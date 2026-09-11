---
title: Tentukan Font Default Presentasi di Python via Java
linktitle: Font Default
type: docs
weight: 30
url: /id/python-java/default-font/
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
- Java
- Aspose.Slides
description: "Atur font default di Aspose.Slides untuk Python via Java guna memastikan konversi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) yang tepat ke PDF, XPS, dan gambar."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font default yang digunakan saat presentasi dirender. Hal ini berguna saat menghasilkan thumbnail slide atau mengekspor presentasi ke format seperti PDF dan XPS. Font default dikonfigurasi melalui [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/) sebelum presentasi dimuat.

Metode [setDefaultRegularFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) menentukan font default untuk teks reguler, sementara [setDefaultAsianFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) menentukan font default untuk teks Asia. Setelah opsi-opsi ini diatur, presentasi dapat dimuat dan dirender menggunakan font yang ditentukan.

## **Gunakan Font Default untuk Merender Presentasi**

Aspose.Slides memungkinkan Anda mengatur font default untuk merender presentasi ke PDF, XPS, atau thumbnail. Bagian ini menunjukkan cara mendefinisikan font default untuk teks reguler dan Asia menggunakan Aspose.Slides untuk Python via Java:

1. Buat sebuah instance dari [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/).
2. Gunakan [setDefaultRegularFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) untuk menentukan font yang diinginkan. Contoh berikut menggunakan Wingdings.
3. Gunakan [setDefaultAsianFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) untuk menentukan font yang diinginkan. Contoh berikut juga menggunakan Wingdings.
4. Muat presentasi menggunakan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dengan opsi pemuatan.
5. Hasilkan thumbnail slide, PDF, dan XPS untuk memverifikasi hasil.

Contoh berikut mengimplementasikan langkah-langkah ini:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Gunakan opsi muat untuk mendefinisikan font reguler dan font Asia default.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Muat presentasi.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Hasilkan thumbnail slide.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Simpan gambar ke disk.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Hasilkan PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Hasilkan dokumen XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa sebenarnya yang dipengaruhi oleh font default reguler dan Asia—hanya ekspor, atau juga thumbnail, PDF, XPS, HTML, dan SVG?**

Mereka berpartisipasi dalam pipeline rendering untuk semua output yang didukung. Ini mencakup thumbnail slide, [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/id/python-java/convert-powerpoint-to-xps/), [raster images](/slides/id/python-java/convert-powerpoint-to-png/), [HTML](/slides/id/python-java/convert-powerpoint-to-html/), dan [SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/), karena Aspose.Slides menggunakan logika tata letak dan resolusi glif yang sama di semua target tersebut.

**Apakah font default diterapkan saat hanya membaca dan menyimpan PPTX tanpa rendering?**

Tidak. Font default berperan ketika teks harus diukur dan digambar. Membuka‑simpan langsung sebuah presentasi tidak mengubah run font yang disimpan atau struktur file. Font default berperan selama operasi yang merender atau mengalir ulang teks.

**Jika saya menambahkan folder font saya sendiri atau menyediakan font dari memori, apakah mereka akan dipertimbangkan saat memilih font default?**

Ya. [Custom font sources](/slides/id/python-java/custom-font/) memperluas katalog keluarga dan glif yang tersedia yang dapat digunakan mesin. Font default dan setiap [fallback rules](/slides/id/python-java/fallback-font/) akan diselesaikan terhadap sumber tersebut terlebih dahulu, memberikan cakupan yang lebih andal pada server dan dalam kontainer.

**Apakah font default memengaruhi metrik teks (kerning, advances) dan oleh karena itu pemenggalan baris serta pembungkusannya?**

Ya. Mengubah font mengubah metrik glif dan dapat mengubah pemenggalan baris, pembungkus, serta paginasi selama rendering. Untuk stabilitas tata letak, [embed the original fonts](/slides/id/python-java/embedded-font/) atau pilih keluarga default dan fallback yang kompatibel secara metrik.

**Apakah ada gunanya menetapkan font default jika semua font yang digunakan dalam presentasi sudah tersemat?**

Seringkali tidak diperlukan, karena [embedded fonts](/slides/id/python-java/embedded-font/) sudah memastikan tampilan konsisten. Font default tetap membantu sebagai jaringan pengaman untuk karakter yang tidak tercakup oleh subset tersemat atau ketika file mencampur teks tersemat dan tidak tersemat.