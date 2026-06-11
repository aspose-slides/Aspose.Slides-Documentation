---
title: Uzyskaj całe tło slajdu z prezentacji jako obraz
linktitle: Całe tło slajdu
type: docs
weight: 95
url: /pl/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "Wyodrębnij pełne tła slajdów jako obrazy z prezentacji PowerPoint i OpenDocument, używając Aspose.Slides dla C++, usprawniając przepływy pracy wizualnej."
---
## **Przegląd**

W prezentacjach PowerPoint tło slajdu może składać się z wielu elementów, w tym obrazu tła slajdu, motywu prezentacji, schematu kolorów oraz obiektów umieszczonych na głównym slajdzie lub slajdzie układu.

Ten artykuł pokazuje, jak wyodrębnić całe tło slajdu jako obraz przy użyciu Aspose.Slides. Ponieważ nie istnieje pojedyncza metoda dla tego zadania, podejście polega na sklonowaniu wybranego slajdu do tymczasowej prezentacji, usunięciu kształtów ze slajdu oraz konwersji powstałego tła slajdu na obraz.

## **Uzyskaj całe tło slajdu**

Aspose.Slides dla C++ nie udostępnia prostej metody wyodrębnienia całego tła slajdu prezentacji jako obrazu, ale możesz wykonać poniższe kroki, aby to zrobić:
1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz rozmiar slajdu z prezentacji.
1. Wybierz slajd.
1. Utwórz tymczasową prezentację.
1. Ustaw ten sam rozmiar slajdu w tymczasowej prezentacji.
1. Sklonuj wybrany slajd do tymczasowej prezentacji.
1. Usuń kształty ze sklonowanego slajdu.
1. Przekonwertuj sklonowany slajd na obraz.

Poniższy przykład kodu wyodrębnia całe tło slajdu prezentacji jako obraz.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **FAQ**

**Czy złożone gradienty, tekstury lub wypełnienia obrazem z głównego slajdu zostaną zachowane w wygenerowanym obrazie tła?**

Tak. Aspose.Slides renderuje wypełnienia gradientowe, obrazkowe i teksturowe zdefiniowane na slajdzie, układzie lub głównym slajdzie. Jeśli potrzebujesz odizolować wygląd od odziedziczonych masterów, [ustaw własne tło](/slides/pl/cpp/presentation-background/) na bieżącym slajdzie przed eksportem.

**Czy mogę dodać znak wodny do wygenerowanego obrazu tła przed jego zapisaniem?**

Tak. Możesz [dodać znak wodny](/slides/pl/cpp/watermark/) w postaci kształtu lub obrazu na roboczej [kopii slajdu](/slides/pl/cpp/clone-slides/) (umieszczonej za inną treścią), a następnie wyeksportować. Dzięki temu uzyskasz obraz tła z wtopionym znakiem wodnym.

**Czy mogę uzyskać tło dla konkretnego układu lub mastera bez powiązania go z istniejącym slajdem?**

Tak. Uzyskaj dostęp do żądanego mastera lub układu, zastosuj go do [tymczasowego slajdu](/slides/pl/cpp/clone-slides/) o wymaganym rozmiarze i wyeksportuj ten slajd, aby otrzymać tło pochodzące z tego układu lub mastera.

**Czy istnieją ograniczenia licencyjne wpływające na eksport obrazu?**

Funkcje renderowania są w pełni dostępne przy użyciu [ważnej licencji](/slides/pl/cpp/licensing/). W trybie ewaluacyjnym wyjście może zawierać ograniczenia, takie jak znak wodny. Aktywuj licencję raz na proces przed uruchomieniem eksportu wsadowego.