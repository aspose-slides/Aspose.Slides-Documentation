---
title: "Отображать слайды презентаций как SVG‑изображения в PHP"
linktitle: "Слайд в SVG"
type: docs
weight: 50
url: /ru/php-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint в SVG"
- "презентация в SVG"
- "слайд в SVG"
- "PPT в SVG"
- "PPTX в SVG"
- "Параметры экспорта SVG"
- "интерактивный SVG"
- "PowerPoint"
- "презентация"
- "PHP"
- "Aspose.Slides"
description: "Экспортировать слайды PowerPoint в виде SVG‑изображений в PHP и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотров слайдов, процессов обеспечения доступности и автоматической пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/) когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#writeAsSvg). Ниже приведён пример, который экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла использует [Slide.getSlideNumber](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getSlideNumber) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#writeAsSvg), когда просмотрщику слайдов или веб‑странице нужен только этот объект.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setUseFrameSize) включает рамку текста в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setUseFrameRotation) определяет, применяется ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `true`, когда текст должен рендериться без лигатур.

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

## **Управление текстом и шрифтами**

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setVectorizeText) в `true`, чтобы записывать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным между браузерами, но текст уже нельзя будет выделять или искать как SVG‑текст.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы добавить ссылки на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензии шрифтов перед их внедрением.

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

## **Уменьшение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setPicturesCompression), чтобы уменьшить разрешение встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), чтобы исключить обрезанные области источника, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setJpegQuality), чтобы контролировать качество JPEG‑кодирования. Эти настройки уменьшают размер файла ценой качества изображения или сохранённых данных изображения.

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

## **Назначение стабильных идентификаторов формам и тексту**

Предоставьте обратный вызов форматирования в [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setShapeFormattingController), чтобы задать [SvgShape.setId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgshape/#setId) для каждой формы SVG. Обратный вызов может также задавать значения [SvgTSpan.setId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgtspan/#setId) для элементов текста `tspan`.

PhpJavaBridge не может вызвать PHP‑обратный вызов из `writeAsSvg`, когда он работает в режиме потока. Поместите логику форматирования в небольшом Java‑классе‑помощнике, скомпилируйте его и добавьте полученный JAR‑файл в classpath моста. Помощник может использовать [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getOfficeInteropShapeId), который остаётся стабильным в течение жизненного цикла формы, и повторяемый счётчик для её текстовых спанов. Смотрите [Java implementation of `StableSvgIdController`](/slides/ru/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) для кода помощника.

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

В обратном вызове форматирования вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgshape/#setEventHandler) с значением [SvgEvent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgevent/), чтобы добавить обработчик JavaScript к экспортируемой форме. Привяжите обратный вызов с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setShapeFormattingController) и определите функцию JavaScript на странице или в SVG‑документе, который размещает результат.

Как и в случае со стабильными идентификаторами, реализуйте обратный вызов в Java‑помощнике, когда PhpJavaBridge использует режим потока. [Java implementation of `SvgEventController`](/slides/ru/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) назначает ID и обработчик `OnClick` форме с именем `ActionButton`. Скомпилируйте этот помощник, добавьте его в classpath моста как `com.example.slides.SvgEventController` и используйте из PHP следующим образом:

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

Хост‑страница может определить функцию JavaScript, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет создавать просмотрщики слайдов, улучшать доступность и реализовывать другие интерактивные SVG‑процессы.

## **ЧаВо**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setVectorizeText) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgoptions/#setVectorizeText), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их предоставить. Проверьте результат, так как снижение разрешения изображений, уменьшение качества JPEG и векторизация текста влияют на качество и размер по‑разному.

**Можно ли изменять экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через обратный вызов форматирования, а затем выберите соответствующие элементы SVG в инструменте пост‑обработки или в скрипте браузера.