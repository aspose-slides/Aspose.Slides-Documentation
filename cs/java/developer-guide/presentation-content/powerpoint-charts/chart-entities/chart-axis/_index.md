---
title: Přizpůsobení os grafu v prezentacích pomocí Javy
linktitle: Osa grafu
type: docs
url: /cs/java/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat s osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- poloha osy
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides pro Javu k přizpůsobení os grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy diagramu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty osy, vyměnit data mezi osami, skrýt svislou nebo vodorovnou osu u čárových diagramů, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit název osy, nastavit polohu osy a zobrazit popisek jednotky na hodnotové ose.

## **Získání maximálních hodnot na svislé ose v diagramech**

Aspose.Slides for Java umožňuje získat minimální a maximální hodnoty na svislé ose. Projděte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte skutečnou maximální hodnotu na ose.
1. Získejte skutečnou minimální hodnotu na ose.
1. Získejte skutečnou hlavní jednotku osy.
1. Získejte skutečnou vedlejší jednotku osy.
1. Získejte skutečnou měřítko hlavní jednotky osy.
1. Získejte skutečnou měřítko vedlejší jednotky osy.

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Uloží prezentaci
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Výměna dat mezi osami**

Aspose.Slides umožňuje rychle vyměnit data mezi osami — data zobrazená na svislé ose (y‑osa) se přesune na vodorovnou osu (x‑osa) a naopak.

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Přepíná řádky a sloupce
	chart.getChartData().switchRowColumn();

	// Uloží prezentaci
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Zakázat svislou osu u čárových diagramů**

Tento Java kód ukazuje, jak skrýt svislou osu u čárového diagramu:

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

## **Zakázat vodorovnou osu u čárových diagramů**

Tento kód ukazuje, jak skrýt vodorovnou osu u čárového diagramu:

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

## **Změna osy kategorií**

Pomocí vlastnosti **CategoryAxisType** můžete určit preferovaný typ osy kategorií (**date** nebo **text**). Tento Java kód demonstruje operaci:

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

## **Nastavení formátu data pro hodnoty osy kategorií**

Aspose.Slides for Java umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto Java kódu:

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

## **Nastavení úhlu otočení názvu osy diagramu**

Aspose.Slides for Java umožňuje nastavit úhel otočení názvu osy diagramu. Tento Java kód demonstruje operaci:

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

## **Nastavení polohy osy na ose kategorií nebo hodnot**

Aspose.Slides for Java umožňuje nastavit polohu osy v ose kategorií nebo hodnot. Tento Java kód ukazuje, jak úlohu provést:

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

## **Povolení zobrazení popisku jednotky na hodnotové ose diagramu**

Aspose.Slides for Java umožňuje nakonfigurovat diagram tak, aby zobrazoval popisek jednotky na jeho hodnotové ose. Tento Java kód demonstruje operaci:

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

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (překřížení osy)?**

Osy nabízejí [nastavení překřížení](https://reference.aspose.com/slides/cs/java/com.aspose.slides/axis/#setCrossType-int-): můžete zvolit překřížení v nule, v maximální hodnotě kategorie/hodnoty nebo v konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů nebo pro zdůraznění referenční čáry.

**Jak mohu umístit popisky značek relativně k ose (vedle, vně, uvnitř)?**

Nastavte [polohu popisků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/axis/#setMajorTickMark-int-) na "cross", "outside" nebo "inside". Toto ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých diagramů.