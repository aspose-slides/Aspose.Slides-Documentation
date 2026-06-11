---
title: Dostosuj osie wykresu w prezentacjach na Androidzie
linktitle: Osie wykresu
type: docs
url: /pl/androidjava/chart-axis/
keywords:
- osie wykresu
- pionowa oś
- pozioma oś
- dostosuj oś
- manipuluj osią
- zarządzaj osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak używać Aspose.Slides dla Androida za pośrednictwem Javy, aby dostosować osie wykresu w prezentacjach PowerPoint do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Pobierz maksymalne wartości na pionowej osi wykresów**
Aspose.Slides dla Androida za pośrednictwem Java umożliwia uzyskanie minimalnych i maksymalnych wartości na pionowej osi. Przejdź przez poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z danymi domyślnymi.
4. Pobierz rzeczywistą maksymalną wartość na osi.
5. Pobierz rzeczywistą minimalną wartość na osi.
6. Pobierz rzeczywistą jednostkę główną osi.
7. Pobierz rzeczywistą jednostkę pomocniczą osi.
8. Pobierz rzeczywistą skalę jednostki głównej osi.
9. Pobierz rzeczywistą skalę jednostki pomocniczej osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w języku Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Zapisuje prezentację
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Zamień dane między osiami**
Aspose.Slides umożliwia szybkie zamienienie danych między osiami — dane znajdujące się na pionowej osi (y) przenoszone są na poziomą oś (x) i odwrotnie.

Ten kod Java pokazuje, jak wykonać zamianę danych między osiami w wykresie:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Zamienia wiersze i kolumny
	chart.getChartData().switchRowColumn();

	// Zapisuje prezentację
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ukryj pionową oś w wykresach liniowych**

Ten kod Java pokazuje, jak ukryć pionową oś w wykresie liniowym:

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

## **Ukryj poziomą oś w wykresach liniowych**

Ten kod pokazuje, jak ukryć poziomą oś w wykresie liniowym:

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

## **Zmień oś kategorii**

Za pomocą właściwości **CategoryAxisType** możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w języku Java demonstruje tę operację:

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

## **Ustaw format daty dla wartości osi kategorii**
Aspose.Slides dla Androida za pośrednictwem Java umożliwia ustawienie formatu daty dla wartości osi kategorii. Operacja jest pokazana w poniższym kodzie Java:

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

## **Ustaw kąt obrotu tytułu osi wykresu**
Aspose.Slides dla Androida za pośrednictwem Java umożliwia ustawienie kąta obrotu tytułu osi wykresu. Ten kod Java demonstruje tę operację:

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

## **Ustaw pozycję osi na osi kategorii lub wartości**
Aspose.Slides dla Androida za pośrednictwem Java umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod Java pokazuje, jak wykonać to zadanie:

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

## **Włącz wyświetlanie etykiety jednostki na osi wartości wykresu**
Aspose.Slides dla Androida za pośrednictwem Java umożliwia skonfigurowanie wykresu tak, aby wyświetlał etykietę jednostki na osi wartości wykresu. Ten kod Java demonstruje tę operację:

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

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie udostępniają [ustawienie przecięcia](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/axis/#setCrossType-int-): możesz wybrać przecięcie w zerze, w maksymalnej kategorii/wartości lub w określonej wartości numerycznej. Jest to przydatne do przesuwania osi X w górę lub w dół lub podkreślenia linii bazowej.

**Jak mogę ustawić położenie etykiet znaczników względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [pozycję etykiety](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) na “cross”, “outside” lub “inside”. Ma to wpływ na czytelność i pomaga zaoszczędzić miejsce, szczególnie w małych wykresach.