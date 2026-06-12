---
title: "Tentukan Font Presentasi Default dalam Java"
linktitle: "Font Default"
type: docs
weight: 30
url: /id/java/default-font/
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
- Java
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk Java untuk memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) ke PDF, XPS, dan gambar yang tepat."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Ini berguna saat menghasilkan thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Metode `setDefaultRegularFont` mendefinisikan font default untuk teks reguler, sementara `setDefaultAsianFont` mendefinisikan font default untuk teks Asia. Setelah opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan Aspose.Slides for Java API:

1. Buat instance dari [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/LoadOptions).
1. [Setel DefaultRegularFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.
1. [Setel DefaultAsianFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ke font yang Anda inginkan. Saya menggunakan Wingdings pada contoh berikut.
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.
1. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

```java
// Gunakan opsi pemuatan untuk menentukan font reguler dan font Asia default
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Hasilkan thumbnail slide
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // simpan gambar ke disk.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Hasilkan PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Hasilkan XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline perenderan untuk semua output yang didukung. Ini termasuk thumbnail slide, [PDF](/slides/id/java/convert-powerpoint-to-pdf/), [XPS](/slides/id/java/convert-powerpoint-to-xps/), [gambar raster](/slides/id/java/convert-powerpoint-to-png/), [HTML](/slides/id/java/convert-powerpoint-to-html/), dan [SVG](/slides/id/java/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glif yang sama untuk semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa perenderan?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka‑menyimpan secara langsung sebuah presentasi tidak mengubah run font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengatur ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/java/custom-font/) memperluas katalog keluarga dan glif yang tersedia yang dapat digunakan mesin. Font default dan setiap [aturan fallback](/slides/id/java/fallback-font/) akan diselesaikan terhadap sumber tersebut terlebih dahulu, menghasilkan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advance) dan oleh karena itu pemutusan baris serta pembungkusannya?**

Ya. Mengubah font mengubah metrik glif dan dapat mengubah pemutusan baris, pembungkus, dan paginasi selama perenderan. Untuk kestabilan tata letak, [sematkan font asli](/slides/id/java/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada manfaat mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/java/embedded-font/) sudah memastikan tampilan konsisten. Font default tetap membantu sebagai jaring pengaman untuk karakter yang tidak tercakup oleh subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.