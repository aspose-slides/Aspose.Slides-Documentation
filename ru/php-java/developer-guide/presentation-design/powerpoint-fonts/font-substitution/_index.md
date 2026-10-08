---
title: Настройка замены шрифтов в презентациях с использованием PHP
linktitle: Замена шрифтов
type: docs
weight: 70
url: /ru/php-java/font-substitution/
keywords:
- шрифт
- заменяемый шрифт
- замена шрифтов
- замена шрифта
- замена шрифтов
- правило замены
- правило замены
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Настройте правила замены шрифтов и просмотрите заменённые шрифты в Aspose.Slides для PHP через Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Замена влияет только на отрисованный вывод; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает сохранять единообразие вывода в разных средах с различными установленными шрифтами.

Если шрифт доступен, но не имеет отдельного полужирного начертания, см. [Обработать шрифты без отдельного полужирного начертания](/slides/ru/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растеризовать затронутый текст при экспорте в PDF и какие последствия это имеет для выделения текста, поиска и масштабирования.

## **Получить замену шрифтов**

Используйте метод [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) чтобы определить, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/), которые указывают оригинальные и заменённые имена шрифтов.

Следующий пример PHP перечисляет все замены шрифтов для презентации:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Получить замену шрифтов для выбранных слайдов**

Используйте перегрузку метода [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) с аргументом `int[] slides`, чтобы проверять только те замены, которые необходимы для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, постепенно проверяете большую презентацию, находите слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

`slides` массив содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. Для сравнения, accessor коллекции [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) использует нулевую базу индексов, поэтому тот же слайд доступен как `$presentation->getSlides()->get_Item(0)`. Учтите эту разницу при формировании массива, чтобы избежать ошибок смещения на один.

Вызовите перегрузку через метод [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Он возвращает только те замены, которые определены при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/php-java/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удаляйте дублирование результатов при создании инвентаризации шрифтов или отчёта предрейса. Следующий пример выводит каждую возвращённую замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Класс [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Вам нужны замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Вам нужны замены для выбранного диапазона, постепенной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример PHP заменяет `SomeRareFont` на `Arial`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/php-java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для расчёта и рендеринга макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что нужен **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/php-java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены по-прежнему применимы к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и заменой (substitution) шрифтов?**

[Font replacement](/slides/ru/php-java/font-replacement/) сознательно меняет один шрифт на другой во всей презентации. Замена шрифтов выбирает шрифт для отрисованного вывода, когда выполнено настроенное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила замены шрифтов?**

Правила участвуют в [font selection sequence](/slides/ru/php-java/font-selection-sequence/) во время рендеринга и конвертации. При `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, когда шрифт отсутствует и правило замены не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать замены?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/php-java/custom-font/) чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты замены различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может требовать замены на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загрузить необходимые внешние шрифты](/slides/ru/php-java/custom-font/), и [встроить шрифты](/slides/ru/php-java/embedded-font/) когда лицензия позволяет. Вы также можете вызвать [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные замены.