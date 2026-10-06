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
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller -strömmar i Java med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java kan konvertera PowerPoint-presentationer till PowerPoint XML‑presentationsformatet. XML‑utdata är användbart när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra resultat i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) med `Xml`‑värdet från klassen [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` skapar en PowerPoint XML‑presentation. Den extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakt PPTX‑paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera själva PPTX‑paketet.
{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), och skicka sedan utdata‑sökvägen och `SaveFormat.Xml` till [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, såsom PPT, PPTX eller ODP.

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

Använd ström‑överladdningen av [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) när XML‑filen måste finnas kvar i minnet eller skickas till en annan komponent, såsom en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) och hämtar den resulterande XML‑en som en byte‑array:

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

## **Jämför XML med presentations- och exportformat**

Välj utdataformat enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML‑presentation | Inspektion av struktur, felsökning, jämförelse av genererat resultat och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Fasta sidlayouter eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsvisningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Webbläsarvisning och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och dataorienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [stödda filformat](/slides/sv/java/supported-file-formats/) listar alla format som Aspose.Slides kan läsa in, importera, spara eller rendera.

## **Vanliga frågor**

**Är `SaveFormat.Xml` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.Xml` skapar en PowerPoint XML‑presentationsfil.

**Kan jag spara XML‑utdata utan att skapa en fil på disken?**

Ja. Skicka en skrivbar ström till [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Till exempel, använd en [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) för in‑minnes‑bearbetning.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Ja. Skicka XML‑filen eller en ström till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--) returnerar sedan `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) rapporterar `LoadFormat.Unknown` för detta format, så använd inte den för att avgöra om en XML‑fil kan öppnas.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sidorienterad utdata, eller PNG, JPEG och SVG för enskilda bild‑filer.