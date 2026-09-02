---
title: Presentaties opslaan in Java
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/java/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang opslaan
- Java
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan in Java met Aspose.Slides--exporteer naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open presentaties in Java](/slides/nl/java/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties kunt maken en opslaan. De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze uiteindelijk opslaan. Met Aspose.Slides for Java kun je opslaan naar een **bestand** of **stroom**. Dit artikel bespreekt de verschillende manieren om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Doe hier wat werk...

    // Sla de presentatie op naar een bestand.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse. Een presentatie kan naar vele type streams worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Maak een instantie van de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Sla de presentatie op naar de stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan met een vooraf gedefinieerde weergavetype**

Aspose.Slides laat je de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/)‑klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#setLastView-int-)‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewtype/)‑enumeratie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/)‑klasse en stel de `conformance`‑eigenschap in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) opgeeft, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder maakt een presentatie aan en slaat deze op in het Strict Office Open XML‑formaat.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Maak een instantie van de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Sla de presentatie op in het Strict Office Open XML‑formaat.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de uitgepakte grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑methode laat je kiezen wanneer je ZIP64‑formatextensies gebruikt bij het opslaan van een Office Open XML‑bestand.

Deze methode kan worden gebruikt met de volgende modi:

- [IfNecessary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑extensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑extensies.
- [Always](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑extensies.

De volgende code laat zien hoe je een presentatie opslaat als een PPTX‑bestand met ZIP64‑extensies ingeschakeld:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never), wordt een [PptxException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxexception/) gegooid als de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Bij grote presentaties kun je het compressieniveau aanpassen om een balans te vinden tussen bestandsgrootte en verwerkingstijd. Afhankelijk van je wensen kun je kiezen voor snellere verwerking of kleinere uitvoerbestanden.

Aspose.Slides biedt de [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-)‑methode, waarmee je het compressieniveau kunt specificeren dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- [**None**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#None): Er wordt geen compressie toegepast. Bestanden worden ongewijzigd opgeslagen.
- [**Level1**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level1): De snelste compressie met de laagste compressieverhouding.
- [**Level2**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level2): Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- [**Level3**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level3): Biedt betere compressie dan **Level2** met een matige impact op de verwerkingstijd.
- [**Level4**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level4): Biedt betere compressie dan **Level3**.
- [**Level5**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level5): Verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- [**Level6**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level6): Standaardcompressie die een goede balans biedt tussen snelheid en bestandsgrootte. Dit is het *standaard compressieniveau*.
- [**Level7**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level7): Biedt betere compressie dan **Level6** met tragere verwerking.
- [**Level8**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level8): Biedt betere compressie dan **Level7**.
- [**Level9**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level9): Maximale compressie. Produceert de kleinste bestandsgrootte tegen de hoogste verwerkingstijd.

Het volgende voorbeeld toont hoe je een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Dit voorbeeld laat zien hoe je een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan zonder de miniatuur bij te werken**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑methode regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als `true`, wordt de miniatuur tijdens het opslaan ververst. Dit is de standaardwaarde.
- Als `false`, wordt de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te verversen.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.
{{% /alert %}}

## **Voortgangsupdates opslaan in percentages**

De [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/)‑interface wordt gebruikt via de `setProgressCallback`‑methode die beschikbaar is op de [ISaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isaveoptions/)‑interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/)‑klasse. Koppel een [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/)‑implementatie met `setProgressCallback` om voortgangsupdates tijdens het opslaan als percentage te ontvangen.

De volgende code‑fragment toont hoe je `IProgressCallback` gebruikt.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Gebruik hier de voortgangspercentage‑waarde.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint‑splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van zijn eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incrmenteel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt telkens het volledige doelbestand aan; incrmenteel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie [is niet thread‑safe](/slides/nl/java/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/java/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de verwijzende paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/java/presentation-properties/) worden ondersteund en bij het opslaan in het bestand weggeschreven.