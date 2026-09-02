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
description: "Настройте правила подстановки шрифтов и просмотрите заменённые шрифты в Aspose.Slides для Node.js через Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Подстановка влияет только на вывод рендеринга; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просматривать подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в разных средах с различными установленными шрифтами.

## **Получить подстановки шрифтов**

Используйте метод [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstitutioninfo/), содержащие имена оригинального и заменённого шрифтов.

Следующий пример JavaScript выводит все подстановки шрифтов для презентации:

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

## **Получить подстановки шрифтов для выбранных слайдов**

Используйте перегрузку [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) с массивом индексов слайдов, чтобы просмотреть только подстановки, необходимые для рендеринга конкретных слайдов. Это полезно при рендеринге или экспорте части презентации, поэтапной проверке большой презентации, поиске слайдов, зависящих от недоступных шрифтов, подготовке минимального пакета шрифтов для сервера или контейнера, а также при диагностике различий в рендеринге без обработки несвязанных слайдов.

Перегрузка ожидает примитивный массив Java `int[]`. Создайте его с помощью `java.newArray("int", [...])`; обычный массив JavaScript преобразуется в `Integer[]` и не соответствует этой перегрузке.

Массив содержит индексы слайдов, начинающиеся с 1: `1` идентифицирует первый слайд. В отличие от этого, коллекция [Presentation.getSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslides/) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок «на один» .

Вызовите перегрузку через [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getfontsmanager/). Она возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имена шрифтов. Результат отражает текущую среду шрифтов, настроенные правила fallback, правила подстановки, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/nodejs-java/custom-font/).

Одна и та же подстановка может потребоваться более чем одному выбранному слайду. Удалите дублирование результатов при создании инвентаря шрифтов или отчёта о предварительной проверке. Следующий пример выводит каждую полученную подстановку, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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

Класс [FontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от объёма операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) без аргументов | Нужно получить подстановки для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) с массивом `int[]` индексов слайдов | Нужно получить подстановки для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила подстановки шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Присвойте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Выполните рендеринг или конвертацию презентации.

Следующий пример JavaScript заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

{{% alert color="info" title="Примечание" %}}

Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/nodejs-java/font-replacement/).

{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифта, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** в этом случае, и рендеринг всё равно может потребовать **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/nodejs-java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила подстановки по‑прежнему применяются к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и подстановкой шрифтов?**

[Font replacement](/slides/ru/nodejs-java/font-replacement/) сознательно меняет один шрифт на другой по всей презентации. Подстановка шрифтов выбирает шрифт для вывода, когда выполнено заданное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [font selection sequence](/slides/ru/nodejs-java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/nodejs-java/custom-font/), чтобы Aspose.Slides мог их использовать при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в разных операционных системах, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/nodejs-java/custom-font/), и [embed fonts](/slides/ru/nodejs-java/embedded-font/), если лицензия позволяет. Вы также можете вызвать [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.