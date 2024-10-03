---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 15.5.0
type: docs
weight: 130
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) классов, методов, свойств и так далее, любых новых ограничений и других [изменений](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), введенных с API Aspose.Slides для PHP через Java 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties были добавлены**
Класс com.aspose.slides.CommonSlideViewProperties (и его интерфейс com.aspose.slides.ICommonSlideViewProperties) представляют собой общие свойства представления слайдов (в настоящее время варианты масштаба просмотра).
### **Методы IAxis.getLabelOffset(), setLabelOffset(int) были добавлены**
Методы IAxis.getLabelOffset(), setLabelOffset(int) позволяют получить и указать расстояние меток от оси. Применяется к оси категории или оси дат.
### **Методы IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) были добавлены**
Методы getAutofitType(), setAutofitType(/**TextAutofitType**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может повлиять только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта для рендеринга).
### **Методы IChartTextBlockFormat.getWrapText(), setWrapText(byte) были добавлены**
Методы getWrapText(), setWrapText(/**NullableBool**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этого значения может повлиять только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
### **Методы для управления отступами были добавлены в IChartTextBlockFormat**
Методы getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() и setMarginBottom(double) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.
Изменение этих значений может повлиять только на эти части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта для рендеринга).
### **Метод ViewProperties.getNotesViewProperties() был добавлен**
Свойство com.aspose.slides.ViewProperties.getNotesViewProperties() было добавлено. Оно получает общие свойства представления, связанные с режимом просмотра заметок.
### **Метод ViewProperties.getSlideViewProperties() был добавлен**
Метод com.aspose.slides.ViewProperties.getSlideViewProperties() был добавлен. Он получает общие свойства представления, связанные с режимом просмотра слайда.