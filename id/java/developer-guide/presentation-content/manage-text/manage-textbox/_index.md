---
title: Mengelola Kotak Teks dalam Presentasi Menggunakan Java
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java memudahkan pembuatan, penyuntingan, dan penggandaan kotak teks di file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada di dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks dan kemudian menempatkan beberapa teks di dalam kotak teks tersebut. Aspose.Slides for Java menyediakan antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}
Aspose.Slides juga menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui antarmuka `IShape` dapat menampung teks. Tetapi bentuk yang ditambahkan melalui antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dapat berisi teks.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Oleh karena itu, ketika menangani sebuah bentuk yang ingin Anda tambahkan teks, Anda mungkin ingin memeriksa dan memastikan bahwa bentuk tersebut telah di-cast melalui antarmuka `IAutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/TextFrame), yang merupakan properti di bawah `IAutoShape`. Lihat bagian [Update Text](https://docs.aspose.com/slides/id/java/manage-textbox/#update-text) pada halaman ini. 
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation). 
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dengan [ShapeType](https://reference.aspose.com/slides/id/java/com.aspose.slides/IGeometryShape#setShapeType-int-) yang disetel ke `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi untuk objek `IAutoShape` yang baru ditambahkan. 
4. Tambahkan properti `TextFrame` ke objek `IAutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks berikut: *Aspose TextBox*
5. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode Java ini—implementasi dari langkah-langkah di atas—menunjukkan cara menambahkan teks ke slide:

```java
// Membuat Instance Presentation
Presentation pres = new Presentation();
try {
    // Mengambil slide pertama dalam presentasi
    ISlide sld = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Menambahkan TextFrame ke Rectangle
    ashp.addTextFrame(" ");

    // Mengakses bingkai teks
    ITextFrame txtFrame = ashp.getTextFrame();

    // Membuat objek Paragraph untuk bingkai teks
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Membuat objek Portion untuk paragraf
    IPortion portion = para.getPortions().get_Item(0);

    // Menetapkan Teks
    portion.setText("Aspose TextBox");

    // Menyimpan presentasi ke disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [isTextBox](https://reference.aspose.com/slides/id/java/com.aspose.slides/autoshape/#isTextBox--) dari antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Text box and shape](istextbox.png)

Kode Java ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Perhatikan bahwa jika Anda hanya menambahkan sebuah autoshape menggunakan metode `addAutoShape` dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/), metode `isTextBox` pada autoshape tersebut akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `addTextFrame` atau metode `setText`, properti `isTextBox` akan mengembalikan `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() mengembalikan false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() mengembalikan true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() mengembalikan false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() mengembalikan true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() mengembalikan false
shape3.addTextFrame("");
// shape3.isTextBox() mengembalikan false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() mengembalikan false
shape4.getTextFrame().setText("");
// shape4.isTextBox() mengembalikan false
```

## **Tambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) dan [ColumnSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat) dan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/TextFrameFormat)) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak antar kolom dalam poin.

Kode Java ini menunjukkan operasi yang dijelaskan: 

```java
Presentation pres = new Presentation();
try {
    // Mengambil slide pertama dalam presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Menambahkan TextFrame ke Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Mengambil format teks dari TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Menentukan jumlah kolom dalam TextFrame
    format.setColumnCount(3);

    // Menentukan jarak antar kolom
    format.setColumnSpacing(10);

    // Menyimpan presentasi
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Kolom ke Bingkai Teks**
Aspose.Slides for Java menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat)) yang memungkinkan Anda menambahkan kolom dalam bingkai teks. Dengan properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah bingkai teks. 

Kode Java ini menunjukkan cara menambahkan kolom di dalam bingkai teks:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks yang terdapat dalam sebuah presentasi. 

Kode Java ini menunjukkan operasi dimana semua teks dalam sebuah presentasi diperbarui atau diubah:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Memeriksa apakah bentuk mendukung bingkai teks (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Melakukan iterasi pada paragraf dalam bingkai teks
                {
                    for (IPortion portion : paragraph.getPortions()) //Melakukan iterasi pada setiap bagian dalam paragraf
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Mengubah teks
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Mengubah format
                    }
                }
            }
        }
    }

    //Menyimpan presentasi yang telah dimodifikasi
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Kotak Teks dengan Tautan** 

Anda dapat menyisipkan tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna diarahkan untuk membuka tautan tersebut. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas `Presentation`. 
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` disetel ke `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi untuk objek AutoShape yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks defaultnya. 
5. Instansiasi kelas `IHyperlinkManager`. 
6. Tetapkan objek `IHyperlinkManager` ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/Shape#getHyperlinkClick--) yang terkait dengan bagian yang Anda pilih pada `TextFrame`. 
7. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode Java ini—implementasi dari langkah-langkah di atas—menunjukkan cara menambahkan kotak teks dengan tautan ke slide:

```java
// Membuat instance kelas Presentation yang mewakili sebuah PPTX
Presentation pres = new Presentation();
try {
    // Mengambil slide pertama dalam presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Meng-cast shape menjadi AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Mengakses properti ITextFrame yang terkait dengan AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Menambahkan beberapa teks ke frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Mengatur Hyperlink untuk teks portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Menyimpan Presentasi PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan slide master?**

Sebuah [placeholder](/slides/id/java/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana saya dapat melakukan penggantian teks secara massal di seluruh presentasi tanpa menyentuh teks di dalam diagram, tabel, dan SmartArt?**

Batasi iterasi Anda hanya pada auto-shape yang memiliki bingkai teks dan kecualikan objek tersemat ([chart](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/), [table](https://reference.aspose.com/slides/id/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/smartart/)) dengan menelusuri koleksinya secara terpisah atau melewatkan tipe objek tersebut.