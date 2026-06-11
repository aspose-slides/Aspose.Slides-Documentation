---
title: Slajd
type: docs
weight: 10
url: /pl/cpp/examples/elements/slide/
keywords:
- przykład kodu
- slajd
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj slajdami w Aspose.Slides for C++: twórz, klonuj, zmieniaj kolejność, zmieniaj rozmiar, ustawiaj tła i stosuj przejścia w C++ dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł zawiera serię przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for C++**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy przy użyciu klasy `Presentation`.

Każdy przykład poniżej zawiera krótkie wyjaśnienie oraz fragment kodu w C++.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw musisz wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Uwaga:** Każdy układ slajdu jest pochodną slajdu nadrzędnego, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obraz przedstawia, jak slajdy nadrzędne i ich powiązane układy są zorganizowane w programie PowerPoint.

![Relacja między szablonem a układem](master-layout-slide.png)

## **Dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów używając ich indeksu lub znaleźć indeks slajdu na podstawie odwołania. Jest to przydatne przy iteracji lub modyfikacji konkretnych slajdów.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Dodaj kolejny pusty slajd.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Dostęp do slajdów według indeksu.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Pobierz indeks slajdu z referencji, a następnie uzyskaj dostęp do niego według indeksu.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Sklonuj slajd**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Zmień kolejność slajdów**

Możesz zmienić kolejność slajdów, przenosząc jeden na nowy indeks. W tym przypadku przenosimy sklonowany slajd na pierwszą pozycję.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Usuń slajd**

Aby usunąć slajd, po prostu odwołaj się do niego i wywołaj `Remove`. Ten przykład dodaje drugi slajd, a następnie usuwa pierwotny, pozostawiając tylko nowy.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```