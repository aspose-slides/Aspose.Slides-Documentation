---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 15.11.0
linktitle: Aspose.Slides per Java 15.11.0
type: docs
weight: 190
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutti gli [added](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) o [removed](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) classi, metodi, proprietà e così via, e le altre modifiche introdotte con l'API di Aspose.Slides per Java 15.11.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Metodi obsoleti nella classe com.aspose.slides.DataLabelCollection sono stati eliminati**
I metodi obsoleti nella classe com.aspose.slides.DataLabelCollection sono stati eliminati:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Sono stati aggiunti i nuovi metodi getFirstSlideNumber() e setFirstSlideNumber() alla classe Presentation**
I nuovi metodi getFirstSlideNumber() e setFirstSlideNumber() consentono di ottenere o impostare il numero della prima diapositiva in una presentazione. Quando viene specificato un nuovo valore per il numero della prima diapositiva, tutti i numeri delle diapositive vengono ricalcolati.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```