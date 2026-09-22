---
title: Tentukan Format Presentasi Asli dalam C++
linktitle: Format Sumber
type: docs
weight: 35
url: /id/cpp/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat dalam C++ dengan Aspose.Slides untuk C++, bandingkan API deteksi, dan tangani file, stream, serta format legacy."
---
## **Ikhtisar**

Setelah memuat sebuah presentasi, panggil [Presentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sourceformat/) untuk menentukan format aslinya. Metode ini juga tersedia melalui [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_sourceformat/). Gunakan metode ini ketika pemrosesan selanjutnya bergantung pada format dari mana instansi saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah format sumber dari instansi yang ada.

## **Baca Format Sumber dari File**

Contoh ini membutuhkan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sourceformat/), bukan berdasarkan nama file. Ubah path input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan tersebut dengan logika aplikasi Anda.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Mengenali Nilai yang Didukung**

Enumerasi [SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/sourceformat/) membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentasi Office Open XML |
| `Pptm` | `.pptm` | presentasi Office Open XML dengan makro |
| `Pps` | `.pps` | presentasi slide show PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | slide show Office Open XML |
| `Ppsm` | `.ppsm` | slide show Office Open XML dengan makro |
| `Pot` | `.pot` | template PowerPoint 97–2003 |
| `Potx` | `.potx` | template Office Open XML |
| `Potm` | `.potm` | template Office Open XML dengan makro |
| `Odp` | `.odp` | presentasi OpenDocument |
| `Otp` | `.otp` | template presentasi OpenDocument |
| `Fodp` | `.fodp` | presentasi Flat XML ODF |
| `Xml` | `.xml` | presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini membutuhkan file `sample.pps` yang sudah ada. Membaca byte-nya ke dalam stream memori mensimulasikan input yang diterima tanpa nama file, seperti nilai basis data atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menerima hanya stream.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat menggunakan path file, ekstensi dapat membantu membedakan slide show atau template. Tanpa nama file, konten legacy PPS dan POT mungkin dilaporkan sebagai `SourceFormat::Ppt`; contoh PPS di atas melaporkan `Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk berguna untuk subtipe legacy ini, namun tidak boleh menjadi satu-satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/getpresentationinfo/) dan [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_loadformat/) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi lengkapnya. Gunakan [Presentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sourceformat/) ketika instansi sudah ada.

Contoh ini membutuhkan `sample.pptx` dan mencetak `Pptx` untuk kedua pemeriksaan. Dalam produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak memerlukan inspeksi kedua hanya untuk memperoleh format sumbernya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Hasilnya memiliki tipe enumerasi yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/sourceformat/). Jangan membandingkannya dengan meng-casting nilai numerik mereka atau mengasumsikan setiap format memiliki hasil deteksi yang identik. PowerPoint XML dapat dilaporkan sebagai `LoadFormat::Unknown` sebelum dimuat dan `SourceFormat::Xml` setelah dimuat.

## **Pisahkan Format Sumber dan Output**

Contoh ini membutuhkan `sample.pptx` dan menulis `converted.odp`. Ia mencetak `Pptx` baik sebelum maupun setelah menyimpan instansi asli. Hanya instansi baru yang dimuat dari output ODP yang melaporkan `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Presentasi yang dibuat dari awal dengan `MakeObject<Presentation>()` melaporkan `SourceFormat::Pptx`. Ia tidak memiliki file input: ini adalah nilai default untuk instansi yang baru dibuat, bukan bukti bahwa file PPTX dimuat. Lacak apakah aplikasi Anda membuat atau memuat instansi secara terpisah jika perbedaan tersebut penting.

## **Memetakan Format Sumber ke Ekstensi**

Contoh berikut membutuhkan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/sourceformat/) yang didukung saat ini ke ekstensi konvensional, tanpa mengurai nama file input. Mekanisme fallback menghindari penetapan ekstensi secara diam-diam pada nilai yang tidak dikenali.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Pemetaannya tidak mengubah file atau memulihkan subtipe legacy PPS/POT yang hilang selama pemuatan stream. Untuk penyimpanan sebenarnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali setiap output baik melalui path maupun melalui stream memori. Untuk PPTX dan ODP, kedua metode melaporkan format yang disimpan. Untuk PPS, pemuatan melalui path melaporkan `Pps`, sedangkan pemuatan byte yang sama tanpa nama file melaporkan `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Tabel berikut merangkum identifikasi format sumber untuk presentasi dengan ekstensi yang cocok:

| Format Tersimpan | SourceFormat dari path file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` masing-masing | Sama seperti path file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` masing-masing | Sama seperti path file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` masing-masing | Sama seperti path file |
| ODP, OTP | `Odp`, `Otp` masing-masing | Sama seperti path file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Konten legacy PPS/POT dinormalkan menjadi `Ppt` untuk stream tanpa nama. Tabel tersebut menggambarkan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah format sumber dari presentasi yang dimuat dari PPTX?**

Tidak. Instansi yang ada masih melaporkan `Pptx`. Instansi yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Apakah sebuah stream selalu dapat membedakan presentasi legacy, slide show, dan template?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah bila perbedaan tersebut diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation::get_SourceFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_sourceformat/). Gunakan [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/getpresentationinfo/) untuk inspeksi sebelum memuat.