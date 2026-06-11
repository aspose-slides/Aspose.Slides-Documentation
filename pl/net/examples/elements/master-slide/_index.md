---
title: Slajd główny
type: docs
weight: 30
url: /pl/net/examples/elements/master-slide/
keywords:
- slajd główny
- dodaj slajd główny
- dostęp do slajdu głównego
- usuń slajd główny
- nieużywany slajd główny
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj przykłady slajdów głównych w Aspose.Slides dla .NET: twórz, edytuj i stylizuj slajdy główne, elementy zastępcze i motywy w formatach PPT, PPTX i ODP przy użyciu czytelnego kodu C#."
---
Slajdy główne stanowią najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **Slajd główny** definiuje wspólne elementy projektu, takie jak tła, logotypy i formatowanie tekstu. **Slajdy układu** dziedziczą po slajdach głównych, a **zwykłe slajdy** dziedziczą po slajdach układu.

Ten artykuł pokazuje, jak tworzyć, modyfikować i zarządzać slajdami głównymi przy użyciu Aspose.Slides dla .NET.

## **Dodaj slajd główny**

Ten przykład pokazuje, jak utworzyć nowy slajd główny, klonując domyślny. Następnie dodaje baner z nazwą firmy do wszystkich slajdów poprzez dziedziczenie układu.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Sklonuj domyślny slajd główny.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Dodaj baner z nazwą firmy na górze slajdu głównego.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Przypisz nowy slajd główny do slajdu układu.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Przypisz slajd układu do pierwszego slajdu w prezentacji.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Uwaga 1:** Slajdy główne umożliwiają stosowanie spójnego brandingu lub wspólnych elementów projektowych we wszystkich slajdach. Wszelkie zmiany wprowadzone w slajdzie głównym będą automatycznie odzwierciedlane w zależnych slajdach układu i zwykłych slajdach.

> 💡 **Uwaga 2:** Wszystkie kształty lub formatowanie dodane do slajdu głównego są dziedziczone przez slajdy układu, a w konsekwencji przez wszystkie zwykłe slajdy korzystające z tych układów.  
> Poniższy obrazek ilustruje, jak pole tekstowe dodane na slajdzie głównym jest automatycznie renderowane na ostatecznym slajdzie.

![Przykład dziedziczenia slajdu głównego](master-slide-banner.png)

## **Uzyskaj dostęp do slajdu głównego**

Możesz uzyskać dostęp do slajdów głównych za pomocą kolekcji `Presentation.Masters`. Oto jak je pobrać i pracować z nimi:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Uzyskaj dostęp do pierwszego slajdu głównego.
    var firstMasterSlide = presentation.Masters[0];

    // Zmień typ tła.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Usuń slajd główny**

Slajdy główne można usunąć zarówno według indeksu, jak i za pomocą referencji.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Usuń slajd główny według indeksu.
    presentation.Masters.RemoveAt(0);

    // Usuń slajd główny według referencji.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Usuń nieużywane slajdy główne**

Niektóre prezentacje zawierają slajdy główne, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Usuń wszystkie nieużywane slajdy główne (nawet te oznaczone jako Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```