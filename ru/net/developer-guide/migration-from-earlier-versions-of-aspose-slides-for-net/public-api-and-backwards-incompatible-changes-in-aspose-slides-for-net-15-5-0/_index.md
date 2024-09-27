---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.5.0
type: docs
weight: 160
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) или [удаленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) классы, методы, свойства и так далее, а также другие изменения, введенные в API Aspose.Slides для .NET 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties**
Класс Aspose.Slides.CommonSlideViewProperties и интерфейс Aspose.Slides.ICommonSlideViewProperties представляют общие свойства представления слайдов (в настоящее время параметры масштабирования представления).
#### **Добавлено свойство IAxis.LabelOffset**
Свойство IAxis.LabelOffset указывает расстояние меток от оси. Применяется к категориальной или временной оси.
#### **Добавлено свойство IChartTextBlockFormat.AutofitType**
Изменение этого свойства может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта от рендеринга).
#### **Добавлено свойство IChartTextBlockFormat.WrapText**
Изменение этого свойства может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
#### **Свойства Margin были добавлены в IChartTextBlockFormat**
Изменение этих свойств может оказать определенное влияние только на эти части графика: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 нет эффекта от рендеринга).
#### **Добавлено свойство ViewProperties.NotesViewProperties**
Свойство Aspose.Slides.ViewProperties.NotesViewProperties было добавлено. Оно указывает общие свойства представления, связанные с режимом просмотра заметок.
#### **Добавлено свойство ViewProperties.SlideViewProperties**
Свойство Aspose.Slides.ViewProperties.SlideViewProperties было добавлено. Оно указывает общие свойства представления, связанные с режимом просмотра слайда.