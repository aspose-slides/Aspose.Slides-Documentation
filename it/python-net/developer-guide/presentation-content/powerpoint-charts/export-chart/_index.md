---
title: Esporta i grafici della presentazione con Python
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/python-net/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrarre immagine del grafico
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per Python via .NET, supportando i formati PPT, PPTX e ODP, e semplifica la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un'immagine da un grafico e salvarla, utile quando è necessario riutilizzare le visualizzazioni del grafico al di fuori di una presentazione PowerPoint.

## **Ottieni immagine del grafico**
Aspose.Slides per Python via .NET fornisce il supporto per estrarre l'immagine di un grafico specifico. Di seguito è riportato un esempio.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Posso esportare un grafico come vettoriale (SVG) invece di un'immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG utilizzando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/write_as_svg/).

**Come posso impostare le dimensioni esatte del grafico esportato in pixel?**

Utilizza le sovraccariche di rendering immagine che consentono di specificare la dimensione o la scala: la libreria supporta il rendering di oggetti con le dimensioni o la scala specificate.

**Cosa devo fare se i caratteri nelle etichette e nella legenda appaiono errati dopo l'esportazione?**

[Carica i caratteri richiesti](/slides/it/python-net/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsloader/) in modo che il rendering del grafico preservi metriche e aspetto del testo.

**L'esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l'aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Consulta la sezione di esportazione dell'[API](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/)/[documentazione](/slides/it/python-net/convert-powerpoint/) per i formati di output ([PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/it/python-net/convert-powerpoint-to-xps/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/), ecc.) e le opzioni di rendering correlate.