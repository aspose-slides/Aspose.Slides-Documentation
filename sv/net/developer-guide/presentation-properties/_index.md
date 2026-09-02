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
- ändra egenskaper
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
description: "Behärska presentationsegenskaper i Aspose.Slides för .NET och effektivisera sökning, varumärkesprofil och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för .NET stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides för .NET API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av egenskapen [Presentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/documentproperties/) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa fält alltid kommer att visa "Aspose Ltd." och "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Hantera presentations egenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till egenskaper i presentationsfiler. Dessa dokumentegenskaper möjliggör lagring av användbar information tillsammans med filerna. Det finns två typer av dokumentegenskaper:

- Systemdefinierade (inbyggda) egenskaper
- Användardefinierade (anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik och mer.

**Anpassade** egenskaper definieras av användare som **Namn/Värde**-par, där både namn och värde anges av användaren.

Med Aspose.Slides för .NET kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper.

Microsoft PowerPoint låter användare hantera dokumentegenskaper genom att klicka på Office‑ikonen och sedan välja **File → Info → Properties**. Efter att ha valt **Advanced Properties** visas en dialogruta där du kan hantera alla dokumentegenskaper för presentationsfilen.

I dialogrutan **Properties** finns flera flikar, såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Varje flik ger alternativ för att konfigurera specifika typer av information relaterad till PowerPoint‑filen. Fliken **Custom** används för att hantera användardefinierade egenskaper.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper, enligt gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) innehåller: **Creator** (Författare), **Description**, **Keywords**, **Created** (Skapandedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **SharedDoc** (indikerar om dokumentet delas mellan olika producenter), **PresentationFormat**, **Subject**, **Title**, och mer.

```cs
using Aspose.Slides;

// Instansiera Presentation-klassen som representerar en presentationsfil.
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

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap, så uppdateras egenskapens värde. I exemplet nedan visar vi hur man ändrar de inbyggda dokumentegenskaperna i en presentationsfil.

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

// Spara presentationen till en fil.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Lägg till anpassade presentationsegenskaper**

Anpassade presentationsegenskaper gör det möjligt för utvecklare att lagra ytterligare metadata eller specifik information i en presentationsfil. Aspose.Slides gör det enkelt att skapa och hantera dessa anpassade egenskaper programmässigt. Följande exempel visar hur du lägger till anpassade egenskaper i dina presentationer.

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

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides låter även utvecklare komma åt befintliga anpassade egenskaper och enkelt ändra deras värden. Denna funktionalitet hjälper till att hålla metadata korrekt och stöder dynamiska uppdateringar baserade på användarinmatning eller affärslogik. Exemplen nedan visar hur man hämtar och uppdaterar värden för anpassade egenskaper inom en presentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Åtkomst till och ändring av de anpassade egenskaperna.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Visa namnet och värdet på den anpassade egenskapen.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ändra värdet på den anpassade egenskapen.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Spara presentationen till en fil.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑exempel**

Prova den online‑appen [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur man arbetar med dokumentegenskaper med Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) och sedan [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/net/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.