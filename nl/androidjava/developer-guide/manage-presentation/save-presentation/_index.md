---
title: Presentaties opslaan op Android
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/androidjava/save-presentation/
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
- opslaan vooruitgang
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u presentaties in Java kunt opslaan met Aspose.Slides voor Android—exporteren naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentaties op Android](/slides/nl/androidjava/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie van nul maakt of een bestaande wijzigt, je wilt deze opslaan zodra je klaar bent. Met Aspose.Slides voor Android kun je opslaan naar een **bestand** of **stream**. Dit artikel bespreekt de verschillende manieren om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Voer hier wat bewerkingen uit...

    // Sla de presentatie op naar een bestand.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse. Een presentatie kan naar vele stream‑typen worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides stelt je in staat het initiële weergavetype in te stellen dat PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/)‑klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewtype/)‑enumeratie.

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

Aspose.Slides maakt het mogelijk een presentatie op te slaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/)‑klasse en stel de eigenschap `conformance` in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Sla de presentatie op in het Strict Office Open XML-formaat.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de uitgepakte grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en bovendien een limiet van 65 535 (2^16‑1) bestanden hanteert. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑methode laat je kiezen wanneer ZIP64‑formatextensies te gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan worden gebruikt met de volgende modi:

- [IfNecessary](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑formatextensies.
- [Always](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑formatextensies.

De volgende code toont hoe je een presentatie opslaat als een PPTX‑bestand met ingeschakelde ZIP64‑formatextensies:

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

{{% alert title="OPMERKING" color="warning" %}}
Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never), wordt een [PptxException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxexception/) gegooid als de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Bij grote presentaties kun je het compressieniveau aanpassen om de bestandsgrootte en de verwerkingstijd in balans te brengen. Afhankelijk van je eisen kun je kiezen voor snellere verwerking of een kleiner uitvoerbestand.

Aspose.Slides biedt de [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-)‑methode, waarmee je het compressieniveau kunt opgeven dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- [**None**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#None): Geen compressie. Bestanden worden onveranderd opgeslagen.
- [**Level1**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level1): De snelste compressie met de laagste compressieverhouding.
- [**Level2**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level2): Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- [**Level3**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level3): Biedt betere compressie dan **Level2** met een matige impact op de verwerkingstijd.
- [**Level4**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level4): Biedt betere compressie dan **Level3**.
- [**Level5**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level5): Biedt verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- [**Level6**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level6): Standaardcompressie die een goede balans biedt tussen verwerkingssnelheid en bestandsgrootte. Dit is de *standaard compressieniveau*.
- [**Level7**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level7): Biedt betere compressie dan **Level6** met tragere verwerking.
- [**Level8**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level8): Biedt betere compressie dan **Level7**.
- [**Level9**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level9): Maximale compressie. Produceert de kleinste bestandsgrootte ten koste van de langste verwerkingstijd.

Het volgende voorbeeld laat zien hoe je een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

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

Dit voorbeeld toont hoe je een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

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

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑methode regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als deze op `true` staat, wordt de miniatuur vernieuwd tijdens het opslaan. Dit is de standaardwaarde.
- Als deze op `false` staat, wordt de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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
Deze optie helpt de tijd die nodig is om een presentatie op te slaan in PPTX‑formaat te verkorten.
{{% /alert %}}

## **Opslaan van voortgangsupdates in percentage**

De [IProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/)‑interface wordt gebruikt via de `setProgressCallback`‑methode die wordt blootgelegd door de [ISaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isaveoptions/)‑interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/)‑klasse. Ken een [IProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/)‑implementatie toe met `setProgressCallback` om voortgangsupdates bij het opslaan te ontvangen als percentage.

De volgende codefragmenten laten zien hoe je `IProgressCallback` gebruikt.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Gebruik hier de voortgangspercentage-waarde.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app laat je een presentatie opsplitsen in meerdere bestanden door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incremental save) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand; incrementeel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie [is niet thread‑safe](/slides/nl/androidjava/multithreading/); sla die op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de refererende paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/androidjava/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.