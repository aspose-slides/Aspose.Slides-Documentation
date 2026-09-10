---
title: Personalizza i grafici a ciambella nelle presentazioni usando Python via Java
linktitle: Grafico a ciambella
type: docs
weight: 30
url: /it/python-java/doughnut-chart/
keywords:
- grafico a ciambella
- spazio centrale
- dimensione del foro
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come creare e personalizzare i grafici a ciambella in Aspose.Slides per Python via Java, supportando i formati PowerPoint per presentazioni dinamiche."
---
## **Panoramica**

Questo articolo mostra come lavorare con un grafico a ciambella in Aspose.Slides aggiungendo il grafico a una diapositiva, impostando la dimensione del foro centrale e salvando la presentazione. Si concentra sul metodo [setDoughnutHoleSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) e dimostra i passaggi di base necessari per personalizzare questo tipo di grafico nel codice.

Include anche una breve FAQ che copre scenari correlati ai grafici a ciambella, come l'uso di più serie per creare più anelli, lavorare con grafici a ciambella esplosi e esportare un grafico come immagine raster o SVG.

## **Specificare lo spazio centrale in un grafico a ciambella**

{{% alert color="info" title="Nota" %}}
Aspose.Slides per Python via Java supporta la specifica della dimensione del foro in un grafico a ciambella. Questa sezione dimostra come impostare la dimensione del foro con un esempio.
{{% /alert %}}

Per specificare la dimensione del foro in un grafico a ciambella, seguire questi passaggi:

1. Istanziare un oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Aggiungere un grafico a ciambella alla diapositiva.
1. Specificare la dimensione del foro nel grafico a ciambella.
1. Scrivere la presentazione su disco.

L'esempio seguente imposta la dimensione del foro in un grafico a ciambella.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Scrivi la presentazione su disco.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso creare una ciambella a più livelli con più anelli?**

Sì. Aggiungere più serie a un singolo grafico a ciambella—ogni serie diventa un anello separato. L'ordine degli anelli è determinato dall'ordine delle serie nella raccolta.

**È supportata una ciambella “esplosa” (fette separate)?**

Sì. Esiste un [tipo di grafico](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/) a ciambella esplosa e una proprietà di esplosione sui punti dati; è possibile separare le singole fette.

**Come posso ottenere un'immagine di un grafico a ciambella (PNG/SVG) per un report?**

Un grafico è una [forma](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/); è possibile renderizzarlo in una [immagine raster](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) o esportare il grafico in un'immagine SVG.