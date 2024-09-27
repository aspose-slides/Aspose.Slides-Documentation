---
title: Сравнить слайды
type: docs
weight: 50
url: /ru/net/compare-slides/
keywords: "Сравнить слайды PowerPoint, Сравнить два слайда, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Сравнить слайды презентации PowerPoint на C# или .NET"
---

## **Сравнить два слайда**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) и класс [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Он возвращает true для слайдов/макетов и слайдов/мастера, которые идентичны по своей структуре и статическому содержанию.

Два слайда равны, если все формы, стили, тексты, анимация и другие настройки и т. д. совпадают. Сравнение не учитывает значения уникальных идентификаторов, например, SlideId, и динамическое содержимое, например, текущее значение даты в поле "Дата".

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} равен SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```