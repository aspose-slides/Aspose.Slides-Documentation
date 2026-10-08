---
title: "Настройка подстановки шрифтов в презентациях с использованием JavaScript"
linktitle: "Подстановка шрифтов"
type: docs
weight: 70
url: /ru/nodejs-java/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифтов
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и проверьте заменённые шрифты в Aspose.Slides для Node.js через Java при визуализации или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при визуализации или конвертации презентации. Замена влияет только на полученный результат визуализации; она не изменяет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть замены, которые Aspose.Slides выполнит во время визуализации. Это помогает сохранять согласованность вывода в разных средах с различными установленными шрифтами.

Если шрифт доступен, но у него нет отдельного полужирного начертания, см. [Обработка шрифтов без отдельного полужирного начертания](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растеризовать затронутый текст при экспорте в PDF и какие последствия это имеет для выбора текста, поиска и масштабирования.

## **Получить замены шрифтов**

Используйте метод [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при визуализации презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/), содержащие исходные и заменённые названия шрифтов.

Следующий пример на JavaScript выводит все замены шрифтов для презентации:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Получить замены шрифтов для выбранных слайдов**

Используйте перегрузку метода [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) с массивом индексов слайдов, чтобы просматривать только те замены, которые необходимы для визуализации конкретных слайдов. Это полезно, когда вы визуализируете или экспортируете часть презентации, постепенно проверяете большую презентацию, ищете слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в визуализации без обработки нерелевантных слайдов.

Перегрузка ожидает примитив Java `int[]`. Создайте его с помощью `java.newArray("int", [...])`; обычный массив JavaScript преобразуется в `Integer[]` и не соответствует этой перегрузке.

Массив содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. В отличие от этого, доступ к коллекции [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок сдвига на один.

Вызовите перегрузку через [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Она возвращает только те замены, которые были определены при визуализации выбранных слайдов. Каждый результат представляет объект [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое названия шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/nodejs-java/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удаляйте дубликаты результатов при создании инвентаризации шрифтов или отчёта предполётной проверки. Следующий пример выводит каждую полученную замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Класс [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области операции визуализации:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Вам нужны замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Вам нужны замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Визуализируйте или конвертируйте презентацию.

Следующий пример на JavaScript заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем визуализирует первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/nodejs-java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифта, используемого при визуализации и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным правилом.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для расчёта и визуализации макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и при визуализации всё равно может появиться сообщение о необходимости **Cambria Math**.

Чтобы визуализировать или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/nodejs-java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены продолжают применяться к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/nodejs-java/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Замена шрифтов выбирает шрифт для визуализированного вывода, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила замены?**

Правила участвуют в [font selection sequence](/slides/ru/nodejs-java/font-selection-sequence/) во время визуализации и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, когда шрифт отсутствует и правило замены не настроено?**

Aspose.Slides выбирает наиболее близкий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/nodejs-java/custom-font/), чтобы Aspose.Slides мог использовать их во время визуализации и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки отличаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файловые наборы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/nodejs-java/custom-font/) и [embed fonts](/slides/ru/nodejs-java/embedded-font/) при наличии лицензии. Вы также можете вызвать [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.