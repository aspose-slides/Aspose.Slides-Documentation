---
title: Pobierz całe tło slajdu z prezentacji jako obraz
linktitle: Całe tło slajdu
type: docs
weight: 95
url: /pl/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP via Java, usprawniając przepływy pracy wizualnej."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na slajdzie głównym lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides. Ponieważ nie istnieje jedyna metoda dla tego zadania, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów slajdu i konwersji otrzymanego tła slajdu na obraz.

## **Uzyskaj całe tło slajdu**

Aspose.Slides for PHP via Java nie udostępnia prostego sposobu na wyodrębnienie całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki:
1. Załaduj prezentację przy użyciu klasy [Prezentacja](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Przekonwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **FAQ**

**Czy złożone gradienty, tekstury lub wypełnienia obrazem z slajdu głównego zostaną zachowane w wynikowym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazowe i teksturę zdefiniowane na slajdzie, układzie lub masterze. Jeśli potrzebujesz odizolować wygląd od odziedziczonych masterów, [ustaw własne tło](/slides/pl/php-java/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do wynikowego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/php-java/watermark/) jako kształt lub obraz na [kopii slajdu](/slides/pl/php-java/clone-slides/) (umieszczonej za inną treścią), a następnie dokonać eksportu. Dzięki temu uzyskasz obraz tła z wbudowanym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub mastera bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do pożądanego mastera lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/php-java/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub mastera.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazu?**

Funkcje renderowania są w pełni dostępne przy [ważnej licencji](/slides/pl/php-java/licensing/). W trybie ewaluacji wyjście może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.