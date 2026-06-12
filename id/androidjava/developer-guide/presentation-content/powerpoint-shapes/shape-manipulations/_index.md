---
title: Kelola Bentuk Presentasi di Android
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/androidjava/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk Interop
- Teks alternatif bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Sejajarkan bentuk
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk dalam Aspose.Slides untuk Android via Java serta menghasilkan presentasi PowerPoint dengan kinerja tinggi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan bentuk dalam presentasi menggunakan Aspose.Slides. Ini menunjukkan cara menemukan sebuah bentuk pada slide, menggandakannya, menghapusnya, menyembunyikannya, mengubah urutannya, mendapatkan ID bentuk Interop, dan menetapkan teks alternatif untuk identifikasi dan pemrosesan lebih lanjut.

Artikel ini juga mencakup cara mengakses format tata letak untuk bentuk, merender sebuah bentuk sebagai SVG, menyelaraskan bentuk pada slide, dan menggunakan properti flip untuk pencerminan horizontal dan vertikal. Selain itu, artikel ini menyertakan FAQ singkat tentang kombinasi bentuk, urutan tumpukan, dan penguncian bentuk.

## **Temukan Bentuk pada Slide**
Topik ini akan menjelaskan teknik sederhana untuk memudahkan pengembang menemukan bentuk tertentu pada slide tanpa menggunakan Id internalnya. Penting untuk diketahui bahwa file Presentasi PowerPoint tidak memiliki cara lain untuk mengidentifikasi bentuk pada slide selain Id unik internal. Hal ini sering menyulitkan pengembang untuk menemukan bentuk menggunakan Id unik internalnya. Semua bentuk yang ditambahkan ke slide memiliki beberapa Teks Alt. Kami menyarankan pengembang menggunakan teks alternatif untuk menemukan bentuk tertentu. Anda dapat menggunakan MS PowerPoint untuk mendefinisikan teks alternatif untuk objek yang akan Anda ubah di masa depan.

Setelah menetapkan teks alternatif untuk bentuk yang diinginkan, Anda dapat membuka presentasi tersebut menggunakan Aspose.Slides for Android via Java dan mengiterasi semua bentuk yang ditambahkan ke sebuah slide. Pada setiap iterasi, Anda dapat memeriksa teks alternatif bentuk tersebut dan bentuk dengan teks alternatif yang cocok akan menjadi bentuk yang Anda butuhkan. Untuk mendemonstrasikan teknik ini dengan lebih baik, kami telah membuat metode, [findShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) yang melakukan pencarian bentuk spesifik di sebuah slide dan kemudian mengembalikan bentuk tersebut.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Teks alternatif dari bentuk yang akan dicari
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementasi metode untuk menemukan bentuk dalam slide menggunakan teks alternatifnya
public static IShape findShape(ISlide slide, String alttext)
{
    // Mengiterasi semua bentuk di dalam slide
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Jika teks alternatif slide cocok dengan yang diperlukan maka
        // Kembalikan bentuk tersebut
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Gandakan Bentuk**
Untuk menggandakan sebuah bentuk ke slide menggunakan Aspose.Slides for Android via Java:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses koleksi bentuk slide sumber.
1. Tambahkan slide baru ke presentasi.
1. Gandakan bentuk dari koleksi bentuk slide sumber ke slide baru.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan bentuk grup ke sebuah slide.

```java
// Instansiasi kelas Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Simpan file PPTX ke disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Bentuk**
Aspose.Slides for Android via Java memungkinkan pengembang menghapus bentuk apa pun. Untuk menghapus bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Hapus bentuk tersebut.
1. Simpan file ke disk.

```java
// Buat objek Presentation
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan autoshape tipe persegi panjang
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Simpan presentasi ke disk
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sembunyikan Bentuk**
Aspose.Slides for Android via Java memungkinkan pengembang menyembunyikan bentuk apa pun. Untuk menyembunyikan bentuk dari slide mana pun, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Temukan bentuk dengan AlternativeText tertentu.
1. Sembunyikan bentuk tersebut.
1. Simpan file ke disk.

```java
// Instansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan autoshape tipe persegi panjang
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Simpan presentasi ke disk
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Urutan Bentuk**
Aspose.Slides for Android via Java memungkinkan pengembang mengubah urutan bentuk. Mengubah urutan bentuk menentukan bentuk mana yang berada di depan atau di belakang. Untuk mengubah urutan bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan sebuah bentuk.
1. Tambahkan teks ke dalam bingkai teks bentuk.
1. Tambahkan bentuk lain dengan koordinat yang sama.
1. Ubah urutan bentuk-bentuk tersebut.
1. Simpan file ke disk.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan ID Bentuk Interop**
Aspose.Slides for Android via Java memungkinkan pengembang mendapatkan pengidentifikasi bentuk unik dalam ruang lingkup slide yang berbeda dari metode [getUniqueId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getUniqueId--) yang memberikan pengidentifikasi unik dalam ruang lingkup presentasi. Metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) telah ditambahkan ke antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape) dan kelas [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Shape). Nilai yang dikembalikan oleh metode [getOfficeInteropShapeId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) sesuai dengan nilai Id dari objek Microsoft.Office.Interop.PowerPoint.Shape. Berikut contoh kode yang diberikan.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Mendapatkan pengidentifikasi bentuk unik dalam ruang lingkup slide
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Tetapkan Teks Alternatif untuk Bentuk**
Aspose.Slides for Android via Java memungkinkan pengembang menetapkan AlternateText pada bentuk apa pun. Bentuk dalam presentasi dapat dibedakan menggunakan metode [AlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) atau [Shape Name](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Metode [setAlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) dan [getAlternativeText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getAlternativeText--) dapat dibaca atau diatur menggunakan Aspose.Slides maupun Microsoft PowerPoint. Dengan menggunakan metode ini, Anda dapat menandai sebuah bentuk dan melakukan operasi berbeda seperti Menghapus bentuk, Menyembunyikan bentuk, atau Mengubah urutan bentuk pada slide. Untuk menetapkan AlternateText sebuah bentuk, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan bentuk apa pun ke slide.
1. Lakukan beberapa pekerjaan dengan bentuk yang baru ditambahkan.
1. Telusuri bentuk-bentuk untuk menemukan bentuk yang diinginkan.
1. Tetapkan AlternativeText.
1. Simpan file ke disk.

```java
// Instansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan autoshape tipe persegi panjang
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Simpan presentasi ke disk
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Akses Format Tata Letak untuk Bentuk**
Aspose.Slides for Android via Java menyediakan API sederhana untuk mengakses format tata letak untuk sebuah bentuk. Artikel ini menunjukkan cara mengakses format tata letak.

Contoh kode di bawah ini diberikan.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Render Bentuk sebagai SVG**
Sekarang Aspose.Slides for Android via Java mendukung perenderan sebuah bentuk sebagai SVG. Metode [writeAsSvg](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (beserta overload-nya) telah ditambahkan ke kelas [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Shape) dan antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape). Metode ini memungkinkan menyimpan konten bentuk sebagai file SVG. Potongan kode di bawah ini menunjukkan cara mengekspor bentuk slide ke file SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sejajarkan Bentuk**
Aspose.Slides memungkinkan menyelaraskan bentuk baik relatif terhadap margin slide maupun relatif terhadap satu sama lain. Untuk tujuan ini, metode overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) telah ditambahkan. Enumerasi [ShapesAlignmentType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapesAlignmentType) mendefinisikan opsi penyelarasan yang mungkin.

