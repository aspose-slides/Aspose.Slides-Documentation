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
- font hilang
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk .NET memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam dan konsisten—tingkatkan slide Anda sekarang."
---
## **Gambaran Umum**

Ketika sebuah presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan oleh PowerPoint.

Aspose.Slides pertama kali mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, font pengganti yang cocok diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font yang disematkan dari sebuah presentasi, atau memuat font eksternal untuk dokumen keluaran seperti file PDF.

## **Pemilihan Font**

Beberapa aturan berlaku untuk font dalam sebuah presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide-nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dikonfirmasi tidak ada, mereka diganti — lihat [**Penggantian Font**](https://docs.aspose.com/slides/id/net/font-replacement/) dan [**Substitusi Font**](https://docs.aspose.com/slides/id/net/font-substitution/).

Berikut adalah proses yang diikuti Aspose.Slides dalam menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi. 
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan yang akan digunakan oleh PowerPoint.
3. Jika aturan penggantian font telah diatur melalui [FontSubstRule](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstrule/), aturan tersebut diterapkan. 

Aspose.Slides memungkinkan Anda menambahkan font pada runtime aplikasi dan kemudian menggunakan font tersebut. Lihat [**Font Kustom**](https://docs.aspose.com/slides/id/net/custom-font/). 

Ketika font tambahan ditempatkan dalam sebuah presentasi, mereka disebut [**Font Tertanam**](https://docs.aspose.com/slides/id/net/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen keluaran. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font tertanam, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **font eksternal**. 

{{% alert title="Note" color="info" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, namun Anda melakukannya dengan font atas kebijaksanaan dan tanggung jawab Anda.
{{% /alert %}}

## **FAQ**

### Bagaimana saya dapat menentukan font apa yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [menyematkan](/slides/id/net/embedded-font/), [mengganti](/slides/id/net/font-replacement/), atau menambahkan [sumber eksternal](/slides/id/net/custom-font/). Ini membantu Anda mencegah substitusi yang tidak diinginkan selama render dan ekspor.

### Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?

Ya. Anda dapat mendaftarkan [sumber font eksternal](/slides/id/net/custom-font/) seperti folder atau aliran memori untuk render dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

### Bagaimana cara mencegah fallback diam-diam ke font yang tidak cocok saat sebuah glif tidak ada?

Tetapkan secara eksplisit [penggantian font](/slides/id/net/font-replacement/) dan [aturan fallBack font](/slides/id/net/fallback-font/) sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkontrol untuk substitusi, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.