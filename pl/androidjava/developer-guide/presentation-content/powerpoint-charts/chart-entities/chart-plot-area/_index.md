---
title: Dostosuj obszary wykresów prezentacji na Androidzie
linktitle: Obszar wykresu
type: docs
url: /pl/androidjava/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie. Popraw wygląd swoich slajdów bez wysiłku."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości.

Pokazuje również, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie swojego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobranie szerokości i wysokości obszaru wykresu**
Aspose.Slides dla Androida za pośrednictwem Java zapewnia prosty interfejs API dla.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z danymi domyślnymi.
4. Wywołaj metodę [IChart.validateChartLayout()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChart#validateChartLayout--) przed pobraniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewy) elementu wykresu względem lewego górnego rogu wykresu.
6. Pobiera rzeczywistą pozycję Y (góra) elementu wykresu względem lewego górnego rogu wykresu.
7. Pobiera rzeczywistą szerokość elementu wykresu.
8. Pobiera rzeczywistą wysokość elementu wykresu.

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

## **Ustaw tryb układu obszaru wykresu**
Aspose.Slides dla Androida za pośrednictwem Java zapewnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) i [**getLayoutTargetType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) zostały dodane do klasy [**ChartPlotArea**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ChartPlotArea) oraz interfejsu [**IChartPlotArea**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartPlotArea). Jeśli układ obszaru wykresu jest definiowany ręcznie, ta właściwość określa, czy układować obszar wykresu według jego wnętrza (bez osi i etykiet osi) czy według jego zewnętrza (z uwzględnieniem osi i etykiet osi). Dostępne są dwie możliwe wartości zdefiniowane w wyliczeniu [**LayoutTargetType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LayoutTargetType#Inner) – określa, że rozmiar obszaru wykresu decyduje o rozmiarze obszaru wykresu, nie uwzględniając znaczników podziałki i etykiet osi.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LayoutTargetType#Outer) – określa, że rozmiar obszaru wykresu decyduje o rozmiarze obszaru wykresu, znaczników podziałki i etykiet osi.

Przykładowy kod znajduje się poniżej.

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

**W jakich jednostkach zwracane są rzeczywiste x, rzeczywiste y, rzeczywista szerokość i rzeczywista wysokość?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Jak Obszar wykresu (Plot Area) różni się od Obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar wykresu (Plot Area) jest regionem rysowania danych (serie, linie siatki, linie trendu itp.); Obszar wykresu (Chart Area) zawiera elementy otaczające (tytuł, legendę itp.). W wykresach 3D Obszar wykresu obejmuje także ściany/podłogę oraz osie.

**Jak interpretowane są wartości x, y, szerokość i wysokość Obszaru wykresu, gdy układ jest ustawiony ręcznie?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są podane ułamki.

**Dlaczego po dodaniu/przeniesieniu legendy pozycja Obszaru wykresu się zmieniła?**

Legenda znajduje się w obszarze wykresu poza Obszarem wykresu, ale wpływa na układ i dostępną przestrzeń, dlatego Obszar wykresu może się przemieścić, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w programie PowerPoint.)