---
title: Kelola Buku Kerja Diagram dalam Presentasi Menggunakan Java
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/java/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel workbook
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan workbook
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Java: dengan mudah kelola buku kerja diagram dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui stream buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil path buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#readWorkbookStream--) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

Kode Java berikut mendemonstrasikan operasi contoh:

```java
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

## **Setel Sel WorkBook sebagai Label Data Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram Bubble dengan beberapa data.
1. Akses seri diagram.
1. Setel sel workbook sebagai label data.
1. Simpan presentasi.

Kode Java berikut menunjukkan cara menyetel sel workbook sebagai label data diagram:

```java
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

Kode Java berikut mendemonstrasikan operasi di mana metode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:

```java
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

Kode Java berikut menunjukkan cara menentukan jenis untuk sumber data:

```java
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

## **Deteksi Format Workbook Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/IChartData) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/java/com.aspose.slides/WorkbookType) untuk mendeteksi format yang tidak didukung dan melewati diagram‑diagram tersebut.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Workbook tersemat berada dalam format .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data workbook diagram di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Eksternal**

{{% alert color="primary" %}} 
Pada [Aspose.Slides 19.4](https://docs.aspose.com/slides/id/java/aspose-slides-for-java-19-4-release-notes/), kami menambahkan dukungan untuk workbook eksternal sebagai sumber data bagi diagram.
{{% /alert %}} 

### **Buat Workbook Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau mengubah workbook internal menjadi eksternal.

Kode Java berikut mendemonstrasikan proses pembuatan workbook eksternal:

```java
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

### **Setel Workbook Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke sebuah diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui path ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika path relatif untuk workbook eksternal diberikan, path tersebut akan otomatis dikonversi menjadi path lengkap.

Kode Java berikut menunjukkan cara menetapkan workbook eksternal:

```java
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

Parameter `ChartData` (di bawah metode `setExternalWorkbook`) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak. 

* Ketika nilai `ChartData` disetel ke `false`, hanya path workbook yang diperbarui—data diagram tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia. 
* Ketika nilai `ChartData` disetel ke `true`, data diagram diperbarui dari workbook target.

```java
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

### **Dapatkan Path Workbook Sumber Data Eksternal dari Sebuah Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk shape diagram.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode Java berikut mendemonstrasikan operasi tersebut:

```java
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

### **Edit Data Diagram**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti Anda mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah exception akan dilempar.

Kode Java berikut merupakan implementasi dari proses yang dijelaskan:

```java
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

### **Pulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali workbook diagram dari data yang disimpan dalam cache presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/spreadsheetoptions/), dan panggil [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) dengan `true` sebelum membuka presentasi.

Contoh Java berikut membuka sebuah presentasi yang diagramnya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [IChart.getChartData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichart/#getChartData--) dan [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar exception. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getDataSourceType--) dan [path ke workbook eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah workbook eksternal, Anda dapat membaca path lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah path relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan path relatif, path tersebut secara otomatis akan dikonversi menjadi path absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan path absolut dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang terletak pada sumber daya/jaringan bersama?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/java/)) dan menautkan ke salulan tersebut.

**Apakah beberapa diagram dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya mengarah ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat kembali.