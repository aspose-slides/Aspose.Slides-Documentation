---
title: Esporta grafici delle presentazioni in Python tramite Java
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/python-java/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrarre immagine del grafico
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per Python tramite Java, supportando i formati PPT e PPTX, e semplifica la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un’immagine da un grafico e salvarla, utile quando è necessario riutilizzare i visual del grafico al di fuori di una presentazione PowerPoint.

Oltre al flusso di lavoro di esportazione dell’immagine di base, l’articolo affronta anche domande comuni relative all’esportazione, tra cui il salvataggio del contenuto del grafico in SVG, il controllo della dimensione dell’output tramite opzioni di rendering, il caricamento dei font per preservare l’aspetto delle etichette e della leggenda, e il mantenimento della formattazione originale della presentazione, come temi, stili, riempimenti ed effetti, durante il rendering.

## **Ottieni un’immagine del grafico**
Aspose.Slides for Python via Java supporta l’estrazione di un’immagine di un grafico specifico. L’esempio seguente dimostra come farlo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Posso esportare un grafico come vettoriale (SVG) anziché come immagine raster?**

Sì. Un grafico è una forma, e il suo contenuto può essere salvato in SVG usando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Come posso impostare la dimensione esatta del grafico esportato in pixel?**

Utilizza le overload di rendering dell’immagine che consentono di specificare dimensione o scala: la libreria supporta il rendering degli oggetti con dimensioni o scala specificate.

**Cosa devo fare se i font nelle etichette e nella leggenda appaiono errati dopo l’esportazione?**

[Carica i font richiesti](/slides/it/python-java/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsloader/) così il rendering del grafico preserva metriche e aspetto del testo.

**L’esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l’aspetto del grafico viene conservato.

**Dove posso trovare le funzionalità di rendering/esportazione disponibili oltre le immagini dei grafici?**

Consulta l'[API](https://reference.aspose.com/slides/it/python-java/aspose.slides/)/[documentazione](/slides/it/python-java/convert-powerpoint/) per i formati di destinazione ([PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/it/python-java/convert-powerpoint-to-xps/), [HTML](/slides/it/python-java/convert-powerpoint-to-html/), ecc.) e le opzioni di rendering correlate.