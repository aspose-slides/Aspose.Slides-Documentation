---
title: Kelola Daftar Bertanda Peluru dan Bernomor dalam Presentasi di C++
linktitle: Kelola Daftar
type: docs
weight: 70
url: /id/cpp/manage-lists/
keywords:
- peluru
- daftar bertanda peluru
- daftar bernomor
- peluru simbol
- peluru gambar
- peluru khusus
- daftar berjenjang
- buat peluru
- tambahkan peluru
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar bertanda peluru, gambar, berjenjang, dan bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Aspose.Slides untuk C++ memungkinkan Anda membuat dan memformat daftar bertanda peluru dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan pelurunya dikontrol melalui format paragrafnya.

Gunakan metode [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/get_paragraphformat/) untuk mengakses pengaturan daftar pada tingkat paragraf. Titik masuk utama adalah [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/get_bullet/), yang mengembalikan objek [IBulletFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/). Dengan objek ini, Anda dapat mengatur jenis peluru, simbol, gambar, warna, ukuran, gaya penomoran, dan nomor awal.

Artikel ini menunjukkan cara:
- membuat daftar bertanda peluru dengan simbol khusus
- membuat peluru gambar
- membuat daftar berjenjang dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang ada

## **Membuat Daftar Bertanda Peluru**

Untuk membuat daftar bertanda peluru, tambahkan objek [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/) ke dalam [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dan setel [IBulletFormat::set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_type/) ke [BulletType::Symbol](https://reference.aspose.com/slides/id/cpp/aspose.slides/bullettype/). Anda kemudian dapat mengatur [IBulletFormat::set_Char](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/get_color/), dan [IBulletFormat::set_Height](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_height/) untuk mengontrol tampilan peluru.

Kode C++ berikut menunjukkan cara membuat daftar bertanda peluru dalam sebuah slide:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasil:

![Peluru simbol](symbol_bullets.png)

## **Membuat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Setel [IBulletFormat::set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_type/) ke [BulletType::Numbered](https://reference.aspose.com/slides/id/cpp/aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) atau setel [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) bila daftar harus dimulai dari nilai selain 1.

Kode C++ berikut menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasil:

![Peluru bernomor](numbered_bullets.png)

## **Membuat Peluru Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol peluru biasa dengan gambar. Peluru gambar paling cocok dengan gambar sederhana yang tetap dapat dibaca pada ukuran kecil, seperti ikon atau file PNG transparan kecil.

{{% alert color="primary" %}}
Idealnya, jika Anda berencana mengganti simbol peluru biasa dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar semacam itu bekerja baik sebagai simbol peluru khusus.
{{% /alert %}}

Untuk membuat peluru gambar, tambahkan gambar ke [IPresentation::get_Images](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/get_images/) dan tetapkan objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) yang dikembalikan ke [IBulletFormat::get_Picture](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/get_picture/). Setel [IBulletFormat::set_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibulletformat/set_type/) ke [BulletType::Picture](https://reference.aspose.com/slides/id/cpp/aspose.slides/bullettype/) sebelum menetapkan gambar.

Misalkan kita memiliki file "image.png":

![Gambar untuk peluru](picture_for_bullets.png)

Kode C++ berikut menunjukkan cara membuat peluru gambar dalam sebuah slide:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasil:

![Peluru gambar](picture_bullets.png)

## **Membuat Daftar Bertingkat**

Gunakan [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_depth/) untuk menempatkan item daftar pada level yang berbeda. Level 0 adalah level teratas, level 1 berada di bawahnya, dan seterusnya.

Kode C++ berikut menunjukkan cara membuat daftar bertanda peluru berjenjang:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasil:

![Daftar berjenjang](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang ada, akses paragraf target dan perbarui pengaturan [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/get_bullet/). Properti yang sama yang digunakan untuk membuat daftar dapat digunakan untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

Kode C++ berikut mengubah paragraf pertama dalam sebuah frame teks untuk menggunakan gaya daftar bernomor:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah daftar bertanda peluru dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur peluru yang bersesuaian.

**Apakah saya dapat mengedit daftar dalam presentasi yang ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/get_bullet/), dan simpan presentasi.

**Apakah daftar dapat berisi teks non-Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang Anda perlukan.