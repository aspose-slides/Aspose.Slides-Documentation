---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /ru/python-net/managing-tags-and-custom-data/
keywords: "Теги, Пользовательские данные, Значение для тегов, Добавить теги, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление тегов и пользовательских данных к презентациям PowerPoint на Python"
---

## Хранение данных в файлах презентаций

Файлы PPTX — это элементы с расширением .pptx, которые хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд является одним из элементов презентаций, а *часть слайда* содержит содержание единственного слайда. Части слайда могут иметь явные связи со многими частями, такими как пользовательские определенные теги, определяемые ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователя могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Теги по сути представляют собой пары значений с ключом в виде строки. 

{{% /alert %}} 

## Получение значений тегов

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот образец кода показывает, как получить значение тега с помощью Aspose.Slides для Python через .NET для [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## Добавление тегов в презентации

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имени пользовательского свойства - `MyTag` 
- значения пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе конкретного правила или свойства, вы можете извлечь выгоду от добавления тегов к этим презентациям. Например, если вы хотите категоризовать или объединить все презентации из стран Северной Америки, вы можете создать тег для Северной Америки и затем назначить соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот образец кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) с помощью Aspose.Slides для Python через .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Теги также могут быть установлены для [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Или для любой отдельной [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```