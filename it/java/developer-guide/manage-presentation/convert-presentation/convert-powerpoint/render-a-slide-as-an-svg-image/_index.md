---
title: Renderizza le diapositive di presentazione come immagini SVG in Java
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in Java e controlla caratteri, testo, immagini, ID e eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) quando il file SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), seleziona una slide e scrivila in uno stream con [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). L'esempio seguente esporta ogni slide di una presentazione in un file SVG separato.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Il nome file utilizza [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) anziché l'indice del ciclo. È possibile anche esportare una forma individuale con [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) quando un visualizzatore di slide o una pagina web necessita solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determina se la rotazione del riquadro viene applicata. Imposta [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) su `true` quando il testo deve essere renderizzato senza legature.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controlla il ritaglio delle estremità di linea alle punte delle frecce**

SVG 1.1 non ha un'impostazione di inserimento del marcatore per specificare dove una linea deve fermarsi sotto una punta di freccia. Per impostazione predefinita, Aspose.Slides accorcia la linea esportata in modo che il tratto non sporga attraverso il marcatore. Chiama [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) con `true` per disegnare il tratto fino al punto finale originale della linea. Questa impostazione influisce solo sull'output SVG. La linea mantiene la sua posizione e lunghezza nella diapositiva.

L'esempio disegna punte di freccia a triangolo e a diamante su linee spesse 2 e 10 punti. Esporta la stessa diapositiva due volte, modificando solo l'opzione di ritaglio.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Il confronto mostra la punta triangolare sulla linea a 10 punti. Con il ritaglio abilitato, la punta è affilata. Con il ritaglio disabilitato, il tratto sporge attraverso i lati inclinati del marcatore e lascia un'estremità piatta.

![Triangolo a 10 punti ingrandito con punta affilata quando il ritaglio è abilitato e estremità piatta quando il ritaglio è disabilitato](line-end-cropping.png)

Nelle altre linee dell'esempio, il tratto sporgente è meno visibile sul triangolo a 2 punti. Il diamante riempito copre l'estremità del tratto in entrambe le larghezze.

## **Controlla testo e caratteri**

Quando si esportano le diapositive in SVG, è possibile controllare se il testo rimane testo o viene convertito in grafica vettoriale, e come i caratteri esterni vengono inclusi o referenziati. Le seguenti opzioni vi aiutano a bilanciare la coerenza visiva, la selezione del testo e le dipendenze dei caratteri nello SVG esportato.

### **Vettorializza tutto il testo**

Imposta [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile o ricercabile come testo SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per riferire a file di caratteri separati, `Embed` per includere i dati del carattere nello SVG, o `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica la licenza dei caratteri prima di incorporarli.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Riduci le dimensioni delle immagini incorporate**

Utilizza [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) per omettere le aree ritagliate delle immagini sorgenti, e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) per controllare la qualità della codifica JPEG. queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controlla la risoluzione di rasterizzazione dei Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) imposta il limite inferiore di risoluzione per rasterizzare i metafile durante l'esportazione SVG. Usalo per bilanciare i dettagli e le dimensioni del file quando un'immagine EMF o WMF viene rasterizzata. Non definisce un DPI globale per lo SVG né forza ogni oggetto della diapositiva a diventare un'immagine raster.

Scarica [metafile-rasterization.pptx](metafile-rasterization.pptx), che contiene un'immagine EMF con linee diagonali molto vicine. L'esempio seguente esporta la sua prima diapositiva a tre risoluzioni di rasterizzazione tramite [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Tutte le altre impostazioni di esportazione rimangono identiche così i risultati possono essere confrontati.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Nell'output, l'EMF è diventato un PNG incorporato in ogni SVG. Le seguenti misurazioni sono per la presentazione fornita; non costituiscono una formula generale per convertire DPI in dimensioni pixel.

| Risoluzione di rasterizzazione del Metafile DPI | Dimensioni PNG incorporato | Dimensione file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Il confronto sotto mostra la stessa area del raster incorporato alla stessa dimensione di visualizzazione ingrandita. Le linee diagonali mostrano una pixelatura visibile a 72 DPI e bordi più morbidi a risoluzioni più alte, mentre il file SVG cresce. Aumentare il valore non migliora necessariamente ogni dettaglio né cambia ogni immagine esportata.

![Dettaglio della linea diagonale ingrandita a 72, 150 e 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) controlla la riduzione della risoluzione dell'immagine e può mascherare l'effetto del cambiamento della risoluzione di rasterizzazione del metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) controlla la qualità della codifica JPEG, non la risoluzione di rasterizzazione del metafile.

## **Assegna ID stabili a forme e testo**

Utilizza [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) per impostare [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) per ogni forma SVG. Per impostare i valori [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) sugli elementi `tspan` di testo, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assegna uno dei due controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Il controller seguente utilizza [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), che è stabile per la durata della forma, e un contatore ripetibile per i suoi `tspan` di testo. Questo rende gli ID generati adatti al post‑processing di una presentazione non modificata.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungi gestori di eventi SVG**

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), chiama [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) con un valore [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) e definisci la funzione JavaScript nella pagina o documento SVG che ospita il risultato.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

La pagina host può definire la funzione JavaScript referenziata dal gestore. Assegnare ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Utilizza [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) quando tutto il testo deve essere indipendente dai caratteri. Utilizza [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree ritagliate delle immagini e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorializzato hanno ciascuno compromessi diversi in termini di qualità e dimensioni.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o script del browser.