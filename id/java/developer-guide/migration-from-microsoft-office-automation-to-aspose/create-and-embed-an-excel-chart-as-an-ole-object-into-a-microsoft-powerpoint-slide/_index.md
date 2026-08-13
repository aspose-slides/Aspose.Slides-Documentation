---
title: Membuat dan Menyematkan Chart Excel sebagai Objek OLE Menggunakan VSTO dan Aspose.Slides untuk Java
linktitle: Membuat dan Menyematkan Chart Excel sebagai Objek OLE
type: docs
weight: 60
url: /id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- buat chart
- sematkan chart Excel
- objek OLE
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Migrasikan dari otomasi Microsoft Office ke Aspose.Slides untuk Java dan sematkan chart Excel sebagai objek OLE ke dalam slide PowerPoint (PPT, PPTX) menggunakan Java."
---
{{% alert color="info" %}} 

 Chart adalah representasi visual dari data Anda dan banyak digunakan dalam slide presentasi. Artikel ini akan menunjukkan kode untuk membuat dan menyematkan Chart Excel sebagai OLE Object dalam Slide PowerPoint secara programatik dengan menggunakan [VSTO](/slides/id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) dan [Aspose.Slides for Java](/slides/id/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Membuat dan Menyematkan Chart Excel**
Dua contoh kode di bawah ini panjang dan terperinci karena tugas yang mereka jelaskan cukup kompleks. Anda membuat workbook Microsoft Excel, membuat chart, lalu membuat presentasi Microsoft PowerPoint yang akan Anda sematkan chart tersebut. OLE object berisi tautan ke dokumen asli sehingga pengguna yang mengklik dua kali file yang disematkan akan meluncurkan file dan aplikasinya.
### **Contoh VSTO**
Menggunakan VSTO, langkah-langkah berikut dilakukan:

1. Buat instance objek Microsoft Excel ApplicationClass.
1. Buat workbook baru dengan satu lembar di dalamnya.
1. Tambahkan chart ke lembar.
1. Simpan workbook.
1. Buka workbook Excel yang berisi worksheet dengan data chart.
1. Dapatkan koleksi ChartObjects untuk lembar.
1. Dapatkan chart yang akan disalin.
1. Buat presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Salin chart dari worksheet Excel ke clipboard.
1. Tempel chart ke dalam presentasi PowerPoint.
1. Posisikan chart pada slide.
1. Simpan presentasi.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Contoh Aspose.Slides untuk Java**
Menggunakan Aspose.Slides untuk .NET, langkah-langkah berikut dilakukan:

1. Buat workbook menggunakan Aspose.Cells untuk Java.
1. Buat chart Microsoft Excel.
1. Atur ukuran OLE dari Chart Excel.
1. Dapatkan gambar chart.
1. Sematkan chart Excel sebagai OLE Object di dalam presentasi PPTX menggunakan Aspose.Slides untuk Java.
1. Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk menangani masalah perubahan objek.
1. Tulis presentasi output ke disk dalam format PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}