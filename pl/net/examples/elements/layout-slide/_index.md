---
title: Układ slajdu
type: docs
weight: 20
url: /pl/net/examples/elements/layout-slide/
keywords:
- układ slajdu
- dodaj układ slajdu
- dostęp do układu slajdu
- usuń układ slajdu
- nieużywany układ slajdu
- klonuj układ slajdu
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Główne układy slajdów w Aspose.Slides dla .NET: wybieraj, stosuj i dostosowuj układy slajdów, miejsca wstawiania i szablony z przykładami C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak pracować z **Układami slajdów** w Aspose.Slides dla .NET. Układ slajdu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać układy slajdów, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Dodaj układ slajdu**

Możesz utworzyć własny układ slajdu, aby zdefiniować wielokrotnie wykorzystywane formatowanie. Na przykład możesz dodać pole tekstowe, które pojawi się we wszystkich slajdach korzystających z tego układu.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Utwórz układ slajdu z pustym typem układu i własną nazwą.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Dodaj pole tekstowe do układu slajdu.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Dodaj dwa slajdy używając tego układu; oba odziedziczą tekst z układu.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Uwaga 1:** Układy slajdów działają jako szablony dla pojedynczych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.
> 
> 💡 **Uwaga 2:** Gdy dodajesz kształty lub tekst do układu slajdu, wszystkie slajdy oparte na tym układzie będą automatycznie wyświetlały tę wspólną treść.  
> Zrzut ekranu poniżej pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego układu slajdu.

![Slajdy dziedziczące treść układu](layout-slide-result.png)

## **Uzyskaj dostęp do układu slajdu**

Układy slajdów można uzyskać przez indeks lub typ układu (np. `Blank`, `Title`, `SectionHeader` itp.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Uzyskaj dostęp do układu slajdu według indeksu.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Uzyskaj dostęp do układu slajdu według typu.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Usuń układ slajdu**

Możesz usunąć konkretny układ slajdu, jeśli nie jest już potrzebny.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Pobierz układ slajdu według typu i usuń go.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Usuń nieużywane układy slajdów**

Aby zmniejszyć rozmiar prezentacji, możesz chcieć usunąć układy slajdów, które nie są używane przez żadne zwykłe slajdy.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Automatycznie usuwa wszystkie układy slajdów, które nie są używane przez żaden slajd.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Klonuj układ slajdu**

Możesz powielić układ slajdu, używając metody `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Pobierz istniejący układ slajdu według typu.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Sklonuj układ slajdu na koniec kolekcji układów slajdów.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Podsumowanie:** Układy slajdów to potężne narzędzia do zarządzania spójnym formatowaniem w całej prezentacji. Aspose.Slides zapewnia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją układów slajdów.