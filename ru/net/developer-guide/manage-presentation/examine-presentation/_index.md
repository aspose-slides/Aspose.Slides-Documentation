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
- читать свойства
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
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью .NET для более быстрых выводов и умных проверок содержимого."
---

Aspose.Slides for .NET позволяет изучать презентацию, чтобы узнать её свойства и понять её поведение. 

{{% alert title="Info" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) и [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) содержат свойства и методы, используемые в приведённых ниже операциях. 

{{% /alert %}} 

## **Проверка формата презентации**

Прежде чем работать с презентацией, возможно, вы захотите узнать, в каком формате (PPT, PPTX, ODP и другие) она сейчас находится.  

Вы можете проверить формат презентации без её загрузки. См. следующий код C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Получение свойств презентации**

Этот код C# показывает, как получить свойства презентации (информацию о презентации):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


Возможно, вам понадобится посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), который позволяет вносить изменения в свойства презентации.  

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Этот пример кода показывает, как редактировать некоторые свойства презентации:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа презентации PowerPoint](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её параметрах безопасности, возможно, вам пригодятся следующие ссылки:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только чтение)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты презентации](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите [информацию о встроенных шрифтах](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов в содержимом](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.  

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) и проверьте у каждого слайда [флаг видимости](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).  

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) и ориентацию со стандартными предустановками; это помогает предсказать поведение при печати и экспорте.  

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдите по всем [диаграммам](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.  

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; назначьте приблизительный коэффициент сложности, чтобы отметить потенциальные проблемные места производительности.