---
title: Группа
type: docs
weight: 40
url: /ru/net/group/
keywords: "Форма группы, Форма PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление формы группы в презентацию PowerPoint на C# или .NET"
---

## **Добавить форму группы**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта функция помогает разработчикам создавать более насыщенные презентации. Aspose.Slides для .NET поддерживает добавление или доступ к группам форм. Можно добавлять формы в добавленную групповую форму, чтобы заполнить ее, или получить доступ к любому свойству группе форм. Чтобы добавить групповую форму на слайд с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте групповую форму на слайд.
1. Добавьте формы в добавленную групповую форму.
1. Сохраните измененную презентацию в файл PPTX.

Пример ниже добавляет групповую форму на слайд.

```c#
// Создайте экземпляр класса Presentation 
using (Presentation pres = new Presentation())
{
    // Получите первый слайд 
    ISlide sld = pres.Slides[0];

    // Доступ к коллекции форм слайдов 
    IShapeCollection slideShapes = sld.Shapes;

    // Добавление групповой формы на слайд 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Добавление форм внутри добавленной групповой формы 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки групповой формы 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Запишите файл PPTX на диск 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Доступ к свойству AltText**
Эта тема демонстрирует простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить доступ к AltText групповой формы на слайде с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса `Presentation`, который представляет файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к коллекции форм слайдов.
1. Доступ к групповым формам.
1. Доступ к свойству AltText.

Пример ниже показывает, как получить альтернативный текст групповой формы.

```c#
// Создайте экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("AltText.pptx");

// Получите первый слайд
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Доступ к коллекции форм слайдов
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Доступ к групповой форме.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Доступ к свойству AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```