---
title: Grupowe kształty prezentacji w Javie
linktitle: Grupa Kształtów
type: docs
weight: 40
url: /pl/java/group/
keywords:
- grupa kształtów
- grupa kształtów
- dodaj grupę
- tekst alternatywny
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy — szybki, krok po kroku poradnik z darmowym kodem Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupami kształtów w Aspose.Slides. Pokazuje, jak dodać grupę kształtów do slajdu, umieścić w niej kształty oraz zapisać zaktualizowaną prezentację. Demonstracja obejmuje także dostęp do kształtów przechowywanych w grupie i odczyt ich wartości `AlternativeText`. Dodatkowo artykuł krótko opisuje powiązane możliwości grupy kształtów, takie jak zagnieżdżone grupy, kolejność Z oraz opcje blokowania.

## **Dodaj grupę kształtów**
Aspose.Slides obsługuje pracę z grupami kształtów na slajdach. Ta funkcja pomaga programistom tworzyć bardziej bogate prezentacje. Aspose.Slides for Java umożliwia dodawanie i dostęp do grup kształtów. Można dodawać kształty do utworzonej grupy, aby ją wypełnić lub uzyskać dostęp do dowolnej właściwości grupy kształtów. Aby dodać grupę kształtów do slajdu przy użyciu Aspose.Slides for Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu, używając jego indeksu
3. Dodaj grupę kształtów do slajdu.
4. Dodaj kształty do utworzonej grupy.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupę kształtów do slajdu.

```java
// Utwórz klasę Presentation
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

    // Zapisz plik PPTX na dysku
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uzyskaj dostęp do właściwości AltText**
Ten temat przedstawia proste kroki, wraz z przykładami kodu, dotyczące dodawania grupy kształtów i uzyskiwania dostępu do właściwości AltText grup kształtów na slajdach. Aby uzyskać dostęp do AltText grupy kształtów w slajdzie przy użyciu Aspose.Slides for Java:

1. Zainstaluj/utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) reprezentującej plik PPTX.
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kolekcji kształtów slajdów.
4. Uzyskaj dostęp do grupy kształtów.
5. Uzyskaj dostęp do właściwości [AlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getAlternativeText--).

Poniższy przykład uzyskuje dostęp do alternatywnego tekstu grupy kształtów.

```java
// Utwórz klasę Presentation reprezentującą plik PPTX
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

Tak. [GroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/groupshape/) posiada metodę [getParentGroup](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getParentGroup--) , która bezpośrednio wskazuje na obsługę hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj metody [getZOrderPosition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getZOrderPosition--) klasy [GroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/groupshape/) , aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę zapobiec przemieszczaniu/edycji/rozgrupowywaniu?**

Tak. Sekcja blokady grupy jest dostępna poprzez [GroupShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/groupshape/#getGroupShapeLock--) , co umożliwia ograniczenie operacji na obiekcie.