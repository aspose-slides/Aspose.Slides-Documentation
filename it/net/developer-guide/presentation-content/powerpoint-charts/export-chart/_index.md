---
title: Esporta grafici della presentazione in .NET
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/net/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrai immagine del grafico
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per .NET, supportando i formati PPT e PPTX, e ottimizzare la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides ti consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un’immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual di un grafico al di fuori di una presentazione PowerPoint.

Oltre al flusso di lavoro di esportazione base, l’articolo affronta anche domande comuni legate all’esportazione, inclusa la possibilità di salvare il contenuto del grafico in SVG, il controllo delle dimensioni di output tramite le opzioni di rendering, il caricamento dei font per preservare l’aspetto di etichette e legenda, e il mantenimento della formattazione originale della presentazione come temi, stili, riempimenti ed effetti durante il rendering.

## **Ottieni un’immagine del grafico**
Aspose.Slides per .NET fornisce il supporto per estrarre l’immagine di un grafico specifico. Di seguito è riportato un esempio.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Posso esportare un grafico come vettoriale (SVG) invece che come immagine raster?**

Sì. Un grafico è una forma e i suoi contenuti possono essere salvati in SVG usando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/).

**Come posso impostare le dimensioni esatte del grafico esportato in pixel?**

Usa le sovraccariche di rendering immagine che consentono di specificare dimensioni o scala: la libreria supporta il rendering di oggetti con le dimensioni/scala fornite.

**Cosa devo fare se i font nelle etichette e nella legenda appaiono errati dopo l’esportazione?**

[Carica i font necessari](/slides/it/net/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/) in modo che il rendering del grafico preservi le metriche e l’aspetto del testo.

**L’esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), così l’aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Consulta la sezione di esportazione dell’[API](https://reference.aspose.com/slides/it/net/aspose.slides.export/)/[documentazione](/slides/it/net/convert-powerpoint/) per i target di output ([PDF](/slides/it/net/convert-powerpoint-to-pdf/), [SVG](/slides/it/net/render-a-slide-as-an-svg-image/), [XPS](/slides/it/net/convert-powerpoint-to-xps/), [HTML](/slides/it/net/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.