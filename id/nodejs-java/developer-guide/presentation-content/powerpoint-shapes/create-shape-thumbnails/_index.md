---
title: Buat Miniatur Bentuk Presentasi dalam JavaScript
linktitle: Miniatur Bentuk
type: docs
weight: 70
url: /id/nodejs-java/create-shape-thumbnails/
keywords:
- miniatur bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Hasilkan miniatur bentuk berkualitas tinggi dari slide PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js – dengan mudah buat dan ekspor miniatur presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide ini dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun kadang‑kadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides membantu Anda menghasilkan gambar miniatur bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.
Artikel ini menjelaskan cara menghasilkan miniatur slide dengan berbagai cara:

- Menghasilkan miniatur bentuk di dalam slide.
- Menghasilkan miniatur bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan miniatur bentuk dalam batas tampilan bentuk.

## **Menghasilkan Miniatur Bentuk dari Slide**

Untuk menghasilkan miniatur bentuk dari slide mana pun menggunakan Aspose.Slides untuk Node.js via Java, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. [Dapatkan gambar miniatur bentuk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getImage--) dari slide yang direferensikan dengan skala default.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan miniatur bentuk dari slide:

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Menyimpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghasilkan Miniatur Bentuk dengan Faktor Skala yang Ditentukan Pengguna**

Untuk menghasilkan miniatur bentuk slide menggunakan Aspose.Slides untuk Node.js via Java, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. [Dapatkan gambar miniatur bentuk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan miniatur bentuk berdasarkan faktor skala yang ditentukan:

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Menyimpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghasilkan Miniatur Bentuk Berdasarkan Batas**

Metode ini untuk membuat miniatur bentuk memungkinkan pengembang menghasilkan miniatur dalam batas tampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Miniatur bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan miniatur bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. Dapatkan gambar miniatur dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini didasarkan pada langkah‑langkah di atas:

```javascript
// Membuat instance kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Menyimpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dapatkan Batas Visual Aktual dari Sebuah Bentuk**

Properti bingkai dari sebuah [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/)—metode `getX()`, `getY()`, `getWidth()`, dan `getHeight()`—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui bingkai tersebut atau menempati persegi panjang yang berorientasi sumbu yang berbeda. Rotasi, garis tepi, kepala panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, serta efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getVisualBounds--) untuk menghitung area yang ditempati tersebut tanpa membuat gambar. Metode ini mengembalikan objek [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong pada slide, sehingga koordinatnya dapat menjadi negatif ketika konten melampaui asal slide.

Contoh berikut mendapatkan dan membandingkan bingkai dan batas visual:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Persegi panjang yang sama dapat digunakan untuk menyelaraskan bentuk‑bentuk di sekitarnya ke tepi kiri, kanan, atas, atau bawah; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan bentuk grup, di mana bingkai yang disimpan mungkin tidak mewakili hasil render penuh.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getVisualBounds--) ketika Anda membutuhkan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [Shape.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage--) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` mengatur ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds.Appearance` mengatur ukuran dari tampilan bentuk dan membatasi hasil pada batas slide. Sebaliknya, [Shape.getVisualBounds](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getVisualBounds--) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya pada slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan miniatur bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender miniatur?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/nodejs-java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap akan dirender sebagai miniatur?**

Sebuah bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/)) dapat disimpan sebagai miniatur atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas miniatur untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang dibutuhkan](/slides/id/nodejs-java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/nodejs-java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan tata letak teks.