---
title: Получить и обновить информацию о презентации в PHP
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/php-java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- читать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализировать PPTX
- анализировать PPT
- анализировать ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP, получая более быстрые инсайты и более умные аудиты контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные без создания полной модели объектов презентации. Это полезно, когда необходимо классифицировать файлы, формировать инвентарь или проверять свойства перед тем, как решать, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируются лёгкие проверки с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/), а также целенаправленные обновления через [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/).

## **Проверка формата презентации**

Если у вас уже загружена презентация, см. [Determine the Original Presentation Format](/slides/ru/php-java/detect-presentation-source-format/) для определения формата после загрузки и ограничения потоков legacy PPT, PPS и POT.

Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) для инспекции файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Метод [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#getLoadFormat) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Создание лёгкого инвентаря презентаций**

При обработке большого количества файлов презентаций может потребоваться компактный инвентарь для валидации, индексации или системы управления документами. В этом случае используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) для получения объекта [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/), а затем вызовите [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/), дают следующие значения инвентаря:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getSlides) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getNotes) | Количество слайдов с заметками. |
| [getParagraphs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getParagraphs) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getWords) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Общее количество аудио‑ и видеоклипов. |

Следующий пример читает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и выводит компактный инвентарь. Он также сочетает [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHeadingPairs) с [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getTitlesOfParts) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Каждая [HeadingPair](https://reference.aspose.com/slides/ru/php-java/aspose.slides/headingpair/) поставляет имя группы и количество элементов в этой группе. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getTitlesOfParts) возвращает плоский упорядоченный массив, поэтому необходимо потреблять количество последовательных заголовков, указанное каждой парой заголовков.

### **Хранимые метаданные и ограничения форматов**

Свойства инвентаря, возвращаемые [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектов презентации для пересчёта этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, которое последним сохраняло файл, не обновило их.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчёта слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пары заголовков и названия частей. Доступность зависит от того, какие свойства были записаны создателем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑сводки документа. Если свойство отсутствует или не было обновлено создателем, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не вычисляет его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не соответствуют каждому расширенному свойству PowerPoint. Метаданные скрытых слайдов, слайдов‑заметок, мультимедиа, пар заголовков и названий частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего контента.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и инспектируйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties), также могут быть изменены без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Примените изменения с помощью [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), а затем запишите привязанную презентацию через [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

На следующем изображении показаны исходные свойства документа.

![Original document properties of the PowerPoint presentation](input_properties.png)

Следующий пример меняет название и время последнего сохранения и записывает результат в новый файл:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

На следующем изображении показаны обновлённые свойства документа.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/php-java/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation::getFontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getFontsManager). Вызовите [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) для получения встроенных шрифтов и [FontsManager::getFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFonts) для получения шрифтов, используемых в презентации. Сравните два результата, чтобы найти шрифты, необходимые для отображения, но не встроенные.

**Как быстро определить, есть ли скрытые слайды и их количество?**

Когда хранимые метаданные документа достаточны, прочитайте [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHiddenSlides) через [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, хранимые метаданные могут быть отсутствующими или устаревшими, либо требуется проверка живых значений — тогда пройдитесь по [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) и проверьте метод [Slide::getHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getHidden) каждого слайда.

**Могу ли я определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation::getSlideSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlideSize). Используйте [SlideSize::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getSize) и [SlideSize::getOrientation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getOrientation) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждый [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) и вызовите [ChartData::getDataSourceType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#getDataSourceType). Для внешней рабочей книги вызовите [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности ресурса требует отдельной проверки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Нет единого свойства сложности. Пройдитесь по [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) и коллекции [BaseSlide::getShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getShapes) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы для отсева, а также измерьте репрезентативный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.