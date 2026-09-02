---
title: Управление объектами чернил презентации в PHP
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/php-java/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисование чернил
- рисование
- экспорт чернил
- рендеринг чернил
- скрыть чернила
- InkOptions
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте трассы и свойства кисти, а также контролируйте внешний вид чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для PHP через Java."
---
## **Введение**

PowerPoint предоставляет функцию чернил, позволяющую рисовать произвольные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде.

Aspose.Slides предоставляет типы, необходимые для работы с объектами чернил. Например, класс [Ink](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/). В своей простейшей форме форма является контейнером, определяющим область самого объекта (его рамку), а также такие свойства, как размер контейнера, форма и фон. Подробнее см. раздел [Shape Layout Format](https://docs.aspose.com/slides/ru/php-java/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства кадра объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными методами [Shape.getWidth](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getWidth) и [Shape.getHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Трассы чернил**

Трасса чернил — базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровыми чернилами. Трасса хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой точки выборки. Когда все соединённые точки отображаются, они образуют изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки трассы чернил. Кисть имеет собственный цвет и размер, которые представлены методами [InkBrush.getColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkbrush/#getColor) и [InkBrush.getSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkbrush/#getSize).

### **Установить цвет кисти чернил**

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Установить размер кисти чернил**

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его трасс. Здесь целевой объект (трасса рукописного текста) масштабирован до размеров контейнера (рамки). Когда меняется размер контейнера, размер кисти остаётся постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление внешним видом чернил при экспорте и рендеринге**

Aspose.Slides предоставляет класс [InkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/) для управления тем, как объекты чернил отображаются в экспортируемом или отрисованном выводе. Вы можете использовать его свойства, чтобы полностью скрыть чернила или изменить способ интерпретации операций маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких типов вывода:

| Вывод | Свойство параметров чернил |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Следующие методы [InkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/) раскрывают те же две настройки:

- `[InkOptions.getHideInk](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#getHideInk)` определяет, включаются ли объекты чернил в вывод. Значение по умолчанию — `false`.
- `[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity)` определяет, интерпретируется ли операция маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `true`; вызов `[InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)` с `false` переключает на операцию ROP.

### **Скрыть объекты чернил в PDF‑выводе**

По умолчанию объекты чернил остаются видимыми при экспорте. Чтобы создать чистый вывод без рукописных аннотаций или другого контента чернил, вызовите `[InkOptions.setHideInk](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#setHideInk)` с `true`.

Следующий пример PHP экспортирует презентацию в PDF, скрывая все объекты чернил:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Скрыть объекты чернил при рендеринге слайда как изображения**

Чтобы скрыть объекты чернил при рендеринге слайдов в растровые изображения, настройте `[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/renderingoptions/#getInkOptions)` и передайте параметры рендеринга в `[Slide.getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getImage)`.

Следующий пример PHP рендерит первый слайд в PNG‑изображение без объектов чернил:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Управление рендерингом маски чернил**

Настройка `[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity)` контролирует, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `true`, что использует непрозрачность. Чтобы вместо этого использовать операцию ROP, вызовите `[InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)` с `false`.

Следующий пример PHP экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

То же самое можно применить через `[TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/tiffoptions/#getInkOptions)` при экспорте презентации или рендеринге слайда в TIFF.

### **Выберите, скрывать или сохранять чернила**

Когда требуется чистая версия аннотированной презентации для распространения без пометок обзора, вызовите `[InkOptions.setHideInk](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#setHideInk)` с `true` при экспорте.

Оставьте `[InkOptions.getHideInk](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#getHideInk)` со значением по умолчанию `false`, когда аннотации чернил являются частью задуманного содержания, например, комментарии обзора, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные версии для обзора и финального вывода из одной и той же презентации без изменения исходных объектов чернил.

## **Часто задаваемые вопросы**

**Можно ли изменить цвет или размер существующего штриха чернил?**

Да. Получите трассу через `[Ink.getTraces](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ink/#getTraces)`, затем измените её `[InkTrace.getBrush](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inktrace/#getBrush)`. Вызовите `[InkBrush.setColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkbrush/#setColor)` или `[InkBrush.setSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkbrush/#setSize)`, чтобы изменить кисть.

**Изменяет ли скрытие чернил исходную презентацию?**

Нет. Вызов `[InkOptions.setHideInk](https://reference.aspose.com/slides/ru/php-java/aspose.slides/inkoptions/#setHideInk)` влияет только на отрисованный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, показанные выше.

**Дополнительные материалы**

* Чтобы узнать о фигурах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/php-java/powerpoint-shapes/).
* Для получения информации о эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/php-java/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF см. [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/php-java/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML см. [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/php-java/convert-powerpoint-to-html/).
* Подробности экспорта в SVG см. [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/php-java/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF см. [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/php-java/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайдов в изображения см. [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/php-java/convert-slide/).