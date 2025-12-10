---
title: Получить и обновить информацию о презентации в C++
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/cpp/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- исследовать PPTX
- исследовать PPT
- исследовать ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью C++ для более быстрых выводов и более умных аудитов контента."
---

Aspose.Slides for C++ позволяет изучать презентацию, чтобы узнать её свойства и понять её поведение. 

{{% alert title="Info" color="info" %}}

Классы [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) и [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) содержат свойства и методы, используемые в приведённых операциях.

{{% /alert %}} 

## **Проверка формата презентации**

Перед работой с презентацией вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Вы можете проверить формат презентации без её загрузки. См. этот код C++:
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```


## **Получение свойств презентации**

Этот код C++ показывает, как получить свойства презентации (информацию о презентации):
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// и т.д.
```


## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/), который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Original document properties of the PowerPoint presentation](input_properties.png)

Этот пример кода показывает, как отредактировать некоторые свойства презентации:
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


Результаты изменения свойств документа показаны ниже.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Полезные ссылки**

Для получения дополнительной информации о презентации и её параметрах безопасности могут быть полезны следующие ссылки:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию о [embedded-font](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [fonts actually used across content](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, есть ли скрытые слайды и их количество?**

Итерируйте через [slide collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) и проверяйте флаг [visibility](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) каждого слайда.

**Можно ли обнаружить использование пользовательского размера и ориентации слайдов и отличается ли он от стандартных?**

Да. Сравните текущий [slide size and orientation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) со стандартными предустановками; это помогает предсказать поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдите по всем [charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), проверьте их [data source](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), и отметьте, является ли источник данных внутренним или ссылкой, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный балл сложности, чтобы отметить потенциальные узкие места производительности.