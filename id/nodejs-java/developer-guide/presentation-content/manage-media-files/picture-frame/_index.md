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
- pemformatan bingkai gambar
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

Bingkai gambar adalah bentuk yang berisi gambar—mirip dengan gambar dalam sebuah bingkai. 

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek `PPImage` dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFrame) berdasarkan lebar dan tinggi gambar melalui metode `addPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

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

Bingkai gambar memungkinkan Anda dengan cepat membuat slide presentasi berdasarkan gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat mengelola operasi input/output untuk mengonversi gambar dari satu format ke format lain.

## **Buat Bingkai Gambar dengan Skala Relatif**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan gambar ke koleksi gambar presentasi.
4. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar.
6. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```javascript
// Membuat instance kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
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

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFrame) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah menunjukkan cara mengekstrak gambar dari dokumen "sample.pptx" dan menyimpannya dalam format PNG.

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

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides untuk Node.js via Java memungkinkan Anda mengambil gambar vektor asli dengan keakuratan penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), memeriksa apakah [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau aliran dalam format SVG aslinya.

Contoh kode berikut menunjukkan cara mengekstrak gambar SVG dari sebuah bingkai gambar:

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

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek transparansi yang diterapkan pada gambar. Kode JavaScript ini menunjukkan operasi tersebut:

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

## **Dapatkan Kecerahan dan Kontras Gambar**

Aspose.Slides memungkinkan Anda mendapatkan efek kecerahan dan kontras yang diterapkan pada gambar. Kelas [Luminance](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/luminance/) mewakili efek transformasi gambar ini.

Kode JavaScript ini menunjukkan cara mendapatkan pengaturan kecerahan dan kontras dari sebuah bingkai gambar:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan menggunakan opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan persyaratan tertentu.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PPImage) dengan menambahkan gambar ke [ImagesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi gambar.
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) yang disediakan oleh objek [Shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection) yang terkait dengan slide yang direferensikan.
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
7. Atur warna garis bingkai gambar.
8. Atur lebar garis bingkai gambar.
9. Putar bingkai gambar dengan memberikan nilai positif atau negatif.  
   * Nilai positif memutar gambar searah jarum jam.  
   * Nilai negatif memutar gambar berlawanan arah jarum jam.
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide.
11. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

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

Baru-baru ini Aspose mengembangkan [Collage Maker gratis](https://products.aspose.app/slides/id/collage). Jika Anda perlu [menggabungkan gambar JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) atau PNG, [membuat grid dari foto](https://products.aspose.app/slides/id/collage/photo-grid), Anda dapat menggunakan layanan ini. 

{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyisipkan berkas secara langsung ke dalam presentasi. Kode JavaScript ini memperlihatkan cara menambahkan gambar dan video ke placeholder:

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

## **Pangkas Gambar**

Kode JavaScript ini memperlihatkan cara memotong gambar yang ada pada slide:

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

## **Hapus Area yang Dipotong dari Gambar**

Jika Anda ingin menghapus area yang dipotong dari gambar yang terdapat dalam sebuah bingkai, Anda dapat menggunakan metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Metode ini mengembalikan gambar yang dipotong atau gambar asli jika pemotongan tidak diperlukan.

Kode JavaScript ini mendemonstrasikan operasi tersebut:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Mendapatkan PictureFrame dari slide pertama
    var picFrame = slide.getShapes().get_Item(0);
    // Menghapus area terpotong dari gambar PictureFrame dan mengembalikan gambar terpotong
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

Metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) menambahkan gambar yang dipotong ke koleksi gambar presentasi. Jika gambar hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) yang diproses, pengaturan ini dapat mengurangi ukuran presentasi. Jika tidak, jumlah gambar dalam presentasi yang dihasilkan akan meningkat.

Metode ini mengonversi file metafile WMF/EMF menjadi gambar PNG raster dalam operasi pemotongan. 

{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam sebuah presentasi menggunakan metode [PictureFillFormat.compressImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-). Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran shape dan resolusi yang ditentukan, dengan opsi menghapus area yang dipotong.

Ia menyesuaikan ukuran dan resolusi gambar serupa dengan fitur PowerPoint **Picture Format → Compress Pictures → Resolution**.

Contoh JavaScript berikut menunjukkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipotong:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area terpotong.
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

Atau menggunakan nilai DPI yang telah ditentukan lainnya:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Kompres gambar ke 96 DPI (resolusi email), menghapus area terpotong.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metode mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran shape dan DPI yang diberikan. Area yang dipotong juga dapat dihapus untuk mengoptimalkan ukuran berkas. Jika gambar berupa metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit dikurangi berdasarkan resolusi, serupa dengan cara PowerPoint menangani JPEG beresolusi tinggi.

{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin sebuah shape yang berisi gambar mempertahankan rasio aspeknya bahkan setelah mengubah dimensi gambar, Anda dapat menggunakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) untuk mengatur pengaturan *Lock Aspect Ratio*.

Kode JavaScript ini menunjukkan cara mengunci rasio aspek shape:

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
    // atur shape agar mempertahankan rasio aspek saat diubah ukuran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek shape dan tidak mempertahankan gambar yang terdapat di dalamnya.

{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan metode [setStretchOffsetLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) , dan [setStretchOffsetBottom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PictureFillFormat), Anda dapat menentukan sebuah persegi isi.

Saat stretching ditentukan untuk sebuah gambar, persegi sumber akan diskalakan agar sesuai dengan persegi isi yang ditentukan. Setiap sisi persegi isi didefinisikan oleh offset persentase dari sisi yang bersesuaian pada kotak pembatas shape. Persentase positif menunjukkan inset sementara persentase negatif menunjukkan outset.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah persegi `AutoShape`. 
4. Buat sebuah gambar.
5. Atur jenis isi shape.
6. Atur mode isi gambar shape.
7. Tambahkan gambar yang diatur untuk mengisi shape.
8. Tentukan offset gambar dari sisi yang bersesuaian pada kotak pembatas shape
9. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode JavaScript ini mendemonstrasikan proses di mana properti StretchOff digunakan:

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
    // Menambahkan AutoShape dengan tipe Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Mengatur tipe isi shape
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Mengatur mode isi gambar shape
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Mengatur gambar untuk mengisi shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Menentukan offset gambar dari tepi yang bersesuaian pada kotak pembatas shape
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

**Bagaimana cara mengetahui format gambar apa saja yang didukung untuk PictureFrame?**

Aspose.Slides mendukung gambar raster (PNG, JPEG, BMP, GIF, dll.) dan gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar besar memengaruhi ukuran dan kinerja PPTX?**

Menyisipkan gambar besar meningkatkan ukuran berkas dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil tetapi memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran berkas.

**Bagaimana saya dapat mengunci objek gambar agar tidak secara tidak sengaja dipindahkan/diubah ukurannya?**

Gunakan [shape locks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) (misalnya, nonaktifkan pemindahan atau perubahan ukuran). Mekanisme penguncian didukung untuk berbagai tipe shape, termasuk [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/).

**Apakah keakuratan vektor SVG tetap terjaga saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/nodejs-java/convert-powerpoint-to-png/), hasilnya mungkin dirasterisasi tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.