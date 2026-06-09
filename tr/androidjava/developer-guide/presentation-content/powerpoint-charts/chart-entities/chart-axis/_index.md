---
title: Android'ta Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/androidjava/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'i kullanarak PowerPoint sunumlarındaki grafik eksenlerini raporlar ve görselleştirmeler için nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini nasıl alacağınızı, eksenler arasında verileri nasıl değiştireceğinizi, çizgi grafiklerinde dikey veya yatay ekseni nasıl gizleyeceğinizi, kategori eksen tipini nasıl değiştirileceğini, kategori eksen değerleri için tarih biçimini nasıl ayarlayacağınızı, bir eksen başlığını nasıl döndüreceğinizi, eksen konumunu nasıl ayarlayacağınızı ve değer ekseninde bir birim etiketi nasıl görüntüleneceğini gösterir.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Almak**
Aspose.Slides for Android via Java, bir dikey eksende minimum ve maksimum değerleri almanıza olanak tanır. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Eksenin gerçek maksimum değerini alın.
5. Eksenin gerçek minimum değerini alın.
6. Eksenin gerçek ana birimini alın.
7. Eksenin gerçek yan birimini alın.
8. Eksenin gerçek ana birim ölçeğini alın.
9. Eksenin gerçek yan birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulamasıdır—gereken değerleri Java’da nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Sunumu kaydeder
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Eksenler Arasındaki Verileri Değiştirme**
Aspose.Slides, eksenler arasındaki verileri hızlıca değiştirmenize olanak tanır—dikey eksende (y-ekseninde) temsil edilen veriler yatay eksene (x-eksenine) ve tersine taşınır.

Bu Java kodu, bir grafikte eksenler arasındaki veri değişimini nasıl gerçekleştireceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Satır ve sütunları değiştirir
	chart.getChartData().switchRowColumn();

	// Sunumu kaydeder
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırakma**

Bu Java kodu, bir çizgi grafik için dikey ekseni nasıl gizleyeceğinizi gösterir:

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

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırakma**

Bu kod, bir çizgi grafik için yatay ekseni nasıl gizleyeceğinizi gösterir:

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

## **Kategori Eksenini Değiştirme**

**CategoryAxisType** özelliğini kullanarak tercih ettiğiniz kategori eksen tipini (**date** veya **text**) belirtebilirsiniz. Bu Java kodu işlemi gösterir:

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

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarlama**
Aspose.Slides for Android via Java, bir kategori eksen değerinin tarih biçimini ayarlamanıza olanak tanır. İşlem bu Java kodunda gösterilmiştir:

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

## **Grafik Eksen Başlığı İçin Döndürme Açısını Ayarlama**
Aspose.Slides for Android via Java, bir grafik eksen başlığının döndürme açısını ayarlamanıza olanak tanır. Bu Java kodu işlemi gösterir:

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlama**
Aspose.Slides for Android via Java, bir kategori veya değer ekseninde eksen konumunu ayarlamanıza olanak tanır. Bu Java kodu görevi nasıl gerçekleştireceğinizi gösterir:

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

## **Grafik Değer Ekseninde Birim Etiketini Görüntülemeyi Etkinleştirme**
Aspose.Slides for Android via Java, bir grafiğin değer ekseninde bir birim etiketinin gösterilmesini yapılandırmanıza olanak tanır. Bu Java kodu işlemi gösterir:

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

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Eksenler, bir [kesişme ayarı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/axis/#setCrossType-int-) sunar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X-eksenini yukarı ya da aşağı kaydırmak ya da bir temel çizgiyi vurgulamak için kullanışlıdır.

**Tik etiketlerini eksene göre (yan yana, dışta, içinde) nasıl konumlandırabilirim?**

[etiket konumunu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) "cross", "outside" veya "inside" olarak ayarlayın. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.