---
title: Exportovat prezentace do HTML s externě propojenými obrázky
type: docs
weight: 100
url: /cs/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPointu
- export OpenDocumentu
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
- propojený obrázek
- externě propojený obrázek
- propojený zdroj
- externí zdroj
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do HTML v jazyce Java pomocí Aspose.Slides s obrázky a dalšími zdroji uloženými jako externě propojené soubory."
---
## **Přehled**

Ve výchozím nastavení Aspose.Slides exportuje prezentaci do samostatného HTML souboru. Obrázky a další zdroje jsou zapisovány přímo do HTML, obvykle jako data Base64. To je pohodlné, když potřebujete jeden přenosný soubor, ale není to vždy nejlepší formát pro webové stránky, CMS nebo serverovou konverzní pipeline.

Použijte externě odkazované zdroje, když chcete:
- zmenšit velikost HTML dokumentu;
- cachovat obrázky, písma, audio nebo video samostatně v prohlížeči nebo CDN;
- zkontrolovat, nahradit, komprimovat nebo následně zpracovat generované zdroje po exportu;
- udržet strukturu výstupu blíže tomu, co očekává webová aplikace.

Pro obecný postup konverze HTML si přečtěte [Převod prezentací PowerPoint do HTML](/slides/cs/java/convert-powerpoint-to-html/). Tento článek se zaměřuje na část exportu související s propojením zdrojů.

## **Jak funguje export propojených zdrojů**

[ILinkEmbedController](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) umožňuje vaší aplikaci rozhodovat po jednotlivých zdrojích, zda exportér vloží data do HTML nebo je uloží externě a zapíše odkaz.

Rozhraní má tři metody:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) určuje, zda by měl být zdroj odkazován nebo vložen.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) vrací URL, která bude zapsána do vygenerovaného HTML nebo do jiného propojeného zdroje.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) zapíše data propojeného zdroje na disk nebo do jiného úložiště.

Cesta v souborovém systému a URL v prohlížeči jsou oddělené záležitosti. Například níže uvedený příklad zapisuje soubory zdrojů do `html-output/assets` na disku, zatímco HTML obsahuje relativní URL jako `assets/resource-1.svg`. Prohlížeč tyto URL vyhodnocuje relativně k souboru, který odkaz obsahuje. Proto odkaz z `presentation.html` na SVG soubor používá `assets/resource-1.svg`, zatímco odkaz z tohoto SVG souboru na obrázek uložený ve stejné složce `assets` používá `resource-4.jpg`.

## **Export HTML s propojenými zdroji**

Následující Java příklad vytvoří výstupní adresář, uloží tam HTML soubor a uloží propojené zdroje do podsložky `assets`. Kontroler propojuje běžné obrázkové, písmo, audio, video a CSS zdroje, pokud Aspose.Slides poskytuje nebo dokáže odhadnout bezpečnou příponu souboru. Zdroje, které nejsou rozpoznány, zůstávají vloženy.

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

Přesné soubory závisí na obsahu prezentace a nastaveních exportu. Například rastrové obrázky jsou běžně exportovány jako JPEG nebo PNG. Aspose.Slides může zvolit jiný image kodek než ten použitý v původní prezentaci, pokud to vede k menšímu nebo vhodnějšímu souboru. Obrázky s průhledností jsou exportovány jako PNG.

## **Volba URL pro nasazení**

Ukázka používá relativní předponu URL: `assets/`. Pokud je `presentation.html` otevřen z `html-output/presentation.html`, prohlížeč načte `html-output/assets/resource-1.svg`.

Když jeden propojený zdroj odkazuje na jiný propojený zdroj, ukázka používá parametr `referrer` v [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) a vrací pouze název souboru. Například pokud jsou `resource-1.svg` a `resource-4.jpg` oba ve složce `assets`, SVG soubor by měl odkazovat na `resource-4.jpg`, nikoli na `assets/resource-4.jpg`.

Použijte jinou předponu URL, když jsou soubory nasazeny jinde:
- Použijte `assets/`, pokud je adresář s prostředky vedle HTML souboru.
- Použijte `../assets/`, pokud je adresář s prostředky o jednu úroveň nad HTML souborem.
- Použijte `https://cdn.example.com/presentations/job-123/assets/`, pokud jsou soubory nahrány na CDN nebo statický souborový server.

URL vrácená metodou [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/) musí odpovídat konečné nasazené lokaci souboru, který je zapsán metodou [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/). V serverových aplikacích použijte jedinečný výstupní adresář nebo předponu objektového úložiště pro každou konverzní úlohu, aby nedošlo k přepsání souborů z jiného exportu.

## **Kdy místo toho vložit**

Vložené Base64 HTML je stále užitečné, když výstup musí být jediný soubor, například e‑mailová příloha, offline náhled nebo dokument, který bude přesunut bez připojené složky se zdroji. Propojené zdroje jsou vhodnější, když bude HTML poskytováno webovou aplikací, uloženo v CMS, optimalizováno build pipeline nebo cachováno prohlížeči nezávisle na HTML.

## **Často kladené otázky**

**Mohu externalizovat pouze obrázky a nechat ostatní zdroje vložené?**

Ano. V metodě [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinkembedcontroller/), vraťte `LinkEmbedDecision.Link` pouze pro typy obsahu, které chcete uložit jako samostatné soubory, a pro vše ostatní vraťte `LinkEmbedDecision.Embed`.

**Proč se přípona exportovaného obrázku liší od původní prezentace?**

Aspose.Slides může během exportu HTML rekódovat rastrové obrázky, aby zlepšil velikost nebo kompatibilitu s prohlížeči. Například obrázek ze zdrojového souboru může být zapsán jako JPEG nebo PNG v závislosti na výsledném vykreslení.

**Fungují relativní URL po přesunutí HTML souboru?**

Relativní URL fungují jen tehdy, když je zachována stejná relativní struktura složek. Pokud HTML odkazuje na `assets/resource-1.png`, složka `assets` musí zůstat vedle HTML souboru, pokud nevytvoříte jinou předponu URL.

**Měly by serverové aplikace znovu použít stejnou výstupní složku?**

Ne. Použijte jedinečný výstupní adresář nebo předponu úložiště pro každou konverzní úlohu. Tím se zabrání kolizím názvů souborů a přepsání zdrojů jedním exportem jiným exportem.