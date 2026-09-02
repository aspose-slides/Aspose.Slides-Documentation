---
title: Настройка подстановки шрифтов в презентациях с использованием PHP
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/php-java/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифтов
- замена шрифта
- замена шрифтов
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите подставленные шрифты в Aspose.Slides для PHP через Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Замена влияет только на выводимый результат; она не изменяет шрифт, назначенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать консистентность вывода в разных средах с различными установленными шрифтами.

## **Получить замены шрифтов**

Используйте метод [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstitutioninfo/), которые указывают оригинальные и заменённые названия шрифтов.

Следующий пример на PHP выводит все замены шрифтов для презентации:

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

## **Получить замены шрифтов для выбранных слайдов**

Используйте перегруженный вариант [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getsubstitutions/) с аргументом `int[] slides`, чтобы просматривать только те замены, которые нужны для рендеринга конкретных слайдов. Это удобно, когда вы рендерите или экспортируете часть презентации, инкрементно проверяете большую презентацию, находите слайды, зависящие от недоступных шрифтов, готовите минимальный набор шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. В отличие от этого, accessor коллекции [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getSlides) использует нулевую индексацию, поэтому тот же слайд доступен как `$presentation->getSlides()->get_Item(0)`. Учитывайте это различие при построении массива, чтобы избежать ошибок смещения.

Вызовите перегрузку через метод [Presentation::getFontsManager](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getFontsManager). Он возвращает только те замены, которые определены при рендеринге выбранных слайдов. Каждый результат представляет собой объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstitutioninfo/), содержащий оригинальные и заменённые названия шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/php-java/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дубликаты результатов при создании инвентаризации шрифтов или отчёта о проверке. Следующий пример выводит каждую возвращённую замену, а затем создает отсортированный список уникальных сопоставлений шрифтов:

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

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getsubstitutions/) без аргументов | Вам нужны подстановки для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getsubstitutions/) с `int[] slides` | Вам нужны подстановки для выбранного диапазона, инкрементной проверки или частичного экспорта. |

## **Установить правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на PHP заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для расчёта и рендеринга разметки уравнения. Правило, заменяющее его на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/php-java/custom-font/).

Это ограничение относится к разметке уравнений. Описанные выше правила замены по‑прежнему применяются к обычному тексту презентации.

## **Вопросы и ответы**

**В чём разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/php-java/font-replacement/) намеренно меняет один шрифт на другой по всей презентации. Подстановка шрифтов выбирает шрифт для выводимого результата, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [последовательности выбора шрифтов](/slides/ru/php-java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/php-java/custom-font/), чтобы Aspose.Slides мог использовать их при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить консистентный выбор шрифтов при пакетных конверсиях?**

Используйте одинаковые файловые наборы и версии шрифтов на каждой машине или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/php-java/custom-font/) и [встраивайте шрифты](/slides/ru/php-java/embedded-font/) при наличии лицензии. Вы также можете вызвать [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.