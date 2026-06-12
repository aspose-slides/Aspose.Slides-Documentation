---
title: Presentaties efficiënt samenvoegen in PHP
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/php-java/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- PHP
- Aspose.Slides
description: "Voeg moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samen met Aspose.Slides voor PHP via Java, waardoor uw workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te combineren door dia's van de ene presentatie te klonen naar een andere. Dit artikel legt uit hoe u volledige presentaties of geselecteerde dia's kunt samenvoegen, een slide‑master of een specifieke lay‑out tijdens het samenvoegen kunt gebruiken, presentaties met verschillende diaformaten kunt verwerken en samengevoegde dia's aan een presentatiesectie kunt toevoegen. Het behandelt ook praktische opmerkingen over samengevoegde inhoud, waaronder spreker­notities, opmerkingen, met wachtwoord beveiligde bronbestanden en thread‑gebruik.

## **Presentatie samenvoegen**

Wanneer u de ene presentatie met de andere samenvoegt, combineert u effectief hun dia's in één presentatie om één bestand te verkrijgen. 

{{% alert title="Info" color="info" %}}

De meeste presentatietools (PowerPoint of OpenOffice) missen functies die gebruikers in staat stellen presentaties op deze manier te combineren. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/nl/php-java/), stelt u echter in staat presentaties op verschillende manieren samen te voegen. U kunt presentaties met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz. samenvoegen zonder kwaliteits- of gegevensverlies.

**Zie ook**

[Clone Slides](/slides/nl/php-java/clone-slides/).

{{% /alert %}}

### **Wat kan worden samengevoegd**

Met Aspose.Slides kunt u

* volledige presentaties. Alle dia's uit de presentaties komen in één presentatie terecht
* specifieke dia's. Geselecteerde dia's komen in één presentatie terecht
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar toe. 

{{% alert title="Note" color="warning" %}} 

Naast presentaties maakt Aspose.Slides het mogelijk andere bestanden samen te voegen:

