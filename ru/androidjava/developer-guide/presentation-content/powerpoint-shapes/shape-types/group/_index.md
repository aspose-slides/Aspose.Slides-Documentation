---
title: Группа
type: docs
weight: 40
url: /ru/androidjava/group/
---

## **Добавить группу форм**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта функция помогает разработчикам поддерживать более насыщенные презентации. Aspose.Slides для Android через Java поддерживает добавление или доступ к групповым формам. Возможно добавить формы в добавленную группу форм, чтобы заполнить ее, или получить доступ к любому свойству группы форм. Чтобы добавить группу форм на слайд с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте группу форм на слайд.
1. Добавьте формы в добавленную группу форм.
1. Сохраните изменённую презентацию как файл PPTX.

Пример ниже добавляет группу форм на слайд.

```java
// Создаем экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Получаем коллекцию форм слайдов
    IShapeCollection slideShapes = sld.getShapes();

    // Добавляем группу форм на слайд
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Добавляем формы внутри добавленной группы форм
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавляем рамку группы форм
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Записываем PPTX файл на диск
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к свойству AltText**
Эта тема показывает простые шаги с примерами кода для добавления группы форм и доступа к свойству AltText групповых форм на слайдах. Чтобы получить доступ к AltText группы форм на слайде с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который представляет файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм слайдов.
1. Получите доступ к группе форм.
1. Получите доступ к свойству [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--).

Пример ниже получает альтернативный текст группы форм.

```java
// Создаем экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Получаем коллекцию форм слайдов
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Получаем доступ к группе форм.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Получаем доступ к свойству AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```