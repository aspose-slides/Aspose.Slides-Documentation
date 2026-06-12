---
title: Kelola Bingkai Gambar dalam Presentasi Menggunakan JavaScript
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/nodejs-java/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- potong gambar
- area terpotong
- properti StretchOff
- formatasi bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java. Sederhanakan alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah bentuk yang berisi gambar—seperti gambar dalam sebuah bingkai.

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="primary" %}} 
Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 
{{% /alert %}} 

## **Membuat Bingkai Gambar**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek `PPImage` dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFrame) berdasarkan lebar dan tinggi gambar melalui metode `addPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat bingkai gambar:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Membuat instance kelas Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Menambahkan bingkai gambar dengan tinggi dan lebar gambar yang setara
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bingkai gambar memungkinkan Anda dengan cepat membuat slide presentasi berdasarkan gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat memanipulasi operasi input/output untuk mengonversi gambar dari satu format ke format lain.

## **Membuat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih kompleks. 

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi.
4. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar.
6. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara membuat bingkai gambar dengan skala relatif:

```javascript
// Membuat instance kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Membuat instance kelas Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Tambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Mengatur skala relatif lebar dan tinggi
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFrame) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini menunjukkan cara mengekstrak gambar dari dokumen “sample.pptx” dan menyimpannya dalam format PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Mengekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides untuk Node.js via Java memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), memeriksa apakah [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut memperlihatkan cara mengekstrak gambar SVG dari bingkai gambar:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Mendapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada gambar. Kode JavaScript ini menunjukkan operasinya:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Menggunakan opsi-opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan persyaratan spesifik.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) yang disediakan oleh objek [Shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection) yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Atur warna garis bingkai gambar.
8. Atur lebar garis bingkai gambar.
9. Putar bingkai gambar dengan memberi nilai positif atau negatif.
   * Nilai positif memutar gambar searah jarum jam. 
   * Nilai negatif memutar gambar berlawanan arah jarum jam.
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
11. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini mendemonstrasikan proses pemformatan bingkai gambar:

```javascript
// Membuat instance kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Membuat instance kelas Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Menambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Menerapkan beberapa format ke PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose baru-baru ini mengembangkan [Collage Maker gratis](https://products.aspose.app/slides/id/collage). Jika Anda perlu [menggabungkan gambar JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) atau PNG, [membuat grid dari foto](https://products.aspose.app/slides/id/collage/photo-grid), Anda dapat menggunakan layanan ini. 
{{% /alert %}}

## **Menambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyematkan file secara langsung ke dalam presentasi. Kode JavaScript ini menunjukkan cara menambahkan gambar dan video ke placeholder:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Memangkas Gambar**

Kode JavaScript ini menunjukkan cara memangkas gambar yang sudah ada pada slide:

```javascript
var pres = new aspose.slides.Presentation();
// Membuat objek gambar baru
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan PictureFrame ke Slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Memotong gambar (nilai persentase)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Menyimpan hasil
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Area yang Dipangkas pada Bingkai Gambar**

Jika Anda ingin menghapus area yang dipangkas dari gambar yang terdapat dalam bingkai, Anda dapat menggunakan metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Metode ini mengembalikan gambar yang dipangkas atau gambar asli jika pemangkasan tidak diperlukan.

Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Mendapatkan PictureFrame dari slide pertama
    var picFrame = slide.getShapes().get_Item(0);
    // Menghapus area yang dipotong dari gambar PictureFrame dan mengembalikan gambar yang dipotong
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Menyimpan hasil
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) menambahkan gambar yang dipangkas ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan meningkat.

Metode ini mengonversi metafile WMF/EMF ke gambar PNG raster dalam operasi pemangkasan. 
{{% /alert %}}

## **Mengompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) .
Metode ini mengompres gambar dengan mengurangi ukuran berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi menghapus area yang dipangkas.

Ini menyesuaikan ukuran dan resolusi gambar serupa dengan fitur **Picture Format → Compress Pictures → Resolution** di PowerPoint.

Contoh JavaScript berikut memperlihatkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipangkas:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Kompress gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area yang dipotong.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Periksa hasil kompresi.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Atau menggunakan nilai DPI yang telah ditentukan sebelumnya:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Kompres gambar ke 96 DPI (resolusi email), menghapus area yang dipotong.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metode ini mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran bentuk dan DPI yang diberikan. Region yang dipangkas juga dapat dihapus untuk mengoptimalkan ukuran file.
Jika gambar adalah metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit dikurangi berdasarkan resolusi, serupa dengan cara PowerPoint menangani JPEG beresolusi tinggi.
{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin bentuk yang berisi gambar mempertahankan rasio aspeknya bahkan setelah mengubah dimensi gambar, Anda dapat menggunakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) untuk mengatur pengaturan *Lock Aspect Ratio*.

Kode JavaScript ini menunjukkan cara mengunci rasio aspek bentuk:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // atur bentuk agar mempertahankan rasio aspek saat mengubah ukuran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk dan bukan gambar yang dikandungnya.
{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan metode [setStretchOffsetLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) dan [setStretchOffsetBottom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat), Anda dapat menentukan persegi panjang isi.

Ketika peregangan ditentukan untuk gambar, persegi panjang sumber diskalakan agar sesuai dengan persegi panjang isi yang ditentukan. Setiap sisi persegi panjang isi didefinisikan oleh offset persentase dari sisi yang bersesuaian dari kotak pembatas bentuk. Persentase positif menentukan inset sementara persentase negatif menentukan outset.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan persegi panjang `AutoShape`. 
4. Buat gambar.
5. Atur tipe isi bentuk.
6. Atur mode isi gambar bentuk.
7. Tambahkan gambar yang akan mengisi bentuk.
8. Tentukan offset gambar dari sisi kotak pembatas bentuk yang bersesuaian.
9. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini mendemonstrasikan proses penggunaan properti StretchOff:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Membuat instance kelas ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan AutoShape yang diatur ke Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Mengatur tipe isi bentuk
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Mengatur mode isi gambar bentuk
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Mengatur gambar untuk mengisi bentuk
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Menentukan offset gambar dari sisi yang bersesuaian dari kotak pembatas bentuk
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Menulis file PPTX ke disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana cara mengetahui format gambar apa yang didukung untuk PictureFrame?**

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar besar memengaruhi ukuran dan kinerja PPTX?**

Menyematkan gambar besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil namun memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran file.

**Bagaimana cara mengunci objek gambar agar tidak tergerak/diubah ukuran secara tidak sengaja?**

Gunakan [shape locks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) (misalnya menonaktifkan pemindahan atau pengubahan ukuran). Mekanisme penguncian didukung untuk berbagai tipe bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG tetap terjaga saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/nodejs-java/convert-powerpoint-to-png/), hasilnya dapat dirasterisasi tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.