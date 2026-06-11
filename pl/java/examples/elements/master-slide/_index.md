---
title: Slajd nadrzędny
type: docs
weight: 30
url: /pl/java/examples/elements/master-slide/
keywords:
- przykład kodu
- slajd nadrzędny
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj przykłady slajdów nadrzędnych Aspose.Slides for Java: twórz, edytuj i stylizuj slajdy nadrzędne, pola wypełnienia i motywy w formatach PPT, PPTX i ODP przy użyciu przejrzystego kodu Java."
---
Slajdy nadrzędne stanowią najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **Slajd nadrzędny** definiuje wspólne elementy projektu, takie jak tła, loga i formatowanie tekstu. **Slajdy układu** dziedziczą po slajdach nadrzędnych, a **slajdy zwykłe** dziedziczą po slajdach układu.

Ten artykuł pokazuje, jak tworzyć, modyfikować i zarządzać slajdami nadrzędnymi przy użyciu Aspose.Slides for Java.

## **Dodaj slajd nadrzędny**

Ten przykład pokazuje, jak utworzyć nowy slajd nadrzędny, klonując domyślny. Następnie dodaje baner z nazwą firmy do wszystkich slajdów poprzez dziedziczenie układu.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Sklonuj domyślny slajd nadrzędny.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Dodaj baner z nazwą firmy na górze slajdu nadrzędnego.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Przypisz nowy slajd nadrzędny do slajdu układu.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Przypisz slajd układu do pierwszego slajdu w prezentacji.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga 1:** Slajdy nadrzędne umożliwiają stosowanie spójnej identyfikacji marki lub wspólnych elementów projektu we wszystkich slajdach. Wszelkie zmiany wprowadzone w slajdzie nadrzędnym będą automatycznie odzwierciedlane w zależnych slajdach układu i slajdach zwykłych.  
> 
> 💡 **Uwaga 2:** Wszystkie kształty lub formatowanie dodane do slajdu nadrzędnego są dziedziczone przez slajdy układu, a tym samym przez wszystkie slajdy zwykłe korzystające z tych układów.  
> 
> Poniższy obrazek ilustruje, jak pole tekstowe dodane w slajdzie nadrzędnym jest automatycznie renderowane na końcowym slajdzie.

![Master Inheritance Example](master-slide-banner.png)

## **Dostęp do slajdu nadrzędnego**

Możesz uzyskać dostęp do slajdów nadrzędnych za pomocą kolekcji slajdów nadrzędnych prezentacji. Oto jak je pobrać i pracować z nimi:

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

## **Usuń slajd nadrzędny**

Slajdy nadrzędne można usunąć zarówno według indeksu, jak i odwołania.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Usuń slajd nadrzędny według indeksu.
        presentation.getMasters().removeAt(0);

        // Usuń slajd nadrzędny według odwołania.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń nieużywane slajdy nadrzędne**

Niektóre prezentacje zawierają slajdy nadrzędne, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Usuń wszystkie nieużywane slajdy nadrzędne (nawet te oznaczone jako Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```