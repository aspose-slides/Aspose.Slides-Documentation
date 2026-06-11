---
title: Master Slajd
type: docs
weight: 30
url: /pl/androidjava/examples/elements/master-slide/
keywords:
- przykład kodu
- master slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Poznaj przykłady master slajdów w Aspose.Slides for Android: twórz, edytuj i stylizuj mastery, pola zastępcze oraz motywy w formatach PPT, PPTX i ODP przy użyciu przejrzystego kodu Java."
---
Master slajdy stanowią najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **Master slajd** definiuje wspólne elementy projektu, takie jak tła, logo i formatowanie tekstu. **Layout slajdy** dziedziczą po master slajdach, a **normalne slajdy** dziedziczą po layout slajdach.

Ten artykuł demonstruje, jak tworzyć, modyfikować i zarządzać master slajdami przy użyciu Aspose.Slides for Android za pośrednictwem Javy.

## **Dodaj master slajd**

Ten przykład pokazuje, jak utworzyć nowy master slajd poprzez sklonowanie domyślnego. Następnie dodaje baner z nazwą firmy do wszystkich slajdów za pomocą dziedziczenia layoutu.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Sklonuj domyślny master slajd.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Dodaj baner z nazwą firmy na górze master slajdu.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Przypisz nowy master slajd do layout slajdu.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Przypisz layout slajd do pierwszego slajdu w prezentacji.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga 1:** Master slajdy umożliwiają stosowanie spójnej identyfikacji wizualnej lub wspólnych elementów projektu we wszystkich slajdach. Wszelkie zmiany wprowadzone w masterze będą automatycznie odzwierciedlane w zależnych layoutach i normalnych slajdach.

> 💡 **Uwaga 2:** Wszystkie kształty lub formatowanie dodane do master slajdu są dziedziczone przez layout slajdy i, w konsekwencji, przez wszystkie normalne slajdy korzystające z tych layoutów.  
> Poniższy obrazek ilustruje, jak pole tekstowe dodane do master slajdu jest automatycznie renderowane na ostatecznym slajdzie.

![Przykład dziedziczenia master slajdu](master-slide-banner.png)

## **Dostęp do master slajdu**

Możesz uzyskać dostęp do master slajdów za pomocą kolekcji masterów prezentacji. Oto jak je pobrać i pracować z nimi:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Zmień typ tła.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń master slajd**

Master slajdy można usunąć zarówno według indeksu, jak i za pomocą odwołania.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Usuń master slajd według indeksu.
        presentation.getMasters().removeAt(0);

        // Usuń master slajd według odwołania.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń nieużywane master slajdy**

Niektóre prezentacje zawierają master slajdy, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Usuń wszystkie nieużywane master slajdy (nawet te oznaczone jako Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```