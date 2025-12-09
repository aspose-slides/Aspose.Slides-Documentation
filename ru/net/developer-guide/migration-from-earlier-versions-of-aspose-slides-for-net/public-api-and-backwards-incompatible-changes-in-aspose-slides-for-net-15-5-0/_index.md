---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides for .NET 15.5.0
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides for .NET для плавной миграции ваших решений для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

На этой странице перечислены все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 15.5.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлены класс CommonSlideViewProperties и интерфейс ICommonSlideViewProperties**
Класс Aspose.Slides.CommonSlideViewProperties и интерфейс Aspose.Slides.ICommonSlideViewProperties представляют общие свойства просмотра слайда (в настоящее время параметры масштаба просмотра).

#### **Добавлено свойство IAxis.LabelOffset**
Свойство IAxis.LabelOffset задаёт расстояние меток от оси. Применяется к категориальной или датовой оси.

#### **Добавлено свойство IChartTextBlockFormat.AutofitType**
Изменение этого свойства может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффект при рендеринге отсутствует).

#### **Добавлено свойство IChartTextBlockFormat.WrapText**
Изменение этого свойства может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2007/2013).

#### **К свойствам IChartTextBlockFormat добавлены свойства отступов**
Изменение этих свойств может оказывать влияние только на следующие части диаграммы: DataLabel и DataLabelFormat (полная поддержка в PowerPoint 2013; в PowerPoint 2007 эффект при рендеринге отсутствует).

#### **Добавлено свойство ViewProperties.NotesViewProperties**
Свойство Aspose.Slides.ViewProperties.NotesViewProperties добавлено. Оно задаёт общие свойства просмотра, связанные с режимом просмотра заметок.

#### **Добавлено свойство ViewProperties.SlideViewProperties**
Свойство Aspose.Slides.ViewProperties.SlideViewProperties добавлено. Оно задаёт общие свойства просмотра, связанные с режимом просмотра слайда.