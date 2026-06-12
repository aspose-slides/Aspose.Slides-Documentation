---
title: Urutan Pemilihan Font di Aspose.Slides untuk .NET
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Temukan cara Aspose.Slides untuk .NET memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam dan konsisten—tingkatkan slide Anda sekarang."
---
## **Gambaran Umum**

Saat sebuah presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang dibutuhkan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan oleh PowerPoint.

Aspose.Slides pertama-tama mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, font pengganti yang cocok diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font yang disematkan dari sebuah presentasi, atau memuat font eksternal untuk dokumen output seperti file PDF.

## **Pemilihan Font**

Aturan tertentu berlaku untuk font dalam sebuah presentasi saat presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dipastikan tidak ada, mereka diganti — lihat [**Font Replacement**](https://docs.aspose.com/slides/id/net/font-replacement/) dan [**Font Substitution**](https://docs.aspose.com/slides/id/net/font-substitution/).

Berikut proses yang diikuti Aspose.Slides saat menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang sesuai dengan font yang dipilih dalam presentasi. 
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan yang akan digunakan oleh PowerPoint.
3. Jika aturan penggantian font telah diatur melalui [FontSubstRule](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstrule/), aturan tersebut diterapkan. 

Aspose.Slides memungkinkan Anda menambahkan font ke runtime aplikasi dan kemudian menggunakan font tersebut. Lihat [**Custom fonts**](https://docs.aspose.com/slides/id/net/custom-font/). 

Ketika font tambahan ditempatkan di dalam sebuah presentasi, mereka disebut [**Embedded fonts**](https://docs.aspose.com/slides/id/net/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan hanya pada dokumen output. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font yang disematkan, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, tetapi Anda melakukannya dengan font sesuai kebijaksanaan dan tanggung jawab Anda.
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [embed](/slides/id/net/embedded-font/), [replace](/slides/id/net/font-replacement/), atau menambahkan [external sources](/slides/id/net/custom-font/). Hal ini membantu Anda mencegah substitusi yang tidak diinginkan selama rendering dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [external font sources](/slides/id/net/custom-font/) seperti folder atau aliran memori (in‑memory) untuk rendering dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana saya mencegah fallback diam-diam ke font yang tidak cocok ketika sebuah glyph tidak tersedia?**

Definisikan secara eksplisit [font replacement](/slides/id/net/font-replacement/) dan aturan [fallBack](/slides/id/net/fallback-font/) font sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkendali untuk substitusi, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.