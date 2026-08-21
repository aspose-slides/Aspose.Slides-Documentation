---
title: Операции с презентациями Low-Code в PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /ru/php-java/low-code-presentation-operations/
keywords:
- low-code API презентаций
- конвертировать презентацию
- объединять презентации
- итерировать слайды
- итерировать фигуры
- итерировать текст
- сбор фигур
- сжать презентацию
- удалить неиспользуемые шаблонные слайды
- удалить неиспользуемые макетные слайды
- сжать встроенные шрифты
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в PHP для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён [aspose.slides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/) предоставляет статические вспомогательные классы для общих операций с презентациями. Эти вспомогательные классы оборачивают часто используемые потоки объектной модели в целевые методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные средства low-code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полную [Aspose.Slides object model](https://reference.aspose.com/slides/ru/php-java/aspose.slides/), когда нужен детальный контроль над отдельными слайдами, шаблонами, макетами, фигурами, настройками экспорта или связями между элементами презентации.

Следующая таблица суммирует доступные вспомогательные средства:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/) | Конвертирование презентации в другой формат с прямым вызовом файл‑в‑файл. |
| [Merger](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/) | Объединение полных файлов презентаций одного формата. |
| [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/) | Выполнение обратного вызова для каждого слайда, фигуры, абзаца или фрагмента текста. |
| [Collect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) | Удаление неиспользуемых шаблонов и макетов и уменьшение данных встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert::autoByExtension](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/#autoByExtension), когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути к выходному файлу и записывает результат.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/) также предоставляет специальные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, который не предоставлен выбранным вспомогательным модулем. См. [Convert Presentation](/php-java/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте [Merger::process](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/#process) для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь один и тот же формат файла.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Вспомогательный модуль подходит, когда все слайды должны быть добавлены к одному результату без отдельного выбора или переопределения. Используйте полную объектную модель, когда нужно объединить выбранные слайды, применить целевой шаблон или макет, явно сохранить разделы или согласовать разные размеры слайдов. См. [Merge Presentations](/php-java/merge-presentation/) для этих сценариев.

## **Итерировать элементы презентации**

Класс [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/) вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов по коллекциям и удобен для проверки или изменения формата по всей презентации.

В следующем примере используются [ForEach_::slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#paragraph) и [ForEach_::portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#portion) для проверки соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, шаблонные и макетные слайды. Перегрузки с параметром `includeNotes` также могут обрабатывать слайды заметок. Используйте прямые циклы по коллекциям, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальный контроль иерархии родитель‑потомок.

## **Собрать фигуры**

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

Используйте [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) может удалять неиспользуемые структурные элементы и уменьшать данные встроенных шрифтов:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) удаляет макетные слайды, на которые не ссылается ни один обычный слайд.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/#removeUnusedMasterSlides) удаляет шаблонные слайды, которые больше не используются.
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

Сначала удаляйте неиспользуемые макеты, а затем неиспользуемые шаблоны, чтобы шаблон, который стал неиспользуемым после очистки макетов, также мог быть удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут понадобиться оригинальные шаблоны, макеты или полные данные встроенных шрифтов. Для более подробной информации см. [Slide Master](/php-java/slide-master/) и [Embedded Font](/php-java/embedded-font/).

## **Часто задаваемые вопросы**

**Когда следует использовать low-code API вместо полной объектной модели?**

Используйте low-code вспомогательные модули, когда стандартная операция применяется к полному файлу или презентации и не требует детального управления отдельными элементами. Используйте полную объектную модель, когда нужно выбрать конкретные слайды, контролировать взаимосвязи шаблонов и макетов, просмотреть промежуточное состояние или настроить поведение, которое не предоставляется вспомогательным модулем.

**Может ли Merger объединять презентации в разных файловых форматах?**

Нет. [Merger::process](https://reference.aspose.com/slides/ru/php-java/aspose.slides/merger/#process) требует, чтобы входные презентации были в одинаковом формате. Сначала конвертируйте входные файлы в общий формат, например с помощью [Convert::autoByExtension](https://reference.aspose.com/slides/ru/php-java/aspose.slides/convert/#autoByExtension), а затем объедините конвертированные файлы.

**Обрабатывает ли ForEach_ шаблонные, макетные и слайды заметок?**

[ForEach_::slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#slide) перебирает обычные слайды презентации. Операции [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#paragraph) и [ForEach_::portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#portion) по всей презентации включают обычные, шаблонные и макетные слайды по умолчанию. Используйте их перегрузки с параметром `includeNotes`, установленным в `true`, чтобы включить слайды заметок.

**В чём разница между ForEach_::shape и Collect::shapes?**

Используйте [ForEach_::shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_/#shape), чтобы обрабатывать каждую фигуру немедленно через обратный вызов. Используйте [Collect::shapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/collect/#shapes), когда нужен итерируемый результат, который можно сохранить, отфильтровать, подсчитать или просматривать несколько раз.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Результат зависит от того, содержит ли презентация неиспользуемые макеты, неиспользуемые шаблоны или встроенные шрифты с неиспользуемыми символами. Если их нет, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, выполненные через ForEach_ или Compress, автоматически?**

Нет. Эти вспомогательные модули работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach_](https://reference.aspose.com/slides/ru/php-java/aspose.slides/foreach_) или выполнения [Compress](https://reference.aspose.com/slides/ru/php-java/aspose.slides/compress/), вызовите [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save), чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/php-java/convert-presentation/)
- [Объединить презентации](/php-java/merge-presentation/)
- [Шаблон слайда](/php-java/slide-master/)
- [Управление текстовым полем](/php-java/manage-textbox/)
- [Встроенный шрифт](/php-java/embedded-font/)