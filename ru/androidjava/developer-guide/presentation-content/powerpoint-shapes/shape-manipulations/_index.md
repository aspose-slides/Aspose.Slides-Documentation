---
title: Управление формами презентации на Android
linktitle: Манипуляция формами
type: docs
weight: 40
url: /ru/androidjava/shape-manipulations/
keywords:
- Форма PowerPoint
- Форма презентации
- Форма на слайде
- Найти форму
- Клонировать форму
- Удалить форму
- Скрыть форму
- Изменить порядок форм
- Получить Interop Shape ID
- Альтернативный текст формы
- Форматы макета формы
- Форма как SVG
- Форма в SVG
- Выровнять форму
- PowerPoint
- Презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать формы в Aspose.Slides для Android через Java и создавать высокопроизводительные презентации PowerPoint."
---

## **Найти форму на слайде**
Эта тема описывает простую технику, позволяющую разработчикам легче находить конкретную форму на слайде без использования её внутреннего Id. Важно знать, что файлы презентаций PowerPoint не имеют способа идентифицировать формы на слайде, кроме внутреннего уникального Id. Разработчикам часто сложно находить форму по её внутреннему уникальному Id. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы советуем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста для объектов, которые вы планируете изменять в будущем.

После установки альтернативного текста любой нужной формы вы можете открыть эту презентацию с помощью Aspose.Slides for Android via Java и пройтись по всем формам, добавленным на слайд. На каждой итерации можно проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет нужной вам формой. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , который выполняет поиск конкретной формы на слайде и просто возвращает её форму.
```java
// Создать объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Альтернативный текст формы, которую нужно найти
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Реализация метода для поиска формы на слайде по её альтернативному тексту
public static IShape findShape(ISlide slide, String alttext)
{
    // Итерация по всем формам внутри слайда
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Если альтернативный текст формы совпадает с требуемым, то
        // Возврат формы
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Клонировать форму**
Для клонирования формы на слайд с помощью Aspose.Slides for Android via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда в новый слайд.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён пример, который добавляет групповую форму на слайд.
```java
// Создать объект класса Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Записать файл PPTX на диск
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удалить форму**
Aspose.Slides for Android via Java позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определённым AlternativeText.
1. Удалите форму.
1. Сохраните файл на диск.
```java
// Создать объект Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа Rectangle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Сохранить презентацию на диск
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Скрыть форму**
Aspose.Slides for Android via Java позволяет разработчикам скрывать любую форму. Чтобы скрыть форму на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определённым AlternativeText.
1. Скрыть форму.
1. Сохраните файл на диск.
```java
// Создать объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа прямоугольник
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Сохранить презентацию на диск
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить порядок форм**
Aspose.Slides for Android via Java позволяет разработчикам изменять порядок форм. Переупорядочивание форм определяет, какая форма находится спереди, а какая — сзади. Чтобы переупорядочить формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте форму.
1. Добавьте текст в текстовый фрейм формы.
1. Добавьте другую форму с теми же координатами.
1. Переупорядочьте формы.
1. Сохраните файл на диск.
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить Interop Shape ID**
Aspose.Slides for Android via Java позволяет разработчикам получать уникальный идентификатор формы в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) , который возвращает уникальный идентификатор в пределах всей презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен в интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) и класс [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape). Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) соответствует Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получение уникального идентификатора формы в пределах слайда
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить альтернативный текст для формы**
Aspose.Slides for Android via Java позволяет разработчикам задавать AlternateText любой формы. Формы в презентации можно различать с помощью метода [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) или [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Методы [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) могут быть использованы как в Aspose.Slides, так и в Microsoft PowerPoint. С помощью этого метода вы можете пометить форму и выполнять различные операции, такие как удаление формы, скрытие формы или переупорядочивание форм на слайде. Чтобы задать AlternateText формы, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте любую форму на слайд.
1. Выполните необходимые действия с только что добавленной формой.
1. Пройдитесь по формам, чтобы найти нужную форму.
1. Установите AlternativeText.
1. Сохраните файл на диск.
```java
// Создать объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа прямоугольник
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Сохранить презентацию на диск
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к форматам макета для формы**
Aspose.Slides for Android via Java предоставляет простой API для доступа к форматам макета формы. Эта статья демонстрирует, как получить доступ к форматам макета.

Ниже приведён пример кода.
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Отрисовать форму как SVG**
Теперь Aspose.Slides for Android via Java поддерживает отрисовку формы в формате svg. Метод [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегрузка) был добавлен в класс [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Этот метод позволяет сохранить содержимое формы в файл SVG. Пример кода ниже показывает, как экспортировать форму слайда в файл SVG.
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Выровнять форму**
Aspose.Slides позволяет выравнивать формы либо относительно полей слайда, либо относительно друг друга. Для этой цели была добавлена перегруженная версия метода [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) определяет возможные варианты выравнивания.

**Пример 1**

Приведённый ниже код выравнивает формы с индексами 1, 2 и 4 по верхнему краю слайда.
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**Пример 2**

Пример ниже показывает, как выравнивать всю коллекцию форм относительно самой нижней формы в коллекции.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Свойства отражения**

В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным зеркальным отражением форм через свойства `flipH` и `flipV`. Оба свойства имеют тип `byte` и могут принимать значения `1` для отражения, `0` для отсутствия отражения или `-1` для использования поведения по умолчанию. Эти значения доступны из [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) формы.

Чтобы изменить настройки отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) с текущими координатами и размером формы, нужными значениями `flipH` и `flipV` и углом поворота. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) формы и сохранив презентацию, вы применяете зеркальные трансформации и фиксируете их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит одну форму с настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения формы и отражает её одновременно по горизонтали и вертикали.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Получить свойство горизонтального отражения формы.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Получить свойство вертикального отражения формы.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Отразить горизонтально.
    byte flipV = NullableBool.True; // Отразить горизонтально.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Результат:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Можно ли объединять формы (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно реализовать это, построив желаемый контур вручную — например, вычислив полученную геометрию (через [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) и создав новую форму с этим контуром, при необходимости удалив исходные.

**Как контролировать порядок наложения (z‑order), чтобы форма всегда оставалась «на вершине»?**

Измените порядок вставки/перемещения внутри коллекции [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) слайда. Для предсказуемых результатов завершайте настройку z‑order после всех остальных изменений слайда.

**Можно ли «запереть» форму, чтобы пользователи не могли её редактировать в PowerPoint?**

Да. Установите флаги защиты уровня формы (например, блокировать выбор, перемещение, изменение размера, редактирование текста). При необходимости наложите ограничения на мастер или макет. Учтите, что это защита только на уровне UI, а не полноценная безопасность; для более надёжной защиты комбинируйте её с ограничениями на уровне файла, такими как рекомендации только для чтения или пароли.