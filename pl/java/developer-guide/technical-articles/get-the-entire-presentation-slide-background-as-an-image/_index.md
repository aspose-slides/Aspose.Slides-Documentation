---
title: Uzyskaj całe tło slajdu z prezentacji jako obraz
linktitle: Całe tło slajdu
type: docs
weight: 95
url: /pl/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- tło slajdu
- ostateczne tło
- wyodrębnij tło
- całe tło
- tło na obraz
- tło PPT
- tło PPTX
- tło ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy, upraszczając przepływy pracy wizualnej."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może powstawać z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie wzorca lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides dla .NET. Ponieważ nie istnieje jedyna metoda na to zadanie, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów slajdu, a następnie konwersji uzyskanego tła slajdu na obraz.

## **Uzyskaj całe tło slajdu**

Aspose.Slides for Java nie udostępnia prostej metody wyodrębniania całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki, aby to zrobić:
1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Skonwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Czy złożone gradienty, tekstury lub wypełnienia obrazem z slajdu wzorca zostaną zachowane w powstałym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazowe i teksturowe zdefiniowane na slajdzie, układzie lub wzorcu. Jeśli potrzebujesz odizolować wygląd od dziedziczonych wzorców, [ustaw własne tło](/slides/pl/java/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do powstałego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/java/watermark/) jako kształt lub obraz na roboczej [kopii slajdu](/slides/pl/java/clone-slides/) (umieszczonej za inną zawartością), a następnie wyeksportować. Dzięki temu wygenerujesz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub wzorca bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego wzorca lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/java/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby uzyskać tło pochodzące z tego układu lub wzorca.

**Czy istnieją ograniczenia licencyjne, które wpływają na eksport obrazu?**

Funkcje renderowania są w pełni dostępne przy [ważnej licencji](/slides/pl/java/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem masowych eksportów.