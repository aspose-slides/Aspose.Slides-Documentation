---
title: Menentukan Font Default Presentasi di C++
linktitle: Font Default
type: docs
weight: 30
url: /id/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk C++ agar konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) ke PDF, XPS, dan gambar berjalan dengan baik."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Ini berguna saat membuat thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Metode `set_DefaultRegularFont` menentukan font default untuk teks biasa, sementara `set_DefaultAsianFont` menentukan font default untuk teks Asia. Setelah opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang telah ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal menggunakan API Aspose.Slides untuk C++:

1. Buat instance LoadOptions.  
1. Atur DefaultRegularFont ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.  
1. Atur DefaultAsianFont ke font yang Anda inginkan. Saya menggunakan Wingdings pada contoh berikut.  
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.  
1. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.  

Implementasi di atas diberikan di bawah.

```cpp
// Gunakan opsi pemuatan untuk menentukan font default reguler dan Asia
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh DefaultRegularFont dan DefaultAsianFont—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini termasuk thumbnail slide, [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/id/cpp/convert-powerpoint-to-xps/), [gambar raster](/slides/id/cpp/convert-powerpoint-to-png/), [HTML](/slides/id/cpp/convert-powerpoint-to-html/), dan [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glif yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering apa pun?**

Tidak. Font default berpengaruh ketika teks harus diukur dan digambar. Membuka‑menyimpan langsung sebuah presentasi tidak mengubah rentang font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengatur kembali teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Custom font sources](/slides/id/cpp/custom-font/) memperluas katalog keluarga dan glif yang tersedia yang dapat digunakan mesin. Font default dan setiap [fallback rules](/slides/id/cpp/fallback-font/) akan diresolusikan terhadap sumber tersebut terlebih dahulu, memberikan cakupan yang lebih dapat diandalkan pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advances) dan dengan demikian pemotongan baris serta pembungkusannya?**

Ya. Mengubah font mengubah metrik glif dan dapat mengubah pemotongan baris, pembungkus, serta paginasi selama rendering. Untuk stabilitas tata letak, [embed the original fonts](/slides/id/cpp/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah ter-embed?**

Seringkali tidak diperlukan, karena [embedded fonts](/slides/id/cpp/embedded-font/) sudah memastikan tampilan konsisten. Font default tetap membantu sebagai jaringan pengaman untuk karakter yang tidak tercakup oleh subset yang ter-embed atau ketika sebuah file mencampur teks ter-embed dan tidak ter-embed.