---
title: Dostosowywanie obszarów wykresów w prezentacjach w Javie
linktitle: Obszar wykresu
type: docs
url: /pl/java/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy. Popraw wygląd slajdów bez wysiłku."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości.

Pokazuje także, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie jego wewnętrznego regionu czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobranie szerokości i wysokości obszaru wykresu**
Aspose.Slides for Java udostępnia prosty interfejs API.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) .
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z danymi domyślnymi.
1. Wywołaj metodę [IChart.validateChartLayout()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart#validateChartLayout--) przed uzyskaniem rzeczywistych wartości.
1. Pobiera rzeczywistą pozycję X (lewo) elementu wykresu względem lewego górnego rogu wykresu.
1. Pobiera rzeczywistą pozycję Y (góra) elementu wykresu względem lewego górnego rogu wykresu.
1. Pobiera rzeczywistą szerokość elementu wykresu.
1. Pobiera rzeczywistą wysokość elementu wykresu.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawienie trybu układu obszaru wykresu**
Aspose.Slides for Java udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) i [**getLayoutTargetType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) zostały dodane do klasy [**ChartPlotArea**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ChartPlotArea) oraz interfejsu [**IChartPlotArea**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartPlotArea). Jeśli układ obszaru wykresu jest definiowany ręcznie, to właściwość określa, czy układ obszaru wykresu ma być określany przez jego wnętrze (bez osi i etykiet osi) czy zewnętrze (z osiami i etykietami osi). Dostępne są dwie możliwe wartości, które są zdefiniowane w wyliczeniu [**LayoutTargetType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LayoutTargetType#Inner) - określa, że rozmiar obszaru wykresu określa rozmiar samego obszaru wykresu, nie uwzględniając kresek podziałki i etykiet osi.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LayoutTargetType#Outer) - określa, że rozmiar obszaru wykresu określa rozmiar samego obszaru wykresu, kresek podziałki i etykiet osi.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**W jakich jednostkach zwracane są rzeczywiste wartości x, y, szerokość i wysokość?**  
W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Czym różni się Plot Area od Chart Area pod względem zawartości?**  
Plot Area jest regionem rysowania danych (serie, linie siatki, linie trendu itp.); Chart Area obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D Plot Area obejmuje również ściany/podłogę oraz osie.

**Jak interpretowane są wartości x, y, szerokość i wysokość Plot Area, gdy układ jest ustawiony ręcznie?**  
Są to ułamki (0–1) ogólnego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są ustawione przez Ciebie ułamki.

**Dlaczego pozycja Plot Area zmieniła się po dodaniu/przesunięciu legendy?**  
Legenda znajduje się w obszarze wykresu poza Plot Area, ale wpływa na układ i dostępną przestrzeń, dlatego Plot Area może przesunąć się, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w PowerPoint.)