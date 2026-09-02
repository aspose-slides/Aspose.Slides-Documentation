---
title: Gestire gli oggetti inchiostro della presentazione su Android
linktitle: Gestisci inchiostro
type: docs
weight: 95
url: /it/androidjava/manage-ink/
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
- IInkOptions
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestire gli oggetti inchiostro di PowerPoint, modificare le tracce e le proprietà dei pennelli, e controllare l'aspetto dell'inchiostro durante l'esportazione in PDF, HTML, SVG, TIFF e immagini con Aspose.Slides per Android."
---
## **Introduzione**

PowerPoint fornisce una funzionalità di inchiostro che consente di disegnare tratti liberi. L’inchiostro può essere usato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l’attenzione su elementi specifici di una diapositiva.

Aspose.Slides fornisce i tipi necessari per lavorare con gli oggetti inchiostro. Ad esempio, l’interfaccia [IInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iink/) rappresenta un oggetto inchiostro su una diapositiva.

## **Differenze tra oggetti normali e oggetti inchiostro**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Nella sua forma più semplice, una forma è un contenitore che definisce l’area dell’oggetto stesso (il suo riquadro) insieme a proprietà come la dimensione del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto inchiostro, ignora tutte le proprietà del riquadro dell’oggetto (contenitore) tranne la sua dimensione. La dimensione dell’area del contenitore è determinata dai metodi standard [IShape.getWidth](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getWidth--) e [IShape.getHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di inchiostro**

Una traccia di inchiostro è un elemento di base usato per registrare la traiettoria di una penna mentre l’utente scrive in inchiostro digitale. Una traccia memorizza una sequenza di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ciascun punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un’immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Un pennello è usato per disegnare linee che collegano i punti di una traccia di inchiostro. Il pennello ha il proprio colore e la propria dimensione, rappresentati dai metodi [IInkBrush.getColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkbrush/#getColor--) e [IInkBrush.getSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Impostare il colore del pennello inchiostro**

Questo codice Java mostra come impostare il colore di un pennello inchiostro:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Impostare la dimensione del pennello inchiostro**

Questo codice Java mostra come impostare la dimensione di un pennello inchiostro:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

In generale, la larghezza e l’altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la relativa sezione dei dati è grigio). Quando larghezza e altezza coincidono, PowerPoint mostra la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l’altezza dell’oggetto inchiostro e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non tiene conto della dimensione dei pennelli – presume sempre che lo spessore della linea sia zero (vedi l’immagine precedente).

Pertanto, per determinare l’area visibile dell’intero oggetto inchiostro, è necessario considerare la dimensione del pennello delle sue tracce. Qui l’oggetto di destinazione (la traccia di testo scritto a mano) è stato ridimensionato alla dimensione del contenitore (riquadro). Quando la dimensione del contenitore cambia, la dimensione del pennello rimane costante, e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l’aspetto dell’inchiostro durante l’esportazione e il rendering**

Aspose.Slides fornisce l’interfaccia [IInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/) per controllare come gli oggetti inchiostro appaiono nell’output esportato o renderizzato. È possibile usare le sue proprietà per nascondere completamente l’inchiostro o per modificare il modo in cui le operazioni di maschera del pennello inchiostro sono interpretate.

Le opzioni inchiostro sono disponibili attraverso le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Proprietà opzioni inchiostro |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Immagine diapositiva | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

I seguenti metodi di [IInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/) espongono le stesse due impostazioni:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) determina se gli oggetti inchiostro sono inclusi nell’output. Il valore predefinito è `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) determina se un’operazione di maschera è interpretata come opacità quando si renderizza un pennello inchiostro. Il valore predefinito è `true`; chiamare [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false` per usare l’operazione ROP invece.

### **Nascondere gli oggetti inchiostro nell’output PDF**

Per impostazione predefinita, gli oggetti inchiostro rimangono visibili durante l’esportazione. Per creare un output pulito senza annotazioni scritte a mano o altri contenuti inchiostro, chiamare [IInkOptions.setHideInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true`.

Il seguente esempio Java esporta una presentazione in PDF nascondendo tutti gli oggetti inchiostro:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Nascondere gli oggetti inchiostro durante il rendering di una diapositiva come immagine**

Per nascondere gli oggetti inchiostro durante il rendering delle diapositive come immagini bitmap, configurare [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) e passare le opzioni di rendering a [ISlide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Il seguente esempio Java rende la prima diapositiva come immagine PNG senza oggetti inchiostro:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controllare il rendering della maschera di inchiostro**

L’impostazione [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) controlla come le operazioni di maschera sono interpretate durante il rendering dei pennelli inchiostro. Il valore predefinito è `true`, che utilizza l’opacità. Per usare invece l’operazione ROP, chiamare [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false`.

Il seguente esempio Java esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera inchiostro:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

La stessa impostazione può essere applicata tramite [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) quando si esporta una presentazione o si renderizza una diapositiva in TIFF.

### **Scegliere se nascondere o preservare l’inchiostro**

Quando è necessaria una versione pulita di una presentazione annotata per la distribuzione senza segni di revisione, chiamare [IInkOptions.setHideInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true` durante l’esportazione.

Lasciare [IInkOptions.getHideInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) al valore predefinito `false` quando le annotazioni inchiostro fanno parte del contenuto previsto, ad esempio commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Ciò consente alle applicazioni di generare uscite di revisione e finali separate dalla stessa presentazione senza modificare gli oggetti inchiostro originali.

## **FAQ**

**Posso cambiare il colore o la dimensione di un tratto di inchiostro esistente?**

Sì. Ottieni la traccia da [IInk.getTraces](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iink/#getTraces--), quindi modifica il suo [IInkTrace.getBrush](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinktrace/#getBrush--). Chiama [IInkBrush.setColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) o [IInkBrush.setSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) per cambiare il pennello.

**Nascondere l’inchiostro modifica la presentazione di origine?**

No. Chiamare [IInkOptions.setHideInk](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti inchiostro nella presentazione di origine.

**Quali formati di esportazione supportano le opzioni inchiostro?**

È possibile configurare le opzioni inchiostro per PDF, HTML, SVG, TIFF e immagini bitmap delle diapositive tramite le rispettive opzioni di esportazione o rendering mostrate sopra.

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/androidjava/powerpoint-shapes/).
* Per ulteriori dettagli sui valori effettivi, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Per i dettagli sull’esportazione PDF, vedere [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/it/androidjava/convert-powerpoint-to-pdf/).
* Per i dettagli sull’esportazione HTML, vedere [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/it/androidjava/convert-powerpoint-to-html/).
* Per i dettagli sull’esportazione SVG, vedere [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/it/androidjava/render-a-slide-as-an-svg-image/).
* Per i dettagli sull’esportazione TIFF, vedere [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/it/androidjava/convert-powerpoint-to-tiff/).
* Per i dettagli sul rendering diapositiva‑immagine, vedere [Convert Presentation Slides to Images](https://docs.aspose.com/slides/it/androidjava/convert-slide/).