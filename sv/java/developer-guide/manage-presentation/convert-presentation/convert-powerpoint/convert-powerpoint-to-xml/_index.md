---
title: Konvertera PowerPoint-presentationer till XML i Java
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/java/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML-presentation
- SaveFormat.Xml
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i Java med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java kan konvertera PowerPoint‑presentationer till PowerPoint XML Presentation‑formatet. XML‑utdata är användbara när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra resultat i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑metoden med `Xml`‑värdet från [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/)-klassen. Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Obs" %}}
`SaveFormat.Xml` skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakta PPTX‑paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera själva PPTX‑paketet.
{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-klassen och skicka sedan utvägssökvägen och `SaveFormat.Xml` till [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, t.ex. PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX‑presentation till en XML‑fil:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Skriv XML‑utdata till en ström**

Använd ström‑överladdningen av [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) när XML‑utdata ska hållas i minnet eller skickas till en annan komponent, t.ex. en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) och erhåller den resulterande XML‑en som en byte‑array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Skicka xmlData till nästa komponent i arbetsflödet.
} finally {
    presentation.dispose();
}
```

## **Jämför XML med presentations‑ och exportformat**

Välj utdataformat enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Inspektion av struktur, felsökning, jämförelse av genererat resultat och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Fasta layout‑sidor eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsvisningar och bildresurser |
| HTML eller HTML5 | Webborienterat presentationsutdata | Webbläsarvisning och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedda för inspektion och data‑orienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar de presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/java/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart‑sparformat, så använd det inte när ett arbetsflöde måste läsa in den exporterade filen igen i Aspose.Slides för fortsatt redigering.

## **Vanliga frågor**

**Är `SaveFormat.Xml` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.Xml` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disk?**

Ja. Skicka en skrivbar ström till [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Till exempel kan du använda en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande bara för sparande, inte för inläsning. Använd PPTX eller ett annat stödformat när rundresa‑redigering krävs.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerade presentationsdata. Använd PDF eller TIFF för sid‑orienterad utdata, eller PNG, JPEG och SVG för enskilda bild‑bilder.