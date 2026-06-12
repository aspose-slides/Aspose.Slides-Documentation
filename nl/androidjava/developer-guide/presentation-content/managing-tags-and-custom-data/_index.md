---
title: Beheer tags en aangepaste gegevens in presentaties op Android
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/androidjava/managing-tags-and-custom-data
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- sleutel-waardeparen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Tags en aangepaste gegevens toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor Android, met Java-voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het schetst kort hoe gegevens worden opgeslagen in PPTX‑bestanden, vermeldt dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde tekenreeksparen.

Het laat ook zien hoe je tag‑waarden kunt lezen en hoe je tags kunt toevoegen aan een presentatie, een individuele dia of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag‑beheertaken, zoals alle tags wissen, een tag verwijderen op naam, en de lijst met tagnamen opvragen.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden—items met de extensie .pptx—worden opgeslagen in het PresentationML‑formaat, dat onderdeel is van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens die zich in presentaties bevinden.

Met een *dia* als een van de elementen in presentaties, bevat een *dia‑onderdeel* de inhoud van één enkele dia. Een dia‑onderdeel mag expliciete relaties hebben met vele onderdelen—zoals door de gebruiker gedefinieerde tags—zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([ITagCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITagCollection)) en CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Tags zijn in wezen string‑sleutel‑waardeparen. 
{{% /alert %}} 

## **Waarden van tags ophalen**

In dia's komt een tag overeen met de [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) en [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) methoden. Deze voorbeeldcode laat zien hoe je de waarde van een tag kunt ophalen met Aspose.Slides voor Android via Java voor [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee onderdelen:

- de naam van een aangepaste eigenschap - `MyTag`
- de waarde van de aangepaste eigenschap - `My Tag Value`

Als je sommige presentaties moet classificeren op basis van een specifieke regel of eigenschap, kun je profiteren van het toevoegen van tags aan die presentaties. Bijvoorbeeld, als je alle presentaties uit Noord‑Amerikaanse landen wilt groeperen, kun je een Noord‑Amerikaanse tag aanmaken en vervolgens de relevante landen (de VS, Mexico en Canada) als waarden toewijzen.

Deze voorbeeldcode laat zien hoe je een tag kunt toevoegen aan een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) met Aspose.Slides voor Android via Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape):

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

Tags die via de aangepaste datatag‑collectie met `getCustomData().getTags()` worden toegevoegd, worden alleen opgeslagen in het PowerPoint‑bestand. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Oplossing**: Je kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijv. `shape.setAlternativeText("MyId")`). Na exporteren naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#clear--) bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de volledige collectie te doorlopen?**

Gebruik de [remove(name)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) bewerking op de [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) op de [tag collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tagcollection/); deze geeft een array terug met alle tagnamen.