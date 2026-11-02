---
title: Kelola Hyperlink Presentasi dalam C++
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/cpp/manage-hyperlinks/
keywords:
  - tambahkan URL
  - tambahkan hyperlink
  - buat hyperlink
  - format hyperlink
  - hapus hyperlink
  - perbarui hyperlink
  - hyperlink teks
  - hyperlink slide
  - hyperlink bentuk
  - hyperlink gambar
  - hyperlink video
  - hyperlink dapat diubah
  - PowerPoint
  - OpenDocument
  - presentasi
  - C++
  - Aspose.Slides
description: "Menambahkan, memformat, memperbarui, dan menghapus hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++, menggunakan contoh C++."
---
## **Pendahuluan**

Hyperlink menghubungkan konten presentasi ke situs web atau lokasi di dalam presentasi. Di PowerPoint, hyperlink biasanya berfungsi dua tujuan:

* Membuka situs web dari teks, bentuk, atau bingkai media.
* Menavigasi ke slide lain, misalnya, dari daftar isi.

Aspose.Slides untuk C++ memungkinkan Anda menambahkan tautan ini, mengontrol tampilan dan suaranya, memperbarui pengaturannya, dan menghapusnya. Contoh di bawah menunjukkan cara bekerja dengan hyperlink pada elemen individual dan cara mengakses hyperlink pada tingkat presentasi, slide, atau bingkai teks.

{{% alert color="info" title="Note" %}}
Anda juga dapat mengedit presentasi dengan [editor PowerPoint Aspose online gratis](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Tambahkan Hyperlink URL**

Anda dapat menetapkan URL situs web ke teks, bentuk, atau bingkai media. Elemen tempat Anda menetapkan hyperlink menentukan area yang dapat diklik: bagian teks menautkan teks yang dipilih, sementara bentuk atau bingkai menautkan objek slide.

Untuk presentasi yang berisi hyperlink relatif, lihat [Kelola Dasar Hyperlink](/slides/id/cpp/presentation-properties/#manage-the-hyperlink-base) untuk membaca, mengubah, atau menghapus dasar tingkat dokumen.

### **Tambahkan Hyperlink URL ke Teks**

Untuk menautkan teks ke situs web, buat sebuah [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) dan tetapkan menggunakan metode [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) pada bagian teks, seperti ditunjukkan di bawah. Hanya bagian teks tersebut yang menjadi dapat diklik.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Tambahkan Hyperlink URL ke Bentuk dan Bingkai Media**

Untuk membuat bentuk atau bingkai dapat diklik, gunakan metode [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/) miliknya. Hyperlink melekat pada objek itu sendiri bukan pada bagian teks di dalamnya.

Pendekatan yang sama berlaku untuk bingkai gambar, audio, dan video: tetapkan hyperlink ke bingkai dan gunakan [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) untuk menambahkan petunjuk bila diperlukan.

Contoh berikut membuat persegi panjang dapat diklik:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Hyperlink internal memungkinkan pembaca melompat dari daftar isi ke slide tertentu. Contoh berikut menggunakan [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) untuk menautkan teks “Page 2” pada slide pertama ke slide kedua.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Format Hyperlink**

### **Warna**

Metode [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) dari [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) menentukan apakah hyperlink menggunakan warna hyperlink presentasi atau pemformatan bagian teks. Untuk menerapkan warna teks khusus, pilih [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) dan tetapkan warna isi bagian. Fitur ini diperkenalkan di PowerPoint 2019; versi lebih lama tidak menerapkan pengaturan ini.

Contoh berikut menambahkan dua hyperlink teks ke slide yang sama. Yang pertama menggunakan isi teks berwarna merah, sementara yang kedua tetap menggunakan warna hyperlink default.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **Suara**

Hyperlink dapat memutar suara saat diaktifkan atau menghentikan suara yang sudah diputar. Gunakan metode berikut untuk mengonfigurasi perilaku ini:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) menentukan audio yang terkait dengan hyperlink.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) mengontrol apakah mengaktifkan hyperlink menghentikan suara sebelumnya.

#### **Tambahkan Suara Hyperlink**

Contoh berikut memuat `sampleaudio.wav` dan mengaitkannya dengan tombol pada slide pertama. Mengklik tombol memutar suara dan menavigasi ke slide berikutnya. Bentuk kedua pada slide itu menghentikan suara sebelumnya saat diklik, tanpa melakukan aksi navigasi.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Ekstrak Suara Hyperlink**

