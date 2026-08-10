---
title: Gestire gli oggetti inchiostro della presentazione in PHP
linktitle: Gestisci Inchiostro
type: docs
weight: 95
url: /it/php-java/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- esportazione inchiostro
- rendering inchiostro
- nascondere inchiostro
- InkOptions
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci gli oggetti inchiostro di PowerPoint, modifica le tracce e le proprietà dei pennelli, e controlla l'aspetto dell'inchiostro durante l'esportazione in PDF, HTML, SVG, TIFF e immagini con Aspose.Slides per PHP via Java."
---
## **Introduzione**

PowerPoint fornisce una funzionalità di inchiostro che consente di disegnare tratti liberi. L'inchiostro può essere usato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici di una diapositiva.

Aspose.Slides fornisce i tipi necessari per lavorare con gli oggetti inchiostro. Ad esempio, la classe [Ink](https://reference.aspose.com/slides/it/php-java/aspose.slides/ink/) rappresenta un oggetto inchiostro su una diapositiva.

## **Differenze tra oggetti normali e oggetti inchiostro**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/). Nella forma più semplice, una forma è un contenitore che definisce l'area dell'oggetto stesso (il suo frame) insieme a proprietà come le dimensioni del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/php-java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto inchiostro, ignora tutte le proprietà del frame dell'oggetto (contenitore) tranne la sua dimensione. Le dimensioni dell'area del contenitore sono determinate dai metodi standard [Shape.getWidth](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getWidth) e [Shape.getHeight](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce d'inchiostro**

Una traccia d'inchiostro è un elemento base utilizzato per registrare la traiettoria di una penna mentre l'utente scrive in inchiostro digitale. Una traccia memorizza una sequenza di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Un pennello è usato per disegnare linee che collegano i punti di una traccia d'inchiostro. Il pennello ha il proprio colore e dimensione, rappresentati dai metodi [InkBrush.getColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkbrush/#getColor) e [InkBrush.getSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkbrush/#getSize).

### **Impostare il colore del pennello d'inchiostro**

Questo codice PHP mostra come impostare il colore di un pennello d'inchiostro:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Impostare la dimensione del pennello d'inchiostro**

Questo codice PHP mostra come impostare la dimensione di un pennello d'inchiostro:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

In generale, la larghezza e l'altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati corrispondente è grigia). Quando larghezza e altezza coincidono, PowerPoint visualizza la dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per maggiore chiarezza, aumentiamo l'altezza dell'oggetto inchiostro e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (frame) non tiene conto della dimensione dei pennelli — assume sempre che lo spessore della linea sia zero (vedi l'immagine precedente).

Pertanto, per determinare l'area visibile dell'intero oggetto inchiostro, deve essere considerata la dimensione del pennello delle sue tracce. Qui, l'oggetto di destinazione (la traccia di testo scritto a mano) è stato scalato alle dimensioni del contenitore (frame). Quando le dimensioni del contenitore cambiano, la dimensione del pennello rimane costante e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti di testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l'aspetto dell'inchiostro durante l'esportazione e il rendering**

Aspose.Slides fornisce la classe [InkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/) per controllare come gli oggetti inchiostro appaiono nell'output esportato o renderizzato. È possibile utilizzare le sue proprietà per nascondere completamente l'inchiostro o modificare il modo in cui le operazioni di maschera del pennello d'inchiostro vengono interpretate.

Le opzioni inchiostro sono disponibili attraverso le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Proprietà delle opzioni inchiostro |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Immagine della diapositiva | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/#getInkOptions) |

I seguenti metodi di [InkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/) espongono le stesse due impostazioni:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#getHideInk) determina se gli oggetti inchiostro sono inclusi nell'output. Il valore predefinito è `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) determina se un'operazione di maschera è interpretata come opacità durante il rendering di un pennello d'inchiostro. Il valore predefinito è `true`; chiamare [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `false` per utilizzare invece l'operazione ROP.

### **Nascondere gli oggetti inchiostro nell'output PDF**

Per impostazione predefinita, gli oggetti inchiostro rimangono visibili durante l'esportazione. Per creare un output pulito senza annotazioni scritte a mano o altri contenuti inchiostro, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#setHideInk) con `true`.

Il seguente esempio PHP esporta una presentazione in PDF nascondendo tutti gli oggetti inchiostro:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Nascondere gli oggetti inchiostro durante il rendering di una diapositiva come immagine**

Per nascondere gli oggetti inchiostro durante il rendering delle diapositive come immagini bitmap, configurare [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/#getInkOptions) e passare le opzioni di rendering a [Slide.getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage).

Il seguente esempio PHP rende la prima diapositiva come immagine PNG senza oggetti inchiostro:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Controllare il rendering della maschera dell'inchiostro**

L'impostazione [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) controlla come le operazioni di maschera sono interpretate durante il rendering dei pennelli d'inchiostro. Il valore predefinito è `true`, che utilizza l'opacità. Per utilizzare invece l'operazione ROP, chiamare [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `false`.

Il seguente esempio PHP esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera dell'inchiostro:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

La stessa impostazione può essere applicata tramite [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/#getInkOptions) quando si esporta una presentazione o si rende una diapositiva in TIFF.

### **Scegliere se nascondere o preservare l'inchiostro**

Quando è necessario una versione pulita di una presentazione annotata per la distribuzione senza segni di revisione, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#setHideInk) con `true` durante l'esportazione.

Lasciare [InkOptions.getHideInk](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#getHideInk) al valore predefinito `false` quando le annotazioni inchiostro fanno parte del contenuto desiderato, ad esempio commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Questo consente alle applicazioni di generare output di revisione e finali separati dalla stessa presentazione senza modificare gli oggetti inchiostro originali.

## **FAQ**

**Posso cambiare colore o dimensione di un tratto d'inchiostro esistente?**

Sì. Ottieni la traccia da [Ink.getTraces](https://reference.aspose.com/slides/it/php-java/aspose.slides/ink/#getTraces), quindi modifica il suo [InkTrace.getBrush](https://reference.aspose.com/slides/it/php-java/aspose.slides/inktrace/#getBrush). Chiama [InkBrush.setColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkbrush/#setColor) o [InkBrush.setSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkbrush/#setSize) per cambiare il pennello.

**Nascondere l'inchiostro modifica la presentazione sorgente?**

No. Chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/php-java/aspose.slides/inkoptions/#setHideInk) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti inchiostro nella presentazione sorgente.

**Quali formati di esportazione supportano le opzioni inchiostro?**

È possibile configurare le opzioni inchiostro per PDF, HTML, SVG, TIFF e immagini bitmap delle diapositive attraverso le relative opzioni di esportazione o rendering mostrate sopra.

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/php-java/powerpoint-shapes/).
* Per maggiori dettagli sui valori effettivi, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/php-java/shape-effective-properties/#get-effective-font-height-value).
* Per dettagli sull'esportazione PDF, vedere [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/it/php-java/convert-powerpoint-to-pdf/).
* Per dettagli sull'esportazione HTML, vedere [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/it/php-java/convert-powerpoint-to-html/).
* Per dettagli sull'esportazione SVG, vedere [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/it/php-java/render-a-slide-as-an-svg-image/).
* Per dettagli sull'esportazione TIFF, vedere [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/it/php-java/convert-powerpoint-to-tiff/).
* Per dettagli sul rendering di diapositive in immagini, vedere [Convert Presentation Slides to Images](https://docs.aspose.com/slides/it/php-java/convert-slide/).