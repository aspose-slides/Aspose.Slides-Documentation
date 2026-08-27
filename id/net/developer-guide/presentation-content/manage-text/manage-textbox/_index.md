---
title: "Mengelola Kotak Teks dalam Presentasi di .NET"
linktitle: "Kelola Kotak Teks"
type: docs
weight: 20
url: /id/net/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambahkan teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambahkan kolom teks
- menambahkan tautan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides untuk .NET memudahkan pembuatan, penyuntingan, dan kloning kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks terlebih dahulu dan kemudian menaruh teks di dalam kotak teks tersebut. 

Untuk memungkinkan Anda menambahkan bentuk yang dapat menampung teks, Aspose.Slides untuk .NET menyediakan antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides juga menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape) untuk memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui antarmuka `IShape` dapat menampung teks. Bentuk yang ditambahkan melalui antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape) biasanya berisi teks. 

Oleh karena itu, ketika menangani bentuk yang sudah ada dan ingin Anda tambahkan teks, Anda mungkin perlu memeriksa dan memastikan bahwa bentuk tersebut telah di‑cast melalui antarmuka `IAutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/properties/textframe), yang merupakan properti di bawah `IAutoShape`. Lihat bagian [Perbarui Teks](https://docs.aspose.com/slides/id/net/manage-textbox/#update-text) pada halaman ini. 

{{% /alert %}}

## **Buat Kotak Teks pada Slide**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide pertama melalui indeksnya. 
3. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape) dengan [ShapeType](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/properties/shapetype) yang diset sebagai `Rectangle` pada posisi tertentu di slide dan peroleh referensi untuk objek `IAutoShape` yang baru ditambahkan. 
4. Tambahkan properti `TextFrame` ke objek `IAutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks berikut: *Aspose TextBox*
5. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode C# ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan teks ke slide:

```c#
using Aspose.Slides;

// Membuat instance PresentationEx
using (Presentation pres = new Presentation())
{

    // Mendapatkan slide pertama dalam presentasi
    ISlide sld = pres.Slides[0];

    // Menambahkan AutoShape dengan tipe yang diatur sebagai Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Menambahkan TextFrame ke Rectangle
    ashp.AddTextFrame(" ");

    // Mengakses bingkai teks
    ITextFrame txtFrame = ashp.TextFrame;

    // Membuat objek Paragraph untuk bingkai teks
    IParagraph para = txtFrame.Paragraphs[0];

    // Membuat objek Portion untuk paragraf
    IPortion portion = para.Portions[0];

    // Mengatur teks
    portion.Text = "Aspose TextBox";

    // Menyimpan presentasi ke disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan properti [IsTextBox](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/istextbox/) dari antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Kotak teks dan bentuk](istextbox.png)

Kode C# ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Perhatikan bahwa jika Anda hanya menambahkan autoshape menggunakan metode `AddAutoShape` dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/), properti `IsTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `AddTextFrame` atau properti `Text`, properti `IsTextBox` akan mengembalikan `true`.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox adalah false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox adalah true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox adalah false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox adalah true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox adalah false
    shape3.AddTextFrame("");
    // shape3.IsTextBox adalah false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox adalah false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox adalah false
}
```

## **Temukan Bentuk yang Memiliki Bingkai Teks**

Dalam kode pemrosesan teks umum, Anda mungkin menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang menampungnya. Gunakan properti [ITextFrame.ParentShape](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentshape/) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) pemiliknya.

Untuk bingkai teks yang merupakan milik sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) atau bentuk lain yang berisi teks, [ITextFrame.ParentShape](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentshape/) diatur dan [ITextFrame.ParentCell](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentcell/) bernilai `null`. Kedua properti bersifat read‑only sebagai properti navigasi, sehingga membaca mereka tidak mengubah kepemilikan. Selalu periksa nilai yang dikembalikan untuk `null` sebelum mengakses bentuknya.

Untuk contoh lengkap yang mengidentifikasi pemilik bentuk dan sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/net/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/columncount) dan [ColumnSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/properties/columnspacing) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat) dan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat)) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan kemudian menentukan jarak dalam poin antara kolom. 

Kode C# berikut mendemonstrasikan operasi yang dijelaskan: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Mendapatkan slide pertama dalam presentasi
	ISlide slide = presentation.Slides[0];

	// Menambahkan AutoShape dengan tipe yang diatur sebagai Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Menambahkan TextFrame ke Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Mendapatkan format teks dari TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Menentukan jumlah kolom dalam TextFrame
	format.ColumnCount = 3;

	// Menentukan jarak antar kolom
	format.ColumnSpacing = 10;

	// Menyimpan presentasi
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Tambahkan Kolom ke Bingkai Teks**
Aspose.Slides untuk .NET menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/columncount) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat)) yang memungkinkan Anda menambahkan kolom dalam bingkai teks. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam bingkai teks. 

Kode C# ini menunjukkan cara menambahkan kolom di dalam bingkai teks:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Perbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks yang terdapat dalam sebuah presentasi. 

Kode C# ini mendemonstrasikan operasi di mana semua teks dalam sebuah presentasi diperbarui atau diubah:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Memeriksa apakah shape mendukung bingkai teks (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iterasi melalui paragraf dalam bingkai teks
               {
                   foreach (IPortion portion in paragraph.Portions) //Iterasi melalui setiap portion dalam paragraf
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Mengubah teks
                       portion.PortionFormat.FontBold = NullableBool.True; //Mengubah pemformatan
                   }
               }
           }
       }
   }
  
   //Menyimpan presentasi yang telah dimodifikasi
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Tambahkan Kotak Teks dengan Tautan** 

Anda dapat menyisipkan sebuah tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan untuk membuka tautan tersebut. 

1. Buat sebuah instance dari kelas `Presentation`. 
2. Dapatkan referensi slide pertama melalui indeksnya.  
3. Tambahkan objek `AutoShape` dengan `ShapeType` yang diset sebagai `Rectangle` pada posisi tertentu di slide dan peroleh referensi objek `AutoShape` yang baru ditambahkan. 
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks default. 
5. Instansiasikan kelas `IHyperlinkManager`. 
6. Tetapkan objek `IHyperlinkManager` ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/shape/properties/hyperlinkclick) yang terkait dengan bagian `TextFrame` yang Anda inginkan. 
7. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode C# ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan kotak teks dengan tautan ke slide:

```c#
using Aspose.Slides;

// Membuat instance kelas Presentation yang mewakili PPTX
Presentation pptxPresentation = new Presentation();

// Mendapatkan slide pertama dalam presentasi
ISlide slide = pptxPresentation.Slides[0];

// Menambahkan objek AutoShape dengan tipe yang diatur sebagai Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Mencasting shape menjadi AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Mengakses properti ITextFrame yang terkait dengan AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Menambahkan teks ke bingkai
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Mengatur Hyperlink untuk teks portion
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Menyimpan presentasi PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/net/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/net/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks secara massal di seluruh presentasi tanpa menyentuh teks di dalam diagram, tabel, dan SmartArt?**

Batasi iterasi Anda pada auto‑shape yang memiliki bingkai teks dan kecualikan objek tersemat ([diagram](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/), [tabel](https://reference.aspose.com/slides/id/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewatkan tipe objek tersebut.