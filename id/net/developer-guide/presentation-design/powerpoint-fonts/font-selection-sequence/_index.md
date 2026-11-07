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
description: "Temukan bagaimana Aspose.Slides untuk .NET memilih font, memastikan tampilan PPT, PPTX, dan ODP yang tajam serta konsisten—perbaiki slide Anda sekarang."
---
## **Gambaran Umum**

Saat presentasi dimuat, dirender, atau dikonversi ke format lain, Aspose.Slides mempertimbangkan font yang tersemat dan font yang tersedia bagi aplikasi. Jika font yang dibutuhkan tidak tersedia, Aspose.Slides memilih font pengganti yang sedekat mungkin dengan yang akan digunakan PowerPoint.

Font yang tersedia dapat mencakup font sistem, font yang dimuat oleh aplikasi, dan font yang tersemat dalam presentasi. Untuk font tersemat dan terdaftar yang cocok, preferensi .NET 26.11 yang dijelaskan di bawah mengatur mana yang memiliki prioritas. Aturan substitusi font yang didefinisikan melalui [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) adalah mekanisme terpisah.

Anda juga dapat menambahkan font pada runtime aplikasi, menggunakan font tersemat dari presentasi, atau memuat font eksternal untuk dokumen output seperti file PDF.

## **Pemilihan Font**

Teks dapat merujuk ke font tema, seperti `+mn-lt`, bukan nama keluarga font yang eksplisit. Lihat [Menyelesaikan Referensi Font Tema](/slides/id/net/presentation-theme/#resolve-theme-font-references) untuk mendapatkan keluarga font yang ditentukan oleh tema yang berlaku. Menyelesaikan referensi tersebut terpisah dari memeriksa ketersediaan font dan menerapkan substitusi pada waktu render atau fallback glyph; hal ini tidak mengidentifikasi file font yang pada akhirnya digunakan untuk merender teks.

Saat merender slide atau mengonversi presentasi, periksa bahwa font yang diminta tersemat atau tersedia dari sumber yang terdaftar. Font yang hilang dapat memerlukan penggantian atau substitusi; lihat [**Penggantian Font**](/slides/id/net/font-replacement/) dan [**Substitusi Font**](/slides/id/net/font-substitution/).

Saat menyelidiki pemilihan font:

1. Menentukan keluarga dan gaya yang diminta, termasuk referensi tema apa pun.
2. Memeriksa font tersemat dan sumber terdaftar, termasuk font sistem dan font yang dimuat oleh aplikasi. Gunakan preferensi di bawah ini ketika versi tersemat dan terdaftar yang cocok bersaing.
3. Tinjau [aturan substitusi font](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) dan fallback glyph jika font atau karakter yang diminta tidak tersedia.

Aspose.Slides memungkinkan Anda menambahkan font pada runtime aplikasi dan kemudian menggunakan font tersebut. Lihat [**Font Kustom**](/slides/id/net/custom-font/).

Ketika font tambahan ditempatkan dalam presentasi, mereka disebut [**Font Tersemat**](/slides/id/net/embedded-font/).

Aspose.Slides memungkinkan Anda menambahkan font yang diterapkan *hanya* pada dokumen output. Misalnya, jika sebuah presentasi yang ingin Anda konversi ke PDF berisi font yang tidak ada di sistem Anda dan font tersemat, Anda dapat menambahkan atau memuat font yang dibutuhkan sebagai **font eksternal**. 

{{% alert title="Note" color="info" %}} 
Kami tidak mendistribusikan font apa pun, baik berbayar maupun gratis. API kami memungkinkan Anda memuat font eksternal dan menyematkannya ke dalam dokumen, tetapi Anda melakukannya dengan font atas kebijaksanaan dan tanggung jawab Anda.
{{% /alert %}}

## **Utamakan Font Terdaftar daripada Font Tersemat**

Mulai dari .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) memungkinkan font terdaftar yang cocok mengambil prioritas lebih tinggi daripada font tersemat selama ekspor. Nilai baku adalah `false`. Pencocokan menggunakan nama dan gaya font; nama keluarga yang berbeda bukan merupakan pencocokan pengganti. Font terdaftar dapat berasal dari sistem atau [sumber font yang dimuat secara eksplisit](/slides/id/net/custom-font/).

Contoh berikut menggunakan paket **Aspose.Slides.NET6.CrossPlatform 26.11** pada .NET 8. Ikuti [panduan instalasi](/slides/id/net/installation/) untuk lingkungan Anda. Sediakan `embedded-fonts.pptx` dengan font tersemat dan `preferred.ttf` dengan nama keluarga dan gaya yang sama. Kedua file font harus berbeda secara visual jika Anda ingin membandingkan output.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Pengaturan ini mengubah urutan prioritas font selama ekspor; tidak mengubah nama font teks, menghapus data font tersemat, atau menyematkan kembali file terdaftar. Ini adalah pengaturan runtime: atur lagi setelah membuka kembali presentasi. Jika tidak ada font terdaftar yang cocok, mengaktifkan preferensi ini tidak menyediakan font; verifikasi font dan tata letak yang dihasilkan di lingkungan target Anda.

Output PNG dan PDF dengan font reguler yang dimuat secara eksplisit telah diperiksa untuk konfigurasi di atas. Periksa file font, gaya, build SDK, dan format output Anda sendiri sebelum bergantung pada hasil yang identik. Metri font dapat mengubah jeda baris dan posisi. Gunakan [penggantian font](/slides/id/net/font-replacement/) atau [substitusi](/slides/id/net/font-substitution/) ketika Anda memerlukan keluarga yang berbeda, dan [operasi font tersemat](/slides/id/net/embedded-font/) ketika Anda perlu mengubah font yang disimpan dalam presentasi.

## **Tanya Jawab**

**Bagaimana saya dapat menentukan font mana yang sebenarnya digunakan dalam sebuah presentasi sebelum konversi?**

Aspose.Slides memungkinkan Anda memeriksa font yang digunakan melalui [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), sehingga Anda dapat memutuskan apakah akan [menyematkan](/slides/id/net/embedded-font/), [mengganti](/slides/id/net/font-replacement/), atau menambahkan [sumber eksternal](/slides/id/net/custom-font/). Hal ini membantu Anda mencegah substitusi yang tidak diinginkan selama render dan ekspor.

**Apakah saya dapat menambahkan direktori font tambahan tanpa menginstalnya di sistem operasi?**

Ya. Anda dapat mendaftarkan [sumber font eksternal](/slides/id/net/custom-font/) seperti folder atau aliran memori untuk render dan ekspor. Ini menghilangkan ketergantungan pada font sistem host dan menjaga tata letak tetap dapat diprediksi.

**Bagaimana saya mencegah fallback diam-diam ke font yang tidak cocok ketika sebuah glyph tidak tersedia?**

Tentukan [penggantian font](/slides/id/net/font-replacement/) dan [aturan fallback font](/slides/id/net/fallback-font/) secara eksplisit sebelumnya. Dengan menganalisis font yang digunakan dan menetapkan prioritas terkontrol untuk pengganti, Anda memastikan tipografi yang konsisten dan menghindari hasil yang tidak terduga.