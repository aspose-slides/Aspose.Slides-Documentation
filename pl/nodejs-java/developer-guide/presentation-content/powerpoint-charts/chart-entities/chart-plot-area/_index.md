---
title: Dostosowywanie obszarów wykresów w prezentacjach w JavaScript
linktitle: Obszar wykresu
type: docs
url: /pl/nodejs-java/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj sposób dostosowywania obszarów wykresów w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js. Łatwo popraw wizualizację swoich slajdów."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując wartości X, Y, szerokość i wysokość.

Pokazuje także, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie swojego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobierz szerokość i wysokość obszaru wykresu**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API dla .

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę [Chart.validateChartLayout()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#validateChartLayout--) przed uzyskaniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewy) elementu wykresu względem lewego górnego rogu wykresu.
6. Pobiera rzeczywistą pozycję górną elementu wykresu względem lewego górnego rogu wykresu.
7. Pobiera rzeczywistą szerokość elementu wykresu.
8. Pobiera rzeczywistą wysokość elementu wykresu.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw tryb układu obszaru wykresu**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Metody **setLayoutTargetType** i **getLayoutTargetType** zostały dodane do klasy **ChartPlotArea**. Jeśli układ obszaru wykresu jest definiowany ręcznie, ta właściwość określa, czy układać obszar wykresu wewnątrz (bez osi i etykiet osi) czy na zewnątrz (z osiami i etykietami osi). Dostępne są dwie wartości określone w wyliczeniu **LayoutTargetType**.

- **LayoutTargetType.Inner** – określa, że rozmiar obszaru wykresu określa rozmiar samego obszaru wykresu, nie obejmując znaczników podziałki i etykiet osi.
- **LayoutTargetType.Outer** – określa, że rozmiar obszaru wykresu określa rozmiar obszaru wykresu, znaczników podziałki i etykiet osi.

Przykładowy kod jest podany poniżej.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**W jakich jednostkach zwracane są rzeczywiste X, rzeczywiste Y, rzeczywista szerokość i rzeczywista wysokość?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Jak obszar rysowania (Plot Area) różni się od obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar rysowania (Plot Area) to region przeznaczony do rysowania danych (serie, linie siatki, linie trendu itp.); obszar wykresu (Chart Area) obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D obszar rysowania obejmuje również ściany/podłogę oraz osie.

**Jak interpretowane są X, Y, szerokość i wysokość obszaru rysowania, gdy układ jest ręczny?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone, a używane są podane przez Ciebie ułamki.

**Dlaczego pozycja obszaru rysowania zmieniła się po dodaniu/przeniesieniu legendy?**

Legenda znajduje się w obszarze wykresu poza obszarem rysowania, ale wpływa na układ i dostępne miejsce, dlatego obszar rysowania może się przesunąć, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów PowerPoint.)