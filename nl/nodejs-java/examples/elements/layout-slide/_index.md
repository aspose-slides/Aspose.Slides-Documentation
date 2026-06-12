---
title: Layout-slide
type: docs
weight: 20
url: /nl/nodejs-java/examples/elements/layout-slide/
keywords:
- codevoorbeeld
- layout-slide
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer layout-slides in Aspose.Slides voor Node.js: kies, pas toe en pas aan slide-lay-outs, placeholder-objecten en masters met voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u kunt werken met **Layout Slides** in Aspose.Slides voor Node.js via Java. Een layout‑slide bepaalt het ontwerp en de opmaak die normale slides erven. U kunt layout‑slides toevoegen, benaderen, klonen en verwijderen, en tevens ongebruikte slides opschonen om de grootte van de presentatie te verkleinen.

## **Een Layout Slide Toevoegen**

U kunt een aangepaste layout‑slide maken om herbruikbare opmaak te definiëren.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Maak een layout-slide met een lege layouttype en een aangepaste naam.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking 1:** Layout‑slides fungeren als sjablonen voor individuele slides. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens hergebruiken in veel slides.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst toevoegt aan een layout‑slide, wordt deze gedeelde inhoud automatisch weergegeven op alle slides die op die layout zijn gebaseerd.  
> De screenshot hieronder toont twee slides, elk met een tekstvak dat ze van dezelfde layout‑slide erven.

![Dia’s die layoutinhoud erven](layout-slide-result.png)

## **Een Layout Slide Benaderen**

Layout‑slides kunnen benaderd worden via een index of via het layouttype (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Toegang tot een layout-slide per index.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Toegang tot een layout-slide per type.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Een Layout Slide Verwijderen**

U kunt een specifieke layout‑slide verwijderen als deze niet meer nodig is.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Haal een layout-slide op basis van type op en verwijder deze.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ongebruikte Layout Slides Verwijderen**

Om de grootte van de presentatie te verkleinen, kunt u layout‑slides die door geen enkele normale slide worden gebruikt verwijderen.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Verwijdert automatisch alle layout-slides die door geen enkele slide worden gebruikt.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Een Layout Slide Klonen**

U kunt een layout‑slide dupliceren met de `addClone`‑methode.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Haal een bestaande layout-slide op basis van type.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Kloon de layout-slide naar het einde van de layout-slide collectie.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Samenvatting:** Layout‑slides zijn krachtige hulpmiddelen voor het beheren van consistente opmaak over slides heen. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout‑slides.