---
title: Управление тегами и пользовательскими данными
type: docs
weight: 300
url: /ru/cpp/managing-tags-and-custom-data

---

## Хранение данных в презентационных файлах

Файлы PPTX — это элементы с расширением .pptx, которые хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях.

Поскольку *слайд* является одним из элементов в презентациях, *часть слайда* содержит содержимое одного слайда. Часть слайда может иметь явные отношения к многим частям — таким как пользовательские теги — определенным стандартом ISO/IEC 29500.

Пользовательские данные (специфичные для презентации) или пользователя могут существовать как теги ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) и CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)).

{{% alert color="primary" %}} 

Теги представляют собой пары значений с ключом-строкой. 

{{% /alert %}} 

## Получение значений тегов

В слайдах тег соответствует свойству IDocumentProperties.Keywords. Этот пример кода демонстрирует, как получить значение тега с помощью Aspose.Slides для C++ для [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## Добавление тегов к презентациям

Aspose.Slides позволяет добавлять теги к презентациям. Тег обычно состоит из двух элементов:

- название пользовательского свойства - `MyTag` 
- значение пользовательского свойства - `My Tag Value`

Если вам нужно классифицировать некоторые презентации на основе определенного правила или свойства, вы можете получить выгоду от добавления тегов к этим презентациям. Например, если вы хотите категоризировать или объединить все презентации из стран Северной Америки, вы можете создать тег "Северная Америка", а затем назначить соответствующие страны (США, Мексика и Канада) в качестве значений.

Этот пример кода показывает, как добавить тег к [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) с использованием Aspose.Slides для C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Теги также могут быть установлены для [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):

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