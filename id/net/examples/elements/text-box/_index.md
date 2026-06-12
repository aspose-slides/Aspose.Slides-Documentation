---
title: Kotak Teks
type: docs
weight: 40
url: /id/net/examples/elements/text-box/
keywords:
- kotak teks
- menambah kotak teks
- akses kotak teks
- hapus kotak teks
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan kotak teks di Aspose.Slides untuk .NET: menambah, memformat, menyelaraskan, membungkus, menyesuaikan otomatis, dan memberikan gaya pada teks menggunakan C# untuk presentasi PPT, PPTX, dan ODP."
---
Di Aspose.Slides, sebuah **text box** direpresentasikan oleh `AutoShape`. Hampir semua shape dapat berisi teks, tetapi text box tipikal tidak memiliki isian atau border dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambah, mengakses, dan menghapus text box secara programatis.

## **Tambahkan Text Box**

Text box hanyalah `AutoShape` tanpa isian atau border dan dengan beberapa teks yang diformat. Berikut cara membuatnya:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Buat shape persegi panjang (secara default terisi dengan border dan tanpa teks).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Hapus isian dan border agar terlihat seperti kotak teks tipikal.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Atur pemformatan teks.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Tetapkan konten teks yang sebenarnya.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` tidak kosong dapat berfungsi sebagai text box.

## **Akses Text Box berdasarkan Konten**

Untuk menemukan semua text box yang berisi kata kunci tertentu (mis. "Slide"), iterasi melalui shape dan periksa teksnya:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Hanya AutoShape yang dapat berisi teks yang dapat diedit.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Lakukan sesuatu dengan kotak teks yang cocok.
            }
        }
    }
}
```

## **Hapus Text Box berdasarkan Konten**

Contoh ini menemukan dan menghapus semua text box pada slide pertama yang berisi kata kunci tertentu:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Tip:** Selalu buat salinan koleksi shape sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.