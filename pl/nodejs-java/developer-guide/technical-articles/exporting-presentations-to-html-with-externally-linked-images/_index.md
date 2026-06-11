---
title: Eksportowanie prezentacji do HTML z zewnętrznie powiązanymi obrazami
type: docs
weight: 100
url: /pl/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do HTML w JavaScript przy użyciu Aspose.Slides dla Node.js poprzez Javę, z obrazami i innymi zasobami zapisywanymi jako zewnętrznie powiązane pliki."
---
## **Przegląd**

Domyślnie Aspose.Slides eksportuje prezentację do samodzielnego pliku HTML. Obrazy i inne zasoby są zapisywane bezpośrednio w HTML, zazwyczaj jako dane Base64. Jest to wygodne, gdy potrzebny jest jeden przenośny plik, ale nie zawsze jest to najlepszy format dla strony internetowej, systemu CMS ani potoku konwersji po stronie serwera.

Używaj zewnętrznie linkowanych zasobów, gdy chcesz:
- zredukować rozmiar dokumentu HTML;
- przechowywać w pamięci podręcznej obrazy, czcionki, audio lub wideo osobno w przeglądarce lub CDN;
- przeglądać, zamieniać, kompresować lub przetwarzać po generacji wygenerowane zasoby po eksporcie;
- utrzymać strukturę wyjściową bliższą temu, czego oczekuje aplikacja internetowa.

Aby zapoznać się z ogólnym przepływem konwersji HTML, zobacz [Konwertuj prezentacje PowerPoint do HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/). Ten artykuł koncentruje się na części eksportu związanej z linkowaniem zasobów.

## **Jak działa eksport z linkowanymi zasobami**

Proxy Javy dla [ILinkEmbedController](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) pozwala Twojej aplikacji decydować, zasób po zasobie, czy eksporter osadza dane w HTML, czy zapisuje je zewnętrznie i tworzy odnośnik.

Kontroler ma trzy metody:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) decyduje, czy zasób powinien być linkowany czy osadzony.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zwraca URL, który zostanie zapisany w wygenerowanym HTML lub w innym linkowanym zasobie.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zapisuje dane linkowanego zasobu na dysk lub do innego celu przechowywania.

Ścieżka systemu plików i URL przeglądarki to odrębne zagadnienia. Na przykład, poniższy przykład zapisuje pliki zasobów w `html-output/assets` na dysku, podczas gdy HTML zawiera względne URL‑e takie jak `assets/resource-1.svg`. Przeglądarka rozwiązuje te URL‑e względem pliku, w którym znajduje się odnośnik. Dlatego odnośnik z `presentation.html` do pliku SVG używa `assets/resource-1.svg`, a odnośnik z tego pliku SVG do obrazu zapisanego w tym samym folderze `assets` używa `resource-4.jpg`.

## **Eksportuj HTML z linkowanymi zasobami**

Poniższy przykład JavaScript tworzy katalog wyjściowy, zapisuje w nim plik HTML i przechowuje linkowane zasoby w podkatalogu `assets`. Kontroler linkuje typowe obrazy, czcionki, audio, wideo i zasoby CSS, gdy Aspose.Slides udostępnia lub może wywnioskować bezpieczne rozszerzenie pliku. Zasoby, które nie zostaną rozpoznane, pozostają osadzone.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
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

Dokładne pliki zależą od zawartości prezentacji i opcji eksportu. Na przykład obrazy rastrowe są zwykle eksportowane jako JPEG lub PNG. Aspose.Slides może wybrać inny codec obrazu niż używany w oryginalnej prezentacji, gdy daje to mniejszy lub lepszy plik. Obrazy z przezroczystością są eksportowane jako PNG.

## **Wybór URL‑ów do wdrożenia**

Przykład używa względnego prefiksu URL: `assets/`. Jeśli `presentation.html` zostanie otwarty z `html-output/presentation.html`, przeglądarka załaduje `html-output/assets/resource-1.svg`.

Gdy jeden linkowany zasób odwołuje się do innego linkowanego zasobu, przykład używa parametru `referrer` w [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) i zwraca tylko nazwę pliku. Na przykład, jeśli `resource-1.svg` i `resource-4.jpg` znajdują się w folderze `assets`, plik SVG powinien odwoływać się do `resource-4.jpg`, a nie do `assets/resource-4.jpg`.

Użyj innego prefiksu URL, gdy pliki są wdrażane w innym miejscu:
- Użyj `assets/`, gdy katalog zasobów znajduje się obok pliku HTML.
- Użyj `../assets/`, gdy katalog zasobów jest o jeden poziom wyżej niż plik HTML.
- Użyj `https://cdn.example.com/presentations/job-123/assets/`, gdy pliki są przesyłane do CDN lub serwera plików statycznych.

URL zwrócony przez [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) musi odpowiadać ostatecznej lokalizacji wdrożenia pliku zapisanego przez [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/). W aplikacjach serwerowych używaj unikalnego katalogu wyjściowego lub prefiksu przechowywania obiektów dla każdego zadania konwersji, aby uniknąć nadpisywania plików z innego eksportu.

## **Kiedy zamiast tego osadzać**

Osadzony HTML w formacie Base64 jest nadal przydatny, gdy wyjście musi być jednym plikiem, np. załącznikiem e‑mail, podglądem offline lub dokumentem, który będzie przenoszony bez folderu zasobów. Linkowane zasoby lepiej sprawdzają się, gdy HTML będzie serwowany przez aplikację internetową, przechowywany w systemie CMS, optymalizowany w pipeline budowania lub buforowany przez przeglądarki niezależnie od HTML.

## **FAQ**

**Czy mogę zewnętrznie wyodrębnić tylko obrazy i pozostawić pozostałe zasoby osadzone?**

Tak. W [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinkembedcontroller/) zwróć `LinkEmbedDecision.Link` tylko dla typów treści, które chcesz zapisać jako osobne pliki, oraz zwróć `LinkEmbedDecision.Embed` dla wszystkiego innego.

**Dlaczego rozszerzenie wyeksportowanego obrazu różni się od prezentacji źródłowej?**

Aspose.Slides może ponownie kodować obrazy rastrowe podczas eksportu HTML, aby poprawić rozmiar lub kompatybilność przeglądarki. Na przykład, obraz z pliku źródłowego może zostać zapisany jako JPEG lub PNG w zależności od uzyskanego rezultatu.

**Czy względne URL‑e działają po przeniesieniu pliku HTML?**

Względne URL‑e działają tylko wtedy, gdy zachowana jest ta sama względna struktura folderów. Jeśli HTML odwołuje się do `assets/resource-1.png`, folder `assets` musi pozostać obok pliku HTML, chyba że wygenerujesz inny prefiks URL.

**Czy aplikacje serwerowe powinny ponownie używać tego samego folderu wyjściowego?**

Nie. Używaj unikalnego katalogu wyjściowego lub prefiksu przechowywania dla każdego zadania konwersji. Zapobiega to kolizjom nazw plików i uniemożliwia nadpisywanie zasobów wygenerowanych przez inny eksport.