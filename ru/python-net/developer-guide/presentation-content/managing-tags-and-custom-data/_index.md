---
title: Управление тегами и пользовательскими данными в презентациях на Python
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
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для Python через .NET, с примерами для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с тегами и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные хранятся в файлах PPTX, отмечается, что данные, специфичные для презентации, могут существовать в виде тегов и пользовательских XML‑частей, и теги описываются как парные строки «ключ‑значение».

Также показано, как считывать значения тегов и как добавлять теги в презентацию, отдельный слайд или форму. Кроме того, статья охватывает типичные задачи управления тегами, такие как очистка всех тегов, удаление тега по имени и получение списка имён тегов.

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

*Слайд* является одним из элементов презентаций, а *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные отношения со многими частями — например, пользовательскими тегами — определёнными в ISO/IEC 29500.

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/itagcollection/)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Теги по сути являются парами строк «ключ‑значение». 
{{% /alert %}} 

## **Получение значений тегов**

В Slides тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides for Python via .NET для [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:

- имя пользовательского свойства — `MyTag`
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите собрать все презентации из стран Северной Америки, можно создать тег «North American» и задать в качестве значений соответствующие страны (США, Мексика и Канада).

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) с помощью Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Теги также можно задать для [Slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Или для любой отдельной [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Ограничения**

Теги, добавленные через коллекцию `custom_data.tags`, сохраняются только внутри файла PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, назначенный как тег, нельзя получить из PDF‑файла с тегами.

**Обходное решение**: можно сохранить пользовательский идентификатор в свойстве **Alt Text** объекта (например, `shape.alternative_text = "MyId"`). После экспорта в PDF альтернативный текст может появиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все теги из презентации, слайда или формы одной операцией?**

Да. [tag collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/clear/), которая удаляет все парные ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [remove(name)](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [get_names_of_tags](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/get_names_of_tags/) у [tag collection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.