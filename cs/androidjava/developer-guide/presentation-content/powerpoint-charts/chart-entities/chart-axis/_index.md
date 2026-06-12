---
title: "Přizpůsobení os grafu v prezentacích na Androidu"
linktitle: "Osa grafu"
type: docs
url: /cs/androidjava/chart-axis/
keywords:
  - "osa grafu"
  - "svislá osa"
  - "vodorovná osa"
  - "přizpůsobení osy"
  - "manipulace s osou"
  - "správa osy"
  - "vlastnosti osy"
  - "maximální hodnota"
  - "minimální hodnota"
  - "čára osy"
  - "formát data"
  - "název osy"
  - "pozice osy"
  - "PowerPoint"
  - "prezentace"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Objevte, jak pomocí Aspose.Slides pro Android přes Java přizpůsobit osy grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty osy, prohodit data mezi osami, skrýt svislou nebo vodorovnou osu u spojnicových grafů, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit nadpis osy, nastavit polohu osy a zobrazit štítek jednotky na hodnotové ose.

## **Získání maximálních hodnot na svislé ose grafů**
Aspose.Slides pro Android přes Java umožňuje získat minimální a maximální hodnoty na svislé ose. Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přistupte k první snímku.
1. Přidejte graf s výchozími daty.
1. Získejte skutečnou maximální hodnotu na ose.
1. Získejte skutečnou minimální hodnotu na ose.
1. Získejte skutečnou hlavní jednotku osy.
1. Získejte skutečnou vedlejší jednotku osy.
1. Získejte skutečnou měřítko hlavní jednotky osy.
1. Získejte skutečnou měřítko vedlejší jednotky osy.

Tento ukázkový kód – implementace výše uvedených kroků – ukazuje, jak získat požadované hodnoty v Javě:

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

## **Prohození dat mezi osami**
Aspose.Slides umožňuje rychle prohodit data mezi osami – data zobrazená na svislé ose (y‑osa) se přesunou na vodorovnou osu (x‑osa) a naopak.

Tento Java kód ukazuje, jak provést výměnu dat mezi osami v grafu:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Přepne řádky a sloupce
	// Uloží prezentaci
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Zakázání svislé osy u spojnicových grafů**

Tento Java kód ukazuje, jak skrýt svislou osu u spojnicového grafu:

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

## **Zakázání vodorovné osy u spojnicových grafů**

Tento kód ukazuje, jak skrýt vodorovnou osu u spojnicového grafu:

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

Pomocí vlastnosti **CategoryAxisType** můžete určit požadovaný typ osy kategorií (**date** nebo **text**). Tento Java kód demonstruje operaci:

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
Aspose.Slides pro Android přes Java umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto Java kódu:

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

## **Nastavení úhlu otáčení nadpisu osy grafu**
Aspose.Slides pro Android přes Java umožňuje nastavit úhel otáčení nadpisu osy grafu. Tento Java kód demonstruje operaci:

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

## **Nastavení polohy osy na ose kategorií nebo hodnoty**
Aspose.Slides pro Android přes Java umožňuje nastavit polohu osy v ose kategorií nebo hodnoty. Tento Java kód ukazuje, jak provést úkol:

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

## **Povolení zobrazování štítku jednotky na hodnotové ose grafu**
Aspose.Slides pro Android přes Java umožňuje nakonfigurovat graf tak, aby zobrazoval štítek jednotky na své hodnotové ose. Tento Java kód demonstruje operaci:

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

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Osy poskytují [crossing setting](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/axis/#setCrossType-int-): můžete zvolit průsečík v nule, na maximální kategorii/hodnotě nebo na konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů nebo pro zdůraznění referenční čáry.

**Jak mohu umístit popisky značek vzhledem k ose (vedle, venku, uvnitř)?**

Nastavte [label position](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) na „cross“, „outside“ nebo „inside“. Toto ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.