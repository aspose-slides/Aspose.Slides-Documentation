---
title: Buat dan Sematkan Grafik Excel sebagai OLE Objects Menggunakan VSTO dan Aspose.Slides untuk Java
linktitle: Buat dan Sematkan Grafik Excel sebagai OLE Objects
type: docs
weight: 60
url: /id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- buat grafik
- sematkan grafik Excel
- objek OLE
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Migrasi dari otomatisasi Microsoft Office ke Aspose.Slides untuk Java dan sematkan grafik Excel sebagai objek OLE ke dalam slide PowerPoint (PPT, PPTX) dalam Java."
---
{{% alert color="primary" %}} 
Chart adalah representasi visual dari data Anda dan banyak digunakan dalam slide presentasi. Artikel ini akan menunjukkan kode untuk membuat dan menyematkan Grafik Excel sebagai OLE Object di slide PowerPoint secara programatis dengan menggunakan [VSTO](/slides/id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) dan [Aspose.Slides for Java](/slides/id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Membuat dan Menyematkan Grafik Excel**
Dua contoh kode di bawah ini panjang dan terperinci karena tugas yang mereka jelaskan cukup kompleks. Anda membuat workbook Microsoft Excel, membuat grafik, dan kemudian membuat presentasi Microsoft PowerPoint yang akan Anda sematkan grafiknya. OLE object berisi tautan ke dokumen asli sehingga pengguna yang mengklik ganda file yang disematkan akan meluncurkan file tersebut dan aplikasi terkait.
### **Contoh VSTO**
Dengan VSTO, langkah-langkah berikut dilakukan:

1. Buat instance objek Microsoft Excel ApplicationClass.
1. Buat workbook baru dengan satu lembar di dalamnya.
1. Tambahkan grafik ke lembar.
1. Simpan workbook.
1. Buka workbook Excel yang berisi worksheet dengan data grafik.
1. Dapatkan koleksi ChartObjects untuk lembar.
1. Ambil grafik yang akan disalin.
1. Buat presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Salin grafik dari worksheet Excel ke clipboard.
1. Tempel grafik ke dalam presentasi PowerPoint.
1. Posisikan grafik pada slide.
1. Simpan presentasi.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Contoh Aspose.Slides for Java**
Dengan Aspose.Slides untuk .NET, langkah-langkah berikut dilakukan:

1. Buat workbook menggunakan Aspose.Cells untuk Java.
1. Buat grafik Microsoft Excel.
1. Atur ukuran OLE dari Grafik Excel.
1. Dapatkan gambar grafik.
1. Sematkan grafik Excel sebagai OLE Object di dalam presentasi PPTX menggunakan Aspose.Slides untuk Java.
1. Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah objek yang berubah.
1. Tuliskan presentasi output ke disk dalam format PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}