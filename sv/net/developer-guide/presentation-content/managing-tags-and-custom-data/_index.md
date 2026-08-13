---
title: Hantera taggar och anpassade data i presentationer i .NET
linktitle: Taggar och anpassade data
type: docs
weight: 300
url: /sv/net/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassade data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- parvärden
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassade XML-data i PowerPoint-presentationer med Aspose.Slides för .NET, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML-delar."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides arbetar med taggar och anpassade data i PowerPoint‑presentationer. Presentationsspecifika data kan lagras som taggar eller anpassade XML‑delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML‑delar kan lagra strukturerad metadata och applikationsspecifika XML‑payloads.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar på presentations‑, bild‑ och formnivå. Anpassade XML‑delar är användbara för integrationer som lagrar information såsom dokumenthanterings‑identifierare, arbetsflödestillstånd, efterlevnads‑metadata, mall‑bindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datälagring i presentationsfiler**

PPTX‑filer – filer med filändelsen `.pptx` – lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterade data.

En presentation innehåller flera delar som är kopplade med relationer. Till exempel innehåller en bilddel innehållet för en enda bild och kan ha explicita relationer till andra delar som definieras av ISO/IEC 29500.

Anpassade data kan lagras som taggar ([ITagCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/itagcollection)) eller anpassade XML‑delar ([ICustomXmlPartCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection)). Båda är tillgängliga via gränssnittet [`ICustomData`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Taggar lagrar enkla sträng‑nyckel‑värde‑par. Anpassade XML‑delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML‑delar**

Gränssnittet [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomdata/customxmlparts/) returnerar samlingen av anpassade XML‑delar som är kopplade till ett specifikt presentationsobjekt. Till exempel:

- `presentation.CustomData.CustomXmlParts` innehåller anpassade XML‑delar som är associerade med själva presentationen.
- `slide.CustomData.CustomXmlParts` innehåller anpassade XML‑delar som är associerade med en specifik bild.
- `shape.CustomData.CustomXmlParts` innehåller anpassade XML‑delar som är associerade med en specifik form.

Använd [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/allcustomxmlparts/) när du behöver undersöka alla anpassade XML‑delar i presentationen oavsett var de är kopplade.

### **Lägg till en anpassad XML‑del i en presentation**

Använd [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection/add/) för att lägga till XML‑data i en samling av anpassade XML‑delar. XML‑filen måste vara giltig och icke‑tom.

Följande exempel lägger till strukturerad metadata i presentations‑nivåns anpassade datainsamling:

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

// Add tilldelar automatiskt ett identifierare. Ange en specifik GUID endast när det krävs.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add`‑metoden kan också ta emot XML som en byte‑array eller ström, vilket är användbart när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML‑del i en bild eller form**

Anpassad XML‑data kan kopplas till en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata bara beskriver ett objekt, till exempel en mallnyckel, ett externt post‑identifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML‑del i en bild och en annan i en form:

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

Nivån där en del läggs till bestämmer vilken objekts `CustomData.CustomXmlParts`‑samling som innehåller relationen till den delen. Data på presentationsnivå är lämplig för dokumentomfattande metadata, bildnivådata för information som tillhör en viss bild och formnivådata för metadata knuten till en enskild form.

### **Lista och granska alla anpassade XML‑delar**

Använd [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/allcustomxmlparts/) för att hämta alla anpassade XML‑delar från en presentation. Varje [`ICustomXmlPart`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/) exponerar sitt identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML‑delar och deras namnrymdsscheman:

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

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/namespaceschemas/) returnerar XML‑schemana som är associerade med den anpassade XML‑delen. Denna information kan vara användbar när du granskar presentationer som innehåller XML som producerats av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/xmlasstring/) för att arbeta med XML som en UTF‑8‑sträng, eller [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/xmldata/) för att arbeta med råa XML‑byte. Båda egenskaperna kan läsas och uppdateras.

[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/itemid/) innehåller GUID‑en som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Den kan också ändras när en integration kräver ett nytt identifierare.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Läs den aktuella XML:n som text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Uppdatera XML:n som en UTF-8-sträng.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData tillhandahåller samma XML-innehåll som råa byte.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Ersätt identifieraren när integrationen kräver det.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

