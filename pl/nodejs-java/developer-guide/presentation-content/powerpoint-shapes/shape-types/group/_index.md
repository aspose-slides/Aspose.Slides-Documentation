---
title: Kształty grupowe w prezentacjach w JavaScript
linktitle: Grupa Kształtów
type: docs
weight: 40
url: /pl/nodejs-java/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- tekst alternatywny
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js via Java — szybki, krok po kroku przewodnik z darmowym kodem JavaScript."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami grupowymi w Aspose.Slides. Pokazuje, jak dodać kształt grupowy do slajdu, umieścić w nim kształty i zapisać zaktualizowaną prezentację. Demonstruje także, jak uzyskać dostęp do kształtów przechowywanych w grupie i odczytać ich wartości `AlternativeText`. Dodatkowo artykuł krótko opisuje powiązane możliwości kształtów grupowych, takie jak zagnieżdżone grupy, kolejność Z oraz opcje blokowania.

## **Dodawanie kształtu grupowego**
Aspose.Slides obsługuje pracę z kształtami grupowymi na slajdach. Ta funkcja pomaga programistom tworzyć bogatsze prezentacje. Aspose.Slides for Node.js via Java umożliwia dodawanie lub dostęp do kształtów grupowych. Można dodać kształty do utworzonego kształtu grupowego, aby je wypełnić lub uzyskać dostęp do dowolnej właściwości grupy. Aby dodać kształt grupowy do slajdu przy użyciu Aspose.Slides for Node.js via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu
1. Dodaj kształt grupowy do slajdu.
1. Dodaj kształty do dodanego kształtu grupowego.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje kształt grupowy do slajdu.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dostęp do kolekcji kształtów slajdu
    var slideShapes = sld.getShapes();
    // Dodawanie kształtu grupowego do slajdu
    var groupShape = slideShapes.addGroupShape();
    // Dodawanie kształtów wewnątrz dodanego kształtu grupowego
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Dodawanie ramki kształtu grupowego
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Zapisz plik PPTX na dysku
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do właściwości AltText**
Ten temat przedstawia proste kroki, wraz z przykładami kodu, dotyczące dodawania kształtu grupowego i uzyskiwania dostępu do właściwości AltText kształtów grupowych na slajdach. Aby uzyskać dostęp do AltText kształtu grupowego w slajdzie przy użyciu Aspose.Slides for Node.js via Java:

1. Zainstancjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) reprezentującą plik PPTX.
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu.
1. Uzyskaj dostęp do kształtu grupowego.
1. Wywołaj właściwość [getAlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

Poniższy przykład uzyskuje dostęp do alternatywnego tekstu kształtu grupowego.

```javascript
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Dostęp do kolekcji kształtów slajdu
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Dostęp do kształtu grupowego.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Dostęp do właściwości AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy obsługiwane jest zagnieżdżanie grup (grupa wewnątrz grupy)?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/) posiada metodę [getParentGroup](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getparentgroup/), która bezpośrednio wskazuje na obsługę hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj metody [getZOrderPosition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getzorderposition/) klasy [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/), aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę uniemożliwić przenoszenie/edycję/odgrupowywanie?**

Tak. Sekcja blokowania grupy jest dostępna poprzez [GroupShapeLock](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), co pozwala ograniczyć operacje na obiekcie.