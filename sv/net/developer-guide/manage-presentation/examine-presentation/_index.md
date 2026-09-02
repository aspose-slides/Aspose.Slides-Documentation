---
title: Hämta och uppdatera presentationsinformation i .NET
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/net/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- undersöka PPTX
- undersöka PPT
- undersöka ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med .NET för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dess dokumentmetadata utan att skapa en komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett register eller inspektera egenskaper innan du beslutar om du ska ladda och bearbeta presentationsinnehållet.

Den här artikeln demonstrerar lättviktig inspektion genom [PresentationFactory](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/) och [IPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/), samt målmedvetna uppdateringar genom [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/).

## **Kontrollera ett presentationsformat**

Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) instans. Egenskapen [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/loadformat/) rapporterar det upptäckta formatet, såsom PPTX, PPT eller ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Bygg ett lättviktigt presentationsregister**

När du bearbetar många presentationsfiler kan du behöva ett kompakt register för validering, indexering eller ett dokumenthanteringssystem. I detta scenario använder du [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) för att erhålla ett [IPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/)‑objekt, och sedan anropar du [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar ingen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans och kräver inte att du traverserar hela presentationsobjektmodellen.

De utökade egenskaperna som exponeras av [IDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/) ger följande registervärden:

| Egenskap | Inventarievärde |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/slides/sv/) | Totalt antal bilder. |
| [HiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/hiddenslides/) | Antal dolda bilder. |
| [Notes](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/notes/) | Antal bilder som innehåller anteckningar. |
| [Paragraphs](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/paragraphs/) | Totalt antal stycken, när tillgängligt. |
| [Words](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/words/) | Totalt antal ord. |
| [MultimediaClips](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/multimediaclips/) | Totalt antal ljud‑ och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑objekt och skriver ut ett kompakt register. Det kombinerar även [HeadingPairs](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/headingpairs/) med [TitlesOfParts](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/titlesofparts/) för att visa innehållsgrupper som teckensnitt, teman och bildrubriker.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Varje [IHeadingPair](https://reference.aspose.com/slides/sv/net/aspose.slides/iheadingpair/) levererar ett gruppnamn och antalet objekt i den gruppen. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/titlesofparts/) är en platt, ordnad array, så konsumera antalet på varandra följande titlar som anges av varje rubrikpar.

### **Lagrad metadata och formatbegränsningar**

De registeregenskaper som returneras av [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar presentationsobjektmodellen för att omräkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller utökade dokumentegenskaper för bild, not, dold‑bild, stycke, ord och multimediantal, samt rubrikpar och deltitlar. Tillgänglighet beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte har uppdaterats av dokumentproducenten returnerar Aspose.Slides dess lagrade eller standardvärde i stället för att beräkna det från bilderna.
- **ODP:** OpenDocument‑metadata ger allmänna dokumentstatistik såsom sida, stycke och ordantal, men dessa värden motsvarar inte alla PowerPoint‑specifika utökade egenskaper. Metadata för dolda bilder, not‑bilder, multimedia, rubrik‑par och del‑titlar kan vara otillgängliga, och registeregenskaperna kan returnera standardvärden. Behandla inte ett nollvärde eller en tom array som bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för register och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste återspegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

De egenskaper som returneras av [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans. Verkställ ändringarna med [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), och skriv sedan den bundna presentationen med [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Följande bild visar de ursprungliga dokumentegenskaperna för PowerPoint‑presentationen.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Följande exempel ändrar titeln och sista‑sparade tiden och skriver resultatet till en ny fil:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Följande bild visar de ändrade dokumentegenskaperna för PowerPoint‑presentationen.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/net/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/net/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Ladda presentationen och använd [Presentation.FontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/fontsmanager/). Anropa [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getembeddedfonts/) för att erhålla de inbäddade teckensnitten och [FontsManager.GetFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getfonts/) för att få de teckensnitt som används av presentationen. Jämför de två resultaten för att hitta teckensnitt som krävs för rendering men som inte är inbäddade.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/hiddenslides/) via [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) och [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Detta är lämpligt för ett lättviktigt register. Om presentationen har modifierats i minnet kan den lagrade metadata saknas eller vara föråldrad, eller så behöver du verifiera levande värden genom att iterera över [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) och inspektera varje bilds [Slide.Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/hidden/)‑egenskap istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Ladda presentationen och läs [Presentation.SlideSize](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slidesize/). Inspektera [ISlideSize.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/size/) och [ISlideSize.Orientation](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/orientation/) för att jämföra de aktuella inställningarna med de förväntade förinställningarna och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Lokalisera varje [Chart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/) och inspektera [ChartData.DataSourceType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/datasourcetype/). För en extern arbetsbok, läs [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/). Datakälltyp och sökväg identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resurspåslag.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF‑export?**

Det finns ingen enskild komplexitets‑egenskap. Traversera [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) och varje bilds [IBaseSlide.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/shapes/)‑samling. Använd antalet former samt förekomsten av stora bilder, effekter, animationer eller multimedia som screeningssignaler, och mät en representativ rendering eller export innan du behandlar en bild som en bekräftad prestandaflaskhals.