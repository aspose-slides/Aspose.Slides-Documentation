---
title: Slajd
type: docs
weight: 10
url: /pl/nodejs-java/examples/elements/slide/
keywords:
- przykład kodu
- slajd
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Steruj slajdami w Aspose.Slides for Node.js: twórz, klonuj, zmieniaj kolejność, zmieniaj rozmiar, ustawiaj tła i stosuj przejścia dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł zawiera serię przykładów, które demonstrują, jak pracować ze slajdami przy użyciu **Aspose.Slides for Node.js via Java**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy przy użyciu klasy `Presentation`.

Każdy poniższy przykład zawiera krótkie wyjaśnienie, po którym następuje fragment kodu w języku JavaScript.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw musisz wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga:** Każdy układ slajdu jest pochodną slajdu podstawowego, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obrazek ilustruje, jak slajdy podstawowe i ich powiązane układy są zorganizowane w programie PowerPoint.

![Związek między slajdem podstawowym a układem](master-layout-slide.png)

## **Dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów, używając ich indeksu. Jest to przydatne przy iteracji po slajdach lub modyfikacji konkretnych slajdów.

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Uzyskaj dostęp do slajdu po indeksie.
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonowanie slajdu**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Zmiana kolejności slajdów**

Możesz zmienić kolejność slajdów, przenosząc jeden na nowy indeks. W tym przypadku przenosimy slajd na pierwszą pozycję.

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // Zmień kolejność slajdów, przenosząc drugi slajd na pierwszą pozycję.
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Usunięcie slajdu**

Aby usunąć slajd, po prostu odwołaj się do niego i wywołaj `remove`. Ten przykład dodaje drugi slajd, a następnie usuwa pierwotny, pozostawiając tylko nowy.

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```