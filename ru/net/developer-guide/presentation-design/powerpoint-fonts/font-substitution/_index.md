---
title: Конфигурирование подстановки шрифтов в презентациях в .NET
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите заменённые шрифты в Aspose.Slides для .NET при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Замена влияет только на вывод рендеринга; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда конкретный шрифт недоступен, и можете просматривать замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в разных средах с различными установленными шрифтами.

## **Получить замены шрифтов**

Используйте метод [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstitutioninfo/), которые указывают оригинальные и заменённые имена шрифтов.

Следующий пример на C# выводит все замены шрифтов для презентации:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Получить замены шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) с аргументом `int[] slides`, чтобы просматривать только заменяемые шрифты, необходимые для рендеринга определённых слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, находите слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с 1: `1` обозначает первый слайд. В то время как индексатор коллекции [Presentation.Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) является нулевым, поэтому тот же слайд доступен как `presentation.Slides[0]`. Учтите это различие при построении массива, чтобы избежать ошибок смещения.

Вызовите перегрузку через свойство [Presentation.FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/fontsmanager/). Оно возвращает только те замены, которые определены при рендеринге выбранных слайдов. Каждый результат представляет объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstitutioninfo/) с оригинальными и заменёнными именами шрифтов. Результат отражает текущую среду шрифтов и [externally loaded fonts](/slides/ru/net/custom-font/). Правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsubstrulecollection/), изменяют вывод рендеринга, но не отражаются в результате.

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дубликаты из результатов при создании инвентаризации шрифтов или отчёта предрейсов. Следующий пример выводит каждую возвращённую замену, а затем формирует отсортированный список уникальных сопоставлений шрифтов:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от объёма операции рендеринга:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Вам нужны замены для всей презентации. |
| [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Вам нужны замены для выбранного диапазона, поэтапной проверки или частного экспорта. |

## **Установить правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию свойству [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на C# заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/net/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифта, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга разметки уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/net/custom-font/).

Это ограничение относится к разметке уравнений. Описанные выше правила замены по‑прежнему применяются к обычному тексту презентации.

## **FAQ**

**В чем разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/net/font-replacement/) намеренно меняет один шрифт на другой по всей презентации. Замена шрифтов выбирает шрифт для вывода рендеринга, когда выполнено заданное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [font selection sequence](/slides/ru/net/font-selection-sequence/) во время рендеринга и конвертации. При `WhenInaccessible` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/net/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Распространяет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в разных операционных системах, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/net/custom-font/), и [embed fonts](/slides/ru/net/embedded-font/) при наличии соответствующей лицензии. Вы также можете вызвать [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные замены.