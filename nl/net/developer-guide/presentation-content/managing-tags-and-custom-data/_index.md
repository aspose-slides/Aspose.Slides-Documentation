---
title: Beheer tags en aangepaste gegevens in presentaties in .NET
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/net/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- parenwaarden
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor .NET, met voorbeelden voor PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het schetst kort hoe gegevens worden opgeslagen in PPTX‑bestanden, merkt op dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde‑tekenreeksparen.

Het laat ook zien hoe u tagwaarden leest en hoe u tags toevoegt aan een presentatie, een individuele slide of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag‑beheertaken, zoals alle tags wissen, een tag verwijderen op naam, en de lijst met tagnamen opvragen.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — items met de extensie .pptx — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens die in presentaties worden opgenomen.

Met een *slide* als een van de elementen in presentaties bevat een *slide‑deel* de inhoud van één enkele slide. Een slide‑deel mag expliciete relaties hebben met veel onderdelen — zoals User Defined Tags — gedefinieerd door ISO/IEC 29500.

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([ITagCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/itagcollection)) en CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
Tags zijn in wezen string‑sleutel‑paarwaarden. 
{{% /alert %}} 

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de eigenschap IDocumentProperties.Keywords. Deze voorbeeldcode toont hoe u de waarde van een tag opvraagt met Aspose.Slides for .NET voor een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt u in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee onderdelen:

- de naam van een aangepast kenmerk — `MyTag` 
- de waarde van het aangepaste kenmerk — `My Tag Value`

Als u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u profiteren van het toevoegen van tags aan die presentaties. Bijvoorbeeld, als u alle presentaties uit Noord‑Amerikaanse landen wilt groeperen, kunt u een Noord‑Amerikaanse tag maken en vervolgens de betreffende landen (de VS, Mexico en Canada) als waarden toewijzen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) met Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Beperkingen**

Tags die via de `CustomData.Tags`‑collectie worden toegevoegd, worden alleen opgeslagen in het PowerPoint‑bestand. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepast identificatie‑element dat als tag is toegewezen, niet worden opgehaald uit de getagde PDF.

**Oplossing**: U kunt een aangepast identificatie‑element opslaan in de **Alt‑tekst** van het object (bijv. `shape.AlternativeText = "MyId"`). Na exporteren naar PDF kan de Alt‑tekst verschijnen in de PDF‑tagstructuur.

## **FAQ**

**Kan ik alle tags uit een presentatie, slide of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik de [Remove(name)](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/remove/)‑bewerking op de [TagCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/) om de tag op sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [GetNamesOfTags](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/getnamesoftags/) op de [tag collection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/); deze geeft een array terug met alle tagnamen.