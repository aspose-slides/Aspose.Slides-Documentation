---
title: Urutan Pemilihan Font di Aspose.Slides untuk PHP
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/php-java/font-selection-sequence/
keywords:
- pemilihan font
- substitusi font
- penggantian font
- aturan substitusi
- font tersedia
- font yang hilang
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk PHP via Java memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam dan konsisten — tingkatkan slide Anda sekarang."
---
## **Ikhtisar**

Ketika sebuah presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.

Aspose.Slides pertama‑tama mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, font pengganti yang sesuai diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font yang disematkan dari sebuah presentasi, atau memuat font eksternal untuk dokumen keluaran seperti file PDF.

## **Pemilihan Font**

Aturan tertentu berlaku untuk font dalam sebuah presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dipastikan tidak ada, font tersebut diganti—lihat [**Font Replacement**](https://docs.aspose.com/slides/id/php-java/font-replacement/) dan [**Font Substitution**](https://docs.aspose.com/slides/id/php-java/font-substitution/).

Berikut proses yang diikuti Aspose.Slides dalam menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi.  
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan apa yang akan digunakan PowerPoint.  
3. Jika aturan penggantian font telah disetel melalui [FontSubstRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstrule/), aturan tersebut diterapkan.

Aspose.Slides memungkinkan Anda menambahkan font ke runtime Aspose dan kemudian menggunakan font tersebut. Lihat [**Custom fonts**](https://docs.aspose.com/slides/id/php-java/custom-font/).

Ketika font tambahan ditempatkan dalam sebuah presentasi, font tersebut disebut [**Embedded fonts**](https://docs.aspose.com/slides/id/php-java/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan **hanya** pada dokumen keluaran. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font yang disematkan, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **External fonts**.

## **Tanya Jawab**

**Bagaimana cara menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [embed](/slides/id/php-java/embedded-font/), [replace](/slides/id/php-java/font-replacement/), atau menambahkan [external sources](/slides/id/php-java/custom-font/). Ini membantu mencegah substitusi yang tidak diinginkan selama rendering dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [external font sources](/slides/id/php-java/custom-font/) seperti folder atau aliran memori untuk rendering dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana cara mencegah fallback diam‑diam ke font yang tidak cocok ketika sebuah glyph tidak ada?**

Tentukan [font replacement](/slides/id/php-java/font-replacement/) dan [fallback rules](/slides/id/php-java/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkendali untuk substitusi, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tak terduga.