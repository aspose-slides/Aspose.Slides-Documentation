---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i Java med Aspose.Slides där bilder och andra resurser sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML-fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64-data. Detta är bekvämt när du behöver en portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server‑sidig konverteringspipeline.

Använd externa länkar till resurser när du vill:

- reducera storleken på HTML-dokumentet;
- cacha bilder, teckensnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- behålla utdata‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML‑konverteringsarbetsflödet, se [Konvertera PowerPoint-presentationer till HTML](/slides/sv/java/convert-powerpoint-to-html/). Denna artikel fokuserar på den resurs‑länkningsdel som exporten innehåller.

## **Hur export av länkade resurser fungerar**

[ILinkEmbedController](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) låter din applikation avgöra, resurs för resurs, om exportören bäddar in data i HTML eller sparar dem externt och skriver en länk.

Gränssnittet har tre metoder:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) bestämmer om en resurs ska länkas eller bäddas in.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) returnerar URL‑en som skrivas till den genererade HTML‑filen eller till en annan länkad resurs.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) skriver de länkade resursdata till disk eller till ett annat lagringsmål.

Fil‑systemets sökväg och webbläsarens URL är separata bekymmer. Till exempel skriver exemplet nedan resursfiler till `html-output/assets` på disk, medan HTML‑filen innehåller relativa URL‑er såsom `assets/resource-1.svg`. En webbläsare löser dessa URL‑er relativt till filen som innehåller länken. Därför använder en länk från `presentation.html` till en SVG‑fil `assets/resource-1.svg`, medan en länk från den SVG‑filen till en bild sparad i samma `assets`‑mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande Java‑exempel skapar en utdata‑katalog, sparar HTML‑filen där och lagrar länkade resurser i en `assets`‑undermapp. Kontrollen länkar vanliga bild‑, teckensnitt‑, ljud‑, video‑ och CSS‑resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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

Efter exporten har utdata‑mappen följande struktur:

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

De exakt filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder oftast som JPEG eller PNG. Aspose.Slides kan välja en annan bildkodare än den som användes i källpresentationen om det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL‑er för distribution**

Exemplet använder ett relativt URL‑prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html`, laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs refererar till en annan länkad resurs, använder exemplet parametern `referrer` i [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda ligger i `assets`‑mappen, bör SVG‑filen referera till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL‑prefix när filerna distribueras någon annanstans:

- Använd `assets/` när tillgångs‑katalogen ligger bredvid HTML‑filen.
- Använd `../assets/` när tillgångs‑katalogen är en nivå över HTML‑filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

URL‑en som returneras av [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) måste matcha den slutliga placerings‑URL för filen som skrivs av [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/). I serverapplikationer, använd en unik utdata‑katalog eller objekt‑lagrings‑prefix för varje konverteringsjobb för att undvika att filer från en annan export skrivs över.

## **När man ska bädda in istället**

Inbäddad Base64‑HTML är fortfarande användbar när utdata måste vara en enda fil, exempelvis ett e‑post‑bilaga, en offline‑förhandsgranskning eller ett dokument som kommer att flyttas utan en stödjande tillgångs‑mapp. Länkade resurser är ett bättre alternativ när HTML‑filen kommer att serveras av en webbapplikation, lagras i ett CMS, optimeras av en bygg‑pipeline eller cachas av webbläsare oberoende av HTML‑filen.

## **Vanliga frågor**

**Kan jag externalisera bara bilder och behålla andra resurser inbäddade?**

Ja. I [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinkembedcontroller/) returnera `LinkEmbedDecision.Link` endast för de innehållstyper du vill spara som separata filer, och returnera `LinkEmbedDecision.Embed` för allt annat.

**Varför skiljer sig den exporterade bildfilens extension från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML‑export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag har flyttat HTML‑filen?**

Relativa URL‑er fungerar endast när samma relativa mappstruktur bevaras. Om HTML‑filen refererar till `assets/resource-1.png` måste `assets`‑mappen ligga kvar bredvid HTML‑filen om du inte genererar ett annat URL‑prefix.

**Ska serverapplikationer återanvända samma utdata‑mapp?**

Nej. Använd en unik utdata‑katalog eller lagrings‑prefix för varje konverteringsjobb. Detta undviker filnamnskollisioner och förhindrar att en export skriver över resurser som genererats av en annan export.