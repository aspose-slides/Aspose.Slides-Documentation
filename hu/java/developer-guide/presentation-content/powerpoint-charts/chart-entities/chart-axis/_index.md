---
title: Diagram tengelyek testreszabása prezentációkban Java használatával
linktitle: Diagram tengely
type: docs
url: /hu/java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely kezelése
- tengely kezelése
- tengely tulajdonságok
- maximum érték
- minimum érték
- tengely vonal
- dátum formátum
- tengely cím
- tengely helyzet
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Java-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeket az Aspose.Slides-ban. Megmutatja, hogyan lehet megkapni a tényleges tengelyértékeket, cserélni az adatokat a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, megváltoztatni a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni egy tengely címet, beállítani a tengely helyzetét, valamint megjeleníteni egy egységcímkét az érték tengelyen.

## **Maximum értékek a függőleges tengelyen a diagramoknál**
Az Aspose.Slides for Java lehetővé teszi a minimum és maximum értékek lekérését egy függőleges tengelyen. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Érje el az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Szerezze meg a tényleges maximális értéket a tengelyen.
5. Szerezze meg a tényleges minimális értéket a tengelyen.
6. Szerezze meg a tényleges fő egységet a tengelyen.
7. Szerezze meg a tényleges al‑egységet a tengelyen.
8. Szerezze meg a tényleges fő egység skálát a tengelyen.
9. Szerezze meg a tényleges al‑egység skálát a tengelyen.

Ez a minta kód – a fenti lépések megvalósítása – megmutatja, hogyan lehet a szükséges értékeket Java-ban lekérni:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Mentés a prezentáció
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Az adatok cseréje a tengelyek között**
Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y‑tengely) megjelenő adatok átkerülnek a vízszintes tengelyre (x‑tengely), és fordítva.

Ez a Java kód bemutatja, hogyan hajtható végre az adatcsere a diagram tengelyei között:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Váltja a sorokat és az oszlopokat
	chart.getChartData().switchRowColumn();

	// Mentés a prezentáció
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **A függőleges tengely letiltása vonaldiagramoknál**

Ez a Java kód bemutatja, hogyan rejthető el a függőleges tengely egy vonaldiagramon:

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

## **A vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan rejthető el a vízszintes tengely egy vonaldiagramon:

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

## **Kategória tengely módosítása**

A **CategoryAxisType** tulajdonság használatával megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a Java kód bemutatja a műveletet:

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

## **Dátumformátum beállítása a kategória tengely értékeihez**
Az Aspose.Slides for Java lehetővé teszi, hogy beállítsa a dátumformátumot egy kategória tengely értékéhez. A műveletet ez a Java kód demonstrálja:

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

## **Forgatási szög beállítása a diagram tengely címéhez**
Az Aspose.Slides for Java lehetővé teszi a forgatási szög beállítását egy diagram tengely címéhez. Ez a Java kód demonstrálja a műveletet:

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

## **A tengely helyzetének beállítása kategória vagy érték tengelyen**
Az Aspose.Slides for Java lehetővé teszi a tengely helyzetének beállítását egy kategória vagy érték tengelyen. Ez a Java kód megmutatja, hogyan végezhető el a feladat:

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

## **Az egységcímke megjelenítésének engedélyezése a diagram érték tengelyén**
Az Aspose.Slides for Java lehetővé teszi, hogy egy diagramon megjelenjen az egységcímke a diagram érték tengelyén. Ez a Java kód demonstrálja a műveletet:

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

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol az egyik tengely keresztezi a másikat (tengelykereszteződés)?**

A tengelyek egy [crossing setting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/axis/#setCrossType-int-) lehetőséget kínálnak: kiválaszthatja, hogy a nulla, a maximális kategória/érték vagy egy konkrét numerikus érték legyen a metszéspont. Ez hasznos az X‑tengely felfelé vagy lefelé történő eltolásához vagy egy alapvonal kiemeléséhez.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest (mellett, kívül, belül)?**

Állítsa be a [label position](https://reference.aspose.com/slides/hu/java/com.aspose.slides/axis/#setMajorTickMark-int-) értékét „cross”, „outside” vagy „inside” értékre. Ez befolyásolja az olvashatóságot és segít helyet megtakarítani, különösen kis diagramok esetén.