---
title: Hämta och uppdatera presentationsinformation i .NET
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/net/examine-presentation/
keywords:
- presentationsformat
- presentationsattribut
- dokumentegenskaper
- hämta attribut
- läsa attribut
- ändra attribut
- modifiera attribut
- uppdatera attribut
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med .NET för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Denna artikel visar hur du granskar presentationsinformation i Aspose.Slides. Den förklarar hur du bestämmer en presentations aktuella format utan att ladda hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper när det behövs.

Exemplen är baserade på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/) och demonstrerar typiska operationer för arbete med presentationsmetadata.

## **Kontrollera ett presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att ladda presentationen. Se den här C#‑koden:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Hämta presentationsattribut**

Denna C#‑kod visar hur du hämtar presentationsattribut (information om presentationen):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Du kanske vill se [egenskaperna under DocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/documentproperties/#properties)-klassen.

## **Uppdatera presentationsattribut**

Aspose.Slides tillhandahåller metoden [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) som låter dig göra ändringar i presentationsattribut.

Låt oss säga att vi har en PowerPoint‑presentation med dokumentegenskaperna som visas nedan.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar några presentationsattribut:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Resultaten av ändringen av dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna följande länkar användbara:

- [Password-Protect Presentations](/slides/sv/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/sv/net/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Leta efter information om inbäddade typsnitt på presentationsnivå, jämför sedan dessa poster med mängden typsnitt som faktiskt används i innehållet för att identifiera vilka typsnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom bildsamlingen och inspektera varje bilds synlighetsflagga.

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de avviker från standardinställningarna?**

Ja. Jämför den aktuella bildstorleken och orienteringen med standardinställningarna; detta hjälper till att förutse beteende vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla diagram, kontrollera deras datakälla och notera om data är intern eller länkbaserad, inklusive eventuella trasiga länkar.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF‑export?**

För varje bild räknar du objekt, letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela en grov komplexitetspoäng för att flagga potentiella prestandaproblem.