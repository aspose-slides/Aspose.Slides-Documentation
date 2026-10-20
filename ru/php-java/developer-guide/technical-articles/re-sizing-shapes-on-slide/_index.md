---
title: Изменение размера фигур на слайдах презентаций в PHP
type: docs
weight: 130
url: /ru/php-java/resizing-shapes-on-slide/
aliases:
  - /ru/php-java/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java—автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

Когда вы меняете размер слайда презентации, вам также может потребоваться изменить размер и положение фигур, чтобы они соответствовали новым измерениям. Эта статья показывает, как масштабировать фигуры вручную и как работать с таблицами на слайдах, мастерах и макетах.

## **Изменить размер фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к оригинальной ширине. Примените соответствующее отношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, изменяет размер слайда на A4 и сохраняет результат. Он использует [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) с [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) так, чтобы последующий цикл контролировал масштабирование. Отношения безразмерные; позиции фигур и их размеры измеряются в пунктах. Разные отношения ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует размер шрифтов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}Таблицы требуют отдельной обработки: масштабировать ширины их столбцов и высоты строк вместо назначения общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячеек требует больше места.{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры на мастерах и макетах, а также отдельные слайды, перед сохранением изменённой презентации. Его вспомогательный метод обрабатывает каждый [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) путем масштабирования ширины столбцов с помощью [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) и минимальной высоты строк с помощью [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Затем он масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Размеры таблицы контролируются шириной столбцов и высотой строк.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Вычислить независимые горизонтальные и вертикальные коэффициенты масштабирования.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Изменить размер фигур, определённых на мастерах и макетах, а также отдельных слайдах.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**

Если вы меняете размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли приведённый код для всех типов фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте получившийся макет, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширины столбцов по коэффициенту ширины и минимальные высоты строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли такое изменение размера работать для мастер‑слайдов и макетных слайдов?**

Да. Второй пример проходит по [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) и каждому [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) мастера и применяет ту же логику изменения размера к их фигурам.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**

Да. Вызовите [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) после изменения размера слайда и перед чтением целевых размеров, чтобы коэффициенты масштабирования учитывали конечную ориентацию.

**Есть ли ограничение на размер слайда, который я могу установить?**

Вы можете задать пользовательские размеры слайда с помощью [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте одинаковый коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальный макет в новых размерах слайда, используйте меньшее из коэффициентов ширины и высоты для обеих измерений и позиций. Это сохраняет пропорции, но может оставить свободное пространство вдоль одной из сторон.