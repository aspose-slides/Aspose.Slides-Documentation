---
title: "Kelola Buku Kerja Grafik dalam Presentasi Menggunakan Java"
linktitle: "Buku Kerja Grafik"
type: docs
weight: 70
url: /id/java/chart-workbook/
keywords:
- buku kerja grafik
- data grafik
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache grafik
- pemulihan buku kerja
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Java: kelola buku kerja grafik dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data grafik, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai grafik.

Artikel ini juga membahas penggunaan buku kerja eksternal sebagai sumber data grafik. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil path buku kerja eksternal yang terhubung ke grafik, dan mengedit data grafik saat buku kerja tersedia.

## **Baca dan Tulis Data Grafik dari Buku Kerja**
Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#readWorkbookStream--) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis buku kerja data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau memiliki struktur mirip dengan sumbernya.

Kode Java ini memperlihatkan contoh operasi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Validasi Tata Letak Grafik Setelah Modifikasi Buku Kerja**

Ketika Anda mengganti buku kerja yang tertanam dengan yang telah dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidakkonsistenan ini dapat menyebabkan metode [IChart.validateChartLayout](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#validateChartLayout--) melempar `ArgumentOutOfRangeException` (parameter: index). Untuk menghindari pengecualian, bersihkan seri dan kategori yang ada **sebelum** menulis ulang buku kerja yang diperbarui ke grafik.

```java
// Setelah memodifikasi aliran workbook (mis., menggunakan Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Hapus referensi data yang ada.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Membersihkan koleksi memastikan struktur data grafik selaras dengan buku kerja baru, sehingga `validateChartLayout` dapat selesai tanpa error.

## **Tetapkan Sel Buku Kerja sebagai Label Data Grafik**

1. Buat instance kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan grafik Bubble dengan beberapa data.
1. Akses seri grafik.
1. Tetapkan sel buku kerja sebagai label data.
1. Simpan presentasi.

Kode Java ini menunjukkan cara menetapkan sel buku kerja sebagai label data grafik:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Membuat instance kelas presentasi yang mewakili file presentasi
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kelola Lembar Kerja**

Kode Java ini memperlihatkan operasi di mana metode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi lembar kerja:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tentukan Jenis Sumber Data**

Kode Java ini menunjukkan cara menentukan jenis untuk sumber data:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Deteksi Format Buku Kerja Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tertanam dalam beberapa grafik. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/java/com.aspose.slides/WorkbookType) untuk mendeteksi format yang tidak didukung dan melewati grafik tersebut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Workbook yang tertanam berformat .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data buku kerja grafik di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Buku Kerja Eksternal**

{{% alert color="info" %}} 
Di [Aspose.Slides 19.4](https://docs.aspose.com/slides/id/java/aspose-slides-for-java-19-4-release-notes/), kami menambahkan dukungan untuk buku kerja eksternal sebagai sumber data bagi grafik.
{{% /alert %}} 

### **Buat Buku Kerja Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat buku kerja eksternal dari awal atau menjadikan buku kerja internal menjadi eksternal.

Kode Java ini memperlihatkan proses pembuatan buku kerja eksternal:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tetapkan Buku Kerja Eksternal**

Dengan metode **`setExternalWorkbook`**, Anda dapat menetapkan buku kerja eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui path ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data di buku kerja yang disimpan di lokasi atau sumber daya jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika path relatif untuk buku kerja eksternal diberikan, path tersebut akan otomatis dikonversi menjadi path lengkap.

Kode Java ini menunjukkan cara menetapkan buku kerja eksternal:

```java
import com.aspose.slides.*;

// Membuat instance dari kelas Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Parameter kedua (`boolean`) dari metode `setExternalWorkbook` digunakan untuk menentukan apakah buku kerja Excel akan dimuat atau tidak. 

* Jika nilainya `false`, hanya path buku kerja yang diperbarui—data grafik tidak akan dimuat atau diperbarui dari buku kerja target. Gunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia. 
* Jika nilainya `true`, data grafik akan diperbarui dari buku kerja target.

```java
import com.aspose.slides.*;

// Membuat instance dari kelas Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Dapatkan Path Buku Kerja Sumber Data Eksternal dari Grafik**

1. Buat instance kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk shape grafik.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data grafik.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data buku kerja eksternal.

Kode Java ini memperlihatkan operasi tersebut:

```java
import com.aspose.slides.*;

// Membuat instance dari kelas Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Menyimpan presentasi
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edit Data Grafik**

Anda dapat mengedit data di buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Jika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode Java ini merupakan implementasi proses yang dijelaskan:

```java
import com.aspose.slides.*;

// Membuat instance dari kelas Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Pulihkan Buku Kerja dari Cache Grafik**

Jika sebuah grafik menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja grafik dari data yang di-cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/spreadsheetoptions/), dan panggil [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) dengan `true` sebelum membuka presentasi.

Contoh Java berikut membuka presentasi yang grafiknya merujuk ke buku kerja eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [IChart.getChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#getChartData--) dan [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Baca atau ubah data buku kerja yang dipulihkan di sini.
} finally {
    presentation.dispose();
}
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di-cache dapat diterima sebagai fallback, karena cache mungkin tidak berisi perubahan pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah grafik terhubung ke buku kerja eksternal atau tertanam?**

Ya. Grafik memiliki [data source type](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getDataSourceType--) dan [path ke buku kerja eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca path lengkap untuk memastikan file eksternal yang digunakan.

**Apakah path relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan path relatif, secara otomatis akan dikonversi menjadi path absolut. Ini memudahkan portabilitas proyek; namun, presentasi akan menyimpan path absolut di dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang berada di sumber daya jaringan/share?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja remote langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [link ke file eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya dengan [Aspose.Cells](/cells/java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik saat data dimuat kembali.