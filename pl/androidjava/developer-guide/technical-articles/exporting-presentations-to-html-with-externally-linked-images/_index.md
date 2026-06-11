---
title: Eksportowanie prezentacji do HTML z zewnętrznie połączonymi obrazami
type: docs
weight: 100
url: /pl/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w systemie Android przy użyciu języka Java i biblioteki Aspose.Slides, zapisując obrazy i inne zasoby jako zewnętrznie połączone pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zazwyczaj jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla podglądu w przeglądarce, systemu CMS ani dla serwerowego potoku konwersji, który później publikuje wynik.

Używaj zewnętrznie połączonych zasobów, gdy chcesz:

- zmniejszyć rozmiar dokumentu HTML;
- odrębnie buforować obrazy, czcionki, dźwięki lub wideo w przeglądarce lub CDN;
- przeglądać, wymieniać, kompresować lub poddawać dalszej obróbce wygenerowane zasoby po eksporcie;
- zachować strukturę wyjściową bliższą temu, czego oczekuje aplikacja webowa.

Aby zapoznać się z ogólnym przepływem konwersji HTML, zobacz [Konwertuj prezentacje PowerPoint do HTML](/slides/pl/androidjava/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu związanej z łączeniem zasobów.

## **Jak działa eksport zasobów z linkami**

[ILinkEmbedController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) pozwala aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i tworzy odnośnik.

Interfejs posiada trzy metody:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) decyduje, czy zasób powinien być połączony (linkowany) czy osadzony.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym połączonym zasobie.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) zapisuje dane połączonego zasobu na dysk lub do innego miejsca przechowywania.

Ścieżka w systemie plików i URL w przeglądarce to odrębne kwestie. Na przykład poniższy przykład zapisuje pliki zasobów do `html-output/assets` w pamięci aplikacji, podczas gdy HTML zawiera względne adresy URL, takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te adresy URL względem pliku zawierającego odnośnik. Dlatego odnośnik z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, a odnośnik z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Eksportuj HTML z połączonymi zasobami**

Poniższy przykład w języku Android Java tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje połączone zasoby w podkatalogu `assets`. Przekaż katalog należący do aplikacji, np. `context.getFilesDir()`, jako `applicationFilesDirectory`. Kod unika API `java.nio.file`, dzięki czemu pozostaje kompatybilny z Android `minSdk` 19.

Kontroler łączy typowe obrazy, czcionki, dźwięki, wideo oraz zasoby CSS, gdy Aspose.Slides dostarcza lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby, które nie zostaną rozpoznane, pozostają osadzone.

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

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zazwyczaj eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny kodek obrazu niż użyty w pierwotnej prezentacji, jeśli daje to mniejszy lub bardziej odpowiedni plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór adresów URL do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden połączony zasób odwołuje się do innego połączonego zasobu, przykład używa parametru `referrer` w [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrażane w innym miejscu:

- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów znajduje się o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera plików statycznych.

URL zwracany przez [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/) musi odpowiadać ostatecznej lokalizacji wdrożonego pliku zapisanego przez [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/). W aplikacjach Android używaj pamięci specyficznej dla aplikacji, katalogu cache lub katalogu uzyskanego za pośrednictwem Storage Access Framework, zgodnie z przepływem publikacji. W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu w magazynie obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML w formacie Base64 nadal jest przydatny, gdy wynik musi być jednym plikiem, takim jak załącznik e‑mail, podgląd offline lub dokument, który będzie przenoszony bez folderu zasobów. Połączone zasoby lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację webową, przechowywany w systemie CMS, optymalizowany w potoku budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę zewnętrznie udostępniać tylko obrazy i pozostawić inne zasoby osadzone?**

Tak. W [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinkembedcontroller/), zwróć `Link` z [LinkEmbedDecision](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linkembeddecision/) tylko dla typów treści, które chcesz zapisać jako osobne pliki, oraz zwróć `Embed` dla wszystkiego innego.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie zakodować obrazy rastrowe podczas eksportu HTML, aby poprawić rozmiar lub kompatybilność z przeglądarką. Na przykład obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od uzyskanego efektu renderowania.

**Czy względne adresy URL działają po przeniesieniu pliku HTML?**

Względne adresy URL działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy mogę zapisywać zasoby w publicznej pamięci zewnętrznej na Androidzie?**

Tak, jeśli aplikacja ma prawidłowe miejsce docelowe i model uprawnień dla docelowej wersji Androida. Dla generowanego HTML używanego wyłącznie przez aplikację zazwyczaj prostsze są pliki specyficzne dla aplikacji lub katalogi cache. Dla widocznego dla użytkownika wyniku użyj lokalizacji wybranej przez użytkownika lub innego podejścia do przechowywania, które pasuje do Twojej aplikacji.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu pamięci dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia nadpisywanie zasobów wygenerowanych przez inny eksport.