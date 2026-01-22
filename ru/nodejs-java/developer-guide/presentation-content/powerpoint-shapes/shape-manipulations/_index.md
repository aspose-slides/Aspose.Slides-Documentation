---
title: Управление фигурами презентации в JavaScript
linktitle: Работа с фигурами
type: docs
weight: 40
url: /ru/nodejs-java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Найти фигуру
- Клонировать фигуру
- Удалить фигуру
- Скрыть фигуру
- Изменить порядок фигур
- Получить Interop ID фигуры
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выровнять фигуру
- PowerPoint
- Презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать фигуры с помощью JavaScript и Aspose.Slides для Node.js через Java, а также создавать высокопроизводительные презентации PowerPoint."
---

## **Найти фигуру на слайде**
В этой статье описывается простая техника, упрощающая разработчикам поиск конкретной фигуры на слайде без использования её внутреннего Id. Важно знать, что файлы PowerPoint Presentation не предоставляют способа идентифицировать фигуры на слайде, кроме внутреннего уникального Id. Разработчикам часто сложно найти фигуру по её внутреннему уникальному Id. Все фигуры, добавленные на слайды, имеют альтернативный текст. Мы рекомендуем использовать альтернативный текст для поиска конкретной фигуры. Вы можете использовать MS PowerPoint для задания альтернативного текста объектам, которые планируете изменять в будущем.

После задания альтернативного текста нужной фигуры вы можете открыть эту презентацию с помощью Aspose.Slides for Node.js via Java и пройтись по всем фигурам, добавленным на слайд. Во время каждой итерации можно проверить альтернативный текст фигуры, и фигура с совпадающим альтернативным текстом будет требуемой. Чтобы лучше продемонстрировать эту технику, мы создали метод [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-), который реализует поиск конкретной фигуры на слайде и просто возвращает эту фигуру.
```javascript
// Создать экземпляр класса Presentation, представляющего файл презентации
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Альтернативный текст фигуры, которую нужно найти
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **Клонировать фигуру**
Чтобы клонировать фигуру на слайд с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию фигур исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте фигуры из коллекции фигур исходного слайда в новый слайд.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповую фигуру на слайд.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Записать файл PPTX на диск
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удалить фигуру**
Aspose.Slides for Node.js via Java позволяет разработчикам удалять любые фигуры. Чтобы удалить фигуру с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите фигуру с определённым AlternativeText.
1. Удалите фигуру.
1. Сохраните файл на диск.
```javascript
// Создать объект Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить автофигуру прямоугольного типа
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Сохранить презентацию на диск
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Скрыть фигуру**
Aspose.Slides for Node.js via Java позволяет разработчикам скрывать любые фигуры. Чтобы скрыть фигуру на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите фигуру с определённым AlternativeText.
1. Скрыть фигуру.
1. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить автофигуру прямоугольного типа
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Сохранить презентацию на диск
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить порядок фигур**
Aspose.Slides for Node.js via Java позволяет разработчикам менять порядок фигур. Перестановка фигур определяет, какая фигура находится спереди, а какая — сзади. Чтобы изменить порядок фигур на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте фигуру.
1. Добавьте текст во фрейм текста фигуры.
1. Добавьте другую фигуру с теми же координатами.
1. Переставьте фигуры.
1. Сохраните файл на диск.
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить Interop Shape ID**
Aspose.Slides for Node.js via Java позволяет разработчикам получать уникальный идентификатор фигуры в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) , который возвращает уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) был добавлен в класс [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). Возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) значение соответствует Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Получение уникального идентификатора фигуры в области слайда
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить альтернативный текст для фигуры**
Aspose.Slides for Node.js via Java позволяет разработчикам задавать AlternateText любой фигуры.
Фигуры в презентации можно различать с помощью метода [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) или [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-).
Методы [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) могут быть использованы для чтения и задания значений как в Aspose.Slides, так и в Microsoft PowerPoint.
С помощью этого метода вы можете пометить фигуру и выполнять различные операции, такие как удаление фигуры, скрытие фигуры или изменение порядка фигур на слайде.
Чтобы установить AlternateText фигуры, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте любую фигуру на слайд.
1. Выполните некоторые действия с только что добавленной фигурой.
1. Пройдитесь по фигурам, чтобы найти нужную.
1. Задайте AlternativeText.
1. Сохраните файл на диск.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавить автофигуру прямоугольного типа
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Сохранить презентацию на диск
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить форматы макета для фигуры**
Aspose.Slides for Node.js via Java предоставляет простой API для доступа к форматам макета фигуры. В этой статье показано, как получить доступ к форматам макета.

Ниже приведён пример кода.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Отрисовать фигуру как SVG**
Теперь Aspose.Slides for Node.js via Java поддерживает рендеринг фигуры в SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (и его перегрузка) был добавлен в класс [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). Этот метод позволяет сохранить содержимое фигуры в файл SVG. Ниже приведён фрагмент кода, показывающий, как экспортировать фигур� со слайда в файл SVG.
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Выравнивание фигур**
Aspose.Slides позволяет выравнивать фигуры как относительно полей слайда, так и относительно друг друга. Для этой цели была добавлена перегруженная версия метода [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) определяет возможные варианты выравнивания.

**Example 1**

Исходный код ниже выравнивает фигуры с индексами 1,2 и 4 по верхней границе слайда.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Example 2**

Пример ниже показывает, как выровнять всю коллекцию фигур относительно самой нижней фигуры в наборе.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Flip Properties**
В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным зеркалированием фигур через свойства `flipH` и `flipV`. Оба свойства имеют тип `byte` и могут принимать значения `1` для включения отражения, `0` для отсутствия отражения или `-1` для использования поведения по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) фигуры.

Для изменения настроек отражения создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) , в котором указываются текущие позиция и размер фигуры, желаемые значения `flipH` и `flipV` и угол поворота. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) фигуры и сохранив презентацию, вы применяете зеркальные трансформации и фиксируете их в выходном файле.

Допустим, у нас есть файл sample.pptx, на первом слайде которого находится единственная фигура с настройками отражения по умолчанию, как показано ниже.

![Фигура для отражения](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения фигуры и отражает её как по горизонтали, так и по вертикали.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Получить свойство горизонтального отражения фигуры.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Получить свойство вертикального отражения фигуры.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Отразить по горизонтали.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Отразить по вертикали.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![Отражённая фигура](flipped_shape.png)

## **FAQ**

**Могу ли я объединять фигуры (объединение/пересечение/вычитание) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно выполнить её, построив нужный контур вручную — например, вычислить получающуюся геометрию (через [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)) и создать новую фигуру с этим контуром, при желании удалив исходные.

**Как контролировать порядок наложения (z-order), чтобы фигура всегда оставалась «поверх»?**

Измените порядок вставки/перемещения в коллекции [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) слайда. Для предсказуемых результатов завершайте настройку z-order после всех остальных изменений слайда.

**Могу ли я «заблокировать» фигуру, чтобы пользователи не могли её редактировать в PowerPoint?**

Да. Установите флаги защиты на уровне фигуры (например, блокировка выбора, перемещения, изменения размера, редактирования текста). При необходимости аналогичные ограничения можно задать на мастере или макете. Учтите, что это защита на уровне UI, а не безопасность; для более надёжной защиты комбинируйте с ограничениями уровня файла, например, рекомендациями только для чтения или паролями [read-only recommendations or passwords](/slides/ru/nodejs-java/password-protected-presentation/).