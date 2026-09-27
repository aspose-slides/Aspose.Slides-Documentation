---
title: Instalasi
type: docs
weight: 70
url: /id/nodejs-net/installation/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- Instalasi Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Instal Aspose.Slides untuk Node.js via .NET dari npm di Windows atau Linux: prasyarat, override edge-js, pemulihan NuGet satu kali, dan program pertama yang membuat presentasi."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via .NET adalah paket npm `aspose.slides.via.net`. Ia menjalankan perpustakaan Aspose.Slides .NET di dalam Node.js melalui jembatan [edge-js](https://github.com/agracio/edge-js), sehingga instalasi yang berfungsi memerlukan baik Node.js maupun .NET.

Artikel ini membawa Anda dari mesin bersih ke program pertama yang membuat presentasi. Ada empat langkah: buat proyek dengan override edge-js, instal paket dari npm, pulihkan dependensi .NET paket sekali, dan jalankan skrip Anda dari folder proyek.

## **Prasyarat**

- **Node.js 22 atau 24 LTS**, build x64, dari [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 atau lebih baru**, dari [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Runtime .NET saja tidak cukup: langkah pemulihan di bawah membutuhkan SDK, begitu pula jembatan saat skrip Anda dijalankan. Jalankan `dotnet --list-sdks` untuk memeriksa SDK mana yang terpasang.
- **Hanya pada Linux**:
  - alat pembangunan `python3`, `make`, dan `g++`, karena npm mengompilasi edge-js selama instalasi di Linux;
  - pustaka fontconfig, yang dimuat oleh perpustakaan menggambar native Aspose.Slides.

Pada Debian, paket‑paket ini adalah `python3`, `make`, `g++`, dan `libfontconfig1`.

Langkah‑langkah dalam artikel ini telah diuji pada platform berikut:

| Platform | Hasil |
|---|---|
| Windows x64 dengan Node.js 22 atau 24 | Berfungsi. Diuji dengan Microsoft Visual C++ Redistributable terinstal. |
| Linux x64 dengan Node.js 22 atau 24, dimana OpenSSL sistem berasal dari jalur rilis yang sama dengan OpenSSL yang dibangun ke dalam Node.js, misalnya Debian 13 | Berfungsi. |
| Linux dimana dua versi OpenSSL berbeda, misalnya Debian 12 | Node.js crash dengan segmentation fault ketika sebuah presentasi dibuat. |
| macOS | Tidak diverifikasi. |

Pada Linux, bandingkan dua versi sebelum Anda mulai. Perintah pertama mencetak versi OpenSSL yang dibangun ke dalam Node.js; yang kedua mencetak versi sistem. Gunakan sistem di mana keduanya diawali dengan nomor mayor dan minor yang sama, misalnya `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Jika perintah `openssl` tidak ditemukan, instal paket `openssl` terlebih dahulu.

## **Buat Proyek**

Buat folder untuk proyek Anda, inisialisasi, dan tambahkan override yang memberi tahu npm rilis edge-js mana yang harus diinstal:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Paket ini meminta rilis edge-js yang lebih lama yang binari Windows pra‑dibuatnya berhenti pada Node.js 20, sehingga tanpa override skrip pertama pada Windows berhenti dengan "The edge module has not been pre-compiled for node.js version". Perintah ini menulis override ke bagian `overrides` di `package.json`; tambahkan sebelum Anda menginstal paket.

## **Instal Paket**

Instal Aspose.Slides untuk Node.js via .NET dari npm:

```sh
npm install aspose.slides.via.net
```

Selama instalasi, paket menyalin pustaka menggambar native-nya (file‑file yang namanya mengandung `aspose.slides.drawing.capi`) ke dalam folder proyek, di sebelah `package.json`.

Paket ini juga dipublikasikan sebagai arsip ZIP di [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). Artikel ini hanya membahas instalasi dari npm.

## **Pulihkan Dependensi .NET**

Paket ini berisi assembly .NET Aspose.Slides, tetapi tidak 20 paket NuGet yang menjadi dependensi assembly tersebut. Pada waktu berjalan, .NET mencari mereka di cache paket NuGet: `%USERPROFILE%\.nuget\packages` di Windows, `~/.nuget/packages` di Linux, atau folder yang ditetapkan dalam variabel lingkungan `NUGET_PACKAGES`. Jika tidak ada, skrip pertama berhenti dengan "assembly specified in the dependencies manifest was not found".

Untuk mengisi cache, buat folder bernama `deps` di folder proyek dan simpan file berikut di dalamnya dengan nama `deps.csproj`. Setiap item `PackageDownload` mengunduh satu paket pada versi tepat yang berada dalam kurung; tidak ada yang dibangun.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Kemudian pulihkan dari folder proyek:

```sh
dotnet restore deps/deps.csproj
```

Anda membutuhkan langkah ini satu kali per mesin, bukan satu kali per proyek: paket‑paket tetap di cache NuGet, dan proyek‑proyek selanjutnya pada mesin yang sama menggunakannya. Setelah pemulihan, Anda dapat menghapus folder `deps`.

## **Jalankan Program Pertama**

Buat file bernama `hello.js` di folder proyek dengan kode berikut. Kode ini membuat presentasi, menambahkan persegi panjang berisi teks "Hello, World!" ke slide pertama, dan menyimpan hasilnya sebagai `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Presentasi baru berisi satu slide kosong.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posisi dan ukuran dalam satuan point (1/72 inci): x, y, lebar, tinggi.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Lepaskan objek .NET yang mendasari presentasi.
    presentation.dispose();
}
```

Jalankan dari folder proyek:

```sh
node hello.js
```

Skrip mencetak `Saved hello.pptx`. Buka `hello.pptx` untuk melihat satu slide dengan persegi panjang terisi yang berisi teks tersebut. Tanpa lisensi, Aspose.Slides juga menambah watermark evaluasi; lihat [Evaluasi Aspose.Slides](/slides/id/nodejs-net/evaluate-aspose-slides/) dan [Lisensi](/slides/id/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Jalankan skrip Anda dari folder proyek, yaitu yang berisi `package.json`. Jalur relatif seperti `hello.pptx` diselesaikan relatif terhadap folder saat ini, dan pada beberapa mesin skrip yang dijalankan dari folder lain tidak dapat membuat presentasi.
{{% /alert %}}

API JavaScript mencerminkan Aspose.Slides untuk .NET: kelas mempertahankan nama .NET mereka, properti dan metode menggunakan camelCase (`Slides` menjadi `slides`, `AddAutoShape` menjadi `addAutoShape`), dan item koleksi dibaca dengan `get(index)`. Tidak ada referensi API terpisah untuk paket ini, jadi gunakan [referensi API Aspose.Slides untuk .NET](https://reference.aspose.com/slides/net/) untuk detail kelas dan anggota, misalnya [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Apa arti "The edge module has not been pre-compiled for node.js version"?**

npm menginstal rilis edge-js yang lebih lama yang diminta paket. Tambahkan override dari [Buat Proyek](#buat-proyek) dan jalankan `npm install` lagi.

**Apa arti "assembly specified in the dependencies manifest was not found"?**

Dependensi .NET tidak ada di cache NuGet. Jalankan yang sama juga melaporkan "edge.initializeClrFunc is not a function". Ikuti [Pulihkan Dependensi .NET](#pulihkan-dependensi-.net) sekali, lalu jalankan skrip Anda lagi.

**Apa arti "The edge native module is not available" pada Linux?**

edge-js tidak dikompilasi selama `npm install`, misalnya karena `python3`, `make`, atau `g++` tidak ada. npm tidak melaporkan ini sebagai kesalahan. Instal alat pembangunan, lalu jalankan `npm rebuild edge-js` di folder proyek.

**Mengapa pembuatan presentasi gagal dengan "Error" kosong?**

Pada Linux, pastikan pustaka fontconfig terinstal (`libfontconfig1` pada Debian); tanpa itu, pustaka menggambar native tidak dapat dimuat. Pada sistem apa pun, pastikan juga Anda menjalankan skrip dari folder proyek.

**Mengapa Node.js crash dengan segmentation fault pada Linux?**

OpenSSL sistem dan OpenSSL yang dibangun ke dalam Node.js berasal dari jalur rilis yang berbeda. Bandingkan seperti yang ditunjukkan di [Prasyarat](#prasyarat) dan gunakan distribusi atau build Node.js di mana keduanya cocok.

**Apakah saya perlu mengulangi pemulihan NuGet untuk setiap proyek?**

Tidak. Pemulihan mengisi cache NuGet untuk akun pengguna Anda, dan setiap proyek pada mesin itu menggunakan cache yang sama.