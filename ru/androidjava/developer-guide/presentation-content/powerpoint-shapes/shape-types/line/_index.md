---
title: Добавить линейные фигуры в презентации на Android
linktitle: Линия
type: docs
weight: 50
url: /ru/androidjava/line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль штриховки
- наконечник стрелки
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides для Android. Откройте свойства, методы и примеры на Java."
---
## **Обзор**

Aspose.Slides позволяет программно добавлять линейные фигуры в слайды PowerPoint. В этой статье показано, как создать простую линию и как настроить линию, чтобы она выглядела как стрелка.

Вы узнаете, как добавить линейную фигуру на слайд, изменить её внешний вид и сохранить обновлённую презентацию. В примерах рассматриваются практические параметры форматирования линии, такие как стиль, ширина, шаблон штриховки, параметры наконечника стрелки и цвет заливки.

## **Создание простой линии**

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Добавить AutoShape типа line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Записать PPTX на диск
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание линии со стрелкой**

Aspose.Slides для Android через Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides для Android через Java.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides для Android через Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.

```java
// Создайте экземпляр класса PresentationEx, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Применить некоторое форматирование к линии
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

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/) типа [Line](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapetype/)) автоматически не превращается в соединитель. Чтобы привязать её к фигурам, используйте специальный тип [Connector](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/connector/) и [corresponding APIs](/slides/ru/androidjava/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Read the effective properties](/slides/ru/androidjava/shape-effective-properties/) через интерфейсы [ILineFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , позволяющие запрещать операции редактирования.