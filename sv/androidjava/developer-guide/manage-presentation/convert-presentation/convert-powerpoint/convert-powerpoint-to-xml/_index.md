---
title: Konvertera PowerPoint-presentationer till XML på Android
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/androidjava/convert-powerpoint-to-xml/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar på Android med Aspose.Slides."
---
## **Översikt**

Aspose.Slides för Android via Java kan konvertera PowerPoint-presentationer till PowerPoint XML Presentation‑formatet. XML‑utdata är användbar när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra utdata i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML i stället för ett presentationspaket.

Använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) med [SaveFormat.Xml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/#Xml). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` skapar en PowerPoint XML Presentation. Det extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakta PPTX‑paketdelarna, såsom `ppt/presentation.xml` eller enskilda slide‑XML‑filer, inspektera själva PPTX‑paketet.

{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och ange sedan sökvägen för utdata samt [SaveFormat.Xml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/#Xml) till [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, t.ex. PPT, PPTX eller ODP.

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

Använd strömladdningen av [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) när XML‑filen måste finnas i minnet eller skickas till en annan komponent, t.ex. en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) och erhåller den genererade XML‑en som en byte‑array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Skicka xmlData till nästa komponent i arbetsflödet.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Jämför XML med presentation‑ och exportformat**

Välj utdataformat efter hur resultatet ska användas:

| Format | Resultat | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Inspektion av struktur, felsökning, jämförelse av genererad utdata och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket med flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Sidor med fast layout eller en fler‑sidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild slide | Miniatyrer, förhandsgranskningar och bildresurser |
| HTML eller HTML5 | Webbanpassad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och data‑orienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för slides representerar den presentationsdata snarare än att rendera slides som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/androidjava/supported-file-formats/) listar PowerPoint XML Presentation som ett endast‑spara‑format, så använd den inte när ett arbetsflöde måste läsa in den exporterade filen igen i Aspose.Slides för fortsatt redigering.

## **Vanliga frågor**

**Är `SaveFormat.Xml` detsamma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.Xml` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disken?**

Ja. Skicka en skrivbar ström till [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Till exempel, använd en [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande bara för sparande, inte för inläsning. Använd PPTX eller ett annat stödformat när round‑trip‑redigering krävs.

**Renderar XML‑konvertering varje slide som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sid‑orienterad utdata, eller PNG, JPEG och SVG för individuella slide‑bilder.