* [Images](https://products.aspose.com/slides/nl/php-java/merger/image-to-image/), zoals [JPG to JPG](https://products.aspose.com/slides/nl/php-java/merger/jpg-to-jpg/) of [PNG to PNG](https://products.aspose.com/slides/nl/php-java/merger/png-to-png/)
* Documents, zoals [PDF to PDF](https://products.aspose.com/slides/nl/php-java/merger/pdf-to-pdf/) of [HTML to HTML](https://products.aspose.com/slides/nl/php-java/merger/html-to-html/)
* En twee verschillende bestanden, zoals [image to PDF](https://products.aspose.com/slides/nl/php-java/merger/image-to-pdf/) of [JPG to PDF](https://products.aspose.com/slides/nl/php-java/merger/jpg-to-pdf/) of [TIFF to PDF](https://products.aspose.com/slides/nl/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Samenvoegopties**

U kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt
* een specifieke stijl wordt gebruikt voor alle dia's in de uitvoerpresentatie. 

Om presentaties samen te voegen, biedt Aspose.Slides de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) methoden (van de [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) klasse). Er zijn verschillende implementaties van de `addClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslides/) collectie, zodat u een `addClone`‑methode kunt aanroepen vanuit de presentatie waaraan u dia's wilt toevoegen.

De `addClone`‑methode retourneert een `Slide`‑object, dat een kloon van de bron‑dia is. De dia's in een uitvoerpresentatie zijn simpelweg een kopie van de bron‑dia's. Daarom kunt u wijzigingen aanbrengen in de resulterende dia's (bijvoorbeeld stijlen, opmaakopties of lay‑outs toepassen) zonder dat de bronpresentaties worden beïnvloed. 

## **Presentaties samenvoegen** 

Aspose.Slides biedt de [addClone(Slide)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) methode die u in staat stelt dia's te combineren terwijl de dia's hun lay‑outs en stijlen behouden (standaardparameters).

Deze PHP‑code toont hoe u presentaties kunt samenvoegen:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Presentaties samenvoegen met een Slide Master**

Aspose.Slides biedt de [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) methode die u in staat stelt dia's te combineren terwijl u een slide‑master‑sjabloon toepast. Op deze manier kunt u, indien nodig, de stijl voor de dia's in de uitvoerpresentatie wijzigen.

Deze code demonstreert de beschreven bewerking:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

De dia‑lay‑out voor de slide‑master wordt automatisch bepaald. Wanneer er geen passende lay‑out kan worden bepaald, wordt – als de `allowCloneMissingLayout`‑boolean‑parameter van de `addClone`‑methode op true staat – de lay‑out van de bron‑dia gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PptxEditException) gegooid.

{{% /alert %}}

Als u wilt dat de dia's in de uitvoerpresentatie een andere dia‑lay‑out hebben, gebruikt u in plaats daarvan de [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) methode bij het samenvoegen.

## **Specifieke dia's uit presentaties samenvoegen**

Specifieke dia's uit meerdere presentaties samenvoegen is handig voor het maken van aangepaste dia‑sets. Aspose.Slides for PHP via Java stelt u in staat alleen de dia's te selecteren en te importeren die u nodig heeft. De API behoudt de opmaak, lay‑out en vormgeving van de originele dia's.

De volgende PHP‑code maakt een nieuwe presentatie, voegt titeldia's toe uit twee andere presentaties en slaat het resultaat op in een bestand:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Presentaties samenvoegen met een Slide Layout**

Deze PHP‑code toont hoe u dia's uit presentaties combineert terwijl u uw favoriete dia‑lay‑out toepast om één uitvoerpresentatie te krijgen:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Presentaties samenvoegen met verschillende diaformaten**

{{% alert title="Note" color="warning" %}} 

U kunt geen presentaties met verschillende diaformaten samenvoegen. 

{{% /alert %}}

Om 2 presentaties met verschillende diaformaten samen te voegen, moet u één van de presentaties verkleinen of vergroten zodat het formaat overeenkomt met dat van de andere presentatie. 

Deze voorbeeldcode demonstreert de beschreven bewerking:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Dia's samenvoegen met een presentatiesectie**

Deze PHP‑code toont hoe u een specifieke dia kunt samenvoegen met een sectie in een presentatie:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

De dia wordt aan het einde van de sectie toegevoegd. 

## **Zie ook**


Aspose biedt een [FREE Online Collage Maker](https://products.aspose.app/slides/nl/collage). Met deze online service kunt u [JPG to JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑naar‑PNG‑afbeeldingen samenvoegen, [photo grids](https://products.aspose.app/slides/nl/collage/photo-grid) maken en meer.

Bekijk de [Aspose FREE Online Merger](https://products.aspose.app/slides/nl/merger). Deze tool laat u PowerPoint‑presentaties in hetzelfde formaat (bijv. PPT naar PPT, PPTX naar PPTX) of over verschillende formaten heen (bijv. PPT naar PPTX, PPTX naar ODP) samenvoegen.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/nl/merger)

## **Veelgestelde vragen**

**Zijn er beperkingen op het aantal dia's bij het samenvoegen van presentaties?**

Geen strikte limieten. Aspose.Slides kan grote bestanden aan, maar de prestaties hangen af van de bestandsgrootte en de systeembronnen. Voor zeer grote presentaties wordt aangeraden een 64‑bit JVM te gebruiken en voldoende heap‑geheugen toe te wijzen.

**Kan ik presentaties samenvoegen met ingesloten video of audio?**

Ja, Aspose.Slides behoudt multimedia‑inhoud die in dia's is ingesloten, maar de uiteindelijke presentatie kan daardoor aanzienlijk groter worden.

**Worden lettertypen behouden bij het samenvoegen van presentaties?**

Ja. Lettertypen die in de bron‑presentaties worden gebruikt, blijven behouden in het uitvoerbestand, op voorwaarde dat ze op het systeem zijn geïnstalleerd of [embedded](/slides/nl/php-java/embedded-font/).