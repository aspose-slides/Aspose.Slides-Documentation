---
title: Exporteren van presentaties naar HTML met extern gelinkte afbeeldingen
type: docs
weight: 100
url: /nl/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- dia exporteren
- PPT exporteren
- PPTX exporteren
- ODP exporteren
- PowerPoint naar HTML
- OpenDocument naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- gelinkte afbeelding
- extern gelinkte afbeelding
- gelinkte resource
- externe resource
- PHP
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar HTML in PHP via Java met Aspose.Slides, waarbij afbeeldingen en andere resources worden opgeslagen als extern gelinkte bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandige HTML‑bestand. Afbeeldingen en andere resources worden direct in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer u één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

Gebruik extern gelinkte resources wanneer u wilt:

- de grootte van het HTML‑document verkleinen;
- afbeeldingen, lettertypen, audio of video afzonderlijk cachen in een browser of CDN;
- gegenereerde resources inspecteren, vervangen, comprimeren of post‑processen nadat ze geëxporteerd zijn;
- de output‑structuur dichter bij wat een webapplicatie verwacht houden.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/php-java/convert-powerpoint-to-html/). Dit artikel richt zich op het resource‑linkgedeelte van de export.

## **Hoe gelinkte resource-export werkt**

[HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/) kan een aangepaste link/embed‑controller gebruiken wanneer Aspose.Slides een presentatie exporteert naar HTML. In PHP via Java wordt dit scenario meestal geïmplementeerd met een kleine Java‑helper‑klasse. Compileer die helper, voeg hem toe aan de PHP Java Bridge‑classpath, en instantieer hem vanuit PHP met `new Java(...)`.

De helper‑klasse bepaalt, resource voor resource, of de exporter de data in de HTML embeded of extern opslaat en een link schrijft. Het heeft drie callback‑methoden nodig:

- `ExternalResourceController.getObjectStoringLocation` bepaalt of een resource gelinkt of embedded moet worden.
- `ExternalResourceController.getUrl` geeft de URL terug die in de gegenereerde HTML of naar een andere gelinkte resource wordt geschreven.
- `ExternalResourceController.saveExternal` schrijft de gelinkte resource‑data naar disk of naar een ander opslagdoel.

Het bestandssysteem‑pad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het onderstaande voorbeeld schrijft resource‑bestanden naar `html-output/assets` op disk, terwijl de HTML relatieve URL’s bevat zoals `assets/resource-1.svg`. Een browser lost die URL’s op ten opzichte van het bestand dat de link bevat. Daarom gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link van dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map is opgeslagen, `resource-4.jpg` gebruikt.

## **Maak de Java‑helper‑klasse**

Maak een Java‑klasse aan, bijvoorbeeld `com.example.slides.ExternalResourceController`, compileer deze met Aspose.Slides for Java op de classpath, en maak de gecompileerde klasse of JAR beschikbaar voor de PHP Java Bridge.

De helper hieronder linkt veelvoorkomende afbeelding‑, lettertype‑, audio‑, video‑ en CSS‑resources wanneer Aspose.Slides een veilige bestandsextensie aanbiedt of kan afleiden. Resources die niet herkend worden, blijven embedded.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Exporteer HTML met gelinkte resources**

De volgende PHP‑code maakt een uitvoermap aan, slaat het HTML‑bestand daar op, en slaat gelinkte resources op in een submap `assets`. Het combineert [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideimageformat/) en [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) voor de export.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Na de export heeft de uitvoermap deze structuur:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Bijvoorbeeld, rasterafbeeldingen worden doorgaans geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere beeldcodec kiezen dan die van de oorspronkelijke presentatie wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **Kiezen van URL’s voor productie**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend van `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer een gelinkte resource naar een andere gelinkte resource verwijst, gebruikt het voorbeeld de `referrer`‑parameter in `ExternalResourceController.getUrl` en geeft alleen de bestandsnaam terug. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg`, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden ingezet:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload worden naar een CDN of statische bestandsserver.

De URL die door `ExternalResourceController.getUrl` wordt geretourneerd moet overeenkomen met de uiteindelijke inzetlocatie van het bestand dat door `ExternalResourceController.saveExternal` is weggeschreven. In server‑applicaties, gebruik een unieke uitvoermap of object‑storage‑prefix voor elke conversietaak om overschrijven van bestanden van een andere export te voorkomen.

## **Wanneer embedden in plaats daarvan**

Embedded Base64‑HTML is nog steeds handig wanneer de output een enkel bestand moet zijn, zoals een e‑mailbijlage, een offline preview, of een document dat wordt verplaatst zonder een ondersteunende asset‑map. Gelinkte resources passen beter wanneer de HTML wordt bediend door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of door browsers onafhankelijk van de HTML wordt gecached.

## **FAQ**

**Kan ik alleen afbeeldingen externaliseren en andere resources embedded houden?**

Ja. In `ExternalResourceController.getObjectStoringLocation` retourneert u de `Link`‑waarde van [LinkEmbedDecision](https://reference.aspose.com/slides/nl/php-java/aspose.slides/linkembeddecision/) alleen voor de content‑types die u als afzonderlijke bestanden wilt opslaan, en retourneert u de `Embed`‑waarde voor alles anders.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van die in de oorspronkelijke presentatie?**

Aspose.Slides kan rasterafbeeldingen opnieuw coderen tijdens de HTML‑export om de grootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG, afhankelijk van het gerenderde resultaat.

**Werken relatieve URL’s na het verplaatsen van het HTML‑bestand?**

Relatieve URL’s werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML verwijst naar `assets/resource-1.png`, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij u een andere URL‑prefix genereert.

**Moeten server‑applicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik een unieke uitvoermap of opslag‑prefix voor elke conversietaak. Dit voorkomt bestandsnaamconflicten en voorkomt dat een export resources van een andere export overschrijft.