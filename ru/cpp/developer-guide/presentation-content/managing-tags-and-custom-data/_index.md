---
title: Управление тегами и пользовательскими данными в презентациях с использованием C++
linktitle: Теги и пользовательские данные
type: docs
weight: 300
url: /ru/cpp/managing-tags-and-custom-data/
keywords:
- свойства документа
- тег
- пользовательские данные
- добавить тег
- парные значения
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавлять, читать, обновлять и удалять теги и пользовательские данные в Aspose.Slides для C++ с примерами для презентаций PowerPoint и OpenDocument."
---

## **Хранение данных в файлах презентаций**

Файлы PPTX — объекты с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Поскольку *слайд* является одним из элементов презентации, *часть слайда* содержит содержимое отдельного слайда. Части слайда могут иметь явные связи со многими другими частями — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Теги представляют собой пары значений строка‑ключ. 
{{% /alert %}} 

## **Получение значений тегов**

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Ниже приведён пример кода, показывающий, как получить значение тега с помощью Aspose.Slides для C++ для [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Добавление тегов в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, вы можете воспользоваться тегами. Например, если хотите собрать все презентации из стран Северной Америки, создайте тег «North American» и задайте в качестве значений соответствующие страны (США, Мексика и Канада). 

Ниже показан пример кода, демонстрирующий, как добавить тег к [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) с помощью Aspose.Slides для C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Теги также можно задать для [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


Или для любого отдельного [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **Часто задаваемые вопросы**

**Можно ли удалить все теги из презентации, слайда или фигуры одной операцией?**

Да. [Коллекция тегов](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить один тег по его имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) для удаления тега по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); она вернёт массив всех имён тегов.