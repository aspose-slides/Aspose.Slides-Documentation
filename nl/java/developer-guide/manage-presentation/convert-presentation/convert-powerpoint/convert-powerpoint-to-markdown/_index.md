---
title: PowerPoint-presentaties converteren naar Markdown in Java
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/java/convert-powerpoint-to-markdown/
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
- CDN-afbeeldingslinks
- PowerPoint
- presentatie
- Markdown
- Java
- Aspose.Slides
description: "Converteer PPT‑ en PPTX‑presentaties naar Markdown in Java en bepaal waar geëxporteerde bitmap‑, metafile‑ en SVG‑afbeeldingen worden opgeslagen en naar verwezen."
---
## **Overzicht**

Aspose.Slides for Java kan PPT‑ en PPTX‑presentaties naar Markdown converteren voor documentatie, statische sites, contentmigratie en versie‑controle‑workflows. U kunt een Markdown‑variant kiezen, bepalen hoe slide‑inhoud wordt weergegeven en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt de Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stelt u het exporttype in met de [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)‑methode op de waarde `Sequential` of `Visual` uit de [MarkdownExportType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownexporttype/)‑enumeratie. `Sequential` rendert slide‑elementen afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde elementen samen houdt om hun visuele relatie te behouden. De waarde `TextOnly` genereert geen afbeeldingsbronnen, zodat de image‑saving‑callbacks in die modus niet worden aangeroepen.

## **Converteer een presentatie naar Markdown**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)-klasse en roep vervolgens de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)-methode aan met de `Md`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/)-enumeratie.

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

De [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)-methode bepaalt welke Markdown‑specificatie voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/flavor/)-enumeratie omvat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

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

## **Exporteer afbeeldingen met het standaard lokale opslaan‑gedrag**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)-klasse biedt twee methoden om lokaal opgeslagen afbeeldingen te configureren:

- [setBasePath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) specificeert de basismap voor het Markdown‑document en de bijbehorende resources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) specificeert de submap voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsreferenties in het Markdown‑document:

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

Dit gedrag dient ook als terugval wanneer een aangepaste image‑saving‑handler `false` retourneert.

## **Pas image‑opslaan en Markdown‑links aan**

Gebruik de [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)-methode om een callback te registreren voor niet‑SVG‑bitmap‑ en metafile‑resources die tijdens de Markdown‑export worden gegenereerd. De `MarkdownImageSavingHandler`‑callback ontvangt het [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/)-object, zijn [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/)-waarde, en de gegenereerde Markdown‑link als een één‑elementige `String[]`‑parameter. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link[0]` door de referentie die in de Markdown‑output moet verschijnen.

Resources die in SVG‑formaat worden gegenereerd, worden apart afgehandeld. Registreer een callback met de [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/)-methode. De `MarkdownSvgImageSavingHandler`‑callback ontvangt een [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/)-object en de één‑elementige `String[] link`‑parameter. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑data via de [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/)-methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere inhoud worden; de resulterende niet‑SVG‑resource wordt vervolgens doorgegeven aan de image‑saving‑callback. Registreer beide callbacks wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde heeft toegewezen aan `link[0]`. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert het standaard lokale opslaan niet uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren volgens de waarden ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Belangrijk" %}}
Een handler die `true` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als hij `true` retourneert zonder een geldige, niet‑lege link toe te wijzen, mislukt de export met een `InvalidOperationException`.
{{% /alert %}}

### **Sla afbeeldingen op in een CDN‑origin‑directory en gebruik externe URL’s**

Het volgende voorbeeld behandelt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste directory en vervangt de gegenereerde lokale referentie door een openbare CDN‑URL. Het voorbeeld zelf voert geen netwerkupload uit: de URL wordt pas geldig nadat de directory is aangekoppeld als CDN‑origin of de bestanden naar het CDN zijn gepubliceerd. Voor objectopslag vervangt u de bestands‑systeem‑schrijfbewerking door de upload‑operatie van de opslag‑SDK en kent u `link[0]` pas toe na een geslaagde upload.

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

De bitmap‑handler retourneert opzettelijk `false` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` met het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden afgehandeld door de aangepaste code. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen besturingssysteem‑paden bij het schrijven van bestanden; links in Markdown gebruiken schuine strepen (`/`) en URL‑geëncodeerde bestandsnamen. Pas dezelfde regel toe bij het bouwen van relatieve links: gebruik `/`, niet de platform‑specifieke map‑scheidingsteken.

## **FAQ**

**Kan één handler zowel raster‑ als SVG‑afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) voor uitgegeven bitmap‑ en metafile‑resources en [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) voor resources die als SVG worden uitgegeven. De eerste levert een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/)-object en een [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/)-waarde; de tweede levert een [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/)-object waarvan de SVG‑data kan worden gelezen met [ISvgImage.getSvgData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/). Een bron‑SVG die tijdens export wordt gerasterd, wordt verwerkt door de image‑saving‑callback.

**Wat gebeurt er wanneer een image‑saving‑handler `false` retourneert?**

Aspose.Slides gebruikt het standaard lokale opslaan‑gedrag. De afbeeldingslocatie en de gegenereerde referentie worden bepaald door de waarden ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markdownsaveoptions/).

**Kan een handler een URL geven zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar objectopslag of doorgeven aan een andere service, de resulterende URL toewijzen aan `link[0]` en `true` retourneren. De handler moet de verwerking zelf voltooien; het retourneren van `true` voorkomt het standaard lokale opslaan.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link levert. Wijs het relatieve pad of de externe URL toe die in Markdown moet worden geschreven voordat u `true` retourneert.

**Welke pad‑scheidingsteken moet worden gebruikt in afbeeldingslinks?**

Gebruik schuine strepen in Markdown‑links en URL’s. Gebruik `Path.resolve` alleen voor besturingssysteem‑paden en bouw of normaliseer vervolgens de Markdown‑referentie apart.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst‑[hyperlinks](/slides/nl/java/manage-hyperlinks/) worden bewaard als standaard Markdown‑links. Slide‑[transities](/slides/nl/java/slide-transition/) en -[animaties](/slides/nl/java/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

U kunt verschillende presentatiebestanden parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie niet tussen threads. Volg de [multithreading guidelines](/slides/nl/java/multithreading/) en gebruik een aparte instantie per bestand.