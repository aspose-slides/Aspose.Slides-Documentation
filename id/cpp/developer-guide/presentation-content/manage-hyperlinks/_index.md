---
title: "Kelola Hyperlink Presentasi di C++"
linktitle: "Kelola Hyperlink"
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
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Hyperlink adalah referensi ke sebuah objek atau data atau suatu tempat dalam sesuatu. Berikut ini adalah hyperlink umum dalam Presentasi PowerPoint:

* Link ke situs web di dalam teks, bentuk, atau media
* Link ke slide

Aspose.Slides untuk C++ memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi. 

{{% alert color="primary" %}} 
Anda mungkin ingin mencoba Aspose sederhana, [editor PowerPoint online gratis.](https://products.aspose.app/slides/id/editor)
{{% /alert %}} 

## **Tambah Hyperlink URL**

### **Tambah Hyperlink URL ke Teks**

Kode C++ ini menunjukkan cara menambahkan hyperlink situs web ke teks:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Tambah Hyperlink URL ke Bentuk atau Bingkai**

Contoh kode C++ ini menunjukkan cara menambahkan hyperlink situs web ke sebuah bentuk:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Tambah Hyperlink URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video. 

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **gambar**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Menambahkan gambar ke presentasi
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **file audio**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **video**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 
Anda mungkin ingin melihat *[Kelola OLE](https://docs.aspose.com/slides/id/cpp/manage-ole/)*.
{{% /alert %}}



## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi. 

Contoh kode ini menunjukkan cara membuat daftar isi dengan hyperlink:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **Format Hyperlink**

### **Warna**

Dengan metode [set_ColorSource()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) dan [get_ColorSource()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) dalam antarmuka [IHyperlink](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink), Anda dapat mengatur warna untuk hyperlink dan juga mendapatkan informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan yang melibatkan properti ini tidak berlaku untuk versi PowerPoint yang lebih lama.

Contoh kode ini mendemonstrasikan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **Hapus Hyperlink dari Presentasi**

### **Hapus Hyperlink dari Teks**

Kode C++ ini menunjukkan cara menghapus hyperlink dari teks dalam slide presentasi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Hapus Hyperlink dari Bentuk atau Bingkai**

Kode C++ ini menunjukkan cara menghapus hyperlink dari sebuah bentuk dalam slide presentasi: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Hyperlink Mutable**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.hyperlink) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai untuk metode-metode berikut:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke slide dan mengedit tooltip-nya kemudian:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```




## **Metode yang Didukung dalam IHyperlinkQueries**

Anda dapat mengakses IHyperlinkQueries dari sebuah presentasi, slide, atau teks yang memiliki hyperlink yang didefinisikan. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Kelas IHyperlinkQueries mendukung metode-metode berikut: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal tidak hanya ke sebuah slide, tetapi ke "bagian" atau slide pertama dari sebuah bagian?**

Bagian dalam PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk "menavigasi ke sebuah bagian", biasanya Anda menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan tersebut muncul pada slide turunan dan dapat diklik selama presentasi.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Di [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/cpp/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [gambar](/slides/id/cpp/convert-powerpoint-to-png/) dan [video](/slides/id/cpp/convert-powerpoint-to-video/), kemampuan mengklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).