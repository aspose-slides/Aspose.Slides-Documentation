---
title: Masterdia
type: docs
weight: 30
url: /nl/php-java/examples/elements/master-slide/
keywords:
- masterdia
- masterdia toevoegen
- masterdia openen
- masterdia verwijderen
- ongebruikte masterdia
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer masterdia's in PHP met Aspose.Slides: maak, bewerk, kloon en formatteer thema's, achtergronden, tijdelijke aanduidingen om dia's te uniformiseren in PowerPoint en OpenDocument."
---
Masterdia's vormen het hoogste niveau van de dia‑erfhiërarchie in PowerPoint. Een **masterdia** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Lay‑outdia's** erven van masterdia's, en **normale dia's** erven van lay‑outdia's.

Dit artikel laat zien hoe u masterdia's kunt aanmaken, wijzigen en beheren met Aspose.Slides voor PHP via Java.

## **Masterdia toevoegen**

Dit voorbeeld laat zien hoe u een nieuwe masterdia kunt maken door de standaarddia te klonen.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Kopieer de standaard masterdia.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Masterdia's bieden een manier om consistente branding of gedeelde designelementen toe te passen op alle dia's. Alle wijzigingen die u aan de master aanbrengt, worden automatisch doorgevoerd in de afhankelijke lay‑out‑ en normale dia's.

> 💡 **Tip 2:** Alle vormen of opmaak die aan een masterdia worden toegevoegd, worden geërfd door lay‑outdia's en daarmee door alle normale dia's die die lay-outs gebruiken.  
> De afbeelding hieronder toont hoe een tekstvak dat op een masterdia is toegevoegd, automatisch wordt weergegeven op de einddia.

![Voorbeeld van master‑erfenis](master-slide-banner.png)

## **Toegang tot een masterdia**

U kunt masterdia's benaderen met de `Presentation::getMasters`‑methode. Hieronder ziet u hoe u ze kunt ophalen en ermee kunt werken:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Toegang tot de eerste masterdia.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Een masterdia verwijderen**

Masterdia's kunnen worden verwijderd op basis van index of referentie.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Verwijderen op index.
        $presentation->getMasters()->removeAt(0);

        // Of verwijderen op referentie.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ongebruikte masterdia's verwijderen**

Sommige presentaties bevatten masterdia's die niet worden gebruikt. Het verwijderen van deze dia's kan helpen de bestandsgrootte te verkleinen.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Verwijder alle ongebruikte masterdia's (ook die gemarkeerd zijn als Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Gebruik `removeUnused(true)` om ongebruikte masterdia's op te ruimen en de presentatiegrootte te minimaliseren.