---
title: Dodaj linie trendu do wykresów w prezentacji w JavaScript
linktitle: Linia trendu
type: docs
url: /pl/nodejs-java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- linia trendu liniowa
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu JavaScript i Aspose.Slides for Node.js via Java — praktyczny przewodnik, który zaangażuje Twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnią kroczącą, wielomianowymi i potęgowymi.

Opisuje także, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do formatu PDF lub SVG oraz podczas renderowania wykresów jako obrazy.

## **Dodaj linię trendu**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj wykres z danymi domyślnymi wraz z wybranym typem (w tym przykładzie użyto ChartType.ClusteredColumn).
1. Dodawanie wykładniczej linii trendu dla serii wykresu 1.
1. Dodawanie liniowej linii trendu dla serii wykresu 1.
1. Dodawanie logarytmicznej linii trendu dla serii wykresu 2.
1. Dodawanie linii trendu średniej kroczącej dla serii wykresu 2.
1. Dodawanie wielomianowej linii trendu dla serii wykresu 3.
1. Dodawanie potęgowej linii trendu dla serii wykresu 3.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do utworzenia wykresu z liniami trendu.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tworzenie wykresu kolumnowego grupowanego
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Dodawanie wykładniczej linii trendu dla serii wykresu 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Dodawanie liniowej linii trendu dla serii wykresu 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Dodawanie logarytmicznej linii trendu dla serii wykresu 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Dodawanie linii trendu średniej kroczącej dla serii wykresu 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Dodawanie wielomianowej linii trendu dla serii wykresu 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Dodawanie potęgowej linii trendu dla serii wykresu 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Zapisywanie prezentacji
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodaj własną linię**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation)
- Uzyskaj odniesienie do slajdu, używając jego indeksu
- Utwórz nowy wykres przy użyciu metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Linia przy użyciu metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do utworzenia wykresu z własnymi liniami.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Co oznaczają 'forward' i 'backward' w kontekście linii trendu?**

Są to długości linii trendu projektowane w przód/tuł: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów nie‑punktowych – w liczbie kategorii. Dopuszczalne są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana podczas eksportu prezentacji do formatu PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda do [eksportu obrazu wykresu](/slides/pl/nodejs-java/create-shape-thumbnails/) samego w sobie.