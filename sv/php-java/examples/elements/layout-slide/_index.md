---
title: Layoutbild
type: docs
weight: 20
url: /sv/php-java/examples/elements/layout-slide/
keywords:
- layoutbild
- lägg till layoutbild
- komma åt layoutbild
- ta bort layoutbild
- oanvänd layoutbild
- klona layoutbild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Använd PHP för att hantera layoutbilder med Aspose.Slides: skapa, tillämpa, klona, byta namn och anpassa platshållare och teman i presentationer för PPT, PPTX och ODP."
---
Den här artikeln visar hur du arbetar med **Layout Slides** i Aspose.Slides för PHP via Java. En layoutslide definierar designen och formateringen som ärvs av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layoutbilder, samt rensa bort oanvända för att minska presentationens storlek.

## **Lägg till en layoutslide**

Du kan skapa en anpassad layoutslide för att definiera återanvändbar formatering. Till exempel kan du lägga till en textruta som visas på alla bilder som använder den här layouten.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Skapa en layoutslide med en tom layouttyp och ett anpassat namn.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tips 1:** Layoutbilder fungerar som mallar för enskilda bilder. Du kan definiera gemensamma element en gång och återanvända dem i många bilder.

> 💡 **Tips 2:** När du lägger till former eller text i en layoutslide kommer alla bilder baserade på den layouten automatiskt att visa detta delade innehåll.  
> Skärmbilden nedan visar två bilder, där varje bild ärver en textruta från samma layoutslide.

![Bilder som ärver layoutinnehåll](layout-slide-result.png)

## **Kom åt en layoutslide**

Layoutbilder kan kommas åt via index eller via layouttyp (t.ex. `Blank`, `Title`, `SectionHeader` osv.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Åtkomst via index.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Åtkomst via layouttyp.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en layoutslide**

Du kan ta bort en specifik layoutslide om den inte längre behövs.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Hämta en layoutslide efter typ och ta bort den.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort oanvända layoutbilder**

För att minska presentationens storlek kan du vilja ta bort layoutbilder som inte används av några vanliga bilder.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Tar automatiskt bort alla layoutbilder som inte refereras av någon bild.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klona en layoutslide**

Du kan duplicera en layoutslide med hjälp av metoden `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Hämta en befintlig layoutslide efter typ.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Klona layoutsliden till slutet av layoutslide-samlingen.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Sammanfattning:** Layoutbilder är kraftfulla verktyg för att hantera enhetlig formatering över bilder. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layoutbilder.