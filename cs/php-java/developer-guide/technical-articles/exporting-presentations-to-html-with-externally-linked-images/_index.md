---
title: Export prezentací do HTML s externě propojenými obrázky
type: docs
weight: 100
url: /cs/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export prezentace
- export snímek
- export PPT
- export PPTX
- export ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- propojený obrázek
- externě propojený obrázek
- propojený zdroj
- externí zdroj
- PHP
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v PHP přes Java pomocí Aspose.Slides s obrázky a dalšími zdroji uloženými jako externě propojené soubory."
---
## **Přehled**

Ve výchozím nastavení exportuje Aspose.Slides prezentaci do samostatného HTML souboru. Obrázky a ostatní zdroje jsou zapisovány přímo do HTML, obvykle jako Base64 data. To je výhodné, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro web, CMS nebo server‑side konverzní pipeline.

Použijte externě propojené zdroje, když chcete:

- snížit velikost HTML dokumentu;
- kešovat obrázky, fonty, audio nebo video samostatně v prohlížeči či CDN;
- po exportu zkontrolovat, nahradit, komprimovat nebo následně zpracovat vygenerované zdroje;
- zachovat výstupní strukturu blíže tomu, co očekává webová aplikace.

Obecný postup konverze do HTML najdete v [Convert PowerPoint Presentations to HTML](/slides/cs/php-java/convert-powerpoint-to-html/). Tento článek se soustředí na část exportu, která se týká propojování zdrojů.

## **Jak funguje export propojených zdrojů**

[HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/) může použít vlastní kontroler pro propojování/vkládání, když Aspose.Slides exportuje prezentaci do HTML. V PHP přes Java se tento scénář obvykle implementuje pomocí malé Java pomocné třídy. Zkompilujte tuto třídu, přidejte ji do classpath PHP Java Bridge a vytvořte její instanci v PHP pomocí `new Java(...)`.

Pomocná třída rozhoduje, zdroj po zdroji, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz. Potřebuje tři metody zpětného volání:

- `ExternalResourceController.getObjectStoringLocation` rozhoduje, zda má být zdroj propojen nebo vložen.
- `ExternalResourceController.getUrl` vrací URL, která bude zapsána do vygenerovaného HTML nebo do jiného propojeného zdroje.
- `ExternalResourceController.saveExternal` zapíše data propojeného zdroje na disk nebo do jiného úložiště.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory zdrojů do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tyto URL vyhodnocuje relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejné složce `assets` používá `resource-4.jpg`.

## **Vytvoření Java pomocné třídy**

Vytvořte Java třídu např. `com.example.slides.ExternalResourceController`, zkompilujte ji s Aspose.Slides for Java na classpath a zpřístupněte zkompilovanou třídu nebo JAR PHP Java Bridge.

Níže uvedená pomocná třída propojuje běžné obrázky, fonty, audio, video a CSS zdroje, pokud Aspose.Slides poskytne nebo dokáže odhadnout bezpečnou příponu souboru. Zdroje, které nejsou rozpoznány, zůstávají vložené.

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

## **Export HTML s propojenými zdroji**

Následující PHP kód vytvoří výstupní adresář, uloží tam HTML soubor a uloží propojené zdroje do podsložky `assets`. Kombinuje [HtmlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slideimageformat/) a [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/) pro export.

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

Po exportu má výstupní složka tuto strukturu:

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

Přesné soubory závisejí na obsahu prezentace a nastaveních exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný kodek obrázku než ten použitý ve zdrojové prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Volba URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřeno z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden propojený zdroj odkazuje na jiný propojený zdroj, ukázka používá parametr `referrer` v metodě `ExternalResourceController.getUrl` a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba ve složce `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jinou předponu URL, pokud jsou soubory nasazeny jinde:

- Použijte `assets/`, když je složka s assety vedle HTML souboru.
- Použijte `../assets/`, když je složka s assety o úroveň výš než HTML soubor.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou `ExternalResourceController.getUrl` musí odpovídat konečnému nasazenému umístění souboru, který zapíše `ExternalResourceController.saveExternal`. V serverových aplikacích použijte unikátní výstupní adresář nebo prefix v objektovém úložišti pro každou konverzní úlohu, aby nedošlo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit zdroje**

Vložené Base64 HTML je stále užitečné, když výstup musí být jeden soubor, například e‑mailová příloha, offline náhled nebo dokument, který bude přesunut bez podpůrné složky s assety. Propojené zdroje jsou vhodnější, když bude HTML podáváno webovou aplikací, uložené v CMS, optimalizované build pipeline nebo kešované prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externalizovat pouze obrázky a ostatní zdroje ponechat vložené?**

Ano. V `ExternalResourceController.getObjectStoringLocation` vraťte hodnotu `Link` z [LinkEmbedDecision](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linkembeddecision/) jen pro typy obsahu, které chcete uložit jako samostatné soubory, a pro vše ostatní vraťte hodnotu `Embed`.

**Proč se přípona exportovaného obrázku liší od originální prezentace?**

Aspose.Slides může během HTML exportu přeenkódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledku renderování.

**Fungují relativní URL po přesunu HTML souboru?**

Relativní URL fungují jen tehdy, když je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Měly by serverové aplikace znovu používat stejný výstupní adresář?**

Ne. Použijte unikátní výstupní adresář nebo prefix úložiště pro každou konverzní úlohu. Tím se zabrání kolizím názvů souborů a přepsání zdrojů vytvořených jiným exportem.