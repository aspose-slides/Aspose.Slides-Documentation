---
title: Export prezentací do HTML s externě odkazovanými obrázky
type: docs
weight: 100
url: /cs/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export prezentace
- export snímku
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
- odkazovaný obrázek
- externě odkazovaný obrázek
- odkazovaný prostředek
- externí prostředek
- Android
- Java
- Aspose.Slides
description: "Export prezentací PowerPoint a OpenDocument do HTML v Androidu pomocí Javy a knihovny Aspose.Slides, přičemž obrázky a další prostředky jsou uloženy jako externě odkazované soubory."
---
## **Přehled**

Ve výchozím nastavení exportuje Aspose.Slides prezentaci do samostatného HTML souboru. Obrázky a další prostředky jsou zapisovány přímo do HTML, obvykle jako data Base64. To je vhodné, když potřebujete jeden přenosný soubor, ale ne vždy to představuje nejlepší formát pro webové zobrazení, CMS nebo serverovou konverzní pipeline, která výstup později publikují.

Používejte externě odkazované prostředky, když chcete:

- snížit velikost HTML dokumentu;
- kešovat obrázky, fonty, audio nebo video samostatně v prohlížeči nebo CDN;
- po exportu kontrolovat, nahrazovat, komprimovat nebo post‑zpracovávat vygenerované prostředky;
- mít výstupní strukturu blíže tomu, co očekává webová aplikace.

Pro obecný postup konverze do HTML viz [Převod PowerPoint prezentací do HTML](/slides/cs/androidjava/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu související s odkazováním na prostředky.

## **Jak funguje export s odkazovanými prostředky**

[ILinkEmbedController](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) umožňuje vaší aplikaci rozhodnout o každém prostředku, zda jej exportér vloží do HTML nebo uloží externě a zapíše odkaz.

Rozhraní má tři metody:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) rozhoduje, zda by měl být prostředek odkazován nebo vložen.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) vrací URL, která bude zapsána do vygenerovaného HTML nebo do jiného odkazovaného prostředku.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) zapisuje data odkazovaného prostředku na disk nebo do jiného úložného cíle.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené problémy. Například ukázka níže zapisuje soubory prostředků do `html-output/assets` v úložišti aplikace, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tyto URL vyhodnocuje relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejné složce `assets` používá `resource-4.jpg`.

## **Export HTML s odkazovanými prostředky**

Následující příklad v Android Java vytvoří výstupní adresář, uloží tam HTML soubor a uloží odkazované prostředky do podadresáře `assets`. Jako adresář vlastněný aplikací předávejte např. `context.getFilesDir()` v parametru `applicationFilesDirectory`. Kód se vyhýbá API `java.nio.file`, takže zůstává kompatibilní s Android `minSdk` 19.

Řadič odkazuje běžné obrázkové, fontové, audio, video a CSS prostředky, pokud je Aspose.Slides schopen buď poskytnout, nebo odvodit bezpečnou příponu souboru. Prostředky, které nejsou rozpoznány, zůstávají vložené.

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

Přesné soubory závisí na obsahu prezentace a možnostech exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný image codec než ten použité v původní prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Volba URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřeno z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden odkazovaný prostředek odkazuje na jiný odkazovaný prostředek, ukázka používá parametr `referrer` v [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba ve složce `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jinou předponu URL, když jsou soubory nasazeny jinde:

- Použijte `assets/`, když je adresář s aktivy vedle HTML souboru.
- Použijte `../assets/`, když je adresář s aktivy o jednu úroveň výše než HTML soubor.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, když jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) musí odpovídat finální nasazené lokaci souboru, který zapíše metoda [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/). V Android aplikacích používejte úložiště specifické pro aplikaci, adresář cache nebo adresář získaný přes Storage Access Framework podle vašeho publikačního workflow. V serverových aplikacích používejte jedinečný výstupní adresář nebo předponu v objektovém úložišti pro každou konverzní úlohu, aby nedocházelo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když musí být výstup jediným souborem, např. příloha e‑mailu, offline náhled nebo dokument, který bude přesunut bez podpůrné složky s aktivy. Odkazované prostředky jsou vhodnější, když bude HTML servírováno webovou aplikací, uloženo v CMS, optimalizováno build pipeline nebo kešováno prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externalizovat jen obrázky a ostatní prostředky nechat vložené?**

Ano. V metodě [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinkembedcontroller/) vraťte `Link` z [LinkEmbedDecision](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linkembeddecision/) pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a vraťte `Embed` pro vše ostatní.

**Proč se po exportu liší přípona obrázku od původní prezentace?**

Aspose.Slides může během exportu do HTML přeenkódovat rastrové obrázky, aby zmenšil velikost nebo zvýšil kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG podle výsledku renderování.

**Fungují relativní URL po přesunu HTML souboru?**

Relativní URL fungují jen tehdy, pokud je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Mohu zapisovat prostředky na veřejné externí úložiště v Androidu?**

Ano, pokud má vaše aplikace platné cílové umístění a model oprávnění pro cílovou verzi Androidu. Pro generované HTML, které používá jen vaše aplikace, jsou obvykle jednodušší soubory specifické pro aplikaci nebo adresáře cache. Pro výstup viditelný uživateli použijte uživatelem vybranou lokaci nebo jiný úložný přístup, který vyhovuje vaší aplikaci.

**Mají serverové aplikace používat stejný výstupní adresář?**

Ne. Použijte jedinečný výstupní adresář nebo předponu úložiště pro každou konverzní úlohu. Tím se zabrání kolizím názvů souborů a přepisování prostředků generovaných jiným exportem.