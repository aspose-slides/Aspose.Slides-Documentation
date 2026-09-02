---
title: Hämta och uppdatera presentationsinformation i Python
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/python-net/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Python för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Den här artikeln visar hur man granskar presentationsinformation i Aspose.Slides. Den förklarar hur man bestämmer en presentations nuvarande format utan att läsa in hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper vid behov.

Exemplen är baserade på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/) och demonstrerar vanliga operationer för att arbeta med presentationsmetadata.

## **Kontrollera ett presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att läsa in presentationen. Se den här Python-koden:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Hämta presentationsegenskaper**

Denna Python-kod visar hur du hämtar presentationsegenskaper (information om presentationen):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Du kanske vill se [properties under the DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/#properties) klassen.

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) som låter dig göra ändringar i presentationsegenskaper.

Låt oss säga att vi har en PowerPoint-presentation med dokumentegenskaperna som visas nedan.

![Originala dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Det här kodexemplet visar hur du redigerar några presentationsegenskaper:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Lösenordsskydda presentationer](/slides/sv/python-net/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/python-net/write-protected-presentation/)

## **FAQ**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Leta efter [embedded-font information](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) på presentationsnivå, jämför sedan dessa poster med mängden [fonts actually used across content](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_fonts/) för att identifiera vilka typsnitt som är kritiska för återgivning.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom [slide collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidecollection/) och inspektera varje bilds [visibility flag](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/hidden/).

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Jämför den aktuella [slide size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slide_size/) och orienteringen med standardinställningarna; detta hjälper dig förutse beteendet vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla [charts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/), kontrollera deras [data source](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/data_source_type/), och notera om datan är intern eller länkbaserad, inklusive eventuella brutna länkar.

**Hur kan jag bedöma 'tunga' bilder som kan sakta rendering eller PDF-export?**

För varje bild räknar du objekt och letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela ett grovt komplexitetsvärde för att identifiera potentiella prestandaflaskhalsar.