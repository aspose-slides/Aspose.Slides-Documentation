---
title: Kelola Kotak Teks dalam Presentasi Menggunakan Java
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/java/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambah teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambah kolom teks
- menambah hyperlink
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Aspose.Slides untuk Java memudahkan pembuatan, penyuntingan, dan penyalinan kotak teks di file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada di dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke sebuah slide, Anda harus menambahkan kotak teks terlebih dahulu, lalu menaruh teks di dalamnya. Aspose.Slides for Java menyediakan antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}

Aspose.Slides juga menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui antarmuka `IShape` dapat menampung teks. Sebaliknya, bentuk yang ditambahkan melalui antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dapat berisi teks. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Karena itu, ketika Anda berurusan dengan sebuah bentuk yang ingin Anda tambahkan teks, sebaiknya periksa dan pastikan bahwa bentuk tersebut telah di‑cast melalui antarmuka `IAutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/TextFrame), yang merupakan properti dari `IAutoShape`. Lihat bagian [Perbarui Teks](https://docs.aspose.com/slides/id/java/manage-textbox/#update-text) pada halaman ini. 

{{% /alert %}}

## **Membuat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation). 
2. Dapatkan referensi ke slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) dengan [ShapeType](https://reference.aspose.com/slides/id/java/com.aspose.slides/IGeometryShape#setShapeType-int-) yang disetel ke `Rectangle` pada posisi yang ditentukan di slide, dan peroleh referensi ke objek `IAutoShape` yang baru ditambahkan. 
4. Tambahkan properti `TextFrame` ke objek `IAutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks: *Aspose TextBox*
5. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode Java berikut—implementasi langkah‑langkah di atas—menunjukkan cara menambahkan teks ke sebuah slide:

```java
import com.aspose.slides.*;

// Membuat Instance Presentation
Presentation pres = new Presentation();
try {
    // Mengambil slide pertama dalam presentasi
    ISlide sld = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Menambahkan TextFrame ke Rectangle
    ashp.addTextFrame(" ");

    // Mengakses text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Membuat objek Paragraph untuk text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Membuat objek Portion untuk paragraf
    IPortion portion = para.getPortions().get_Item(0);

    // Mengatur Teks
    portion.setText("Aspose TextBox");

    // Menyimpan presentasi ke disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Memeriksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [isTextBox](https://reference.aspose.com/slides/id/java/com.aspose.slides/autoshape/#isTextBox--) dari antarmuka [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Text box and shape](istextbox.png)

Kode Java berikut menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks: 

```java
import com.aspose.slides.*;

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

Perlu dicatat bahwa jika Anda hanya menambahkan auto‑shape menggunakan metode `addAutoShape` dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/), metode `isTextBox` pada auto‑shape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke auto‑shape menggunakan metode `addTextFrame` atau metode `setText`, properti `isTextBox` akan mengembalikan `true`.

```java
import com.aspose.slides.*;

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

## **Menemukan Bentuk yang Memiliki Text Frame**

Dalam kode pemrosesan teks generik, Anda mungkin menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang memuatnya. Gunakan metode [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentShape--) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) pemiliknya.

Untuk sebuah text frame yang dimiliki oleh sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) atau bentuk lain yang berisi teks, [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentShape--) mengembalikan pemiliknya dan [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#getParentCell--) mengembalikan `null`. Kedua metode memberikan navigasi hanya‑baca, sehingga pemanggilannya tidak mengubah kepemilikan. Selalu periksa nilai kembali untuk `null` sebelum mengakses bentuk.

Untuk contoh lengkap yang mengidentifikasi pemilik bentuk dan sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/java/search-and-replace-text/).

## **Menambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) dan [ColumnSpacing](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat) dan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/TextFrameFormat)) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak antar kolom dalam poin.

Kode Java berikut mendemonstrasikan operasi tersebut: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama dalam presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Menambahkan TextFrame ke Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Mendapatkan format teks dari TextFrame
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

## **Menambahkan Kolom ke Text Frame**
Aspose.Slides for Java menyediakan properti [ColumnCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrameFormat)) yang memungkinkan Anda menambahkan kolom dalam text frame. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah text frame. 

Kode Java berikut menunjukkan cara menambahkan kolom di dalam text frame:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Memperbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks dalam sebuah presentasi. 

Kode Java berikut mendemonstrasikan operasi di mana semua teks dalam sebuah presentasi diperbarui atau diubah:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Memeriksa apakah bentuk mendukung text frame (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iterasi melalui paragraf di text frame
                {
                    for (IPortion portion : paragraph.getPortions()) //Iterasi melalui setiap portion dalam paragraf
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Mengubah teks
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Mengubah format
                    }
                }
            }
        }
    }

    //Menyimpan presentasi yang dimodifikasi
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Kotak Teks dengan Hyperlink** 

Anda dapat menyisipkan tautan di dalam sebuah kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan ke tautan tersebut. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah‑langkah berikut:

1. Buat instance kelas `Presentation`. 
2. Dapatkan referensi ke slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` yang disetel ke `Rectangle` pada posisi yang ditentukan di slide, dan peroleh referensi ke objek AutoShape yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks default. 
5. Instansiasi kelas `IHyperlinkManager`. 
6. Tetapkan objek `IHyperlinkManager` ke properti [HyperlinkClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/Shape#getHyperlinkClick--) yang terkait dengan bagian yang Anda inginkan dalam `TextFrame`. 
7. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode Java berikut—implementasi langkah‑langkah di atas—menunjukkan cara menambahkan kotak teks dengan hyperlink ke sebuah slide:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Mengambil slide pertama dalam presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Mengubah tipe shape menjadi AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Mengakses properti ITextFrame yang terkait dengan AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Menambahkan teks ke dalam frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Mengatur Hyperlink untuk teks portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Menyimpan presentasi PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan slide master?**

Sebuah [placeholder](/slides/id/java/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/java/com.aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah saat Anda beralih layout.

**Bagaimana cara melakukan penggantian teks massal di seluruh presentasi tanpa memengaruhi teks di dalam bagan, tabel, dan SmartArt?**

Batasi iterasi Anda pada auto‑shape yang memiliki text frame dan kecualikan objek tersemat ([chart](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/), [table](https://reference.aspose.com/slides/id/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewatkan tipe objek tersebut.