---
title: Prezentációk exportálása HTML-be külsőleg hivatkozott képekkel
type: docs
weight: 100
url: /hu/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- dia exportálása
- PPT exportálása
- PPTX exportálása
- ODP exportálása
- PowerPoint HTML-re
- OpenDocument HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- ODP HTML-re
- hivatkozott kép
- külsőleg hivatkozott kép
- hivatkozott erőforrás
- külső erőforrás
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-be PHP-ben Java-n keresztül az Aspose.Slides használatával, a képekkel és egyéb erőforrásokkal, amelyeket külső hivatkozott fájlokként ment."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML-fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be kerülnek, általában Base64-adatként. Ez akkor kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy webhelyhez, egy CMS-hez vagy egy szerveroldali konverziós csővezetékhez.

Használd a külsőleg hivatkozott erőforrásokat, ha:

- csökkenteni a HTML-dokumentum méretét;
- a képeket, betűtípusokat, hangot vagy videót külön cache-elni egy böngészőben vagy CDN-ben;
- a generált erőforrásokat exportálás után ellenőrizni, cserélni, tömöríteni vagy utófeldolgozni;
- az kimeneti struktúrát közelebb tartani ahhoz, amit egy webalkalmazás elvár.

Az általános HTML-konverzió munkafolyamatért lásd a [PowerPoint-prezentációk HTML‑re konvertálása](/slides/hu/php-java/convert-powerpoint-to-html/) oldalt. Ez a cikk az export erőforrás‑összekapcsolási részére összpontosít.

## **A hivatkozott erőforrások exportálásának működése**

[HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) saját hivatkozás/beágyazás vezérlőt használhat, amikor az Aspose.Slides egy prezentációt HTML‑re exportál. PHP‑ben Java‑on keresztül ez a forgatókönyv általában egy kis Java segédosztállyal valósul meg. Fordítsd le azt a segédosztályt, add hozzá a PHP Java Bridge osztályúthoz, és példányosítsd PHP‑ből a `new Java(...)` segítségével.

A segédosztály erőforrásonként eldönti, hogy az exportáló beágyazza-e az adatot a HTML-be, vagy külsőleg elmenti és hivatkozást ír. Három visszahívási metódusra van szüksége:

- `ExternalResourceController.getObjectStoringLocation` eldönti, hogy egy erőforrás hivatkozott vagy beágyazott legyen.
- `ExternalResourceController.getUrl` visszaadja a URL‑t, amely a generált HTML‑be vagy egy másik hivatkozott erőforrásba kerül.
- `ExternalResourceController.saveExternal` az összekapcsolt erőforrás adatát leírja a lemezre vagy egy másik tárolóhelyre.

A fájlrendszer‑útvonal és a böngésző‑URL külön kérdés. Például az alábbi minta az erőforrás‑fájlokat a lemezen a `html-output/assets` könyvtárba írja, míg a HTML relatív URL‑eket tartalmaz, például `assets/resource-1.svg`. A böngésző ezeket az URL‑eket a hivatkozást tartalmazó fájlhoz képest oldja fel. Így egy `presentation.html`‑ről egy SVG‑fájlra mutató hivatkozás `assets/resource-1.svg`‑t használ, míg az SVG‑fájlból ugyanabban a `assets` mappában elmentett képre mutató hivatkozás `resource-4.jpg`.

## **Java segédosztály létrehozása**

Hozz létre egy Java osztályt, például `com.example.slides.ExternalResourceController` néven, fordítsd le az Aspose.Slides for Java‑val az osztályúton, és tedd a lefordított osztályt vagy JAR‑t elérhetővé a PHP Java Bridge számára.

Az alábbi segéd az általános képeket, betűtípusokat, hang-, video‑ és CSS‑erőforrásokat hivatkozza, ha az Aspose.Slides biztosít vagy le tud vonni egy biztonságos fájlkiterjesztést. A nem felismert erőforrások beágyazva maradnak.

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

## **HTML exportálása hivatkozott erőforrásokkal**

