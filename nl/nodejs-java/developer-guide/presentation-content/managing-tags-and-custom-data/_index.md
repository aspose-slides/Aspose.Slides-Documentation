---
title: Tags en aangepaste gegevens beheren in presentaties met JavaScript
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/nodejs-java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- waardeparen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor Node.js, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint-presentaties. Het geeft kort weer hoe gegevens worden opgeslagen in PPTX-bestanden, vermeldt dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML-onderdelen, en beschrijft tags als sleutel-waarde-tekenreeksparen.

Het laat ook zien hoe je tag-waarden kunt lezen en hoe je tags kunt toevoegen aan een presentatie, een individuele dia of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag-beheertaken, zoals alle tags wissen, een tag verwijderen op naam, en de lijst met tag-namen ophalen.

## **Gegevensopslag in presentatiebestanden**

PPTX-bestanden — items met de extensie .pptx — worden opgeslagen in het PresentationML-formaat, dat deel uitmaakt van de Office Open XML-specificatie. Het Office Open XML-formaat definieert de structuur voor gegevens die in presentaties voorkomen.

Aangezien een *dia* een van de elementen in presentaties is, bevat een *dia-onderdeel* de inhoud van één enkele dia. Een dia-onderdeel mag expliciete relaties hebben met vele onderdelen - zoals door de gebruiker gedefinieerde tags - die gedefinieerd zijn door ISO/IEC 29500.

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([TagCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TagCollection)) en CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Tags zijn in wezen tekenreeks-sleutel-paren. 
{{% /alert %}} 

## **Waarden van tags ophalen**

In dia's komt een tag overeen met de methoden [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) en [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Deze voorbeeldcode toont hoe je de waarde van een tag kunt ophalen met Aspose.Slides voor Node.js via Java voor [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee elementen:
- de naam van een aangepaste eigenschap - `MyTag`
- de waarde van de aangepaste eigenschap - `My Tag Value`

Als je enkele presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je profiteren van het toevoegen van tags aan die presentaties. Bijvoorbeeld, als je alle presentaties uit Noord-Amerikaanse landen wilt groeperen, kun je een Noord-Amerikaanse tag aanmaken en vervolgens de relevante landen (de VS, Mexico en Canada) als waarden toewijzen.

Deze voorbeeldcode toont hoe je een tag kunt toevoegen aan een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) met Aspose.Slides voor Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Of elke individuele [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Beperkingen**

Tags die via de aangepaste datatag-collectie met `getCustomData().getTags()` worden toegevoegd, worden alleen opgeslagen in het PowerPoint-bestand. Ze worden **niet** overgedragen naar de PDF-tagstructuur wanneer de presentatie naar PDF wordt geëxporteerd. Hierdoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: Je kunt een aangepaste identifier opslaan in de **Alt-tekst** van het object (bijv. `shape.setAlternativeText("MyId")`). Na exporteren naar PDF kan de Alt-tekst in de PDF-tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel-waarde-paren in één keer verwijdert.

**Hoe kan ik een enkele tag op naam verwijderen zonder over de volledige collectie te itereren?**

Gebruik de [remove(name)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/remove/)‑bewerking op [TagCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/) om de tag via de sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tag-namen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) op de [tag collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tagcollection/); deze retourneert een array met alle tag-namen.