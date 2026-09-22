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
- voortgang opslaan
- Android
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams op Android met Aspose.Slides, en de PPTX-uitvoer en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of [een bestaande opent](/slides/nl/androidjava/open-presentation/), gebruikt u de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode om het resultaat te schrijven. Aspose.Slides voor Android via Java kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslaacties en de beschikbare opties voor PPTX‑uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode. De formatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Voeg hier presentatie-inhoud toe of wijzig deze.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand‑ en streamdetectie, het gedrag van nieuw aangemaakte presentaties, en het onderscheid tussen bron‑ en uitvoerformaten, zie [Determine the Original Presentation Format](/slides/nl/androidjava/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand leest u het oorspronkelijke formaat via de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) methode. Geef de resulterende [SourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sourceformat/) waarde door aan [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) om de overeenkomstige [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) om de aangepaste presentatie te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij, en slaat het op naar een uitvoermap in het formaat waarin het werd geladen:

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

De [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) kaart PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint‑XML om naar hun overeenkomstige presentatie‑opslaformaten. Het kaart alleen presentatie‑bronformaten; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sourceformat/) waarde resulteert in een [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Legacy PPT‑, PPS‑ en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie wordt geladen vanuit een stream zonder bestandsextensie, kan een PPS‑ of POT‑bestand daarom worden geïdentificeerd als PPT. Als het behouden van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of format‑metadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en –formaat.

## **Presentaties opslaan naar streams**

Om een presentatie te schrijven zonder te vertrouwen op een definitief bestandspad, geeft u een schrijfbare stream en een [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) methode. Deze methode is handig wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database, of in het geheugen moet worden verwerkt.

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

U kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie aanvankelijk opent. Gebruik de [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) methode met een [ViewType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld stelt Slide Master‑weergave in als de initiële weergave:

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

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/) instantie aan en gebruikt u de [setConformance](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) methode met [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Geef vervolgens de opties door aan de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode.

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

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie die limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en item‑aantallimieten.

Gebruik de [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) methode om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- [IfNecessary](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never) schakelt ZIP64‑extensies uit.
- [Always](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Always) schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoer‑presentatie:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Als [Zip64Mode.Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never) wordt gebruikt en de presentatie niet binnen de standaard ZIP‑limieten past, werpt de opslaan‑bewerking een [PptxException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑output kunt u de opslagsnelheid afwegen tegen de bestandsgrootte door de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) methode te gebruiken. De [CompressionLevel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/) klasse biedt de volgende waarden:

- [None](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#None) slaat gegevens op zonder compressie.
- [Level1](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level1) biedt de snelste compressie en de grootste gecomprimeerde uitvoer.
- [Level2](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level2) tot en met [Level5](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level5) geven geleidelijk de voorkeur aan een kleinere uitvoer boven de opslagsnelheid.
- [Level6](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level6) balanceert tussen opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- [Level7](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level7) en [Level8](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level8) geven nog meer de voorkeur aan een kleinere uitvoer boven de opslagsnelheid.
- [Level9](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compressionlevel/#Level9) biedt de sterkste compressie en vereist de meeste verwerkingstijd.

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

## **Presentaties opslaan zonder het miniatuur te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, bepaalt de [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) methode de miniatuur van het document:

- `true` genereert de miniatuur opnieuw tijdens de opslaan‑bewerking. Dit is de standaardwaarde.
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
Het uitschakelen van het vernieuwen van de miniatuur kan de tijd die nodig is om een PPTX‑bestand op te slaan verminderen.
{{% /alert %}}

## **Opslaan van voortgangsupdates in procenten**

Om een opslaan‑bewerking te monitoren, implementeert u de [IProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/) interface en geeft u de implementatie door aan de [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) methode. Aspose.Slides roept vervolgens de [IProgressCallback.reporting](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) methode aan met voortgangswaarden tijdens de export.

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
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) aan, gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑bewerking schrijft een volledig uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) instantie [is not thread-safe](/slides/nl/androidjava/multithreading/). Toegang tot en opslaan van elke instantie mag slechts vanuit één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides copieert geen extern gelinkte bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/androidjava/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.