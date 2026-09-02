---
title: Ambil dan Perbarui Informasi Presentasi dalam C++
linktitle: Informasi Presentasi
type: docs
weight: 30
url: /id/cpp/examine-presentation/
keywords:
- format presentasi
- properti presentasi
- properti dokumen
- dapatkan properti
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

Aspose.Slides dapat mengidentifikasi format presentasi dan membaca metadata dokumen tanpa membuat model objek presentasi yang lengkap. Ini berguna ketika Anda perlu mengklasifikasikan file, membuat inventaris, atau memeriksa properti sebelum memutuskan apakah akan memuat dan memproses konten presentasi.

Artikel ini menunjukkan inspeksi ringan melalui [PresentationFactory](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/) dan [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/), serta pembaruan terarah melalui [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/).

## **Periksa Format Presentasi**

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

## **Bangun Inventaris Presentasi Ringan**

Saat Anda memproses banyak file presentasi, Anda mungkin memerlukan inventaris ringkas untuk validasi, pengindeksan, atau sistem manajemen dokumen. Dalam skenario ini, gunakan [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) untuk memperoleh objek [IPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/), lalu panggil [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) untuk membaca metadata dokumen. Pendekatan ini tidak membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) atau mengharuskan Anda menelusuri model objek presentasi secara lengkap.

Properti tambahan yang disajikan oleh [IDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/) menyediakan nilai inventaris berikut:

