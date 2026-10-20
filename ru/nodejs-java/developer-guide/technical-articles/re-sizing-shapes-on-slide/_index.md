---
title: Изменение размеров фигур на слайдах презентации в Node.js
type: docs
weight: 130
url: /ru/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java—автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

При изменении размера слайдов презентации вам также может потребоваться изменить размер и позицию фигур, чтобы они соответствовали новым размерам. В этой статье показано, как масштабировать фигуры вручную и как работать с таблицами на слайдах, шаблонах и макетах.

## **Изменение размеров фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к исходной. Примените соответствующее отношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, меняет размер слайда на A4 и сохраняет результат. Он использует [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) с [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale), чтобы последующий цикл контролировал масштабирование. Отношения безразмерны; позиции и размеры фигур измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует её размеры шрифта.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Рассчитайте независимые горизонтальные и вертикальные коэффициенты масштабирования.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Таблицы требуют отдельной обработки: масштабировать их ширину столбцов и высоту строк вместо задания общей ширины и высоты таблицы. Высота строк может оставаться большей, чем запрошено, если содержимое ячейки требует больше места.
{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры на шаблонах и макетах, а также отдельные слайды перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждую [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) путем масштабирования ширины столбцов с помощью [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) и минимальной высоты строк с помощью [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Затем он масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Размеры таблицы управляются ширинами столбцов и высотами строк.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Рассчитайте независимые горизонтальные и вертикальные коэффициенты масштабирования.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Измените размеры фигур, определённых в мастер‑шаблонах и макетах, а также отдельных слайдах.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**  
Если изменить размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код для всех типов фигур?**  
Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**  
Масштабируйте ширину столбцов по коэффициенту ширины и минимальную высоту строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли это масштабирование работать для шаблонных и макетных слайдов?**  
Да. Второй пример проходит по [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) и каждому [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) и применяет ту же логику изменения размеров к их фигурам.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**  
Да. Вызовите [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) после изменения размера слайда и до чтения целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли предел размера слайда, который можно установить?**  
Вы можете задать пользовательские размеры слайда с помощью [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**  
Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальный макет внутри новых размеров слайда, используйте меньший из коэффициентов ширины и высоты для обеих измерений и позиций. Это сохраняет пропорции, но может оставить неиспользуемое пространство вдоль одной из сторон.