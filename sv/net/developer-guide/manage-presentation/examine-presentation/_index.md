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

Denna artikel visar hur man inspekterar presentationsinformation i Aspose.Slides. Den förklarar hur man avgör en presentations aktuella format utan att läsa in hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper vid behov.

Exemplen är baserade på PresentationInfo- och DocumentProperties-API:erna och demonstrerar typiska operationer för att arbeta med presentationsmetadata.

## **Kontrollera ett presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att läsa in presentationen. Se denna C#‑kod:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Hämta presentationsegenskaper**

Denna C#‑kod visar hur du hämtar presentationsegenskaper (information om presentationen):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Du kanske vill se egenskaperna under DocumentProperties‑klassen.

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden PresentationInfo.UpdateDocumentProperties som gör att du kan göra ändringar i presentationsegenskaper.

Låt oss säga att vi har en PowerPoint-presentation med dokumentegenskaperna som visas nedan.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar vissa presentationsegenskaper:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Kontrollera om en presentation är krypterad](https://docs.aspose.com/slides/sv/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrollera om en presentation är skrivskyddad (read-only)](https://docs.aspose.com/slides/sv/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrollera om en presentation är lösenordsskyddad innan den läses in](https://docs.aspose.com/slides/sv/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bekräfta lösenordet som används för att skydda en presentation](https://docs.aspose.com/slides/sv/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Leta efter information om inbäddade typsnitt på presentationsnivå, jämför sedan dessa poster med mängden typsnitt som faktiskt används i innehållet för att identifiera vilka typsnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom slide‑samlingen och inspektera varje slides synlighetsflagga.

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de skiljer sig från standardvärdena?**

Ja. Jämför den aktuella bildstorleken och orienteringen med standardinställningarna; detta hjälper dig att förutse beteendet vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla diagram, kontrollera deras datakälla och notera om data är intern eller länkbaserad, inklusive eventuella brutna länkar.

**Hur kan jag bedöma 'tunga' bilder som kan sakta renderingen eller PDF‑export?**

För varje bild räknar du antalet objekt och letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela ett grovt komplexitetsvärde för att markera potentiella prestandaflaskhalsar.