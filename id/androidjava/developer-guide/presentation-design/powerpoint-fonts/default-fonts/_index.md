---
title: Tentukan Font Presentasi Default di Android
linktitle: Font Default
type: docs
weight: 30
url: /id/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk Android via Java untuk memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) yang tepat ke PDF, XPS, dan gambar."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Hal ini berguna saat membuat thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Metode `setDefaultRegularFont` menentukan font default untuk teks biasa, sedangkan `setDefaultAsianFont` menentukan font default untuk teks Asia. Setelah opsi-opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan Aspose.Slides for Android melalui Java API:

1. Buat instance dari [LoadOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LoadOptions).
2. [Setel DefaultRegularFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.
3. [Setel DefaultAsianFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ke font yang Anda inginkan. Saya menggunakan Wingdings dalam contoh berikut.
4. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.
5. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

```java
// Gunakan opsi pemuatan untuk menentukan font reguler dan Asia default
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Buat thumbnail slide
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // simpan gambar ke disk.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Buat PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Buat XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini termasuk thumbnail slide, [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/id/androidjava/convert-powerpoint-to-xps/), [gambar raster](/slides/id/androidjava/convert-powerpoint-to-png/), [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), dan [SVG](/slides/id/androidjava/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama pada semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering apa pun?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka dan menyimpan presentasi secara langsung tidak mengubah urutan font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengalir ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/androidjava/custom-font/) memperluas katalog keluarga dan glyph yang tersedia untuk mesin. Font default dan aturan [fallback](/slides/id/androidjava/fallback-font/) akan memeriksa sumber-sumber tersebut terlebih dahulu, menghasilkan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default akan memengaruhi metrik teks (kerning, advance) dan akibatnya pemenggalan baris serta pembungkusannya?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah pemenggalan baris, pembungkus, serta paginasi selama rendering. Untuk kestabilan tata letak, [sematkan font asli](/slides/id/androidjava/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/androidjava/embedded-font/) sudah memastikan tampilan konsisten. Font default masih berguna sebagai jaring pengaman untuk karakter yang tidak tercakup oleh subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.