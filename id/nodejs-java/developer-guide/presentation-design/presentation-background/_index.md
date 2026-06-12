---
title: Mengelola Latar Belakang Presentasi dalam JavaScript
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/nodejs-java/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradien
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js, dengan tip kode untuk meningkatkan presentasi Anda."
---
## **Pendahuluan**

Warna solid, gradien, dan gambar biasanya digunakan untuk latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku untuk beberapa slide sekaligus).

![PowerPoint background](powerpoint-background.png)

## **Mengatur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam presentasi—bahkan jika presentasi menggunakan slide master. Perubahan hanya berlaku pada slide yang dipilih.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/backgroundtype/) slide ke `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) latar belakang slide ke `Solid`.
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) pada [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang slide normal:

```js
// Buat instance dari kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Atur warna latar belakang slide menjadi biru.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Simpan presentasi ke disk.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam presentasi. Slide master berfungsi sebagai templat yang mengontrol pemformatan untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, warna tersebut diterapkan pada setiap slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/backgroundtype/) slide master (via `getMasters`) ke `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) latar belakang slide master ke `Solid`.
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut menunjukkan cara mengatur warna solid hijau sebagai latar belakang slide master:

```js
// Buat instance dari kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Atur warna latar belakang slide Master menjadi Hijau Hutan.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Simpan presentasi ke disk.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Latar Belakang Gradien untuk Slide**

Gradien adalah efek grafis yang dibuat oleh perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradien dapat membuat presentasi tampak lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradien sebagai latar belakang untuk slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/backgroundtype/) slide ke `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) latar belakang slide ke `Gradient`.
4. Gunakan metode [getGradientFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getGradientFormat) pada [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradien yang diinginkan.
5. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut menunjukkan cara mengatur warna gradien sebagai latar belakang slide:

```js
// Buat instance dari kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Terapkan efek gradien pada latar belakang.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Simpan presentasi ke disk.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengatur Gambar sebagai Latar Belakang Slide**

Selain isian solid dan gradien, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .
2. Atur [BackgroundType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/backgroundtype/) slide ke `OwnBackground`.
3. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) latar belakang slide ke `Picture`.
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide.
5. Tambahkan gambar ke koleksi gambar presentasi.
6. Gunakan metode [getPictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) pada [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang.
7. Simpan presentasi yang telah dimodifikasi.

Contoh JavaScript berikut menunjukkan cara mengatur gambar sebagai latar belakang slide:

```js
// Buat instance dari kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Atur properti gambar latar belakang.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Muat gambar.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Tambahkan gambar ke koleksi gambar presentasi.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Simpan presentasi ke disk.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Contoh kode berikut menunjukkan cara mengatur jenis isian latar belakang menjadi gambar ubin dan mengubah properti ubin:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Atur gambar yang digunakan untuk isian latar belakang.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Atur mode isian gambar menjadi Ubin dan sesuaikan properti ubin.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Baca selengkapnya: [**Ubin Gambar Sebagai Tekstur**](/slides/id/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar isi slide lebih menonjol. Kode JavaScript berikut menunjukkan cara mengubah transparansi untuk gambar latar belakang slide:

```js
var transparencyValue = 30; // Sebagai contoh.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Dapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan kelas `BackgroundEffectiveData` untuk mengambil nilai latar belakang efektif slide. Kelas ini mengekspos [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/) dan [EffectFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effectformat/) yang efektif.

Dengan menggunakan metode `getBackground` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh JavaScript berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```js
// Buat instance dari kelas Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ambil latar belakang efektif, memperhitungkan master, layout, dan tema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ulang latar belakang khusus dan mengembalikan latar belakang tema/layout?**

Ya. Hapus isian khusus slide, dan latar belakang akan kembali diwarisi dari slide [layout](/slides/id/nodejs-java/slide-layout/)/[master](/slides/id/nodejs-java/slide-master/) yang bersangkutan (yaitu [latar belakang tema](/slides/id/nodejs-java/presentation-theme/)).

**Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?**

Jika sebuah slide memiliki isian sendiri, isian tersebut tidak akan berubah. Jika latar belakang diwarisi dari [layout](/slides/id/nodejs-java/slide-layout/)/[master](/slides/id/nodejs-java/slide-master/), maka akan diperbarui agar sesuai dengan [tema baru](/slides/id/nodejs-java/presentation-theme/).