---
title: Präsentationen mit extern verlinkten Bildern nach HTML exportieren
type: docs
weight: 100
url: /de/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- verlinktes Bild
- extern verlinktes Bild
- verlinkte Ressource
- externe Ressource
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint und OpenDocument Präsentationen nach HTML in PHP über Java mit Aspose.Slides, wobei Bilder und andere Ressourcen als extern verlinkte Dateien gespeichert werden."
---
## **Übersicht**

Standardmäßig exportiert Aspose.Slides eine Präsentation in eine eigenständige HTML-Datei. Bilder und andere Ressourcen werden direkt in das HTML geschrieben, meist als Base64-Daten. Das ist praktisch, wenn Sie eine einzige portable Datei benötigen, aber es ist nicht immer das beste Format für eine Website, ein CMS oder eine serverseitige Konvertierungspipeline.

Verwenden Sie extern verlinkte Ressourcen, wenn Sie:
- die Größe des HTML-Dokuments reduzieren;
- Bilder, Schriftarten, Audio oder Video separat in einem Browser oder CDN zwischenspeichern;
- generierte Ressourcen nach dem Export untersuchen, ersetzen, komprimieren oder nachbearbeiten;
- die Ausgabestruktur näher an dem halten, was eine Webanwendung erwartet.

Für den allgemeinen HTML-Konvertierungsablauf siehe [Convert PowerPoint Presentations to HTML](/slides/de/php-java/convert-powerpoint-to-html/). Dieser Artikel konzentriert sich auf den Ressourcenverlinkungs‑Teil des Exports.

## **Wie der Export verknüpfter Ressourcen funktioniert**

[HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) kann einen benutzerdefinierten Link/Einbetten‑Controller verwenden, wenn Aspose.Slides eine Präsentation nach HTML exportiert. In PHP via Java wird dieses Szenario normalerweise mit einer kleinen Java‑Hilfsklasse implementiert. Kompilieren Sie diese Hilfsklasse, fügen Sie sie dem Klassenpfad der PHP‑Java‑Bridge hinzu und instanziieren Sie sie aus PHP mit `new Java(...)`.

Die Hilfsklasse entscheidet ressourcenweise, ob der Exporter die Daten in das HTML einbettet oder sie extern speichert und einen Link schreibt. Sie benötigt drei Callback‑Methoden:
- `ExternalResourceController.getObjectStoringLocation` entscheidet, ob eine Ressource verlinkt oder eingebettet werden soll.
- `ExternalResourceController.getUrl` gibt die URL zurück, die in das erzeugte HTML oder in eine andere verlinkte Ressource geschrieben wird.
- `ExternalResourceController.saveExternal` schreibt die verlinkten Resourcendaten auf die Festplatte oder an ein anderes Speicherziel.

Der Dateisystempfad und die Browser‑URL sind separate Anliegen. Zum Beispiel schreibt das untenstehende Beispiel Ressourcendateien nach `html-output/assets` auf die Festplatte, während das HTML relative URLs wie `assets/resource-1.svg` enthält. Ein Browser löst diese URLs relativ zu der Datei auf, die den Link enthält. Daher verwendet ein Link von `presentation.html` zu einer SVG‑Datei `assets/resource-1.svg`, während ein Link von dieser SVG‑Datei zu einem im selben `assets`‑Ordner gespeicherten Bild `resource-4.jpg` verwendet.

## **Erstellen Sie die Java-Hilfsklasse**

Erstellen Sie eine Java‑Klasse wie `com.example.slides.ExternalResourceController`, kompilieren Sie sie mit Aspose.Slides für Java im Klassenpfad und stellen Sie die kompilierte Klasse oder das JAR der PHP‑Java‑Bridge zur Verfügung.

Die untenstehende Hilfsklasse verlinkt gängige Bild-, Schrift‑, Audio‑, Video‑ und CSS‑Ressourcen, wenn Aspose.Slides eine sichere Dateierweiterung bereitstellt oder ableiten kann. Nicht erkannte Ressourcen bleiben eingebettet.

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

## **Exportieren Sie HTML mit verknüpften Ressourcen**

Der folgende PHP‑Code erstellt ein Ausgabeverzeichnis, speichert die HTML‑Datei dort und legt verknüpfte Ressourcen in einem Unterverzeichnis `assets` ab. Er kombiniert [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideimageformat/) und [SaveFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/) für den Export.

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

