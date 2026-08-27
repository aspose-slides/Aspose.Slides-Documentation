---
title: Converti le presentazioni PowerPoint in Markdown su Android
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/androidjava/convert-powerpoint-to-markdown/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salvare PowerPoint come Markdown
- salvare presentazione come Markdown
- salvare diapositiva come Markdown
- salvare PPT come MD
- salvare PPTX come MD
- esportare PPT in MD
- esportare PPTX in MD
- esportazione immagini Markdown
- link immagini CDN
- PowerPoint
- presentazione
- Markdown
- Android
- Java
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in Markdown su Android tramite Java e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per Android via Java può convertire presentazioni PPT e PPTX in Markdown per documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere un flavor di Markdown, controllare come viene renderizzato il contenuto delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le fa riferimento.

Per impostazione predefinita, l’esportazione in Markdown utilizza solo output testuale. Per esportare contenuti visivi, impostare il tipo di esportazione con il metodo [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) al valore `Sequential` o `Visual` della enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` rende gli oggetti della diapositiva separatamente e in ordine, mentre `Visual` mantiene gli oggetti raggruppati insieme per preservare la loro relazione visiva. Il valore `TextOnly` non genera risorse immagine, quindi le callback di salvataggio delle immagini non vengono invocate in quella modalità.

## **Convertire una Presentazione in Markdown**

Caricare il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e quindi chiamare il metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) passando il valore `Md` della enumerazione [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/).

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

## **Selezionare un Flavor di Markdown**

Il metodo [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) controlla la specifica di Markdown utilizzata per l’output. La enumerazione [Flavor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

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

## **Esportare Immagini con il Comportamento Predefinito di Salvataggio Locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [setBasePath](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) specifica la directory base per il documento Markdown e le sue risorse.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) specifica la sottodirectory delle immagini. Il suo valore predefinito è `Images`.

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

Questo comportamento funge anche da fallback quando un gestore personalizzato di salvataggio immagini restituisce `false`.

## **Personalizzare il Salvataggio delle Immagini e i Link Markdown**

Utilizzare il metodo [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) per registrare una callback per le risorse bitmap e metafile non SVG emesse durante l’esportazione in Markdown. La sua callback `MarkdownImageSavingHandler` riceve l’oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/), il valore [ImageFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/) e il link Markdown generato come parametro `String[]` a un solo elemento. Salvare o caricare l’immagine con il formato fornito e sostituire `link[0]` con il riferimento che deve apparire nell’output Markdown.

Le risorse emesse in formato SVG sono gestite separatamente. Registrare una callback con il metodo [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/). La sua callback `MarkdownSvgImageSavingHandler` riceve un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) e il parametro `String[] link` a un solo elemento. Un SVG non ha argomento `ImageFormat`; scrivere o caricare i dati XML tramite il metodo [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/). In base alla modalità di esportazione e al raggruppamento visivo, uno SVG nella presentazione sorgente può essere rasterizzato o combinato con altri contenuti; la risorsa non SVG risultante viene quindi passata alla callback di salvataggio immagine. Registrare entrambe le callback quando ogni risorsa visiva esportata richiede elaborazione personalizzata.

Il valore restituito dal gestore determina chi elabora l’immagine:

- Restituire `true` dopo che il gestore ha salvato, caricato, trasformato o altrimenti elaborato l’immagine e ha assegnato un valore valido a `link[0]`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituire `false` per consentire ad Aspose.Slides di salvare l’immagine localmente e generare il suo link in base ai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Un gestore che restituisce `true` si assume la responsabilità dell’immagine. Se restituisce `true` senza assegnare un link valido e non vuoto, l’esportazione fallisce con un `InvalidOperationException`.

{{% /alert %}}

### **Salvare le Immagini in una Directory di Origine CDN e Utilizzare URL Esterni**

Il seguente esempio tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni gestore estrae il nome file generato, salva l’immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L’esempio stesso non esegue alcun upload di rete: l’URL diventa valido solo dopo che la directory è montata come origine CDN o i suoi file sono pubblicati sul CDN. Per lo storage a oggetti, sostituire la scrittura su file system con l’operazione di upload dell’Sdk di storage e assegnare `link[0]` solo dopo che l’upload è riuscito.

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

Il gestore bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva quelle immagini in `output/fallback-images` usando il comportamento predefinito. Le risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Ad esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I gestori usano percorsi del sistema operativo solo quando scrivono file; i link scritti in Markdown usano barre oblique (`/`) e nomi file con escape URL. Applicare la stessa regola quando si costruiscono link relativi: usare `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un gestore può elaborare sia immagini raster che immagini SVG?**

No. Utilizzare [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) per le risorse bitmap e metafile emesse e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) per le risorse emesse come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) e un valore [ImageFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/); il secondo fornisce un oggetto [ISvgImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/) il cui dato SVG può essere letto con [ISvgImage.getSvgData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgimage/). Un SVG sorgente rasterizzato durante l’esportazione è elaborato dalla callback di salvataggio immagine.

**Cosa succede quando un gestore di salvataggio immagine restituisce `false`?**

Aspose.Slides utilizza il comportamento predefinito di salvataggio locale. La posizione dell’immagine e il riferimento generato sono controllati dai valori impostati con [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/markdownsaveoptions/).

**Un gestore può fornire un URL senza salvare l’immagine localmente?**

Sì. Il gestore può caricare l’immagine su storage a oggetti o passarla a un altro servizio, assegnare l’URL risultante a `link[0]` e restituire `true`. Il gestore deve completare l’elaborazione da solo; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l’esportazione Markdown genera un `InvalidOperationException` da un gestore?**

Questa eccezione si verifica quando il gestore restituisce `true` ma non fornisce un link valido. Assegnare il percorso relativo o l’URL esterno che deve essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso devono utilizzare i link alle immagini?**

Usare le barre oblique nei link Markdown e negli URL. Usare `Path.resolve` solo per i percorsi del file system, quindi costruire o normalizzare il riferimento Markdown separatamente.

**I collegamenti ipertestuali sono preservati durante l’esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/androidjava/manage-hyperlinks/) del testo sono preservati come link Markdown standard. Le [transizioni](/slides/it/androidjava/slide-transition/) e le [animazioni](/slides/it/androidjava/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare file di presentazione diversi in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) tra thread. Seguire le [linee guida sul multithreading](/slides/it/androidjava/multithreading/) e utilizzare un’istanza separata per ogni file.