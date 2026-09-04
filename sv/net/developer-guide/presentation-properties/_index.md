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
- förvalt språk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för .NET och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för .NET stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides för .NET API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av [IPresentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/documentproperties/). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Obs" %}}
Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa fält alltid visar "Aspose Ltd." och "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till egenskaper i presentationsfiler. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med filerna. Det finns två typer av dokumentegenskaper:

- Systemdefinierade (inbyggda) egenskaper
- Användardefinierade (anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet, såsom dokumenttitel, författarens namn, dokumentstatistik och mer.

**Anpassade** egenskaper definieras av användare som **Namn/Värde**‑par, där både namn och värde är specifika för användaren.

Med Aspose.Slides för .NET kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper.

Microsoft PowerPoint låter användare hantera dokumentegenskaper genom att klicka på Office‑ikonen och sedan välja **File → Info → Properties**. Efter att ha valt **Advanced Properties** visas en dialog där du kan hantera alla dokumentegenskaper för presentationsfilen.

I dialogrutan **Properties** finns flera flikar, såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Varje flik ger alternativ för att konfigurera specifika typer av information relaterad till PowerPoint‑filen. Fliken **Custom** används för att hantera användardefinierade egenskaper.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation är krypterad med [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) satt till `false` förblir dess dokumentegenskaper offentliga. En applikation kan då sätta [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) till `true` och läsa den offentliga metadata utan att ange öppningslösenordet.

`OnlyLoadDocumentProperties` styr vad Aspose.Slides laddar; det dekrypterar ingenting. Om egenskaperna ingick i krypteringen misslyckas laddning utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) och läser sedan inbyggda egenskaper via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

I detta läge laddas inte bildinnehåll. Slides, masters, layouts, shapes, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera `IsOnlyDocumentPropertiesLoaded` innan en operation som kräver hela presentationsobjektmodellen utförs.

{{% alert color="warning" title="Säkerhet" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Låt dem vara offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt behov av att komma åt dem utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper i en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas med `OnlyLoadDocumentProperties` avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det objektet som endast innehåller metadata, eftersom de offentliga egenskaperna måste förbli i linje med motsvarande data i den krypterade presentationen. Därför krävs korrekt öppningslösenord och en fullständig laddning för att uppdatera dem.

Följande exempel öppnar presentationen med [LoadOptions.Password](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/password/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter används [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/isencrypted/) för att verifiera att krypteringen bevaras och den offentliga metadata öppnas igen utan lösenord för att verifiera de nya värdena:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Om en applikation inte får decrypta eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper, som exponeras av gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/), inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indikerar om dokumentet delas mellan olika producenter), **PresentationFormat**, **Subject**, **Title** och mer.

```cs
using Aspose.Slides;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är kopplat till presentationen.
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

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap, så uppdateras egenskapens värde. I exemplet nedan visar vi hur du ändrar de inbyggda dokumentegenskaperna för en presentationsfil.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Sätt de inbyggda egenskaperna.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Spara presentationen till en fil.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Lägg till anpassade presentationsegenskaper**

Anpassade presentationsegenskaper gör det möjligt för utvecklare att lagra ytterligare metadata eller specifik information i en presentationsfil. Aspose.Slides förenklar att programatiskt skapa och hantera dessa anpassade egenskaper. Följande exempel demonstrerar hur du lägger till anpassade egenskaper i dina presentationer.

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

## **Åtkomst och ändring av anpassade egenskaper**

Aspose.Slides låter också utvecklare komma åt befintliga anpassade egenskaper och enkelt ändra deras värden. Denna funktionalitet hjälper till att hålla metadata korrekt och stödjer dynamiska uppdateringar baserade på användarinmatning eller affärslogik. Exemplen nedan visar hur du hämtar och uppdaterar anpassade egenskapsvärden i en presentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en PPTX-fil.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Hämta en referens till objektet av typen IDocumentProperties som är associerat med presentationen.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Åtkomst till och ändra de anpassade egenskaperna.
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

## **Liveexempel**

Prova den [**Visa & redigera PowerPoint-metadata**](https://products.aspose.app/slides/sv/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper via Aspose.Slides‑API:n:

[![Visa & redigera PowerPoint-metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **Vanliga frågor**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller, om egenskapen tillåter det, sätta dem till ett tomt värde.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) och sedan [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/net/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats med `EncryptDocumentProperties` satt till `false`, och den måste laddas med `OnlyLoadDocumentProperties` satt till `true`.

**Kan jag uppdatera en krypterad PPTX‑fil i enbart dokumentegenskapsläge?**

Nej. Offentlig och krypterad egendomsdata måste förbli konsekventa, så uppdatering av en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.