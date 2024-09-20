---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.5.0
type: docs
weight: 130
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), введенные с API Aspose.Slides для Java 15.5.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties добавлены**
Класс com.aspose.slides.CommonSlideViewProperties (и его интерфейс com.aspose.slides.ICommonSlideViewProperties) представляет собой общие свойства представления слайдов (в настоящее время параметры масштаба представления).
### **Добавлены методы IAxis.getLabelOffset(), setLabelOffset(int)**
Методы IAxis.getLabelOffset(), setLabelOffset(int) позволяют получать и указывать расстояние меток от оси. Применяются к категории или временной оси.
### **Добавлены методы IChartTextBlockFormat.getAutofitType(), setAutofitType(byte)**
Методы getAutofitType(), setAutofitType(/**TextAutofitType**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 влияние на отображение отсутствует).
### **Добавлены методы IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Методы getWrapText(), setWrapText(/**NullableBool**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
### **Методы для управления полями добавлены в IChartTextBlockFormat**
Методы getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() и setMarginBottom(double) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этих значений может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 влияние на отображение отсутствует).
### **Добавлен метод ViewProperties.getNotesViewProperties()**
Свойство com.aspose.slides.ViewProperties.getNotesViewProperties() было добавлено. Оно получает общие свойства представления, связанные с режимом просмотра заметок.
### **Добавлен метод ViewProperties.getSlideViewProperties()**
Метод com.aspose.slides.ViewProperties.getSlideViewProperties() был добавлен. Он получает общие свойства представления, связанные с режимом просмотра слайдов.