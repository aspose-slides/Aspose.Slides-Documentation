---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introdotte con l'API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
### **È stata aggiunta la classe CommonSlideViewProperties e l'interfaccia ICommonSlideViewProperties**
La classe com.aspose.slides.CommonSlideViewProperties (e la sua interfaccia com.aspose.slides.ICommonSlideViewProperties) rappresentano le proprietà comuni di visualizzazione della diapositiva (attualmente le opzioni di scala della visualizzazione).
### **Sono stati aggiunti i metodi IAxis.getLabelOffset() e setLabelOffset(int)**
I metodi IAxis.getLabelOffset() e setLabelOffset(int) consentono di ottenere e specificare la distanza delle etichette dall'asse. Applicabili a un asse di categoria o di data.
### **Sono stati aggiunti i metodi IChartTextBlockFormat.getAutofitType() e setAutofitType(byte)**
I metodi getAutofitType() e setAutofitType(/**TextAutofitType**/byte) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questo valore può influire solo sui seguenti componenti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non vi è alcun effetto di rendering).
### **Sono stati aggiunti i metodi IChartTextBlockFormat.getWrapText() e setWrapText(byte)**
I metodi getWrapText() e setWrapText(/**NullableBool**/byte) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questo valore può influire solo sui seguenti componenti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2007/2013).
### **Sono stati aggiunti i metodi per gestire i margini a IChartTextBlockFormat**
I metodi getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() e setMarginBottom(double) sono stati aggiunti all'interfaccia com.aspose.slides.IChartTextBlockFormat. La modifica di questi valori può influire solo sui seguenti componenti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non vi è alcun effetto di rendering).
### **È stato aggiunto il metodo ViewProperties.getNotesViewProperties()**
È stata aggiunta la proprietà com.aspose.slides.ViewProperties.getNotesViewProperties(). Restituisce le proprietà comuni di visualizzazione associate alla modalità visualizzazione note.
### **È stato aggiunto il metodo ViewProperties.getSlideViewProperties()**
È stato aggiunto il metodo com.aspose.slides.ViewProperties.getSlideViewProperties(). Restituisce le proprietà comuni di visualizzazione associate alla modalità visualizzazione diapositiva.