---
title: Uzyskaj pełne tło slajdu z prezentacji jako obraz
linktitle: Pełne tło slajdu
type: docs
weight: 95
url: /pl/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slajd
- tło
- tło slajdu
- ostateczne tło
- tło do obrazu
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w .NET, usprawniając przepływy wizualne."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie nadrzędnym lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić pełne tło slajdu jako obraz przy użyciu Aspose.Slides. Ponieważ nie istnieje pojedyncza metoda dla tego zadania, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu i następnie konwersji uzyskanego tła slajdu na obraz.

## **Uzyskaj pełne tło slajdu**

Aspose.Slides for Python nie udostępnia prostej metody do wyodrębnienia pełnego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki:
1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Przekształć sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia pełne tło slajdu prezentacji jako obraz.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Czy skomplikowane gradienty, tekstury lub wypełnienia obrazami z motywu nadrzędnego zostaną zachowane w wygenerowanym obrazie tła?**

Tak. Aspose.Slides renderuje gradienty, obrazy i tekstury definiowane na slajdzie, układzie lub motywie nadrzędnym. Jeśli potrzebujesz odizolować wygląd od odziedziczonych motywów, [set an own background](/slides/pl/python-net/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do wygenerowanego obrazu tła przed jego zapisaniem?**

Tak. Możesz [add a watermark](/slides/pl/python-net/watermark/) kształt lub obraz na roboczej [copy of the slide](/slides/pl/python-net/clone-slides/) (umieszczony za inną zawartością), a następnie wyeksportować. Dzięki temu uzyskasz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub motywu nadrzędnego bez powiązania go z istniejącym slajdem?**

Tak. Dostęp do żądanego motywu nadrzędnego lub układu, zastosowanie go do [temporary slide](/slides/pl/python-net/clone-slides/) o wymaganym rozmiarze i eksport tego slajdu pozwoli uzyskać tło pochodzące z tego układu lub motywu.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazu?**

Funkcje renderowania są w pełni dostępne z [valid license](/slides/pl/python-net/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem masowych eksportów.