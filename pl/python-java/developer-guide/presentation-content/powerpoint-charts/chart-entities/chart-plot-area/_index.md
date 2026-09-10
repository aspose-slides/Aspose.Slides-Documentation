---
title: Dostosuj obszary wykresów w prezentacjach w Pythonie
linktitle: Obszar wykresu
type: docs
url: /pl/python-java/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via Java. Popraw wygląd swoich slajdów bez wysiłku."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości. Pokazuje również, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając [LayoutTargetType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layouttargettype/) do określenia, czy obszar wykresu jest obliczany na podstawie jego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Uzyskaj szerokość i wysokość obszaru wykresu**

Aspose.Slides for Python via Java udostępnia prosty interfejs API do odczytywania rzeczywistej pozycji i rozmiaru obszaru wykresu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) przed pobraniem rzeczywistych wartości.
5. Uzyskaj rzeczywistą pozycję X (lewo) elementu wykresu względem lewego górnego rogu wykresu.
6. Uzyskaj rzeczywistą pozycję Y (góra) elementu wykresu względem lewego górnego rogu wykresu.
7. Uzyskaj rzeczywistą szerokość elementu wykresu.
8. Uzyskaj rzeczywistą wysokość elementu wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Ustaw tryb układu obszaru wykresu**

Aspose.Slides for Python via Java udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Metody [setLayoutTargetType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) i [getLayoutTargetType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) są dostępne w klasie [ChartPlotArea](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartplotarea/). Jeśli układ obszaru wykresu jest definiowany ręcznie, to ustawienie określa, czy układać obszar wykresu wewnątrz (wyłączając osie i etykiety osi) czy na zewnątrz (włączając osie i etykiety osi). Są dwie możliwe wartości zdefiniowane w wyliczeniu [LayoutTargetType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layouttargettype/#Inner) określa, że rozmiar obszaru wykresu nie obejmuje znaczników podziałki i etykiet osi.
- [Outer](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layouttargettype/#Outer) określa, że rozmiar obszaru wykresu obejmuje znaczniki podziałki i etykiety osi.

Przykładowy kod podano poniżej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**W jakich jednostkach zwracane są rzeczywiste X, rzeczywiste Y, rzeczywista szerokość i rzeczywista wysokość?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Jak obszar wykresu (Plot Area) różni się od obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar wykresu (Plot Area) jest regionem rysowania danych (serie, linie siatki, linie trendu itp.); obszar wykresu (Chart Area) obejmuje otaczające elementy (tytuł, legendę itp.). W wykresach 3D obszar wykresu (Plot Area) zawiera także ściany/podłogę oraz osie.

**Jak interpretowane są wartości X, Y, szerokość i wysokość obszaru wykresu (Plot Area) przy ręcznym układzie?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są podane przez Ciebie ułamki.

**Dlaczego po dodaniu lub przeniesieniu legendy pozycja obszaru wykresu (Plot Area) się zmieniła?**

Legenda znajduje się w obszarze wykresu poza obszarem wykresu (Plot Area), ale wpływa na układ i dostępną przestrzeń, dlatego obszar wykresu może się przemieszczać, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w programie PowerPoint.)