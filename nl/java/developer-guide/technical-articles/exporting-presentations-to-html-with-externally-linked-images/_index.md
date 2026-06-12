---
title: Presentaties exporteren naar HTML met extern gekoppelde afbeeldingen
type: docs
weight: 100
url: /nl/java/exporting-presentations-to-html-with-externally-linked-images/
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
- gekoppelde afbeelding
- extern gekoppelde afbeelding
- gekoppelde bron
- externe bron
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument‑presentaties naar HTML in Java met Aspose.Slides, waarbij afbeeldingen en andere bronnen worden opgeslagen als extern gekoppelde bestanden."
---
## **Overview**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandige HTML‑bestand. Afbeeldingen en andere bronnen worden rechtstreeks in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer u één draagbaar bestand nodig heeft, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

- verklein de grootte van het HTML‑document;
- cache afbeeldingen, lettertypen, audio of video afzonderlijk in een browser of CDN;
- inspecteer, vervang, comprimeer of post‑process de gegenereerde bronnen na export;
- houd de uitvoerstructuur dichter bij wat een webapplicatie verwacht.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/java/convert-powerpoint-to-html/). Dit artikel richt zich op het resource‑linkinggedeelte van de export.

## **How Linked Resource Export Works**

[ILinkEmbedController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) laat uw applicatie per resource beslissen of de exporter de gegevens in de HTML inbedt of ze extern opslaat en een koppeling schrijft.

De interface heeft drie methoden:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) bepaalt of een resource gelinkt of ingesloten moet worden.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) geeft de URL terug die in de gegenereerde HTML of naar een andere gelinkte resource zal worden geschreven.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) schrijft de gelinkte resource‑gegevens naar schijf of naar een ander opslagdoel.

Het bestandssysteempad en de browser‑URL zijn aparte zaken. Bijvoorbeeld, het voorbeeld hieronder schrijft bronbestanden naar `html-output/assets` op schijf, terwijl de HTML relatieve URL's bevat zoals `assets/resource-1.svg`. Een browser lost die URL's op relatief ten opzichte van het bestand dat de link bevat. Daarom gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link vanuit dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map is opgeslagen `resource-4.jpg` gebruikt.

## **Export HTML with Linked Resources**

Het volgende Java‑voorbeeld maakt een uitvoermap aan, slaat het HTML‑bestand daar op en bewaart gelinkte resources in een submap `assets`. De controller koppelt veelvoorkomende afbeelding-, lettertype-, audio-, video‑ en CSS‑resources wanneer Aspose.Slides een veilige bestandsextensie levert of kan afleiden. Resources die niet herkend worden, blijven ingesloten.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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

De exacte bestanden hangen af van de inhoud van de presentatie en de export‑opties. Bijvoorbeeld, rasterafbeeldingen worden meestal geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere afbeeldingscodec kiezen dan die in de bronpresentatie wordt gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **Choosing URLs for Deployment**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer één gelinkte resource naar een andere gelinkte resource verwijst, gebruikt het voorbeeld de `referrer`‑parameter in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) en geeft alleen de bestandsnaam terug. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg`, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden ingezet:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload worden naar een CDN of statische bestandserver.

De URL die wordt geretourneerd door [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) moet overeenkomen met de uiteindelijke locatie van het bestand dat wordt geschreven door [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/). In server‑applicaties, gebruik een unieke uitvoermap of object‑storage prefix voor elke conversietaak om overschrijven van bestanden van een andere export te voorkomen.

## **When to Embed Instead**

Ingesloten Base64‑HTML blijft nuttig wanneer de output één enkel bestand moet zijn, bijvoorbeeld als e‑mailbijlage, offline preview, of een document dat verplaatst wordt zonder een ondersteunende asset‑map. Gelinkte resources passen beter wanneer de HTML wordt bediend door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of door browsers onafhankelijk van de HTML gecachet wordt.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

**Kan ik alleen afbeeldingen extern opslaan en andere resources ingesloten houden?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) retourneert u `LinkEmbedDecision.Link` alleen voor de content‑types die u als aparte bestanden wilt opslaan, en `LinkEmbedDecision.Embed` voor al het overige.

**Why does the exported image extension differ from the source presentation?**

**Waarom verschilt de geëxporteerde afbeeldingsextensie van de bronpresentatie?**

Aspose.Slides kan rasterafbeeldingen opnieuw coderen tijdens de HTML‑export om de grootte te verkleinen of de browsercompatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG, afhankelijk van het gerenderde resultaat.

**Do relative URLs work after I move the HTML file?**

**Werken relatieve URL's nog nadat ik het HTML‑bestand verplaats?**

Relatieve URL's werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML verwijst naar `assets/resource-1.png`, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij u een andere URL‑prefix genereert.

**Should server applications reuse the same output folder?**

**Moeten server‑applicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik een unieke uitvoermap of opslag‑prefix voor elke conversietaak. Dit voorkomt bestandsnaamconflicten en voorkomt dat één export resources van een andere export overschrijft.