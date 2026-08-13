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
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- paarwaarden
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides voor .NET, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

Aspose.Slides biedt API’s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen op presentatieniveau, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑beheerders‑identifiers, workflow‑status, compliance‑metadata, template‑bindinggegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiesbestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatiewijzigingen en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Een dia‑onderdeel bijvoorbeeld bevat de inhoud van één dia en kan expliciete relaties hebben met andere onderdelen, gedefinieerd volgens ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/itagcollection)) of aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection)). Beide zijn beschikbaar via de [`ICustomData`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomdata/) interface.

{{% alert color="info" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waardeparen op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen aan een presentatie, dia of vorm gekoppeld worden.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De eigenschap [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomdata/customxmlparts/) levert de collectie van aangepaste XML‑onderdelen die aan een specifiek presentatie‑object zijn gekoppeld. Bijvoorbeeld:

- `presentation.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die bij de presentatie zelf horen.
- `slide.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die bij een specifieke dia horen.
- `shape.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die bij een specifieke vorm horen.

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) wanneer u alle aangepaste XML‑onderdelen in de presentatie moet inspecteren, ongeacht waar ze zijn gekoppeld.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/add/) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de aangepaste gegevensverzameling op presentatieniveau:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add kent automatisch een identifier toe. Stel een specifieke GUID alleen in wanneer nodig.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

De `Add`‑methode kan ook XML accepteren als byte‑array of stream, wat nuttig is wanneer XML‑inhoud al in binaire vorm beschikbaar is.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen aan een specifieke dia of vorm worden gekoppeld in plaats van aan de hele presentatie. Dit is nuttig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, externe record‑identifier of bind‑informatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een dia en een ander aan een vorm:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke `CustomData.CustomXmlParts`‑collectie van welk object de relatie naar dat onderdeel bevat. Gegevens op presentatieniveau zijn geschikt voor metadata over het hele document, gegevens op dia‑niveau voor informatie die bij een bepaalde dia hoort, en gegevens op vorm‑niveau voor metadata die aan een individuele vorm gekoppeld is.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elke [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/) toont zijn identifier, XML‑inhoud en bijbehorende namespace‑schema's.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schema's op:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

`ICustomXmlPart.NamespaceSchemas` geeft de XML‑schema's terug die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/xmlasstring/) om met XML te werken als UTF‑8‑tekst, of [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/xmldata/) om met de ruwe XML‑bytes te werken. Beide eigenschappen kunnen gelezen en bijgewerkt worden.

De eigenschap [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/itemid/) bevat de GUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Deze kan ook gewijzigd worden wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Lees de huidige XML als tekst.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Werk de XML bij als een UTF-8 tekenreeks.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData levert dezelfde XML-inhoud als ruwe bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Vervang de identifier wanneer de integratie dit vereist.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Bij het toewijzen van `XmlAsString` of `XmlData` moet u geldige, niet‑lege XML leveren. Gebruik de ene of de andere representatie afhankelijk van of de toepassing voornamelijk met tekenreeksen of byte‑gegevens werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/remove/) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/remove/) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/removeat/) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/clear/) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één aangepast XML‑onderdeel op presentatieniveau via referentie:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Als u al een `ICustomXmlPart` hebt en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `customXmlPart.Remove()` aan.

U kunt ook een item verwijderen op basis van index:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `Clear` wanneer alle aangepaste XML‑onderdelen die aan een bepaald presentatie‑object zijn gekoppeld verwijderd moeten worden.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` heeft alleen effect op de geselecteerde collectie. Het wissen van de collectie van een dia bijvoorbeeld, wist niet de collecties op presentatieniveau of vormniveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, iterate door `AllCustomXmlParts` en verwijder elk onderdeel:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Gekoppelde of gedeelde aangepaste XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel vanuit meer dan één presentatie‑object worden gerefereerd. Een bestaand bestand kan bijvoorbeeld relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Het bijwerken van `XmlAsString`, `XmlData` of `ItemId` wijzigt het onderliggende aangepaste XML‑onderdeel, waardoor de wijziging overal geldt waar dat onderdeel wordt gerefereerd.
- `ItemId` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑level collecties.
- Het verwijderen van een onderdeel uit een specifieke `CustomXmlParts`‑collectie verwijdert het uit die collectie. Gebruik `ICustomXmlPart.Remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat u een gedeeld onderdeel verwijdert of vervangt, controleer de object‑level collecties om te bepalen of andere dia’s of vormen het nog steeds refereren.

De `Add`‑overloads maken een nieuw aangepast XML‑onderdeel aan vanuit XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties het vaakst voor bij het laden van presentaties die deze al bevatten.

Het volgende voorbeeld audit de collecties op presentatieniveau, dia‑ en vorm‑niveau op basis van `ItemId` en rapporteert onderdelen die vanuit meer dan één plaats worden gerefereerd:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Dit type audit is nuttig voordat u aangepaste XML‑gegevens wijzigt of verwijdert in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel mogelijk in meer dan één relatie participeert.

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de eigenschap `IDocumentProperties.Keywords`. Deze voorbeeldcode toont hoe u een tag‑waarde kunt ophalen met Aspose.Slides for .NET voor [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt u in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee elementen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Als u presentaties moet classificeren op basis van een specifieke regel of eigenschap, kunt u tags hiervoor toevoegen. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode laat zien hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) met Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Beperkingen**

Tags die via de `CustomData.Tags`‑collectie worden toegevoegd, worden alleen opgeslagen in het PowerPoint‑bestand. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie naar PDF wordt geëxporteerd. Hierdoor kan een aangepaste identifier die als tag is toegewezen niet uit de getagde PDF worden opgehaald.

**Omzeil‑oplossing**: u kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.AlternativeText = "MyId"`). Na exporteren naar PDF kan de alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/) ondersteunt een [Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waardeparen in één keer verwijdert.

**Hoe kan ik een enkele tag verwijderen op basis van de naam zonder de hele collectie te doorlopen?**

Gebruik [Remove(name)](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/remove/) op [TagCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/) om de tag te verwijderen op basis van zijn sleutel.

**Hoe kan ik de volledige lijst van tagnamen ophalen voor analyses of filtering?**

Gebruik [GetNamesOfTags](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/getnamesoftags/) op de [tag collection](https://reference.aspose.com/slides/nl/net/aspose.slides/tagcollection/); dit geeft een array terug met alle tagnamen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `XmlAsString` of `XmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `XmlAsString` wanneer de toepassing werkt met UTF‑8 XML‑tekst. Gebruik `XmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer een binaire verwerking handiger is. Beide eigenschappen vertegenwoordigen de XML‑inhoud van hetzelfde aangepaste XML‑onderdeel.