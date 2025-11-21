---
title: Чернила
type: docs
weight: 180
url: /ru/net/examples/elements/ink/
keywords:
- пример чернил
- доступ к чернилам
- удалить чернила
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с цифровыми чернилами на слайдах в C# с помощью Aspose.Slides: добавляйте штрихи пера, редактируйте пути, задавайте цвет и ширину, а также экспортируйте результаты для PowerPoint и OpenDocument."
---

Предоставляет примеры доступа к существующим чернильным фигурам и их удаления с помощью **Aspose.Slides for .NET**.

> ❗ **Примечание:** Чернильные фигуры представляют ввод пользователя со специализированных устройств. Aspose.Slides не может программно создавать новые чернильные штрихи, но вы можете читать и изменять существующую чернильную запись.

## Доступ к чернилу

Прочитайте теги первой чернильной фигуры на слайде.
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Используйте tagName по необходимости
        }
    }
}
```


## Удаление чернильных фигур

Удалите чернильную фигуру со слайда, если она существует.
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
