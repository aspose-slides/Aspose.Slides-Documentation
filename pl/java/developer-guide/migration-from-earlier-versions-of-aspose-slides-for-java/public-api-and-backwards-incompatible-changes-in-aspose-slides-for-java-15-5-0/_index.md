---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 15.5.0
linktitle: Aspose.Slides dla Java 15.5.0
type: docs
weight: 130
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migracja
- starszy kod
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian niekompatybilnych w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) klasy, metody, właściwości itp., wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) wprowadzone w API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Klasa CommonSlideViewProperties oraz interfejs ICommonSlideViewProperties zostały dodane**
Klasa com.aspose.slides.CommonSlideViewProperties (oraz jej interfejs com.aspose.slides.ICommonSlideViewProperties) reprezentuje wspólne właściwości widoku slajdu (obecnie opcje skalowania widoku).
### **Metody IAxis.getLabelOffset(), setLabelOffset(int) zostały dodane**
Metody IAxis.getLabelOffset() i setLabelOffset(int) umożliwiają pobranie oraz określenie odległości etykiet od osi. Stosowane do osi kategorii lub daty.
### **Metody IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) zostały dodane**
Metody getAutofitType() i setAutofitType(/**TextAutofitType**/byte) zostały dodane do interfejsu com.aspose.slides.IChartTextBlockFormat. Zmiana tej wartości może wpływać jedynie na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma wpływu na renderowanie).
### **Metody IChartTextBlockFormat.getWrapText(), setWrapText(byte) zostały dodane**
Metody getWrapText() i setWrapText(/**NullableBool**/byte) zostały dodane do interfejsu com.aspose.slides.IChartTextBlockFormat. Zmiana tej wartości może wpływać jedynie na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2007/2013).
### **Metody zarządzania marginesami zostały dodane do IChartTextBlockFormat**
Metody getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() i setMarginBottom(double) zostały dodane do interfejsu com.aspose.slides.IChartTextBlockFormat. Zmiana tych wartości może wpływać jedynie na następujące elementy wykresu: DataLabel i DataLabelFormat (pełne wsparcie w PowerPoint 2013; w PowerPoint 2007 nie ma wpływu na renderowanie).
### **Metoda ViewProperties.getNotesViewProperties() została dodana**
Właściwość com.aspose.slides.ViewProperties.getNotesViewProperties() została dodana. Zwraca wspólne właściwości widoku powiązane z trybem widoku notatek.
### **Metoda ViewProperties.getSlideViewProperties() została dodana**
Metoda com.aspose.slides.ViewProperties.getSlideViewProperties() została dodana. Zwraca wspólne właściwości widoku powiązane z trybem widoku slajdu.