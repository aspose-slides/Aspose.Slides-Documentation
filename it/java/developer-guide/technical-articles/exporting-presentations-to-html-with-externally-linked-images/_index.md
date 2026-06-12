---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- esporta diapositiva
- esporta PPT
- esporta PPTX
- esporta ODP
- PowerPoint in HTML
- OpenDocument in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- immagine collegata
- immagine collegata esternamente
- risorsa collegata
- risorsa esterna
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in Java utilizzando Aspose.Slides, con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono inserite direttamente nell'HTML, di solito come dati Base64. Ciò è comodo quando si necessita di un unico file portabile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Utilizzare risorse collegate esternamente quando si desidera:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- esaminare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- mantenere la struttura di output più vicina a ciò che un'applicazione web si aspetta.

Per il flusso di lavoro generale di conversione HTML, vedere [Convert PowerPoint Presentations to HTML](/slides/it/java/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione con risorse collegate**

[ILinkEmbedController](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) consente alla tua applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente e scrive un collegamento.

L'interfaccia dispone di tre metodi:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) decide se una risorsa deve essere collegata o incorporata.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) scrive i dati della risorsa collegata su disco o su un altro target di archiviazione.

La path del file system e l'URL del browser sono preoccupazioni separate. Ad esempio, il campione seguente scrive i file di risorsa in `html-output/assets` su disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL rispetto al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG utilizza `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` utilizza `resource-4.jpg`.

## **Esporta HTML con risorse collegate**

Il seguente esempio Java crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottodirectory `assets`. Il controller collega le risorse comuni di immagini, font, audio, video e CSS quando Aspose.Slides fornisce o può dedurre un'estensione di file sicura. Le risorse non riconosciute rimangono incorporate.

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

Dopo l'esportazione, la cartella di output ha questa struttura:

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

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Ad esempio, le immagini raster vengono tipicamente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza vengono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione utilizza il parametro `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) e restituisce solo il nome del file. Ad esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe riferirsi a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Utilizzare un prefisso URL diverso quando i file sono distribuiti altrove:

- Utilizzare `assets/` quando la directory degli asset è accanto al file HTML.
- Utilizzare `../assets/` quando la directory degli asset è un livello sopra il file HTML.
- Utilizzare `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o un server di file statici.

L'URL restituito da [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/) deve corrispondere alla posizione finale di distribuzione del file scritto da [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/). Nelle applicazioni server, utilizzare una directory di output unica o un prefisso di archiviazione oggetti per ogni lavoro di conversione per evitare di sovrascrivere file da un'altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di asset di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, archiviato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dai browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinkembedcontroller/), restituisci `LinkEmbedDecision.Link` solo per i tipi di contenuto che desideri salvare come file separati, e restituisci `LinkEmbedDecision.Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare dimensione o compatibilità con il browser. Ad esempio, un'immagine del file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relativa viene preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Utilizzare una directory di output unica o un prefisso di archiviazione per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce che una esportazione sovrascriva le risorse generate da un'altra esportazione.