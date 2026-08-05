---
title: Добавление линейных фигур в презентации на Java
linktitle: Линия
type: docs
weight: 50
url: /ru/java/line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль штриха
- наконечник стрелки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Изучите, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides for Java. Узнайте о свойствах, методах и примерах."
---
## **Обзор**

Aspose.Slides позволяет программно добавлять линейные фигуры в слайды PowerPoint. В этой статье показано, как создать простую линию и как настроить её так, чтобы она выглядела как стрелка.

Вы узнаете, как добавить линейную фигуру на слайд, изменить её визуальный вид и сохранить обновлённую презентацию. Примеры сосредоточены на практических параметрах форматирования линии, таких как стиль, ширина, тип штриха, параметры наконечника стрелки и цвет заливки.

## **Создание простой линии**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавьте AutoShape типа line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Запишите PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание линии‑стрелки**

Aspose.Slides for Java также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Попробуем задать несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for Java.
- Задайте ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/java/com.aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавьте AutoShape типа line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Примените некоторое форматирование к линии
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Запишите PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязывалась» к фигурам?**

Нет. Обычная линия (AutoShape типа [Line](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она привязывалась к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/ru/java/com.aspose.slides/connector/) и [соответствующие API](/slides/ru/java/connector/) для соединений.

**Что делать, если свойства линии унаследованы из темы и трудно определить окончательные значения?**

[Читайте эффективные свойства](/slides/ru/java/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/ru/java/com.aspose.slides/autoshape/#getAutoShapeLock--) , позволяющие [запретить операции редактирования](/slides/ru/java/applying-protection-to-presentation/).