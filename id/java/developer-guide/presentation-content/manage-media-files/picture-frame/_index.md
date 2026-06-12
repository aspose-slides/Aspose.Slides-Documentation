---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan Java
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- pangkas gambar
- area terpangkas
- properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Java. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah bentuk yang berisi gambar—itu seperti foto dalam sebuah bingkai. 

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage]() dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/PictureFrame) berdasarkan lebar dan tinggi gambar melalui metode `AddPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara membuat bingkai gambar:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Membuat instance kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Menambahkan bingkai gambar dengan tinggi dan lebar gambar yang setara
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Bingkai gambar memungkinkan Anda membuat slide presentasi dengan cepat berdasarkan gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat memanipulasi operasi input/output untuk mengonversi gambar dari satu format ke format lain. Anda mungkin ingin melihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/java/conversion/image-to-jpg/); konversi [JPG ke gambar](https://products.aspose.com/slides/id/java/conversion/jpg-to-image/); konversi [JPG ke PNG](https://products.aspose.com/slides/id/java/conversion/jpg-to-png/), konversi [PNG ke JPG](https://products.aspose.com/slides/id/java/conversion/png-to-jpg/); konversi [PNG ke SVG](https://products.aspose.com/slides/id/java/conversion/png-to-svg/), konversi [SVG ke PNG](https://products.aspose.com/slides/id/java/conversion/svg-to-png/).

{{% /alert %}}

## **Buat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih kompleks. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi.
4. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar.
6. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara membuat bingkai gambar dengan skala relatif:

```java
// Membuat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Membuat instance kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Menambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Mengatur skala relatif lebar dan tinggi
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/PictureFrame) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah menunjukkan cara mengekstrak gambar dari dokumen "sample.pptx" dan menyimpannya dalam format PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) , Aspose.Slides untuk Java memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/), memeriksa apakah [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) yang mendasarinya berisi konten SVG, lalu menyimpan gambar tersebut ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut menunjukkan cara mengekstrak gambar SVG dari sebuah bingkai gambar:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada sebuah gambar. Kode Java berikut menunjukkan operasi tersebut:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan menggunakan opsi-opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan persyaratan tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPPImage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [AddPictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yang disediakan oleh objek [IShapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection) yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Atur warna garis bingkai gambar.
8. Atur lebar garis bingkai gambar.
9. Putar bingkai gambar dengan memberikan nilai positif atau negatif. 
   * Nilai positif memutar gambar searah jarum jam. 
   * Nilai negatif memutar gambar berlawanan arah jarum jam.
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
11. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan proses pemformatan bingkai gambar:

```java
// Membuat instance kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Membuat instance kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Menambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Menerapkan beberapa pemformatan pada PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose baru‑baru ini mengembangkan [Collage Maker gratis](https://products.aspose.app/slides/id/collage). Jika Anda pernah perlu [menggabungkan JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) atau gambar PNG, [membuat grid dari foto](https://products.aspose.app/slides/id/collage/photo-grid), Anda dapat menggunakan layanan ini. 

{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Tidak ingin ukuran presentasi menjadi besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih‑alih menyematkan file langsung ke dalam presentasi. Kode Java berikut menunjukkan cara menambahkan gambar dan video ke dalam placeholder:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pangkas Gambar**

Kode Java berikut menunjukkan cara memangkas gambar yang sudah ada pada slide:

```java
Presentation pres = new Presentation();
// Membuat objek gambar baru
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan PictureFrame ke Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Memangkas gambar (nilai persentase)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Menyimpan hasil
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Area Terpangkas pada Bingkai Gambar**

Jika Anda ingin menghapus area terpangkas dari gambar yang berada dalam bingkai, Anda dapat menggunakan metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Metode ini mengembalikan gambar yang telah dipangkas atau gambar asli jika pemangkasan tidak diperlukan.

Kode Java berikut menunjukkan operasi tersebut:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Mendapatkan PictureFrame dari slide pertama
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Menghapus area terpangkas dari gambar PictureFrame dan mengembalikan gambar yang terpangkas
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Menyimpan hasil
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) menambahkan gambar terpangkas ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan bertambah.

