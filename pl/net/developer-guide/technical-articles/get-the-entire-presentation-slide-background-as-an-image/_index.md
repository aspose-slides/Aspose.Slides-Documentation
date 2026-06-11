---
title: Pobierz całe tło slajdu z prezentacji jako obraz
linktitle: Całe tło slajdu
type: docs
weight: 95
url: /pl/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- tło slajdu
- ostateczne tło
- wyodrębnić tło
- całe tło
- tło na obraz
- tło PPT
- tło PPTX
- tło ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wyodrębnia pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET, usprawniając przepływy wizualne."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie głównym lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides for .NET. Ponieważ nie istnieje pojedyncza metoda do tego zadania, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu i następnie konwersji uzyskanego tła slajdu na obraz.

## **Uzyskaj całe tło slajdu**

Aspose.Slides for .NET nie udostępnia prostej metody do wyodrębnienia całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki:
1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Przekształć sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **FAQ**

**Czy złożone gradienty, tekstury lub wypełnienia obrazem z slajdu głównego zostaną zachowane w wygenerowanym obrazie tła?**

Tak. Aspose.Slides renderuje gradientowe, obrazowe i teksturowane wypełnienia zdefiniowane na slajdzie, układzie lub głównym. Jeśli potrzebujesz odizolować wygląd od odziedziczonych szablonów, [ustaw własne tło](/slides/pl/net/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do wygenerowanego obrazu tła przed jego zapisaniem?**

Tak. Możesz dodać kształt lub obraz z [znakiem wodnym](/slides/pl/net/watermark/) na roboczej [kopii slajdu](/slides/pl/net/clone-slides/) (umieszczonej pod inną zawartością), a następnie wyeksportować. Dzięki temu uzyskasz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub szablonu bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego szablonu lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/net/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub szablonu.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazów?**

Funkcje renderowania są w pełni dostępne przy użyciu [ważnej licencji](/slides/pl/net/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.