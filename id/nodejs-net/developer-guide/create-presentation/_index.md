---
title: Buat Presentasi di Node.js via .NET
linktitle: Buat Presentasi
type: docs
weight: 10
url: /id/nodejs-net/create-presentation/
keywords:
- buat presentasi
- presentasi baru
- buat PowerPoint
- buat PPTX
- tambahkan kotak teks
- tambahkan slide
- ukuran slide
- layar lebar
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat presentasi PowerPoint dalam JavaScript dengan Aspose.Slides untuk Node.js via .NET: tambahkan kotak teks dan slide, atur ukuran slide 16:9, dan simpan hasilnya sebagai PPTX."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi dengan Aspose.Slides untuk Node.js via .NET, menambahkan kotak teks ke slide pertama, dan menyimpan hasilnya sebagai file PPTX. Artikel ini juga menunjukkan cara menambahkan lebih banyak slide dan cara mengubah presentasi menjadi slide layar lebar (16:9).

Contoh-contoh memerlukan proyek yang disiapkan seperti dijelaskan di [Instalasi](/slides/id/nodejs-net/installation/). Simpan setiap contoh sebagai file `.js` di folder proyek dan jalankan dari folder itu dengan `node`, misalnya `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk Node.js via .NET tidak memiliki referensi API sendiri. Ia mencerminkan API Aspose.Slides untuk .NET dengan nama camelCase, sehingga tautan API dalam artikel ini mengarah ke kelas dan anggota yang cocok di [Referensi API Aspose.Slides untuk .NET](https://reference.aspose.com/slides/id/net/).
{{% /alert %}}

## **Buat Presentasi dengan Kotak Teks**

1. Buat instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Presentasi baru sudah berisi satu slide kosong.  
2. Dapatkan slide tersebut dari koleksi [slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/). Koleksi dalam paket ini dibaca dengan `get(index)`, dan indeks dimulai dari 0.  
3. Tambahkan sebuah persegi panjang dengan metode [addAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/shapecollection/addautoshape/) dan atur [text](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/text/) pada [textFrame](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/textframe/) miliknya.  
4. Simpan presentasi dengan metode [save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dan nilai `SaveFormat.Pptx`.  
5. Panggil `dispose` dalam blok `finally` untuk melepaskan sumber daya .NET yang mendukung presentasi.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posisi (x, y) dan ukuran (lebar, tinggi) berada dalam poin.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Skrip menulis `new-presentation.pptx` ke folder proyek. File tersebut memiliki satu slide dengan persegi panjang berisi yang sudut kiri-atasnya berada 50 poin dari tepi kiri dan atas slide. Persegi panjang tersebut lebar 400 poin dan tinggi 100 poin, dan teksnya terpusat. Satu poin adalah 1/72 inci. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi ke slide; lihat [Lisensi](/slides/id/nodejs-net/licensing/).

## **Tambah Slide**

Presentasi baru memiliki satu slide. Untuk menambahkan lebih banyak, berikan slide tata letak ke metode [addEmptySlide](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/addemptyslide/) dari koleksi `slides`. Metode [getByType](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslidecollection/getbytype/) dari koleksi [layoutSlides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/layoutslides/) mengembalikan tata letak pertama dari [SlideLayoutType](https://reference.aspose.com/slides/id/net/aspose.slides/slidelayouttype/) yang diberikan.

Contoh berikut menambahkan dua slide dengan tata letak Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrip mencetak `Slide count: 3` dan menulis `three-slides.pptx`. Slide baru ditambahkan setelah slide pertama dan tidak berisi bentuk apapun. Presentasi baru selalu memiliki tata letak Blank, tetapi presentasi yang Anda buka dari file mungkin tidak memiliki tata letak dengan tipe yang diminta; dalam kasus tersebut `getByType` mengembalikan `null`, jadi periksa hasilnya sebelum Anda menggunakannya.

## **Atur Ukuran Slide**

Presentasi baru menggunakan slide 4:3 yang berukuran 720 × 540 poin (10 × 7,5 inci). Untuk membuat slide layar lebar, panggil metode [setSize](https://reference.aspose.com/slides/id/net/aspose.slides/slidesize/setsize/) dari [slideSize](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slidesize/) presentasi dengan nilai [SlideSizeType](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizetype/) dan nilai [SlideSizeScaleType](https://reference.aspose.com/slides/id/net/aspose.slides/slidesizescaletype/). Tipe skala memberi tahu Aspose.Slides apa yang harus dilakukan dengan bentuk yang sudah ada di slide; `DoNotScale` membiarkannya apa adanya, yang merupakan pilihan tepat untuk presentasi yang belum memiliki konten.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skrip mencetak `Slide size: 960 x 540 points`, yang merupakan 13,33 × 7,5 inci, dan menulis `widescreen.pptx`. `SlideSizeType.OnScreen16x9` memiliki rasio aspek 16:9 yang sama tetapi lebih kecil: 720 × 405 poin.

## **FAQ**

**Dalam satuan apa posisi dan ukuran diukur?**

Dalam poin. Satu inci adalah 72 poin, sehingga slide default 4:3 berukuran 720 × 540 poin, dan slide layar lebar 16:9 berukuran 960 × 540 poin.

**Format apa yang dapat saya simpan untuk presentasi baru?**

Nilai apa pun dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/), misalnya `SaveFormat.Ppt` untuk PowerPoint 97–2003, `SaveFormat.Odp` untuk OpenDocument, atau `SaveFormat.Pdf`. Untuk output PDF, lihat [Konversi PowerPoint ke PDF](/slides/id/nodejs-net/convert-powerpoint-to-pdf/).

**Mengapa presentasi yang disimpan berisi teks "Evaluation only"?**

Tanpa lisensi, Aspose.Slides menambahkan watermark evaluasi ke slide yang disimpan. Terapkan lisensi seperti dijelaskan di [Lisensi](/slides/id/nodejs-net/licensing/) untuk menghilangkannya.

**Mengapa saya harus memanggil `dispose`?**

Objek `Presentation` didukung oleh objek .NET yang menyimpan memori dan sumber daya lainnya. Memanggil `dispose` membebaskannya segera setelah Anda tidak lagi membutuhkan presentasi, dan memanggilnya dalam blok `finally` membebaskannya bahkan ketika terjadi kesalahan.