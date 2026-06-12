---
title: Kotak Teks
type: docs
weight: 40
url: /id/cpp/examples/elements/text-box/
keywords:
- contoh kode
- kotak teks
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan kotak teks di Aspose.Slides untuk C++: menambah, memformat, meratakan, membungkus, menyesuaikan otomatis, dan memberi gaya pada teks menggunakan C++ untuk presentasi PPT, PPTX, dan ODP."
---
Di Aspose.Slides, sebuah **text box** direpresentasikan oleh `AutoShape`. Hampir semua bentuk dapat berisi teks, namun text box tipikal tidak memiliki isian atau border dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambah, mengakses, dan menghapus text box secara programatik.

## **Menambahkan Text Box**

Sebuah text box hanyalah `AutoShape` tanpa isian atau border dan dengan beberapa teks yang diformat. Berikut cara membuatnya:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Buat bentuk persegi panjang (default terisi dengan border dan tanpa teks).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Hapus isian dan border agar terlihat seperti kotak teks tipikal.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Atur pemformatan teks.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Tetapkan konten teks yang sebenarnya.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` tidak kosong dapat berfungsi sebagai text box.

## **Mengakses Text Box Berdasarkan Konten**

Untuk menemukan semua text box yang berisi kata kunci tertentu (mis. "Slide"), iterasi melalui bentuk-bentuk dan periksa teksnya:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Hanya AutoShape yang dapat berisi teks yang dapat diedit.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Lakukan sesuatu dengan kotak teks yang cocok.
            }
        }
    }

    presentation->Dispose();
}
```

## **Menghapus Text Box Berdasarkan Konten**

Contoh ini menemukan dan menghapus semua text box pada slide pertama yang berisi kata kunci tertentu:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tip:** Selalu buat salinan koleksi shape sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.