När du tilldelar `XmlAsString` eller `XmlData` ska du ange giltig, icke‑tom XML. Använd den ena representationen eller den andra beroende på om applikationen främst arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML‑del**

Aspose.Slides tillhandahåller flera sätt att ta bort anpassad XML‑data:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpart/remove/) tar bort den anpassade XML‑delen från presentationen.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection/remove/) tar bort en specifik del från en samling av anpassade XML‑delar.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection/removeat/) tar bort delen på ett angivet index i samlingen.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/sv/net/aspose.slides/icustomxmlpartcollection/clear/) tar bort alla delar från en specifik samling.

Följande exempel tar bort en presentations‑nivå XML‑del genom referens:

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

Om du redan har ett `ICustomXmlPart` och vill ta bort den delen från presentationen snarare än att adressera en specifik samling, anropa `customXmlPart.Remove()`.

Du kan också ta bort ett objekt efter index:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Rensa alla anpassade XML‑delar från en samling**

Använd `Clear` när alla anpassade XML‑delar som är kopplade till ett specifikt presentationsobjekt ska tas bort.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` påverkar endast den valda samlingen. Till exempel rensar en bilds samling inte presentations‑ eller form‑samlingarna.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom `AllCustomXmlParts` och ta bort varje del:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Hantera länkade eller delade anpassade XML‑delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från mer än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande XML‑del.

En delad del bör behandlas som ett dataobjekt med flera referenser:

- Att uppdatera dess `XmlAsString`, `XmlData` eller `ItemId` ändrar den underliggande XML‑delen, så förändringen gäller överallt där delen refereras.
- `ItemId` kan användas för att identifiera samma anpassade XML‑del vid granskning av objekt‑nivåsamlingar.
- Att ta bort en del från en specifik `CustomXmlParts`‑samling tar bort den endast från den samlingen. Använd `ICustomXmlPart.Remove()` när delen själv ska tas bort från presentationen.
- Innan du raderar eller ersätter en delad del, inspektera objekt‑nivåsamlingarna för att avgöra om andra bilder eller former fortfarande refererar till den.

`Add`‑överladdningarna skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte ett befintligt `ICustomXmlPart`. Därför möts delade relationer oftast när presentationer som redan innehåller dem laddas.

Följande exempel granskar presentations‑, bild‑ och form‑samlingar efter `ItemId` och rapporterar delar som refereras från mer än en plats:

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

Denna typ av granskning är användbar innan du modifierar eller tar bort anpassad XML‑data i presentationer skapade av externa system, eftersom samma metadata‑del kan delta i flera relationer.

## **Hämta värden på taggar**

I slides motsvarar en tagg egenskapen `IDocumentProperties.Keywords`. Följande exempel visar hur du får ett taggvärde med Aspose.Slides för .NET för [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två delar:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer baserat på en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från Nordamerika kan du skapa en Nordamerika‑tagg och tilldela det relevanta landet som dess värde.

Följande exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) med Aspose.Slides för .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Begränsningar**

Taggar som läggs till via samlingen `CustomData.Tags` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelats som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. `shape.AlternativeText = "MyId"`). Efter export till PDF kan Alt‑texten visas i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en enda operation?**

Ja. [tag‑samling] stöder en [Clear]‑operation som raderar alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [Remove(name)] på [TagCollection] för att ta bort taggen med dess nyckel.

**Hur kan jag hämta den fullständiga listan med taggnamn för analys eller filtrering?**

Använd [GetNamesOfTags] på [tag‑samling]; den returnerar en array med alla taggnamn.

**Hur kan jag hitta alla anpassade XML‑delar oavsett var de lagras?**

Använd [`Presentation.AllCustomXmlParts`] för att hämta alla anpassade XML‑delar i presentationen.

**Ska jag använda `XmlAsString` eller `XmlData` för att uppdatera en anpassad XML‑del?**

Använd `XmlAsString` när applikationen arbetar med UTF‑8‑XML‑text. Använd `XmlData` när XML redan finns som en byte‑array eller när binär bearbetning är mer bekväm. Båda egenskaperna representerar XML‑innehållet i samma anpassade XML‑del.