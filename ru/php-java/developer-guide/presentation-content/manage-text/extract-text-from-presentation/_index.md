---
title: "Продвинутое извлечение текста из презентаций в PHP"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/php-java/extract-text-from-presentation/
keywords:
- извлекать текст
- извлекать текст со слайда
- извлекать текст из презентации
- извлекать текст из PowerPoint
- извлекать текст из OpenDocument
- извлекать текст из PPT
- извлекать текст из PPTX
- извлекать текст из ODP
- получать текст
- получать текст со слайда
- получать текст из презентации
- получать текст из PowerPoint
- получать текст из OpenDocument
- получать текст из PPT
- получать текст из PPTX
- получать текст из ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — обычная, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важным для анализа, автоматизации, индексирования или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for PHP via Java. Вы узнаете, как систематически обходить элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for PHP via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/). Этот класс предоставляет несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [getAllTextBoxes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/#getAllTextBoxes). Этот метод принимает объект типа [BaseSlide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/) в качестве параметра. При выполнении метод сканирует весь слайд в поисках текста и возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/#getAllTextFrames), предоставляемый классом [SlideUtil](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлечён текст.
2. Затем значение `boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

