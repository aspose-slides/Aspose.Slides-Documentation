---
title: Mengelola Workbook Diagram dalam Presentasi di Android
linktitle: Workbook Diagram
type: docs
weight: 70
url: /id/androidjava/chart-workbook/
keywords:
- workbook diagram
- data diagram
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Android via Java: kelola workbook diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga membahas cara bekerja dengan workbook eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil path workbook eksternal yang terhubung ke diagram, serta mengedit data diagram ketika workbook tersedia.

## **Membaca dan Menulis Data Diagram dari Workbook**
Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yang memungkinkan Anda membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Kode Java ini menunjukkan contoh operasi:

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

## **Menetapkan Sel Workbook sebagai Label Data Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram Bubble dengan beberapa data.
1. Akses seri diagram.
1. Tetapkan sel workbook sebagai label data.
1. Simpan presentasi.

Kode Java ini menunjukkan cara menetapkan sel workbook sebagai label data diagram:

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

## **Mengelola Worksheet**

Kode Java ini menunjukkan operasi di mana metode [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) digunakan untuk mengakses koleksi worksheet:

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

## **Menentukan Tipe Sumber Data**

Kode Java ini menunjukkan cara menentukan tipe untuk sumber data:

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

## **Mendeteksi Format Workbook Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tertanam dalam beberapa diagram. Anda dapat menggunakan metode `getEmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IChartData) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/WorkbookType) untuk mendeteksi format yang tidak didukung dan melewatkan diagram tersebut.

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
            // Workbook tertanam berformat .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data workbook diagram di sini.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung workbook eksternal sebagai sumber data untuk diagram.

### **Membuat Workbook Eksternal**

Dengan menggunakan metode **`readWorkbookStream`** dan **`setExternalWorkbook`**, Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode Java ini menunjukkan proses pembuatan workbook eksternal:

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

### **Menetapkan Workbook Eksternal**

Dengan menggunakan metode **`setExternalWorkbook`**, Anda dapat menetapkan workbook eksternal ke sebuah diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui path ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika path relatif untuk workbook eksternal diberikan, path tersebut secara otomatis akan dikonversi menjadi path penuh.

Kode Java ini menunjukkan cara menetapkan workbook eksternal:

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

Parameter `ChartData` (dalam metode `setExternalWorkbook`) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak.

* Ketika nilai `ChartData` diatur ke `false`, hanya path workbook yang diperbarui — data diagram tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak dapat diakses.
* Ketika nilai `ChartData` diatur ke `true`, data diagram diperbarui dari workbook target.

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

### **Mendapatkan Path Workbook Sumber Data Eksternal dari Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://apireference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk bentuk diagram.
1. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode Java ini menunjukkan operasi tersebut:

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

### **Mengedit Data Diagram**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah konten workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode Java ini merupakan implementasi proses yang dijelaskan:

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

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram terhubung ke workbook eksternal atau tertanam?**

Ya. Diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) dan [path ke workbook eksternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jika sumbernya adalah workbook eksternal, Anda dapat membaca path lengkap untuk memastikan file eksternal yang digunakan.

**Apakah path relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan path relatif, secara otomatis akan dikonversi menjadi path absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan path absolut dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang berada pada sumber daya atau share jaringan?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook remote secara langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) dan menggunakannya untuk membaca data. File eksternal tidak dimodifikasi saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat melakukan tautan. Pendekatan umum adalah menghapus proteksi terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya dengan menggunakan [Aspose.Cells](/cells/androidjava/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semua diagram mengarah ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram saat data dimuat berikutnya.