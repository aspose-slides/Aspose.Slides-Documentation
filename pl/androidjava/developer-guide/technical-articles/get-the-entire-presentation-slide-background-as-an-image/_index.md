---
title: Pobierz pełne tło slajdu z prezentacji jako obraz
linktitle: Pełne tło slajdu
type: docs
weight: 95
url: /pl/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- tło slajdu
- końcowe tło
- wyodrębnij tło
- pełne tło
- tło na obraz
- tło PPT
- tło PPTX
- tło ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Wyodrębniaj pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Android via Java, usprawniając przepływy pracy wizualnej."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie wzorca lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides for .NET. Ponieważ nie istnieje pojedyncza metoda wykonująca to zadanie, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu oraz konwersji uzyskanego tła slajdu na obraz.

## **Pobierz pełne tło slajdu**

Aspose.Slides for Android via Java nie udostępnia prostej metody do wyodrębnienia pełnego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki:
1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Przekonwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia pełne tło slajdu prezentacji jako obraz.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Czy złożone gradienty, tekstury lub wypełnienia obrazem z slajdu wzorca zostaną zachowane w powstałym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazowe i teksturowe zdefiniowane na slajdzie, układzie lub wzorcu. Jeśli trzeba odizolować wygląd od odziedziczonych wzorców, [ustaw własne tło](/slides/pl/androidjava/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do powstałego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/androidjava/watermark/) jako kształt lub obraz na [kopię slajdu](/slides/pl/androidjava/clone-slides/) (umieszczony za inną treścią), a następnie wyeksportować. Dzięki temu uzyskasz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub wzorca bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego wzorca lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/androidjava/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub wzorca.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazów?**

Funkcje renderowania są w pełni dostępne przy [ważnej licencji](/slides/pl/androidjava/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.