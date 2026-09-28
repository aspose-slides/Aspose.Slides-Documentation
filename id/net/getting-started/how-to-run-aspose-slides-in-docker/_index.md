---
title: Jalankan Aspose.Slides untuk .NET di Docker
linktitle: Docker
type: docs
weight: 140
url: /id/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Kontainer Docker
- pembangunan multi-tahap
- gambar kontainer
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- font
- konversi PDF
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bangun dan jalankan aplikasi konsol Aspose.Slides untuk .NET dalam Docker: Dockerfile multi-tahap pada gambar .NET resmi, pustaka Linux dan font yang dibutuhkan, serta cara menyalin file yang dihasilkan ke mesin Anda."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menjalankan Aspose.Slides untuk .NET dalam sebuah kontainer Docker. Anda membuat aplikasi konsol kecil yang membuat presentasi dengan kotak teks dan mengonversinya ke PDF, mengemasnya dengan Dockerfile multi‑tahap pada gambar .NET resmi Microsoft, menjalankannya, dan menyalin file yang dihasilkan ke mesin Anda. Artikel ini juga mencantumkan pustaka Linux dan font yang diperlukan Aspose.Slides dalam kontainer dan diakhiri dengan varian untuk Alpine Linux.

Anda hanya memerlukan Docker di mesin Anda. .NET SDK merupakan bagian dari gambar build, sehingga Anda tidak perlu menginstalnya. Untuk menginstal Docker, lihat [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Pilih Paket dan Gambar Dasar**

Gambar kontainer .NET 10 default berbasis Ubuntu 24.04. Pada gambar ini, gunakan paket [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Paket ini memerlukan pustaka `fontconfig`, dan gambar runtime .NET tidak menyertakan pustaka tersebut maupun font apa pun, sehingga Dockerfile dalam artikel ini menginstal keduanya.

Aspose.Slides.NET6.CrossPlatform tidak berjalan pada Alpine Linux. Untuk gambar berbasis Alpine, gunakan paket [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) dengan `libgdiplus`, seperti dijelaskan pada [Run on Alpine Linux](#run-on-alpine-linux). [Instalasi](/slides/id/net/installation/) membandingkan kedua paket tersebut.

## **Buat Proyek**

Buat folder bernama *HelloSlidesDocker* dan tambahkan tiga file berikut ke dalamnya.

*HelloSlidesDocker.csproj* mendeskripsikan aplikasi konsol untuk .NET 10, versi gambar kontainer yang digunakan di bawah, dan mereferensikan Aspose.Slides.NET6.CrossPlatform. Atur versi paket ke yang terbaru yang tercantum di [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* membuat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), menambahkan persegi panjang dengan teks ke slide pertama, dan menyimpan presentasi dua kali dengan metode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/): sebagai PPTX dan sebagai PDF. Kedua file ditempatkan di folder *output* di bawah direktori kerja. Aplikasi kemudian mencantumkan font yang diganti saat PDF dirender, menggunakan [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), sehingga Anda dapat melihat apakah kontainer memiliki font yang digunakan presentasi.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* menjaga folder *bin* dan *obj* dari build lokal, serta output run sebelumnya, tetap di luar konteks build Docker, sehingga gambar dibangun hanya dari file sumber.

```text
bin/
obj/
output/
```

## **Tuliskan Dockerfile**

Tambahkan file bernama *Dockerfile* ke folder yang sama:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

File ini memiliki dua tahapan:

- **Tahap build** dimulai dari gambar .NET SDK. Ia menyalin file proyek dan memulihkan paket NuGet terlebih dahulu, sehingga Docker dapat menggunakan kembali lapisan tersebut selama file proyek tidak berubah. Kemudian menyalin kode sumber dan memublikasikan aplikasi ke */app*.
- **Tahap runtime** dimulai dari gambar runtime .NET yang lebih kecil, yang tidak memiliki SDK, dan menyalin hanya aplikasi yang sudah dipublikasikan. Ia menginstal dua paket:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform memuat pustaka ini saat mulai. Tanpanya, aplikasi berhenti dengan `DllNotFoundException` yang menyebut `libfontconfig.so.1`.
  - `fonts-dejavu-core`: gambar runtime tidak berisi font, dan Aspose.Slides memerlukan setidaknya satu font yang terpasang untuk menggambar teks; tanpa font apa pun, konversi berhenti dengan `InvalidOperationException: Cannot find any fonts installed on the system.` Teks dengan font yang tidak terpasang digambar dengan font substitusi. Font DejaVu adalah set kecil yang memungkinkan teks dirender; untuk merender presentasi dengan font aslinya, lihat [Sebarkan Font](/slides/id/net/deploy-fonts/).

  `--no-install-recommends` dan penghapusan daftar paket menjaga ukuran gambar tetap kecil. Baris terakhir membuat folder *output*, memberikannya kepada pengguna non‑root `app` yang didefinisikan oleh gambar .NET resmi (ID pengguna berada di variabel `APP_UID`), dan menjalankan aplikasi sebagai pengguna tersebut.

Untuk aplikasi ASP.NET Core, mulailah tahap runtime dari `mcr.microsoft.com/dotnet/aspnet:10.0` sebagai gantinya. Gambar tersebut berbasis pada gambar Ubuntu yang sama, sehingga paket yang sama diperlukan.

## **Bangun dan Jalankan Kontainer**

Buka terminal di folder *HelloSlidesDocker*. Bangun gambar, lalu jalankan sebuah kontainer dari gambar tersebut:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Build pertama mengunduh gambar dasar dan paket NuGet, sehingga memakan waktu lebih lama dibandingkan build selanjutnya. Kontainer menjalankan aplikasi dan berhenti. Ia mencetak:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Baris pertama menunjukkan bahwa teks menggunakan Calibri, font default presentasi baru, dan bahwa Calibri tidak terpasang di gambar, sehingga Aspose.Slides menggambar teks dengan DejaVu Sans. Teks dalam PDF adalah teks nyata yang dapat dipilih dengan font tersebut. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Lisensi](/slides/id/net/licensing/).

## **Salin Output ke Mesin Anda**

File berada di folder */app/output* dari kontainer yang sudah berhenti. Salin mereka ke folder *output* di mesin Anda, lalu hapus kontainer:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Dua perintah ini bekerja sama di Bash, PowerShell, dan Windows Command Prompt.

Di Linux, Anda dapat mengganti dengan memasang folder mesin Anda ke dalam kontainer, sehingga aplikasi menulis file langsung ke sana:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Opsi `--user` menjalankan aplikasi dengan ID pengguna dan grup Anda, sehingga dapat menulis ke folder yang Anda buat dan file menjadi milik Anda. `--rm` menghapus kontainer saat berhenti.

## **Jalankan pada Alpine Linux**

Untuk menjalankan aplikasi dalam gambar berbasis Alpine, beralih ke paket Aspose.Slides.NET dan ubah tahap runtime. Tahap build tetap sama.

1. Di *HelloSlidesDocker.csproj*, ganti referensi paket:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. Di *Program.cs*, tambahkan pernyataan ini setelah direktif `using`, sebelum pemanggilan pertama Aspose.Slides. Ini mengaktifkan dukungan System.Drawing untuk Linux yang digunakan Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. Di *Dockerfile*, ganti tahap runtime (semua dari baris `FROM` kedua) dengan:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Tahap Alpine menginstal tiga paket dan mengubah satu pengaturan:

- `libgdiplus` adalah pustaka grafis yang dipakai Aspose.Slides.NET di Linux.
- `font-dejavu` menyediakan font. Tanpa font apa pun, konversi berhenti dengan `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` dan `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` menyediakan data budaya. Gambar .NET Alpine berjalan dalam mode globalisasi‑invariant secara default, dan dalam mode itu Aspose.Slides berhenti dengan `CultureNotFoundException` untuk `en-US`.

Bangun, jalankan, dan salin output dengan perintah yang sama seperti di atas. Pada gambar ini, aplikasi hanya mencetak baris `Saved`: dengan Aspose.Slides.NET di Linux, fontconfig memilih pengganti untuk font yang hilang, dan [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) tidak mencantumkannya. [Sebarkan Font](/slides/id/net/deploy-fonts/) menunjukkan cara memeriksa font yang digunakan.

## **Tanya Jawab**

**Aplikasi berhenti dengan "Unable to load shared library 'libaspose.slides.drawing.capi…'". Apa yang kurang?**

Pada gambar Ubuntu dan Debian, paket `libfontconfig1`; pesan menampilkan `libfontconfig.so.1` sebagai file yang tidak dapat dibuka. Pada Alpine Linux, pesan berarti Aspose.Slides.NET6.CrossPlatform sedang digunakan; beralih ke Aspose.Slides.NET seperti yang dijelaskan pada [Run on Alpine Linux](#run-on-alpine-linux).

**Mengapa teks dalam PDF memakai font berbeda dari di PowerPoint?**

Font yang dipakai presentasi tidak terpasang di gambar, sehingga Aspose.Slides menggambar teks dengan font substitusi. Output aplikasi menyebutkan setiap font yang diganti. [Sebarkan Font](/slides/id/net/deploy-fonts/) menjelaskan cara memasang font di gambar atau memuatnya dari folder aplikasi.

**Apakah saya memerlukan .NET SDK di mesin saya?**

Tidak. Tahap build mengkompilasi aplikasi di dalam gambar SDK. Anda hanya memerlukan SDK jika ingin membangun dan menjalankan aplikasi di luar Docker; lihat [Instalasi](/slides/id/net/installation/).