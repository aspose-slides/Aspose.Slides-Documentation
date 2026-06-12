---
title: Tentukan Font Default Presentasi di С++
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
- С++
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk С++ guna memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) yang tepat ke PDF, XPS, dan gambar."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Ini berguna saat membuat thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Metode `set_DefaultRegularFont` mendefinisikan font default untuk teks biasa, sementara `set_DefaultAsianFont` mendefinisikan font default untuk teks Asia. Setelah opsi-opsi ini ditetapkan, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegularFont dan DefaultAsianFont untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan API Aspose.Slides untuk C++:

1. Buat instance LoadOptions.  
1. Setel DefaultRegularFont ke font yang diinginkan. Pada contoh berikut, saya menggunakan Wingdings.  
1. Setel DefaultAsianFont ke font yang diinginkan. Saya menggunakan Wingdings dalam contoh berikut.  
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.  
1. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.  

Implementasi di atas diberikan di bawah ini.

```cpp
// Gunakan opsi pemuatan untuk menentukan font reguler dan Asian default
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

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/id/cpp/convert-powerpoint-to-xps/), [gambar raster](/slides/id/cpp/convert-powerpoint-to-png/), [HTML](/slides/id/cpp/convert-powerpoint-to-html/), dan [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering apa pun?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka dan menyimpan kembali sebuah presentasi secara langsung tidak mengubah rentang font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengatur ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font khusus](/slides/id/cpp/custom-font/) memperluas katalog keluarga dan glyph yang tersedia yang dapat digunakan mesin. Font default dan setiap [aturan fallback](/slides/id/cpp/fallback-font/) akan menyelesaikan terhadap sumber tersebut terlebih dahulu, memberikan cakupan yang lebih andal pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advances) dan dengan demikian jeda baris serta pembungkusan?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah jeda baris, pembungkusan, serta paginasi selama rendering. Untuk stabilitas tata letak, [sematkan font asli](/slides/id/cpp/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/cpp/embedded-font/) sudah memastikan tampilan yang konsisten. Font default tetap berguna sebagai jaring pengaman untuk karakter yang tidak tercakup dalam subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.