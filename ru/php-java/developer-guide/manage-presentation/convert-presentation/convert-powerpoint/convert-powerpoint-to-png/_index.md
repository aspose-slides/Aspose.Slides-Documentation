---
title: Конвертировать слайды PowerPoint в PNG в PHP
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- PHP
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для PHP через Java, обеспечивая точные, автоматизированные результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентаций в изображения PNG с помощью Aspose.Slides для PHP через Java. Вы можете загружать презентации в формате PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное PNG‑изображение.

Приведённые ниже примеры демонстрируют рендеринг в масштабе по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиента.

## **Конвертировать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). В примере каждый слайд рендерится с помощью [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) без параметров для создания миниатюры. Затем вызывается [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) с [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png), чтобы сохранить каждый отрендеренный слайд в виде PNG‑изображения.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Перегрузка [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштаба или явно указанным размером изображения, показанным ниже.
{{% /alert %}}

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштаба в [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage), чтобы контролировать размеры рендеринга. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 Г— 540 пунктов создает изображение 1440 Г— 1080 пикселей. Равные коэффициенты сохраняют соотношение сторон слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Конвертировать PowerPoint в PNG с пользовательским размером**

Чтобы задать размеры вывода в пикселях, передайте размер в [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) вместо коэффициентов масштаба. Этот пример рендерит каждый слайд с размерами 960 Г— 720 пикселей и сохраняет результат с помощью [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Выбирайте размеры, соответствующие соотношению сторон слайда, чтобы избежать растягивания изображения.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Выберите стиль рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе отличаются от того, что вы видите в PowerPoint. Вы можете использовать метод [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle), унаследованный от [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и разместите его в рабочем каталоге приложения. Его первый слайд содержит два линейных градиента: от цианового к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две точки остановки — на 0 % и 100 %.

Следующий пример загружает эту презентацию и рендерит один и тот же первый слайд в обоих режимах с помощью [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Изображения ниже показывают вывод одного и того же слайда, с обоими градиентами на каждом изображении:

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от цианового к оранжевому и от синего к жёлтому, отрендеренные с Default](gradient-Default.png) | ![Те же градиенты, отрендеренные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` создаёт более светлые промежуточные цвета, тогда как `PowerPointUI` создаёт более тёмные промежуточные цвета. Разница зависит от цветов и точек остановки в градиенте.

Выберите `Default`, если стандартный вывод Aspose.Slides подходит для ваших задач. Попробуйте `PowerPointUI`, если ваш приоритет — соответствие внешнему виду в PowerPoint. Сравните оба вывода с желаемым результатом; ни один режим не является универсально предпочтительным.

## **Часто задаваемые вопросы**

**Как экспортировать отдельную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/php-java/create-shape-thumbnails/), позволяя рендерить форму в виде PNG‑изображения.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делитесь одним экземпляром между потоками](/slides/ru/php-java/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/php-java/licensing/), пока лицензия не будет применена.