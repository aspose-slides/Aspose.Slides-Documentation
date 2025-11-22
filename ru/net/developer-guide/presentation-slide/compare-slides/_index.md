---
title: Сравнение слайдов
type: docs
weight: 50
url: /ru/net/compare-slides/
keywords: "Сравнение слайдов PowerPoint, Сравнение двух слайдов, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Сравнение слайдов презентации PowerPoint на C# или .NET"
---

## **Сравнение двух слайдов**
Метод Equals был добавлен в интерфейс [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) и класс [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Он возвращает true для слайдов/макетов и слайдов/мастеров, которые идентичны по своей структуре и статическому содержимому.

Два слайда считаются равными, если все фигуры, стили, тексты, анимация и другие настройки совпадают и т.д. При сравнении не учитываются уникальные идентификаторы, например SlideId, и динамическое содержимое, например текущее значение даты в Date Placeholder.
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **Часто задаваемые вопросы**

**Влияет ли факт того, что слайд скрыт, на сравнение самих слайдов?**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) — это свойство уровня презентации/воспроизведения, а не визуального содержимого. Равенство двух конкретных слайдов определяется их структурой и статическим содержимым; сам факт скрытия слайда не делает слайды разными.

**Учитываются ли гиперссылки и их параметры?**

Да. Ссылки являются частью статического содержимого слайда. Если URL или действие гиперссылки различаются, это обычно считается разницей в статическом содержимом.

**Если диаграмма ссылается на внешний файл Excel, будет ли учитываться содержимое этого файла?**

Нет. Сравнение производится на основе самих слайдов. Внешние источники данных обычно не читаются во время сравнения; учитывается только то, что присутствует в структуре и статическом состоянии слайда.