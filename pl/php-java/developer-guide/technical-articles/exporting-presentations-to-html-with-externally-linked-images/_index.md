---
title: Eksportowanie prezentacji do HTML z zewnętrznie połączonymi obrazami
type: docs
weight: 100
url: /pl/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- eksport slajdu
- eksport PPT
- eksport PPTX
- eksport ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- połączony obraz
- zewnętrznie połączony obraz
- połączony zasób
- zewnętrzny zasób
- PHP
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w PHP przy użyciu Java oraz Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie połączone pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zazwyczaj jako dane Base64. To wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla witryny, CMS‑a lub potoku konwersji po stronie serwera.

Używaj zewnętrznie połączonych zasobów, gdy chcesz:
- zredukować rozmiar dokumentu HTML;
- buforować obrazy, czcionki, dźwięki lub wideo osobno w przeglądarce lub CDN;
- przeglądać, podmieniać, kompresować lub przetwarzać po wyeksportowaniu wygenerowane zasoby;
- zachować strukturę wyjścia bliższą temu, czego oczekuje aplikacja webowa.

Ogólny przebieg konwersji HTML znajdziesz w [Konwertuj prezentacje PowerPoint do HTML](/slides/pl/php-java/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu polegającej na łączeniu zasobów.

## **Jak działa eksport z powiązanymi zasobami**

[HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) może używać niestandardowego kontrolera link/ embed, gdy Aspose.Slides eksportuje prezentację do HTML. W PHP poprzez Java scenariusz ten jest zazwyczaj realizowany małą klasą pomocniczą w Javie. Skompiluj tę pomocnicę, dodaj ją do ścieżki klas PHP Java Bridge i utwórz jej instancję w PHP za pomocą `new Java(...)`.

Klasa pomocnicza decyduje, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i zapisuje odnośnik. Potrzebuje trzech metod zwrotnych:
- `ExternalResourceController.getObjectStoringLocation` decyduje, czy zasób ma być połączony, czy osadzony.
- `ExternalResourceController.getUrl` zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym połączonym zasobie.
- `ExternalResourceController.saveExternal` zapisuje dane połączonego zasobu na dysk lub do innego docelowego miejsca przechowywania.

Ścieżka systemu plików i URL przeglądarki to odrębne kwestie. Na przykład poniższy przykład zapisuje pliki zasobów w katalogu `html-output/assets` na dysku, podczas gdy HTML zawiera względne URL‑e, takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te URL‑e względem pliku, w którym znajduje się odnośnik. Dlatego odnośnik z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, a odnośnik z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Utwórz klasę pomocniczą w Javie**

Utwórz klasę Javy, np. `com.example.slides.ExternalResourceController`, skompiluj ją z Aspose.Slides for Java na ścieżce klas i udostępnij skompilowaną klasę lub plik JAR w PHP Java Bridge.

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

## **Eksport HTML z powiązanymi zasobami**

Poniższy kod PHP tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje połączone zasoby w podkatalogu `assets`. Do eksportu łączy [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideimageformat/) oraz [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/).

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

Po eksporcie folder wyjściowy ma następującą strukturę:

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

Dokładne pliki zależą od zawartości prezentacji i wybranych opcji eksportu. Na przykład obrazy rastrowe są zwykle eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż ten używany w źródłowej prezentacji, jeśli daje to mniejszy lub bardziej odpowiedni plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór adresów URL dla wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden połączony zasób odwołuje się do innego połączonego zasobu, przykład używa parametru `referrer` w `ExternalResourceController.getUrl` i zwraca jedynie nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrożone w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów jest o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera plików statycznych.

Adres URL zwrócony przez `ExternalResourceController.getUrl` musi odpowiadać ostatecznej lokalizacji wdrożonego pliku zapisanego przez `ExternalResourceController.saveExternal`. W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w przechowywaniu obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML z Base64 wciąż jest przydatny, gdy wynik musi być jednym plikiem, np. załącznikiem e‑mail, podglądem offline lub dokumentem, który będzie przenoszony bez folderu zasobów. Połączone zasoby lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację webową, przechowywany w CMS, optymalizowany w procesie budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę wyodrębnić tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. W metodzie `ExternalResourceController.getObjectStoringLocation` zwróć wartość `Link` z [LinkEmbedDecision](https://reference.aspose.com/slides/pl/php-java/aspose.slides/linkembeddecision/) tylko dla typów zawartości, które chcesz zapisać jako osobne pliki, a dla pozostałych zwróć wartość `Embed`.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od tego w źródłowej prezentacji?**

Aspose.Slides może ponownie zakodować obrazy rastrowe podczas eksportu do HTML, aby zmniejszyć rozmiar lub poprawić kompatybilność z przeglądarką. Na przykład obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od uzyskanego wyniku renderowania.

**Czy względne adresy URL działają po przeniesieniu pliku HTML?**

Względne adresy URL działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu w przechowywaniu dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia nadpisywanie zasobów wygenerowanych przez inny eksport.