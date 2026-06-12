---
title: Beheer tags en aangepaste gegevens in presentaties met PHP
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/php-java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- paarwaarden
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides for PHP via Java, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het geeft een kort overzicht van hoe gegevens worden opgeslagen in PPTX‑bestanden, merkt op dat presentatie‑specifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde‑tekenreeksparen.

Het laat ook zien hoe tag‑waarden gelezen kunnen worden en hoe tags toegevoegd worden aan een presentatie, een specifieke dia of een vorm. Daarnaast behandelt het artikel gangbare tag‑beheertaken zoals het wissen van alle tags, het verwijderen van een tag op naam, en het ophalen van de lijst met tagnamen.

## **Gegevensopslag in presentatiesbestanden**

PPTX‑bestanden — items met de .pptx‑extensie — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens die in presentaties zijn opgenomen.

Met een *dia* als een van de elementen in presentaties, bevat een *dia‑onderdeel* de inhoud van één enkele dia. Een dia‑onderdeel mag expliciete relaties hebben met veel onderdelen — zoals User Defined Tags — gedefinieerd door ISO/IEC 29500.

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([TagCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/)) en CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

Tags zijn in wezen string‑sleutel‑paar‑waarden. 

{{% /alert %}} 

## **Waarden van tags ophalen**

In slides komt een tag overeen met de [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getKeywords) en [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#setKeywords) methoden. Deze voorbeeldcode laat zien hoe je de waarde van een tag opvraagt met Aspose.Slides for PHP via Java voor [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tags toevoegen aan presentaties**

Aspose.Slides maakt het mogelijk om tags toe te voegen aan presentaties. Een tag bestaat meestal uit twee onderdelen:

- de naam van een aangepaste eigenschap — `MyTag`
- de waarde van de aangepaste eigenschap — `My Tag Value`

Als je presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je baat hebben bij het toevoegen van tags aan die presentaties. Bijvoorbeeld, als je alle presentaties uit Noord‑Amerikaanse landen wilt groeperen, kun je een Noord‑Amerikaanse tag aanmaken en vervolgens de relevante landen (VS, Mexico en Canada) als waarden toewijzen.

Deze voorbeeldcode laat zien hoe je een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) met Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Of een individuele [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Beperkingen**

Tags die via de aangepaste data‑tagcollectie met `getCustomData()->getTags()` worden toegevoegd, worden uitsluitend opgeslagen binnen het PowerPoint‑bestand. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: Je kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijv. `$shape->setAlternativeText("MyId")`). Na exporteren naar PDF kan de Alt‑tekst verschijnen in de PDF‑tagstructuur.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/clear/) bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik de [remove(name)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/remove/) bewerking op de [tag collection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/) om de tag op sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/getnamesoftags/) op de [tag collection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tagcollection/); deze retourneert een array met alle tagnamen.