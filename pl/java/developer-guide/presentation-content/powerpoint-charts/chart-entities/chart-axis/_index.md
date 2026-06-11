---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu Java
linktitle: Oś wykresu
type: docs
url: /pl/java/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowywanie osi
- manipulacja osią
- zarządzanie osią
- właściwości osi
- maksymalna wartość
- minimalna wartość
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides for Java do dostosowywania osi wykresu w prezentacjach PowerPoint dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, wymienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Uzyskaj maksymalne wartości na osi pionowej wykresów**
Aspose.Slides for Java umożliwia uzyskanie minimalnych i maksymalnych wartości na osi pionowej. Postępuj zgodnie z następującymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Pobierz rzeczywistą maksymalną wartość na osi.
1. Pobierz rzeczywistą minimalną wartość na osi.
1. Pobierz rzeczywistą główną jednostkę osi.
1. Pobierz rzeczywistą pomocniczą jednostkę osi.
1. Pobierz rzeczywistą skalę głównej jednostki osi.
1. Pobierz rzeczywistą skalę pomocniczej jednostki osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w Javie:

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
Aspose.Slides umożliwia szybkie zamienienie danych między osiami — dane przedstawione na osi pionowej (y) przechodzą na oś poziomą (x) i odwrotnie.

Ten kod w Javie pokazuje, jak wykonać zamianę danych między osiami wykresu:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Przełącza wiersze i kolumny
	chart.getChartData().switchRowColumn();

	// Zapisuje prezentację
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ukryj oś pionową w wykresach liniowych**

Ten kod w Javie pokazuje, jak ukryć oś pionową w wykresie liniowym:

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

## **Ukryj oś poziomą w wykresach liniowych**

Ten kod pokazuje, jak ukryć oś poziomą w wykresie liniowym:

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

Korzystając z właściwości **CategoryAxisType**, możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w Javie demonstruje tę operację:

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
Aspose.Slides for Java umożliwia ustawienie formatu daty dla wartości osi kategorii. Operację przedstawiono w poniższym kodzie Java:

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
Aspose.Slides for Java umożliwia ustawienie kąta obrotu tytułu osi wykresu. Ten kod w Javie demonstruje tę operację:

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
Aspose.Slides for Java umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod w Javie pokazuje, jak wykonać to zadanie:

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
Aspose.Slides for Java umożliwia skonfigurowanie wykresu tak, aby wyświetlał etykietę jednostki na osi wartości. Ten kod w Javie demonstruje tę operację:

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

Osie udostępniają [crossing setting](https://reference.aspose.com/slides/pl/java/com.aspose.slides/axis/#setCrossType-int-): możesz wybrać przecięcie w zerze, na maksymalnej kategorii/wartości lub w określonej wartości numerycznej. Jest to przydatne przy podnoszeniu lub opuszczaniu osi X lub podkreślaniu linii bazowej.

**Jak mogę ustawić położenie etykiet znaczników względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [label position](https://reference.aspose.com/slides/pl/java/com.aspose.slides/axis/#setMajorTickMark-int-) na „cross”, „outside” lub „inside”. Ma to wpływ na czytelność i pomaga oszczędzić miejsce, szczególnie w małych wykresach.