Die genauen Dateien hängen vom Inhalt der Präsentation und den Exportoptionen ab. Rasterbilder werden beispielsweise häufig als JPEG oder PNG exportiert. Aspose.Slides kann einen anderen Bild‑Codec wählen als den in der Quellpräsentation verwendeten, wenn dies zu einer kleineren oder besser geeigneten Datei führt. Bilder mit Transparenz werden als PNG exportiert.

## **Auswahl von URLs für die Bereitstellung**

Das Beispiel verwendet ein relatives URL‑Präfix: `assets/`. Wenn `presentation.html` aus `html-output/presentation.html` geöffnet wird, lädt der Browser `html-output/assets/resource-1.svg`.

Wenn eine verknüpfte Ressource auf eine andere verknüpfte Ressource verweist, verwendet das Beispiel den Parameter `referrer` in `ExternalResourceController.getUrl` und gibt nur den Dateinamen zurück. Beispielsweise sollte die SVG‑Datei, wenn `resource-1.svg` und `resource-4.jpg` beide im Ordner `assets` liegen, auf `resource-4.jpg` verweisen und nicht auf `assets/resource-4.jpg`.

Verwenden Sie ein anderes URL‑Präfix, wenn die Dateien an anderer Stelle bereitgestellt werden:
- Verwenden Sie `assets/`, wenn das Asset‑Verzeichnis neben der HTML‑Datei liegt.
- Verwenden Sie `../assets/`, wenn das Asset‑Verzeichnis eine Ebene über der HTML‑Datei liegt.
- Verwenden Sie `https://cdn.example.com/presentations/job-123/assets/`, wenn die Dateien zu einem CDN oder statischen Dateiserver hochgeladen werden.

Die von `ExternalResourceController.getUrl` zurückgegebene URL muss mit dem endgültigen Bereitstellungsort der von `ExternalResourceController.saveExternal` geschriebenen Datei übereinstimmen. Verwenden Sie in Server‑Anwendungen für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder ein Objekt‑Speicher‑Präfix, um das Überschreiben von Dateien aus einem anderen Export zu vermeiden.

## **Wann stattdessen einbetten**

Eingebettetes Base64‑HTML ist weiterhin nützlich, wenn die Ausgabe eine einzige Datei sein muss, etwa als E‑Mail‑Anhang, Offline‑Vorschau oder Dokument, das ohne unterstützenden Asset‑Ordner verschoben wird. Verknüpfte Ressourcen passen besser, wenn das HTML von einer Web‑Anwendung bereitgestellt, in einem CMS gespeichert, durch eine Build‑Pipeline optimiert oder von Browsern unabhängig vom HTML zwischengespeichert wird.

## **FAQ**

**Kann ich nur Bilder externalisieren und andere Ressourcen eingebettet lassen?**

Ja. In `ExternalResourceController.getObjectStoringLocation` geben Sie den Wert `Link` aus [LinkEmbedDecision](https://reference.aspose.com/slides/de/php-java/aspose.slides/linkembeddecision/) nur für die Inhaltstypen zurück, die Sie als separate Dateien speichern möchten, und geben den Wert `Embed` für alles andere zurück.

**Warum unterscheidet sich die exportierte Bilddateierweiterung von der der Quellpräsentation?**

Aspose.Slides kann Rasterbilder während des HTML‑Exports neu kodieren, um die Größe zu reduzieren oder die Browser‑Kompatibilität zu verbessern. Beispielsweise kann ein Bild aus der Quelldatei je nach Ergebnis als JPEG oder PNG geschrieben werden.

**Funktionieren relative URLs, nachdem ich die HTML‑Datei verschoben habe?**

Relative URLs funktionieren nur, wenn die gleiche relative Ordnerstruktur beibehalten wird. Wenn das HTML `assets/resource-1.png` referenziert, muss der Ordner `assets` neben der HTML‑Datei bleiben, es sei denn, Sie erzeugen ein anderes URL‑Präfix.

**Sollten Server‑Anwendungen denselben Ausgabordner wiederverwenden?**

Nein. Verwenden Sie für jeden Konvertierungsauftrag ein eindeutiges Ausgabeverzeichnis oder Speicher‑Präfix. Dies verhindert Namenskollisionen und verhindert, dass ein Export Ressourcen eines anderen Exports überschreibt.