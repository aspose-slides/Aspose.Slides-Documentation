---
title: Группировка форм презентации на Android
linktitle: Группа форм
type: docs
weight: 40
url: /ru/androidjava/group/
keywords:
- групповая форма
- группа форм
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как группировать и разгруппировать формы в презентациях PowerPoint с помощью Aspose.Slides для Android - быстрый пошаговый гид с бесплатным кодом на Java."
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта функция помогает разработчикам создавать более богатые презентации. Aspose.Slides for Android via Java поддерживает добавление и доступ к групповым формам. Можно добавлять формы в уже созданную групповую форму, заполнять её или получать доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с помощью Aspose.Slides for Android via Java:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получить ссылку на слайд, используя его Index.
1. Добавить групповую форму на слайд.
1. Добавить формы в созданную групповую форму.
1. Сохранить изменённую презентацию в файл PPTX.

Ниже приведён пример, который добавляет групповую форму на слайд.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Доступ к коллекции фигур слайдов
    IShapeCollection slideShapes = sld.getShapes();

    // Добавление групповой фигуры на слайд
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Добавление фигур внутрь добавленной групповой фигуры
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки групповой фигуры
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Сохранить файл PPTX на диск
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к свойству AltText**
В этом разделе показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить AltText групповой формы на слайде с помощью Aspose.Slides for Android via Java:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), представляющего файл PPTX.
1. Получить ссылку на слайд, используя его Index.
1. Получить доступ к коллекции форм слайдов.
1. Получить доступ к групповой форме.
1. Получить доступ к свойству [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

Ниже приведён пример, который получает альтернативный текст групповой формы.
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
            // Доступ к групповой фигуре.
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

**Поддерживается ли вложенное группирование (группа внутри группы)?**

Да. У [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) есть метод [getParentGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getParentGroup--), который напрямую указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как управлять порядком наложения группы относительно других объектов на слайде?**

Используйте метод [getZOrderPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) класса [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), чтобы узнать её позицию в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [getGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--), что позволяет ограничить операции над объектом.