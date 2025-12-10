---
title: Группировка фигур в .NET
linktitle: Группа фигур
type: docs
weight: 40
url: /ru/net/group/
keywords:
- групповая фигура
- группа фигур
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать фигуры в презентациях PowerPoint с помощью Aspose.Slides for .NET — быстрый пошаговый гид с бесплатным кодом на C#."
---

## **Добавить группу фигур**
Aspose.Slides поддерживает работу с группами фигур на слайдах. Эта возможность помогает разработчикам создавать более насыщенные презентации. Aspose.Slides for .NET поддерживает добавление и доступ к группам фигур. Можно добавить фигуры в добавленную группу, чтобы заполнить её или получить доступ к любому свойству группы фигур. Чтобы добавить группу фигур на слайд с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его Index
1. Добавьте группу фигур на слайд.
1. Добавьте фигуры в добавленную группу.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён пример, который добавляет группу фигур на слайд.
```c#
// Создать экземпляр класса Presentation 
using (Presentation pres = new Presentation())
{
    // Получить первый слайд 
    ISlide sld = pres.Slides[0];

    // Доступ к коллекции фигур слайдов 
    IShapeCollection slideShapes = sld.Shapes;

    // Добавление группы фигур на слайд 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Добавление фигур внутри добавленной группы 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки группы фигур 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Записать файл PPTX на диск 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Доступ к свойству AltText**
В этом разделе показаны простые шаги с примерами кода для добавления группы фигур и доступа к свойству AltText групп фигур на слайдах. Чтобы получить AltText группы фигур на слайде с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
1. Получите ссылку на слайд, используя его Index.
1. Доступ к коллекции фигур слайдов.
1. Доступ к группе фигур.
1. Доступ к свойству AltText.

Ниже приведён пример, который получает альтернативный текст группы фигур.
```c#
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("AltText.pptx");

// Получить первый слайд
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Доступ к коллекции фигур слайдов
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Доступ к группе фигур.
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


## **FAQ**

**Поддерживается ли вложенное группирование (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) имеет свойство [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), которое напрямую указывает поддержку иерархии (группа может быть дочерней другой группы).

**Как контролировать порядок слоя группы относительно других объектов на слайде?**

Используйте свойство [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) класса [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) для проверки её положения в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), который позволяет ограничить операции над объектом.