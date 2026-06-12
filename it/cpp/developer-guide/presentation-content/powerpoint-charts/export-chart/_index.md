---
title: Esporta i grafici della presentazione in C++
linktitle: Esporta grafico
type: docs
weight: 90
url: /it/cpp/export-chart/
keywords:
- grafico
- grafico in immagine
- grafico come immagine
- estrai immagine del grafico
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come esportare i grafici delle presentazioni con Aspose.Slides per C++, supportando i formati PPT e PPTX, e ottimizzare la generazione di report in qualsiasi flusso di lavoro."
---
## **Panoramica**

Aspose.Slides consente di esportare un grafico da una presentazione come immagine. Questo articolo mostra come ottenere un'immagine da un grafico e salvarla, il che è utile quando è necessario riutilizzare le visualizzazioni dei grafici al di fuori di una presentazione PowerPoint.

## **Ottenere un'immagine del grafico**
Aspose.Slides per C++ offre il supporto per estrarre l'immagine di un grafico specifico. Di seguito è riportato un esempio.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Posso esportare un grafico come vettore (SVG) invece di un'immagine raster?**

Sì. Un grafico è una forma e il suo contenuto può essere salvato in SVG utilizzando il [metodo di salvataggio shape-to-SVG](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/).

**Come posso impostare la dimensione esatta del grafico esportato in pixel?**

Utilizza le sovraccariche di rendering delle immagini che consentono di specificare dimensioni o scala: la libreria supporta il rendering di oggetti con dimensioni/scala specificate.

**Cosa devo fare se i caratteri nelle etichette e nella legenda appaiono errati dopo l'esportazione?**

[Carica i caratteri richiesti](/slides/it/cpp/custom-font/) tramite [FontsLoader](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/) in modo che il rendering del grafico conservi metriche e aspetto del testo.

**L'esportazione rispetta il tema, gli stili e gli effetti di PowerPoint?**

Sì. Il renderer di Aspose.Slides segue la formattazione della presentazione (temi, stili, riempimenti, effetti), quindi l'aspetto del grafico viene preservato.

**Dove posso trovare le capacità di rendering/esportazione disponibili oltre alle immagini dei grafici?**

Consulta la sezione di esportazione dell'[API](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/)/[documentazione](/slides/it/cpp/convert-powerpoint/) per le destinazioni di output ([PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/it/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/it/cpp/convert-powerpoint-to-xps/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/), ecc.) e le relative opzioni di rendering.