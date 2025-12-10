---
title: Управление фигурами презентации в Java
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- поиск фигуры
- клонирование фигуры
- удаление фигуры
- скрытие фигуры
- изменение порядка фигур
- получение Interop Shape ID
- альтернативный текст фигуры
- форматы размещения фигуры
- фигура как SVG
- фигура в SVG
- выравнивание фигуры
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Изучите создание, редактирование и оптимизацию фигур в Aspose.Slides для Java и создавайте высокопроизводительные презентации PowerPoint."
---

## **Найти объект на слайде**
В этой статье описывается простая техника, позволяющая разработчикам проще находить конкретный объект на слайде без использования его внутреннего Id. Важно знать, что файлы PowerPoint Presentation не предоставляют способа идентифицировать объекты на слайде, кроме внутреннего уникального Id. Разработчикам зачастую сложно находить объект по его внутреннему уникальному Id. Все объекты, добавленные на слайды, имеют альтернативный текст. Мы рекомендуем разработчикам использовать альтернативный текст для поиска конкретного объекта. Вы можете использовать MS PowerPoint для задания альтернативного текста объектам, которые планируете изменять в будущем.

После задания альтернативного текста для любого нужного объекта вы можете открыть презентацию с помощью Aspose.Slides for Java и перебрать все объекты, добавленные на слайд. На каждой итерации можно проверить альтернативный текст объекта, и объект с совпадающим альтернативным текстом будет нужным вам объектом. Чтобы продемонстрировать эту технику более наглядно, мы создали метод, [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) который выполняет поиск конкретного объекта на слайде и просто возвращает этот объект.
```java
// Создайте объект класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Альтернативный текст ищущейся фигуры
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
// Реализация метода для поиска фигуры на слайде по её альтернативному тексту
public static IShape findShape(ISlide slide, String alttext)
{
    // Перебор всех фигур внутри слайда
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Если альтернативный текст фигуры совпадает с требуемым, тогда
        // вернуть фигуру
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Клонирование объекта**
Чтобы клонировать объект на слайд с помощью Aspose.Slides for Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к коллекции объектов исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте объекты из коллекции объектов исходного слайда в новый слайд.
1. Сохраните изменённую презентацию в файл PPTX.

Пример ниже добавляет групповой объект на слайд.
```java
// Создайте объект класса Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Сохранить файл PPTX на диск
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удалить объект**
Aspose.Slides for Java позволяет разработчикам удалять любые объекты. Чтобы удалить объект с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите объект с определённым AlternativeText.
1. Удалите объект.
1. Сохраните файл на диск.
```java
// Создайте объект Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автоконтур типа прямоугольник
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


## **Скрытие объекта**
Aspose.Slides for Java позволяет разработчикам скрывать любые объекты. Чтобы скрыть объект на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите объект с определённым AlternativeText.
1. Скрыть объект.
1. Сохраните файл на диск.
```java
// Создайте объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автоконтур типа прямоугольник
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


## **Изменить порядок объектов**
Aspose.Slides for Java позволяет разработчикам менять порядок объектов. Переупорядочивание определяет, какой объект находится спереди, а какой — сзади. Чтобы изменить порядок объектов на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте объект.
1. Добавьте некоторый текст в текстовый кадр объекта.
1. Добавьте другой объект с теми же координатами.
1. Измените порядок объектов.
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
Aspose.Slides for Java позволяет разработчикам получить уникальный идентификатор объекта в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--) который предоставляет уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен в интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) и класс [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) соответственно. Возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) значение соответствует Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получение уникального идентификатора формы в пределах слайда
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить альтернативный текст для объекта**
Aspose.Slides for Java позволяет разработчикам задавать AlternateText любого объекта. Объекты в презентации можно различать с помощью метода [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) или [Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-). Методы [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) могут читаться и устанавливаться как в Aspose.Slides, так и в Microsoft PowerPoint. С помощью этого метода вы можете пометить объект и выполнять различные операции, такие как удаление объекта, скрытие объекта или переупорядочивание объектов на слайде. Чтобы задать AlternateText для объекта, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте любой объект на слайд.
1. Выполните необходимые действия с только что добавленным объектом.
1. Пройдитесь по объектам, чтобы найти нужный объект.
1. Установите AlternativeText.
1. Сохраните файл на диск.
```java
// Создайте объект класса Presentation, представляющий PPTX
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить автоконтур типа прямоугольник
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


## **Доступ к форматам размещения для объекта**
Aspose.Slides for Java предоставляет простой API для доступа к форматам размещения объекта. Эта статья демонстрирует, как можно получить доступ к форматам размещения.

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


## **Отрисовка объекта в формате SVG**
Теперь Aspose.Slides for Java поддерживает отрисовку объекта в формате SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегрузка) был добавлен в класс [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape). Этот метод позволяет сохранять содержимое объекта в файл SVG. Ниже показан фрагмент кода, демонстрирующий экспорт объекта слайда в файл SVG.
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


## **Выравнивание объекта**
Aspose.Slides позволяет выравнивать объекты либо относительно полей слайда, либо относительно друг друга. Для этой цели была добавлена перегруженная версия метода [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) определяет возможные варианты выравнивания.

**Пример 1**

Исходный код ниже выравнивает объекты с индексами 1, 2 и 4 по верхней границе слайда.
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

Ниже показан пример выравнивания всей коллекции объектов относительно самого нижнего объекта в коллекции.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Свойства отражения**
В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным зеркальным отражением объектов через свойства `flipH` и `flipV`. Оба свойства имеют тип `byte`, где значение `1` указывает на отражение, `0` — отсутствие отражения, а `-1` — использование поведения по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) объекта.

Чтобы изменить настройки отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) с текущими координатами и размерами объекта, желаемыми значениями `flipH` и `flipV`, а также углом поворота. Присваивание этого экземпляра свойству [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) объекта и сохранение презентации применяют зеркальные преобразования и фиксируют их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит один объект с настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения объекта и отражает его как по горизонтали, так и по вертикали.
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
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
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

**Могу ли я объединять объекты (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для логических операций нет. Вы можете приблизительно реализовать это, построив нужный контур самостоятельно — например, вычислив результирующую геометрию (через [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)) и создав новый объект с этим контуром, при желании удалив оригиналы.

**Как я могу контролировать порядок наложения (z-order), чтобы объект всегда оставался «поверх»?**

Изменяйте порядок вставки/перемещения внутри коллекции [shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) слайда. Для предсказуемых результатов завершайте настройку z-order после всех остальных изменений слайда.

**Можно ли «заблокировать» объект, чтобы пользователи не могли его редактировать в PowerPoint?**

Да. Установите флаги защиты на уровне объекта (например, блокировка выбора, перемещения, изменения размеров, редактирования текста). При необходимости примените аналогичные ограничения к шаблону или макету. Обратите внимание, что это защита уровня UI, а не механизм безопасности; для более сильной защиты сочетайте её с ограничениями на уровне файла, такими как рекомендации «только для чтения» или пароли.