---
title: Группа
type: docs
weight: 40
url: /ru/java/group/
---

## **Добавить группу фигур**
Aspose.Slides поддерживает работу с группами фигур на слайдах. Эта функция помогает разработчикам создавать более богатые презентации. Aspose.Slides для Java поддерживает добавление или доступ к группам фигур. Можно добавлять фигуры в добавленную группу фигур для её заполнения или получать доступ к любому свойству группы фигур. Чтобы добавить группу фигур на слайд с использованием Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте группу фигур на слайд.
1. Добавьте фигуры в добавленную группу фигур.
1. Сохраните изменённую презентацию в файле PPTX.

Пример ниже добавляет группу фигур на слайд.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide sld = pres.getSlides().get_Item(0);

    // Доступ к коллекции фигур слайдов
    IShapeCollection slideShapes = sld.getShapes();

    // Добавление группы фигур на слайд
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Добавление фигур в добавленную группу фигур
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Добавление рамки группы фигур
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Запись файла PPTX на диск
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к свойству AltText**
Эта тема демонстрирует простые шаги с примерами кода для добавления группы фигур и доступа к свойству AltText групп фигур на слайдах. Чтобы получить доступ к AltText группы фигур на слайде, используя Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), представляющего файл PPTX.
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к коллекции фигур слайдов.
1. Доступ к группе фигур.
1. Доступ к свойству [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--).

Пример ниже получает альтернативный текст группы фигур.

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Получение первого слайда
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Доступ к коллекции фигур слайдов
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Доступ к группе фигур.
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