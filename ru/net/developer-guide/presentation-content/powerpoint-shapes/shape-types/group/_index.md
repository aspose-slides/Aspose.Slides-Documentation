---
title: Группа
type: docs
weight: 40
url: /ru/net/group/
keywords: "Групповая форма, форма PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавить групповую форму в презентацию PowerPoint на C# или .NET"
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта возможность помогает разработчикам создавать более насыщенные презентации. Aspose.Slides для .NET поддерживает добавление и доступ к групповым формам. Можно добавить формы в уже созданную групповую форму, чтобы заполнить её или получить доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с помощью Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте групповую форму на слайд.
1. Добавьте формы в созданную групповую форму.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую форму на слайд.
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

    // Добавление фигур внутри добавленной групповой фигуры 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки групповой фигуры 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Записать файл PPTX на диск 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Доступ к свойству AltText**
В этой статье показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить AltText групповой формы на слайде с помощью Aspose.Slides для .NET:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
1. Получите ссылку на слайд, используя его Index.
1. Получите доступ к коллекции форм слайда.
1. Получите доступ к групповой форме.
1. Получите доступ к свойству AltText.

Пример ниже получает альтернативный текст групповой формы.
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

**Поддерживается ли вложенное групповое объединение (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) имеет свойство [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), которое напрямую указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как управлять порядком z‑groupы относительно других объектов на слайде?**

Используйте свойство [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) класса [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) для просмотра или изменения её позиции в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), который позволяет ограничить операции над объектом.