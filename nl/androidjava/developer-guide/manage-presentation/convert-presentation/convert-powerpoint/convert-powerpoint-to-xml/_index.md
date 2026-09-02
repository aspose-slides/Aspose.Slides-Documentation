---
title: PowerPoint-presentaties omzetten naar XML op Android
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/androidjava/convert-powerpoint-to-xml/
keywords:
- PowerPoint converteren naar XML
- presentatie converteren naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML-presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stroom
- Android
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties omzetten naar PowerPoint-XML-bestanden of -streams op Android met Aspose.Slides."
---
## **Overzicht**

Aspose.Slides for Android via Java kan PowerPoint‑presentaties converteren naar het PowerPoint XML Presentation‑formaat. XML‑output is bruikbaar wanneer je een tekstgebaseerde weergave nodig hebt om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of om te integreren met een workflow die XML consumeert in plaats van een presentatiedatabase.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode met [SaveFormat.Xml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/#Xml). Je kunt het resultaat rechtstreeks naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` maakt een PowerPoint XML Presentation aan. Het extraheert niet de individuele Office Open XML‑onderdelen die in een PPTX‑pakket zijn opgeslagen. Als je de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of individuele dia‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.
{{% /alert %}}

## **Converteer een presentatie naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse en geef vervolgens het uitvoerpad en [SaveFormat.Xml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/#Xml) door aan [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). De bron kan elk presentatiesformaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

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

## **Schrijf de XML‑uitvoer naar een stream**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een andere component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) en verkrijgt de gegenereerde XML als een byte‑array:

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

        // Geef xmlData door aan de volgende component in de workflow.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Vergelijk XML met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Formaat | Uitvoer | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML Presentation | Structuur inspecteren, troubleshooting, gegenereerde output vergelijken en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedocument | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Reguliere PowerPoint‑bewerking en presentatiewisseling |
| PDF or TIFF | Vaste‑layout pagina's of een meer‑pagina afbeelding | Weergeven, afdrukken en archiveren |
| PNG, JPEG, or SVG | Een gerenderde weergave van een individuele dia | Miniaturen, voorbeeldweergaven en afbeelding‑assets |
| HTML or HTML5 | Web‑georiënteerde presentatie‑output | Weergave in browser en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output voornamelijk bedoeld voor inspectie en data‑georiënteerde workflows. In tegenstelling tot PDF, TIFF, HTML en dia‑beeldformaten vertegenwoordigt het presentatiedata in plaats van dia's als pagina's of visuele assets te renderen. De tabel met [ondersteunde bestandsformaten](/slides/nl/androidjava/supported-file-formats/) vermeldt PowerPoint XML Presentation als een alleen‑opslaan‑formaat, dus gebruik het niet wanneer een workflow het geëxporteerde bestand opnieuw moet laden in Aspose.Slides voor verdere bewerking.

## **Veelgestelde vragen**

**Is `SaveFormat.Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.Xml` een PowerPoint XML Presentation‑bestand maakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf aan te maken?**

Ja. Geef een schrijfbare stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Bijvoorbeeld, gebruik een [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML Presentation wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiefomaat wanneer round‑trip bewerking vereist is.

**Renderen XML‑conversies elke dia als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor individuele dia‑afbeeldingen.