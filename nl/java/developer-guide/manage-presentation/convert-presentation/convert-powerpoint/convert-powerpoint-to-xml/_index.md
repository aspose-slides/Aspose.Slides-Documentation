---
title: PowerPoint-presentaties naar XML converteren in Java
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint naar XML converteren
- presentatie naar XML converteren
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML-presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stream
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties converteren naar PowerPoint-XML-bestanden of -streams in Java met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java kan PowerPoint‑presentaties omzetten naar het PowerPoint‑XML‑Presentatie‑formaat. XML‑output is handig wanneer u een tekstgebaseerde weergave nodig hebt om de presentatiestructuur te inspecteren, gegenereerde documenten te foutopsporen, output in geautomatiseerde tests te vergelijken, of om te integreren met een workflow die XML consumeert in plaats van een presentatiepakket.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode met de `Xml`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/)‑klasse. U kunt het resultaat rechtstreeks naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` maakt een PowerPoint‑XML‑Presentatie aan. Het haalt niet de afzonderlijke Office‑Open‑XML‑onderdelen op die in een PPTX‑pakket zijn opgeslagen. Als u de exacte PPTX‑pakketonderdelen nodig heeft, zoals `ppt/presentation.xml` of afzonderlijke dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.
{{% /alert %}}

## **Een presentatie omzetten naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat.Xml` door aan [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). De bron kan elk presentatie‑formaat zijn dat wordt ondersteund voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld zet een PPTX‑presentatie om naar een XML‑bestand:

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

## **De XML‑output naar een stream schrijven**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) en haalt de resulterende XML op als een byte‑array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Geef xmlData door aan de volgende component in de workflow.
} finally {
    presentation.dispose();
}
```

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat gebruikt zal worden:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Inspectie van structuur, foutopsporing, vergelijken van gegenereerde output en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een ouder binair presentatie‑bestand | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Normaal PowerPoint‑bewerken en uitwisseling van presentaties |
| PDF of TIFF | Vaste‑layout pagina’s of een meer‑pagina afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een afzonderlijke dia | Miniaturen, voorbeeldweergaven en afbeeldings‑assets |
| HTML of HTML5 | Web‑gerichte presentatie‑output | Browserweergave en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output voornamelijk bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑afbeeldingsformaten vertegenwoordigt het presentatiedata in plaats van dia’s als pagina’s of visuele assets te renderen. De tabel met [ondersteunde bestandsformaten](/slides/nl/java/supported-file-formats/) geeft elk formaat weer dat Aspose.Slides kan laden, importeren, opslaan of renderen.

## **FAQ**

**Is `SaveFormat.Xml` the same as saving a PPTX file?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.Xml` een PowerPoint‑XML‑presentatie‑bestand aanmaakt.

**Can I save the XML output without creating a file on disk?**

Ja. Geef een schrijfbare stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Bijvoorbeeld, gebruik een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) voor verwerking in het geheugen.

**Can Aspose.Slides load the exported XML file again?**

Ja. Geef het XML‑bestand of een stream door aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑constructor. [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--) geeft vervolgens `SourceFormat.Xml` terug. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) meldt `LoadFormat.Unknown` voor dit formaat, dus gebruik dit niet om te bepalen of een XML‑bestand geopend kan worden.

**Does XML conversion render each slide as a page or image?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.