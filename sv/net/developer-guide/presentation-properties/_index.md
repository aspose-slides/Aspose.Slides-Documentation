---
title: Hantera presentations-egenskaper i .NET
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/net/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
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

Aspose.Slides för .NET stöder **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författare, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Aspose.Slides hanterar applikations- och producentmetadata när presentationer sparas; dessa fält identifierar den mjukvara som skapade utdata.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information tillsammans med presentationsinnehållet. De delas in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde‑par.

Aspose.Slides för .NET ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att granska dokumentmetadata. Dialogrutan grupperar information i flikar som **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar vanligtvis både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras med [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) satt till `false`, förblir dess dokumentegenskaper offentliga. En applikation kan då sätta [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) till `true` och läsa den offentliga metadatan utan att ange öppningslösenordet.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) styr vad Aspose.Slides läser in; det dekrypterar ingenting. Om egenskaperna inkluderades i krypteringen misslyckas inläsning utan lösenordet. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen läses in.

Exemplet kräver en krypterad presentation vars dokumentegenskaper lämnades offentliga. Det verifierar laddningsläget via [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) och läser sedan inbyggda egenskaper via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):
```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

I det här läget laddas inte bildinnehållet. Bilder, master‑bilder, layout, former, media och andra presentationsobjekt är inte tillgängliga. Applikationer bör alltid kontrollera [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Security" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt behov av att komma åt dem utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som lästs in med [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det objektet som bara innehåller metadata eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. En uppdatering kräver därför korrekt öppningslösenord och en fullständig inläsning.

Exemplet kräver en krypterad PPTX‑presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Sedan använder det [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata utan ett lösenord för att verifiera de nya värdena:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Om en applikation inte har rätt att dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) visar inbyggd metadata via typade egenskaper, inklusive [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) och [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Detta exempel öppnar en befintlig presentation och skriver dess lagrade metadata till konsolen. Värdena beror på den ingångspresentation som används; vissa fält kan vara tomma.
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Rapportera revisionsnummer och redigeringstid**

För att rapportera en rad för varje PPTX‑fil i mappen `presentations`, anropa [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) för att hämta dess [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) utan att ladda bilderna för redigering. Det standardmässiga `c`‑formatet för `TimeSpan` inkluderar dagantalet när varaktigheten når 24 timmar.
```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Exempel på utdata för en presentation med 1 dag, 2 timmar och 5 minuter inspelad redigeringstid:
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) är skrivbar metadata. Dess värde ensam kan inte fastställa hur många gånger presentationen sparats eller återuppbygga dess versionshistorik.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) är den redigeringstid som lagrats i filen. Ett värde på `00:00:00` betyder att den lagrade varaktigheten är noll. Det bevisar inte att ingen har redigerat presentationen.

## **Modifiera inbyggda egenskaper**

För att uppdatera inbyggd metadata, tilldela värden till de skrivbara egenskaper som exponeras av [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Detta exempel öppnar en befintlig presentation, sätter [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), och [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), och sparar sedan den uppdaterade presentationen med [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Den sparade PPTX‑filen innehåller den nya metadatan.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Hantera hyperlinkbasen**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) lagrar dokumentnivåns bas för relativa hyperlänkar. Detta är användbart när en presentation och dess länkade filer flyttas till en annan plats. Det är separat från en enskild hyperlink's [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/): att ändra basen skriver inte om de lagrade länkadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, t.ex. `target.html`, och en absolut länk, t.ex. `https://example.org/absolute.html`. Det läser den befintliga basen, tilldelar en ny basadress och sparar och öppnar sedan presentationen igen för att kontrollera värdet. Därefter rensar det basen med `string.Empty` och verifierar det tomma värdet i en separat sparad fil. Ersätt exempelbasadressen med platsen för dina länkade filer.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

De två verifieringsmeddelandena bör skriva ut `True`. Att rensa basen lämnar de enskilda hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på mappen `old`. Efter att ha ändrat basen till mappen `new`, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttar presentationen eller ändrar dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som inte har motsvarande inbyggt fält. [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) låter dig tilldela ett värde med egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde, och sparar presentationen med [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Att tilldela ett värde till ett befintligt namn ersätter den egenskapens värde.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Åtkomst till och modifiera anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) för att iterera över dem. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) accepterar ett nollbaserat index och returnerar namnet som används av [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Exemplet skriver ut varje ursprungligt namn och värde, ersätter varje värde med en numrerad sträng oavsett dess ursprungliga typ, och sparar ändringarna. Om det inte finns några anpassade egenskaper gör loopen inga förändringar.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live-exempel**

Prova den [**Visa & redigera PowerPoint-metadata**](https://products.aspose.app/slides/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper med Aspose.Slides‑API:t:
[![Visa & redigera PowerPoint-metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) och sedan [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑instans. Se [Bygg ett lättviktigt presentationsinventarium](/slides/sv/net/examine-presentation/) för ett fullständigt rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats med [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) satt till `false`, och den måste läsas in med [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) satt till `true`.

**Kan jag uppdatera en krypterad PPTX‑fil i endast‑dokumentegenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsekventa, så en uppdatering av en krypterad PPTX‑fil kräver att hela presentationen läses in med korrekt öppningslösenord.