---
title: Получение и обновление информации о презентации в PHP
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
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для PHP, чтобы получить более быстрые инсайты и более интеллектуальные аудиты контента."
---
## **Обзор**

Aspose.Slides может определять формат презентации и считывать её метаданные без создания полной модели объектов презентации. Это полезно, когда необходимо классифицировать файлы, составлять инвентарь или проверять свойства до того, как решить, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируется лёгкая проверка с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/), а также целевые обновления с помощью [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/).

## **Проверка формата презентации**

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

Когда вам приходится обрабатывать множество файлов презентаций, может потребоваться компактный инвентарь для проверки, индексирования или системы управления документами. В этом случае используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) для получения объекта [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/), а затем вызовите [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения метаданных документа. Такой подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и не требует обхода полной модели объектов презентации.

Расширенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getSlides) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getNotes) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getParagraphs) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getWords) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Общее количество аудио- и видеоклипов. |

Следующий пример считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и выводит компактный инвентарь. Он также сочетает [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHeadingPairs) с [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getTitlesOfParts) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

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

Каждый [HeadingPair](https://reference.aspose.com/slides/ru/php-java/aspose.slides/headingpair/) предоставляет имя группы и количество элементов в этой группе. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getTitlesOfParts) возвращает плоский упорядоченный массив, поэтому следует потреблять количество последовательных заголовков, указанных каждой парой заголовков.

### **Сохранённые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объектов презентации для перерасчёта этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, последним сохранившее файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для подсчёта слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедийных клипов, а также пар заголовков и названий частей. Доступность зависит от того, какие свойства были записаны создателем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑сводки документа. Если свойство отсутствует или не было обновлено создателем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию вместо вычисления из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не映 соответствуют каждому расширенному свойству PowerPoint. Метаданные о скрытых слайдах, заметках, мультимедиа, парах заголовков и названиях частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties), также можно изменить без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Примените изменения с помощью [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), а затем запишите связанную презентацию с помощью [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Следующее изображение показывает исходные свойства документа PowerPoint презентации.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

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

Следующее изображение показывает обновлённые свойства документа PowerPoint презентации.

![Обновлённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты см. следующие статьи:

- [Защита паролем презентаций](/slides/ru/php-java/password-protected-presentation/)
- [Защита от записи презентаций](/slides/ru/php-java/write-protected-presentation/)

## **Часто задаваемые вопросы**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation::getFontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getFontsManager). Вызовите [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) для получения встроенных шрифтов и [FontsManager::getFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/#getFonts) для получения шрифтов, используемых в презентации. Сравнив два результата, вы найдёте шрифты, необходимые для рендеринга, но не встроенные.

**Как быстро определить, содержит ли файл скрытые слайды и их количество?**

Когда достаточно сохранённых метаданных документа, прочитайте [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#getHiddenSlides) через [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, сохранённые метаданные могут быть отсутствовать или устареть, либо вам нужно проверить текущие значения, пройдя по [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) и проверяя метод [Slide::getHidden](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slide/#getHidden) каждого слайда.

**Можно ли определить, используется ли пользовательский размер и ориентация слайда, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation::getSlideSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlideSize). Используйте [SlideSize::getType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getSize) и [SlideSize::getOrientation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesize/#getOrientation) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) и вызовите [ChartData::getDataSourceType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#getDataSourceType). Для внешней книги вызовите [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Тип источника данных и путь указывают на внешнюю ссылку, но проверка доступности целевого ресурса требует отдельной проверки.

**Как оценить «тяжелые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Нет единого свойства сложности. Обойдите [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) и коллекцию [BaseSlide::getShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslide/#getShapes) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы, и измерьте репрезентативный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.