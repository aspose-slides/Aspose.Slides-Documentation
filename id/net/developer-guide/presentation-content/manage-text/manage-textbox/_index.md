---
title: Mengelola Kotak Teks dalam Presentasi di .NET
linktitle: Kelola Kotak Teks
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
- menambahkan hyperlink
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides untuk .NET memudahkan pembuatan, penyuntingan, dan penggandaan kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks terlebih dahulu lalu menaruh teks di dalam kotak teks. 

Untuk memungkinkan Anda menambahkan bentuk yang dapat menampung teks, Aspose.Slides untuk .NET menyediakan antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides juga menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape) untuk memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui antarmuka `IShape` dapat menampung teks. Bentuk yang ditambahkan melalui antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape) biasanya berisi teks. 

Oleh karena itu, ketika menangani bentuk yang sudah ada dan ingin Anda tambahkan teks, Anda mungkin ingin memeriksa dan memastikan bahwa bentuk tersebut telah di‑cast melalui antarmuka `IAutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/properties/textframe), yang merupakan properti di bawah `IAutoShape`. Lihat bagian [Update Text](https://docs.aspose.com/slides/id/net/manage-textbox/#update-text) pada halaman ini. 

{{% /alert %}}

## **Buat Kotak Teks pada Slide**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation). 
2. Dapatkan referensi slide pertama melalui indeksnya. 
3. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape) dengan [ShapeType](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/properties/shapetype) diatur ke `Rectangle` pada posisi tertentu di slide dan dapatkan referensi untuk objek `IAutoShape` yang baru ditambahkan. 
4. Tambahkan properti `TextFrame` ke objek `IAutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks ini: *Aspose TextBox*
5. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode C# ini—implementasi langkah-langkah di atas—menunjukkan cara menambahkan teks ke slide:

```c#
// Membuat instance Presentation
using (Presentation pres = new Presentation())
{

    // Mendapatkan slide pertama dalam presentasi
    ISlide sld = pres.Slides[0];

    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Menambahkan TextFrame ke Rectangle
    ashp.AddTextFrame(" ");

    // Mengakses text frame
    ITextFrame txtFrame = ashp.TextFrame;

    // Membuat objek Paragraph untuk text frame
    IParagraph para = txtFrame.Paragraphs[0];

    // Membuat objek Portion untuk paragraf
    IPortion portion = para.Portions[0];

    // Menetapkan teks
    portion.Text = "Aspose TextBox";

    // Menyimpan presentasi ke disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan properti [IsTextBox](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/istextbox/) dari antarmuka [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) , yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Kotak teks dan bentuk](istextbox.png)

Kode C# ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks: 

```c#
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

Catatan bahwa jika Anda hanya menambahkan autoshape menggunakan metode `AddAutoShape` dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/), properti `IsTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `AddTextFrame` atau properti `Text`, properti `IsTextBox` akan mengembalikan `true`.

```cs
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

## **Tambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/columncount) dan [ColumnSpacing](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/properties/columnspacing) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat) dan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat)) untuk memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan kemudian menentukan jarak antar kolom dalam poin. 

Kode ini dalam C# mendemonstrasikan operasi yang dijelaskan: 

```c#
using (Presentation presentation = new Presentation())
{
	// Mendapatkan slide pertama dalam presentasi
	ISlide slide = presentation.Slides[0];

	// Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
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

Aspose.Slides untuk .NET menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/columncount) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat)) yang memungkinkan Anda menambahkan kolom dalam bingkai teks. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah bingkai teks. 

Kode C# ini menunjukkan cara menambahkan kolom di dalam bingkai teks:

```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks yang terdapat dalam presentasi. 

Kode C# ini mendemonstrasikan operasi di mana semua teks dalam presentasi diperbarui atau diubah:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Memeriksa apakah shape mendukung text frame (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iterasi melalui paragraf dalam text frame
               {
                   foreach (IPortion portion in paragraph.Portions) //Iterasi melalui setiap portion dalam paragraf
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Mengubah teks
                       portion.PortionFormat.FontBold = NullableBool.True; //Mengubah format
                   }
               }
           }
       }
   }
  
   //Menyimpan presentasi yang telah dimodifikasi
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Tambahkan Kotak Teks dengan Hyperlink** 

Anda dapat menyisipkan tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan untuk membuka tautan tersebut. 

1. Buat instance dari kelas `Presentation`. 
2. Dapatkan referensi slide pertama melalui indeksnya.  
3. Tambahkan objek `AutoShape` dengan `ShapeType` diatur ke `Rectangle` pada posisi tertentu di slide dan dapatkan referensi objek `AutoShape` yang baru ditambahkan. 
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks defaultnya. 
5. Buat instance kelas `IHyperlinkManager`. 
6. Tetapkan objek `IHyperlinkManager` ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/net/aspose.slides/shape/properties/hyperlinkclick) yang terkait dengan bagian `TextFrame` yang Anda inginkan. 
7. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode C# ini—implementasi langkah-langkah di atas—menunjukkan cara menambahkan kotak teks dengan hyperlink ke slide:

```c#
// Membuat instance kelas Presentation yang mewakili sebuah PPTX
// Mendapatkan slide pertama dalam presentasi
// Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
// Meng-cast shape menjadi AutoShape
// Mengakses properti ITextFrame yang terkait dengan AutoShape
// Menambahkan beberapa teks ke frame
// Menetapkan Hyperlink untuk teks portion
// Menyimpan Presentasi PPTX
Presentation pptxPresentation = new Presentation();

// Gets the first slide in the presentation
ISlide slide = pptxPresentation.Slides[0];

// Adds an AutoShape object with type set as Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Casts the shape to AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Accesses the ITextFrame property associated with the AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Adds some text to the frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Sets the Hyperlink for the portion text
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Saves the PPTX Presentation
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/net/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/net/aspose.slides/masterslide/) dan dapat diganti pada [layouts](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks secara massal di seluruh presentasi tanpa memengaruhi teks di dalam chart, tabel, dan SmartArt?**

Batasi iterasi Anda hanya pada auto‑shapes yang memiliki text frame dan kecualikan objek tersemat ([charts](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/id/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewati tipe objek tersebut.