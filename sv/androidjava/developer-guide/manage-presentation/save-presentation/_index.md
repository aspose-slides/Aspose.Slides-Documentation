---
title: Spara presentationer på Android
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/androidjava/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- spara framsteg
- Android
- Java
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar på Android med Aspose.Slides, och konfigurera PPTX-utdata samt rapportering av framsteg."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppnat en befintlig](/slides/sv/androidjava/open-presentation/), använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva resultatet. Aspose.Slides för Android via Java kan spara en presentation till en fil eller ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt täcker de vanliga sparåtgärderna och de alternativ som finns för PPTX-utdata.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka utdata‑sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/)‑värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Formatvärdet bestämmer vilken typ av fil som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Lägg till eller ändra presentationsinnehåll här.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nyss skapade presentationer och skillnaden mellan käll‑ och målformat, se [Bestäm det ursprungliga presentationsformatet](/slides/sv/androidjava/detect-presentation-source-format/).

I ett batch‑behandlingsprogram kan indataformatet vara okänt i förväg. Efter att ha laddat en fil, läs dess ursprungliga format från metoden [IPresentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sourceformat/)‑värdet till [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) för att få motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/)‑värde, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) för att skriva den ändrade presentationen.

Följande kompletta exempel behandlar varje fil i en inmatningskatalog, uppdaterar dess titel och sparar den till en utdatamapp i det format den lästes in i:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint‑XML till deras motsvarande presentations‑sparformat. Den mappar endast presentations‑källformat; den är inte avsedd för att välja exportformat såsom PDF, HTML, TIFF eller bilder. Att skicka ett ej stödjt eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sourceformat/)‑värde resulterar i ett [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Äldre PPT-, PPS- och POT‑filer använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om det krävs att bevara dessa äldre undertyper, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utdatafilnamn och format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita sig på en slutgiltig filsökväg, skicka en skrivbar ström och ett [SaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/)‑värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller behandlas i minnet.

Följande exempel sparar en ny presentation till en filström:

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

## **Spara presentationer med en fördefinierad visningstyp**

Du kan ange den vy som PowerPoint först öppnar en sparad presentation i. Använd metoden [ViewProperties.setLastView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) med ett [ViewType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewtype/)‑värde innan du sparar.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

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

## **Spara presentationer i strikt Office Open XML-format**

För att skapa en PPTX‑fil som följer den Strikta profilen för Office Open XML, skapa en instans av [PptxOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/) och använd dess [setConformance](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-)‑metod med [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Skicka sedan alternativen till metoden [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

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

## **Spara presentationer i Office Open XML-format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar storleken på de komprimerade och okomprimerade posterna, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa gränser. ZIP64‑tillägg höjer de tillämpliga storleks‑ och postantal‑gränserna.

Använd metoden [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) för att styra om Aspose.Slides skriver ZIP64‑tillägg:

- [IfNecessary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#IfNecessary) använder ZIP64 endast när presentationen överskrider standard‑ZIP‑gränserna. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never) inaktiverar ZIP64‑tillägg.
- [Always](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Always) skriver alltid ZIP64‑tillägg.

Följande exempel aktiverar alltid ZIP64‑tillägg för den utgående presentationen:

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
Om [Zip64Mode.Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never) används och presentationen inte får plats inom standard‑ZIP‑gränserna, kastar sparoperationen ett [PptxException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

För PPTX‑utdata kan du balansera sparhastighet mot filstorlek genom att använda metoden [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Klassen [CompressionLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/) tillhandahåller följande värden:

- [None](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#None) lagrar data utan kompression.
- [Level1](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level1) ger den snabbaste kompressionen och den största komprimerade utdata.
- [Level2](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level2) till [Level5](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level5) favoriserar gradvis mindre utdata över sparhastighet.
- [Level6](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level6) balanserar sparhastighet och filstorlek. Detta är standardnivån.
- [Level7](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level7) och [Level8](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level8) favoriserar ytterligare mindre utdata över sparhastighet.
- [Level9](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level9) ger den starkaste kompressionen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

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

Följande exempel använder den maximala komprimeringsnivån:

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

## **Spara presentationer utan att uppdatera miniatyrbilden**

När en presentation sparas som PPTX styr metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) dess dokumentminiatyr:

- `true` regenererar miniatyrbilden under sparoperationen. Detta är standardvärdet.
- `false` bevarar den befintliga miniatyrbilden. Om presentationen saknar miniatyrbild genererar Aspose.Slides ingen.

Följande exempel sparar en presentation utan att uppdatera dess miniatyrbild:

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
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Spara framdriftsuppdateringar i procent**

För att övervaka en sparoperation, implementera gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/) och skicka implementationen till metoden [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides anropar sedan metoden [IProgressCallback.reporting](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) med framdriftsvärden under exporten.

Följande exempel rapporterar framdriften för en PDF‑export till konsolen:

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
Aspose tillhandahåller en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:t. Den sparar utvalda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides inkrementell eller ”snabb sparning”?**

Nej. Varje sparoperation skriver en komplett utdatafil istället för att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/androidjava/multithreading/). Åtkomst och sparning av varje instans får endast ske från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlinks](/slides/sv/androidjava/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapelsedatum?**

Ja. Ställ in lämpliga [document properties](/slides/sv/androidjava/presentation-properties/) innan du sparar, så skriver Aspose.Slides dem till utdatafilen.