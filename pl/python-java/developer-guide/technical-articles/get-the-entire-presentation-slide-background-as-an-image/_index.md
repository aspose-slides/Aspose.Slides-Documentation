---
title: Pobierz pełne tło slajdu z prezentacji jako obraz
linktitle: Pełne tło slajdu
type: docs
weight: 95
url: /pl/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- tło slajdu
- ostateczne tło
- wyodrębnij tło
- pełne tło
- tło do obrazu
- tło PPT
- tło PPTX
- tło ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java, upraszczając przepływy wizualne."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na master‑slajdzie lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides for Python via Java. Ponieważ nie istnieje pojedyncza metoda umożliwiająca to zadanie, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu oraz konwersji powstałego tła slajdu na obraz.

## **Uzyskaj pełne tło slajdu**

Aspose.Slides for Python via Java nie udostępnia prostej metody do wyodrębnienia całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Konwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy skomplikowane gradienty, tekstury lub wypełnienia obrazem z master‑slajdu zostaną zachowane w powstałym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazkowe i teksturowane zdefiniowane na slajdzie, układzie lub masterze. Jeśli musisz odizolować wygląd od dziedziczonych masterów, [ustaw własne tło](/slides/pl/python-java/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do powstałego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/python-java/watermark/) jako kształt lub obraz na roboczej [kopii slajdu](/slides/pl/python-java/clone-slides/) (umieszczonej za inną zawartością), a następnie wyeksportować. To pozwala wygenerować obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub mastera bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego mastera lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/python-java/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub mastera.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazów?**

Funkcje renderowania są w pełni dostępne przy [ważnej licencji](/slides/pl/python-java/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.