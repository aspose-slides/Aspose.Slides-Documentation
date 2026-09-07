---
title: Konvertera PowerPoint-presentationer till XML i Python via Java
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/python-java/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i Python via Java med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides for Python via Java kan konvertera PowerPoint-presentationer till PowerPoint XML Presentation-formatet. XML‑utdata är användbart när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra utdata i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med värdet [Xml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Xml) från klassen [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Xml) skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML-delarna som lagras i ett PPTX-paket. Om du behöver de exakta PPTX-paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera själva PPTX-paketet.
{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), och skicka sedan utsökvägen och [SaveFormat.Xml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Xml) till [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, till exempel PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX-presentation till en XML‑fil:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Skriv XML‑utdata till en ström**

Använd ström‑översättningen av [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) när XML måste ligga kvar i minnet eller vidarebefordras till en annan komponent, som en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) och erhåller den resulterande XML‑en som ett Python‑bytes‑objekt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Skicka xml_data till nästa komponent i arbetsflödet.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Jämför XML med presentations‑ och exportformat**

Välj utskriftsformatet enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Inspektion av struktur, felsökning, jämförelse av genererad utdata och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Fasta layout‑sidor eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsvisningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och data‑orienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/python-java/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart sparformat, så använd den inte när ett arbetsflöde måste läsa in den exporterade filen tillbaka i Aspose.Slides för fortsatt redigering.

## **FAQ**

**Är XML‑export samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan [SaveFormat.Xml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Xml) skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disk?**

Ja. Skicka en skrivbar Java‑utström till [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save). Till exempel, använd en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) för in‑minnes‑bearbetning.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande bara för sparning, inte för inläsning. Använd PPTX eller ett annat stödd presentationsformat när rundresande redigering krävs.

**Renderar XML‑konverteringen varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerade presentationsdata. Använd PDF eller TIFF för sidorienterad utdata, eller PNG, JPEG och SVG för enskilda bildfiler.