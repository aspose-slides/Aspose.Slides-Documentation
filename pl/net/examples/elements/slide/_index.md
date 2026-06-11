---
title: Slajd
type: docs
weight: 10
url: /pl/net/examples/elements/slide/
keywords:
- slajd
- dodaj slajd
- dostęp do slajdu
- indeks slajdu
- klonuj slajd
- przestawianie slajdów
- usuń slajd
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Kontroluj slajdy w Aspose.Slides dla .NET: twórz, klonuj, przestawiaj, zmieniaj rozmiar, ustawiaj tła i stosuj przejścia w C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł zawiera serię przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for .NET**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy przy użyciu klasy `Presentation`.

Każdy poniższy przykład zawiera krótkie wyjaśnienie, po którym następuje fragment kodu w C#.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw musisz wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Każdy slajd opiera się na układzie, który sam jest oparty na slajdzie głównym.
    // Użyj układu Blank, aby utworzyć nowy slajd.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Dodaj nowy pusty slajd przy użyciu wybranego układu.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Uwaga:** Każdy układ slajdu pochodzi z slajdu głównego, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obraz ilustruje, jak slajdy główne i ich powiązane układy są zorganizowane w programie PowerPoint.

![Relacja pomiędzy slajdem głównym a układem](master-layout-slide.png)

## **Uzyskaj dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów, używając ich indeksu, lub znaleźć indeks slajdu na podstawie odwołania. Jest to przydatne przy iteracji przez slajdy lub modyfikowaniu konkretnych slajdów.

```csharp
static void AccessSlide()
{
    // Domyślnie prezentacja jest tworzona z jednym pustym slajdem.
    using var presentation = new Presentation();

    // Dodaj kolejny pusty slajd.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Uzyskaj dostęp do slajdów według indeksu.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Pobierz indeks slajdu z referencji, a następnie uzyskaj do niego dostęp według indeksu.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Klonuj slajd**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```csharp
static void CloneSlide()
{
    // Domyślnie prezentacja zawiera jeden pusty slajd.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Sklonuj pierwszy slajd; zostanie dodany na koniec prezentacji.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Indeks sklonowanego slajdu to 1 (drugi slajd w prezentacji).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Zmień kolejność slajdów**

Możesz zmienić kolejność slajdów, przenosząc jeden na nowy indeks. W tym przypadku przenosimy sklonowany slajd na pierwszą pozycję.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Dodaj klon pierwszego slajdu (utworzony domyślnie).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Przenieś sklonowany slajd na pierwszą pozycję (pozostałe przesuwają się w dół).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Usuń slajd**

Aby usunąć slajd, po prostu odwołaj się do niego i wywołaj `Remove`. Ten przykład dodaje drugi slajd, a następnie usuwa pierwotny, pozostawiając tylko nowy.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Dodaj nowy pusty slajd oprócz domyślnego pierwszego slajdu.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Usuń pierwszy slajd; zostanie tylko nowo dodany slajd.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```