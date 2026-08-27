---
title: Управление фигурами презентации на Android
linktitle: Манипулирование фигурами
type: docs
weight: 40
url: /ru/androidjava/shape-manipulations/
keywords:
- Фигура PowerPoint
- фигура презентации
- фигура на слайде
- поиск фигуры
- клонирование фигуры
- удаление фигуры
- скрытие фигуры
- изменение порядка фигур
- получить межоперационный ID фигуры
- альтернативный текст фигуры
- точка регулировки фигуры
- регулировка предустановленной фигуры
- геометрия фигуры
- форматы макета фигуры
- фигура как SVG
- фигура в SVG
- выравнивание фигуры
- отражение фигуры
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как идентифицировать, настраивать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides for Android via Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/). Коллекция служит как местом, где можно находить и изменять фигуры, так и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала она объясняет, как надёжно идентифицировать фигуру и изменить предустановленные точки регулировки, затем показывает, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование уровня макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому можно использовать только те операции, которые требуются в вашем рабочем процессе.

## **Идентификация и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выбирайте идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getName--) удобно для шаблонов, контролируемых разработчиком, и его легко увидеть в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому установите соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getAlternativeText--) полезно, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или переписано для доступности и также не гарантирует уникальность. Не переиспользуйте осмысленный текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный референс в течение жизни фигуры. Склонированная или воссозданная фигура — это другая фигура и получает собственный ID.

Связанный метод [getUniqueId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getUniqueId--) возвращает идентификатор в пределах презентации, но он предназначен для ад‑инов и может быть переназначен. Его не следует рассматривать как постоянный внешний ключ. Если долговременная идентичность важна, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Ниже пример ищет по имени с точным сравнением и выводит межоперационный ID, ограниченный слайдом. Когда в шаблоне отсутствует ожидаемая фигура, код сообщает об этом вместо продолжения работы с неправильным объектом.

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

Когда операция специфична для типа фигуры, проверьте интерфейс перед использованием членов, характерных для типа. В этом примере обновляются текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/).

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

## **Идентификация и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут иметь точки регулировки, управляющие такими параметрами, как размер углов, пропорции стрелки или угол дуги. Доступ к ним осуществляется через только‑для‑чтения коллекцию [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Коллекцию предоставляет сама фигура, но каждый [IAdjustValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Перебирайте регулировки и проверяйте только‑для‑чтения метод [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getType--) , чьё значение [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeadjustmenttype/) описывает, что контролирует данная регулировка. Метод только‑для‑чтения [getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#getName--) предоставляет дополнительную идентифицирующую информацию и особенно полезен, когда предустановка содержит более одной регулировки одного и того же семантического типа.

Используйте метод значения, соответствующий смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер скруглённого угла | [setRawValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `setRawValue` |
| `ArrowheadLength` | Длина острия стрелки | `setRawValue` |
| `ArrowheadWidth` | Ширина острия стрелки | `setRawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Конечный угол сектора или дуги | `setAngleValue` |

`getType` и `getName` возвращают только‑для‑чтения информацию. `getRawValue` и `setRawValue` работают с целым числом в родных геометрических единицах предустановки, тогда как `getAngleValue` и `setAngleValue` работают с углом в градусах. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановленного [ShapeType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Значение, корректное для одной предустановки, может быть некорректным или иметь иной эффект для другой.

Когда `getType` возвращает `ShapeAdjustmentType.Custom`, API не распознаёт стандартный семантический смысл. Проанализируйте `getName`, тип предустановки и текущее значение и оставьте регулировку без изменения, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверяйте, не встречается ли такой же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/androidjava/connector/) демонстрирует эту ситуацию с регулировками изгиба соединителей.

Ниже полное примере создаёт стандартные и изменённые версии трёх предустановленных фигур. Он перебирает каждую регулировку, выводит её имя и тип, изменяет значения, связанные с размером, через `setRawValue`, изменяет углы через `setAngleValue` и сохраняет результат. В левом столбце показана геометрия по умолчанию; в правом — скорректированные округлый прямоугольник, четырёхстрелевая стрелка и сектор.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Добавляет заголовки для столбцов с фигурами по умолчанию и отрегулированными фигурами.
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

Проверка семантического типа перед изменением значения делает код явным в отношении намерения и избавляет от предположения, что определённый индекс коллекции имеет одинаковое значение в разных предустановках.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) создаёт независимую копию и добавляет её в конец целевой коллекции. [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) также создаёт копию, но помещает её в указанный индекс порядка z. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут изменить размер.

В примере создаётся целевой слайд, клонируется помеченный прямоугольник на передний план, а второй клон вставляется в задний план. Изменения любого из клонов не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новым логическим идентификаторам клона, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) удаляет конкретный объект фигуры из его коллекции. При удалении нескольких совпадений во время итерации по индексам перебирайте коллекцию в обратном порядке, чтобы каждый оставшийся индекс оставался корректным.

В этом примере удаляются все фигуры с заданным именем. Он читает фигуру по текущему индексу, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

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

После удаления количество фигур и индексы последующих фигур меняются. Ссылки на не затронутые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить более, чем только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) в значение `true` сохраняет фигуру в коллекции, но предотвращает её отображение в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие уместно для опциональных элементов, которые могут быть восстановлены позже.

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

Скрытие — это не удаление и не средство защиты. Объект всё ещё может быть обнаружен и раскрыт пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение порядка Z**

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

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к конечному индексу помещает его спереди. Завершайте порядок z после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют или вставляют новые элементы коллекции и могут изменить задуманную структуру наложения.

## **Проверка фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета — это не тот же объект, что и аналогично расположенная фигура на обычном слайде. Проверяйте фигуры макета, когда необходимо понять или изменить форматирование, предоставляемое макетом.

В следующем примере читаются [FillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getFillFormat--) и [LineFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getLineFormat--) каждой фигуры макета без предположения, что каждая фигура является `AutoShape`.

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

Редактирование макета может повлиять на несколько слайдов, использующих его. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

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

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Владелец потока — вызывающая сторона, и он должна закрыть поток.

## **Выравнивание фигур**

Метод [SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) имеет перегрузки, позволяющие выравнивать либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapesalignmenttype/) задаёт сторону, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать границы слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

В примере три фигуры выравниваются по верхнему краю слайда. Ссылки на фигуры, возвращённые методом, сразу преобразуются в их текущие индексы перед выравниванием.

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

Выравнивание меняет позиции, а не порядок z. Относительное выравнивание обычно требует как минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения промежутков. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `getFlipH` и `getFlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/) : `True` — включить отражение, `False` — выключить, `NotDefined` — сохраняет неуказанное/по‑умолчанию состояние.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

В примере сохраняются все остальные параметры кадра и изменяются только два параметра отражения. Это важно, потому что присвоение нового [Frame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) заменяет весь кадр.

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

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом сохраняются её позиция, размер и вращение.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительнее использовать проверенную конвенцию `Name` или `AlternativeText` для подготовленных шаблонов, либо `OfficeInteropShapeId` для работы с межоперационными задачами в пределах слайда.

**Удаляет ли скрытие фигуры её из порядка z?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему склонированная фигура оказалась перед другой фигурой?**

`addClone` добавляет клон в конец коллекции, что соответствует передней части порядка z. Используйте `insertClone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации регулировки предустановленной фигуры?**

Только после подтверждения точной предустановки и структуры коллекции. Предпочтительно перебрать `IGeometryShape.getAdjustments` и проверять `IAdjustValue.getType`; при наличии нескольких регулировок одного семантического типа используйте `IAdjustValue.getName` как дополнительную информацию.