A következő PHP kód létrehozza a kimeneti könyvtárat, elmenti oda a HTML‑fájlt, és a hivatkozott erőforrásokat egy `assets` alkönyvtárba helyezi. Az exportáláshoz kombinálja a [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/), a [SVGOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/), a [SlideImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideimageformat/) és a [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) beállításokat.

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

Az exportálás után a kimeneti mappának ez a szerkezete van:

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

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket gyakran JPEG‑ként vagy PNG‑ként exportálják. Az Aspose.Slides választani tud egy másik kép‑codecot, mint a forrás‑prezentációban használt, ha ez kisebb vagy megfelelőbb fájlt eredményez. A transzparens átlátszóságú képeket PNG‑ként exportálja.

## **URL‑ek kiválasztása telepítéshez**

A minta egy relatív URL‑előtagot használ: `assets/`. Ha a `presentation.html`‑t a `html-output/presentation.html` helyről nyitják meg, a böngésző betölti a `html-output/assets/resource-1.svg`‑t.

Amikor egy hivatkozott erőforrás egy másik hivatkozott erőforrásra hivatkozik, a minta a `referrer` paramétert használja az `ExternalResourceController.getUrl`‑ben, és csak a fájlnevet adja vissza. Például, ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG‑fájl a `resource-4.jpg`‑ra kell, hogy hivatkozzon, nem az `assets/resource-4.jpg`‑ra.

Használd az alábbi URL‑előtagok egyikét, ha a fájlok máshol kerülnek telepítésre:

- Használd az `assets/`‑t, ha az eszközkönyvtár a HTML‑fájl mellett helyezkedik el.
- Használd a `../assets/`‑t, ha az eszközkönyvtár egy szinttel a HTML‑fájl felett van.
- Használd a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok egy CDN‑re vagy statikus fájlszerverre lettek feltöltve.

Az `ExternalResourceController.getUrl` által visszaadott URL‑nek meg kell egyeznie a `ExternalResourceController.saveExternal` által írt fájl végső telepítési helyével. Szerveralkalmazásokban minden konverziós feladathoz használj egyedi kimeneti könyvtárat vagy objektumtároló előtagot, hogy elkerüld egy másik export fájljainak felülírását.

## **Mikor érdemes beágyazni helyette**

A beágyazott Base64 HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail mellékletként, offline előnézetként vagy egy olyan dokumentumként, amelyet egy támogató eszközkönyvtár nélkül mozgatnak. A hivatkozott erőforrások jobb megoldást jelentenek, ha a HTML-t egy webalkalmazás szolgálja ki, egy CMS‑ben tárolják, egy build‑csővezeték optimalizálja, vagy a böngészők a HTML‑től függetlenül cache‑lik.

## **FAQ**

**Kiexportálhatok csak képeket, és a többi erőforrást beágyazva hagyhatom?**

Igen. Az `ExternalResourceController.getObjectStoringLocation`‑ban csak a külön fájlként menteni kívánt tartalomtípusok esetén térj vissza a [LinkEmbedDecision](https://reference.aspose.com/slides/hu/php-java/aspose.slides/linkembeddecision/) `Link` értékével, minden más esetben a `Embed` értékkel.

**Miért tér el az exportált kép kiterjesztése a forrás‑prezentációétól?**

Az Aspose.Slides a HTML exportálása során újrakódolhatja a raszteres képeket a méret vagy a böngésző‑kompatibilitás javítása érdekében. Például a forrásfájl egy képe JPEG‑ként vagy PNG‑ként kerülhet kiírásra a megjelenített eredménytől függően.

**Működnek a relatív URL‑ek, ha áthelyezem a HTML‑fájlt?**

A relatív URL‑ek csak akkor működnek, ha a ugyanaz a relatív mappaszerkezet megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML‑fájl mellett kell maradnia, hacsak nem generálsz más URL‑előtagot.

**Újra kell-e használnia a szerveralkalmazásoknak ugyanazt a kimeneti mappát?**

Nem. Minden konverziós feladathoz használj egyedi kimeneti könyvtárat vagy tároló‑előtagot. Ez elkerüli a fájlnév-ütközéseket, és megakadályozza, hogy egy export felülírja egy másik export által generált erőforrásokat.