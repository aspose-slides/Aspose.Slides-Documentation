---
title: Чернила
type: docs
weight: 180
url: /ru/net/examples/elements/ink/
keywords:
- чернила
- доступ к чернилам
- удалить чернила
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с чернилами в Aspose.Slides for .NET: рисуйте, импортируйте и редактируйте мазки, регулируйте цвет и ширину, а также экспортируйте в PPT, PPTX и ODP, используя примеры на C#."
---
В этой статье представлены примеры доступа к существующим фигурам чернил и их удаления с использованием **Aspose.Slides for .NET**.

> ❗ **Note:** Фигуры чернил представляют ввод пользователя со специализированных устройств. Aspose.Slides не может программно создавать новые мазки чернил, но вы можете читать и изменять существующие чернила.

## **Доступ к чернилам**

Прочитайте теги первой фигуры чернил на слайде.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Используйте tagName по мере необходимости.
        }
    }
}
```

## **Удалить чернила**

Удалите фигуру чернил со слайда, если она существует.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```