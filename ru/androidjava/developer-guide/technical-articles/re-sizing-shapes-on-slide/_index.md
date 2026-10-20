---
title: Изменение размеров фигур на слайдах презентации в Android
type: docs
weight: 130
url: /ru/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- Android
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java — автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

При изменении размера слайда презентации вам также может потребоваться изменить размер и положение её фигур, чтобы они соответствовали новым габаритам. Эта статья показывает, как вручную масштабировать фигуры и как работать с таблицами на слайдах, мастерах и макетах.

## **Изменение размеров фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к исходной ширине. Аналогичное отношение высоты примените к вертикальным координатам и высоте.

В первом примере загружается презентация, у которой на слайдах нет таблиц, изменяется размер слайда на A4 и сохраняется результат. Он использует [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale), чтобы последующий цикл контролировал масштабирование. Отношения безразмерные; позиции и размеры фигур измеряются в пунктах. Разные отношения ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует её размер шрифта.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Вычислите независимые горизонтальные и вертикальные коэффициенты масштабирования.
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
Таблицы требуют отдельной обработки: масштабировать их ширину столбцов и высоту строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячейки требует больше места.
{{% /alert %}}

Во втором примере поддерживаются таблицы, и обрабатываются фигуры на мастерах и макетах, а также отдельные слайды перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждый [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) масштабируя ширину столбцов с помощью [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) и минимальную высоту строк с помощью [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Затем он масштабирует позицию таблицы, не изменяя её общие размеры отдельно.
```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Размеры таблицы управляются шириной столбцов и высотой строк.
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

    // Изменить размеры фигур, определённых на мастерах и макетах, а также на отдельных слайдах.
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

**Почему после изменения размера слайда фигуры выглядят искажёнными или обрезанными?**

Если изменить размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширину столбцов по коэффициенту ширины и минимальную высоту строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли такое масштабирование работать для слайдов‑мастеров и макетных слайдов?**

Да. Во втором примере происходит итерация по [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) и по каждому [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) мастера, после чего к их фигурам применяется та же логика изменения размеров.

**Можно ли изменить ориентацию слайда (портрет/альбом) вместе с изменением его размера?**

Да. Вызовите [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) после изменения размера слайда и до чтения целевых габаритов, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Существует ли ограничение на размер слайда, который я могу установить?**

Вы можете указать пользовательские размеры слайда с помощью [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы поместить исходный макет в новые габариты слайда, используйте меньшее из двух отношений (по ширине и высоте) для обеих размеров и позиций. Это сохраняет пропорции, но может оставить незаполненное пространство вдоль одной из сторон.