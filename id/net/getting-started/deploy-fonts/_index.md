---
title: Menyebarkan Font untuk Aspose.Slides di Linux dan Docker
linktitle: Menyebarkan Font
type: docs
weight: 145
url: /id/net/deploy-fonts/
keywords:
- menyebarkan font
- menginstal font
- font di Docker
- font di Linux
- font yang hilang
- substitusi font
- font inti Microsoft
- ttf-mscorefonts-installer
- font khusus
- font default
- server
- kontainer
- konversi PDF
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menyebarkan font untuk Aspose.Slides .NET pada server Linux dan kontainer Docker: periksa font mana yang digantikan, instal paket font pada Debian, Ubuntu, dan Alpine, tambahkan file font Anda sendiri, dan atur font default."
---
## **Gambaran Umum**

Aspose.Slides menggambar teks dengan font yang tersedia saat merender presentasi, misalnya ketika mengonversi slide ke PDF atau ke gambar. Desktop Windows biasanya memiliki font yang digunakan presentasi. Server dan kontainer Linux biasanya hanya memiliki sedikit font atau bahkan tidak ada, sehingga Aspose.Slides menggambar teks dengan font pengganti. Font pengganti memiliki bentuk dan lebar huruf yang berbeda, sehingga baris dapat terbungkus secara berbeda dan teks dapat meluber dari bentuknya, serta karakter yang tidak terdapat pada font pengganti tidak digambar dengan benar. Jika tidak ada font yang terpasang sama sekali, konversi berhenti dengan error.

Artikel ini menunjukkan cara memeriksa font apa yang digantikan oleh Aspose.Slides, cara memasang font pada Debian, Ubuntu, dan Alpine Linux, cara menambahkan file font Anda sendiri, serta cara mengatur font yang digunakan ketika sebuah font tidak ada. Contoh dijalankan di Docker pada image .NET resmi, seperti pada [Run Aspose.Slides for .NET in Docker](/slides/id/net/how-to-run-aspose-slides-in-docker/). Perintah paket adalah instruksi Dockerfile; pada server Linux, jalankan perintah yang sama sebagai root.

Untuk API font itu sendiri, seperti menyematkan font dalam presentasi serta aturan fallback dan penggantian, lihat [PowerPoint Fonts](/slides/id/net/powerpoint-fonts/).

## **Periksa Font yang Digantikan**

Aplikasi konsol berikut melaporkan font yang digantikan oleh Aspose.Slides dalam lingkungan saat ini. Buat folder bernama *FontCheck* dan tambahkan file di bawah ini ke dalamnya.

*FontCheck.csproj* mereferensikan [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), paket untuk Debian dan Ubuntu. Ia juga menyalin file dari folder *fonts* opsional ke output aplikasi; bagian [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) menggunakannya.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* menambahkan satu kotak teks per nama font ke slide dan menetapkan font melalui properti [LatinFont](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/latinfont/). Nama font diambil dari baris perintah; tanpa argumen, aplikasi memeriksa Calibri, Arial, dan Times New Roman. Ia mencetak folder tempat Aspose.Slides mencari font ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/getfontfolders/)), merender slide ke *output/fonts.pdf*, dan mencetak substitusi yang dilaporkan oleh [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/). Dua langkah opsional di awal, memuat folder *fonts* dan membaca variabel `DEFAULT_FONT`, dijelaskan lebih lanjut dalam artikel ini.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Font yang akan diperiksa: argumen baris perintah, atau tiga font Office umum.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Muat file font dari folder fonts di samping aplikasi, jika ada.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Gunakan font yang dinamai dalam variabel lingkungan DEFAULT_FONT, jika disetel, untuk teks yang fontnya hilang.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* menyimpan hasil build lokal agar tidak termasuk dalam konteks build:

```text
bin/
obj/
output/
```

*Dockerfile* membangun aplikasi dengan image .NET SDK dan menjalankannya pada image runtime .NET. Tahap runtime menginstal `libfontconfig1`, yang dibutuhkan oleh Aspose.Slides.NET6.CrossPlatform, serta font DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/id/net/how-to-run-aspose-slides-in-docker/) menjelaskan setiap instruksi.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Bangun image dan jalankan pemeriksaan:

