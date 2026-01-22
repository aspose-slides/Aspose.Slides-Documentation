---
title: Добавление фигур линий в презентации на Android
linktitle: Линия
type: docs
weight: 50
url: /ru/androidjava/Line/
keywords:
- линия
- создать линию
- добавить линию
- простая линия
- настроить линию
- персонализировать линию
- стиль пунктирной линии
- конец стрелки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для Android. Откройте свойства, методы и примеры на Java."
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java поддерживает добавление различных типов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for Android via Java разработчики могут не только создавать простые линии, но и рисовать на слайдах более сложные линии.

{{% /alert %}} 

## **Создание простой линии**

Для добавления простой линии на выбранный слайд презентации выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавьте AutoShape типа линия
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Сохраните PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создание линии со стрелкой**

Aspose.Slides for Android via Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Настроим несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for Android via Java.
- Задайте ширину (Width) линии.
- Установите [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for Android via Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применить форматирование к линии
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Записать PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли преобразовать обычную линию в соединитель, чтобы она «привязывалась» к фигурам?**

Нет. Обычная линия (AutoShape типа Line) автоматически не становится соединителем. Чтобы она привязывалась к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) и соответствующие API (/slides/ru/androidjava/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и сложно определить окончательные значения?**

Прочитайте эффективные свойства (/slides/ru/androidjava/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/). Они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , позволяющие запрещать операции редактирования.