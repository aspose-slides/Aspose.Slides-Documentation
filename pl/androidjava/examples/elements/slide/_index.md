---
title: Slajd
type: docs
weight: 10
url: /pl/androidjava/examples/elements/slide/
keywords:
- przykład kodu
- slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj slajdami w Aspose.Slides for Android: twórz, klonuj, zmieniaj kolejność, zmieniaj rozmiar, ustawiaj tła i stosuj przejścia przy użyciu Javy dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł zawiera serię przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for Android via Java**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy za pomocą klasy `Presentation`.

Każdy przykład poniżej zawiera krótkie wyjaśnienie, po którym następuje fragment kodu w języku Java.

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

> 💡 **Uwaga:** Każdy układ slajdu jest pochodną slajdu głównego, który definiuje ogólny projekt i strukturę elementów zastępczych. Poniższy obraz ilustruje, w jaki sposób slajdy główne i ich powiązane układy są zorganizowane w programie PowerPoint.

![Relacja slajdu głównego i układu](master-layout-slide.png)

## **Dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów przy użyciu ich indeksu lub znaleźć indeks slajdu na podstawie referencji. Jest to przydatne przy iteracji lub modyfikacji konkretnych slajdów.

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

        // Pobierz indeks slajdu z odwołania, a następnie uzyskaj dostęp do niego według indeksu.
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

Aby usunąć slajd, po prostu odwołaj się do niego i wywołaj `remove`. Ten przykład dodaje drugi slajd, a następnie usuwa oryginalny, pozostawiając tylko nowy.

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