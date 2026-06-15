---
title: Layoutbild
type: docs
weight: 20
url: /sv/nodejs-java/examples/elements/layout-slide/
keywords:
- kodexempel
- layoutbild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska layoutbilder i Aspose.Slides för Node.js: välj, tillämpa och anpassa bildlayouter, platshållare och masterbilder med exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man arbetar med **Layout Slides** i Aspose.Slides för Node.js via Java. En layoutbild definierar designen och formateringen som ärvs av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layoutbilder, samt rensa bort oanvända för att minska presentationens storlek.

## **Lägg till en layoutbild**

Du kan skapa en anpassad layoutbild för att definiera återanvändbar formatering.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Skapa en layoutbild med en tom layouttyp och ett eget namn.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Obs 1:** Layoutbilder fungerar som mallar för enskilda bilder. Du kan definiera gemensamma element en gång och återanvända dem i många bilder.

> 💡 **Obs 2:** När du lägger till former eller text i en layoutbild, visas detta delade innehåll automatiskt i alla bilder som baseras på den layouten.
> Skärmbilden nedan visar två bilder, som båda ärver en textruta från samma layoutbild.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Kom åt en layoutbild**

Layoutbilder kan nås via index eller via layouttyp (t.ex. `Blank`, `Title`, `SectionHeader`, osv.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Kom åt en layoutbild efter index.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Kom åt en layoutbild efter typ.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en layoutbild**

Du kan ta bort en specifik layoutbild om den inte längre behövs.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Hämta en layoutbild efter typ och ta bort den.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort oanvända layoutbilder**

För att minska presentationens storlek kan du vilja ta bort layoutbilder som inte används av några vanliga bilder.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Automatiskt tar bort alla layoutbilder som inte refereras av någon bild.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Klona en layoutbild**

Du kan duplicera en layoutbild med metoden `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Hämta en befintlig layoutbild efter typ.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Klona layoutbilden till slutet av samlingen av layoutbilder.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Sammanfattning:** Layoutbilder är kraftfulla verktyg för att hantera konsekvent formatering över bilder. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layoutbilder.