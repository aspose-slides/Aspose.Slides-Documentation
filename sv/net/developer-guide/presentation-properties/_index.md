---
title: Hantera presentationsegenskaper i .NET
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/net/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för .NET och förenkla sökning, varumärkesbyggande och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides for .NET stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides for .NET API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av egenskapen [Presentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/documentproperties/) . Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 

Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa fält alltid kommer att visa "Aspose Ltd." och "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till egenskaper i presentationsfiler. Dessa dokumentegenskaper möjliggör lagring av användbar information tillsammans med filerna. Det finns två typer av dokumentegenskaper:

- Systemdefinierade (inbyggda) egenskaper
- Användardefinierade (anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik och mer.

**Anpassade** egenskaper definieras av användare som **Namn/Värde**‑par, där både namnet och värdet anges av användaren.

Med Aspose.Slides for .NET kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper.

Microsoft PowerPoint låter användare hantera dokumentegenskaper genom att klicka på Office‑ikonen och sedan välja **File → Info → Properties**. Efter att ha valt **Advanced Properties** visas en dialogruta där du kan hantera alla dokumentegenskaper för presentationsfilen.

I dialogrutan **Properties** finns flera flikar, såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. varje flik erbjuder alternativ för att konfigurera specifika typer av information relaterad till PowerPoint‑filen. Fliken **Custom** används för att hantera användardefinierade egenskaper.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper, som exponeras av gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) , inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indikerar om dokumentet delas mellan olika producenter), **PresentationFormat**, **Subject**, **Title**, och mer.

```cs
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modifiera inbyggda egenskaper**

Att modifiera de inbyggda egenskaperna i presentationsfiler är lika enkelt som att nå dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap, och egenskapens värde uppdateras. I exemplet nedan demonstrerar vi hur man modifierar de inbyggda dokumentegenskaperna för en presentationsfil.

```cs
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är kopplat till presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ställ in de inbyggda egenskaperna.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Spara presentationen till en fil.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Lägg till anpassade presentationsegenskaper**

Anpassade presentationsegenskaper gör det möjligt för utvecklare att lagra ytterligare metadata eller specifik information i en presentationsfil. Aspose.Slides gör det enkelt att programatiskt skapa och hantera dessa anpassade egenskaper. Följande exempel visar hur du lägger till anpassade egenskaper i dina presentationer.

```cs
// Skapa en instans av Presentation-klassen.
using Presentation presentation = new Presentation();

// Hämta en referens till objektet av typen IDocumentProperties som är kopplat till presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Lägg till anpassade egenskaper.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Spara presentationen till en fil.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Åtkomst till och modifiera anpassade egenskaper**

Aspose.Slides låter även utvecklare komma åt befintliga anpassade egenskaper och enkelt modifiera deras värden. Denna funktionalitet hjälper till att upprätthålla korrekt metadata och stödjer dynamiska uppdateringar baserade på användarinmatning eller affärslogik. Exemplen nedan illustrerar hur man hämtar och uppdaterar anpassade egenskapsvärden i en presentation.

```cs
// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är kopplat till presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Visa namn och värde för den anpassade egenskapen.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifiera värdet för den anpassade egenskapen.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Spara presentationen till en fil.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑exempel**

Prova den online‑appen [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur du arbetar med dokumentegenskaper med Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `GetPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/) . Använd sedan metoden `ReadDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.