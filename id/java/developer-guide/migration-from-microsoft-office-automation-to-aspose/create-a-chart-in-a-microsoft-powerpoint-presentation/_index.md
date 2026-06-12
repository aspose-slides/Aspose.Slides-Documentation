---
title: Membuat Chart Menggunakan VSTO dan Aspose.Slides untuk Java
linktitle: Buat Chart
type: docs
weight: 70
url: /id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- buat chart
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengotomatisasi pembuatan chart PowerPoint dalam Java. Panduan langkah demi langkah ini menunjukkan mengapa Aspose.Slides untuk Java adalah alternatif yang lebih cepat dan lebih kuat dibandingkan Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

Chart adalah representasi visual data yang banyak digunakan dalam presentasi. Artikel ini menunjukkan kode untuk membuat chart di Microsoft PowerPoint secara programatik dengan menggunakan [VSTO](/slides/id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) dan [Aspose.Slides for Java](/slides/id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Membuat Chart**
Contoh kode di bawah ini menjelaskan proses penambahan chart kolom terklaster 3D sederhana menggunakan VSTO. Anda membuat instance presentasi, menambahkan chart default ke dalamnya. Kemudian menggunakan workbook Microsoft Excel untuk mengakses dan memodifikasi data chart bersama dengan mengatur properti chart. Akhirnya, menyimpan presentasi.
### **Contoh VSTO**
Dengan menggunakan VSTO, langkah-langkah berikut dilakukan:

1. Buat sebuah instance presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan chart **3D clustered column** dan akses chart tersebut.
1. Buat instance Microsoft Excel Workbook baru dan muat data chart.
1. Akses worksheet data chart menggunakan instance Microsoft Excel Workbook instancefromworkbook.
1. Atur rentang chart di worksheet dan hapus seri 2 dan 3 dari chart.
1. Modifikasi data kategori chart di worksheet data chart.
1. Modifikasi data seri 1 chart di worksheet data chart.
1. Sekarang, akses judul chart dan atur properti font terkait.
1. Akses sumbu nilai chart dan atur unit utama, unit minor, nilai maksimum, dan nilai minimum.
1. Akses kedalaman chart atau sumbu seri dan hapus karena dalam contoh ini hanya satu seri yang digunakan.
1. Sekarang, atur sudut rotasi chart pada arah X dan Y.
1. Simpan presentasi.
1. Tutup instance Microsoft Excel dan PowerPoint.

**Presentasi output, dibuat dengan VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Contoh Aspose.Slides for Java**
Dengan menggunakan Aspose.Slides for Java, langkah-langkah berikut dilakukan:

1. Buat sebuah instance presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan chart **3D clustered column** dan akses chart tersebut.
1. Akses worksheet data chart menggunakan instance Microsoft Excel Workbook instancefromworkbook.
1. Hapus seri 2 dan 3 yang tidak digunakan.
1. Akses kategori chart dan modifikasi label.
1. Akses seri 1 dan modifikasi nilai seri.
1. Sekarang, akses judul chart dan atur properti font.
1. Akses sumbu nilai chart dan atur unit utama, unit minor, nilai maksimum, dan nilai minimum.
1. Sekarang, atur sudut rotasi chart pada arah X dan Y.
1. Simpan presentasi ke format PPTX.

**Presentasi output, dibuat dengan Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Apakah saya dapat membuat jenis chart lain seperti pie, line, atau bar chart dengan Aspose.Slides?**

Ya. Aspose.Slides mendukung berbagai [jenis chart](/slides/id/java/create-chart/), termasuk pie chart, line chart, bar chart, scatter plot, bubble chart, dan lainnya. Anda dapat menentukan jenis chart yang diinginkan menggunakan kelas [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) saat menambahkan chart.

**Apakah saya dapat menerapkan gaya atau tema khusus pada chart?**

Ya. Anda dapat sepenuhnya menyesuaikan tampilan chart, termasuk warna, font, isi, garis tepi, garis kisi, dan tata letak. Namun, menerapkan tema Office persis seperti yang terlihat di PowerPoint memerlukan pengaturan masing‑masing secara manual.

**Apakah saya dapat mengekspor chart sebagai gambar terpisah dari slide?**

Ya, Aspose.Slides memungkinkan Anda mengekspor shape apa pun—termasuk chart—sebagai gambar terpisah (misalnya PNG, JPEG) dengan menggunakan metode `getImage` pada [shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/) chart.