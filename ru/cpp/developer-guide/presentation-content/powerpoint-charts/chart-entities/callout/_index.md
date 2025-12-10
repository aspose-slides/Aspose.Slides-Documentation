---
title: Управление подсказками в диаграммах презентаций с использованием С++
linktitle: Подсказка
type: docs
url: /ru/cpp/callout/
keywords:
- подсказка диаграммы
- использовать подсказку
- метка данных
- формат метки
- PowerPoint
- презентация
- С++
- Aspose.Slides
description: "Создавайте и оформляйте подсказки в Aspose.Slides для С++ с краткими примерами кода, совместимыми с PPT и PPTX, чтобы автоматизировать рабочие процессы презентаций."
---

## **Использование Callouts**
В класс **DataLabelFormat** и интерфейс **IDataLabelFormat** добавлено новое свойство **ShowLabelAsDataCallout**, которое определяет, будет ли метка данных указанной диаграммы отображаться как подсказка данных или как метка данных. В приведённом ниже примере мы установили Callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Установить Callout для кольцевой диаграммы**
Aspose.Slides for C++ поддерживает возможность задавать форму подсказки метки данных серии для кольцевой диаграммы. Ниже приведён пример.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Yes. Callouts are part of the chart rendering, so when you export to [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/ru/cpp/export-to-html5/), [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/), or [raster images](/slides/ru/cpp/convert-powerpoint-to-png/), they are preserved together with the slide’s formatting.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Yes. Aspose.Slides supports [embedding fonts](/slides/ru/cpp/embedded-font/) into the presentation and controls font embedding during exports such as [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), ensuring the callouts look the same across different systems.