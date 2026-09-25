---
title: Управление фигурами презентации на Android
linktitle: Манипулирование фигурами
type: docs
weight: 40
url: /ru/androidjava/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получение interop ID фигуры
- Альтернативный текст фигуры
- Точка настройки фигуры
- Предустановленная настройка фигуры
- Геометрия фигуры
- Форматы макета фигуры
- Фигура как SVG
- Экспорт фигуры в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- Презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как идентифицировать, настраивать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с использованием Aspose.Slides for Android via Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/). Эта коллекция является как местом, где вы находите и изменяете фигуры, так и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье рассматривается именно такая модель. Сначала объясняется, как надежно идентифицировать фигуру и изменить предустановленные точки настройки фигуры, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему процессу.

## **Идентификация и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getName--) полезно для шаблонов, контролируемых разработчиком, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому установите соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getAlternativeText--) полезно, когда описание доступности или тег, заданный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или переписано для доступности и не гарантирует уникальность. Не переиспользуйте значимый текст доступности как ключ базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный справочник в течение жизни фигуры. Клонированная или воссозданная фигура — это другая фигура и получает собственный ID.

Связанный метод [getUniqueId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getUniqueId--) возвращает идентификатор в рамках презентации, но он предназначен для надстроек и может быть переназначен. Его не следует рассматривать как постоянный внешний ключ. Если долгосрочная идентичность критична, храните сопоставление во внешних данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Для практического примера чтения и обновления как альтернативного текста‑заголовка, так и описания, смотрите [Manage Alternative Text Titles and Descriptions](/slides/ru/androidjava/presentation-accessibility/). Используйте альтернативный текст, чтобы пояснить смысл визуального элемента читателям, и держите его отдельно от имён фигур, которые использует код для их поиска.

Следующий пример ищет по имени с точным сравнением и выводит межоперационный ID в рамках слайда. Если шаблон не содержит ожидаемой фигуры, код сообщает об этом результате вместо продолжения работы с неверным объектом.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Когда операция специфична для типа фигуры, проверьте интерфейс перед использованием членов, характерных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Идентификация и изменение предустановленных настроек фигур**

Фигуры с предустановленной геометрией могут раскрывать точки настройки, которые управляют такими параметрами, как размер угла, пропорции стрелки или угол дуги. Получайте к ним доступ через только‑для‑чтения коллекцию [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Коллекцию предоставляет сама фигура, но каждый [IAdjustValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Пройдите все настройки и изучите только‑для‑чтения метод [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getType--) , чей тип [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeadjustmenttype/) описывает, что контролирует настройка. Метод только‑для‑чтения [getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getName--) предоставляет дополнительную информацию для идентификации и особенно полезен, когда предустановка содержит более одной настройки с одинаковым семантическим типом.

Используйте метод значения, соответствующий смыслу настройки:

| Тип коррекции | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер скруглённых углов | [setRawValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `setRawValue` |
| `ArrowheadLength` | Длина острия стрелки | `setRawValue` |
| `ArrowheadWidth` | Ширина острия стрелки | `setRawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Конечный угол сектора или дуги | `setAngleValue` |

`getType` и `getName` возвращают только‑для‑чтения информацию. `getRawValue` и `setRawValue` работают с целым числом в нативных единицах геометрии предустановки, тогда как `getAngleValue` и `setAngleValue` работают с углом в градусах. Количество, порядок, смысл и допустимый диапазон настроек зависят от предустановленного [ShapeType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Значение, корректное для одной предустановки, может быть некорректным или иметь иной эффект для другой.

Когда `getType` возвращает `ShapeAdjustmentType.Custom`, API не распознаёт стандартный семантический смысл. Изучите `getName`, тип предустановки и текущее значение и оставьте настройку без изменения, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверьте, не встречается ли тот же тип более одного раза перед выбором значения. Статья [Connector](/slides/ru/androidjava/connector/) демонстрирует эту ситуацию с настройками изгиба соединителей.

Следующий полный пример создаёт обычные и изменённые версии трёх предустановленных фигур. Он проходит каждую настройку, выводит её имя и тип, меняет размеры через `setRawValue`, меняет углы через `setAngleValue` и сохраняет результат. Левая колонка сохраняет геометрию по умолчанию; правая показывает изменённый закруглённый прямоугольник, четырёхстороннюю стрелку и сектор.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет заголовки для столбцов фигур по умолчанию и изменённых.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Проверка семантического типа перед изменением значения делает код явным относительно намерения и избавляет от предположения, что конкретный индекс коллекции имеет одинаковый смысл для разных предустановленных фигур.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочения работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, полученные до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) создаёт независимую копию и добавляет её в целевую коллекцию. [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) тоже создаёт копию, но помещает её в указанный индекс z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения размера; перегрузки с шириной и высотой могут изменить размер.

Пример создаёт слайд‑назначение, клонирует помеченный прямоугольник на передний план и вставляет второй клон в задний план. Изменения любого из клонов не влияют на исходную фигуру.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам проходите с конца, чтобы каждый оставшийся индекс оставался валидным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает фигуру по текущему индексу, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

После удаления меняются количество фигур и индексы последующих фигур. Ссылки на неизменённые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) в `true` оставляет фигуру в коллекции, но препятствует её отображению в обычном показа слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для опциональных элементов, которые могут быть восстановлены позже.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрытие — это не удаление и не защита. Объект всё ещё может быть найден и отображён пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [reorder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `size() - 1` — передний.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к последнему индексу помещает его спереди. Завершайте упорядочивание после добавления или клонирования всех связанных фигур, потому что эти операции добавляют или вставляют новые элементы коллекции и могут изменить задуманную стек‑структуру.

## **Осмотр фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета не является тем же объектом, что и аналогично расположенная фигура на обычном слайде. Осматривайте фигуры макета, когда нужно понять или изменить форматирование, заданное макетом.

Следующий пример читает у каждой фигуры макета её [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getFillFormat--) и [LineFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getLineFormat--) без предположения, что каждая фигура является `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Редактирование макета может повлиять на несколько слайдов, которые его используют. Прежде чем изменить фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[writeAsSvg](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не весь фон слайда или соседние фигуры.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и должна его закрыть.

## **Выравнивание фигур**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) перегружается для выравнивания либо всех фигур, либо выбранных индексов коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapesalignmenttype/) задаёт край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Возвратные ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Выравнивание меняет позицию, а не Z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения расстояний. Пересчитайте индексы, если меняете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeframe/) хранит положение, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/): `True` включает отражение, `False` отключает, а `NotDefined` сохраняет неуказанное/значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![The shape before flipping](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что присвоение нового [Frame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) заменяет весь кадр.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом её положение, размер и вращение остаются прежними.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Следует ли использовать индекс коллекции как идентификатор фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенную конвенцию `Name` или `AlternativeText` для шаблонов, созданных вручную, либо `OfficeInteropShapeId` для работы с межоперационными задачами в пределах слайда.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клонированная фигура оказалась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что является передним слоем Z‑порядка. Используйте `insertClone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации предустановленной настройки фигуры?**

Только после проверки точной предустановки и структуры коллекции. Предпочтительно проходить `IGeometryShape.getAdjustments` и проверять `IAdjustValue.getType`; используйте `IAdjustValue.getName` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.