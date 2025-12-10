---
title: Изменение размеров фигур на слайдах презентации
type: docs
weight: 110
url: /ru/java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java — автоматизируйте настройку макета слайдов и повышайте продуктивность."
---

## **Overview**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for Java — как изменять размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта краткая техническая статья показывает, как это сделать.

## **Resize Shapes**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры, чтобы они соответствовали новой раскладке слайда.
```java
// Загрузить файл презентации.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Получить исходный размер слайда.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Получить новый размер слайда.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Изменить размер и перенести фигуры на каждом слайде.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}} 
Если слайд содержит таблицу, приведённый выше код работать не будет. В этом случае необходимо изменять размер каждой ячейки таблицы.
{{% /alert %}} 

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц установка ширины или высоты является особым случаем: необходимо корректировать высоту отдельных строк и ширину столбцов, чтобы изменить общий размер таблицы.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Получить исходный размер слайда.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Изменить размер слайда без масштабирования существующих фигур.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Получить новый размер слайда.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Масштабировать размер фигуры.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Масштабировать позицию фигуры.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Масштабировать размер фигуры.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Масштабировать позицию фигуры.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Does the provided code work for all shape types?**

The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**How do I resize tables when resizing a slide?**

You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) and [Layout slides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can use [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the `getAspectRatioLocked` method of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.