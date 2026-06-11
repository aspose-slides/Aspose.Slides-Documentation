---
title: Dodawanie linii trendu do wykresów w prezentacji w Javie
linktitle: Linia trendu
type: docs
url: /pl/java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla Javy — praktyczny przewodnik, aby przyciągnąć uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnią kroczącą, wielomianowymi i potęgowymi.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu do przodu i do tyłu oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**
Aspose.Slides dla Javy zapewnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z danymi domyślnymi oraz wybranym typem (w tym przykładzie użyto ChartType.ClusteredColumn).
4. Dodawanie wykładniczej linii trendu dla serii wykresu 1.
5. Dodawanie liniowej linii trendu dla serii wykresu 1.
6. Dodawanie logarytmicznej linii trendu dla serii wykresu 2.
7. Dodawanie linii trendu średniej kroczącej dla serii wykresu 2.
8. Dodawanie wielomianowej linii trendu dla serii wykresu 3.
9. Dodawanie potęgowej linii trendu dla serii wykresu 3.
10. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do utworzenia wykresu z liniami trendu.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Tworzenie wykresu kolumnowego grupowanego
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Dodawanie wykładniczej linii trendu dla serii wykresu 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Dodawanie liniowej linii trendu dla serii wykresu 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Dodawanie logarytmicznej linii trendu dla serii wykresu 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Dodawanie linii trendu średniej kroczącej dla serii wykresu 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Dodawanie wielomianowej linii trendu dla serii wykresu 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Dodawanie potęgowej linii trendu dla serii wykresu 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Zapisywanie prezentacji
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj własną linię**
Aspose.Slides dla Javy zapewnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj odwołanie do slajdu, używając jego indeksu.
- Utwórz nowy wykres przy użyciu metody AddChart udostępnionej przez obiekt Shapes.
- Dodaj AutoShape typu Linia przy użyciu metody AddAutoShape udostępnionej przez obiekt Shapes.
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do utworzenia wykresu z własnymi liniami.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Co oznaczają terminy „forward” i „backward” w odniesieniu do linii trendu?**

Są to długości linii trendu projekcjonowane do przodu/do tyłu: dla wykresów rozrzutu (XY) — w jednostkach osi; dla wykresów innych niż rozrzut — w liczbie kategorii. Dozwolone są wyłącznie wartości nieujemne.

**Czy linia trendu zostanie zachowana podczas eksportu prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/java/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda do [eksportu obrazu wykresu](/slides/pl/java/create-shape-thumbnails/).