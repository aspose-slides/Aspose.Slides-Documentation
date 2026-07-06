---
title: Dapatkan Batas Paragraf dari Presentasi dalam C++
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/cpp/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- kerangka teks
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk C++ guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf dalam Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dengan menggunakan [IParagraph::GetRect](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/getrect/), cara mendapatkan koordinat paragraf di dalam kerangka teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, efek pembungkusan teks pada batas, konversi piksel, dan nilai pemformatan paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Paragraf**

Gunakan [IParagraph::GetRect](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/getrect/) untuk mendapatkan persegi panjang pembatas sebuah paragraf.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Dapatkan Ukuran Paragraf dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) di dalam kerangka teks sel tabel, gunakan [IParagraph::GetRect](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/getrect/). Persegi panjang yang dikembalikan bersifat relatif terhadap kerangka teks sel tabel, sehingga Anda harus menambahkan posisi tabel serta offset sel bila memerlukan koordinat tingkat slide.

Contoh berikut mengambil batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Mereka diukur dalam point, di mana 1 inci sama dengan 72 point. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkusan kata memengaruhi batas paragraf?**

Ya. Jika [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/set_wraptext/) diaktifkan untuk [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Dapatkah koordinat paragraf dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan point ke piksel dengan formula berikut: piksel = point × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering atau ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/cpp/shape-effective-properties/); ia mengembalikan nilai akhir yang terkonsolidasi untuk indentasi, spasi, pembungkusan, RTL, dan lainnya.