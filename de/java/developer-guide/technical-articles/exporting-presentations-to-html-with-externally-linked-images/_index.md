---
title: Präsentationen nach HTML mit extern verknüpften Bildern exportieren
type: docs
weight: 100
url: /de/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- Folie exportieren
- PPT exportieren
- PPTX exportieren
- ODP exportieren
- PowerPoint nach HTML
- OpenDocument nach HTML
- Präsentation nach HTML
- Folie nach HTML
- PPT nach HTML
- PPTX nach HTML
- ODP nach HTML
- verknüpftes Bild
- extern verknüpftes Bild
- verknüpfte Ressource
- externe Ressource
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML in Java mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verknüpfte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML‑Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, meist als Base64‑Daten. Das ist praktisch, wenn Sie eine portable Datei benötigen, ist jedoch nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verlinkte Ressourcen, wenn Sie:

- die Größe des HTML‑Dokuments reduzieren;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export inspizieren, ersetzen, komprimieren oder nachzuverarbeiten;
- die Ausgabestruktur näher an das halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungsablauf siehe [PowerPoint‑Präsentationen nach HTML konvertieren](/slides/de/java/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Teil des Exports, der das Verlinken von Ressourcen betrifft.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[ILinkEmbedController](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) ermöglicht es Ihrer Anwendung, ressourcenweise zu entscheiden, ob der Exporter die Daten in das HTML einbettet oder sie extern speichert und einen Link schreibt.

Das Interface verfügt über drei Methoden:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) gibt die URL zurück, die in das erzeugte HTML oder in eine andere verknüpfte Ressource geschrieben wird.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) schreibt die Daten der verknüpften Ressource auf die Festplatte oder in ein anderes Speicherziel.

Der Dateisystempfad und die Browser‑URL sind getrennte Aspekte. Im Beispiel unten werden Ressourcen‑Dateien auf die Festplatte unter `html-output/assets` geschrieben, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem im selben `assets`‑Ordner gespeicherten Bild `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende Java‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Der Controller verlinkt gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Ressourcen, die nicht erkannt werden, bleiben eingebettet.

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

Nach dem Export hat der Ausgabordner diese Struktur:

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

Die konkreten Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Beispielsweise werden Rasterbilder üblicherweise als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als den in der Quellpräsentation verwendeten, wenn dies zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wird `presentation.html` aus `html-output/presentation.html` geöffnet, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, verwendet das Beispiel den Parameter `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) und gibt nur den Dateinamen zurück. Beispielsweise sollte die SVG‑Datei, wenn `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets` liegen, auf `resource-4.jpg` verweisen und nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien woanders bereitgestellt werden:

- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien in ein CDN oder einen statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) zurückgegebene URL muss dem endgültigen Bereitstellungsort der Datei entsprechen, die von [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) geschrieben wird. In Server‑Anwendungen sollten Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein Objekt‑Speicher‑Präfix verwenden, um das Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, z. B. als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne einen begleitenden Asset‑Ordner verschoben wird. Verknüpfte Ressourcen sind besser geeignet, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet lassen?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilinkembedcontroller/) geben Sie `LinkEmbedDecision.Link` nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und `LinkEmbedDecision.Embed` für alle anderen.

**Warum unterscheidet sich die exportierte Bild‑Erweiterung von der Quellpräsentation?**

Aspose.Slides kann Rasterbilder beim HTML‑Export neu kodieren, um Größe oder Browser‑Kompatibilität zu verbessern. Zum Beispiel kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur beibehalten wird. Verweist das HTML auf `assets/resource-1.png`, muss der `assets`‑Ordner neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein Speicher‑Präfix. Dies verhindert Dateinamen‑Kollisionen und verhindert, dass ein Export Ressourcen eines anderen Exports überschreibt.