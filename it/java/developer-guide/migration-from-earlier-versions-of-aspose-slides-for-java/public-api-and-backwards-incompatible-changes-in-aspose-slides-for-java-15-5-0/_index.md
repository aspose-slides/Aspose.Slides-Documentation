---
title: API pubblica e modifiche incompatibili all'indietro in Aspose.Slides per Java 15.5.0
linktitle: Aspose.Slides per Java 15.5.0
type: docs
weight: 130
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) , eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introdotte con l'API Aspose.Slides per Java 15.5.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **Classe CommonSlideViewProperties e interfaccia ICommonSlideViewProperties sono state aggiunte**
La classe com.aspose.slides.CommonSlideViewProperties (e la sua interfaccia com.aspose.slides.ICommonSlideViewProperties) rappresenta le proprietà comuni della visualizzazione delle diapositive (attualmente le opzioni di scala della visualizzazione).
### **Metodi IAxis.getLabelOffset() e setLabelOffset(int) sono stati aggiunti**
I metodi IAxis.getLabelOffset() e setLabelOffset(int) consentono di ottenere e specificare la distanza delle etichette dall'asse. Si applicano all'asse di categoria o di data.
### **Metodi IChartTextBlockFormat.getAutofitType() e setAutofitType(byte) sono stati aggiunti**
I metodi getAutofitType() e setAutofitType(/**TextAutofitType**/byte) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questo valore può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha alcun effetto sul rendering).
### **Metodi IChartTextBlockFormat.getWrapText() e setWrapText(byte) sono stati aggiunti**
I metodi getWrapText() e setWrapText(/**NullableBool**/byte) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questo valore può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2007/2013).
### **I metodi per gestire i margini sono stati aggiunti a IChartTextBlockFormat**
I metodi getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() e setMarginBottom(double) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questi valori può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha alcun effetto sul rendering).
### **Metodo ViewProperties.getNotesViewProperties() è stato aggiunto**
La proprietà com.aspose.slides.ViewProperties.getNotesViewProperties() è stata aggiunta. Restituisce le proprietà comuni della visualizzazione associate alla modalità visualizzazione note.
### **Metodo ViewProperties.getSlideViewProperties() è stato aggiunto**
Il metodo com.aspose.slides.ViewProperties.getSlideViewProperties() è stato aggiunto. Restituisce le proprietà comuni della visualizzazione associate alla modalità visualizzazione diapositiva.