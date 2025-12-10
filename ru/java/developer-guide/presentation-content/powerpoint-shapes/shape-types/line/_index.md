---
title: Добавление линейных фигур в презентации на Java
linktitle: Линия
type: docs
weight: 50
url: /ru/java/Line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль штриха
- стрелка
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для Java. Откройте свойства, методы и примеры."
---

{{% alert color="primary" %}} 

Aspose.Slides for Java поддерживает добавление различных типов фигур на слайды. В этой статье мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for Java разработчики могут создавать не только простые линии, но и рисовать на слайдах некоторые декоративные линии.

{{% /alert %}} 

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```java
// Создайте объект класса PresentationEx, представляющий файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавьте AutoShape типа line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Сохраните PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать линию со стрелкой**

Aspose.Slides for Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line, используя метод [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for Java.
- Установите Width линии.
- Установите [Dash Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) конечной точки линии.
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

    // Сохранить PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «прилипала» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы она прилеплялась к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/java/com.aspose.slides/connector/) и [соответствующие API](/slides/ru/java/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить конечные значения?**

[Читайте эффективные свойства](/slides/ru/java/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilinefillformateffectivedata/), которые уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#getAutoShapeLock--) , которые позволяют вам [запретить операции редактирования](/slides/ru/java/applying-protection-to-presentation/).