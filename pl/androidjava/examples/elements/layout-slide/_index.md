---
title: Układ slajdu
type: docs
weight: 20
url: /pl/androidjava/examples/elements/layout-slide/
keywords:
- przykład kodu
- układ slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Mistrzowskie układy slajdów w Aspose.Slides dla Androida: wybieraj, stosuj i dostosowuj układy slajdów, znaczniki i szablony główne przy użyciu przykładów Java dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak pracować z **Layout Slides** w Aspose.Slides dla Androida przy użyciu Javy. Layout slide definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać layout slides, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Add a Layout Slide**

Możesz utworzyć niestandardowy layout slide, aby określić wielokrotnego użytku formatowanie. Na przykład możesz dodać pole tekstowe, które pojawia się na wszystkich slajdach korzystających z tego układu.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Utwórz slajd układu z pustym typem układu i własną nazwą.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Dodaj pole tekstowe do slajdu układu.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Dodaj dwa slajdy używając tego układu; oba odziedziczą tekst z układu.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Layout slides działają jako szablony dla pojedynczych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Note 2:** Gdy dodasz kształty lub tekst do layout slide, wszystkie slajdy oparte na tym układzie automatycznie wyświetlą tę wspólną zawartość.  
> Zrzut ekranu poniżej pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego layout slide.

![Slajdy dziedziczące zawartość layoutu](layout-slide-result.png)

## **Access a Layout Slide**

Layout slides można uzyskać przez indeks lub przez typ układu (np. `Blank`, `Title`, `SectionHeader` itp.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Uzyskaj dostęp do slajdu układu według indeksu.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Uzyskaj dostęp do slajdu układu według typu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Layout Slide**

Możesz usunąć konkretny layout slide, jeśli nie jest już potrzebny.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Pobierz slajd układu według typu i usuń go.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Layout Slides**

Aby zmniejszyć rozmiar prezentacji, możesz usunąć layout slides, które nie są używane przez żadne zwykłe slajdy.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Automatycznie usuwa wszystkie slajdy układu, które nie są referencjonowane przez żaden slajd.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clone a Layout Slide**

Możesz zduplikować layout slide przy użyciu metody `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Pobierz istniejący slajd układu według typu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Sklonuj slajd układu na koniec kolekcji slajdów układu.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** Layout slides są potężnym narzędziem do zarządzania spójnym formatowaniem na slajdach. Aspose.Slides umożliwia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją layout slides.