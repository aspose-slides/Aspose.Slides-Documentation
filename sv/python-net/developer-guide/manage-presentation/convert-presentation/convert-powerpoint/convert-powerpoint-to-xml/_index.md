---
title: Konvertera PowerPoint-presentationer till XML i Python
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/python-net/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML-presentation
- SaveFormat.XML
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- Python
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i Python med Aspose.Slides."
---
## **Översikt**

Aspose.Slides för Python via .NET kan konvertera PowerPoint-presentationer till PowerPoint XML Presentation-formatet. XML-utdata är användbart när du behöver en textbaserad representation för att granska presentationsstruktur, felsöka genererade dokument, jämföra resultat i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) med värdet `XML` från enumerationen [SaveFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Note" %}}

`SaveFormat.XML` skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML-delarna som lagras i ett PPTX-paket. Om du behöver de exakta PPTX-paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera PPTX‑paketet självt.

{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/), och skicka sedan utvägs‑sökvägen och `SaveFormat.XML` till [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/). Källan kan vara vilket presentationsformat som helst som stöds för läsning, såsom PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX-presentation till en XML‑fil:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Skriv XML‑utdata till en ström**

Använd ström‑överladdningen av [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) när XML måste förbli i minnet eller skickas till en annan komponent, såsom en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)-ström och spolar tillbaka den för efterföljande läsning:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Skicka xml_stream till nästa komponent i arbetsflödet.
```

## **Jämför XML med presentations‑ och exportformat**

Välj utdataformatet enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Granska struktur, felsökning, jämföra genererat resultat, och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Sidor med fast layout eller en fler‑sidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsgranskningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och data‑orienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/python-net/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart sparformat, så använd den inte när ett arbetsflöde måste läsa in den exporterade filen tillbaka i Aspose.Slides för fortsatt redigering.

## **Vanliga frågor**

**Är `SaveFormat.XML` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.XML` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disken?**

Ja. Skicka en skrivbar ström till [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/). Till exempel, använd en [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO)-ström för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande endast för sparande, inte för inläsning. Använd PPTX eller ett annat stödd presentationsformat när rundresa‑redigering krävs.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sid‑orienterad utdata, eller PNG, JPEG och SVG för enskilda bild‑filer.