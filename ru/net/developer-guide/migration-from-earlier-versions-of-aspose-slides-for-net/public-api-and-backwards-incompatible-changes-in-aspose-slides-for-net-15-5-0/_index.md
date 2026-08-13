---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 15.5.0
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

На этой странице перечислены все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлены класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties**
Класс Aspose.Slides.CommonSlideViewProperties и интерфейс Aspose.Slides.ICommonSlideViewProperties представляют общие свойства отображения слайдов (в настоящее время параметры масштабирования представления).
#### **Добавлено свойство IAxis.LabelOffset**
Свойство IAxis.LabelOffset указывает расстояние меток от оси. Применяется к категориальной или датированной оси.
#### **Добавлено свойство IChartTextBlockFormat.AutofitType**
Изменение этого свойства может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффект при рендеринге отсутствует).
#### **Добавлено свойство IChartTextBlockFormat.WrapText**
Изменение этого свойства может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
#### **К свойствам IChartTextBlockFormat добавлены свойства отступов**
Изменение этих свойств может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффект при рендеринге отсутствует).
#### **Добавлено свойство ViewProperties.NotesViewProperties**
Свойство Aspose.Slides.ViewProperties.NotesViewProperties было добавлено. Оно определяет общие свойства представления, связанные с режимом просмотра заметок.
#### **Добавлено свойство ViewProperties.SlideViewProperties**
Свойство Aspose.Slides.ViewProperties.SlideViewProperties было добавлено. Оно определяет общие свойства представления, связанные с режимом просмотра слайда.