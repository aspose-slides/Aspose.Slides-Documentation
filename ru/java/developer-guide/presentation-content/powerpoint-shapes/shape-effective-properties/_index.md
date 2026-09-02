---
title: "Получить эффективные свойства фигур из презентаций на Java"
linktitle: "Эффективные свойства"
type: docs
weight: 50
url: /ru/java/shape-effective-properties/
keywords:
  - свойства фигур
  - свойства камеры
  - система освещения
  - форма с фаской
  - текстовый фрейм
  - стиль текста
  - высота шрифта
  - формат заливки
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Java, чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Понимание локальных, унаследованных и эффективных свойств**

Форматирование PowerPoint может приходить из разных источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint ищет в родительских источниках форматирования, таких как значение по умолчанию абзаца, стиль текста, макет или шаблон слайда, тема или настройки по умолчанию для всей презентации. Эти значения являются **унаследованными значениями**. Значение, оставшееся после разрешения всей иерархии, является **эффективным значением** — значением, используемым при отображении объекта.

Например, часть текста может не определять собственный размер шрифта. её локальное [getFontHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) значение тогда равно `Float.NaN`, что означает «не задано здесь». Часть может унаследовать высоту от абзаца, стиля текста презентации или другого применимого источника. Вызов [getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/#getEffective--) у формата части возвращает окончательно разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читайте или изменяйте локальный объект формата, например [IPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/), когда нужно контролировать, где определено значение.
- Читайте объект эффективных данных, например [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformateffectivedata/), когда нужен окончательный отрисованный результат. Эффективные данные доступны только для чтения.

## **Сравнение локальных, унаследованных и эффективных значений**

Ниже приведён полный пример, который создаёт фигуру и задаёт высоты шрифта на уровнях презентации, абзаца и части текста. На каждом шаге выводятся значения, определённые на этих уровнях, и получаемое эффективное значение для той же части текста. Пример также демонстрирует, почему после изменения форматирования необходимо заново читать эффективные данные.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Определите унаследованные значения на двух разных уровнях.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Локальное значение в части переопределяет оба унаследованных значения.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Изменение унаследованного значения не переопределяет существующее локальное значение.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Очистите локальное значение. Часть снова наследует значение от абзаца.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Очистите значение абзаца. Значение по умолчанию презентации теперь используется.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Прочитайте эффективные данные после предыдущих изменений.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. У других объектов могут быть другие цепочки наследования, но принцип остаётся тем же: более конкретное явно заданное значение выигрывает, а [getEffective](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/#getEffective--) возвращает конечный результат.

## **Получение эффективных свойств текста**

Форматирование текста распределено между несколькими объектами:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframeformat/#getEffective--) разрешает свойства текстового фрейма, такие как отступы, привязка, автоподгонка и направление вертикального текста.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextstyle/#getEffective--) разрешает форматирование абзаца для каждого уровня стиля текста.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getEffective--) разрешает свойства абзаца, такие как выравнивание, отступы и маркеры.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/#getEffective--) разрешает свойства символов, такие как высота шрифта, гарнитура, цвет, жирный и курсив.

Для следующего примера файл `text-formatting.pptx` должен содержать как минимум один слайд и одну [AutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/autoshape/) с непустым текстовым фреймом. AutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Получение эффективных 3D‑свойств**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformat/#getEffective--) возвращает один объект [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformateffectivedata/), который группирует все разрешённые 3D‑настройки. Его методы [getCamera](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), [getBevelBottom](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) предоставляют соответствующие эффективные данные. Чтение этих связанных настроек вместе упрощает понимание окончательного 3D‑вида фигуры.

Для этого примера файл `shape-3d.pptx` должен содержать хотя бы одну фигуру на первом слайде. При желании добавьте к этой фигуре 3D‑камеру, освещение или срезы, чтобы в выводе появились значения, отличные от значений по умолчанию.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может поступать из стиля таблицы и из форматов, применённых к всей таблице, столбцу, строке или отдельной ячейке. При конфликте явно заданных заливок приоритет такой: ячейка, строка, столбец, затем вся таблица. Эффективный формат ячейки — это окончательный формат, используемый при её отрисовке.

Для этого примера файл `table-formatting.pptx` должен содержать хотя бы одну таблицу на первом слайде. Таблица должна иметь минимум одну строку и один столбец. Код ищет объект [ITable](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itable/), а не предполагает, что `getShapes().get_Item(0)` является таблицей.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Если нужен цвет, а не только тип заливки, сначала проверьте эффективный [getFillType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), а затем вызовите метод, соответствующий этому типу — например, [getSolidFillColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент их разрешения. Вызовите `getEffective` снова после изменения любого элемента, участвующего в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового фрейма;
- стиль таблицы, формат таблицы, столбца, строки или ячейки;
- форматирование макета или шаблона слайда;
- данные темы или значения по умолчанию презентации;
- макет или шаблон, назначенный слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутри, а последующий вызов `getEffective` может обновить эти данные. Если нужно сравнить значения до и после изменения, скопируйте нужные скалярные значения — например, высоту шрифта, цвет, выравнивание или ширину среза — в свои переменные перед внесением изменений.

Чтобы изменить значение, обновите соответствующий локальный объект формата, а затем вызовите `getEffective` для проверки результата. Объекты эффективных данных сами по себе только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат только конечное значение, а не его источник. Проверьте применимые локальные объекты, начиная с самого конкретного уровня и переходя наружу. Для текста это могут быть часть, абзац, текстовый фрейм, макет, шаблон, тема и значения по умолчанию презентации. Неопределённые значения, такие как `Float.NaN` или `null`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, если ни один уровень не задаёт свойство?**

Aspose.Slides разрешает соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не задаёт.

**Почему эффективное значение иногда совпадает с локальным?**

Локальное значение выиграло в расчёте наследования. Это ожидаемая ситуация, когда свойство явно установлено в объекте и более специфическое правило его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**

Используйте локальные данные для инспекции или изменения конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный вид после учёта наследования, правил темы и применимых стилей. Полный пример сравнения ([complete comparison example](#compare-local-inherited-and-effective-values)) демонстрирует оба подхода в одном рабочем процессе.