```bash
docker build -t font-check .
docker run --rm font-check
```

Image hanya memiliki font DejaVu, sehingga ketiga font diganti dengan DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Untuk memeriksa font pada presentasi Anda sendiri, berikan nama-nama font tersebut sebagai argumen, misalnya `docker run --rm font-check "Segoe UI" Consolas`. Untuk menyalin *output/fonts.pdf* keluar dari kontainer, gunakan perintah pada [Copy the Output to Your Machine](/slides/id/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Pasang Font pada Debian dan Ubuntu**

### **Microsoft Core Fonts**

Paket `ttf-mscorefonts-installer` mengunduh dan memasang font inti Microsoft untuk web, antara lain Arial, Times New Roman, Courier New, Verdana, Georgia, dan Trebuchet MS. Font-font tersebut dilisensikan di bawah perjanjian lisensi akhir pengguna (EULA) Microsoft, dan paket hanya memasangnya setelah EULA diterima. Build Docker tidak dapat menjawab prompt, sehingga installer menolak EULA dan tidak memasang font apa pun, walaupun `apt-get install` tetap melaporkan sukses. Terima EULA dengan `debconf-set-selections` **sebelum** paket dipasang.

Di *Dockerfile*, ganti instruksi `RUN` yang memasang paket pada tahap runtime dengan:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bangun image dan jalankan pemeriksaan lagi dengan dua perintah yang sama. Arial dan Times New Roman kini terpasang:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, font default sebuah presentasi yang dibuat oleh Aspose.Slides, bukan termasuk font inti, sehingga tetap diganti. Lihat [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Pada Debian, paket berada di komponen repositori `contrib`, yang tidak diaktifkan pada image Debian; image .NET 8 dan .NET 9 default berbasis Debian 12. Aktifkan `contrib` dalam instruksi yang sama:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Image .NET 10 berbasis Ubuntu sudah mengaktifkan `multiverse`, komponen Ubuntu yang berisi paket tersebut.

### **Paket Font Lainnya**

Debian dan Ubuntu juga menyediakan font dengan lisensi bebas, misalnya:

| Paket | Font |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, dan Mono, dengan metrik yang sama seperti Arial, Times New Roman, dan Courier New |
| `fonts-crosextra-carlito` | Carlito, dengan metrik yang sama seperti Calibri |
| `fonts-crosextra-caladea` | Caladea, dengan metrik yang sama seperti Cambria |

Pasang mereka dengan `apt-get install` dalam instruksi `RUN` yang sama. Aspose.Slides.NET6.CrossPlatform tidak menerapkan alias font dari konfigurasi font Linux: dengan `fonts-liberation` terpasang, teks dalam Arial masih digambar dengan font pengganti umum, bukan dengan Liberation Sans. Untuk menggunakan font yang kompatibel secara metriks sebagai pengganti yang hilang, atur sebagai [font default](#set-a-default-font-for-missing-fonts) atau tambahkan [aturan substitusi font](/slides/id/net/font-substitution/).

## **Tambahkan File Font Anda Sendiri**

Font yang tidak dipaketkan oleh distribusi, seperti font organisasi Anda atau font lain yang Anda miliki lisensinya untuk server, dapat ditambahkan sebagai file font. Letakkan file font, misalnya file *.ttf*, dalam folder bernama *fonts* di dalam folder *FontCheck*. Contoh di bawah menggunakan file Carlito, sebuah font dengan metrik yang sama seperti Calibri, yang dapat Anda unduh dari [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Pasang Font di Folder Font Sistem**

Aspose.Slides membaca font di folder yang dicetak pada baris `Font folders`. Untuk memasang font Anda bagi setiap aplikasi dalam image, salin mereka ke */usr/local/share/fonts*, folder untuk font yang dipasang secara lokal. Tambahkan instruksi ini ke tahap runtime *Dockerfile*, setelah instruksi `RUN` yang memasang paket:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Muat Font dari Folder Aplikasi**

Alih-alih memasang font dalam image, Anda dapat mengirimnya bersama aplikasi dan memuatnya dengan [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfonts/). Font kemudian hanya tersedia untuk Aspose.Slides, dan mereka dideploy bersama aplikasi. *FontCheck* melakukan hal ini: *FontCheck.csproj* menyalin folder *fonts* ke output aplikasi, dan *Program.cs* mengirim folder tersebut ke `LoadExternalFonts` sebelum membuat presentasi. [Custom Font](/slides/id/net/custom-font/) menjelaskan cara lain untuk menyediakan font, seperti memuatnya dari memori.

Bangun kembali image, lalu periksa Calibri dan Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Folder aplikasi kini muncul di antara folder font, dan Carlito tidak lagi digantikan:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Atur Font Default untuk Font yang Hilang**

Ketika sebuah font tidak ada, Aspose.Slides menggunakan font pengganti yang dipilihnya sendiri. Untuk memilihnya sendiri, atur properti [DefaultRegularFont](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaultregularfont/) pada [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/) dan kirim opsi tersebut ke konstruktor [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). *FontCheck* membaca nama font dari variabel lingkungan `DEFAULT_FONT`. Dengan Carlito dimuat, gunakan ia untuk font yang hilang:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri kini digambar dengan Carlito, yang karakternya memiliki lebar yang sama dengan Calibri, sehingga teks mempertahankan pemutusan barisnya:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Font default menggantikan setiap font yang hilang. Untuk memetakan font individu, misalnya Arial ke Liberation Sans dan Calibri ke Carlito, gunakan [aturan substitusi font](/slides/id/net/font-substitution/). Aturan mengubah output yang dirender, tetapi `GetSubstitutions` tidak mencerminkannya, jadi periksa font dalam file output sebagai gantinya. Untuk teks Asia, juga atur [DefaultAsianFont](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaultasianfont/); lihat [Default Font](/slides/id/net/default-font/).

## **Pasang Font pada Alpine Linux**

Pada Alpine Linux, gunakan paket Aspose.Slides.NET; [Run on Alpine Linux](/slides/id/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) mencantumkan perubahan pada proyek. Buat perubahan yang sama pada *FontCheck*: ganti referensi paket, tambahkan pernyataan `SetSwitch` ke *Program.cs*, dan gunakan tahap runtime ini, yang juga memasang Microsoft core fonts:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` mengunduh dan memasang font inti Microsoft yang sama seperti paket Debian dan Ubuntu, dan EULA mereka berlaku dengan cara yang sama. `fc-cache` memperbarui cache font.

Dengan Aspose.Slides.NET di Linux, perpustakaan konfigurasi font (fontconfig) memilih pengganti untuk font yang hilang, dan `GetSubstitutions` tidak melaporkannya, sehingga *FontCheck* mencetak `No font substitutions.` Untuk melihat font apa yang digunakan untuk sebuah nama font, tanyakan kepada fontconfig di dalam kontainer:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Dengan Microsoft core fonts terpasang, Arial digunakan untuk Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Tanpa mereka, ketika instruksi `RUN` hanya memasang `icu-libs libgdiplus font-dejavu`, perintah yang sama mencetak:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Mengapa sebuah presentasi terlihat berbeda ketika dikonversi di server?**

Server tidak memiliki font yang digunakan presentasi, sehingga Aspose.Slides menggambar teks dengan font pengganti yang memiliki lebar huruf berbeda. Jalankan *FontCheck* dengan nama-nama font presentasi untuk melihat font apa yang digantikan, lalu instal font tersebut atau muat dari folder aplikasi.

**Build memasang ttf-mscorefonts-installer, tetapi Arial tetap digantikan. Mengapa?**

EULA tidak diterima sebelum paket dipasang, sehingga installer melewati font. Tambahkan perintah `debconf-set-selections` sebelum `apt-get install`, seperti pada [Microsoft Core Fonts](#microsoft-core-fonts), dan bangun kembali image.

**Apakah komputer yang membuka PDF membutuhkan font?**

Tidak. Pada contoh ini, PDF berisi font yang digunakan untuk menggambar teks, sehingga tampil sama di komputer mana pun. Font hanya diperlukan di tempat Aspose.Slides merender presentasi.