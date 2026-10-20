---
title: Изменение размера фигур на слайдах презентации в Android
type: docs
weight: 130
url: /ru/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /ru/androidjava/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- Android
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java — автоматизируйте настройку макета слайдов и повышайте продуктивность."
---
## **Обзор**

При изменении размера слайда презентации вам также может потребоваться изменить размер и переместить её фигуры, чтобы они соответствовали новым размерам. В этой статье показано, как вручную масштабировать фигуры и как работать с таблицами на слайдах, мастерах и разметках.

## **Изменить размер фигур**

Для сохранения относительного положения и размера каждой фигуры умножьте её горизонтальные координаты и ширину на коэффициент отношения новой ширины слайда к исходной ширине. Примените аналогичный коэффициент высоты к вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, изменяет размер слайда на A4 и сохраняет результат. Он использует [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale), чтобы последующий цикл контролировал масштабирование. Коэффициенты безразмерны; позиции и размеры фигур измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует её размеры шрифтов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
Таблицам требуется отдельная обработка: масштабировать ширину их столбцов и высоту строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячейки требует больше места.
{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры на мастерах и разметках, а также отдельные слайды перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждый [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) путем масштабирования ширины столбцов с помощью [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) и минимальной высоты строк с помощью [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Затем он масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Размеры таблицы контролируются ширинами столбцов и высотами строк.
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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Изменить размер фигур, определённых в мастерах и разметках, а также отдельных слайдов.
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

## **Часто задаваемые вопросы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

Если изменить размер слайда без масштабирования фигур, они сохранят свои исходные позиции и размеры и могут выйти за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте полученную разметку, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширину столбцов по коэффициенту ширины и минимальную высоту строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли это масштабирование работать для мастеров и разметок слайдов?**

Да. Во втором примере происходит перебор через [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) и каждую [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) мастера, применяя ту же логику изменения размера к их фигурам.

**Можно ли изменить ориентацию слайда (портрет/альбом) вместе с изменением размера?**

Да. Вызовите [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) после изменения размера слайда и перед считыванием целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли ограничение на размер слайда, который я могу установить?**

Вы можете указать пользовательские размеры слайда с помощью [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальную разметку внутри новых размеров слайда, используйте меньший из коэффициентов ширины и высоты для обеих измерений и позиций. Это сохраняет пропорции, но может оставить неиспользованное пространство вдоль одного из краёв.