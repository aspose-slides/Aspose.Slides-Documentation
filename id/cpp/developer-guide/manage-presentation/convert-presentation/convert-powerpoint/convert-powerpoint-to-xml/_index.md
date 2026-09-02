---
title: Mengonversi Presentasi PowerPoint ke XML di C++
linktitle: PowerPoint ke XML
type: docs
weight: 145
url: /id/cpp/convert-powerpoint-to-xml/
keywords:
- mengonversi PowerPoint ke XML
- mengonversi presentasi ke XML
- PPT ke XML
- PPTX ke XML
- ODP ke XML
- PowerPoint XML Presentation
- SaveFormat::Xml
- menyimpan presentasi sebagai XML
- mengekspor presentasi ke XML
- aliran XML
- C++
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument menjadi file atau aliran PowerPoint XML di C++ dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Aspose.Slides for C++ dapat mengonversi presentasi PowerPoint ke format PowerPoint XML Presentation. Output XML berguna ketika Anda memerlukan representasi berbasis teks untuk memeriksa struktur presentasi, memecahkan masalah dokumen yang dihasilkan, membandingkan output dalam pengujian otomatis, atau mengintegrasikan dengan alur kerja yang mengonsumsi XML alih‑alih paket presentasi.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` membuat PowerPoint XML Presentation. Ini tidak mengekstrak bagian individual Office Open XML yang disimpan di dalam paket PPTX. Jika Anda membutuhkan bagian paket PPTX yang tepat, seperti `ppt/presentation.xml` atau file XML slide individual, periksa paket PPTX itu sendiri.
{{% /alert %}}

## **Konversi Presentasi ke File XML**

Muat presentasi sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), lalu berikan jalur output dan `SaveFormat::Xml` ke [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/). Sumber dapat berupa format presentasi apa pun yang didukung untuk pemuatan, seperti PPT, PPTX, atau ODP.

Contoh berikut mengonversi presentasi PPTX ke file XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Menulis Output XML ke Stream**

Gunakan overload stream dari [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) ketika XML harus tetap berada di memori atau diteruskan ke komponen lain, seperti layanan web, penyedia penyimpanan, atau pipeline pemrosesan XML. Contoh berikut menulis hasil ke [MemoryStream](https://reference.aspose.com/slides/id/cpp/system.io/memorystream/) dan mengatur ulang posisinya untuk pembacaan selanjutnya:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Lewatkan xmlStream ke komponen berikutnya dalam alur kerja.
```

## **Bandingkan XML dengan Format Presentasi dan Ekspor**

Pilih format output sesuai dengan cara hasil akan digunakan:

| Format | Output | Penggunaan umum |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Sebuah PowerPoint XML Presentation | Memeriksa struktur, memecahkan masalah, membandingkan output yang dihasilkan, dan integrasi berbasis XML |
| PPT (`.ppt`) | File presentasi biner warisan | Kompatibilitas dengan alur kerja PowerPoint lama |
| PPTX (`.pptx`) | Paket Office Open XML yang berisi banyak bagian | Pengeditan PowerPoint reguler dan pertukaran presentasi |
| PDF atau TIFF | Halaman dengan tata letak tetap atau gambar multi halaman | Melihat, mencetak, dan mengarsipkan |
| PNG, JPEG, atau SVG | Representasi render dari slide individual | Gambar mini, pratinjau, dan aset gambar |
| HTML atau HTML5 | Output presentasi yang berorientasi web | Penayangan di peramban dan publikasi web |

Berbeda dengan PPT dan PPTX, output XML terutama ditujukan untuk inspeksi dan alur kerja berbasis data. Berbeda dengan PDF, TIFF, HTML, dan format gambar slide, XML mewakili data presentasi bukan merender slide sebagai halaman atau aset visual. Tabel [format file yang didukung](/slides/id/cpp/supported-file-formats/) mencantumkan PowerPoint XML Presentation sebagai format hanya untuk penyimpanan, jadi jangan gunakan ketika alur kerja harus memuat file yang diekspor kembali ke Aspose.Slides untuk penyuntingan lanjutan.

## **FAQ**

**Apakah `SaveFormat::Xml` sama dengan menyimpan file PPTX?**

Tidak. PPTX adalah paket yang berisi banyak bagian Office Open XML, sedangkan `SaveFormat::Xml` membuat file PowerPoint XML Presentation.

**Apakah saya dapat menyimpan output XML tanpa membuat file di disk?**

Ya. Berikan stream yang dapat ditulis ke [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/). Misalnya, gunakan [MemoryStream](https://reference.aspose.com/slides/id/cpp/system.io/memorystream/) untuk pemrosesan dalam memori.

**Apakah Aspose.Slides dapat memuat kembali file XML yang diekspor?**

Tidak. PowerPoint XML Presentation saat ini hanya didukung untuk penyimpanan, bukan untuk pemuatan. Gunakan PPTX atau format presentasi lain yang didukung ketika diperlukan penyuntingan bolak‑balik.

**Apakah konversi XML merender setiap slide sebagai halaman atau gambar?**

Tidak. Konversi XML menulis data presentasi yang terstruktur. Gunakan PDF atau TIFF untuk output berbasis halaman, atau PNG, JPEG, dan SVG untuk gambar slide individual.