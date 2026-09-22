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
- vooraf gedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- opslaan voortgang
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams in Java met Aspose.Slides, en de PPTX-output en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of een [bestaande opent](/slides/nl/java/open-presentation/), gebruikt u de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) methode om het resultaat weg te schrijven. Aspose.Slides voor Java kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslagoperaties en de opties die beschikbaar zijn voor PPTX-uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) methode. De formaatwaarde bepaalt welk type bestand Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Voeg hier inhoud toe aan of wijzig de presentatie.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand‑ en streamdetectie, het gedrag van nieuw aangemaakte presentaties, en het onderscheid tussen bron‑ en uitvoerformaten, zie [Determine the Original Presentation Format](/slides/nl/java/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand leest u het oorspronkelijke formaat uit de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSourceFormat--) methode. Geef de verkregen [SourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sourceformat/) waarde door aan [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#toSaveFormat-int-) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) waarde te krijgen, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) om de gewijzigde presentatie weg te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij en slaat het op naar een uitvoermap in het formaat waarin het werd geladen:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/#toSaveFormat-int-) koppelt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint XML aan hun overeenkomstige presentatie‑opslaanformaten. Het map alleen presentatie‑bronformaten; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sourceformat/) waarde resulteert in een [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy PPT, PPS en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie wordt geladen vanuit een stream zonder extensie, kan een PPS‑ of POT‑bestand daarom worden geïdentificeerd als PPT. Als het behouden van deze oude subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of formaat‑metadata apart en gebruik deze bij het kiezen van de uitvoernaam en het formaat.

## **Presentaties opslaan naar streams**

Om een presentatie weg te schrijven zonder een definitief pad, geeft u een schrijfbare stream en een [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) methode. Deze aanpak is bruikbaar wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database, of in het geheugen moet worden verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestands‑stream:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave bepalen waarin PowerPoint een opgeslagen presentatie eerst opent. Gebruik de [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#setLastView-int-) methode met een [ViewType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld stelt de Slide Master‑weergave in als de initiële weergave:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/) instantie aan en gebruikt u de [setConformance](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setConformance-int-) methode met [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Geef vervolgens de opties door aan de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie deze limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en item‑limieten.

Gebruik de [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) methode om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- [IfNecessary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never) schakelt ZIP64‑extensies uit.
- [Always](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Always) schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip65.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Als [Zip64Mode.Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never) wordt gebruikt en de presentatie niet binnen de standaard ZIP‑limieten past, gooit de opslaan‑operatie een [PptxException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑uitvoer kunt u de opslangsnelheid afwegen tegen de bestandsgrootte door de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) methode te gebruiken. De [CompressionLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/) klasse biedt de volgende waarden:

- [None](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#None) slaat gegevens op zonder compressie.
- [Level1](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level1) biedt de snelste compressie en de grootste gecomprimeerde output.
- [Level2](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level2) tot en met [Level5](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level5) geven steeds de voorkeur aan een kleinere output boven opslagsnelheid.
- [Level6](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level6) balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- [Level7](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level7) en [Level8](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level8) geven nog meer de voorkeur aan een kleinere output boven snelheid.
- [Level9](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compressionlevel/#Level9) biedt de sterkste compressie en vereist de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Het volgende voorbeeld gebruikt het maximale compressieniveau:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, regelt de [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) methode de document‑miniatuur:

- `true` genereert de miniatuur opnieuw tijdens de opslaan‑operatie. Dit is de standaardwaarde.
- `false` behoudt de bestaande miniatuur. Als de presentatie geen miniatuur heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder de miniatuur te vernieuwen:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Het uitschakelen van miniatuurgeneratie kan de tijd die nodig is om een PPTX‑bestand op te slaan, verminderen.
{{% /alert %}}

## **Opslaan met voortgangsupdates in procenten**

Om een opslaan‑operatie te monitoren, implementeert u de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface en geeft u de implementatie door aan de [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) methode. Aspose.Slides roept dan de [IProgressCallback.reporting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/#reporting-double-) methode aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld meldt de voortgang van een PDF‑export naar de console:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑operatie schrijft een volledig nieuw uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie [is not thread-safe](/slides/nl/java/multithreading/). Toegang en opslaan van elke instantie mag slechts door één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/java/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gelinkte bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik document‑metadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/java/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.