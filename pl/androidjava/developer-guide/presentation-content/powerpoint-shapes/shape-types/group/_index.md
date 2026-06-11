---
title: "Kształty grupowe w prezentacji na Androidzie"
linktitle: "Grupa Kształtów"
type: docs
weight: 40
url: /pl/androidjava/group/
keywords:
- "grupa kształtów"
- "grupa kształtów"
- "dodaj grupę"
- "tekst alternatywny"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida — szybki, krok po kroku przewodnik z darmowym kodem Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupami kształtów w Aspose.Slides. Pokazuje, jak dodać grupę kształtów do slajdu, umieścić w niej kształty oraz zapisać zaktualizowaną prezentację. Demonstracja obejmuje również dostęp do kształtów przechowywanych wewnątrz grupy i odczyt ich wartości `AlternativeText`. Dodatkowo artykuł krótko opisuje powiązane możliwości grupy kształtów, takie jak zagnieżdżone grupy, kolejność Z i opcje blokowania.

## **Dodaj grupę kształtów**
Aspose.Slides obsługuje pracę z grupami kształtów na slajdach. Ta funkcja pomaga programistom tworzyć bogatsze prezentacje. Aspose.Slides for Android via Java umożliwia dodawanie lub dostęp do grup kształtów. Można dodawać kształty do dodanej grupy, aby ją wypełnić, lub uzyskać dostęp do dowolnej jej właściwości. Aby dodać grupę kształtów do slajdu przy użyciu Aspose.Slides for Android via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu
1. Dodaj grupę kształtów do slajdu.
1. Dodaj kształty do dodanej grupy kształtów.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupę kształtów do slajdu.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dostęp do kolekcji kształtów slajdów
    IShapeCollection slideShapes = sld.getShapes();

    // Dodawanie grupy kształtów do slajdu
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Dodawanie kształtów wewnątrz dodanej grupy kształtów
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Dodawanie ramki grupy kształtów
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Zapisz plik PPTX na dysk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do właściwości AltText**
Ten temat przedstawia proste kroki, wraz z przykładami kodu, dotyczące dodawania grupy kształtów i uzyskiwania dostępu do właściwości AltText grup kształtów na slajdach. Aby uzyskać dostęp do AltText grupy kształtów w slajdzie przy użyciu Aspose.Slides for Android via Java:

1. Zainicjalizuj klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), która reprezentuje plik PPTX.
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdów.
1. Uzyskaj dostęp do grupy kształtów.
1. Uzyskaj dostęp do właściwości [AlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getAlternativeText--).

Poniższy przykład uzyskuje dostęp do alternatywnego tekstu grupy kształtów.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Dostęp do kolekcji kształtów slajdów
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Dostęp do grupy kształtów.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Dostęp do właściwości AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy obsługiwane jest zagnieżdżone grupowanie (grupa wewnątrz grupy)?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/groupshape/) posiada metodę [getParentGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getParentGroup--) , która bezpośrednio wskazuje obsługę hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj metody [getZOrderPosition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getZOrderPosition--) klasy [GroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/groupshape/), aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę zapobiec przemieszczaniu/edycji/rozgrupowywaniu?**

Tak. Sekcja blokady grupy jest udostępniona poprzez [getGroupShapeLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--), co pozwala ograniczyć operacje na obiekcie.