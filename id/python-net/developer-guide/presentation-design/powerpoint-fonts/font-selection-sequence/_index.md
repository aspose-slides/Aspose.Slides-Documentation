---
title: Urutan Pemilihan Font di Aspose.Slides untuk Python
linktitle: Pemilihan Font
type: docs
weight: 80
url: /id/python-net/font-selection-sequence/
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
- Aspose.Slides
description: "Temukan cara Aspose.Slides untuk Python melalui .NET memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam serta konsisten—tingkatkan slide Anda sekarang."
---
## **Ikhtisar**

Ketika sebuah presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides memeriksa apakah font yang digunakan dalam presentasi tersedia di sistem operasi. Jika font yang diperlukan tidak ada, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan font yang akan digunakan oleh PowerPoint.

Aspose.Slides pertama kali mencari font yang dipilih di sistem operasi. Jika font ditemukan, font tersebut digunakan. Jika tidak ditemukan, font pengganti yang sesuai diterapkan. Ketika aturan substitusi font didefinisikan melalui `FontSubstRule`, aturan tersebut juga dipertimbangkan.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font yang disematkan dari presentasi, atau memuat font eksternal untuk dokumen keluaran seperti file PDF.

## **Pemilihan Font**

Beberapa aturan berlaku untuk font dalam sebuah presentasi ketika presentasi dimuat, dirender, atau dikonversi ke format lain. Misalnya, ketika Anda mencoba mengonversi sebuah presentasi (slide‑nya) menjadi gambar, font presentasi diperiksa untuk memastikan bahwa font yang dipilih tersedia di sistem operasi. Jika font dipastikan tidak ada, mereka diganti — lihat [**Penggantian Font**](https://docs.aspose.com/slides/id/python-net/font-replacement/) dan [**Substitusi Font**](https://docs.aspose.com/slides/id/python-net/font-substitution/).

Berikut proses yang diikuti Aspose.Slides dalam menangani font:

1. Aspose.Slides mencari font di sistem operasi untuk menemukan font yang cocok dengan font yang dipilih dalam presentasi. 
2. Jika font yang dipilih ditemukan, Aspose.Slides menggunakannya. Jika tidak, Aspose.Slides menggunakan font pengganti yang sedekat mungkin dengan apa yang akan digunakan oleh PowerPoint.
3. Jika aturan penggantian font telah ditetapkan melalui [FontSubstRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstrule/), aturan tersebut diterapkan. 

Aspose.Slides memungkinkan Anda menambahkan font ke runtime aplikasi dan kemudian menggunakan font tersebut. Lihat [**Font Kustom**](https://docs.aspose.com/slides/id/python-net/custom-font/). 

Ketika font tambahan ditempatkan dalam sebuah presentasi, mereka disebut [**Font Tertanam**](https://docs.aspose.com/slides/id/python-net/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen keluaran. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font tertanam, Anda dapat menambahkan atau memuat font yang diperlukan sebagai **font eksternal**. 

{{% alert title="Note" color="primary" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya dalam dokumen, tetapi Anda melakukannya dengan font atas kebijakan dan tanggung jawab Anda.
{{% /alert %}}

## **Tanya Jawab**

**Bagaimana saya dapat menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/fonts_manager/), sehingga Anda dapat memutuskan apakah akan [menyematkan](/slides/id/python-net/embedded-font/), [mengganti](/slides/id/python-net/font-replacement/), atau menambahkan [sumber eksternal](/slides/id/python-net/custom-font/). Ini membantu Anda mencegah substitusi yang tidak diinginkan selama rendering dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [sumber font eksternal](/slides/id/python-net/custom-font/) seperti folder atau stream dalam memori untuk rendering dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana saya mencegah fallback diam-diam ke font yang tidak cocok ketika sebuah glyph tidak ada?**

Tentukan [penggantian font](/slides/id/python-net/font-replacement/) dan [aturan fallback font](/slides/id/python-net/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan mengatur prioritas terkendali untuk pengganti, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tak terduga.