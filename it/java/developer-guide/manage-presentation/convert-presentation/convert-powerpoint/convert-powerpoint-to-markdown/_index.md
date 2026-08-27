---
title: Converti le presentazioni PowerPoint in Markdown in Java
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/java/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- esportazione immagini Markdown
- collegamenti immagini CDN
- PowerPoint
- presentazione
- Markdown
- Java
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in Markdown in Java e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per Java può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere una variante di Markdown, controllare come viene renderizzato il contenuto delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le fa riferimento.

Per impostazione predefinita, l’esportazione Markdown utilizza solo output testuale. Per esportare contenuti visivi, impostare il tipo di esportazione con il [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) metodo al valore `Sequential` o `Visual` dell’enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownexporttype/). `Sequential` rende gli elementi della diapositiva separatamente e in ordine, mentre `Visual` mantiene gli elementi raggruppati insieme per preservare la loro relazione visiva. Il valore `TextOnly` non genera risorse immagine, quindi le callback di salvataggio immagine non vengono invocate in quella modalità.

## **Converti una presentazione in Markdown**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e quindi chiama il metodo [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) con il valore `Md` dell’enumerazione [SaveFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Seleziona una variante di Markdown**

Il metodo [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) controlla la specifica Markdown utilizzata per l’output. L’enumerazione [Flavor](https://reference.aspose.com/slides/it/java/com.aspose.slides/flavor/) comprende CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione come CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Esporta immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [setBasePath](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) specifica la directory di base per il documento Markdown e le sue risorse.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) specifica la sottocartella delle immagini. Il suo valore predefinito è `Images`.

Il seguente esempio rende contenuti visivi, scrive le immagini in `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Questo comportamento funge anche da fallback quando un gestore di salvataggio immagine personalizzato restituisce `false`.

## **Personalizza il salvataggio delle immagini e i collegamenti Markdown**

Usa il metodo [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) per registrare una callback per le risorse bitmap e metafile non SVG generate durante l’esportazione Markdown. La sua callback `MarkdownImageSavingHandler` riceve l’oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/), il valore [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/) e il collegamento Markdown generato come parametro `String[]` a elemento unico. Salva o carica l’immagine nel formato fornito e sostituisci `link[0]` con il riferimento che deve comparire nell’output Markdown.

Le risorse emesse in formato SVG sono gestite separatamente. Registra una callback con il metodo [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/). La sua callback `MarkdownSvgImageSavingHandler` riceve un oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) e il parametro `String[] link` a elemento unico. Un SVG non ha argomento `ImageFormat`; scrivi o carica i suoi dati XML dal metodo [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) invece. A seconda della modalità di esportazione e del raggruppamento visivo, uno SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non SVG risultante viene quindi passata alla callback di salvataggio immagine. Registra entrambe le callback quando ogni risorsa visiva esportata richiede una elaborazione personalizzata.

Il valore di ritorno del gestore determina chi elabora l’immagine:

- Restituisci `true` dopo che il gestore ha salvato, caricato, trasformato o altrimenti elaborato l’immagine e ha assegnato un valore valido a `link[0]`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituisci `false` per consentire ad Aspose.Slides di salvare l’immagine localmente e generare il collegamento secondo i valori impostati da [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Un gestore che restituisce `true` si assume la responsabilità dell’immagine. Se restituisce `true` senza assegnare un collegamento valido e non vuoto, l’esportazione fallisce con un `InvalidOperationException`.

{{% /alert %}}

### **Salva le immagini in una directory di origine CDN e utilizza URL esterni**

Il seguente esempio tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni gestore estrae il nome file generato, salva l’immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L’esempio stesso non esegue alcun upload di rete: l’URL diventa valido solo dopo che la directory è montata come origine CDN o i suoi file sono pubblicati sul CDN. Per lo storage a oggetti, sostituisci la scrittura su file system con l’operazione di upload dell’Sdk di storage e assegna `link[0]` solo dopo che l’upload è riuscito.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Il gestore bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva tali immagini in `output/fallback-images` usando il comportamento predefinito. Risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Per esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I gestori usano percorsi del sistema operativo solo quando scrivono file; i collegamenti scritti nel Markdown usano barre oblique e nomi file escape per URL. Applica la stessa regola quando costruisci collegamenti relativi: usa `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un gestore può elaborare sia immagini raster che immagini SVG?**

No. Usa [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) per le risorse bitmap e metafile emesse e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) per le risorse emesse come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) e un valore [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/); il secondo fornisce un oggetto [ISvgImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/) il cui dato SVG può essere letto con [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgimage/). Un SVG di origine rasterizzato durante l’esportazione è elaborato dalla callback di salvataggio immagine anziché da quella SVG.

**Cosa succede quando un gestore di salvataggio immagine restituisce `false`?**

Aspose.Slides utilizza il suo comportamento predefinito di salvataggio locale. La posizione dell’immagine e il riferimento generato sono controllati dai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/java/com.aspose.slides/markdownsaveoptions/).

**Un gestore può fornire un URL senza salvare l’immagine localmente?**

Sì. Il gestore può caricare l’immagine su storage a oggetti o passarla a un altro servizio, assegnare l’URL risultante a `link[0]` e restituire `true`. Il gestore deve completare l’elaborazione da solo; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l’esportazione Markdown genera un `InvalidOperationException` dal gestore?**

Questa eccezione si verifica quando il gestore restituisce `true` ma non fornisce un collegamento valido. Assegna il percorso relativo o l’URL esterno che deve essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso dovrebbero usare i collegamenti alle immagini?**

Usa le barre oblique nei collegamenti Markdown e negli URL. Usa `Path.resolve` solo per i percorsi del file system, quindi costruisci o normalizza il riferimento Markdown separatamente.

**I collegamenti ipertestuali sono preservati durante l’esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/java/manage-hyperlinks/) testuali sono preservati come normali collegamenti Markdown. Le [transizioni](/slides/it/java/slide-transition/) e le [animazioni](/slides/it/java/powerpoint-animation/) delle diapositive non sono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare file di presentazione diversi in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) tra thread. Segui le [linee guida sul multithreading](/slides/it/java/multithreading/) e utilizza un’istanza separata per ciascun file.