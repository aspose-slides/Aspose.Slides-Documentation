---
title: Чернила
type: docs
weight: 180
url: /ru/net/examples/elements/ink/
keywords:
- пример чернил
- доступ к чернилам
- удаление чернил
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с цифровыми чернилами на слайдах в C# с Aspose.Slides: добавляйте штрихи пера, редактируйте пути, задавайте цвет и толщину, а также экспортируйте результаты для PowerPoint и OpenDocument."
---

Предоставляет примеры доступа к существующим формам чернил и их удаления с использованием **Aspose.Slides for .NET**.

> ❗ **Примечание:** Формы чернил представляют ввод пользователя с специализированных устройств. Aspose.Slides не может программно создавать новые чернильные штрихи, но вы можете читать и изменять существующие чернила.

## **Доступ к чернилам**

Прочитайте теги первой формы чернил на слайде.
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
            // Используйте tagName по мере необходимости
        }
    }
}
```


## **Удаление чернил**

Удалите форму чернил со слайда, если она существует.
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
