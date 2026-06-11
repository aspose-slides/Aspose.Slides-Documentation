---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML på Android via Java med Aspose.Slides där bilder och andra resurser sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en självständig HTML-fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64-data. Detta är bekvämt när du behöver en enda portabel fil, men det är inte alltid det bästa formatet för en webbvy, ett CMS eller en server-sidig konverteringspipeline som senare publicerar resultatet.

- minska storleken på HTML-dokumentet;
- cachea bilder, teckensnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- hålla utdata‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML-konverteringsarbetsflödet, se [Convert PowerPoint Presentations to HTML](/slides/sv/androidjava/convert-powerpoint-to-html/). Denna artikel fokuserar på resurslänkning-delen av exporten.

## **Hur export av länkade resurser fungerar**

[ILinkEmbedController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) låter din applikation avgöra, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk.

Gränssnittet har tre metoder:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) avgör om en resurs ska länkas eller bäddas in.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) returnerar URL:en som kommer att skrivas till den genererade HTML-filen eller till en annan länkad resurs.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) skriver de länkade resursdata till disk eller till ett annat lagringsmål.

Filsystemssökvägen och webbläsar-URL:en är separata frågor. Till exempel skriver exemplet nedan resursfiler till `html-output/assets` i applikationens fillagring, medan HTML-filen innehåller relativa URL-er som `assets/resource-1.svg`. En webbläsare löser dessa URL-er relativt den fil som innehåller länken. Därför använder en länk från `presentation.html` till en SVG-fil `assets/resource-1.svg`, medan en länk från den SVG-filen till en bild sparad i samma `assets`-mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande Android-Java-exempel skapar en katalog för utdata, sparar HTML-filen där och lagrar länkade resurser i en `assets`-undermapp. Skicka en app-ägda katalog, t.ex. `context.getFilesDir()`, som `applicationFilesDirectory`. Koden undviker `java.nio.file`-API:er, så den förblir kompatibel med Android `minSdk` 19.

Kontrollen länkar vanliga bild-, teckensnitt-, ljud-, video- och CSS-resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

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
                            outputFile.getAbsolutePath(),
                    exception);
        }
    }
}
```

Efter exporten har utdata-mappen följande struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder vanligtvis som JPEG eller PNG. Aspose.Slides kan välja en annan bild-codec än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exemplet använder ett relativt URL-prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs refererar till en annan länkad resurs, använder exemplet parametern `referrer` i [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) och returnerar endast filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda ligger i `assets`-mappen, ska SVG-filen referera till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL-prefix när filerna ligger någon annanstans:

- Använd `assets/` när tillgångsmappen ligger bredvid HTML-filen.
- Använd `../assets/` när tillgångsmappen ligger ett nivå över HTML-filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till en CDN- eller statisk filserver.

URL-en som returneras av [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) måste matcha den slutliga distribuerade platsen för filen som skrivs av [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/). I Android-applikationer, använd app-specifik lagring, en cache-katalog eller en katalog erhållen via Storage Access Framework enligt ditt publiceringsflöde. I server-applikationer, använd en unik utdata-katalog eller ett objekt-lagrings-prefix för varje konverteringsjobb för att undvika att filer från en annan export skrivs över.

## **När man ska bädda in istället**

Inbäddad Base64-HTML är fortfarande användbart när utdata måste vara en enda fil, t.ex. en e-postbilaga, en offline-förhandsgranskning eller ett dokument som ska flyttas utan en stödjande tillgångsmapp. Länkade resurser är en bättre lösning när HTML kommer att serveras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag externa bara bilder och behålla andra resurser inbäddade?**

Ja. I [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) returnerar du `Link` från [LinkEmbedDecision](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/linkembeddecision/) endast för de innehållstyper du vill spara som separata filer, och returnerar `Embed` för allt annat.

**Varför skiljer sig den exporterade bildändelsen från källpresentationen?**

Aspose.Slides kan koda om rasterbilder under HTML-export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL-er efter att jag flyttat HTML-filen?**

Relativa URL-er fungerar endast när samma relativa mappstruktur bevaras. Om HTML-filen refererar till `assets/resource-1.png` måste `assets`-mappen ligga bredvid HTML-filen såvida du inte genererar ett annat URL-prefix.

**Kan jag skriva resurser till offentlig extern lagring på Android?**

Ja, om din applikation har ett giltigt mål och en behörighetsmodell för den aktuella Android-versionen. För genererad HTML som endast används av din app är app-specifika filer eller cache-kataloger vanligtvis enklare. För användarsynligt resultat, använd en användarvald plats eller en annan lagringsmetod som passar din app.

**Ska serverapplikationer återanvända samma utdata-mapp?**

Nej. Använd en unik utdata-katalog eller lagrings-prefix för varje konverteringsjobb. Detta undviker filnamnskrockar och förhindrar att en export skriver över resurser som genererats av en annan export.