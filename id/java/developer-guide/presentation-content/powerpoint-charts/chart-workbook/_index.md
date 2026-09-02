---
title: "Mengelola Workbook Diagram dalam Presentasi Menggunakan Java"
linktitle: "Workbook Diagram"
type: docs
weight: 70
url: /id/java/chart-workbook/
keywords:
- "workbook diagram"
- "data diagram"
- "sel workbook"
- "label data"
- "lembar kerja"
- "sumber data"
- "workbook eksternal"
- "data eksternal"
- "cache diagram"
- "pemulihan workbook"
- "PowerPoint"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Temukan Aspose.Slides untuk Java: kelola workbook diagram secara mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi worksheet, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga mencakup penggunaan workbook eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, serta mengedit data diagram ketika workbook tersedia.

## **Baca dan Tulis Data Diagram dari Workbook**
Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#readWorkbookStream--) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

Kode Java ini mendemonstrasikan operasi contoh:

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

### **Validasi Tata Letak Diagram Setelah Modifikasi Workbook**

Saat Anda mengganti workbook tersemat dengan yang telah dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori asli. Inkonsistensi ini dapat menyebabkan `chart.validateChartLayout()` melempar `ArgumentOutOfRangeException` (parameter: index). Untuk menghindari pengecualian, bersihkan seri dan kategori yang ada **sebelum** menulis kembali workbook yang diperbarui ke diagram.

```java
// Setelah memodifikasi aliran workbook (misalnya, menggunakan Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Bersihkan referensi data yang ada.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Tuliskan workbook yang diperbarui kembali ke diagram.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Sekarang validasi berhasil.
chart.validateChartLayout();
```

Membersihkan koleksi memastikan struktur data diagram selaras dengan workbook baru, memungkinkan `validateChartLayout()` selesai tanpa kesalahan.

## **Tetapkan Sel Workbook sebagai Label Data Diagram**

1. Buat instance kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram Bubble dengan beberapa data.
1. Akses seri diagram.
1. Tetapkan sel workbook sebagai label data.
1. Simpan presentasi.

Kode Java ini menunjukkan cara menetapkan sel workbook sebagai label data diagram:

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

## **Kelola Worksheet**

Kode Java ini mendemonstrasikan operasi di mana metode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:

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

## **Deteksi Format Workbook Terembed yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/java/com.aspose.slides/WorkbookType) untuk mendeteksi format yang tidak didukung dan melewati diagram tersebut.

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
            // Workbook tersemat berformat .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data workbook diagram di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Eksternal**

{{% alert color="info" %}} 
Di [Aspose.Slides 19.4](https://docs.aspose.com/slides/id/java/aspose-slides-for-java-19-4-release-notes/), kami menambahkan dukungan untuk workbook eksternal sebagai sumber data bagi diagram.
{{% /alert %}} 

### **Buat Workbook Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau mengubah workbook internal menjadi eksternal.

Kode Java ini mendemonstrasikan proses pembuatan workbook eksternal:

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

### **Tetapkan Workbook Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data pada workbook yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal disediakan, jalur tersebut secara otomatis dikonversi menjadi jalur penuh.

Kode Java ini menunjukkan cara menetapkan workbook eksternal:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation
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

Parameter (`boolean`) kedua dari metode `setExternalWorkbook` digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak. 

* Ketika nilainya `false`, hanya jalur workbook yang diperbarui—data diagram tidak akan dimuat atau diperbarui dari workbook target. Anda dapat menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia. 
* Ketika nilainya `true`, data diagram diperbarui dari workbook target.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation
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

### **Dapatkan Jalur Workbook Sumber Data Eksternal dari Diagram**

1. Buat instance kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk bentuk diagram.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode Java ini mendemonstrasikan operasi tersebut:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation
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

### **Edit Data Diagram**

Anda dapat mengedit data pada workbook eksternal dengan cara yang sama seperti mengubah konten workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode Java ini merupakan implementasi proses yang dijelaskan:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation
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

### **Pulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/spreadsheetoptions/), dan panggil [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) dengan `true` sebelum membuka presentasi.

Contoh Java berikut membuka presentasi yang diagramnya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [IChart.getChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#getChartData--) dan [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Baca atau ubah data workbook yang dipulihkan di sini.
} finally {
    presentation.dispose();
}
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache dapat diterima sebagai alternatif, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getDataSourceType--) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Hal ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan jalur absolut di dalam file PPTX.

**Dapatkah saya menggunakan workbook yang berada di sumber daya/jaringan bersama?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, pengeditan workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak dimodifikasi saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semua diagram menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat berikutnya.