---
title: Получить и обновить информацию о презентации на C++
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/cpp/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью C++ для более быстрых выводов и более умных проверок контента."
---
## **Обзор**

Эта статья показывает, как просматривать информацию о презентации в Aspose.Slides. Она объясняет, как определить текущий формат презентации без загрузки полного файла, прочитать её свойства документа и при необходимости обновить эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/documentproperties/) и демонстрируют типичные операции по работе с метаданными презентации.

## **Проверка формата презентации**

Прежде чем работать с презентацией, вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Можно проверить формат презентации без её загрузки. См. следующий код C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationinfo/updatedocumentproperties/), который позволяет вносить изменения в свойства презентации.

Предположим, что у нас есть презентация PowerPoint со следующими свойствами документа.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

Этот пример кода показывает, как изменить некоторые свойства презентации:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Password-Protect Presentations](/slides/ru/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/cpp/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию о [embedded-font](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/getembeddedfonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/getfonts/), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро определить, содержит ли файл скрытые слайды и сколько их?**

Пройдите по [slide collection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slidecollection/) и проверьте [visibility flag](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/get_hidden/) каждого слайда.

**Могу ли я обнаружить использование пользовательского размера и ориентации слайда и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [slide size and orientation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slidesize/) со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдите все [charts](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chart/), проверьте их [data source](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), и отметьте, являются ли данные внутренними или основанными на ссылках, включая любые битые ссылки.

**Как оценить “тяжелые” слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимации и мультимедиа; присвойте приблизительную оценку сложности, чтобы отметить потенциальные узкие места производительности.