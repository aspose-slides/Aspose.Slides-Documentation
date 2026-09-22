---
title: Mengambil dan Memperbarui Informasi Presentasi dalam C++
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/cpp/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- ambil properti
- baca properti
- ubah properti
- modifikasi properti
- perbarui properti
- periksa PPTX
- periksa PPT
- periksa ODP
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Jelajahi slide, struktur, dan metadata dalam presentasi PowerPoint dan OpenDocument menggunakan C++ untuk wawasan yang lebih cepat dan audit konten yang lebih cerdas."
---
## **Ikhtisar**

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumennya tanpa membuat model objek presentasi yang lengkap. Hal ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini mendemonstrasikan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/) dan [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/), serta pembaruan terarah melalui [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/).

## **Memeriksa Format Presentasi**

Jika Anda sudah memiliki presentasi yang dimuat, lihat [Determine the Original Presentation Format](/slides/id/cpp/detect-presentation-source-format/) untuk deteksi setelah pemuatan dan keterbatasan aliran legacy PPT, PPS, dan POT.

Gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memeriksa file tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Metode [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/get_loadformat/) melaporkan format yang terdeteksi, seperti PPTX, PPT, atau ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Membangun Inventaris Presentasi Ringan**

Saat Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris yang kompak untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memperoleh objek [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/), lalu panggil [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi secara lengkap.

Properti tambahan yang diekspose oleh [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/) memberikan nilai inventaris berikut:

| Metode | Nilai inventaris |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_slides/) | Jumlah total slide. |
| [get_HiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Jumlah slide tersembunyi. |
| [get_Notes](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_notes/) | Jumlah slide yang berisi catatan. |
| [get_Paragraphs](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Jumlah total paragraf, bila tersedia. |
| [get_Words](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_words/) | Jumlah total kata. |
| [get_MultimediaClips](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Jumlah total klip audio dan video. |

Contoh berikut membaca nilai-nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan mencetak inventaris yang kompak. Contoh ini juga menggabungkan [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_headingpairs/) dengan [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) untuk menampilkan grup konten seperti font, tema, dan judul slide.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Setiap [IHeadingPair](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/) menyediakan nama grup melalui [IHeadingPair::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/get_name/) dan jumlah item dalam grup tersebut melalui [IHeadingPair::get_Count](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) mengembalikan array datar yang terurut, jadi konsumsi jumlah judul berurutan yang ditentukan oleh setiap pasangan heading.

### **Metadata yang Disimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung kembali nilai-nilai ini pada pemanggilan ini. Properti yang tidak ada direpresentasikan dengan nilai default, dan nilai yang disimpan dapat menjadi usang jika aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk jumlah slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta heading pairs dan judul bagian. Ketersediaannya tergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika suatu properti tidak ada atau tidak disegarkan oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih-alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik dokumen umum, seperti jumlah halaman, paragraf, dan kata, tetapi nilai-nilai ini tidak selalu berkorespondensi dengan properti tambahan khusus PowerPoint. Metadata slide tersembunyi, catatan, multimedia, heading‑pair, dan judul bagian mungkin tidak tersedia, sehingga properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten yang bersangkutan tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan awal. Muat presentasi dan inspeksi model objeknya yang hidup ketika hasil harus mencerminkan perubahan dalam memori atau ketika Anda perlu memverifikasi konten presentasi yang sebenarnya.

## **Memperbarui Properti Presentasi**

Properti yang dikembalikan oleh [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Terapkan perubahan dengan [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), lalu tulis presentasi yang terikat dengan [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Gambar berikut menunjukkan properti dokumen asli.

![Original document properties of the PowerPoint presentation](input_properties.png)

Contoh berikut mengubah judul dan waktu penyimpanan terakhir serta menulis hasilnya ke file baru:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Gambar berikut menunjukkan properti dokumen yang telah diperbarui.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Password-Protect Presentations](/slides/id/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/id/cpp/write-protected-presentation/)

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font disematkan dan font apa saja yang disematkan?**

Muat presentasi dan gunakan [Presentation::get_FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/). Panggil [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) untuk memperoleh font yang disematkan dan [FontsManager::GetFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak disematkan.

**Bagaimana saya dapat dengan cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) melalui [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dan [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi dalam memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai langsung; iterasikan melalui [Presentation::get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slides/) dan inspeksi metode [Slide::get_Hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/get_hidden/) pada setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran dan orientasi slide kustom digunakan, dan apakah berbeda dari nilai default?**

Ya. Muat presentasi dan baca [Presentation::get_SlideSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slidesize/). Periksa [ISlideSize::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_size/), dan [ISlideSize::get_Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_orientation/) untuk membandingkan pengaturan saat ini dengan preset dan dimensi yang diharapkan.

**Apakah ada cara cepat untuk melihat apakah chart merujuk ke sumber data eksternal?**

Ya. Temukan tiap [Chart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/) dan inspeksi [ChartData::get_DataSourceType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Untuk workbook eksternal, baca [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Tipe sumber data dan jalur mengidentifikasi referensi eksternal, tetapi memverifikasi ketersediaan target memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide “berat” yang mungkin memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation::get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slides/) dan koleksi [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_shapes/) pada tiap slide. Gunakan jumlah shape serta keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur rendering atau ekspor representatif sebelum menganggap suatu slide sebagai hambatan kinerja yang terkonfirmasi.