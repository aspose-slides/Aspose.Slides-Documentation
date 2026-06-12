---
title: Kelola Callout dalam Grafik Presentasi Menggunakan C++
linktitle: Callout
type: docs
url: /id/cpp/callout/
keywords:
- callout diagram
- menggunakan callout
- label data
- format label
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat dan gaya callout dalam Aspose.Slides untuk C++ dengan contoh kode singkat, kompatibel dengan PPT dan PPTX untuk mengotomatiskan alur kerja presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data grafik di Aspose.Slides. Artikel ini menunjukkan cara menggunakan metode `set_ShowLabelAsDataCallout` untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label yang terkait dengan callout untuk grafik donat, serta mencatat bahwa callout dan tampilannya dipertahankan ketika presentasi diekspor ke PDF, HTML5, SVG, dan format gambar raster.

## **Menggunakan Callout**
Properti baru **ShowLabelAsDataCallout** telah ditambahkan ke kelas **DataLabelFormat** dan antarmuka **IDataLabelFormat**, yang menentukan apakah label data grafik yang ditentukan akan ditampilkan sebagai callout data atau sebagai label data. Pada contoh di bawah ini, kami telah mengatur Callout.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Atur Callout untuk Diagram Donat**
Aspose.Slides untuk C++ menyediakan dukungan untuk mengatur bentuk callout label data seri untuk diagram Donat. Contoh sampel berikut diberikan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari proses rendering grafik, jadi ketika Anda mengekspor ke [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/id/cpp/export-to-html5/), [SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/), atau [raster images](/slides/id/cpp/convert-powerpoint-to-png/), mereka dipertahankan bersama dengan pemformatan slide.

**Apakah font khusus berfungsi dalam callout, dan apakah tampilannya dapat dipertahankan saat ekspor?**

Ya. Aspose.Slides mendukung [embedding fonts](/slides/id/cpp/embedded-font/) ke dalam presentasi dan mengontrol penyematan font selama ekspor seperti [PDF](/slides/id/cpp/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.