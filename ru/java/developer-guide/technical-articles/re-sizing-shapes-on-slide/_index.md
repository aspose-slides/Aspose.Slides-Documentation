---
title: Изменение размеров фигур на слайдах презентации в Java
type: docs
weight: 130
url: /ru/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /ru/java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Java — автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

Когда вы меняете размер слайдов презентации, возможно, также потребуется изменить размер и переместить её фигуры, чтобы они соответствовали новым размерам. Эта статья показывает, как масштабировать фигуры вручную и как работать с таблицами на слайдах, шаблонах и макетах.

## **Изменить размер фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на соотношение новой ширины слайда к исходной. Примените соответствующее соотношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, меняет размер слайда на A4 и сохраняет результат. Он использует [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale), чтобы последующий цикл контролировал масштабирование. Коэффициенты безразмерные; позиции фигур и их размеры измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует размеры шрифтов.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Таблицы требуют отдельной обработки: масштабировать их ширины столбцов и высоты строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячейки требует больше места.
{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры в шаблонах и макетах, а также отдельные слайды, перед сохранением изменённой презентации. Его вспомогательный класс обрабатывает каждый [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) масштабируя ширины столбцов с помощью [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) и минимальные высоты строк с помощью [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Затем он масштабирует позицию таблицы, не масштабируя её общие размеры отдельно.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Размеры таблицы контролируются шириной столбцов и высотой строк.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Изменить размер фигур, определённых в мастер‑слайдах и макетах, а также отдельных слайдов.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Вопросы и ответы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

Если вы меняете размер слайда без масштабирования фигур, они сохраняют свои исходные положения и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширины столбцов согласно коэффициенту ширины и минимальные высоты строк согласно коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли такое изменение размера работать для мастер‑слайдов и макетных слайдов?**

Да. Во втором примере происходит перебор через [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) и [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) каждого мастера, после чего применяется тот же алгоритм изменения размеров к их фигурам.

**Могу ли я изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Вызовите [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) после изменения размера слайда и до чтения целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли ограничение на размер слайда, который я могу задать?**

Вы можете задать пользовательские размеры слайда с помощью [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальный макет в новых размерах слайда, используйте меньший из коэффициентов ширины и высоты для обеих размерных параметров и позиций. Это сохраняет пропорции, но может оставить лишнее пространство вдоль одной из сторон.