---
title: "Групповые формы презентаций в .NET"
linktitle: "Группа фигур"
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
description: "Узнайте, как группировать и разгруппировать фигуры в презентациях PowerPoint с помощью Aspose.Slides для .NET — быстрый пошаговый гид с бесплатным кодом на C#."
---

## **Добавить групповую фигуру**
Aspose.Slides поддерживает работу с групповыми фигурами на слайдах. Эта функция помогает разработчикам создавать более насыщенные презентации. Aspose.Slides for .NET поддерживает добавление и доступ к групповым фигурам. Можно добавлять фигуры в созданную групповую фигуру, заполнять её или получать доступ к любому свойству групповой фигуры. Чтобы добавить групповую фигуру на слайд с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте групповую фигуру на слайд.
1. Добавьте фигуры в созданную групповую фигуру.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую фигуру на слайд.
```c#
// Создать экземпляр класса Presentation 
using (Presentation pres = new Presentation())
{
    // Получить первый слайд 
    ISlide sld = pres.Slides[0];

    // Доступ к коллекции фигур слайдов 
    IShapeCollection slideShapes = sld.Shapes;

    // Добавление групповой фигуры на слайд 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Добавление фигур в добавленную групповую фигуру 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки групповой фигуры 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Сохранить файл PPTX на диск 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Доступ к свойству AltText**
Эта тема демонстрирует простые шаги с примером кода для добавления групповой фигуры и доступа к свойству AltText групповых фигур на слайдах. Чтобы получить AltText групповой фигуры на слайде с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
1. Получите ссылку на слайд, используя его Index.
1. Получите коллекцию фигур слайдов.
1. Получите групповую фигуру.
1. Получите свойство AltText.

Пример ниже получает альтернативный текст групповой фигуры.
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
        // Доступ к групповой фигуре.
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

**Поддерживается ли вложенная группировка (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) имеет свойство [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), которое напрямую указывает поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как управлять порядком Z группы относительно других объектов на слайде?**

Используйте свойство [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) класса [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), чтобы проверить её положение в стеке отображения.

**Могу ли я запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), что позволяет ограничивать операции с объектом.