---
title: Grupowe kształty prezentacji w .NET
linktitle: Grupa kształtów
type: docs
weight: 40
url: /pl/net/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- alternatywny tekst
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides for .NET — szybki, krok po kroku przewodnik z darmowym kodem C#."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupowymi kształtami w Aspose.Slides. Pokazuje, jak dodać grupowy kształt do slajdu, umieścić w nim kształty i zapisać zaktualizowaną prezentację. Demonstruje także, jak uzyskać dostęp do kształtów przechowywanych wewnątrz grupy i odczytać ich wartości `AlternativeText`. Dodatkowo artykuł krótko opisuje powiązane możliwości grupowych kształtów, takie jak grupy zagnieżdżone, kolejność Z oraz opcje blokowania.

## **Dodawanie grupowego kształtu**
Aspose.Slides obsługuje pracę z grupowymi kształtami na slajdach. Funkcja ta pomaga programistom tworzyć bogatsze prezentacje. Aspose.Slides for .NET umożliwia dodawanie lub dostęp do grupowych kształtów. Można dodawać kształty do dodanej grupy, aby ją wypełnić lub uzyskać dostęp do dowolnej właściwości grupowego kształtu. Aby dodać grupowy kształt do slajdu przy użyciu Aspose.Slides for .NET:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu
1. Dodaj grupowy kształt do slajdu.
1. Dodaj kształty do dodanej grupy.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```c#
// Utwórz instancję klasy Presentation 
using (Presentation pres = new Presentation())
{
    // Pobierz pierwszy slajd 
    ISlide sld = pres.Slides[0];

    // Uzyskiwanie kolekcji kształtów slajdów 
    IShapeCollection slideShapes = sld.Shapes;

    // Dodawanie grupowego kształtu do slajdu 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Dodawanie kształtów wewnątrz dodanej grupy 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Dodawanie ramki grupowego kształtu 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Zapisz plik PPTX na dysku 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Dostęp do właściwości AltText**
Temat ten przedstawia proste kroki, wraz z przykładami kodu, dotyczące dodawania grupowego kształtu i uzyskiwania dostępu do właściwości AltText grupowych kształtów na slajdach. Aby uzyskać dostęp do AltText grupowego kształtu w slajdzie przy użyciu Aspose.Slides for .NET:

1. Zainstaluj klasę `Presentation`, która reprezentuje plik PPTX.
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu.
1. Uzyskaj dostęp do grupowego kształtu.
1. Uzyskaj dostęp do właściwości AltText.

Poniższy przykład odczytuje alternatywny tekst grupowego kształtu.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation("AltText.pptx");

// Pobierz pierwszy slajd
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Uzyskiwanie kolekcji kształtów slajdów
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Uzyskiwanie grupowego kształtu.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Uzyskiwanie właściwości AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**Czy obsługiwane jest grupowanie zagnieżdżone (grupa wewnątrz grupy)?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/groupshape/) ma właściwość [ParentGroup](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/parentgroup/), która bezpośrednio wskazuje na obsługę hierarchii (grupa może być dzieckiem innej grupy).

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj właściwości [ZOrderPosition](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/zorderposition/) klasy [GroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/groupshape/), aby sprawdzić jej pozycję w stosie wyświetlania.

**Czy mogę zapobiec przenoszeniu/edycji/rozgrupowywaniu?**

Tak. Sekcja blokady grupy jest udostępniona przez [GroupShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/groupshape/groupshapelock/), co pozwala ograniczyć operacje na obiekcie.