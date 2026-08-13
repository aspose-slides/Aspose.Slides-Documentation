---
title: API Pubblica e Modifiche Incompatibili Retroattive in Aspose.Slides per Java 15.7.0
linktitle: Aspose.Slides per Java 15.7.0
type: docs
weight: 150
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutti i classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) o [rimosse](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per Java 15.7.0.

{{% /alert %}} 
## **Modifiche all'API Pubblica**
#### **Enum com.aspose.slides.ImagePixelFormat è stato aggiunto**
Enum com.aspose.slides.ImagePixelFormat è stato aggiunto per specificare il formato pixel per le immagini generate.
#### **Il metodo com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() è stato aggiunto**
Questo metodo restituisce un colore automatico del punto dati basato su indice della serie, indice del punto dati, parentSeriesGroup, valori isColorVaried e stile del grafico. Questo colore è utilizzato per impostazione predefinita se fillType è uguale a NotDefined.
#### **I metodi getPixelFormat(), setPixelFormat(int) sono stati aggiunti a com.aspose.slides.ITiffOptions**
I metodi getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) sono stati aggiunti a com.aspose.slides.ITiffOptions e com.aspose.slides.TiffOptions per specificare il formato pixel per le immagini TIFF generate.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```