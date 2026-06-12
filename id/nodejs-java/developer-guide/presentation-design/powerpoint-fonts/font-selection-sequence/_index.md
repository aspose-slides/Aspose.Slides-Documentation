---
title: Urutan Pemilihan Font di Aspose.Slides untuk Node.js via Java
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/nodejs-java/font-selection-sequence/
keywords:
- pemilihan font
- substitusi font
- penggantian font
- aturan substitusi
- font tersedia
- font tidak ada
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Node.js via Java memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam dan konsisten—perbaiki slide Anda sekarang."
---
## **Gambaran Umum**

Ketika presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.

Aspose.Slides pertama-tama mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, font pengganti yang cocok diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada waktu menjalankan aplikasi, menggunakan font yang disematkan dari presentasi, atau memuat font eksternal untuk dokumen keluaran seperti file PDF.

## **Pemilihan Font**

Beberapa aturan berlaku untuk font dalam presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font tersebut dipastikan tidak ada, mereka akan diganti — lihat [**Font Replacement**](https://docs.aspose.com/slides/id/nodejs-java/font-replacement/) dan [**Font Substitution**](https://docs.aspose.com/slides/id/nodejs-java/font-substitution/).

Ini adalah proses yang diikuti Aspose.Slides saat menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi. 
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.
3. Jika aturan penggantian font telah disetel melalui [FontSubstRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstrule/), aturan tersebut diterapkan.

Aspose.Slides memungkinkan Anda menambahkan font pada waktu menjalankan aplikasi dan kemudian menggunakan font tersebut. Lihat [**Custom fonts**](https://docs.aspose.com/slides/id/nodejs-java/custom-font/).

Ketika font tambahan ditempatkan dalam sebuah presentasi, mereka disebut [**Embedded fonts**](https://docs.aspose.com/slides/id/nodejs-java/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen keluaran. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font yang disematkan, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, tetapi Anda melakukannya dengan font sesuai kebijaksanaan dan tanggung jawab Anda.
{{% /alert %}}

## **Tanya Jawab**

**Bagaimana saya dapat menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getfontsmanager/), sehingga Anda dapat memutuskan apakah akan [embed](/slides/id/nodejs-java/embedded-font/), [replace](/slides/id/nodejs-java/font-replacement/), atau menambahkan [external sources](/slides/id/nodejs-java/custom-font/). Ini membantu Anda mencegah substitusi yang tidak diinginkan selama rendering dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [external font sources](/slides/id/nodejs-java/custom-font/) seperti folder atau aliran memori untuk rendering dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana cara mencegah fallback diam secara otomatis ke font yang tidak cocok ketika sebuah glyph tidak ada?**

Tentukan [font replacement](/slides/id/nodejs-java/font-replacement/) dan aturan [fallBack rules](/slides/id/nodejs-java/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkendali untuk substitusi, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.