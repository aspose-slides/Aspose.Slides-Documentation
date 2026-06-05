---
title: Präsentationen nach HTML mit extern verknüpften Bildern exportieren
type: docs
weight: 100
url: /de/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- Folie exportieren
- PPT exportieren
- PPTX exportieren
- ODP exportieren
- PowerPoint zu HTML
- OpenDocument zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- verknüpftes Bild
- extern verknüpftes Bild
- verknüpfte Ressource
- externe Ressource
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint- und OpenDocument-Präsentationen nach HTML unter Android über Java mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verknüpfte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML-Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, üblicherweise als Base64-Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, ist aber nicht immer das beste Format für eine Webansicht, ein CMS oder eine serverseitige Konvertierungspipeline, die das Ergebnis später veröffentlicht.

Verwenden Sie externe verknüpfte Ressourcen, wenn Sie:
- die Größe des HTML‑Dokuments reduzieren;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export prüfen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabestruktur näher an das halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML‑Konvertierungs‑Workflow siehe [Convert PowerPoint Presentations to HTML](/slides/de/androidjava/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Ressourcenverlinkungs‑Teil des Exports.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[ILinkEmbedController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) lässt Ihre Anwendung pro Ressource entscheiden, ob der Exporter die Daten in das HTML einbettet oder sie extern speichert und einen Link schreibt.

Das Interface verfügt über drei Methoden:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) liefert die URL, die in das erzeugte HTML oder zu einer anderen verknüpften Ressource geschrieben wird.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) schreibt die verknüpften Ressourcendaten auf die Festplatte oder an ein anderes Speicherziel.

Der Dateisystempfad und die Browser‑URL sind separate Anliegen. Im Beispiel unten werden Ressourcendateien in `html-output/assets` im Dateispeicher der Anwendung geschrieben, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem im selben `assets`‑Ordner gespeicherten Bild `resource-4.jpg` verwendet.

## **HTML mit verknüpften Ressourcen exportieren**

Das folgende Android‑Java‑Beispiel erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Übergeben Sie ein app‑eigenes Verzeichnis wie `context.getFilesDir()` als `applicationFilesDirectory`. Der Code verzichtet auf `java.nio.file`‑APIs, sodass er mit Android `minSdk` 19 kompatibel bleibt.

Der Controller verlinkt gängige Bild‑, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

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

Nach dem Export hat der Ausgabordner folgende Struktur:

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bildcodec wählen als den im Quell‑Presentation genutzten, wenn dies zu einer kleineren oder geeigneteren Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wird `presentation.html` aus `html-output/presentation.html` geöffnet, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, verwendet das Beispiel den Parameter `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) und gibt nur den Dateinamen zurück. Beispiel: Befinden sich `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets`, sollte die SVG‑Datei auf `resource-4.jpg` verweisen, nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien andernorts bereitgestellt werden:
- Verwenden Sie `assets/`, wenn sich das Asset‑Verzeichnis neben der HTML‑Datei befindet.
- Verwenden Sie `../assets/`, wenn sich das Asset‑Verzeichnis eine Ebene über der HTML‑Datei befindet.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien zu einem CDN oder statischen Dateiserver hochgeladen werden.

Die von [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) zurückgegebene URL muss dem endgültigen Bereitstellungsort der von [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) geschriebenen Datei entsprechen. In Android‑Anwendungen verwenden Sie app‑spezifischen Speicher, ein Cache‑Verzeichnis oder ein über das Storage Access Framework erhaltenes Verzeichnis, entsprechend Ihrem Veröffentlichungs‑Workflow. In Server‑Anwendungen verwenden Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder einen Objekt‑Speicher‑Präfix, um das Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzelne Datei sein muss, z. B. ein E‑Mail‑Anhang, eine Offline‑Vorschau oder ein Dokument, das ohne zugehörigen Asset‑Ordner verschoben wird. Verknüpfte Ressourcen sind besser geeignet, wenn das HTML von einer Webanwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder extern speichern und andere Ressourcen eingebettet lassen?**

Ja. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilinkembedcontroller/) geben Sie `Link` von [LinkEmbedDecision](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/linkembeddecision/) nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und geben `Embed` für alle anderen zurück.

**Warum unterscheidet sich die exportierte Bild‑Erweiterung von der der Quell‑Präsentation?**

Aspose.Slides kann Rasterbilder während des HTML‑Exports neu kodieren, um die Größe zu reduzieren oder die Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach dem gerenderten Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, wenn ich die HTML‑Datei verschiebe?**

Relative URLs funktionieren nur, wenn dieselbe relative Ordnerstruktur erhalten bleibt. Verweist das HTML auf `assets/resource-1.png`, muss der Ordner `assets` neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Kann ich Ressourcen auf öffentlichen externen Speicher auf Android schreiben?**

Ja, sofern Ihre Anwendung über ein gültiges Ziel und ein Berechtigungsmodell für die jeweilige Android‑Version verfügt. Für generiertes HTML, das nur von Ihrer App verwendet wird, sind app‑spezifische Dateien oder Cache‑Verzeichnisse in der Regel einfacher. Für für den Benutzer sichtbare Ausgaben verwenden Sie einen vom Nutzer ausgewählten Speicherort oder einen anderen Speicheransatz, der zu Ihrer App passt.

**Sollten Server‑Anwendungen denselben Ausgabepfad wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungs‑Job ein eindeutiges Ausgabeverzeichnis oder Speicher‑Präfix. Dadurch werden Dateinamenkonflikte vermieden und verhindert, dass ein Export Ressourcen eines anderen Exports überschreibt.