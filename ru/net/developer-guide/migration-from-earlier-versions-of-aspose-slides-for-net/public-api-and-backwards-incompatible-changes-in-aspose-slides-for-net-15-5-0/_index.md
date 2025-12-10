---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.5.0
linktitle: Aspose.Slides для .NET 15.5.0
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
description: "Обзор обновлений публичного API и разрушительных изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) классы, методы, свойства и т.д., а также другие изменения, внедрённые в API Aspose.Slides для .NET 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties были добавлены**
Класс Aspose.Slides.CommonSlideViewProperties и интерфейс Aspose.Slides.ICommonSlideViewProperties представляют общие свойства просмотра слайдов (в настоящее время параметры масштаба просмотра).
#### **Свойство IAxis.LabelOffset было добавлено**
Свойство IAxis.LabelOffset определяет расстояние меток от оси. Применяется к категориальной или датовой оси.
#### **Свойство IChartTextBlockFormat.AutofitType было добавлено**
Изменение этого свойства может оказывать влияние только на следующие элементы диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффекта при рендеринге нет).
#### **Свойство IChartTextBlockFormat.WrapText было добавлено**
Изменение этого свойства может оказывать влияние только на следующие элементы диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).
#### **Свойства Margin были добавлены в IChartTextBlockFormat**
Изменение этих свойств может оказывать влияние только на следующие элементы диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффекта при рендеринге нет).
#### **Свойство ViewProperties.NotesViewProperties было добавлено**
Свойство Aspose.Slides.ViewProperties.NotesViewProperties было добавлено. Оно определяет общие свойства просмотра, связанные с режимом просмотра заметок.
#### **Свойство ViewProperties.SlideViewProperties было добавлено**
Свойство Aspose.Slides.ViewProperties.SlideViewProperties было добавлено. Оно определяет общие свойства просмотра, связанные с режимом просмотра слайдов.