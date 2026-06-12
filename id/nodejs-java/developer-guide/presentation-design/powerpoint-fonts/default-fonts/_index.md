---
title: Tentukan Font Default Presentasi dalam JavaScript
linktitle: Font Default
type: docs
weight: 30
url: /id/nodejs-java/default-font/
keywords:
- font default
- font reguler
- font normal
- font Asia
- ekspor PDF
- ekspor XPS
- ekspor gambar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tetapkan font default di Aspose.Slides untuk Node.js via Java untuk memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) yang tepat ke PDF, XPS, dan gambar."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Ini berguna ketika menghasilkan thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

`setDefaultRegularFont` menetapkan font default untuk teks biasa, sedangkan `setDefaultAsianFont` menetapkan font default untuk teks Asia. Setelah opsi-opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Menggunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda menetapkan font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan Aspose.Slides untuk Node.js melalui Java API:

1. Buat sebuah instance dari [LoadOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LoadOptions).
1. [Setel DefaultRegularFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.
1. [Setel DefaultAsianFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ke font yang Anda inginkan. Saya menggunakan Wingdings dalam contoh berikut.
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.
1. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

Implementasi dari di atas diberikan di bawah.

```javascript
// Gunakan opsi pemuatan untuk menentukan font default reguler dan Asia
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Muat presentasi
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Hasilkan thumbnail slide
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // simpan gambar ke disk.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Hasilkan PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Hasilkan XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/), [gambar raster](/slides/id/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/), dan [SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama di semua target tersebut.

**Apakah font default diterapkan ketika hanya membaca dan menyimpan PPTX tanpa rendering?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka‑simpan (open‑save) sebuah presentasi tidak mengubah rangkaian font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengatur ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/nodejs-java/custom-font/) memperluas katalog keluarga dan glyph yang tersedia bagi mesin untuk digunakan. Font default dan setiap [aturan fallback](/slides/id/nodejs-java/fallback-font/) akan diresolusi terhadap sumber tersebut terlebih dahulu, memberikan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advance) dan dengan demikian pemecahan baris serta pembungkusannya?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah pemecahan baris, pembungkus, serta paginasi selama rendering. Untuk stabilitas tata letak, [sematkan font asli](/slides/id/nodejs-java/embedded-font/) atau pilih keluarga default dan fallback yang secara metrik kompatibel.

**Apakah ada manfaat mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/nodejs-java/embedded-font/) sudah memastikan tampilan yang konsisten. Font default tetap membantu sebagai jaring pengaman untuk karakter yang tidak tercakup oleh subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.