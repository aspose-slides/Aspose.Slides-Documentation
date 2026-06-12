---
title: Kustomisasi Font Default dalam Presentasi dengan Python
linktitle: Font Default
type: docs
weight: 30
url: /id/python-net/default-font/
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
- Python
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk Python guna memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) ke PDF, XPS, dan gambar yang tepat."
---
## **Overview**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat sebuah presentasi dirender. Hal ini berguna saat membuat thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui `LoadOptions` sebelum presentasi dimuat.

Properti `default_regular_font` menentukan font default untuk teks biasa, sementara `default_asian_font` menentukan font default untuk teks Asia. Setelah opsi-opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Menggunakan Font Default untuk Merender Presentasi**
Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Artikel ini menunjukkan cara mendefinisikan DefaultRegular Font dan DefaultAsian Font untuk digunakan sebagai font default. Silakan ikuti langkah-langkah di bawah ini untuk memuat font dari direktori eksternal dengan menggunakan Aspose.Slides for Python via .NET API:

1. Buat instance LoadOptions.
1. Atur DefaultRegularFont ke font yang Anda inginkan. Pada contoh berikut, saya menggunakan Wingdings.
1. Atur DefaultAsianFont ke font yang Anda inginkan. Saya menggunakan Wingdings dalam contoh berikut.
1. Muat presentasi menggunakan Presentation dan mengatur opsi pemuatan.
1. Sekarang, hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

Implementasi di atas diberikan di bawah ini.

```py
import aspose.slides as slides

# Gunakan opsi pemuatan untuk menentukan font reguler dan Asia default# Gunakan opsi pemuatan untuk menentukan font reguler dan Asia default
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Muat presentasi
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Hasilkan thumbnail slide
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Hasilkan PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Hasilkan XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh default_regular_font dan default_asian_font—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-net/convert-powerpoint-to-xps/), [gambar raster](/slides/id/python-net/convert-powerpoint-to-png/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), dan [SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glyph yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering?**

Tidak. Font default penting ketika teks harus diukur dan digambar. Membuka‑menyimpan langsung sebuah presentasi tidak mengubah urutan font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengatur ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyuplai font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Sumber font kustom](/slides/id/python-net/custom-font/) memperluas katalog keluarga dan glyph yang tersedia bagi mesin. Font default dan setiap [aturan fallback](/slides/id/python-net/fallback-font/) akan dicocokkan dengan sumber tersebut terlebih dahulu, memberikan cakupan yang lebih dapat diandalkan pada server dan kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advances) dan dengan demikian pemotongan baris serta pembungkusan?**

Ya. Mengubah font mengubah metrik glyph dan dapat mengubah pemotongan baris, pembungkusan, serta pagination selama rendering. Untuk stabilitas tata letak, [sematkan font asli](/slides/id/python-net/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya mengatur font default jika semua font yang digunakan dalam presentasi sudah disematkan?**

Seringkali tidak diperlukan, karena [font yang disematkan](/slides/id/python-net/embedded-font/) sudah memastikan tampilan yang konsisten. Font default masih berguna sebagai jaring pengaman untuk karakter yang tidak tercakup oleh subset yang disematkan atau ketika sebuah file mencampur teks yang disematkan dan tidak disematkan.