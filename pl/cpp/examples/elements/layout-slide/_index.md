---
title: Slajd układu
type: docs
weight: 20
url: /pl/cpp/examples/elements/layout-slide/
keywords:
- przykład kodu
- slajd układu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Mistrz slajdów układu w Aspose.Slides dla C++: wybieraj, stosuj i dostosowuj układy slajdów, placeholdery i mastery przy użyciu przykładów C++ dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak pracować z **Layout Slides** w Aspose.Slides for C++. Slajd układu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać slajdy układu, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Dodaj slajd układu**

Możesz utworzyć własny slajd układu, aby zdefiniować wielokrotnie używalne formatowanie. Na przykład możesz dodać pole tekstowe, które pojawia się na wszystkich slajdach używających tego układu.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Utwórz slajd układu z pustym typem układu i niestandardową nazwą.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Dodaj pole tekstowe do slajdu układu.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Dodaj dwa slajdy przy użyciu tego układu; oba odziedziczą tekst z układu.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Slajdy układu pełnią rolę szablonów dla poszczególnych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Nota 2:** Gdy dodasz kształty lub tekst do slajdu układu, wszystkie slajdy oparte na tym układzie automatycznie wyświetlą tę wspólną treść.  
> Zrzut ekranu poniżej pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego slajdu układu.

![Slajdy dziedziczące zawartość układu](layout-slide-result.png)

## **Uzyskaj dostęp do slajdu układu**

Slajdy układu można uzyskać przez indeks lub typ układu (np. `Blank`, `Title`, `SectionHeader` itp.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Uzyskaj dostęp do slajdu układu według indeksu.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Uzyskaj dostęp do slajdu układu według typu.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Usuń slajd układu**

Możesz usunąć określony slajd układu, jeśli nie jest już potrzebny.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Pobierz slajd układu według typu i usuń go.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Usuń nieużywane slajdy układu**

Aby zmniejszyć rozmiar prezentacji, możesz usunąć slajdy układu, które nie są używane przez żadne zwykłe slajdy.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Automatycznie usuwa wszystkie slajdy układu, które nie są odwoływane przez żaden slajd.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Klonuj slajd układu**

Możesz powielić slajd układu przy użyciu metody `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Pobierz istniejący slajd układu według typu.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Sklonuj slajd układu na koniec kolekcji slajdów układu.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Podsumowanie:** Slajdy układu są potężnym narzędziem do zarządzania spójnym formatowaniem na slajdach. Aspose.Slides umożliwia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją slajdów układu.