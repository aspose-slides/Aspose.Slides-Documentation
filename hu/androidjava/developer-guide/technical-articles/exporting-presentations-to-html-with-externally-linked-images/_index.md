---
title: Prezentációk exportálása HTML-re külsőleg hivatkozott képekkel
type: docs
weight: 100
url: /hu/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása HTML-re Androidon Java használatával az Aspose.Slides segítségével, képekkel és egyéb erőforrásokkal, amelyeket külső hivatkozott fájlokként mentünk."
---
## **Áttekintés**

Alapértelmezés szerint az Aspose.Slides egy prezentációt önálló HTML-fájlba exportál. A képek és egyéb erőforrások közvetlenül a HTML-be íródnak, általában Base64 adatként. Ez kényelmes, ha egy hordozható fájlra van szükség, de nem mindig a legjobb formátum webes megjelenítéshez, CMS-hez vagy olyan szerveroldali konverziós csővezetékhez, amely később közzéteszi a kimenetet.

Külsőleg hivatkozott erőforrásokat akkor használjon, ha:

- csökkenteni akarja a HTML-dokumentum méretét;
- a képeket, betűkészleteket, hang- vagy videofájlokat külön szeretné gyorsítótárazni egy böngészőben vagy CDN-ben;
- az exportálás után ellenőrizni, cserélni, tömöríteni vagy utólag feldolgozni kívánja a generált erőforrásokat;
- a kimeneti struktúrát közelebb szeretné hozni ahhoz, amit egy webalkalmazás elvár.

Az általános HTML-konverziós munkafolyamatért lásd a [PowerPoint prezentációk konvertálása HTML-re](/slides/hu/androidjava/convert-powerpoint-to-html/). Ez a cikk az export erőforrás-hivatkozási részére koncentrál.

## **A hivatkozott erőforrások exportálásának működése**

[ILinkEmbedController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) lehetővé teszi az alkalmazás számára, hogy erőforrásonként eldöntse, a exportáló beágyazza-e az adatot a HTML-be, vagy külsőleg menti el, és hivatkozást ír be.

Az interfész három metódust tartalmaz:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) határozza meg, hogy egy erőforrás legyen linkelve vagy beágyazva.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) adja vissza az URL-t, amely a generált HTML‑be vagy egy másik hivatkozott erőforrásba kerül.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) írja a hivatkozott erőforrás adatát lemezre vagy egy másik tároló célra.

A fájlrendszer útvonala és a böngésző URL-je külön gondolat. Például az alábbi példa erőforrásfájlokat a `html-output/assets` könyvtárba írja az alkalmazás fájltárolójába, míg a HTML relatív URL-eket tartalmaz, például `assets/resource-1.svg`. A böngésző ezeket az URL-eket a hivatkozást tartalmazó fájlhoz képest oldja fel. Így a `presentation.html` fájlból egy SVG-fájlra mutató link `assets/resource-1.svg` lesz, míg az SVG-fájlban egy, ugyanabban az `assets` mappában mentett képre mutató hivatkozás `resource-4.jpg`.

## **HTML exportálása hivatkozott erőforrásokkal**

Az alábbi Android‑Java példa létrehoz egy kimeneti könyvtárat, elmenti oda a HTML‑fájlt, és a hivatkozott erőforrásokat egy `assets` alkönyvtárban tárolja. Adj meg egy alkalmazás‑tulajdonú könyvtárat, például `context.getFilesDir()`‑t a `applicationFilesDirectory` paraméterként. A kód nem használ `java.nio.file` API‑kat, így Android `minSdk` 19‑kel is kompatibilis marad.

A vezérlő a gyakori kép, betűtípus, hang, videó és CSS erőforrásokat linkeli, amikor az Aspose.Slides biztosít vagy biztonságos fájlkiterjesztést tud következtetni. A nem felismert erőforrások beágyazva maradnak.

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

A pontos fájlok a prezentáció tartalmától és az exportálási beállításoktól függenek. Például a raszteres képeket általában JPEG‑ként vagy PNG‑ként exportálja a rendszer. Az Aspose.Slides másik kép‑kódert választhat a forrás‑prezentációban lévő helyett, ha ez kisebb vagy alkalmasabb fájlt eredményez. Az átlátszóságot tartalmazó képeket PNG‑ként exportálja.

## **URL‑ek kiválasztása a közzétételhez**

