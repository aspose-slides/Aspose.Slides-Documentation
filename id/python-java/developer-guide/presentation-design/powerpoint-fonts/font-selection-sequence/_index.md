---
title: Urutan Pemilihan Font di Aspose.Slides untuk Python via Java
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/python-java/font-selection-sequence/
keywords:
- pemilihan font
- substitusi font
- penggantian font
- aturan substitusi
- font tersedia
- font hilang
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Python via Java memilih font, memastikan tampilan PPT, PPTX dan ODP yang tajam dan konsisten—tingkatkan slide Anda sekarang."
---
## **Ikhtisar**

Ketika sebuah presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.

Aspose.Slides pertama mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut akan digunakan. Jika tidak ditemukan, font pengganti yang cocok akan diterapkan. Ketika aturan substitusi font didefinisikan melalui [FontSubstRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstrule/), aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada waktu aplikasi berjalan, menggunakan font yang disematkan dari sebuah presentasi, atau memuat font eksternal untuk dokumen output seperti file PDF.

## **Pemilihan Font**

Beberapa aturan berlaku untuk font dalam sebuah presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dikonfirmasi tidak ada, mereka diganti — lihat [Font Replacement](/slides/id/python-java/font-replacement/) dan [Font Substitution](/slides/id/python-java/font-substitution/).

Berikut proses yang diikuti Aspose.Slides dalam menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi.
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.
3. Jika aturan penggantian font telah ditetapkan melalui [FontSubstRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstrule/), aturan tersebut diterapkan.

Aspose.Slides memungkinkan Anda menambahkan font pada waktu aplikasi berjalan dan kemudian menggunakan font tersebut. Lihat [Custom fonts](/slides/id/python-java/custom-font/).

Ketika font tambahan ditempatkan dalam sebuah presentasi, mereka disebut [Embedded fonts](/slides/id/python-java/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen output. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF menggunakan font yang tidak terpasang di sistem Anda maupun tidak disematkan dalam presentasi, Anda dapat menambahkan atau memuat font yang dibutuhkan sebagai **external fonts**.

{{% alert title="Catatan" color="info" %}}
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, tetapi Anda melakukannya atas kebijaksanaan dan tanggung jawab Anda sendiri.
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [embed](/slides/id/python-java/embedded-font/), [replace](/slides/id/python-java/font-replacement/), atau menambahkan [external sources](/slides/id/python-java/custom-font/). Ini membantu Anda mencegah substitusi yang tidak diinginkan selama render dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa memasangnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [external font sources](/slides/id/python-java/custom-font/) seperti folder atau aliran memori untuk render dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana cara mencegah fallback diam ke font yang tidak cocok ketika sebuah glyph tidak tersedia?**

Tentukan [font replacement](/slides/id/python-java/font-replacement/) dan aturan [fallback font](/slides/id/python-java/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan mengatur prioritas yang terkendali untuk pengganti, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.