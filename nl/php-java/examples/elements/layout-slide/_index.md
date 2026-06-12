---
title: Layoutdia
type: docs
weight: 20
url: /nl/php-java/examples/elements/layout-slide/
keywords:
- layoutdia
- layoutdia toevoegen
- layoutdia benaderen
- layoutdia verwijderen
- ongebruikte layoutdia
- layoutdia dupliceren
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gebruik PHP om layoutdia's te beheren met Aspose.Slides: maak, pas toe, dupliceer, hernoem en pas plaatshouders en thema's aan in presentaties voor PPT, PPTX en ODP."
---
Dit artikel toont hoe u kunt werken met **Layout Slides** in Aspose.Slides voor PHP via Java. Een layoutslide definieert het ontwerp en de opmaak die normale dia's overerven. U kunt layoutslides toevoegen, benaderen, dupliceren en verwijderen, en ongebruikte slides opruimen om de presentatiegrootte te verkleinen.

## **Een layoutslide toevoegen**

U kunt een aangepaste layoutslide maken om herbruikbare opmaak te definiëren. Bijvoorbeeld kunt u een tekstvak toevoegen dat op alle dia's met deze layout verschijnt.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Maak een layoutslide met een blanco layouttype en een aangepaste naam.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Layoutslides fungeren als sjablonen voor individuele dia's. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens in veel dia's hergebruiken.

> 💡 **Tip 2:** Wanneer u vormen of tekst toevoegt aan een layoutslide, tonen alle dia's die op die layout zijn gebaseerd automatisch deze gedeelde inhoud.  
> De schermafbeelding hieronder toont twee dia's, elk met een tekstvak dat ze erven van dezelfde layoutslide.

![Dia's die layoutinhoud erven](layout-slide-result.png)

## **Een layoutslide benaderen**

Layoutslides kunnen benaderd worden via een index of via het layouttype (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Toegang via index.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Toegang via layouttype.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Een layoutslide verwijderen**

U kunt een specifieke layoutslide verwijderen als deze niet meer nodig is.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Haal een layoutslide op via type en verwijder deze.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ongebruikte layoutslides verwijderen**

Om de presentatiegrootte te verkleinen, wilt u mogelijk layoutslides verwijderen die door geen enkele normale dia worden gebruikt.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Verwijdert automatisch alle layoutdia's die niet door enige dia worden gerefereerd.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Een layoutslide dupliceren**

U kunt een layoutslide dupliceren met de methode `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Haal een bestaande layoutslide op via type.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Dupliceer de layoutslide naar het einde van de layoutslide-collectie.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Samenvatting:** Layoutslides zijn krachtige hulpmiddelen om consistente opmaak over dia's heen te beheren. Aspose.Slides biedt volledige controle over het creëren, beheren en optimaliseren van layoutslides.