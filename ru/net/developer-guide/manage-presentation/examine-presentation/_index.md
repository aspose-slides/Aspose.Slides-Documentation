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
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью .NET для более быстрых инсайтов и более умных аудитов контента."
---

Aspose.Slides for .NET позволяет исследовать презентацию, чтобы узнать её свойства и понять её поведение. 

{{% alert title="Info" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) и [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) содержат свойства и методы, используемые в приведённых ниже операциях.

{{% /alert %}} 

## **Check a Presentation Format**

Прежде чем работать с презентацией, вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и другие) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. См. этот код C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Get Presentation Properties**

Этот код C# демонстрирует, как получить свойства презентации (информацию о презентации):
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


Возможно, вам будет интересно посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Update Presentation Properties**

Aspose.Slides предоставляет метод [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть PowerPoint‑презентация со свойствами документа, показанными ниже.

![Original document properties of the PowerPoint presentation](input_properties.png)

В этом примере кода показано, как отредактировать некоторые свойства презентации:
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

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

Чтобы получить больше информации о презентации и её параметрах безопасности, могут быть полезны следующие ссылки:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Ищите информацию о [embedded-font](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [fonts actually used across content](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.

**How can I quickly tell if the file has hidden slides and how many?**

Пройдитесь по [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) и проверьте у каждой слайда [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/).

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Да. Сравните текущий [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Is there a quick way to see if charts reference external data sources?**

Да. Пройдитесь по всем [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), проверьте их [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимации и мультимедиа; присвойте приблизительный показатель сложности, чтобы выделить потенциальные узкие места производительности.