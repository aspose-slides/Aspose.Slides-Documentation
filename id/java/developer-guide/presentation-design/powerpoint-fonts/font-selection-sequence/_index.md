---
title: Urutan Pemilihan Font di Aspose.Slides untuk Java
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk Java memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam serta konsisten—perbaiki slide Anda sekarang."
---
## **Gambaran Umum**

Ketika presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.

Aspose.Slides pertama-tama mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, pengganti yang sesuai diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font tersemat dari presentasi, atau memuat font eksternal untuk dokumen output seperti file PDF.

## **Pemilihan Font**

Aturan tertentu berlaku untuk font dalam presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) ke gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dipastikan tidak ada, mereka diganti — lihat [**Font Replacement**](https://docs.aspose.com/slides/id/java/font-replacement/) dan [**Font Substitution**](https://docs.aspose.com/slides/id/java/font-substitution/).

Berikut proses yang diikuti Aspose.Slides saat menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi. 
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.
3. Jika aturan penggantian font telah ditetapkan melalui [FontSubstRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstrule/), aturan tersebut diterapkan. 

Aspose.Slides memungkinkan Anda menambahkan font pada runtime aplikasi dan kemudian menggunakan font tersebut. Lihat [**Custom fonts**](https://docs.aspose.com/slides/id/java/custom-font/). 

Ketika font tambahan ditempatkan dalam sebuah presentasi, mereka disebut [**Embedded fonts**](https://docs.aspose.com/slides/id/java/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen output. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font tersemat, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **external fonts**. 

{{% alert title="Note" color="info" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, namun Anda melakukannya dengan font atas kebijaksanaan dan tanggung jawab Anda.
{{% /alert %}}

## **FAQ**

### Bagaimana cara saya menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [embed](/slides/id/java/embedded-font/), [replace](/slides/id/java/font-replacement/), atau menambahkan [external sources](/slides/id/java/custom-font/). Ini membantu Anda mencegah substitusi yang tidak diinginkan selama rendering dan ekspor.

### Apakah saya dapat menambahkan direktori font ekstra tanpa menginstalnya di sistem operasi?

Ya. Anda dapat mendaftarkan [external font sources](/slides/id/java/custom-font/) seperti folder atau aliran memori untuk rendering dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

### Bagaimana saya mencegah fallback diam-diam ke font yang tidak cocok ketika sebuah glyph tidak ada?

Tentukan [font replacement](/slides/id/java/font-replacement/) dan aturan [fallback font](/slides/id/java/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkendali untuk pengganti, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.