Contoh berikut membuka presentasi yang dibuat di atas dan membaca audio hyperlink bentuk pertama ke memori melalui [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) dan [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Pengaturan Tooltip dan Interaksi**

Anda dapat memperbarui pengaturan [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) berikut melalui metode ini setelah menetapkan hyperlink ke teks atau bentuk:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) mengatur teks yang dapat ditampilkan penonton sebagai petunjuk untuk tautan.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) menentukan bingkai target dalam frameset HTML induk, bila berlaku.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) mengontrol apakah mengaktifkan tautan menambahkan tujuan ke daftar hyperlink yang telah dilihat.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) mengontrol apakah hyperlink disorot saat diklik.

## **Hapus Hyperlink dari Presentasi**

Gunakan [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) untuk mengumpulkan kontainer hyperlink, termasuk tautan bagian teks, sebelum mengubahnya. Contoh berikut menghapus kedua tipe aktivasi dari slide pertama. Untuk menghapus hanya satu tipe, panggil hanya [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) atau [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); menghapus aksi klik tidak menghapus pasangan mouse-over.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Untuk penghapusan tanpa syarat, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) menghapus kedua tipe aktivasi dalam lingkup yang dipilih dalam satu pemanggilan. Untuk pembersihan selektif dan cakupan master, tata letak, serta catatan, lihat [Laporan, Sanitasi, dan Verifikasi Hyperlink](#report-sanitize-and-verify-hyperlinks).

## **Bangun Inventaris Hyperlink Lengkap**

Sebelum mendistribusikan presentasi, inventarisasi aksi interaktifnya serta tautan webnya. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mengembalikan objek [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/), bukan daftar datar string URL. Periksa baik [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) maupun [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) pada setiap kontainer. Mereka independen: kontainer yang sama dapat menampilkan kedua aksi, sehingga laporan lengkap memerlukan hingga dua baris per kontainer.

Memindai hanya hyperlink tingkat bentuk dapat melewatkan tautan yang terlampir pada bagian teks. Kueri lingkup yang tepat sebagai gantinya, dan simpan kontainer yang dikembalikan sehingga Anda dapat memperbarui atau menghapus aksinya nanti.

### **Kueri Lingkup Presentasi, Slide, dan Bingkai Teks**

Antarmuka [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) tersedia melalui [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), dan [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). Setiap lingkup mendukung kueri yang sama:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) mengembalikan kontainer dengan aksi klik.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) mengembalikan kontainer dengan aksi mouse-over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) mengembalikan kontainer dengan salah satu atau kedua aksi.

Contoh berikut membuat `hyperlink-audit-input.pptx` dengan tautan klik eksternal, tautan mouse-over file, navigasi slide internal, tautan mouse-over teks, dan aksi makro. Itu tidak mengeksekusi aksi-aksi tersebut. Ketiga kueri yang sama bekerja pada setiap lingkup; hitungan menggambarkan kontainer, bukan total aksi. Lingkup bingkai teks mengecualikan tautan milik bentuk yang menutupinya.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Untuk contoh ini, kueri presentasi dan slide masing‑masing melaporkan tiga kontainer klik, dua kontainer mouse‑over, dan tiga kontainer dengan salah satu aksi. Kueri bingkai teks melaporkan satu kontainer di setiap kategori.

### **Klasifikasikan Aksi dan Tujuan**

Gunakan [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) untuk menafsirkan sebuah aksi sebelum menafsirkan tujuannya. Nilai [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) mencakup lebih dari navigasi web:

| Nilai | Makna untuk audit |
| --- | --- |
| `Hyperlink` | Hyperlink eksternal; periksa URL dan skemanya. |
| `JumpSpecificSlide` | Navigasi internal ke slide tertentu. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigasi slideshow bawaan, diselesaikan dalam konteks slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Mengakhiri pertunjukan saat ini atau memulai pertunjukan khusus. |
| `StartMacro` | Menjalankan macro. |
| `StartProgram` | Meluncurkan program. |
| `OpenFile`, `OpenPresentation` | Membuka file atau presentasi lain; tinjau terpisah dari URL web. |
| `StartStopMedia` | Memulai atau menghentikan pemutaran media. |
| `NoAction`, `Unknown` | Tidak ada aksi navigasi, atau aksi tidak dikenali yang memerlukan peninjauan. |

Baca tujuan eksternal dari [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) dan tujuan internal spesifik dari [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). Aksi internal dan perintah bawaan mungkin tidak memiliki URL eksternal; URL kosong tidak berarti kontainer tidak memiliki aksi. Pertahankan [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) bila berbeda dari URL yang dinormalisasi, dan sertakan tooltip yang dikembalikan oleh [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) bila tersedia.

### **Laporan, Sanitasi, dan Verifikasi Hyperlink**

