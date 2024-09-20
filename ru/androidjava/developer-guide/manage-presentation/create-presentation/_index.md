---
title: Создание Презентации PowerPoint с использованием Java
linktitle: Создать Презентацию
type: docs
weight: 10
url: /androidjava/create-presentation/
keywords: создать ppt java, создать ppt презентацию, создать pptx java
description: Узнайте, как создавать Презентации PowerPoint, например PPT, PPTX с использованием Java с нуля.
---

## **Создание Презентации PowerPoint**
Чтобы добавить простую линию на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте автофигуру типа Линия, используя метод addAutoShape, предоставленный объектом Shapes.
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```java
// Создайте объект Presentation, который представляет файл презентации
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте автофигуру типа линии
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```