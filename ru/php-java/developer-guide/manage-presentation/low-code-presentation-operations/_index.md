---
title: Операции low-code с презентациями в PHP
linktitle: API low-code
type: docs
weight: 50
url: /ru/php-java/low-code-presentation-operations/
keywords:
- API low-code для презентаций
- конвертировать презентацию
- объединение презентаций
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удалить неиспользуемые мастер‑слайды
- удалить неиспользуемые макет‑слайды
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в PHP для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён [aspose.slides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/) предоставляет статические вспомогательные классы для распространённых операций с презентациями. Эти вспомогательные классы упаковывают часто используемые сценарии работы с объектной моделью в целевые методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим объёмом кода.

Вспомогательные средства low‑code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную объектную модель [Aspose.Slides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/), когда требуется тонкая настройка отдельных слайдов, мастеров, макетов, фигур, параметров экспорта или отношений между элементами презентации.

Ниже представлена таблица с доступными вспомогательными средствами:

| Помощник | Для чего используется |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/) | Конвертация презентации в другой формат с помощью прямого вызова файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/) | Выполнение обратного вызова для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) | Удаление неиспользуемых мастеров и макетов и уменьшение объёма встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert::autoByExtension](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/#autoByExtension), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути к выходному файлу и записывает результат.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/) также предоставляет специализированные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не доступен через выбранный вспомогательный класс. Смотрите [Конвертировать презентацию](/slides/ru/php-java/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger::process](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/#process) для комбинирования полных файлов презентаций одним вызовом. Входные презентации должны иметь один и тот же файловый формат.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Этот вспомогательный класс подходит, когда все слайды должны быть добавлены к одному результату без отдельного выбора или переназначения. Применяйте полную объектную модель, если нужно объединять выбранные слайды, применять мастер‑или макет‑назначения, явно сохранять разделы или согласовывать различный размер слайдов. См. [Объединить презентации](/slides/ru/php-java/merge-presentation/) для этих сценариев.

## **Перебор элементов презентации**

Класс [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Это избавляет от вложенных циклов по коллекциям и удобно для проверки или изменения формата по всей презентации.

В следующем примере используются [ForEach_::slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#paragraph) и [ForEach_::portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#portion) для инспекции соответствующих элементов:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

По умолчанию перебор фигур и текста по всей презентации охватывает обычные, мастер‑ и макет‑слайды. Перегрузки с параметром `includeNotes` позволяют также обрабатывать слайды с заметками. Используйте прямые циклы по коллекциям, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль родитель‑дочерних связей.

## **Сбор фигур**

Используйте [Collect::shapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/collect/#shapes), когда нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это полезно, если один и тот же набор будет отфильтрован, подсчитан или обработан более одного раза.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Применяйте [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжатие содержимого презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных шрифтов:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) удаляет макет‑слайды, которые не используют обычные слайды.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedMasterSlides) удаляет мастер‑слайды, которые больше не нужны.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#compressEmbeddedFonts) удаляет неиспользуемые символы из встроенных шрифтов.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые мастеры, чтобы мастер, ставший неиспользуемым после очистки макетов, также был удалён. Сохраняйте оптимизированную презентацию в новый файл, если позже могут понадобиться исходные мастеры, макеты или полный набор встроенных шрифтов. Подробности смотрите в статях [Slide Master](/slides/ru/php-java/slide-master/) и [Embedded Font](/slides/ru/php-java/embedded-font/).

## **Часто задаваемые вопросы**

**Когда следует использовать low‑code API вместо полной объектной модели?**

Применяйте вспомогательные средства low‑code, когда стандартная операция относится к полному файлу или презентации и не требует детального контроля над отдельными элементами. Используйте полную объектную модель, если нужно выбрать конкретные слайды, управлять отношениями мастеров и макетов, проверять промежуточное состояние или настраивать поведение, не доступное через вспомогательный класс.

**Может ли Merger объединять презентации разных файловых форматов?**

Нет. [Merger::process](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/#process) требует, чтобы входные презентации имели один и тот же формат. Сначала преобразуйте входные файлы в общий формат, например с помощью [Convert::autoByExtension](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/#autoByExtension), а затем объедините полученные файлы.

**Обрабатывает ли ForEach_ мастера, макеты и слайды заметок?**

[ForEach_::slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#slide) перебирает обычные слайды презентации. Операции [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#paragraph) и [ForEach_::portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#portion) по умолчанию включают обычные, мастер‑ и макет‑слайды. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach_::shape и Collect::shapes?**

Используйте [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape) для непосредственной обработки каждой фигуры через обратный вызов. Применяйте [Collect::shapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/collect/#shapes), когда нужен сохраняемый результат, который можно фильтровать, подсчитывать или обходить несколько раз.

**Делает ли Compress всегда презентацию меньше?**

Не обязательно. Результат зависит от того, содержит ли презентация неиспользуемые макеты, неиспользуемые мастеры или встроенные шрифты с неиспользуемыми символами. Если ни того, ни другого нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые через ForEach_ или Compress, автоматически?**

Нет. Эти вспомогательные средства работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_) или выполнения [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) вызовите [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/slides/ru/php-java/convert-presentation/)
- [Объединить презентации](/slides/ru/php-java/merge-presentation/)
- [Slide Master](/slides/ru/php-java/slide-master/)
- [Manage Text Box](/slides/ru/php-java/manage-textbox/)
- [Embedded Font](/slides/ru/php-java/embedded-font/)