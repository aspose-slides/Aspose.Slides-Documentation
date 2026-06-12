---
title: Esporta presentazioni in HTML con immagini collegate esternamente
type: docs
weight: 100
url: /it/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- PHP
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML in PHP tramite Java usando Aspose.Slides con immagini e altre risorse salvate come file collegati esternamente."
---
## **Panoramica**

Per impostazione predefinita, Aspose.Slides esporta una presentazione in un file HTML autonomo. Immagini e altre risorse vengono scritte direttamente nell'HTML, solitamente come dati Base64. Questo è comodo quando si necessita di un unico file portabile, ma non è sempre il formato migliore per un sito web, un CMS o una pipeline di conversione lato server.

Usa risorse collegate esternamente quando vuoi:

- ridurre le dimensioni del documento HTML;
- memorizzare nella cache immagini, font, audio o video separatamente in un browser o CDN;
- ispezionare, sostituire, comprimere o post‑elaborare le risorse generate dopo l'esportazione;
- mantenere la struttura dell'output più vicina a quella prevista da un'applicazione web.

Per il flusso di lavoro generale di conversione HTML, vedi [Converti Presentazioni PowerPoint in HTML](/slides/it/php-java/convert-powerpoint-to-html/). Questo articolo si concentra sulla parte di collegamento delle risorse dell'esportazione.

## **Come funziona l'esportazione di risorse collegate**

[HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) può utilizzare un controller personalizzato di collegamento/incorporamento quando Aspose.Slides esporta una presentazione in HTML. In PHP tramite Java, questo scenario è solitamente implementato con una piccola classe helper Java. Compila quell'helper, aggiungilo al classpath del PHP Java Bridge e istanzialo da PHP con `new Java(...)`.

La classe helper decide, risorsa per risorsa, se l'esportatore incorpora i dati nell'HTML o li salva esternamente scrivendo un collegamento. Richiede tre metodi di callback:

- `ExternalResourceController.getObjectStoringLocation` decide se una risorsa deve essere collegata o incorporata.
- `ExternalResourceController.getUrl` restituisce l'URL che verrà scritto nell'HTML generato o in un'altra risorsa collegata.
- `ExternalResourceController.saveExternal` scrive i dati della risorsa collegata su disco o su un altro obiettivo di archiviazione.

Il percorso del file system e l'URL del browser sono preoccupazioni separate. Ad esempio, il campione qui sotto scrive i file di risorse in `html-output/assets` su disco, mentre l'HTML contiene URL relativi come `assets/resource-1.svg`. Un browser risolve quegli URL rispetto al file che contiene il collegamento. Pertanto, un collegamento da `presentation.html` a un file SVG utilizza `assets/resource-1.svg`, mentre un collegamento da quel file SVG a un'immagine salvata nella stessa cartella `assets` utilizza `resource-4.jpg`.

## **Crea la classe helper Java**

Crea una classe Java, ad esempio `com.example.slides.ExternalResourceController`, compilala con Aspose.Slides per Java nel classpath e rendi la classe compilata o il JAR disponibile al PHP Java Bridge.

L'helper sottostante collega le risorse comuni di immagini, font, audio, video e CSS quando Aspose.Slides fornisce o può dedurre un'estensione file sicura. Le risorse non riconosciute rimangono incorporate.

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

## **Esporta HTML con risorse collegate**

Il seguente codice PHP crea una directory di output, salva il file HTML lì e memorizza le risorse collegate in una sottodirectory `assets`. Combina [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideimageformat/) e [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) per l'esportazione.

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

I file esatti dipendono dal contenuto della presentazione e dalle opzioni di esportazione. Ad esempio, le immagini raster sono comunemente esportate come JPEG o PNG. Aspose.Slides può scegliere un codec immagine diverso da quello usato nella presentazione di origine quando ciò produce un file più piccolo o più adatto. Le immagini con trasparenza sono esportate come PNG.

## **Scelta degli URL per il deployment**

L'esempio utilizza un prefisso URL relativo: `assets/`. Se `presentation.html` viene aperto da `html-output/presentation.html`, il browser carica `html-output/assets/resource-1.svg`.

Quando una risorsa collegata fa riferimento a un'altra risorsa collegata, l'esempio utilizza il parametro `referrer` in `ExternalResourceController.getUrl` e restituisce solo il nome del file. Per esempio, se `resource-1.svg` e `resource-4.jpg` sono entrambi nella cartella `assets`, il file SVG dovrebbe fare riferimento a `resource-4.jpg`, non a `assets/resource-4.jpg`.

Usa un prefisso URL diverso quando i file vengono distribuiti altrove:

- Usa `assets/` quando la directory delle risorse è accanto al file HTML.
- Usa `../assets/` quando la directory delle risorse è un livello sopra il file HTML.
- Usa `https://cdn.example.com/presentations/job-123/assets/` quando i file sono caricati su un CDN o su un server di file statici.

L'URL restituito da `ExternalResourceController.getUrl` deve corrispondere alla posizione finale di distribuzione del file scritto da `ExternalResourceController.saveExternal`. Nelle applicazioni server, utilizza una directory di output unica o un prefisso di storage per oggetti per ogni lavoro di conversione per evitare di sovrascrivere file provenienti da un'altra esportazione.

## **Quando incorporare invece**

L'HTML incorporato in Base64 è ancora utile quando l'output deve essere un unico file, ad esempio un allegato email, un'anteprima offline o un documento che verrà spostato senza una cartella di risorse di supporto. Le risorse collegate sono più adatte quando l'HTML sarà servito da un'applicazione web, archiviato in un CMS, ottimizzato da una pipeline di build o memorizzato nella cache dei browser indipendentemente dall'HTML.

## **FAQ**

**Posso esternalizzare solo le immagini e mantenere le altre risorse incorporate?**

Sì. In `ExternalResourceController.getObjectStoringLocation`, restituisci il valore `Link` da [LinkEmbedDecision](https://reference.aspose.com/slides/it/php-java/aspose.slides/linkembeddecision/) solo per i tipi di contenuto che desideri salvare come file separati, e restituisci il valore `Embed` per tutto il resto.

**Perché l'estensione dell'immagine esportata differisce da quella della presentazione di origine?**

Aspose.Slides può ricodificare le immagini raster durante l'esportazione HTML per migliorare le dimensioni o la compatibilità con i browser. Ad esempio, un'immagine dal file di origine può essere scritta come JPEG o PNG a seconda del risultato renderizzato.

**Gli URL relativi funzionano dopo aver spostato il file HTML?**

Gli URL relativi funzionano solo quando la stessa struttura di cartelle relativa viene preservata. Se l'HTML fa riferimento a `assets/resource-1.png`, la cartella `assets` deve rimanere accanto al file HTML a meno che non si generi un prefisso URL diverso.

**Le applicazioni server dovrebbero riutilizzare la stessa cartella di output?**

No. Utilizza una directory di output unica o un prefisso di storage per ogni lavoro di conversione. Questo evita collisioni di nomi file e impedisce a un'esportazione di sovrascrivere le risorse generate da un'altra esportazione.