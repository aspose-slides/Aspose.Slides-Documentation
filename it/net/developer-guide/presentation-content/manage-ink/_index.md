---
title: Gestisci oggetti di inchiostro della presentazione in .NET
linktitle: Gestisci Inchiostro
type: docs
weight: 95
url: /it/net/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia di inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- esportazione inchiostro
- rendering inchiostro
- nascondi inchiostro
- IInkOptions
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci gli oggetti di inchiostro di PowerPoint, modifica le tracce e le proprietà del pennello e controlla l'aspetto dell'inchiostro durante l'esportazione in PDF, HTML, SVG, TIFF e immagine con Aspose.Slides per .NET."
---
## **Introduzione**

PowerPoint fornisce una funzionalità di inchiostro che consente di disegnare tratti liberi. L'inchiostro può essere usato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici in una diapositiva.

Lo spazio dei nomi [Aspose.Slides.Ink](https://reference.aspose.com/slides/it/net/aspose.slides.ink/) contiene le classi e le interfacce necessarie per lavorare con gli oggetti di inchiostro. Ad esempio, l'interfaccia [IInk](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iink/) rappresenta un oggetto di inchiostro su una diapositiva.

## **Differenze tra oggetti regolari e oggetti di inchiostro**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Nella forma più semplice, una forma è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme a proprietà come la dimensione del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/net/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto di inchiostro, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) eccetto la sua dimensione. La dimensione dell'area del contenitore è determinata dalle proprietà standard [IShape.Width](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/width/) e [IShape.Height](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di inchiostro**

Una traccia di inchiostro è un elemento di base usato per registrare la traiettoria di una penna mentre l'utente scrive inchiostro digitale. Una traccia memorizza una sequenza di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Un pennello è usato per disegnare linee che collegano i punti di una traccia di inchiostro. Il pennello ha il proprio colore e la propria dimensione, rappresentati dalle proprietà [IInkBrush.Color](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iinkbrush/color/) e [IInkBrush.Size](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iinkbrush/size/).

### **Imposta colore del pennello di inchiostro**

Questo codice C# mostra come impostare il colore di un pennello di inchiostro:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Imposta dimensione del pennello di inchiostro**

Questo codice C# mostra come impostare la dimensione di un pennello di inchiostro:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati corrispondente è grigia). Quando larghezza e altezza del pennello coincidono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per maggiore chiarezza, aumentiamo l'altezza dell'oggetto di inchiostro e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non tiene conto della dimensione dei pennelli — assume sempre che lo spessore della linea sia zero (vedi l'immagine precedente).

Pertanto, per determinare l'area visibile dell'intero oggetto di inchiostro, è necessario considerare la dimensione del pennello delle sue tracce. Qui, l'oggetto di destinazione (la traccia di testo scritto a mano) è stato scalato alla dimensione del contenitore (riquadro). Quando la dimensione del contenitore cambia, la dimensione del pennello rimane costante, e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti di testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l'aspetto dell'inchiostro durante l'esportazione e il rendering**

Aspose.Slides fornisce l'interfaccia [IInkOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/) per controllare come gli oggetti di inchiostro appaiono nell'output esportato o renderizzato. È possibile usare le sue proprietà per nascondere completamente l'inchiostro o modificare il modo in cui le operazioni di maschera del pennello di inchiostro vengono interpretate.

Le opzioni di inchiostro sono disponibili tramite le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Proprietà opzioni inchiostro |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/it/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/inkoptions/) |

Le stesse due impostazioni sono disponibili attraverso queste proprietà:

- [`HideInk`](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/hideink/) determina se gli oggetti di inchiostro sono inclusi nell'output. Il valore predefinito è `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) determina se un'operazione di maschera è interpretata come opacità durante il rendering di un pennello di inchiostro. Il valore predefinito è `true`; impostalo a `false` per utilizzare l'operazione ROP invece.

### **Nascondi oggetti di inchiostro nell'output PDF**

Per impostazione predefinita, gli oggetti di inchiostro rimangono visibili durante l'esportazione. Imposta [IInkOptions.HideInk](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/hideink/) a `true` quando è necessario un output pulito senza annotazioni scritte a mano o altri contenuti di inchiostro.

Il seguente esempio C# esporta una presentazione in PDF nascondendo tutti gli oggetti di inchiostro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Nascondi oggetti di inchiostro durante il rendering di una diapositiva come immagine**

Per nascondere gli oggetti di inchiostro durante il rendering di diapositive come immagini bitmap, configura [RenderingOptions.InkOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/inkoptions/) e passa le opzioni di rendering al metodo [ISlide.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/).

Il seguente esempio C# rende la prima diapositiva come immagine PNG senza oggetti di inchiostro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Controllare il rendering della maschera di inchiostro**

La proprietà [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) controlla come le operazioni di maschera sono interpretate quando si renderizzano i pennelli di inchiostro. Il valore predefinito è `true`, che utilizza l'opacità. Imposta la proprietà a `false` per usare l'operazione ROP invece.

Il seguente esempio C# esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera di inchiostro:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

La stessa impostazione può essere applicata tramite [TiffOptions.InkOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/inkoptions/) quando si esporta una presentazione o si renderizza una diapositiva in TIFF.

### **Scegliere se nascondere o conservare l'inchiostro**

Usa [IInkOptions.HideInk](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/hideink/) impostato a `true` quando il file esportato deve essere una versione pulita di una presentazione annotata, ad esempio una copia finale destinata alla distribuzione senza segni di revisione.

Lascia [IInkOptions.HideInk](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/hideink/) al suo valore predefinito `false` quando le annotazioni di inchiostro fanno parte del contenuto previsto, come commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Ciò consente alle applicazioni di generare output di revisione e finali separati dalla stessa presentazione senza modificare gli oggetti di inchiostro di origine.

## **FAQ**

**Posso cambiare il colore o la dimensione di un tratto di inchiostro esistente?**

Sì. Ottieni la traccia da [IInk.Traces](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iink/traces/), quindi modifica il suo [IInkTrace.Brush](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iinktrace/brush/). Puoi impostare le proprietà [IInkBrush.Color](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iinkbrush/color/) e [IInkBrush.Size](https://reference.aspose.com/slides/it/net/aspose.slides.ink/iinkbrush/size/).

**Nascondere l'inchiostro cambia la presentazione di origine?**

No. [IInkOptions.HideInk](https://reference.aspose.com/slides/it/net/aspose.slides.export/iinkoptions/hideink/) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti di inchiostro nella presentazione di origine.

**Quali formati di esportazione supportano le opzioni di inchiostro?**

Puoi configurare le opzioni di inchiostro per PDF, HTML, SVG, TIFF e immagini bitmap di diapositive tramite le opzioni di esportazione o rendering corrispondenti mostrate sopra.

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/net/powerpoint-shapes/).
* Per ulteriori dettagli sui valori effettivi, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/net/shape-effective-properties/#get-effective-font-height-value).
* Per i dettagli sull'esportazione PDF, vedere [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/it/net/convert-powerpoint-to-pdf/).
* Per i dettagli sull'esportazione HTML, vedere [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/it/net/convert-powerpoint-to-html/).
* Per i dettagli sull'esportazione SVG, vedere [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/it/net/render-a-slide-as-an-svg-image/).
* Per i dettagli sull'esportazione TIFF, vedere [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/it/net/convert-powerpoint-to-tiff/).
* Per i dettagli sul rendering di diapositive in immagine, vedere [Convert Presentation Slides to Images](https://docs.aspose.com/slides/it/net/convert-slide/).