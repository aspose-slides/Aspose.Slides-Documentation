---
title: ActiveX
type: docs
weight: 200
url: /ru/net/examples/elements/activex/
keywords:
- ActiveX
- добавить ActiveX
- доступ к ActiveX
- удалить ActiveX
- свойства ActiveX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Смотрите примеры ActiveX для Aspose.Slides for .NET: вставка, настройка и управление объектами ActiveX в презентациях PPT и PPTX с понятным кодом C#."
---
Эта статья демонстрирует, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for .NET**.

## **Добавить элемент управления ActiveX**

Вставьте новый элемент управления ActiveX и при необходимости задайте его свойства.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Добавить новый элемент управления ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // При необходимости задайте некоторые свойства.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Получить доступ к элементу управления ActiveX**

Прочитайте информацию из первого элемента управления ActiveX на слайде.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Доступ к первому элементу управления ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Удалить элемент управления ActiveX**

Удалите существующий элемент управления ActiveX со слайда.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Удалить первый элемент управления ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Установить свойства ActiveX**

Добавьте элемент управления и настройте несколько свойств ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Добавить кнопку CommandButton и настроить свойства.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```