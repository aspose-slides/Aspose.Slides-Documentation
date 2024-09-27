---
title: Манипуляции с формами
type: docs
weight: 40
url: /ru/java/shape-manipulations/
---

## **Поиск формы на слайде**
Эта тема опишет простую технику, чтобы облегчить разработчикам поиск конкретной формы на слайде без использования ее внутреннего идентификатора. Важно знать, что файлы презентаций PowerPoint не имеют возможности идентифицировать формы на слайде, кроме как с помощью внутреннего уникального идентификатора. Кажется, что разработчикам сложно найти форму, используя ее внутренний уникальный идентификатор. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы предлагаем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста для объектов, которые вы планируете изменить в будущем.

После установки альтернативного текста для любой желаемой формы, вы можете открыть эту презентацию, используя Aspose.Slides для Java, и перебрать все формы, добавленные на слайд. На каждой итерации вы можете проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет той формой, которая вам нужна. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), который помогает найти конкретную форму на слайде и затем просто возвращает эту форму.

```java
// Создаем экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Альтернативный текст формы, которую нужно найти
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Имя формы: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Реализация метода для поиска формы на слайде по ее альтернативному тексту
public static IShape findShape(ISlide slide, String alttext)
{
    // Перебираем все формы внутри слайда
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Если альтернативный текст слайда совпадает с требуемым
        // Возвращаем форму
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Клонирование формы**
Чтобы клонировать форму на слайде, используя Aspose.Slides для Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к коллекции форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните измененную презентацию в файл PPTX.

Пример ниже добавляет сгруппированную форму на слайд.

```java
// Создаем экземпляр класса Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Записываем файл PPTX на диск
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление формы**
Aspose.Slides для Java позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Доступ к первому слайду.
1. Найдите форму с определенным альтернативным текстом.
1. Удалите форму.
1. Сохраните файл на диск.

```java
// Создаем объект Presentation
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автозаполнение прямоугольной формы
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "Пользовательский текст";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (altText.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Сохраняем презентацию на диск
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Скрытие формы**
Aspose.Slides для Java позволяет разработчикам скрывать любую форму. Чтобы скрыть форму с любого слайда, следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Доступ к первому слайду.
1. Найдите форму с определенным альтернативным текстом.
1. Скрыть форму.
1. Сохраните файл на диск.

```java
// Создаем экземпляр класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автозаполнение прямоугольной формы
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "Пользовательский текст";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (altText.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Сохраняем презентацию на диск
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Смена порядка форм**
Aspose.Slides для Java позволяет разработчикам изменять порядок форм. Изменение порядка определяет, какая форма находится спереди, а какая — позади. Чтобы изменить порядок форм на любом слайде, следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Доступ к первому слайду.
1. Добавьте форму.
1. Добавьте текст в текстовую рамку формы.
1. Добавьте еще одну форму с теми же координатами.
1. Измените порядок форм.
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
    portion.setText("Водяной знак");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение идентификатора Interop формы**
Aspose.Slides для Java позволяет разработчикам получать уникальный идентификатор формы в области слайда в отличие от метода [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--), который позволяет получать уникальный идентификатор в области презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен в интерфейсы [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) и класс [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape). Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--), соответствует значению идентификатора объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведен пример кода.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получение уникального идентификатора формы в области слайда
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка альтернативного текста для формы**
Aspose.Slides для Java позволяет разработчикам устанавливать альтернативный текст для любой формы.
Формы в презентации могут различаться по значениям [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) или [имени формы](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-).
Методы [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) могут быть прочитаны или установлены с использованием Aspose.Slides, так же как и Microsoft PowerPoint.
Используя этот метод, вы можете пометить форму и выполнять различные операции, такие как удаление формы,
скрытие формы или изменение порядка форм на слайде.
Чтобы установить альтернативный текст для формы, следуйте следующим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Доступ к первому слайду.
1. Добавьте любую форму на слайд.
1. Выполните некоторые действия с новодобавленной формой.
1. Переберите формы, чтобы найти форму.
1. Установите альтернативный текст.
1. Сохраните файл на диск.

```java
// Создаем экземпляр класса Presentation, который представляет PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автозаполнение прямоугольной формы
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("Пользовательский текст");
        }
    }

    // Сохраняем презентацию на диск
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к форматам компоновки для формы**
Aspose.Slides для Java предоставляет простой API для доступа к форматам компоновки для формы. В этой статье показано, как вы можете получить доступ к форматам компоновки.

Ниже представлен пример кода.

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

## **Рендеринг формы как SVG**
Теперь Aspose.Slides для Java поддерживает рендеринг формы в формате SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегрузки) были добавлены в класс [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape). Этот метод позволяет сохранить содержимое формы как файл SVG. Приведенный ниже фрагмент кода показывает, как экспортировать форму слайда в файл SVG.

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

## **Выравнивание форм**
Aspose.Slides позволяет выравнивать формы либо относительно границ слайда, либо относительно друг друга. Для этой цели был добавлен перегруженный метод [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) определяет возможные параметры выравнивания.

**Пример 1**

Исходный код ниже выравнивает формы с индексами 1, 2 и 4 вдоль верхней границы слайда.

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

В приведенном ниже примере показано, как выровнять всю коллекцию форм относительно самой нижней формы в коллекции.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```