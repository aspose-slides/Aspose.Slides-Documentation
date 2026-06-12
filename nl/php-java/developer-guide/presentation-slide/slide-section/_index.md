---
title: Beheer dia‑secties in presentaties met PHP
linktitle: Dia sectie
type: docs
weight: 90
url: /nl/php-java/slide-section/
keywords:
- sectie aanmaken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Vereenvoudig dia‑secties in PowerPoint en OpenDocument met Aspose.Slides for PHP via Java - splitsen, hernoemen en herschikken om PPTX‑ en ODP‑workflows te optimaliseren."
---
## **Inleiding**

Met Aspose.Slides for PHP via Java kun je een PowerPoint‑presentatie in secties indelen. Je kunt secties maken die specifieke dia's bevatten.

Je wilt mogelijk secties maken en ze gebruiken om dia's in een presentatie te organiseren of op te delen in logische delen in de volgende situaties:

- Wanneer je aan een grote presentatie werkt met andere personen of een team — en je bepaalde dia's moet toewijzen aan een collega of enkele teamleden. 
- Wanneer je een presentatie hebt met veel dia's — en je moeite hebt om de inhoud in één keer te beheren of te bewerken.

Idealiter maak je een sectie die gelijkaardige dia's bevat — de dia's hebben iets gemeen of kunnen op basis van een regel in een groep worden geplaatst — en geef je de sectie een naam die de inhoud van de dia's beschrijft. 

## **Secties maken in presentaties**

Om een sectie toe te voegen die dia's in een presentatie bevat, biedt Aspose.Slides for PHP via Java de [addSection()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sectioncollection/#addSection)‑methode waarmee je de naam van de te creëren sectie kunt opgeven en de dia vanaf welke de sectie begint.

Deze voorbeeldcode laat zien hoe je een sectie in een presentatie maakt:
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 zal eindigen bij newSlide2 en daarna zal section2 beginnen

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **De namen van secties wijzigen**

Nadat je een sectie in een PowerPoint‑presentatie hebt gemaakt, kun je besluiten de naam ervan te wijzigen. 

Deze voorbeeldcode laat zien hoe je de naam van een sectie in een presentatie wijzigt met behulp van Aspose.Slides:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Worden secties behouden bij het opslaan in het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een gehele sectie "verborgen" worden?**

Nee. Alleen individuele dia's kunnen verborgen worden. Een sectie als entiteit heeft geen "verborgen" status.

**Kan ik snel een sectie vinden op basis van een dia en omgekeerd de eerste dia van een sectie?**

Ja. Een sectie wordt uniek gedefinieerd door zijn startdia; gegeven een dia kun je bepalen tot welke sectie hij behoort, en voor een sectie kun je de eerste dia benaderen.