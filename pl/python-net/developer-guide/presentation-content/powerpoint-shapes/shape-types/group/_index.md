---
title: Grupowe kształty prezentacji w Pythonie
linktitle: Grupa Kształtów
type: docs
weight: 40
url: /pl/python-net/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- alternatywny tekst
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint i dokumentach OpenDocument przy użyciu Aspose.Slides dla Pythona — szybki, krok po kroku przewodnik z darmowym kodem."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupowymi kształtami w Aspose.Slides. Pokazuje, jak dodać grupowy kształt do slajdu, umieścić w nim kształty oraz zapisać zaktualizowaną prezentację. Demonstruje również, jak uzyskać dostęp do kształtów przechowywanych w grupie i odczytać ich wartości `alternative_text`. Dodatkowo artykuł krótko opisuje powiązane możliwości grupowych kształtów, takie jak zagnieżdżone grupy, kolejność Z oraz opcje blokowania.

## **Dodawanie grupowych kształtów**

Aspose.Slides obsługuje pracę z grupowymi kształtami na slajdzie. Ta funkcja pozwala tworzyć bogatsze prezentacje, traktując wiele kształtów jako pojedynczy obiekt. Możesz dodawać nowe grupowe kształty, uzyskiwać dostęp do istniejących, wypełniać je podrzędnymi kształtami oraz odczytywać lub modyfikować ich właściwości. Aby dodać grupowy kształt do slajdu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu po indeksie.
3. Dodaj [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/) do slajdu.
4. Dodaj kształty do nowego grupowego kształtu.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład pokazuje, jak dodać grupowy kształt do slajdu.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj grupowy kształt do slajdu.
    group_shape = slide.shapes.add_group_shape()

    # Dodaj kształty wewnątrz grupowego kształtu.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Zapisz plik PPTX na dysku.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do właściwości Alt Text**

Ta sekcja wyjaśnia, jak odczytać Alt Text kształtów zawartych w grupowym kształcie na slajdzie przy użyciu Aspose.Slides. Aby uzyskać dostęp do Alt Text kształtów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) reprezentującej plik PPTX.
2. Uzyskaj referencję do slajdu po jego indeksie.
3. Uzyskaj dostęp do kolekcji kształtów slajdu.
4. Uzyskaj dostęp do [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/).
5. Odczytaj właściwość Alt Text.

Poniższy przykład pobiera Alt Text kształtów zawartych w grupowych kształtach.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby otworzyć plik PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Uzyskaj dostęp do grupowego kształtu.
            for child_shape in shape.shapes:
                # Uzyskaj dostęp do właściwości Alt Text.
                print(child_shape.alternative_text)
```

## **FAQ**

**Czy grupowanie zagnieżdżone (grupa wewnątrz grupy) jest obsługiwane?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/) posiada właściwość [parent_group](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/parent_group/), która bezpośrednio wskazuje obsługę hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj właściwości [z_order_position](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/z_order_position/) grupy [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/), aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę zapobiec przesuwaniu/edycji/rozgrupowywaniu?**

Tak. Sekcja blokady grupy jest udostępniona poprzez [group_shape_lock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/group_shape_lock/), co pozwala ograniczyć operacje na obiekcie.