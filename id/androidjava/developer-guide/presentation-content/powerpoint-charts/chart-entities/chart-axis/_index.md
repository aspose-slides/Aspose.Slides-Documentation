---
title: Sesuaikan Sumbu Diagram dalam Presentasi di Android
linktitle: Sumbu Diagram
type: docs
url: /id/androidjava/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk Android melalui Java untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint untuk laporan dan visualisasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram di Aspose.Slides. Artikel ini menunjukkan cara mendapatkan nilai sumbu sebenarnya, menukar data antar sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah jenis sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label satuan pada sumbu nilai.

## **Dapatkan Nilai Maksimum pada Sumbu Vertikal pada Diagram**
Aspose.Slides for Android via Java memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Dapatkan nilai maksimum sebenarnya pada sumbu.
1. Dapatkan nilai minimum sebenarnya pada sumbu.
1. Dapatkan satuan utama (major unit) sebenarnya pada sumbu.
1. Dapatkan satuan minor sebenarnya pada sumbu.
1. Dapatkan skala satuan utama sebenarnya pada sumbu.
1. Dapatkan skala satuan minor sebenarnya pada sumbu.

Kode contoh ini—implementasi langkah‑langkah di atas—menunjukkan cara mendapatkan nilai yang diperlukan dalam Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Menyimpan presentasi
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Tukar Data antar Sumbu**
Aspose.Slides memungkinkan Anda menukar data antar sumbu dengan cepat—data yang ditampilkan pada sumbu vertikal (y-axis) berpindah ke sumbu horizontal (x-axis) dan sebaliknya. 

Kode Java ini menunjukkan cara melakukan tugas penukaran data antar sumbu pada diagram:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Menukar baris dan kolom
	// Menyimpan presentasi
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Nonaktifkan Sumbu Vertikal untuk Diagram Garis**

Kode Java ini menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Nonaktifkan Sumbu Horizontal untuk Diagram Garis**

Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ubah Sumbu Kategori**

Dengan menggunakan properti **CategoryAxisType**, Anda dapat menentukan jenis sumbu kategori yang diinginkan (**date** atau **text**). Kode Java ini memperlihatkan operasi tersebut: 

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Atur Format Tanggal untuk Nilai Sumbu Kategori**
Aspose.Slides untuk Android via Java memungkinkan Anda mengatur format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode Java berikut:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Atur Sudut Rotasi untuk Judul Sumbu Diagram**
Aspose.Slides untuk Android via Java memungkinkan Anda mengatur sudut rotasi untuk judul sumbu diagram. Kode Java ini memperlihatkan operasinya:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Atur Posisi Sumbu pada Sumbu Kategori atau Nilai**
Aspose.Slides untuk Android via Java memungkinkan Anda mengatur posisi sumbu pada sumbu kategori atau nilai. Kode Java ini menunjukkan cara melakukan tugas tersebut:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aktifkan Tampilan Label Satuan pada Sumbu Nilai Diagram**
Aspose.Slides untuk Android via Java memungkinkan Anda mengonfigurasi diagram agar menampilkan label satuan pada sumbu nilai diagramnya. Kode Java ini memperlihatkan operasinya:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (penyilangan sumbu)?**

Sumbu menyediakan [pengaturan crossing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/axis/#setCrossType-int-): Anda dapat memilih untuk memotong pada nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana saya dapat memposisikan label tick relatif terhadap sumbu (di samping, di luar, di dalam)?**

Atur [posisi label](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) menjadi "cross", "outside", atau "inside". Ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.