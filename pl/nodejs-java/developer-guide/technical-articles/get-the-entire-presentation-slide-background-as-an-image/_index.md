---
title: Pobierz całe tło slajdu z prezentacji jako obraz
linktitle: Całe tło slajdu
type: docs
weight: 95
url: /pl/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- tło slajdu
- ostateczne tło
- wyodrębnij tło
- pełne tło
- tło na obraz
- tło PPT
- tło PPTX
- tło ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java, usprawniając przepływy pracy wizualnej."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może być zbudowane z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie podstawowym lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides. Ponieważ nie istnieje pojedyncza metoda umożliwiająca to zadanie, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu oraz konwersji powstałego tła slajdu na obraz.

## **Pobierz całe tło slajdu**

Aspose.Slides for Node.js via Java nie oferuje prostej metody wyodrębnienia całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki, aby to zrobić:
1. Wczytaj prezentację używając klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Pobierz rozmiar slajdu z prezentacji.
3. Wybierz slajd.
4. Utwórz tymczasową prezentację.
5. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
6. Sklonuj wybrany slajd do tymczasowej prezentacji.
7. Usuń kształty ze sklonowanego slajdu.
8. Konwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **FAQ**

**Czy skomplikowane gradienty, tekstury lub wypełnienia obrazem z slajdu podstawowego zostaną zachowane w wygenerowanym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazami i teksturami zdefiniowane na slajdzie, układzie lub masterze. Jeśli potrzebujesz odizolować wygląd od odziedziczonych masterów, [ustaw własne tło](/slides/pl/nodejs-java/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do wygenerowanego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/nodejs-java/watermark/) jako kształt lub obraz na roboczej [kopii slajdu](/slides/pl/nodejs-java/clone-slides/) (umieszczonej za inną treścią), a następnie wyeksportować. Dzięki temu uzyskasz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub mastera bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego mastera lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/nodejs-java/clone-slides/) o potrzebnym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub mastera.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazów?**

Funkcje renderowania są w pełni dostępne przy użyciu [ważnej licencji](/slides/pl/nodejs-java/licensing/). W trybie ewaluacyjnym wynik może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.