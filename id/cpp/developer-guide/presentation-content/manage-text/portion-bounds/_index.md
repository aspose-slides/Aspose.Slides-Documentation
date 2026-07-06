---
title: "Dapatkan Batas Bagian Teks dari Presentasi dalam C++"
linktitle: "Batas Bagian"
type: docs
weight: 47
url: /id/cpp/portion-bounds/
keywords:
- "batas bagian teks"
- "bagian teks"
- "potongan teks"
- "koordinat teks"
- "posisi teks"
- "PowerPoint"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Sebuah bagian teks mewakili fragmen teks tertentu di dalam paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Dalam Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas fragmen teks, menerapkan pemformatan hanya pada bagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [IPortion::GetRect](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/getrect/). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [IPortion::GetCoordinates](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/getcoordinates/). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui pewarisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [IPortion::GetRect](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/getrect/) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [IPortion::GetCoordinates](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/getcoordinates/) untuk mengambil koordinat awal sebuah bagian teks:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/cpp/manage-hyperlinks/) ke bagian individu; hanya fragmen tersebut yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada level bagian memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [IPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/), Aspose.Slides mengambilnya dari [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/). Jika tidak diatur di sana juga, Aspose.Slides menggunakan gaya dari [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) atau [theme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/theme/) .

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak ada di mesin atau server target?**

Aturan substitusi font [Font substitution rules](/slides/id/cpp/font-selection-sequence/) berlaku. Teks dapat mengalami reflow: metrik, hyphenasi, dan lebar dapat berubah, yang berpengaruh pada penempatan yang presisi.

**Apakah saya dapat mengatur transparansi isi teks atau gradien khusus bagian secara terpisah dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada level [IPortion](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/) dapat berbeda dari fragmen tetangganya.