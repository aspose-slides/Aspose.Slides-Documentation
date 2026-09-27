---
title: Mengonversi Slide Presentasi menjadi Gambar di Node.js via .NET
linktitle: Slide ke Gambar
type: docs
weight: 40
url: /id/nodejs-net/convert-slide/
keywords:
- konversi slide
- slide ke gambar
- slide ke PNG
- simpan slide sebagai gambar
- render slide
- thumbnail slide
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Render slide dari presentasi PPTX, PPT, dan ODP sebagai gambar PNG dalam JavaScript dengan Aspose.Slides untuk Node.js via .NET, dengan faktor skala atau ukuran pasti dalam piksel."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via .NET merender slide dari presentasi PowerPoint dan OpenDocument menjadi gambar, misalnya untuk menampilkan pratinjau slide pada halaman web. Artikel ini menunjukkan dua cara memilih ukuran gambar: faktor skala relatif terhadap ukuran slide, dan ukuran pasti dalam piksel. Kedua contoh menyimpan file PNG.

Contoh-contoh mengharapkan sebuah presentasi bernama `sample.pptx` di folder proyek yang Anda siapkan di [Instalasi](/slides/id/nodejs-net/installation/). Presentasi PowerPoint apa pun dapat digunakan. Simpan tiap contoh sebagai file `.js` di folder proyek dan jalankan dari folder tersebut dengan `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Buka presentasi dengan konstruktor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
1. Dapatkan slide dari koleksi [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) dengan `get(index)`. Indeks dimulai dari 0.
1. Render slide dengan `getImageWithScale` atau `getImageWithImageSize`. Dalam referensi API .NET, keduanya merupakan overload dari [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). Mereka mengembalikan objek gambar yang sesuai dengan [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
1. Simpan gambar dengan metode [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) dan nilai [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), lalu panggil metode `dispose`-nya.

## **Konversi Setiap Slide ke Gambar PNG**

`getImageWithScale` mengambil faktor skala horizontal dan vertikal. Pada skala 1, satu poin slide menjadi satu piksel gambar. Contoh berikut merender setiap slide dengan skala 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Skala 1 merender satu piksel per poin; 2 menggandakan lebar dan tinggi.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Skrip menulis satu file per slide, `slide_1.png`, `slide_2.png`, dan seterusnya, dengan penomoran mulai dari 1. Untuk presentasi 16:9 dengan slide berukuran 960 × 540 poin, tiap gambar berukuran 1920 × 1080 piksel. Slide yang tersembunyi juga dirender; untuk melewatkannya, periksa properti [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) slide. Setiap gambar dibebaskan dalam blok `finally` masing‑masing, yang melepaskannya sebelum slide berikutnya dirender. Tanpa lisensi, gambar juga menampilkan watermark evaluasi; lihat [Lisensi](/slides/id/nodejs-net/licensing/).

## **Konversi Slide ke Gambar dengan Ukuran Tertentu**

`getImageWithImageSize` mengambil sebuah objek dengan `width` dan `height` dalam piksel. Contoh berikut merender slide pertama dengan lebar 1280 piksel dan menghitung tinggi berdasarkan ukuran slide, sehingga gambar mempertahankan rasio aspek slide:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Properti [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) mengembalikan lebar dan tinggi slide dalam poin. Untuk presentasi 16:9, skrip mencetak `Saved a 1280 x 720 image` dan menulis `slide_1_1280px.png`; untuk presentasi 4:3, gambar berukuran 1280 × 960 piksel.

## **FAQ**

**Mengapa gambar dari `getImage` tanpa argumen begitu kecil?**

Tanpa argumen, `getImage` merender slide pada 20% ukuran dalam poin, sehingga slide 960 × 540 poin menjadi gambar 192 × 108 piksel. Gunakan `getImageWithScale` atau `getImageWithImageSize` untuk memilih ukuran.

**Bagaimana cara menyimpan JPEG atau format gambar lainnya?**

Berikan nilai `ImageFormat` lain ke metode `save` gambar, misalnya `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Format diambil dari nilai `ImageFormat`, bukan dari ekstensi file, jadi pastikan keduanya konsisten.

**Mengapa teks pada gambar terlihat berbeda di Linux?**

Aspose.Slides hanya dapat menggunakan font yang terpasang di mesin yang merender slide. Ketika presentasi menggunakan font yang tidak ada, seperti Calibri pada server Linux typical, Aspose.Slides menggunakan font yang terpasang sebagai pengganti, yang dapat mengubah tampilan teks dan pemenggalan baris. Instal font yang digunakan presentasi Anda untuk mendapatkan gambar yang sama seperti di Windows.

**Mengapa `getThumbnailWithImageSize` gagal dengan TypeError?**

README paket menggunakan `getThumbnailWithImageSize`, tetapi paket tidak memiliki metode `getThumbnail`. Gunakan `getImageWithImageSize` sebagai gantinya; ia mengambil argumen `{ width, height }` yang sama.