Metode ini mengonversi file metafile WMF/EMF menjadi gambar PNG raster dalam operasi pemangkasan. 

{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam sebuah presentasi menggunakan metode [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran shape dan resolusi yang ditentukan, dengan opsi untuk menghapus area terpangkas.

Ini menyesuaikan ukuran dan resolusi gambar mirip dengan fitur **Picture Format -> Compress Pictures -> Resolution** di PowerPoint.

Contoh Java berikut menunjukkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area terpangkas:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area terpangkas.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Periksa hasil kompresi.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Atau menggunakan nilai DPI khusus secara langsung:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompres gambar menjadi 150 DPI (resolusi web), menghapus area terpangkas.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metode mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran shape dan DPI yang diberikan. Region terpangkas juga dapat dihapus untuk mengoptimalkan ukuran file.  
Jika gambar adalah metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit dikurangi tergantung resolusi, mirip dengan cara PowerPoint menangani JPEG resolusi tinggi.

{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin bentuk yang berisi gambar mempertahankan rasio aspeknya bahkan setelah Anda mengubah dimensi gambar, Anda dapat menggunakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) untuk mengatur pengaturan *Lock Aspect Ratio*. 

Kode Java berikut menunjukkan cara mengunci rasio aspek bentuk:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // atur bentuk agar mempertahankan rasio aspek saat diubah ukuran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk, bukan gambar yang dikandungnya.

{{% /alert %}}

## **Gunakan Properti StretchOff**

Kombinasi properti [StretchOffsetLeft](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) dan [StretchOffsetBottom](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat) serta kelas [PictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPictureFillFormat), Anda dapat menentukan sebuah persegi panjang isi.

Saat stretching ditentukan untuk sebuah gambar, persegi panjang sumber akan diskalakan agar sesuai dengan persegi panjang isi yang ditentukan. Setiap tepi persegi panjang isi didefinisikan oleh offset persentase dari tepi yang bersesuaian dari kotak pembatas bentuk. Persentase positif menunjukkan inset (penyusutan) sementara persentase negatif menunjukkan outset (perluasan).

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan persegi panjang `AutoShape`. 
4. Buat sebuah gambar.
5. Atur jenis isian bentuk.
6. Atur mode isian gambar bentuk.
7. Tambahkan gambar yang disetel untuk mengisi bentuk.
8. Tentukan offset gambar dari tepi yang bersesuaian dari kotak pembatas bentuk
9. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan proses di mana properti StretchOff digunakan:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Membuat instance kelas ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan AutoShape yang disetel ke Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Mengatur tipe isian bentuk
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Mengatur mode isian gambar bentuk
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Mengatur gambar untuk mengisi bentuk
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Menentukan offset gambar dari tepi yang bersesuaian dari kotak pembatas bentuk
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Menulis file PPTX ke disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui format gambar apa yang didukung untuk PictureFrame?**

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya, SVG) melalui objek gambar yang ditetapkan pada [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar besar mempengaruhi ukuran dan kinerja PPTX?**

Menyematkan gambar berukuran besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil tetapi memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran file.

**Bagaimana saya dapat mengunci objek gambar agar tidak secara tidak sengaja dipindahkan/diperbesar?**

Gunakan [shape locks](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) (misalnya, menonaktifkan pemindahan atau pengubahan ukuran). Mekanisme penguncian dijelaskan untuk bentuk dalam sebuah [artikel perlindungan](/slides/id/java/applying-protection-to-presentation/) terpisah dan didukung untuk berbagai tipe bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG tetap terjaga saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/java/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/java/convert-powerpoint-to-png/), hasilnya dapat menjadi raster tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.