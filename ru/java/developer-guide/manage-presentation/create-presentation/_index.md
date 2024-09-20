---
title: Создание презентации PowerPoint с использованием Java
linktitle: Создать презентацию
type: docs
weight: 10
url: /java/create-presentation/
keywords: создать ppt java, создать ppt презентацию, создать pptx java
description: Узнайте, как создать презентации PowerPoint, например PPT, PPTX, используя Java с нуля.
---

## **Создание презентации PowerPoint**
Чтобы добавить простую прямую линию на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте фигуру типа линия с помощью метода addAutoShape, доступного в объекте Shapes.
4. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.

```java
// Создаем объект Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавляем автопостановку типа линия
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```