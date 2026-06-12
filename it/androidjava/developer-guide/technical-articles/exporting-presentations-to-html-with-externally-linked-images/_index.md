---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML su Android tramite Java usando Aspose.Slides, con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse sono scritte direttamente nell'HTML, solitamente come dati Base64. Questo è comodo quando è necessario un unico file portatile, ma non è sempre il formato migliore per una visualizzazione web, un CMS o una pipeline di conversione lato server che pubblica successivamente il risultato.

Usa risorse collegate esternamente quando vuoi:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, caratteri, audio o video separatamente in un browser o CDN;
- esaminare, sostituire, comprimere o effettuare post-elaborazioni delle risorse generate dopo l'esportazione;
- mantenere la struttura dell'output più vicina a quella che si aspetta un'applicazione web.

Per il flusso di lavoro generale di conversione HTML, consulta [Converti le presentazioni PowerPoint in HTML](/slides/it/androidjava/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione di risorse collegate**

[ILinkEmbedController](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) consente all'applicazione di decidere, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento.

L'interfaccia dispone di tre metodi:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) decide se una risorsa deve essere collegata o incorporata.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) scrive i dati della risorsa collegata su disco o su un altro target di archiviazione.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Per esempio, il campione sotto scrive i file di risorsa in `html-output/assets` nell'archiviazione dei file dell'applicazione, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL in base al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG utilizza `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` utilizza `resource-4.jpg`.

## **Esporta HTML con risorse collegate**

Il seguente esempio Android Java crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottocartella `assets`. Passa una directory di proprietà dell'app, ad esempio `context.getFilesDir()`, come `applicationFilesDirectory`. Il codice evita le API `java.nio.file`, quindi rimane compatibile con Android `minSdk` 19.

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

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Per esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

Il campione utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` è aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, il campione usa il parametro `referrer` in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) e restituisce solo il nome file. Per esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe fare riferimento a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Usa un prefisso URL diverso quando i file sono distribuiti altrove:

- Usa `assets/` quando la cartella delle risorse è accanto al file HTML.
- Usa `../assets/` quando la cartella delle risorse è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o su un server di file statici.

L'URL restituito da [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/) deve corrispondere alla posizione finale di distribuzione del file scritto da [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/). nelle applicazioni Android, utilizza l'archiviazione specifica dell'app, una directory di cache o una directory ottenuta tramite lo Storage Access Framework secondo il tuo flusso di pubblicazione. nelle applicazioni server, utilizza una directory di output univoca o un prefisso di storage per ogni lavoro di conversione per evitare di sovrascrivere file da un'altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di risorse di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, memorizzato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinkembedcontroller/), restituisci `Link` da [LinkEmbedDecision](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/linkembeddecision/) solo per i tipi di contenuto che desideri salvare come file separati, e restituisci `Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare le dimensioni o la compatibilità con il browser. Per esempio, un'immagine dal file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relativa è preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Posso scrivere le risorse su storage esterno pubblico su Android?**

Sì, se la tua applicazione dispone di una destinazione valida e di un modello di permessi per la versione Android di destinazione. Per HTML generato usato solo dalla tua app, i file specifici dell'app o le directory di cache sono solitamente più semplici. Per output visibile all'utente, utilizza una posizione selezionata dall'utente o un altro approccio di archiviazione che si adatti alla tua app.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Usa una directory di output univoca o un prefisso di storage per ogni lavoro di conversione. Ciò evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.