A minta egy relatív URL‑előtagot használ: `assets/`. Ha a `presentation.html` a `html-output/presentation.html` helyről nyílik meg, a böngésző a `html-output/assets/resource-1.svg` fájlt tölti be.

Amikor egy hivatkozott erőforrás egy másik hivatkozott erőforráshoz fordul, a minta a `referrer` paramétert használja a [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) metódusban, és csak a fájlnevet adja vissza. Például, ha a `resource-1.svg` és a `resource-4.jpg` is az `assets` mappában van, az SVG‑fájlnak `resource-4.jpg`‑re kell hivatkoznia, nem pedig `assets/resource-4.jpg`‑ra.

Használjon másik URL‑előtagot, ha a fájlok máshol kerülnek telepítésre:

- Használja az `assets/`‑t, ha az eszközkönyvtár a HTML‑fájl mellett helyezkedik el.
- Használja a `../assets/`‑t, ha az eszközkönyvtár egy szinttel a HTML‑fájl felett található.
- Használja a `https://cdn.example.com/presentations/job-123/assets/`‑t, ha a fájlok CDN‑re vagy statikus fájlszerverre vannak feltöltve.

Az [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) által visszaadott URL‑nek meg kell egyeznie a [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) által írt fájl végleges telepítési helyével. Android‑alkalmazásokban használjon alkalmazás‑specifikus tárolót, gyorsítótár‑könyvtárat, vagy a Storage Access Framework‑ön keresztül kapott könyvtárat a kiadási munkafolyamatnak megfelelően. Szerver‑alkalmazásokban használjon egyedi kimeneti könyvtárat vagy objektumtároló előtagot minden konverziós feladathoz, hogy elkerülje a fájlok felülírását más exportokból.

## **Mikor érdemes beágyazni helyette**

A beágyazott Base64‑HTML továbbra is hasznos, ha a kimenetnek egyetlen fájlnak kell lennie, például e‑mail‑csatolmányként, offline‑előnézetként vagy olyan dokumentumként, amelyet egy támogató eszközkönyvtár nélkül kell mozgatni. A hivatkozott erőforrások jobban illeszkednek, ha a HTML‑t egy webalkalmazás szolgálja ki, CMS‑ben tárolják, építési csővezetékkel optimalizálják, vagy a böngészők a HTML‑től függetlenül gyorsítótárazzák.

## **GYIK**

**Kizárólag a képeket tudom-e külsőleg tárolni, míg a többi erőforrás beágyazott marad?**

Igen. A [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/) metódusban adja vissza a `Link` értéket a [LinkEmbedDecision](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linkembeddecision/)-ból csak azokhoz a tartalomtípusokhoz, amelyeket külön fájlként szeretne menteni, és minden máshoz adja vissza az `Embed` értéket.

**Miért tér el az exportált kép kiterjesztése a forrás‑prezentációétól?**

Az Aspose.Slides a HTML exportálása során újrakódolhatja a raszteres képeket, hogy csökkentse a méretet vagy javítsa a böngésző‑kompatibilitást. Például a forrásfájlban lévő kép JPEG‑ként vagy PNG‑ként íródhat, a megjelenített eredménytől függően.

**Működnek a relatív URL‑ek, ha áthelyezem a HTML‑fájlt?**

A relatív URL‑ek csak akkor működnek, ha a relatív mappastruktúra megmarad. Ha a HTML a `assets/resource-1.png`‑re hivatkozik, az `assets` mappának a HTML‑fájl mellett kell maradnia, hacsak nem generál másik URL‑előtagot.

**Írhatok erőforrásokat nyilvános külső tárolóba Androidon?**

Igen, ha az alkalmazás rendelkezik a cél‑Android‑verzióhoz megfelelő célhely‑ és engedély‑modellel. A csak az alkalmazás által használt generált HTML‑hez általában egyszerűbb az alkalmazás‑specifikus fájlok vagy gyorsítótár‑könyvtár használata. Felhasználó‑látványos kimenet esetén használjon felhasználó által kiválasztott helyet vagy más tárolási megoldást, amely illeszkedik az alkalmazásához.

**A szerver‑alkalmazások újra felhasználhatják ugyanazt a kimeneti mappát?**

Nem. Használjon egyedi kimeneti könyvtárat vagy tárolási előtagot minden konverziós feladathoz. Ez megakadályozza a fájlnév‑ütközéseket, és megvédi, hogy egy export felülírja egy másik export által generált erőforrásokat.