---
title: Beheren van tags en aangepaste gegevens in presentaties in .NET
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
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties beheert met Aspose.Slides voor .NET, inclusief het toevoegen, lezen, bijwerken, controleren en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

Aspose.Slides biedt API‑s voor het toevoegen, lezen, bijwerken, controleren en verwijderen van aangepaste XML‑onderdelen op presentatieniveau, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑beheer‑identifiers, workflow‑status, compliance‑metadata, sjabloon‑bindgegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatiesbestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, een onderdeel van de Office Open XML‑specificatie. Office Open XML definieert de pakketstructuur en relaties die worden gebruikt om presentatiewaarde en gerelateerde gegevens op te slaan.

Een presentatie bestaat uit meerdere onderdelen die via relaties met elkaar verbonden zijn. Een dia‑onderdeel bevat bijvoorbeeld de inhoud van één dia en kan expliciete relaties hebben met andere onderdelen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/itagcollection)) of aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection)). Beide zijn beschikbaar via de [`ICustomData`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomdata/)‑interface.

{{% alert color="primary" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waarde‑paren op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De eigenschap [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomdata/customxmlparts/) geeft de collectie van aangepaste XML‑onderdelen terug die zijn gekoppeld aan een specifiek presentatiedoel. Bijvoorbeeld:

- `presentation.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die zijn gekoppeld aan de presentatie zelf.
- `slide.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die zijn gekoppeld aan een specifieke dia.
- `shape.CustomData.CustomXmlParts` bevat aangepaste XML‑onderdelen die zijn gekoppeld aan een specifieke vorm.

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze zijn gekoppeld.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/add/) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de presentatieniveau‑custom‑data‑collectie:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"\">" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add wijst automatisch een identifier toe. Stel alleen een specifieke GUID in wanneer dat nodig is.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

De `Add`‑methode kan ook XML accepteren als een byte‑array of stream, wat handig is wanneer XML‑inhoud al beschikbaar is in binaire vorm.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de volledige presentatie. Dit is handig wanneer metadata slechts een enkel object beschrijft, zoals een sjabloonsleutel, een extern record‑identifier of bindinformatie.

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke `CustomData.CustomXmlParts`‑collectie van een object de relatie naar dat onderdeel bevat. Presentatieniveau‑gegevens zijn geschikt voor metadata die het hele document betreft, dia‑niveau‑gegevens voor informatie die bij een specifieke dia hoort, en vorm‑niveau‑gegevens voor metadata die aan een individuele vorm is gekoppeld.

### **Alle aangepaste XML‑onderdelen weergeven en controleren**

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/) geeft zijn identifier, XML‑inhoud en bijbehorende namespace‑schemas weer.

Het volgende voorbeeld geeft alle aangepaste XML‑onderdelen en hun namespace‑schemas weer:

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/namespaceschemas/) retourneert de XML‑schemas die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het controleren van presentaties die XML bevatten die door externe systemen is gegenereerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/xmlasstring/) om met XML te werken als een UTF‑8‑tekenreeks, of [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/xmldata/) om met de ruwe XML‑bytes te werken. Beide eigenschappen kunnen worden gelezen en bijgewerkt.

De eigenschap [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/itemid/) bevat de GUID die het aangepaste XML‑onderdeel in het Office Open XML‑document identificeert. Deze kan ook worden gewijzigd wanneer een integratie een nieuwe identifier vereist.

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

// Werk de XML bij als een UTF-8-tekenreeks.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData levert dezelfde XML-inhoud als ruwe bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Vervang de identifier wanneer de integratie dat vereist.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Bij het toekennen van `XmlAsString` of `XmlData` moet geldige, niet‑leeg XML worden opgegeven. Gebruik de ene representatie of de andere afhankelijk van of de applicatie voornamelijk met tekenreeksen of byte‑gegevens werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpart/remove/) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/remove/) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/removeat/) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/nl/net/aspose.slides/icustomxmlpartcollection/clear/) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één presentatieniveau‑custom‑XML‑onderdeel via referentie:

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

Als u al een `ICustomXmlPart` heeft en dat onderdeel uit de presentatie wilt verwijderen in plaats van een bepaalde collectie aan te spreken, roep dan `customXmlPart.Remove()` aan.

U kunt ook een item op index verwijderen:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `Clear` wanneer alle aangepaste XML‑onderdelen die aan een specifiek presentatiedoel zijn gekoppeld, verwijderd moeten worden.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` heeft alleen effect op de geselecteerde collectie. Bijvoorbeeld, het wissen van de collectie van een dia wist niet de collectie op presentatieniveau of vormniveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, doorloop `AllCustomXmlParts` en verwijder elk onderdeel:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Gelinkte of gedeelde aangepaste XML‑onderdelen verwerken**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel vanuit meer dan één presentatiedoel worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Het bijwerken van `XmlAsString`, `XmlData` of `ItemId` verandert het onderliggende aangepaste XML‑onderdeel, zodat de wijziging overal waar dat onderdeel wordt gerefereerd, wordt doorgevoerd.
- `ItemId` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren bij het controleren van object‑specifieke collecties.
- Het verwijderen van een onderdeel uit een specifieke `CustomXmlParts`‑collectie verwijdert het uit die collectie. Gebruik `ICustomXmlPart.Remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat u een gedeeld onderdeel verwijdert of vervangt, inspecteert u de object‑specifieke collecties om te bepalen of andere dia’s of vormen er nog naar verwijzen.

De `Add`‑overloads maken een nieuw aangepast XML‑onderdeel aan op basis van XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties vooral voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld controleert presentatieniveau‑, dia‑ en vorm‑collecties op `ItemId` en meldt onderdelen die vanuit meer dan één plek worden gerefereerd:

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

Dit type controle is nuttig vóór het wijzigen of verwijderen van aangepaste XML‑gegevens in presentaties die door externe systemen zijn gegenereerd, omdat hetzelfde metadata‑onderdeel in meerdere relaties kan optreden.

## **Waarden van tags ophalen**

In slides komt een tag overeen met de eigenschap `IDocumentProperties.Keywords`. Deze voorbeeldcode laat zien hoe u een tag‑waarde kunt ophalen met Aspose.Slides voor .NET voor een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Tags toevoegen aan presentaties**

Aspose.Slides maakt het mogelijk om tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee items:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Als u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u daarvoor tags aanmaken. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) met Aspose.Slides voor .NET:

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

Tags die via de `CustomData.Tags`‑collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgenomen in de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is opgeslagen, niet worden opgehaald uit de getagde PDF.

**Workaround**: U kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape.AlternativeText = "MyId"`). Na export naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De tag‑collectie ondersteunt een `Clear`‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik `Remove(name)` op `TagCollection` om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik `GetNamesOfTags` op de tag‑collectie; deze retourneert een array met alle tagnamen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/allcustomxmlparts/) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `XmlAsString` of `XmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `XmlAsString` wanneer de applicatie werkt met UTF‑8‑XML‑tekst. Gebruik `XmlData` wanneer de XML al beschikbaar is als een byte‑array of wanneer binair‑georiënteerde verwerking handiger is. Beide eigenschappen vertegenwoordigen dezelfde XML‑inhoud van het aangepaste XML‑onderdeel.