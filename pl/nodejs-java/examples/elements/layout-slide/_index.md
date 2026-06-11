---
title: Slajd układu
type: docs
weight: 20
url: /pl/nodejs-java/examples/elements/layout-slide/
keywords:
- przykład kodu
- slajd układu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Mistrzowskie slajdy układu w Aspose.Slides dla Node.js: wybieraj, stosuj i dostosowuj układy slajdów, pola zastępcze i mastery z przykładami dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak pracować z **Slajdy układu** w Aspose.Slides dla Node.js za pośrednictwem Java. Slajd układu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać slajdy układu, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Dodaj slajd układu**

Możesz utworzyć własny slajd układu, aby zdefiniować wielokrotnie używany format.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Utwórz slajd układu z pustym typem układu i niestandardową nazwą.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga 1:** Slajdy układu działają jako szablony dla poszczególnych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Uwaga 2:** Gdy dodasz kształty lub tekst do slajdu układu, wszystkie slajdy bazujące na tym układzie automatycznie wyświetlą tę współdzieloną zawartość.  
> Poniższy zrzut ekranu pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego slajdu układu.

![Slajdy dziedziczące zawartość układu](layout-slide-result.png)

## **Uzyskaj dostęp do slajdu układu**

Slajdy układu można uzyskać przez indeks lub przez typ układu (np. `Blank`, `Title`, `SectionHeader` itp.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Uzyskaj dostęp do slajdu układu według indeksu.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Uzyskaj dostęp do slajdu układu według typu.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń slajd układu**

Możesz usunąć konkretny slajd układu, jeśli nie jest już potrzebny.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Uzyskaj slajd układu według typu i usuń go.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń nieużywane slajdy układu**

Aby zmniejszyć rozmiar prezentacji, możesz chcieć usunąć slajdy układu, które nie są używane przez żadne zwykłe slajdy.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Automatycznie usuwa wszystkie slajdy układu, które nie są używane przez żaden slajd.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonuj slajd układu**

Możesz zduplikować slajd układu przy użyciu metody `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Pobierz istniejący slajd układu według typu.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Sklonuj slajd układu na koniec kolekcji slajdów układu.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Podsumowanie:** Slajdy układu są potężnym narzędziem do zarządzania spójnym formatowaniem na slajdach. Aspose.Slides umożliwia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją slajdów układu.