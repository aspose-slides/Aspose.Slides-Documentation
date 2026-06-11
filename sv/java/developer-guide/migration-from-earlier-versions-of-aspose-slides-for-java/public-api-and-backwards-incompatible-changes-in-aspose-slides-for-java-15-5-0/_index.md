---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 15.5.0
linktitle: Aspose.Slides för Java 15.5.0
type: docs
weight: 130
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API‑uppdateringar och brutna förändringar i Aspose.Slides for Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP‑presentationer."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) som införts med Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
Klassen CommonSlideViewProperties och gränssnittet ICommonSlideViewProperties har lagts till

Klassen com.aspose.slides.CommonSlideViewProperties (och dess gränssnitt com.aspose.slides.ICommonSlideViewProperties) representerar gemensamma egenskaper för bildvisning (för närvarande alternativ för vyens skala).
### **IAxis.getLabelOffset(), setLabelOffset(int) methods have been added**
Metoderna IAxis.getLabelOffset() och setLabelOffset(int) har lagts till

Metoderna IAxis.getLabelOffset() och setLabelOffset(int) möjliggör att hämta och ange avståndet för etiketter från axeln. Tillämpas på kategori- eller datumaxel.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) methods have been added**
Metoderna IChartTextBlockFormat.getAutofitType() och setAutofitType(byte) har lagts till

Metoderna getAutofitType() och setAutofitType(/**TextAutofitType**/byte) har lagts till i gränssnittet com.aspose.slides.IChartTextBlockFormat. Ändring av detta värde kan ha viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har det ingen effekt vid rendering).
### **Methods IChartTextBlockFormat.getWrapText(), setWrapText(byte) have been added**
Metoderna IChartTextBlockFormat.getWrapText() och setWrapText(byte) har lagts till

Metoderna getWrapText() och setWrapText(/**NullableBool**/byte) har lagts till i gränssnittet com.aspose.slides.IChartTextBlockFormat. Ändring av detta värde kan ha viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2007/2013).
### **The methods to manage margins have been added to IChartTextBlockFormat**
Metoder för att hantera marginaler har lagts till i IChartTextBlockFormat

Metoderna getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() och setMarginBottom(double) har lagts till i gränssnittet com.aspose.slides.IChartTextBlockFormat. Ändring av dessa värden kan ha viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har det ingen effekt vid rendering).
### **ViewProperties.getNotesViewProperties() method have been added**
Metoden ViewProperties.getNotesViewProperties() har lagts till

Egenskapen com.aspose.slides.ViewProperties.getNotesViewProperties() har lagts till. Den hämtar gemensamma vyegenskaper som är kopplade till notismodet.
### **ViewProperties.getSlideViewProperties() method has been added**
Metoden ViewProperties.getSlideViewProperties() har lagts till

Metoden com.aspose.slides.ViewProperties.getSlideViewProperties() har lagts till. Den hämtar gemensamma vyegenskaper som är kopplade till bildvymodet.