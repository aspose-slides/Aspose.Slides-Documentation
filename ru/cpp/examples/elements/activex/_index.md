---
title: ActiveX
type: docs
weight: 200
url: /ru/cpp/examples/elements/activex/
keywords:
- пример кода
- ActiveX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Смотрите примеры ActiveX для Aspose.Slides for C++: вставка, настройка и управление объектами ActiveX в презентациях PPT и PPTX с понятным кодом C++."
---
Эта статья демонстрирует, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for C++**.

## **Add an ActiveX Control**
Вставьте новый элемент управления ActiveX и при необходимости задайте его свойства.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавить новый элемент управления ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // При необходимости установить некоторые свойства.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Access an ActiveX Control**
Прочитайте информацию из первого элемента управления ActiveX на слайде.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Доступ к первому элементу управления ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Remove an ActiveX Control**
Удалите существующий элемент управления ActiveX со слайда.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Удалить первый элемент управления ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Set ActiveX Properties**
Добавьте элемент управления и настройте несколько свойств ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавить элемент управления Windows Media Player и настроить свойства.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```