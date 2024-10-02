---
title: Манипуляции с формами
type: docs
weight: 40
url: /ru/androidjava/shape-manipulations/
---

## **Найти форму на слайде**
Эта тема описывает простую технику, которая облегчит разработчикам поиск конкретной формы на слайде без использования ее внутреннего идентификатора. Важно знать, что файлы презентаций PowerPoint не имеют никакого способа идентификации форм на слайде, кроме внутреннего уникального идентификатора. Похоже, что разработчикам трудно найти форму, используя ее внутренний уникальный идентификатор. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы предлагаем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint, чтобы определить альтернативный текст для объектов, которые вы планируете изменить в будущем.

После установки альтернативного текста для любой желаемой формы, вы можете открыть эту презентацию, используя Aspose.Slides для Android через Java, и перебирать все формы, добавленные на слайд. Во время каждой итерации вы можете проверить альтернативный текст формы, и форма с соответствующим альтернативным текстом будет той формой, которая вам нужна. Чтобы более наглядно продемонстрировать эту технику, мы создали метод [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), который выполняет трюк по поиску конкретной формы на слайде и просто возвращает эту форму.

```java
// Создаем экземпляр класса Presentation, представляющего файл презентации
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
// Реализация метода для поиска формы на слайде с использованием ее альтернативного текста
public static IShape findShape(ISlide slide, String alttext)
{
    // Перебор всех форм внутри слайда
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Если альтернативный текст слайда совпадает с требуемым, то
        // возращаем форму
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Клонировать форму**
Чтобы клонировать форму на слайд с использованием Aspose.Slides для Android через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните измененную презентацию в виде файла PPTX.

Пример ниже добавляет группировку форм на слайд.

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

    // Запишите файл PPTX на диск
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удалить форму**
Aspose.Slides для Android через Java позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определенным AlternativeText.
1. Удалите форму.
1. Сохраните файл на диск.

```java
// Создаем объект Presentation
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автофигуру прямоугольной формы
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

    // Сохраните презентацию на диск
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Скрыть форму**
Aspose.Slides для Android через Java позволяет разработчикам скрывать любую форму. Чтобы скрыть форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определенным AlternativeText.
1. Скрыть форму.
1. Сохраните файл на диск.

```java
// Создаем экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автофигуру прямоугольной формы
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

    // Сохраните презентацию на диск
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменить порядок форм**
Aspose.Slides для Android через Java позволяет разработчикам изменять порядок форм. Изменение порядка форм указывает, какая форма находится спереди, а какая - сзади. Чтобы изменить порядок формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте форму.
1. Добавьте текст в текстовую рамку формы.
1. Добавьте другую форму с теми же координатами.
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
    portion.setText("Текст водяного знака Текст водяного знака Текст водяного знака");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить Interop Shape ID**
Aspose.Slides для Android через Java позволяет разработчикам получить уникальный идентификатор формы в контексте слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--), который позволяет получить уникальный идентификатор в контексте презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен в интерфейсы [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) и класс [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) соответственно. Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--), соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведен пример кода.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получение уникального идентификатора формы в контексте слайда
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить альтернативный текст для формы**
Aspose.Slides для Android через Java позволяет разработчикам устанавливать альтернативный текст (AlternateText) для любой формы. Формы в презентации могут быть различены с помощью методов [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) или [Имя формы](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Методы [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) могут быть прочитаны или установлены с помощью Aspose.Slides, а также Microsoft PowerPoint. С помощью этого метода вы можете маркировать форму и выполнять различные операции, такие как удаление формы, скрытие формы или изменение порядка форм на слайде. Чтобы установить альтернативный текст для формы, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте любую форму на слайд.
1. Выполните некоторые действия с вновь добавленной формой.
1. Переберите формы, чтобы найти нужную форму.
1. Установите альтернативный текст.
1. Сохраните файл на диск.

```java
// Создаем экземпляр класса Presentation, представляющего PPTX
Presentation pres = new Presentation();
try {
    // Получаем первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляем автофигуру прямоугольной формы
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

    // Сохраните презентацию на диск
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение форматов размещения для формы**
Aspose.Slides для Android через Java предоставляет простой API для доступа к форматам размещения для формы. Этот раздел демонстрирует, как можно получить доступ к форматам размещения.

Ниже приведен образец кода.

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
Теперь Aspose.Slides для Android через Java поддерживает отрисовку формы в виде SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегруженные версии) был добавлен в классы [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Этот метод позволяет сохранить содержимое формы в виде файла SVG. Пример кода ниже показывает, как экспортировать форму слайда в файл SVG.

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
Aspose.Slides позволяет выравнивать формы либо относительно полей слайда, либо относительно друг друга. Для этой цели была добавлена перегруженная версия метода [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) определяет возможные варианты выравнивания.

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
```

**Пример 2**

В следующем примере показано, как выровнять всю коллекцию форм относительно нижней формы в коллекции.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```