---
title: Membuat Diagram Menggunakan VSTO dan Aspose.Slides untuk Java
linktitle: Buat Diagram
type: docs
weight: 70
url: /id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- buat diagram
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara mengotomatiskan pembuatan diagram PowerPoint di Java. Panduan langkah demi langkah ini menunjukkan mengapa Aspose.Slides untuk Java adalah alternatif yang lebih cepat dan lebih kuat dibanding Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

Diagram adalah representasi visual data yang banyak digunakan dalam presentasi. Artikel ini menampilkan kode untuk membuat diagram di Microsoft PowerPoint secara programatis dengan menggunakan [VSTO](/slides/id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) dan [Aspose.Slides for Java](/slides/id/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Membuat Diagram**
Contoh kode di bawah menjelaskan proses menambahkan diagram kolom terkelompok 3D sederhana menggunakan VSTO. Anda membuat instance presentasi, menambahkan diagram default ke dalamnya. Kemudian gunakan workbook Microsoft Excel untuk mengakses dan memodifikasi data diagram serta mengatur properti diagram. Akhirnya, simpan presentasi.

### **Contoh VSTO**
Dengan menggunakan VSTO, langkah-langkah berikut dilakukan:

1. Buat sebuah instance dari presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan diagram **3D clustered column** dan akses diagram tersebut.
1. Buat sebuah instance Microsoft Excel Workbook baru dan muat data diagram.
1. Akses lembar kerja data diagram menggunakan Microsoft Excel Workbook instancefromworkbook.
1. Atur rentang diagram di lembar kerja dan hapus seri 2 serta 3 dari diagram.
1. Modifikasi data kategori diagram di lembar kerja data diagram.
1. Modifikasi data seri 1 diagram di lembar kerja data diagram.
1. Sekarang, akses judul diagram dan setthefontrelatedproperties.
1. Akses sumbu nilai diagram dan atur unit mayor, unit minor, nilai maksimum dan nilai minimum.
1. Akses kedalaman diagram atau sumbu seri dan hapus itu karena dalam contoh ini, onlyoneserieisused.
1. Sekarang, atur sudut rotasi diagram pada arah X dan Y.
1. Simpan presentasi.
1. Tutup instance Microsoft Excel dan PowerPoint.

**Presentasi keluaran, yang dibuat dengan VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Contoh Aspose.Slides for Java**
Dengan menggunakan Aspose.Slides for Java, langkah-langkah berikut dilakukan:

1. Buat sebuah instance dari presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan diagram **3D clustered column** dan akses diagram tersebut.
1. Akses lembar kerja data diagram menggunakan Microsoft Excel Workbook instancefromworkbook.
1. Hapus seri 2 dan 3 yang tidak digunakan.
1. Akses kategori diagram dan ubah label.
1. Accesseries1 dan ubah nilai seri.
1. Sekarang, akses judul diagram dan atur properti font.
1. Akses sumbu nilai diagram dan atur unit mayor, unit minor, nilai maksimum dan nilai minimum.
1. Sekarang, atur sudut rotasi diagram pada arah X dan Y.
1. Simpan presentasi ke format PPTX.

**Presentasi keluaran, yang dibuat dengan Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Apakah saya dapat membuat jenis diagram lain seperti diagram pai, garis, atau batang dengan Aspose.Slides?

Ya. Aspose.Slides mendukung berbagai [chart types](/slides/id/java/create-chart/), termasuk diagram pai, diagram garis, diagram batang, plot sebar, diagram gelembung, dan lainnya. Anda dapat menentukan jenis diagram yang diinginkan menggunakan kelas [ChartType](https://reference.aspose.com/slides/id/java/com.aspose.slides/charttype/) saat menambahkan diagram.

### Dapatkah saya menerapkan gaya atau tema khusus pada diagram?

Ya. Anda dapat menyesuaikan tampilan diagram secara penuh, termasuk warna, font, isi, kontur, garis kisi, dan tata letak. Namun, menerapkan tema Office persis seperti yang terlihat di PowerPoint memerlukan pengaturan gaya secara manual.

### Dapatkah saya mengekspor diagram sebagai gambar terpisah dari slide?

Ya, Aspose.Slides memungkinkan Anda mengekspor bentuk apa pun—termasuk diagram—sebagai gambar terpisah (mis., PNG, JPEG) menggunakan metode `getImage` pada [shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/).