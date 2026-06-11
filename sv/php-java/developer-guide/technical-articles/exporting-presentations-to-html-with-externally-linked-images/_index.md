---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- exportera bild
- exportera PPT
- exportera PPTX
- exportera ODP
- PowerPoint till HTML
- OpenDocument till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- länkad bild
- externt länkad bild
- länkad resurs
- extern resurs
- PHP
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i PHP via Java med Aspose.Slides, där bilder och andra resurser sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML‑fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64‑data. Detta är praktiskt när du behöver en enda portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server‑sidig konverteringspipeline.

Använd externt länkade resurser när du vill:

- minska storleken på HTML‑dokumentet;
- cacha bilder, teckensnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- behålla utdata‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML‑konverteringsarbetsflödet, se [Konvertera PowerPoint‑presentationer till HTML](/slides/sv/php-java/convert-powerpoint-to-html/). Denna artikel fokuserar på den resurs‑länkande delen av exporten.

## **Hur länkad resurs‑export fungerar**

[HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) kan använda en anpassad länk/infästad‑kontroller när Aspose.Slides exporterar en presentation till HTML. I PHP via Java implementeras detta scenario vanligtvis med en liten Java‑hjälparklass. Kompilera den hjälparklassen, lägg till den i PHP Java Bridge‑klassvägen och instansiera den från PHP med `new Java(...)`.

Hjälparklassen avgör, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk. Den behöver tre återuppringningsmetoder:

- `ExternalResourceController.getObjectStoringLocation` avgör om en resurs ska länkas eller bäddas in.
- `ExternalResourceController.getUrl` returnerar den URL som kommer att skrivas till den genererade HTML‑filen eller till en annan länkad resurs.
- `ExternalResourceController.saveExternal` skriver den länkade resursens data till disk eller till ett annat lagringsmål.

Filsystemssökvägen och webbläsar‑URL:en är separata frågor. Till exempel skriver provet nedan resursfiler till `html-output/assets` på disken, medan HTML‑filen innehåller relativa URL:er såsom `assets/resource-1.svg`. En webbläsare löser dessa URL:er relativt till filen som innehåller länken. Således använder en länk från `presentation.html` till en SVG‑fil `assets/resource-1.svg`, medan en länk från den SVG‑filen till en bild som sparats i samma `assets`‑mapp använder `resource-4.jpg`.

## **Skapa Java‑hjälparklassen**

Skapa en Java‑klass, exempelvis `com.example.slides.ExternalResourceController`, kompilera den med Aspose.Slides för Java på klassvägen och gör den kompilerade klassen eller JAR‑filen tillgänglig för PHP Java Bridge.

Hjälparklassen nedan länkar vanliga bild-, teckensnitt-, ljud-, video‑ och CSS‑resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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

## **Exportera HTML med länkade resurser**

Följande PHP‑kod skapar en utdatamapp, sparar HTML‑filen där och lagrar länkade resurser i en `assets`‑undermapp. Den kombinerar [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideimageformat/) och [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/) för exporten.

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

Efter exporten har utdatamappen följande struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder ofta som JPEG eller PNG. Aspose.Slides kan välja en annan bildkodare än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exemplet använder ett relativt URL‑prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs hänvisar till en annan länkad resurs använder exemplet `referrer`‑parametern i `ExternalResourceController.getUrl` och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda ligger i `assets`‑mappen, bör SVG‑filen hänvisa till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL‑prefix när filerna distribueras någon annanstans:

- Använd `assets/` när asset‑katalogen ligger bredvid HTML‑filen.
- Använd `../assets/` när asset‑katalogen ligger ett nivå högre än HTML‑filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

Den URL som returneras av `ExternalResourceController.getUrl` måste matcha den slutgiltiga distribuerade platsen för filen som skrivs av `ExternalResourceController.saveExternal`. I serverapplikationer bör du använda en unik utdatamapp eller objekt‑lagrings‑prefix för varje konverteringsjobb för att undvika att filer från en annan export skrivs över.

## **När man ska bädda in istället**

Inbäddad Base64‑HTML är fortfarande användbar när utdata måste vara en enda fil, exempelvis som ett e‑post‑bilaga, en offline‑förhandsgranskning eller ett dokument som ska flyttas utan en stödjande asset‑mapp. Länkade resurser är ett bättre alternativ när HTML‑filen kommer att serveras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **Vanliga frågor**

**Kan jag externalisera endast bilder och behålla andra resurser inbäddade?**

Ja. I `ExternalResourceController.getObjectStoringLocation` returnerar du `Link`‑värdet från [LinkEmbedDecision](https://reference.aspose.com/slides/sv/php-java/aspose.slides/linkembeddecision/) endast för de innehållstyper du vill spara som separata filer, och returnerar `Embed`‑värdet för allt annat.

**Varför skiljer sig den exporterade bildfilens ändelse från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML‑export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag flyttat HTML‑filen?**

Relativa URL:er fungerar endast när samma relativa mappstruktur bevaras. Om HTML‑filen refererar till `assets/resource-1.png` måste `assets`‑mappen förbli bredvid HTML‑filen om du inte genererar ett annat URL‑prefix.

**Ska serverapplikationer återanvända samma utdatamapp?**

Nej. Använd en unik utdatamapp eller lagringsprefix för varje konverteringsjobb. Detta undviker filnamnskonflikter och förhindrar att en export skriver över resurser som genererats av en annan export.