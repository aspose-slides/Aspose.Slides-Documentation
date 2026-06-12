---
title: Tags en aangepaste gegevens beheren in presentaties met Java
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- paarwaarden
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor Java, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het schetst kort hoe gegevens worden opgeslagen in PPTX‑bestanden, merkt op dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde‑tekenreeksparen.

Het laat ook zien hoe je tag‑waarden leest en hoe je tags toevoegt aan een presentatie, een individuele dia of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag‑beheer taken, zoals het wissen van alle tags, het verwijderen van een tag op naam, en het ophalen van de lijst met tagnamen.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden—items met de .pptx‑extensie—worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens in presentaties.

Met een *slide* als een van de elementen in presentaties, bevat een *slide‑part* de inhoud van één dia. Een slide‑part mag expliciete relaties hebben met veel onderdelen—zoals User Defined Tags—gedefinieerd door ISO/IEC 29500.

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([ITagCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITagCollection)) en CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Tags zijn in essentie tekenreeks‑sleutel‑paren. 
{{% /alert %}} 

## **Waarden van tags ophalen**

In slides komt een tag overeen met de [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IDocumentProperties#getKeywords--) en [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) methoden. Deze voorbeeldcode toont hoe je de waarde van een tag krijgt met Aspose.Slides for Java voor [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags toe te voegen aan presentaties. Een tag bestaat meestal uit twee onderdelen:

- de naam van een aangepaste eigenschap – `MyTag`
- de waarde van de aangepaste eigenschap – `My Tag Value`

Als je presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je profiteren van het toevoegen van tags. Bijvoorbeeld, als je alle presentaties uit Noord-Amerikaanse landen wilt groeperen, kun je een North American‑tag aanmaken en vervolgens de relevante landen (de VS, Mexico en Canada) als waarden toewijzen.

Deze voorbeeldcode laat zien hoe je een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) met Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Beperkingen**

Tags die via de aangepaste datatag‑collectie worden toegevoegd met `getCustomData().getTags()` worden alleen opgeslagen in het PowerPoint‑bestand. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: Je kunt een aangepaste identifier opslaan in de **Alt Text** van het object (bijv. `shape.setAlternativeText("MyId")`). Na exporteren naar PDF kan de Alt Text verschijnen in de PDF‑tagstructuur.

## **FAQ**

**Kan ik alle tags van een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#clear--) bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie door te lopen?**

Gebruik de [Remove(name)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) bewerking op de [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/) om de tag op sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/#getNamesOfTags--) op de [tag collection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tagcollection/); het retourneert een array met alle tagnamen.