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

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

Слайд (*slide*) является одним из элементов презентаций, а *slide part* содержит содержимое одного слайда. slide part может иметь явные связи со многими частями — например, с пользовательскими тегами — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) могут существовать в виде тегов ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)). 

{{% alert color="primary" %}} 
Теги по сути являются парами строка‑ключ. 
{{% /alert %}} 

## **Получить значения тегов**

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение тега с помощью Aspose.Slides для C++ для [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Добавить теги в презентации**

Aspose.Slides позволяет добавлять теги в презентации. Тег обычно состоит из двух элементов:
- имя пользовательского свойства — `MyTag`
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление тегов может быть полезным. Например, если вы хотите сгруппировать все презентации из стран Северной Америки, вы можете создать тег North American и назначить в качестве значений соответствующие страны (США, Мексика и Канада). 

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) с помощью Aspose.Slides для C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Теги также можно задать для [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


Или для любого отдельного [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **Часто задаваемые вопросы**

**Могу ли я удалить все теги из презентации, слайда или фигуры одной операцией?**  
Да. [Коллекция тегов](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/), которая удаляет все пары ключ‑значение сразу.

**Как удалить отдельный тег по его имени без перебора всей коллекции?**  
Воспользуйтесь операцией [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) у [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/), чтобы удалить тег по его ключу.

**Как получить полный список имён тегов для аналитики или фильтрации?**  
Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) у [коллекции тегов](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); он возвращает массив всех имён тегов.