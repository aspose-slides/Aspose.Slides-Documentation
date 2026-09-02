---
title: PowerPoint-presentaties naar Markdown converteren op Android
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- slide naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- slide opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown-afbeeldingsexport
- CDN-afbeeldingskoppelingen
- PowerPoint
- presentatie
- Markdown
- Android
- Java
- Aspose.Slides
description: "PPT- en PPTX-presentaties naar Markdown converteren op Android via Java en bepalen waar geëxporteerde bitmap-, metafile- en SVG-afbeeldingen worden opgeslagen en naar verwezen."
---
## **Overzicht**

Aspose.Slides for Android via Java kan PPT‑ en PPTX‑presentaties converteren naar Markdown voor documentatie, statische sites, inhoudsmigratie en versie‑controlescenario’s. U kunt een Markdown‑variant kiezen, bepalen hoe de slide‑inhoud wordt gerenderd, en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stelt u het exporttype in met de [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/)‑methode op de `Sequential` of `Visual` waarde van de [MarkdownExportType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownexporttype/)‑enumeratie. `Sequential` rendert slide‑items afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde items bij elkaar houdt om hun visuele relatie te behouden. De `TextOnly`‑waarde genereert geen afbeeldingsbronnen, zodat de callbacks voor het opslaan van afbeeldingen in die modus niet worden aangeroepen.

## **Een presentatie naar Markdown converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en roep vervolgens de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑methode aan met de `Md`‑waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/)‑enumeratie.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Selecteer een Markdown‑variant**

De [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/)‑methode bepaalt welke Markdown‑specificatie voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/flavor/)‑enumeratie bevat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Afbeeldingen exporteren met het standaard lokaal‑opslaaggedrag**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/)‑klasse biedt twee methoden om lokaal opgeslagen afbeeldingen te configureren:

- [setBasePath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) specificeert de basismap voor het Markdown‑document en de bijbehorende resources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) specificeert de submap voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsverwijzingen in het Markdown‑document:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Dit gedrag dient ook als fallback wanneer een aangepaste afbeelding‑opslaahandler `false` retourneert.

## **Aangepast opslaan van afbeeldingen en Markdown‑links**

Gebruik de [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/)‑methode om een callback te registreren voor niet‑SVG‑bitmap‑ en metafile‑resources die tijdens de Markdown‑export worden gegenereerd. De `MarkdownImageSavingHandler`‑callback ontvangt het [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑object, de [ImageFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/)‑waarde en de gegenereerde Markdown‑link als een één‑elementige `String[]`‑parameter. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link[0]` door de referentie die in de Markdown‑output moet verschijnen.

Resources die in SVG‑formaat worden gegenereerd, worden apart afgehandeld. Registreer een callback met de [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/)‑methode. De `MarkdownSvgImageSavingHandler`‑callback ontvangt een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑object en de één‑elementige `String[] link`‑parameter. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload de XML‑data via de [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere content worden; de resulterende niet‑SVG‑resource wordt vervolgens aan de afbeelding‑opslaacallback doorgegeven. Registreer beide callbacks wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde aan `link[0]` heeft toegewezen. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert niet de standaard lokale opslag uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren op basis van de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Belangrijk" %}}

Een handler die `true` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als hij `true` retourneert zonder een geldige, niet‑lege link toe te wijzen, mislukt de export met een `InvalidOperationException`.

{{% /alert %}}

### **Afbeeldingen opslaan in een CDN‑origin‑directory en externe URL’s gebruiken**

Het volgende voorbeeld beschouwt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste map en vervangt de gegenereerde lokale referentie door een publieke CDN‑URL. Het voorbeeld voert zelf geen netwerk‑upload uit: de URL wordt pas geldig wanneer de directory als CDN‑origin is aangekoppeld of de bestanden naar het CDN zijn gepubliceerd. Voor objectopslag vervangt u de bestands‑writes door de upload‑bewerking van de storage‑SDK en kent u `link[0]` pas toe nadat de upload is geslaagd.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

De bitmap‑handler retourneert expres `false` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` met het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden afgehandeld door de aangepaste code. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen OS‑paths bij het schrijven van bestanden; links die in Markdown worden geschreven, gebruiken schuine strepen en URL‑gecodeerde bestandsnamen. Pas dezelfde regel toe bij het bouwen van relatieve links: gebruik `/`, niet de platform‑specifieke scheidingsteken.

## **FAQ**

**Kan één handler zowel raster‑ als SVG‑afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) voor gegenereerde bitmap‑ en metafile‑resources en [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) voor resources die als SVG worden uitgegeven. De eerste biedt een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑object en een [ImageFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/)‑waarde; de tweede biedt een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑object waarvan de SVG‑data kan worden gelezen met [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/). Een bron‑SVG die tijdens de export wordt gerasterd, wordt door de afbeelding‑opslaacallback verwerkt.

**Wat gebeurt er als een afbeelding‑opslaahandler `false` retourneert?**

Aspose.Slides gebruikt dan zijn standaard lokaal‑opslaaggedrag. De locatie van de afbeelding en de gegenereerde referentie worden bepaald door de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markdownsaveoptions/).

**Kan een handler een URL leveren zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar objectopslag of doorgeven aan een andere service, de resulterende URL aan `link[0]` toewijzen en `true` retourneren. De handler moet de verwerking zelf voltooien; `true` voorkomt de standaard lokale opslag.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link opgeeft. Wijs het relatieve pad of de externe URL toe die in Markdown moet worden geschreven alvorens `true` te retourneren.

**Welke scheidingsteken moet worden gebruikt in afbeeldings‑links?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `Path.resolve` alleen voor bestands‑systemen‑paden en bouw of normaliseer de Markdown‑referentie afzonderlijk.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst[hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) worden bewaard als standaard Markdown‑links. Slide[transities](/slides/nl/androidjava/slide-transition/) en [animaties](/slides/nl/androidjava/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

U kunt verschillende presentatiebestanden parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie niet tussen threads. Volg de [multithreading guidelines](/slides/nl/androidjava/multithreading/) en gebruik een aparte instantie per bestand.