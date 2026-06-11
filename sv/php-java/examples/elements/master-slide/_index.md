---
title: Mastersida
type: docs
weight: 30
url: /sv/php-java/examples/elements/master-slide/
keywords:
- mastersida
- lägga till mastersida
- åtkomst till mastersida
- ta bort mastersida
- oanvänd mastersida
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera mastersidor i PHP med Aspose.Slides: skapa, redigera, klona och formatera teman, bakgrunder och platshållare för att enhetliggöra bilder i PowerPoint och OpenDocument."
---
Mastersidor utgör den översta nivån i bildens arvshierarki i PowerPoint. En **mastersida** definierar gemensamma designelement såsom bakgrunder, logotyper och textformatering. **Layoutbilder** ärver från mastersidor, och **normala bilder** ärver från layoutbilder.

Denna artikel visar hur man skapar, ändrar och hanterar mastersidor med Aspose.Slides för PHP via Java.

## **Lägg till en mastersida**

Detta exempel visar hur man skapar en ny mastersida genom att klona standardmallen.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Klona den förvalda mastersidan.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tips 1:** Mastersidor ger ett sätt att tillämpa enhetlig varumärkesprofil eller delade designelement på alla bilder. Alla ändringar som görs i mastern kommer automatiskt att återspeglas i beroende layout- och normala bilder.

> 💡 **Tips 2:** Alla former eller formateringar som läggs till på en mastersida ärvts av layoutbilder och i sin tur av alla normala bilder som använder dessa layouter.  
> Bilden nedan illustrerar hur en textruta som lagts till på en mastersida automatiskt renderas på den slutgiltiga bilden.

![Master Inheritance Example](master-slide-banner.png)

## **Åtkomst till en mastersida**

Du kan komma åt mastersidor med metoden `Presentation::getMasters`. Så här hämtar du dem och arbetar med dem:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Åtkomst till den första mastersidan.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en mastersida**

Mastersidor kan tas bort antingen efter index eller genom referens.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Ta bort efter index.
        $presentation->getMasters()->removeAt(0);

        // Eller ta bort efter referens.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort oanvända mastersidor**

Vissa presentationer innehåller mastersidor som inte används. Att ta bort dessa bilder kan hjälpa till att minska filstorleken.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Ta bort alla oanvända mastersidor (även de som är markerade som Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tips:** Använd `removeUnused(true)` för att rensa bort oanvända mastersidor och minska presentationens storlek.