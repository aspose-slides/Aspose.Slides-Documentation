---
title: Prezentációk exportálása HTML-be külsőleg hivatkozott képekkel
type: docs
weight: 100
url: /hu/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-be Java nyelven az Aspose.Slides használatával, ahol a képek és egyéb erőforrások külsőleg hivatkozott fájlokként kerülnek mentésre."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be íródnak, általában Base64 adatokként. Ez akkor kényelmes, amikor egy hordozható fájlra van szükség, de nem mindig a legjobb formátum egy weboldal, egy CMS vagy egy szerveroldali konverziós csővezeték számára.

Külsőleg hivatkozott erőforrásokat akkor használjon, ha:

- csökkenteni szeretné a HTML dokumentum méretét;
- a képeket, betűkészleteket, hangokat vagy videókat külön a böngészőben vagy CDN‑en szeretné gyorsítótárazni;
- az exportálás után ellenőrizni, cserélni, tömöríteni vagy utófeldolgozni kívánja a generált erőforrásokat;
- a kimeneti struktúrát közelebb szeretné hozni ahhoz, amit egy webalkalmazás elvár.

Az általános HTML konverziós munkafolyamatért lásd a [Convert PowerPoint Presentations to HTML](/slides/hu/java/convert-powerpoint-to-html/) cikket. Ez a cikk az export erőforrás‑hivatkozási részére összpontosít.

## **A hivatkozott erőforrások exportálásának működése**

[ILinkEmbedController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) lehetővé teszi, hogy az alkalmazás erőforrásonként eldöntse, beágyazza‑e a HTML‑be az adatot, vagy külsőleg menti és hivatkozást ír.

Az interfész három metódust tartalmaz:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) eldönti, hogy egy erőforrás hivatkozott vagy beágyazott legyen.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) visszaadja azt az URL‑t, amely a generált HTML‑be vagy egy másik hivatkozott erőforrásba kerül.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) a hivatkozott erőforrás adatát leírja lemezre vagy egy másik tárolási célra.

A fájlrendszer‑útvonal és a böngésző URL‑je külön kérdés. Például az alábbi mintában az erőforrás‑fájlok a `html-output/assets` mappába kerülnek a lemezen, míg a HTML relatív URL‑ket tartalmaz, például `assets/resource-1.svg`. A böngésző ezeket az URL‑ket a hivatkozást tartalmazó fájlhoz relatívan oldja fel. Ezért a `presentation.html` fájl egy SVG‑re mutató hivatkozása `assets/resource-1.svg`, míg az SVG fájl egy, ugyanabban az `assets` mappában lévő képre mutató hivatkozása `resource-4.jpg`.

## **HTML exportálása hivatkozott erőforrásokkal**

Az alábbi Java példa létrehoz egy kimeneti könyvtárat, elmenti oda a HTML fájlt, és a hivatkozott erőforrásokat egy `assets` almappába helyezi. A vezérlő közös kép, betűkészlet, hang, videó és CSS erőforrásokra hivatkozik, ha az Aspose.Slides biztosít vagy képes egy biztonságos fájl kiterjesztést meghatározni. A nem felismert erőforrások továbbra is beágyazottak maradnak.

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

Az exportálás után a kimeneti mappa a következő struktúrával rendelkezik:

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

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket gyakran JPEG vagy PNG formátumban exportálják. Az Aspose.Slides másik kép‑kódolót választhat a forrás prezentációban használt helyett, ha ez kisebb vagy jobban alkalmas fájlt eredményez. A átlátszóságot tartalmazó képek PNG‑ként kerülnek exportálásra.

## **URL‑k kiválasztása a telepítéshez**

A minta relatív URL előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html` fájlból nyílik meg, a böngésző a `html-output/assets/resource-1.svg` fájlt tölti be.

Amikor egy hivatkozott erőforrás egy másik hivatkozott erőforrásra mutat, a minta a `referrer` paramétert használja a [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) metódusban, és csak a fájlnevet adja vissza. Például ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG‑nek `resource-4.jpg`‑re kell hivatkoznia, nem `assets/resource-4.jpg`‑re.

Használjon más URL előtagot, ha a fájlok máshol kerülnek telepítésre:

- Használja a `assets/`‑t, ha az asset könyvtár a HTML fájl mellett helyezkedik el.
- Használja a `../assets/`‑t, ha az asset könyvtár egy szinttel a HTML fájl felett van.
- Használja a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok CDN‑re vagy statikus fájlszerverre kerülnek feltöltésre.

Az [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) által visszaadott URL‑nek meg kell egyeznie a [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) által a lemezen írt fájl végleges telepítési helyével. Szerveralkalmazásokban használjon egyedi kimeneti könyvtárat vagy objektumtároló előtagot minden konverziós feladathoz, hogy elkerülje a fájlok felülírását más exportálásokból.

## **Mikor érdemes inkább beágyazni**

A beágyazott Base64 HTML még mindig hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail mellékletként, offline előnézetként vagy olyan dokumentumként, amelyet egy támogatás nélküli asset mappa nélkül fognak mozgatni. A hivatkozott erőforrások jobb választás, ha a HTML‑t egy webalkalmazás szolgálja ki, CMS‑ben tárolják, egy build folyamat optimalizálja, vagy a böngészők a HTML‑től függetlenül gyorsítótárazzák.

## **GYIK**

**Kizárólag a képeket szeretném externalizálni, a többi erőforrás be legyen ágyazva?**

Igen. Az [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) metódusban adja vissza a `LinkEmbedDecision.Link` értéket csak azokhoz a tartalomtípusokhoz, amelyeket külön fájlként kíván menteni, a többihez adja vissza a `LinkEmbedDecision.Embed` értéket.

**Miért tér el a exportált kép kiterjesztése a forrás prezentációétól?**

Az Aspose.Slides a HTML exportálás során újrakódolhatja a raszteres képeket a méret vagy a böngésző kompatibilitás javítása érdekében. Például egy forrásfájlból származó kép JPEG vagy PNG formátumban íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑k, ha áthelyezem a HTML fájlt?**

A relatív URL‑k csak akkor működnek, ha az azonos relatív mappastruktúra megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML fájl mellett kell maradnia, kivéve ha más URL‑előtagot generál.

**A szerveralkalmazások használhatják ugyanazt a kimeneti mappát?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tárolási előtagot minden konverziós feladathoz. Ez elkerüli a fájlnév-ütközéseket és megakadályozza, hogy egy export felülírja egy másik export által generált erőforrásokat.