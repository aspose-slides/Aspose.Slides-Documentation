---
title: Раздел
type: docs
weight: 90
url: /ru/cpp/examples/elements/section/
keywords:
- пример кода
- раздел
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте разделами слайдов в Aspose.Slides for C++: создавайте, переименовывайте, переупорядочивайте и группируйте слайды с примерами на C++ для форматов PPT, PPTX и ODP."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с помощью **Aspose.Slides for C++**.

## **Добавить раздел**

Создайте раздел, начинающийся с определённого слайда.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Укажите слайд, который отмечает начало раздела.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Доступ к разделу**

Прочитайте информацию о разделе из презентации.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Получить доступ к разделу по индексу.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Удалить первый раздел.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Переименовать раздел**

Измените имя существующего раздела.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```