---
title: Управление метками и пользовательскими данными в презентациях с использованием C++
linktitle: Метки и пользовательские данные
type: docs
weight: 300
url: /ru/cpp/managing-tags-and-custom-data/
keywords:
- свойства документа
- метка
- пользовательские данные
- добавить метку
- парные значения
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как добавлять, считывать, обновлять и удалять метки и пользовательские данные в Aspose.Slides для C++, с примерами для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

В этой статье объясняется, как Aspose.Slides работает с метками и пользовательскими данными в презентациях PowerPoint. Кратко описывается, как данные сохраняются в файлах PPTX, отмечается, что данные, специфичные для презентации, могут существовать в виде меток и пользовательских XML‑частей, а также описываются метки как парные строки «ключ‑значение».

Также показано, как читать значения меток и как добавлять метки в презентацию, отдельный слайд или форму. Кроме того, в статье рассматриваются общие задачи управления метками, такие как очистка всех меток, удаление метки по имени и получение списка имён меток.

## **Хранение данных в файлах презентаций**

Файлы PPTX — элементы с расширением .pptx — хранятся в формате PresentationML, который является частью спецификации Office Open XML. Формат Office Open XML определяет структуру данных, содержащихся в презентациях. 

*Слайд* (*slide*) является одним из элементов презентаций, *часть слайда* (*slide part*) содержит содержимое одного слайда. Части слайда могут иметь явные отношения со многими другими частями — например, с пользовательскими метками — определёнными в ISO/IEC 29500. 

Пользовательские данные (специфичные для презентации) или пользователь могут существовать в виде меток ([ITagCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itagcollection/)) и пользовательских XML‑частей ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Метки представляют собой по сути пары «строка‑ключ». 

{{% /alert %}} 

## **Получение значений меток**

В Slides метка соответствует свойству IDocumentProperties.Keywords. Этот пример кода показывает, как получить значение метки с помощью Aspose.Slides для C++ для [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Добавление меток в презентации**

Aspose.Slides позволяет добавлять метки в презентации. Метка обычно состоит из двух элементов: 

- имя пользовательского свойства — `MyTag` 
- значение пользовательского свойства — `My Tag Value`

Если необходимо классифицировать некоторые презентации по определённому правилу или свойству, добавление меток может быть полезным. Например, если вы хотите группировать все презентации из стран Северной Америки, можно создать метку «North American» и задать соответствующие страны (США, Мексика и Канада) в качестве значений. 

Этот пример кода демонстрирует, как добавить метку к [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) с помощью Aspose.Slides для C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Метки также можно установить для [Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Или для любой отдельной [Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Ограничения**

Метки, добавленные через коллекцию пользовательских данных тегов с помощью `get_CustomData()->get_Tags()`, сохраняются только внутри файла PowerPoint. Они **не** переносятся в структуру тегов PDF при экспорте презентации в PDF. Следовательно, пользовательский идентификатор, назначенный как метка, нельзя получить из помеченного PDF.

**Обходное решение**: Вы можете сохранить пользовательский идентификатор в **альтернативном тексте** объекта (например, `shape->set_AlternativeText(u"MyId")`). После экспорта в PDF альтернативный текст может отобразиться в структуре тегов PDF.

## **FAQ**

**Можно ли удалить все метки из презентации, слайда или формы одной операцией?**

Да. [Коллекция меток](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/) поддерживает операцию [clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/clear/), которая удаляет все пары «ключ‑значение» сразу.

**Как удалить одну метку по её имени без перебора всей коллекции?**

Используйте операцию [Remove(name)](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/remove/) на [TagCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/) для удаления метки по её ключу.

**Как получить полностью список имён меток для аналитики или фильтрации?**

Вызовите [GetNamesOfTags](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/getnamesoftags/) у [коллекции меток](https://reference.aspose.com/slides/ru/cpp/aspose.slides/tagcollection/); он возвращает массив всех имён меток.