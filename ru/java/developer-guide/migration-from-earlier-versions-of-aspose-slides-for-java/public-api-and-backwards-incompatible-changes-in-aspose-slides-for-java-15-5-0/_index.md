---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для Java 15.5.0
type: docs
weight: 130
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) классов, методов, свойств и так далее, любых новых ограничений и других [изменений](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), введенных в API Aspose.Slides для Java 15.5.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлен класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties**
Класс com.aspose.slides.CommonSlideViewProperties (и его интерфейс com.aspose.slides.ICommonSlideViewProperties) представляет собой общие свойства представления слайдов (в настоящее время параметры масштабирования представления).
### **Добавлены методы IAxis.getLabelOffset(), setLabelOffset(int)**
Методы IAxis.getLabelOffset(), setLabelOffset(int) позволяют получать и устанавливать расстояние меток от оси. Применяются к категории или оси дат.
### **Добавлены методы IChartTextBlockFormat.getAutofitType(), setAutofitType(byte)**
Методы getAutofitType(), setAutofitType(/**TextAutofitType**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может оказать определенное влияние только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта для рендеринга).
### **Добавлены методы IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Методы getWrapText(), setWrapText(/**NullableBool**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может оказать определенное влияние только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
### **Методы управления полями добавлены в IChartTextBlockFormat**
Методы getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() и setMarginBottom(double) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этих значений может оказать определенное влияние только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта для рендеринга).
### **Метод ViewProperties.getNotesViewProperties() добавлен**
Свойство com.aspose.slides.ViewProperties.getNotesViewProperties() было добавлено. Оно получает общие свойства представления, связанные с режимом просмотра заметок.
### **Метод ViewProperties.getSlideViewProperties() добавлен**
Метод com.aspose.slides.ViewProperties.getSlideViewProperties() был добавлен. Он получает общие свойства представления, связанные с режимом просмотра слайдов.