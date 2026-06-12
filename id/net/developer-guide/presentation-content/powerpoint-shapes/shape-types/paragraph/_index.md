---
title: Dapatkan Batas Paragraf dari Presentasi di .NET
linktitle: Paragraf
type: docs
weight: 60
url: /id/net/paragraph/
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di Aspose.Slides untuk .NET guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Overview**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf serta bagian teks dalam Aspose.Slides. Ini menunjukkan cara mengambil persegi panjang paragraf dalam `TextFrame` dengan menggunakan `GetRect()`, cara mendapatkan koordinat paragraf dan bagian di dalam bingkai teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks pada batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Get Paragraph and Portion Coordinates in a TextFrame**
Dengan menggunakan Aspose.Slides untuk .NET, pengembang kini dapat memperoleh koordinat persegi panjang untuk Paragraph di dalam koleksi paragraf TextFrame. Ini juga memungkinkan Anda mendapatkan koordinat bagian di dalam koleksi bagian sebuah paragraf. Pada topik ini, kami akan menunjukkan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

## **Get Rectangular Coordinates of a Paragraph**
Metode baru **GetRect()** telah ditambahkan. Metode ini memungkinkan untuk mendapatkan persegi panjang batas paragraf.

```c#
 // Membuat objek Presentation yang mewakili file presentasi
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Get the Size of a Paragraph and Portion Inside a Table Cell TextFrame**
Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion) atau [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph) dalam bingkai teks sel tabel, Anda dapat menggunakan metode [IPortion.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/methods/getrect) dan [IParagraph.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/methods/getrect).

Kode contoh ini memperlihatkan operasi yang dijelaskan:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **FAQ**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [wrapping](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/wraptext/) diaktifkan dalam [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan dengan andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel dengan menggunakan: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk proses rendering/ekspor.

**Bagaimana cara mendapatkan parameter format paragraf "effective", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/net/shape-effective-properties/); ini mengembalikan nilai akhir yang terkonkonsolidasi untuk indentasi, spasi, pembungkus, RTL, dan lainnya.