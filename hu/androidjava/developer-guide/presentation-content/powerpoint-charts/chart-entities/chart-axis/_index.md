---
title: Diagramtengelyek testreszabása Android prezentációkban
linktitle: Diagramtengely
type: docs
url: /hu/androidjava/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Android via Java könyvtárat a diagramtengelyek testreszabásához PowerPoint-prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagramtengelyeket az Aspose.Slides‑ben. Megmutatja, hogyan lehet lekérni a tényleges tengelyértékeket, cserélni az adatokat a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, megváltoztatni a kategóriatengely típusát, beállítani a dátumformátumot a kategóriatengely értékeihez, elforgatni egy tengelycímkét, beállítani a tengely pozícióját, valamint megjeleníteni egy egységcímkét az értéktengelyen.

## **Maximum értékek lekérése a függőleges tengelyen diagramoknál**
Az Aspose.Slides for Android via Java lehetővé teszi a minimum és maximum értékek lekérését egy függőleges tengelyen. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá egy diagramot az alapértelmezett adatokkal.
1. Szerezze meg a tényleges legnagyobb értéket a tengelyen.
1. Szerezze meg a tényleges legkisebb értéket a tengelyen.
1. Szerezze meg a tényleges fő egységet a tengelyen.
1. Szerezze meg a tényleges mellékegységet a tengelyen.
1. Szerezze meg a tényleges fő egység skálát a tengelyen.
1. Szerezze meg a tényleges mellék egység skálát a tengelyen.

Ez a minta kód – a fenti lépések megvalósítása – bemutatja, hogyan lehet a szükséges értékeket Java‑ban lekérni:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Elmenti a prezentációt
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Adatok cseréje a tengelyek között**
Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges (y‑tengely) tengelyen megjelenő adatok áthelyeződnek a vízszintes (x‑tengely) tengelyre, és fordítva.

Ez a Java‑kód bemutatja, hogyan kell végrehajtani az adatcsere feladatot a tengelyek között egy diagramon:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Felcseréli a sorokat és oszlopokat
	chart.getChartData().switchRowColumn();

	// Mentés a prezentáció
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Függőleges tengely letiltása vonaldiagramoknál**

Ez a Java‑kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramnál:

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

## **Vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramnál:

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

## **Kategóriatengely módosítása**

A **CategoryAxisType** tulajdonsággal megadhatja a kívánt kategóriatengely típust (**date** vagy **text**). Ez a Java‑kód demonstrálja a műveletet:

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

## **Dátumformátum beállítása a kategóriatengely értékeire**
Az Aspose.Slides for Android via Java lehetővé teszi a dátumformátum beállítását egy kategóriatengely értékéhez. A műveletet ez a Java‑kód mutatja be:

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

## **Forgatási szög beállítása egy diagramtengely címkéhez**
Az Aspose.Slides for Android via Java lehetővé teszi a forgatási szög beállítását egy diagramtengely címkéhez. Ez a Java‑kód demonstrálja a műveletet:

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

## **A tengely pozíciójának beállítása egy kategória vagy értéktengelyen**
Az Aspose.Slides for Android via Java lehetővé teszi a tengely helyzetének beállítását egy kategória vagy értéktengelyen. Ez a Java‑kód megmutatja, hogyan kell a feladatot elvégezni:

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

## **Egységcímke megjelenítésének engedélyezése a diagram értéktengelyén**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a diagramot úgy konfigurálja, hogy egységcímkét jelenítsen meg a diagram értéktengelyén. Ez a Java‑kód demonstrálja a műveletet:

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

**Hogyan állíthatom be azt az értéket, ahol egy tengely áthalad a másikon (tengelykereszt)?**

A tengelyek egy [keresztbeállítást](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/axis/#setCrossType-int-) kínálnak: választhat, hogy a nullánál, a legnagyobb kategóriánál/értéknél vagy egy adott numerikus értéknél metssze őket. Ez hasznos az X‑tengely fel vagy le mozgatásához, illetve egy alapvonal kiemeléséhez.

**Hogyan helyezhetem el a jelmagyarázat címkéket a tengelyhez képest (oldalán, kívül, belül)?**

Állítsa a [címke pozícióját](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) „cross”, „outside” vagy „inside” értékre. Ez befolyásolja az olvashatóságot és segít helyet takarítani, különösen kis diagramok esetén.