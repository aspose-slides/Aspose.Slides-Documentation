---
title: Экспортировать слайды презентаций как SVG‑изображения в PHP
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Экспортировать слайды PowerPoint как SVG‑изображения в PHP и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый формат изображений на основе XML, который хорошо подходит для публикаций в Интернете, просмотров слайдов, рабочих процессов доступности и автоматической постобработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым в разных браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Приведённый ниже пример экспортирует каждый слайд презентации в отдельный файл SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Имя файла использует [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) вместо индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg), когда средство просмотра слайдов или веб‑страница нуждаются только в этой фигуре.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) определяет, применяется ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `true`, когда текст должен рендериться без лигатур.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Управление обрезкой концов линий у наконечников стрелок**

В SVG 1.1 нет настройки вставки маркера, позволяющей указать, где линия должна прекращаться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортированную линию, чтобы её обводка не выступала за пределы маркера. Вызовите [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) с `true`, чтобы рисовать обводку до оригинального конца линии. Эта настройка влияет только на вывод SVG. Линия сохраняет своё положение и длину на слайде.

В примере рисуются треугольные и ромбовидные наконечники стрелок на линиях шириной 2 и 10 пунктов. Он экспортирует один и тот же слайд дважды, изменяя только параметр обрезки.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Сравнение показывает треугольный наконечник на линии шириной 10 пунктов. При включённой обрезке кончик остаётся острым. При отключённой обрезке обводка выступает за наклонные стороны маркера, образуя плоский конец.

![Увеличенный треугольник шириной 10 пунктов с острым наконечником при включённой обрезке и плоским концом при отключённой обрезке](line-end-cropping.png)

В остальных линиях примера выступающая обводка менее заметна на треугольнике шириной 2 пункта. Заполненный ромб покрывает конец обводки в обеих ширинах.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете управлять тем, остаётся ли текст в виде текста или преобразуется в векторную графику, а также тем, как включаются или ссылаются внешние шрифты. Ниже приведённые параметры помогут вам сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) в `true`, чтобы записать весь текст слайда как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, но текст больше не будет выделяемым или searchable как SVG‑текст.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Убедитесь в наличии лицензий на шрифты перед их внедрением.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Сокращение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) для снижения разрешения встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) для исключения обрезанных областей исходных изображений и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) для управления качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт качества изображения или сохранённых данных изображения.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Управление разрешением растеризации метафайлов**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы сбалансировать детализацию и размер файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), который содержит изображение EMF с плотно расположенными диагональными линиями. Приведённый пример экспортирует первый слайд с тремя разрешениями растеризации с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Все остальные параметры экспорта остаются одинаковыми, чтобы можно было сравнить результаты.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

В результате EMF превратился в один встроенный PNG в каждом SVG. Приведённые измерения относятся к поставленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растра при одинаковом увеличенном размере отображения. Диагональные линии демонстрируют видимую пикселизацию при 72 DPI и более плавные края при более высоких разрешениях, в то время как размер SVG файла растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Увеличенная детализация диагональной линии при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) управляет уменьшением разрешения изображения и может скрывать эффект изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначение стабильных идентификаторов фигурам и тексту**

Предоставьте callback форматирования в [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController), чтобы установить [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) для каждой SVG‑фигуры. Callback также может задавать значения [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) для элементов `tspan` текста.

PhpJavaBridge не может вызвать PHP‑callback из `writeAsSvg`, когда он работает в режиме потока. Поместите логику форматирования в небольшой Java‑класс‑помощник, скомпилируйте его и добавьте полученный JAR‑файл в путь классов моста. Помощник может использовать [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), который стабилен в течение жизненного цикла фигуры, и повторяющийся счётчик для её текстовых спанов. Смотрите [Java implementation of `StableSvgIdController`](/slides/ru/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) для кода помощника.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Добавление обработчиков событий SVG**

В callback форматирования вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) с значением [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) , чтобы добавить обработчик JavaScript к экспортированной фигуре. Присвойте callback с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) и определите JavaScript‑функцию на странице или в документе SVG, который содержит результат.

Как и в случае со стабильными идентификаторами, реализуйте callback в Java‑помощнике, когда PhpJavaBridge использует режим потока. [Java implementation of `SvgEventController`](/slides/ru/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) назначает идентификатор и обработчик `OnClick` фигуре с именем `ActionButton`. Скомпилируйте этот помощник, добавьте его в путь классов моста как `com.example.slides.SvgEventController` и используйте его из PHP следующим образом:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Страница‑хост может определить JavaScript‑функцию, на которую ссылается обработчик. Назначение идентификаторов и обработчиков событий позволяет создавать средства просмотра слайдов, улучшать доступность и реализовывать другие интерактивные рабочие процессы SVG.

## **Часто задаваемые вопросы**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, так как уменьшение разрешения изображения, снижение качества JPEG и векторизация текста каждый вносят свои компромиссы между качеством и размером.

**Можно ли изменить экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через callback форматирования, а затем выберите соответствующие SVG‑элементы в инструменте пост‑обработки или в скрипте браузера.