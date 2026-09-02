---
title: Получение и обновление информации о презентации в .NET
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/net/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- изучить PPTX
- изучить PPT
- изучить ODP
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью .NET для более быстрых выводов и более умных проверок содержимого."
---
## **Обзор**

В этой статье показано, как просматривать информацию о презентации в Aspose.Slides. Описывается, как определить текущий формат презентации без загрузки полного файла, прочитать её свойства документа и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/documentproperties/) и демонстрируют типичные операции работы с метаданными презентации.

## **Проверка формата презентации**

Прежде чем работать с презентацией, возможно, вы захотите узнать, в каком формате (PPT, PPTX, ODP и другие) она находится в данный момент.

Можно проверить формат презентации без её загрузки. См. пример кода на C#:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Получение свойств презентации**

Этот пример кода на C# показывает, как получить свойства презентации (информацию о презентации):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```

Возможно, вам будет интересно посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/documentproperties/#properties).

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), позволяющий вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Исходные свойства документа PowerPoint‑презентации](input_properties.png)

Этот пример кода показывает, как изменить некоторые свойства презентации:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа PowerPoint‑презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить более подробную информацию о презентации и её параметрах безопасности, вам могут пригодиться следующие ссылки:

- [Презентации с паролем](/slides/ru/net/password-protected-presentation/)
- [Презентации с защитой от записи](/slides/ru/net/write-protected-presentation/)

## **Часто задаваемые вопросы**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию о [встроенных шрифтах](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [шрифтов, реально используемых в содержимом](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для отображения.

**Как быстро определить, есть ли в файле скрытые слайды, и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/ru/net/aspose.slides/slidecollection/) и проверьте у каждого слайда его [флаг видимости](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/hidden/).

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slidesize/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдитесь по всем [диаграммам](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/datasourcetype/), и определите, является ли данные внутренними или ссылочными, включая любые неработающие ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный показатель сложности, чтобы отметить потенциальные узкие места в производительности.