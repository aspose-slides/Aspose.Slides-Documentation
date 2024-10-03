---
title: Порция
type: docs
weight: 70
url: /ru/java/portion/
---

## **Получение координат позиции порции**
Метод [**getCoordinates()**](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion#getCoordinates--) был добавлен в [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPortion) и класс [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion), который позволяет получать координаты начала порции.

```java
// Создание экземпляра класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Изменение контекста презентации
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```