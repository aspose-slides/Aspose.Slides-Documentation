---
title: ActiveX
type: docs
weight: 200
url: /ru/net/examples/elements/activex/
keywords:
- Пример ActiveX
- Элемент управления ActiveX
- добавить ActiveX
- доступ к ActiveX
- удалить ActiveX
- Свойства ActiveX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как находить, редактировать и удалять элементы управления ActiveX в C# с помощью Aspose.Slides, включая обновление свойств для презентаций PowerPoint."
---

Продемонстрировано, как добавить, получить доступ, удалить и настроить элементы управления ActiveX в презентации с использованием **Aspose.Slides for .NET**.

## Добавление элемента управления ActiveX

Вставьте новый элемент управления ActiveX и при необходимости задайте его свойства.
```csharp
static void Add_ActiveX()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Добавить новый элемент управления ActiveX (TextBox)
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // При необходимости установить некоторые свойства
    control.Properties["Value"] = "Default text";

    pres.Save("add_activex.pptm", SaveFormat.Pptm);
}
```


## Доступ к элементу управления ActiveX

Прочитайте информацию о первом элементе управления ActiveX на слайде.
```csharp
static void Access_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    // Доступ к первому элементу управления ActiveX
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```


## Удаление элемента управления ActiveX

Удалите существующий элемент управления ActiveX со слайда.
```csharp
static void Remove_ActiveX()
{
    using var pres = new Presentation("add_activex.pptm");
    var slide = pres.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Удалить первый элемент управления ActiveX
        slide.Controls.RemoveAt(0);
    }

    pres.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```


## Установка свойств ActiveX

Добавьте элемент управления и настройте несколько свойств ActiveX.
```csharp
static void Set_ActiveX_Properties()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Добавить CommandButton и настроить свойства
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    pres.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```
