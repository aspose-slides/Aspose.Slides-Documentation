---
title: Групповые формы презентаций в Java
linktitle: Группа фигур
type: docs
weight: 40
url: /ru/java/group/
keywords:
- групповая форма
- группа фигур
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать фигуры в презентациях PowerPoint с помощью Aspose.Slides для Java — быстрое пошаговое руководство с бесплатным кодом Java."
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта функция помогает разработчикам создавать более насыщенные презентации. Aspose.Slides for Java поддерживает добавление и доступ к групповым формам. Можно добавить фигуры в созданную групповую форму, чтобы заполнить её или получить доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте групповую форму на слайд.
1. Добавьте фигуры в созданную групповую форму.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую форму на слайд.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Доступ к коллекции фигур слайдов
    IShapeCollection slideShapes = sld.getShapes();

    // Добавление групповой формы на слайд
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Добавление фигур внутри добавленной групповой формы
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки групповой формы
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Записать файл PPTX на диск
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к свойству AltText**
В этой статье показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить AltText групповой формы на слайде с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), представляющего файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Получение коллекции фигур слайдов.
1. Получение групповой формы.
1. Получение свойства [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) .

Пример ниже получает альтернативный текст групповой формы.
```java
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Доступ к коллекции фигур слайдов
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Доступ к групповой форме.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Доступ к свойству AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Поддерживается ли вложенное объединение (группа внутри группы)?**

Да. У [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) есть метод [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--) , который напрямую указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как контролировать порядок Z групповой формы относительно других объектов на слайде?**

Используйте метод [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) у [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) , чтобы проверить её позицию в стек отображения.

**Могу ли я запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--) , который позволяет ограничить операции над объектом.