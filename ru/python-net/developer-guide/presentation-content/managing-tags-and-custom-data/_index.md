---
title: У管理ивание тегами и пользовательскими данными в презентациях с помощью Python
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/python-net/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- добавить тег
- парные значения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides for Python via .NET, с примерами для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — сохраняются в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

При том, что *слайд* является одним из элементов презентаций, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со множеством других частей — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Теги по сути являются парами строка‑ключ. 

{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Python via .NET для [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **Добавление тегов к презентациям**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства - `MyTag` 
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе определённого правила или свойства, вы можете добавить теги к этим презентациям. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег «North American» и назначить соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) с помощью Aspose.Slides for Python via .NET:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


Теги также могут быть заданы для [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):
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


## **FAQ**

**Можем ли я удалить все теги из презентации, слайда или фигуры за одну операцию?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имен тегов для анализа или фильтрации?**

Вызовите [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) у [коллекции тегов](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); она возвращает массив всех имён тегов.