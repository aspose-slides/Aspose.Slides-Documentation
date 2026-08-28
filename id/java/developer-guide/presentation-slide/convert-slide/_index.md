---
title: Mengonversi Slide Presentasi menjadi Gambar dalam Java
linktitle: Slide ke Gambar
type: docs
weight: 35
url: /id/java/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Mengonversi slide dari presentasi PPT, PPTX, dan ODP menjadi PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya dalam Java dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for Java dapat merender slide individu dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/).
4. Panggil metode [ISlide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getImage--). Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/).
5. Panggil metode [IImage.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/#save-java.lang.String-int-) dan tentukan format output dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/).

## **Mengonversi Slide menjadi Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) yang dihasilkan dapat diproses di memori atau disimpan ke file.

Contoh Java berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Mengonversi Slide menjadi Gambar dengan Ukuran Kustom**

Gunakan overload [ISlide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) yang menerima nilai [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG berukuran 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Mengonversi Slide dengan Catatan dan Komentar menjadi Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Kirimkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/notescommentslayoutingoptions/) ke metode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) untuk mengontrol di mana catatan dan komentar muncul.

Contoh berikut menempatkan catatan yang dipotong di bawah slide dan komentar di sebelah kanannya:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide ke gambar, jangan kirimkan [BottomFull](https://reference.aspose.com/slides/id/java/com.aspose.slides/notespositions/) ke metode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/id/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Catatan dapat berisi teks lebih banyak daripada ukuran gambar tetap yang dapat menampungnya. Gunakan [BottomTruncated](https://reference.aspose.com/slides/id/java/com.aspose.slides/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Mengonversi Slide menjadi Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lain dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF berukuran 2160 × 2880 pada 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Dukungan TIFF tidak dijamin pada versi Java sebelum JDK 9.
{{% /alert %}}

## **Mengonversi Semua Slide menjadi Gambar**

Iterasi melalui koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi akan disertakan kecuali Anda melewatinya secara eksplisit.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal sebesar 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Membuat Output Enhanced Metafile**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lain yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi gambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam kontainer metafile vektor.

### **Ekspor Slide ke EMF**

Metode [ISlide.writeAsEmf](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) menulis sebuah [ISlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/) ke aliran target dalam format EMF. Contoh berikut memuat sebuah presentasi, memilih slide pertama, dan menulisnya ke aliran file EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Pemanggil memiliki aliran yang diberikan ke [ISlide.writeAsEmf](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) dan bertanggung jawab untuk menutupnya, seperti ditunjukkan di atas.

### **Mengonversi Gambar SVG ke EMF dan Menambahkannya ke Presentasi**

Gunakan [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) untuk mengonversi konten SVG menjadi EMF. Byte yang dihasilkan dapat ditambahkan ke presentasi melalui [IImageCollection.addImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) dan ditempatkan pada slide dengan [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Contoh berikut membuat sebuah [SvgImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/svgimage/) dari markup SVG, mengonversinya menjadi EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/id/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) tidak mengambil kepemilikan aliran tujuan. Sebuah [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) menyimpan semua data yang dihasilkan dalam memori, sehingga tidak diperlukan reset posisi sebelum memanggil `toByteArray`. Array byte yang dikembalikan tetap valid setelah aliran ditutup.

Pembuatan EMF tersedia pada sistem operasi yang didukung oleh konfigurasi Aspose.Slides for Java dan JDK yang dipilih, namun rendering dapat berbeda antar platform ketika font atau dependensi grafis tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [persyaratan platform](/slides/id/java/system-requirements/) untuk Aspose.Slides for Java, dan validasi hasilnya di aplikasi target yang mengonsumsi EMF. Aplikasi Linux dan macOS sering memiliki dukungan yang terbatas atau tidak konsisten untuk menampilkan dan mengedit metafile Windows.

## **Rendering Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi menjadi gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar output.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak. Metode [ISlide.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#getImage--) merender gambar statis dari slide dan tidak mengekspor animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Sertakan mereka dalam loop pemrosesan, seperti yang ditunjukkan pada contoh di atas.

**Apakah bayangan dan efek lain dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.