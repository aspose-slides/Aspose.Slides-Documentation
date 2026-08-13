---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides for Java для плавной миграции ваших решений презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) введённые в API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties добавлены**
Класс com.aspose.slides.CommonSlideViewProperties (и его интерфейс com.aspose.slides.ICommonSlideViewProperties) представляет общие свойства просмотра слайда (в настоящее время параметры масштаба просмотра).
### **Методы IAxis.getLabelOffset() и setLabelOffset(int) добавлены**
Методы IAxis.getLabelOffset() и setLabelOffset(int) позволяют получить и задать расстояние меток от оси. Применяется к категории или датовой оси.
### **Методы IChartTextBlockFormat.getAutofitType() и setAutofitType(byte) добавлены**
Методы getAutofitType() и setAutofitType(/**TextAutofitType**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.  
Изменение этого значения может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта при рендеринге).
### **Методы IChartTextBlockFormat.getWrapText() и setWrapText(byte) добавлены**
Методы getWrapText() и setWrapText(/**NullableBool**/byte) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.  
Изменение этого значения может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
### **Методы управления полями добавлены в IChartTextBlockFormat**
Методы getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() и setMarginBottom(double) были добавлены в интерфейс com.aspose.slides.IChartTextBlockFormat.  
Изменение этих значений может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта при рендеринге).
### **Метод ViewProperties.getNotesViewProperties() добавлен**
Свойство com.aspose.slides.ViewProperties.getNotesViewProperties() было добавлено. Оно получает общие свойства просмотра, связанные с режимом просмотра заметок.
### **Метод ViewProperties.getSlideViewProperties() добавлен**
Метод com.aspose.slides.ViewProperties.getSlideViewProperties() был добавлен. Он получает общие свойства просмотра, связанные с режимом просмотра слайда.