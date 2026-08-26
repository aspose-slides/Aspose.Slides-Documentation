---
title: Получение и обновление информации о презентации в Python
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/python-net/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Python для более быстрых инсайтов и более умных аудитов контента."
---
## **Обзор**

В этой статье показано, как просматривать информацию о презентации в Aspose.Slides. Описывается, как определить текущий формат презентации без загрузки полного файла, читать её свойства документа и при необходимости обновлять эти свойства.

Примеры основаны на API [PresentationInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/) и демонстрируют типичные операции работы с метаданными презентации.

## **Проверка формата презентации**

Прежде чем работать с презентацией, вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Можно проверить формат презентации без её загрузки. См. следующий код на Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Получение свойств презентации**

Этот код на Python показывает, как получить свойства презентации (информацию о презентации):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Вы также можете посмотреть [properties under the DocumentProperties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/documentproperties/#properties) класс.

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), позволяющий вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со свойствами документа, показанными ниже.

![Original document properties of the PowerPoint presentation](input_properties.png)

Этот пример кода показывает, как отредактировать некоторые свойства презентации:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Результаты изменения свойств документа показаны ниже.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Полезные ссылки**

Чтобы получить больше информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Password-Protect Presentations](/slides/ru/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/python-net/write-protected-presentation/)

## **FAQ**

**Как проверить, внедрены ли шрифты и какие именно?**

Ищите информацию о [embedded-font information](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) на уровне презентации, затем сравните эти записи с набором [fonts actually used across content](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_fonts/), чтобы определить, какие шрифты критичны для рендеринга.

**Как быстро узнать, есть ли скрытые слайды и сколько их?**

Пройдитесь по [slide collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/) и проверьте [visibility flag](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/hidden/) каждого слайда.

**Можно ли обнаружить, используются ли пользовательские размеры и ориентация слайдов, и отличаются ли они от стандартных?**

Да. Сравните текущий [slide size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slide_size/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдитесь по всем [charts](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/), проверьте их [data source](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/), и обратите внимание, является ли источник внутренним или связанным, включая любые неисправные ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите большие изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный коэффициент сложности, чтобы отметить потенциальные узкие места производительности.