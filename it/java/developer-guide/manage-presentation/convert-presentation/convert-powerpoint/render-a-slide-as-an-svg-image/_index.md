---
title: Genera diapositive di presentazione come immagini SVG in Java
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
description: "Esporta diapositive PowerPoint come immagini SVG in Java e controlla i caratteri, il testo, le immagini, gli ID e gli eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine scalabile basato su XML che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑processing. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e gli elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/) quando il SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream con [ISlide.writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

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

Il nome file utilizza [ISlide.getSlideNumber](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getSlideNumber--) anziché l'indice del ciclo. È inoltre possibile esportare una forma singola con [IShape.writeAsSvg](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) quando un visualizzatore di diapositive o una pagina web ha bisogno solo di quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) su `true` quando il testo deve essere renderizzato senza legature.

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

## **Controlla testo e caratteri**

### **Vectorizza tutto il testo**

Imposta [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) su `true` per scrivere tutto il testo della diapositiva come grafica vettoriale. Questo elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

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

### **Scegli come gestire i font esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per fare riferimento a file di caratteri separati, `Embed` per includere i dati del carattere nel SVG, oppure `Vectorize` per renderizzare solo il testo che utilizza caratteri esterni come grafica. Verifica le licenze dei caratteri prima di incorporarli.

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

## **Riduci la dimensione delle immagini incorporate**

Utilizza [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) per omettere le aree di origine ritagliate e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) per controllare la qualità della codifica JPEG. Queste impostazioni diminuiscono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

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

## **Assegna ID stabili a forme e testo**

Utilizza [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshapeformattingcontroller/) per impostare [ISvgShape.setId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) per ciascuna forma SVG. Per impostare anche i valori [ISvgTSpan.setId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) sugli elementi di testo `tspan`, implementa [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assegna uno dei due controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Il controller seguente utilizza [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), che è stabile per la durata della forma, e un contatore ripetibile per i suoi `tspan` di testo. Ciò rende gli ID generati adatti per il post‑processing di una presentazione non modificata.

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

In un [ISvgShapeFormattingController](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshapeformattingcontroller/), chiama [ISvgShape.setEventHandler](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) con un valore [SvgEvent](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Assegna il controller con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) e definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

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

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei utilizzare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgexternalfontshandling/)?**

Utilizza [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) quando tutto il testo deve essere indipendente dai caratteri. Utilizza [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/java/com.aspose.slides/svgexternalfontshandling/) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per rendere un SVG più piccolo?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato hanno ciascuno compromessi diversi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna gli ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o nello script del browser.