---
title: Dia's in een presentatie vergelijken in PHP
linktitle: Dia's vergelijken
type: docs
weight: 50
url: /nl/php-java/compare-slides/
keywords:
- dia's vergelijken
- dia vergelijking
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor PHP via Java. Identificeer dia-verschillen snel in de code."
---
## **Inleiding**

Aspose.Slides stelt u in staat dia's, lay-outdia's en masterdia's te vergelijken met behulp van de `equals`‑methode die wordt geleverd door de `BaseSlide`‑klasse. Deze methode retourneert `true` wanneer de vergeleken dia's identiek zijn in hun structuur en statische inhoud.

## **Vergelijk twee dia's**

De Equals‑methode is toegevoegd aan de [BaseSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/BaseSlide)‑klasse. Ze retourneert true voor de dia‑/lay-out‑ en dia‑/master‑dia's die identiek zijn qua structuur en statische inhoud.

Twee dia's zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen enzovoort gelijk zijn. De vergelijking houdt geen rekening met unieke identifier‑waarden, zoals SlideId, en dynamische inhoud, zoals de huidige datumwaarde in een datum‑placeholder.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia's zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/gethidden/) is een presentatie-/afspeel‑niveau eigenschap, geen visuele inhoud. De gelijkheid van twee specifieke dia's wordt bepaald door hun structuur en statische inhoud; het feit alleen dat een dia verborgen is, maakt de dia's niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie afwijkt, wordt dit doorgaans beschouwd als een verschil in statische inhoud.

**Als een grafiek verwijst naar een extern Excel‑bestand, wordt de inhoud van dat bestand dan in aanmerking genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia's zelf. Externe gegevensbronnen worden doorgaans niet gelezen tijdens de vergelijking; alleen wat aanwezig is in de structuur en de statische toestand van de dia wordt in aanmerking genomen.