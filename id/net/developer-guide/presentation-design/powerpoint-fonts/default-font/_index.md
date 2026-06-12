---
title: Tentukan Font Default Presentasi di .NET
linktitle: Font Default
type: docs
weight: 30
url: /id/net/default-font/
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
- .NET
- C#
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk .NET guna memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) yang tepat ke PDF, XPS, dan gambar."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Ini berguna saat menghasilkan thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Properti `DefaultRegularFont` mendefinisikan font default untuk teks reguler, sedangkan `DefaultAsianFont` mendefinisikan font default untuk teks Asia. Setelah opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegular Font dan DefaultAsian Font untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan API Aspose.Slides untuk .NET:

1. Buat instance dari LoadOptions.  
2. Atur DefaultRegularFont ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.  
3. Atur DefaultAsianFont ke font yang Anda inginkan. Saya menggunakan Wingdings pada contoh berikut.  
4. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.  
5. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.  

Implementasi dari di atas diberikan di bawah ini.

```c#
// Gunakan opsi load untuk menentukan font reguler default dan font Asia default
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **Pertanyaan yang Sering Diajukan**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/net/convert-powerpoint-to-pdf/), [XPS](/slides/id/net/convert-powerpoint-to-xps/), [gambar raster](/slides/id/net/convert-powerpoint-to-png/), [HTML](/slides/id/net/convert-powerpoint-to-html/), dan [SVG](/slides/id/net/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering apa pun?**

Tidak. Font default relevan ketika teks harus diukur dan digambar. Membuka‑simpan secara langsung sebuah presentasi tidak mengubah urutan font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengalirkan ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/net/custom-font/) memperluas katalog keluarga dan glyph yang tersedia yang dapat digunakan mesin. Font default dan setiap [aturan fallback](/slides/id/net/fallback-font/) akan diresolusi terhadap sumber tersebut terlebih dahulu, menghasilkan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advances) dan dengan demikian pemecahan baris serta pembungkusan?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah pemecahan baris, pembungkusan, dan paginasi selama rendering. Untuk stabilitas tata letak, [sematkan font asli](/slides/id/net/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/net/embedded-font/) sudah memastikan tampilan yang konsisten. Font default tetap berguna sebagai jaringan pengaman untuk karakter yang tidak tercakup oleh subset yang disematkan atau ketika file mencampur teks yang disematkan dan tidak disematkan.