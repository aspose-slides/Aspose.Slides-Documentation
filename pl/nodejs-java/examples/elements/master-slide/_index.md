---
title: Slajd master
type: docs
weight: 30
url: /pl/nodejs-java/examples/elements/master-slide/
keywords:
- przykład kodu
- slajd master
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj przykłady slajdów master w Aspose.Slides for Node.js: twórz, edytuj i stylizuj mastery, symbole zastępcze oraz motywy w formatach PPT, PPTX i ODP przy użyciu przejrzystego kodu."
---
Master slides tworzą najwyższy poziom hierarchii dziedziczenia slajdów w PowerPoint. **Master slide** definiuje wspólne elementy projektu, takie jak tła, loga i formatowanie tekstu. **Layout slides** dziedziczą po master slides, a **normal slides** dziedziczą po layout slides.

Ten artykuł demonstruje, jak tworzyć, modyfikować i zarządzać slajdami master przy użyciu Aspose.Slides for Node.js via Java.

## **Dodaj slajd master**

Ten przykład pokazuje, jak utworzyć nowy slajd master poprzez sklonowanie domyślnego. Następnie dodaje baner z nazwą firmy do wszystkich slajdów poprzez dziedziczenie układu.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Sklonuj domyślny slajd master.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Dodaj baner z nazwą firmy na górze slajdu master.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Przypisz nowy slajd master do slajdu układu.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Przypisz slajd układu do pierwszego slajdu w prezentacji.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga 1:** Slajdy master zapewniają sposób na zastosowanie spójnej identyfikacji wizualnej lub wspólnych elementów projektu na wszystkich slajdach. Wszelkie zmiany wprowadzone w masterze automatycznie odzwierciedlą się w zależnych slajdach układu i normalnych.

> 💡 **Uwaga 2:** Wszystkie kształty lub formatowanie dodane do slajdu master są dziedziczone przez slajdy layout, a następnie przez wszystkie normalne slajdy używające tych układów.  
> Obraz poniżej ilustruje, jak pole tekstowe dodane na slajdzie master jest automatycznie renderowane na końcowym slajdzie.

![Przykład dziedziczenia mastera](master-slide-banner.png)

## **Uzyskaj dostęp do slajdu master**

Możesz uzyskać dostęp do slajdów master za pomocą kolekcji masterów prezentacji. Oto jak je pobrać i pracować z nimi:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Zmień typ tła.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń slajd master**

Slajdy master można usunąć zarówno według indeksu, jak i przez odniesienie.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Usuń slajd master według indeksu.
        presentation.getMasters().removeAt(0);

        // Usuń slajd master według referencji.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń nieużywane slajdy master**

Niektóre prezentacje zawierają slajdy master, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Usuń wszystkie nieużywane slajdy master (nawet te oznaczone jako Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```