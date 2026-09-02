---
title: PowerPoint‑presentaties converteren naar XML in Java
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/java/convert-powerpoint-to-xml/
keywords:
- PowerPoint converteren naar XML
- presentatie converteren naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML‑presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML‑stream
- Java
- Aspose.Slides
description: "PowerPoint‑ en OpenDocument‑presentaties converteren naar PowerPoint XML‑bestanden of -streams in Java met Aspose.Slides for Java."
---
## **Overzicht**

Aspose.Slides for Java kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatie‑formaat. XML‑output is handig wanneer u een op tekst gebaseerd representatie nodig hebt om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML gebruikt in plaats van een presentatiedpakket.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) methode met de `Xml`‑waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) klasse. U kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Opmerking" %}}

`SaveFormat.Xml` creates a PowerPoint XML Presentation. It does not extract the individual Office Open XML parts stored inside a PPTX package. If you need the exact PPTX package parts, such as `ppt/presentation.xml` or individual slide XML files, inspect the PPTX package itself.

{{% /alert %}}

## **Presentatie converteren naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse en geef vervolgens het uitvoerpad en `SaveFormat.Xml` door aan [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). De bron kan elk presentatiefomat zijn dat voor het laden wordt ondersteund, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

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

## **XML‑output schrijven naar een stream**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een andere component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) en verkrijgt de resulterende XML als een byte‑array:

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

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Uitvoer | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Structuur inspecteren, troubleshooten, gegenereerde output vergelijken en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een verouderd binair presentiebestand | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Reguliere PowerPoint‑bewerking en uitwisseling van presentaties |
| PDF of TIFF | Vaste paginalay-out of een multi‑page afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een individuele dia | Miniaturen, voorbeeldweergaven en beeldbestanden |
| HTML of HTML5 | Webgerichte presentatie‑output | Bekijken in browsers en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑beeldformaten vertegenwoordigt het presentatiedata in plaats van dia's te renderen als pagina’s of visuele assets. De tabel met [ondersteunde bestandsformaten](/slides/nl/java/supported-file-formats/) vermeldt PowerPoint XML‑presentatie als een alleen‑opslaan‑formaat, dus gebruik het niet wanneer een workflow het geëxporteerde bestand opnieuw moet laden in Aspose.Slides voor verdere bewerking.

## **FAQ**

**Is `SaveFormat.Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.Xml` een PowerPoint XML‑presentatie‑bestand maakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf te maken?**

Ja. Geef een schrijfbare stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Bijvoorbeeld, gebruik een [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML‑presentatie wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiefomat wanneer round‑trip‑bewerking vereist is.

**Rendert XML‑conversie elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.