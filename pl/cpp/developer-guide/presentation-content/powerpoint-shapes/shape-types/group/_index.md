---
title: Kształty grupowe w prezentacji w C++
linktitle: Grupa kształtów
type: docs
weight: 40
url: /pl/cpp/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- tekst alternatywny
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++ — szybki, krok po kroku przewodnik z darmowym kodem C++."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupowymi kształtami w Aspose.Slides. Pokazuje, jak dodać grupowy kształt do slajdu, umieścić w nim kształty i zapisać zaktualizowaną prezentację. Demonstruje także, jak uzyskać dostęp do kształtów przechowywanych wewnątrz grupy i odczytać ich wartości `AlternativeText`. Dodatkowo artykuł krótko omawia powiązane możliwości grupowych kształtów, takie jak zagnieżdżone grupy, kolejność Z oraz opcje blokowania.

## **Dodaj kształt grupowy**
Aspose.Slides obsługuje pracę z grupowymi kształtami na slajdach. Ta funkcja pomaga programistom tworzyć bardziej zaawansowane prezentacje. Aspose.Slides for C++ umożliwia dodawanie lub dostęp do grupowych kształtów. Można dodawać kształty do utworzonej grupy, aby ją wypełnić lub uzyskać dostęp do dowolnej właściwości grupowego kształtu. Aby dodać grupowy kształt do slajdu przy użyciu Aspose.Slides for C++:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj referencję do slajdu, używając jego indeksu
1. Dodaj grupowy kształt do slajdu.
1. Dodaj kształty do utworzonego grupowego kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Przykład poniżej dodaje grupowy kształt do slajdu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Dostęp do właściwości AltText**
Ten temat przedstawia proste kroki, wraz z przykładami kodu, pozwalające dodać grupowy kształt i uzyskać dostęp do właściwości AltText grupowych kształtów na slajdach. Aby uzyskać dostęp do AltText grupowego kształtu w slajdzie przy użyciu Aspose.Slides for C++:

1. Zainstancjuj klasę `Presentation` reprezentującą plik PPTX.
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu.
1. Uzyskaj dostęp do grupowego kształtu.
1. Uzyskaj dostęp do właściwości AltText.

Przykład poniżej uzyskuje dostęp do tekstu alternatywnego grupowego kształtu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Czy obsługiwane jest zagnieżdżanie grup (grupa wewnątrz grupy)?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/groupshape/) posiada metodę [get_ParentGroup](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_parentgroup/), która bezpośrednio wskazuje na wsparcie hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj właściwości [Z-Order position](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_zorderposition/) grupowego kształtu [GroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/groupshape/), aby sprawdzić jego pozycję w stosie wyświetlania.

**Czy mogę zapobiec przemieszczaniu/edycji/rozdzielaniu grupy?**

Tak. Sekcja blokad grupy jest udostępniona przez [get_GroupShapeLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/groupshape/get_groupshapelock/), co pozwala ograniczyć operacje na obiekcie.