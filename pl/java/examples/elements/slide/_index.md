---
title: Slajd
type: docs
weight: 10
url: /pl/java/examples/elements/slide/
keywords:
- przykład kodu
- slajd
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Kontroluj slajdy w Aspose.Slides for Java: twórz, klonuj, zmieniaj kolejność, zmieniaj rozmiar, ustawiaj tła i stosuj przejścia w Javie dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł zawiera szereg przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for Java**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy za pomocą klasy `Presentation`.

Każdy poniższy przykład zawiera krótkie wyjaśnienie oraz fragment kodu w języku Java.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw należy wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga:** Każdy układ slajdu jest pochodną slajdu głównego (master), który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obrazek ilustruje, jak slajdy główne i ich powiązane układy są organizowane w programie PowerPoint.

![Związek między masterem a układem](master-layout-slide.png)

## **Dostęp do slajdów po indeksie**

Możesz uzyskać dostęp do slajdów, używając ich indeksu, lub znaleźć indeks slajdu na podstawie odwołania. Jest to przydatne przy iteracji po slajdach lub modyfikacji konkretnych slajdów.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Dodaj kolejny pusty slajd.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Uzyskaj dostęp do slajdów według indeksu.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Pobierz indeks slajdu z referencji, a następnie uzyskaj do niego dostęp według indeksu.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klonowanie slajdu**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Zmiana kolejności slajdów**

Możesz zmienić kolejność slajdów, przenosząc jeden na nowy indeks. W tym przypadku przenosimy sklonowany slajd na pierwszą pozycję.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuwanie slajdu**

Aby usunąć slajd, wystarczy odwołać się do niego i wywołać metodę `remove`. Ten przykład dodaje drugi slajd, a następnie usuwa pierwotny, pozostawiając tylko nowy.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```