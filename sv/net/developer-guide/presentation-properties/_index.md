---
title: Hantera presentationsegenskaper i .NET
linktitle: Presentationssegenskaper
type: docs
weight: 70
url: /sv/net/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations-egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- språk för korrekturläsning
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för .NET och effektivisera sökning, varumärkesprofil och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides for .NET stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides for .NET API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av egenskapen [Presentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/documentproperties/) . Följande exempel visar hur du läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" %}} 

Observera att fälten **Application** och **Producer** inte kan modifieras, eftersom dessa fält alltid kommer att visa "Aspose Ltd." och "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint tillhandahåller en funktion för att lägga till egenskaper i presentationsfiler. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med filerna. Det finns två typer av dokumentegenskaper:

- Systemdefinierade (inbyggda) egenskaper
- Användardefinierade (anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik och mer.

**Anpassade** egenskaper definieras av användare som **Namn/Värde**‑par, där både namn och värde specificeras av användaren.

Med Aspose.Slides for .NET kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper.

Microsoft PowerPoint låter användare hantera dokumentegenskaper genom att klicka på Office‑ikonen och sedan välja **File → Info → Properties**. Efter att ha valt **Advanced Properties** visas en dialogruta där du kan hantera alla dokumentegenskaper för presentationsfilen.

I dialogrutan **Properties** finns flera flikar, såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Varje flik ger alternativ för att konfigurera specifika typer av information relaterad till PowerPoint‑filen. Fliken **Custom** används för att hantera användardefinierade egenskaper.

## **Komma åt inbyggda egenskaper**

Dessa egenskaper, som exponeras av gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) , inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indikeras om dokumentet delas mellan olika producenter), **PresentationFormat**, **Subject**, **Title** och fler.

```cs
using Aspose.Slides;

// Skapa ett Presentation-objekt som representerar en presentationsfil.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Visa de inbyggda egenskaperna.
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

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap, och egenskapens värde kommer att uppdateras. I exemplet nedan visar vi hur du ändrar de inbyggda dokumentegenskaperna för en presentationsfil.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ange de inbyggda egenskaperna.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Lägg till anpassade presentationsegenskaper**

Anpassade presentationsegenskaper gör det möjligt för utvecklare att lagra ytterligare metadata eller specifik information i en presentationsfil. Aspose.Slides underlättar att skapa och hantera dessa anpassade egenskaper programmässigt. Följande exempel demonstrerar hur du lägger till anpassade egenskaper i dina presentationer.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen.
using Presentation presentation = new Presentation();

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Lägg till anpassade egenskaper.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Spara presentationen till en fil.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Komma åt och ändra anpassade egenskaper**

Aspose.Slides låter också utvecklare komma åt befintliga anpassade egenskaper och enkelt ändra deras värden. Denna funktionalitet hjälper till att hålla metadata korrekt och stödjer dynamiska uppdateringar baserade på användarinmatning eller affärslogik. Exemplen nedan visar hur du hämtar och uppdaterar värden för anpassade egenskaper i en presentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Kom åt och ändra de anpassade egenskaperna.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Visa namn och värde för den anpassade egenskapen.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ändra värdet för den anpassade egenskapen.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Spara presentationen till en fil.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑exempel**

Prova den onlinetjänst [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur du arbetar med dokumentegenskaper med Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

### Hur kan jag ta bort en inbyggd egenskap från en presentation?

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

### Vad händer om jag lägger till en anpassad egenskap som redan finns?

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

### Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `GetPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/) . Använd sedan metoden `ReadDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.