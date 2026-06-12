---
title: Dapatkan Batas Paragraf dari Presentasi di C++
linktitle: Paragraf
type: docs
weight: 60
url: /id/cpp/paragraph/
keywords:
- batas paragraf
- batas bagian teks
- koordinat paragraf
- koordinat bagian
- ukuran paragraf
- ukuran bagian teks
- bingkai teks
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di Aspose.Slides untuk C++ guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara memperoleh batas, ukuran, dan koordinat paragraf serta bagian teks di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dalam `TextFrame` menggunakan `GetRect()`, cara mendapatkan koordinat paragraf dan bagian di dalam teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks terhadap batas, konversi piksel, dan nilai pemformatan paragraf yang efektif.

## **Dapatkan Koordinat Paragraf dan Bagian dalam TextFrame**
Dengan Aspose.Slides untuk C++, pengembang kini dapat memperoleh koordinat persegi panjang untuk Paragraf di dalam koleksi paragraf TextFrame. Ini juga memungkinkan Anda mendapatkan koordinat bagian di dalam koleksi bagian sebuah paragraf. Pada topik ini, kami akan mendemonstrasikan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

## **Dapatkan Koordinat Persegi Panjang Sebuah Paragraf**
Metode baru **GetRect()** telah ditambahkan. Metode ini memungkinkan untuk memperoleh persegi panjang batas paragraf.

``` cpp
// Buat objek Presentation yang mewakili file presentasi
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Dapatkan Ukuran Paragraf dan Bagian di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.portion) atau [Paragraph](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.paragraph) dalam teks sel tabel, Anda dapat menggunakan metode [IPortion::GetRect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) dan [IParagraph::GetRect](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Kode contoh berikut mendemonstrasikan operasi yang dijelaskan:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [wrapping](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_wraptext/) diaktifkan pada [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel pada gambar yang diekspor?**

Ya. Konversi poin ke piksel menggunakan: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk proses rendering/ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan memperhitungkan pewarisan gaya?**

Gunakan [struktur data pemformatan paragraf efektif](/slides/id/cpp/shape-effective-properties/); struktur ini mengembalikan nilai akhir yang telah dikonsolidasikan untuk inden, spasi, pembungkus, RTL, dan lainnya.