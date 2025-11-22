---
title: "Изучить презентацию"
type: docs
weight: 30
url: /ru/net/examine-presentation/
keywords:
- PowerPoint
- презентация
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- чтение свойств
- изменить свойства
- модифицировать свойства
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "Чтение и изменение свойств презентации PowerPoint на C# или .NET"
---

Aspose.Slides для .NET позволяет исследовать презентацию, чтобы узнать её свойства и понять её поведение. 

{{% alert title="Информация" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) and [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **Проверка формата презентации**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this C# code:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Получение свойств презентации**

This C# code shows you how to get presentation properties (information about the presentation):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) class.

## **Обновление свойств презентации**

Aspose.Slides provides the [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Исходные свойства документа PowerPoint‑презентации](input_properties.png)

This code example shows you how to edit some presentation properties:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


The results of changing the document properties are shown below.

![Изменённые свойства документа PowerPoint‑презентации](output_properties.png)

## **Полезные ссылки**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только для чтения)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, используемого для защиты презентации](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Часто задаваемые вопросы**

**Как проверить, встроены ли шрифты и какие именно?**

Look for [embedded-font information](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) at the presentation level, then compare those entries with the set of [fonts actually used across content](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) to identify which fonts are critical for rendering.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Iterate through the [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) and inspect each slide's [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).

**Могу ли я определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от стандартных?**

Yes. Compare the current [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) and orientation with the standard presets; this helps anticipate behavior for printing and export.

**Есть ли быстрый способ проверить, ссылаются ли диаграммы на внешние источники данных?**

Yes. Traverse all [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), check their [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), and note whether the data is internal or link-based, including any broken links.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

For each slide, tally object counts and look for large images, transparency, shadows, animations, and multimedia; assign a rough complexity score to flag potential performance hotspots.