Contoh C++ berikut membaca presentasi yang ada (gunakan file yang dibuat di atas), menulis `hyperlink-audit.json`, menerapkan kebijakan, menyimpan `hyperlink-sanitized.pptx`, dan membukanya kembali untuk memeriksa kembali kedua tipe aktivasi. Ia mengumpulkan kontainer sebelum mengubahnya dan menggunakan identitas pointer untuk menghindari memproses kontainer yang sama dua kali. Kueri presentasi mencakup slide biasa; untuk inventaris seluruh paket, ia juga secara eksplisit mengkueri master, tata letak, catatan, serta master catatan dan handout bila ada.

Laporan mencatat indeks slide berbasis satu dan [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) bila tersedia. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) menyediakan slide pemilik untuk kontainer yang didukung. Master, tata letak, dan catatan tidak memiliki indeks slide biasa dan diidentifikasi oleh lingkupnya. Kontainer bentuk dan kontainer format bagian teks diberi label terpisah; tipe kontainer lain mempertahankan nama tipe waktu jalan. Setiap kontainer mendapatkan ID laporan lokal sehingga dua aksinya dapat dihubungkan.

Kebijakan aplikasi yang sengaja restriktif ini hanya memperbolehkan URL HTTPS absolut dan target slide internal yang valid. Ia menolak macro, program, aksi file, aksi slideshow lain, aksi tidak dikenal, serta skema URL lain. Penolakan ini merupakan keputusan kebijakan, bukan penilaian keamanan Aspose.Slides. HTTPS saja tidak menjamin kepercayaan: tambahkan daftar putih host dan pemeriksaan lain untuk aplikasi Anda. Baik URL eksternal asli maupun yang dinormalisasi diperiksa. Contoh ini mengaudit metadata tanpa mengikuti tautan atau menjalankan aksi.

Untuk remediasi, [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) kontainer mendukung [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), dan [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Di sini, tautan klik eksternal yang dilarang diganti dengan halaman landas HTTPS tetap; klik yang dilarang lain serta aksi mouse‑over yang dilarang dihapus secara independen. Tetapkan `replaceExternalClicks` ke `false` untuk menghapus semua pelanggaran kebijakan. Pilih halaman pengganti milik aplikasi sebelum penerapan.

Bendera ekspor laporan menggunakan kebijakan peninjauan PDF yang konservatif: beri bendera aksi mouse‑over dan apa pun selain tautan eksternal atau lompat slide spesifik sebagai potensi tidak didukung. Itu merupakan petunjuk peninjauan, bukan tes kemampuan atau jaminan bahwa tautan yang tidak diberi bendera akan bertahan dalam ekspor. Ekspor [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/cpp/convert-powerpoint-to-html/) yang didukung dapat mempertahankan hyperlink, tergantung pada aksi, opsi ekspor, dan penampil. Gambar [raster](/slides/id/cpp/convert-powerpoint-to-png/) dan [video](/slides/id/cpp/convert-powerpoint-to-video/) tidak dapat mempertahankan hyperlink interaktif; beri bendera setiap aksi saat mengaudit output tersebut.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Dengan input yang dibuat di atas, laporan berisi lima baris aksi. Tautan mouse‑over file dan klik macro dihapus, sementara tautan HTTPS dan navigasi slide internal tetap. Verifikasi mencetak nol aksi yang dilarang. Input yang berisi URL klik eksternal yang dilarang juga menguji jalur penggantian. Kontainer dengan klik yang diizinkan dan mouse‑over yang dilarang mempertahankan aksi kliknya.

Pembersihan selektif ini berbeda dari [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), yang menghapus kedua tipe aktivasi di seluruh lingkup terpilih tanpa memperhatikan kebijakan. Verifikasi di sini hanya memeriksa aksi hyperlink; tidak menghapus proyek VBA tertanam, objek OLE, atau konten aktif lainnya, dan tidak memvalidasi file PDF atau HTML yang diekspor.

## **FAQ**

**Bagaimana saya dapat menautkan ke sebuah seksi atau slide pertamanya?**

Seksi di PowerPoint mengelompokkan slide, tetapi hyperlink internal menargetkan slide individual. Untuk membuat navigasi ke sebuah seksi, tautkan ke slide pertama dalam seksi tersebut.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan pada elemen ini tersedia selama pertunjukan slide pada slide yang menggunakan master atau tata letak yang bersangkutan.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Ekspor PDF dan HTML yang didukung mungkin mempertahankan hyperlink; gambar raster dan video tidak dapat. Lihat pertimbangan ekspor dalam [Laporan, Sanitasi, dan Verifikasi Hyperlink](#report-sanitize-and-verify-hyperlinks).