| Metode | Nilai inventaris |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_slides/) | Jumlah total slide. |
| [get_HiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Jumlah slide tersembunyi. |
| [get_Notes](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_notes/) | Jumlah slide yang berisi catatan. |
| [get_Paragraphs](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Jumlah total paragraf, bila tersedia. |
| [get_Words](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_words/) | Jumlah total kata. |
| [get_MultimediaClips](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Jumlah total klip audio dan video. |

Contoh berikut membaca nilai‑nilai ini tanpa membuat objek [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan mencetak inventaris yang ringkas. Contoh ini juga menggabungkan [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_headingpairs/) dengan [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) untuk menampilkan grup konten seperti font, tema, dan judul slide.

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

Setiap [IHeadingPair](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/) menyediakan nama grup melalui [IHeadingPair::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/get_name/) dan jumlah item dalam grup tersebut melalui [IHeadingPair::get_Count](https://reference.aspose.com/slides/id/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) mengembalikan array datar berurutan, sehingga konsumsi jumlah judul berurutan yang ditentukan oleh tiap pasangan heading.

### **Metadata yang Disimpan dan Batasan Format**

Properti inventaris yang dikembalikan oleh [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) mencerminkan metadata yang tersedia dalam dokumen sumber. Aspose.Slides tidak memuat dan menelusuri model objek presentasi untuk menghitung ulang nilai‑nilai ini pada pemanggilan ini. Properti yang tidak ada diwakili oleh nilai default, dan nilai yang disimpan dapat menjadi usang bila aplikasi yang terakhir menyimpan file tidak memperbarui properti dokumennya.

- **PPTX:** Format ini menyediakan properti dokumen tambahan untuk jumlah slide, catatan, slide tersembunyi, paragraf, kata, dan multimedia, serta pasangan heading dan judul bagian. Ketersediaannya bergantung pada properti mana yang ditulis oleh pembuat dokumen.
- **PPT:** Format biner dapat menyimpan properti ringkasan dokumen yang bersesuaian. Jika suatu properti tidak ada atau tidak diperbarui oleh pembuat dokumen, Aspose.Slides mengembalikan nilai yang disimpan atau nilai default alih-alih menghitungnya dari slide.
- **ODP:** Metadata OpenDocument menyediakan statistik dokumen umum, seperti jumlah halaman, paragraf, dan kata, namun nilai‑nilai ini tidak selalu berkorespondensi dengan setiap properti tambahan khusus PowerPoint. Metadata slide tersembunyi, catatan, multimedia, pasangan heading, dan judul bagian mungkin tidak tersedia, dan properti inventaris dapat mengembalikan nilai default. Jangan menganggap nilai nol atau array kosong sebagai bukti otoritatif bahwa konten yang bersangkutan tidak ada.

Gunakan pendekatan metadata ringan untuk inventaris dan pemeriksaan pendahuluan. Muat presentasi dan inspeksi model objek secara langsung ketika hasil harus mencerminkan perubahan di memori atau ketika Anda perlu memverifikasi konten presentasi yang sesungguhnya.

## **Perbarui Properti Presentasi**

Properti yang dikembalikan oleh [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) juga dapat diubah tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Terapkan perubahan dengan [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), lalu tulis presentasi terikat dengan [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Gambar berikut menunjukkan properti dokumen asli.

![Properti dokumen asli dari presentasi PowerPoint](input_properties.png)

Contoh berikut mengubah judul dan waktu terakhir disimpan serta menulis hasilnya ke file baru:

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

Gambar berikut menunjukkan properti dokumen yang diubah.

![Properti dokumen yang diubah dari presentasi PowerPoint](output_properties.png)

## **Tautan Berguna**

Untuk pemeriksaan keamanan terkait dan pengaturan perlindungan, lihat artikel berikut:

- [Presentasi dengan Perlindungan Kata Sandi](/slides/id/cpp/password-protected-presentation/)
- [Presentasi dengan Perlindungan Penulisan](/slides/id/cpp/write-protected-presentation/)

## **FAQ**

**Bagaimana cara memeriksa apakah font tersemat dan font apa saja?**

Muat presentasi dan gunakan [Presentation::get_FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/). Panggil [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getembeddedfonts/) untuk memperoleh font yang tersemat dan [FontsManager::GetFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/getfonts/) untuk memperoleh font yang digunakan oleh presentasi. Bandingkan kedua hasil untuk menemukan font yang diperlukan untuk rendering tetapi tidak tersemat.

**Bagaimana cara cepat mengetahui apakah file memiliki slide tersembunyi dan berapa banyak?**

Ketika metadata dokumen yang disimpan cukup, baca [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) melalui [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) dan [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Ini cocok untuk inventaris ringan. Jika presentasi telah dimodifikasi di memori, metadata yang disimpan mungkin hilang atau usang, atau Anda perlu memverifikasi nilai secara langsung; iterasi melalui [Presentation::get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slides/) dan periksa metode [Slide::get_Hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/get_hidden/) pada setiap slide.

**Apakah saya dapat mendeteksi apakah ukuran slide khusus dan orientasi digunakan, serta apakah berbeda dari nilai standar?**

Ya. Muat presentasi dan baca [Presentation::get_SlideSize](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slidesize/). Periksa [ISlideSize::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_size/), dan [ISlideSize::get_Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/get_orientation/) untuk membandingkan pengaturan saat ini dengan preset dan dimensi standar.

**Apakah ada cara cepat untuk melihat apakah bagan merujuk ke sumber data eksternal?**

Ya. Temukan setiap [Chart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/) dan periksa [ChartData::get_DataSourceType](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Untuk buku kerja eksternal, baca [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Tipe sumber data dan jalur mengidentifikasi referensi eksternal, tetapi memverifikasi ketersediaan target memerlukan pemeriksaan sumber daya terpisah.

**Bagaimana saya dapat menilai slide “berat” yang mungkin memperlambat rendering atau ekspor PDF?**

Tidak ada properti kompleksitas tunggal. Telusuri [Presentation::get_Slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slides/) dan koleksi [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/get_shapes/) pada tiap slide. Gunakan hitungan shape serta keberadaan gambar besar, efek, animasi, atau multimedia sebagai sinyal penyaringan, dan ukur representasi render atau ekspor sebelum menganggap slide sebagai bottleneck kinerja yang pasti.