**Contoh 1**

Kode sumber di bawah ini menyelaraskan bentuk dengan indeks 1,2, dan 4 sepanjang tepi atas slide.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Contoh 2**

Contoh di bawah ini menunjukkan cara menyelaraskan seluruh koleksi bentuk relatif terhadap bentuk paling bawah dalam koleksi.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Properti Flip**

Di Aspose.Slides, kelas [ShapeFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapeframe/) memberikan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `flipH` dan `flipV`. Kedua properti bertipe `byte`, memungkinkan nilai `1` untuk melakukan flip, `0` untuk tidak flip, atau `-1` untuk menggunakan perilaku default. Nilai-nilai ini dapat diakses dari [Frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getFrame--) bentuk.

Untuk mengubah pengaturan flip, sebuah instance baru [ShapeFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapeframe/) dibuat dengan posisi dan ukuran saat ini dari bentuk, nilai yang diinginkan untuk `flipH` dan `flipV`, serta sudut rotasi. Menetapkan instance ini ke [Frame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getFrame--) bentuk dan menyimpan presentasi akan menerapkan transformasi cermin dan menyimpannya ke file output.

Misalkan kami memiliki file sample.pptx di mana slide pertama berisi satu bentuk dengan pengaturan flip default, seperti ditunjukkan di bawah.

![Bentuk yang akan diputar](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip saat ini dan memflipnya baik secara horizontal maupun vertikal.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Ambil properti flip horizontal dari bentuk.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Ambil properti flip vertikal dari bentuk.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk yang diputar](flipped_shape.png)

## **FAQ**

**Bisakah saya menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat memperkirakannya dengan membangun outline yang diinginkan sendiri—misalnya, menghitung geometri hasil (melalui [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/geometrypath/)) dan membuat bentuk baru dengan kontur tersebut, dengan opsional menghapus bentuk asli.

**Bagaimana saya dapat mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada di "atas"?**

Ubah urutan sisip/move dalam koleksi [shapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseslide/#getShapes--) slide. Untuk hasil yang dapat diprediksi, finalisasi z-order setelah semua modifikasi slide selesai.

**Bisakah saya "mengunci" sebuah bentuk untuk mencegah pengguna mengeditnya di PowerPoint?**

Ya. Tetapkan flag perlindungan tingkat bentuk (misalnya, kunci pemilihan, pergerakan, pengubahan ukuran, pengeditan teks). Jika diperlukan, terapkan pembatasan pada master atau layout. Perlu diingat ini adalah perlindungan level UI, bukan fitur keamanan; untuk perlindungan yang lebih kuat, gabungkan dengan pembatasan tingkat file seperti rekomendasi baca‑saja atau kata sandi.