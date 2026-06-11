---
title: Eksportowanie prezentacji do HTML z zewnętrznie powiązanymi obrazami
type: docs
weight: 100
url: /pl/java/exporting-presentations-to-html-with-externally-linked-images/
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
- powiązany obraz
- zewnętrznie powiązany obraz
- powiązany zasób
- zewnętrzny zasób
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w języku Java przy użyciu Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie powiązane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zazwyczaj jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla witryny internetowej, systemu CMS ani potoku konwersji po stronie serwera.

Używaj zewnętrznie powiązanych zasobów, gdy chcesz:
- zmniejszyć rozmiar dokumentu HTML;
- buforować obrazy, czcionki, audio lub wideo osobno w przeglądarce lub CDN;
- przeglądać, zastępować, kompresować lub przetwarzać dalej wygenerowane zasoby po eksporcie;
- utrzymać strukturę wyjściową bliższą temu, czego oczekuje aplikacja webowa.

Ogólny przepływ konwersji HTML znajdziesz w [Convert PowerPoint Presentations to HTML](/slides/pl/java/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu związanej z linkowaniem zasobów.

## **Jak działa eksport zasobów z linkami**

[ILinkEmbedController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) pozwala aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i tworzy odnośnik.

Interfejs posiada trzy metody:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) decyduje, czy zasób powinien być połączony (linkowany) czy osadzony.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zwraca URL, który zostanie zapisany w wygenerowanym HTML lub innym połączonym zasobie.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zapisuje dane połączonego zasobu na dysk lub inny docelowy magazyn.

Ścieżka systemu plików i URL przeglądarki to odrębne kwestie. Na przykład poniższy przykład zapisuje pliki zasobów w `html-output/assets` na dysku, podczas gdy HTML zawiera względne URL‑e takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te URL‑e względem pliku, który zawiera odnośnik. Dlatego odnośnik z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, natomiast odnośnik z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Eksport HTML z zasobami połączonymi**

Poniższy przykład w języku Java tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje połączone zasoby w podkatalogu `assets`. Kontroler łączy typowe zasoby obrazów, czcionek, audio, wideo i CSS, gdy Aspose.Slides dostarcza lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby, które nie są rozpoznane, pozostają osadzone.

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

Dokładne pliki zależą od treści prezentacji i opcji eksportu. Na przykład obrazy rastryczne są zazwyczaj eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż używany w prezentacji źródłowej, jeśli daje to mniejszy lub bardziej odpowiedni plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór URL‑ów do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` jest otwierany z `html-output/presentation.html`, przeglądarka ładuje `html-output/assets/resource-1.svg`.

Gdy jeden połączony zasób odwołuje się do innego połączonego zasobu, przykład używa parametru `referrer` w [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrażane w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów znajduje się o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera statycznych plików.

URL zwrócony przez [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) musi odpowiadać ostatecznemu miejscu wdrożenia pliku zapisanego przez [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/). W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w magazynie obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML w formacie Base64 jest nadal przydatny, gdy wyjście musi być jednym plikiem, np. załącznikiem e‑mail, podglądem offline lub dokumentem, który będzie przenoszony bez folderu zasobów. Zasoby linkowane lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację webową, przechowywany w systemie CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę wyodrębnić tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. W metodzie [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zwróć `LinkEmbedDecision.Link` tylko dla typów treści, które chcesz zapisać jako osobne pliki, oraz zwróć `LinkEmbedDecision.Embed` dla pozostałych.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie zakodować obrazy rastryczne podczas eksportu HTML, aby poprawić rozmiar lub kompatybilność z przeglądarką. Na przykład obraz z pliku źródłowego może być zapisany jako JPEG lub PNG w zależności od uzyskanego wyniku.

**Czy względne URL‑e działają po przeniesieniu pliku HTML?**

Względne URL‑e działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu pamięci dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia nadpisanie zasobów wygenerowanych przez inny eksport.