---
title: Presentaties exporteren naar HTML met extern gelinkte afbeeldingen
type: docs
weight: 100
url: /nl/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar HTML op Android via Java met Aspose.Slides, waarbij afbeeldingen en andere resources worden opgeslagen als extern gelinkte bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandige HTML‑bestand. Afbeeldingen en andere resources worden direct in de HTML geschreven, meestal als Base64‑data. Dit is handig wanneer u één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een webweergave, een CMS of een server‑side conversiepijplijn die later de output publiceert.

Gebruik extern gelinkte resources wanneer u wilt:
- de grootte van het HTML‑document verkleinen;
- afbeeldingen, lettertypen, audio of video apart cachen in een browser of CDN;
- gegenereerde resources na export inspecteren, vervangen, comprimeren of nabewerken;
- de outputstructuur dichter bij wat een webapplicatie verwacht houden.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/androidjava/convert-powerpoint-to-html/). Dit artikel richt zich op het resource‑linkgedeelte van de export.

## **Hoe gelinkte resource‑export werkt**

[ILinkEmbedController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) laat uw applicatie per resource beslissen of de exporter de gegevens in de HTML invoegt of extern opslaat en een link schrijft.

De interface heeft drie methoden:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) bepaalt of een resource gelinkt of ingesloten moet worden.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) retourneert de URL die in de gegenereerde HTML of een andere gelinkte resource zal worden geschreven.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) schrijft de gelinkte resource‑data naar schijf of naar een ander opslagdoel.

Het bestandssysteempad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het voorbeeld hieronder schrijft resource‑bestanden naar `html-output/assets` in de bestandsopslag van de applicatie, terwijl de HTML relatieve URL’s bevat zoals `assets/resource-1.svg`. Een browser lost die URL’s op ten opzichte van het bestand dat de link bevat. Daarom gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link vanuit dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map is opgeslagen `resource-4.jpg` gebruikt.

## **HTML exporteren met gelinkte resources**

Het volgende Android‑Java‑voorbeeld maakt een output‑directory aan, slaat het HTML‑bestand daar op, en bewaart gelinkte resources in een `assets`‑subdirectory. Geef een door de app beheerde directory, zoals `context.getFilesDir()`, door als `applicationFilesDirectory`. De code vermijdt `java.nio.file`‑API’s, zodat hij compatibel blijft met Android `minSdk` 19.

De controller linkt veelvoorkomende afbeelding‑, lettertype‑, audio‑, video‑ en CSS‑resources wanneer Aspose.Slides een veilige bestandsextensie levert of kan afleiden. Niet‑erkende resources blijven ingesloten.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile .getAbsolutePath(),
                    exception);
        }
    }
}
```

Na de export heeft de output‑map deze structuur:

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

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Bijvoorbeeld, rasterafbeeldingen worden meestal geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere beeldcodec kiezen dan die in de bronpresentatie wordt gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL’s kiezen voor inzet**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer één gelinkte resource naar een andere gelinkte resource verwijst, gebruikt het voorbeeld de `referrer`‑parameter in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) en retourneert alleen de bestandsnaam. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg`, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden ingezet:
- Gebruik `assets/` wanneer de asset‑directory naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑directory één niveau hoger dan het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden worden geüpload naar een CDN of statische bestandsserver.

De URL die wordt geretourneerd door [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) moet overeenkomen met de uiteindelijke locatie van het bestand dat wordt geschreven door [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/). In Android‑applicaties gebruikt u app‑specifieke opslag, een cache‑directory, of een directory verkregen via het Storage Access Framework volgens uw publicatieworkflow. In server‑applicaties gebruikt u een unieke output‑directory of object‑storage‑prefix voor elke conversietaak om te voorkomen dat bestanden van een andere export worden overschreven.

## **Wanneer in plaats daarvan insluiten**

Ingesloten Base64‑HTML is nog steeds bruikbaar wanneer de output een enkel bestand moet zijn, bijvoorbeeld een e‑mailbijlage, een offline preview, of een document dat wordt verplaatst zonder een ondersteunende asset‑map. Gelinkte resources passen beter wanneer de HTML wordt geserveerd door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of onafhankelijk door browsers wordt gecachet van de HTML.

## **FAQ**

**Kan ik alleen afbeeldingen extern maken en andere resources ingesloten houden?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) retourneert u `Link` van [LinkEmbedDecision](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/linkembeddecision/) alleen voor de content‑typen die u als afzonderlijke bestanden wilt opslaan, en retourneert u `Embed` voor alles andere.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van die van de bronpresentatie?**

Aspose.Slides kan rasterafbeeldingen opnieuw coderen tijdens de HTML‑export om de grootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG afhankelijk van het gerenderde resultaat.

**Werken relatieve URL’s nadat ik het HTML‑bestand heb verplaatst?**

Relatieve URL’s werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML `assets/resource-1.png` aanspreekt, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij u een andere URL‑prefix genereert.

**Kan ik resources schrijven naar openbare externe opslag op Android?**

Ja, als uw applicatie een geldige bestemming en toestemmingsmodel heeft voor de doel‑Android‑versie. Voor gegenereerde HTML die alleen door uw app wordt gebruikt, zijn app‑specifieke bestanden of cache‑directories meestal eenvoudiger. Voor gebruikers‑zichtbare output gebruikt u een door de gebruiker gekozen locatie of een andere opslagmethode die bij uw app past.

**Moeten server‑applicaties dezelfde output‑map hergebruiken?**

Nee. Gebruik een unieke output‑directory of opslag‑prefix voor elke conversietaak. Dit voorkomt bestandsnaamconflicten en voorkomt dat één export resources van een andere export overschrijft.