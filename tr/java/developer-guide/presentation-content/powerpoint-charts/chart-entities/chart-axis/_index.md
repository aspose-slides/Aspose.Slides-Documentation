---
title: Java Kullanarak Sunularda Grafik Ekseni Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştir
- eksen manipüle et
- eksen yönet
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarındaki grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides’ta grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini alma, eksenler arasında veri takas etme, çizgi grafikleri için dikey veya yatay ekseni gizleme, kategori eksen tipini değiştirme, kategori eksen değerleri için tarih biçimini ayarlama, eksen başlığını döndürme, eksen konumunu ayarlama ve değer ekseninde bir birim etiketi gösterme konularını gösterir.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Almak**
Aspose.Slides for Java, bir dikey eksende minimum ve maksimum değerleri elde etmenizi sağlar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Eksen üzerindeki gerçek maksimum değeri alın.
1. Eksen üzerindeki gerçek minimum değeri alın.
1. Eksenin gerçek büyük birim değerini alın.
1. Eksenin gerçek küçük birim değerini alın.
1. Eksenin gerçek büyük birim ölçeğini alın.
1. Eksenin gerçek küçük birim ölçeğini alın.

Yukarıdaki adımların bir uygulaması olan bu örnek kod, Java’da gerekli değerleri nasıl alacağınızı gösterir:

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

## **Eksenler Arası Veriyi Takas Etme**
Aspose.Slides, eksenler arasındaki veriyi hızlıca takas etmenizi sağlar—dikey eksende (y‑ekseni) gösterilen veriler yatay eksene (x‑ekseni) ve tersine taşınır.

Bu Java kodu, bir grafikte eksenler arasındaki veri takasını nasıl yapacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Satırları ve sütunları değiştirir
	chart.getChartData().switchRowColumn();

	// Sunumu kaydeder
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Çizgi Grafiklerde Dikey Eksenin Devre Dışı Bırakılması**

Bu Java kodu, bir çizgi grafiğinde dikey ekseni nasıl gizleyeceğinizi gösterir:

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

## **Çizgi Grafiklerde Yatay Eksenin Devre Dışı Bırakılması**

Bu kod, bir çizgi grafiğinde yatay ekseni nasıl gizleyeceğinizi gösterir:

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

## **Bir Kategori Eksenini Değiştirme**

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

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlama**
Aspose.Slides for Java, bir kategori eksen değerinin tarih biçimini ayarlamanıza olanak tanır. Bu Java kodunda işlem gösterilmiştir:

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
Aspose.Slides for Java, bir grafik eksen başlığı için döndürme açısını ayarlamanıza izin verir. Bu Java kodu işlemi gösterir:

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlama**
Aspose.Slides for Java, bir kategori veya değer ekseninde eksen konumunu ayarlamanıza olanak tanır. Bu Java kodu görevi nasıl gerçekleştireceğinizi gösterir:

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

## **Grafik Değer Ekseninde Birim Etiketinin Görüntülenmesini Etkinleştirme**
Aspose.Slides for Java, bir grafiğin değer ekseninde bir birim etiketi gösterilmesini yapılandırmanıza izin verir. Bu Java kodu işlemi gösterir:

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

**Bir eksenin diğerini kesiştiği değeri (ekseni kesişim) nasıl ayarlarım?**

Eksenler bir [crossing setting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/axis/#setCrossType-int-) sunar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X‑eksenini yukarı veya aşağı kaydırmak ya da bir temel çizgiyi vurgulamak için faydalıdır.

**Tik etiketlerini eksene göre (yan yana, dışta, içinde) nasıl konumlandırırım?**

[label position](https://reference.aspose.com/slides/tr/java/com.aspose.slides/axis/#setMajorTickMark-int-) ayarını "cross", "outside" veya "inside" olarak belirleyin. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.