---
title: Получить и обновить информацию о презентации в Python
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/python-net/examine-presentation/
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
- Python
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Python для более быстрых инсайтов и умных проверок контента."
---

Aspose.Slides for Python via .NET позволяет исследовать презентацию, чтобы узнать её свойства и понять её поведение.

{{% alert title="Информация" color="info" %}} 

Классы [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) и [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) содержат свойства и методы, используемые в приведённых ниже операциях.

{{% /alert %}} 

## **Проверка формата презентации**

Прежде чем работать с презентацией, вы можете захотеть узнать, в каком формате (PPT, PPTX, ODP и др.) она находится в данный момент.

Вы можете определить формат презентации без её загрузки. См. этот пример кода на Python:

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

Этот пример кода на Python показывает, как получить свойства презентации (информацию о презентации):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Возможно, вы захотите посмотреть [свойства в классе DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Обновление свойств презентации**

Aspose.Slides предоставляет метод [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), который позволяет вносить изменения в свойства презентации.

Предположим, у нас есть презентация PowerPoint со следующими свойствами документа.

![Исходные свойства документа презентации PowerPoint](input_properties.png)

Этот пример кода показывает, как отредактировать некоторые свойства презентации:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Результаты изменения свойств документа показаны ниже.

![Изменённые свойства документа презентации PowerPoint](output_properties.png)

## **Полезные ссылки**

Для получения дополнительной информации о презентации и её атрибутах безопасности, могут быть полезны следующие ссылки:

- [Проверка, зашифрована ли презентация](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Проверка, защищена ли презентация от записи (только чтение)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Проверка, защищена ли презентация паролем перед загрузкой](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Подтверждение пароля, использованного для защиты презентации](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Ищите информацию об [встроенных шрифтах](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) на уровне презентации, затем сравните эти записи с набором [фактически используемых шрифтов](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/), чтобы определить, какие шрифты критичны для отображения.

**Как быстро узнать, есть ли скрытые слайды и их количество?**

Пройдитесь по [коллекции слайдов](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) и проверьте флаг [видимости каждого слайда](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/).

**Можно ли определить, используются ли пользовательские размеры и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Сравните текущий [размер слайда](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) и ориентацию со стандартными предустановками; это помогает предвидеть поведение при печати и экспорте.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Пройдитесь по всем [диаграммам](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), проверьте их [источник данных](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), и отметьте, являются ли данные внутренними или ссылочными, включая любые битые ссылки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Для каждого слайда подсчитайте количество объектов и ищите крупные изображения, прозрачность, тени, анимацию и мультимедиа; присвойте приблизительный коэффициент сложности, чтобы выделить потенциальные узкие места производительности.