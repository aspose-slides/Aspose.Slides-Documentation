---
title: Настройка подстановки шрифтов в презентациях в .NET
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/net/font-substitution/
keywords:
- шрифт
- заменяемый шрифт
- подстановка шрифтов
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: Настройте правила подстановки шрифтов и просмотрите подставленные шрифты в Aspose.Slides для .NET при рендеринге или конвертации презентаций PowerPoint и OpenDocument.
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Подстановка влияет только на результирующее изображение; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, и вы можете просмотреть подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать единообразный вывод в разных средах с различными установленными шрифтами.

Если шрифт доступен, но у него нет отдельного жирного начертания, см. [Handle Fonts Without a Dedicated Bold Typeface](/slides/ru/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растрировать затронутый текст при экспорте в PDF и какие последствия это имеет для выделения текста, поиска и масштабирования.

## **Получить подстановки шрифтов**

Используйте метод [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/), в которых указаны оригинальные и подставленные имена шрифтов.

Следующий пример на C# выводит все подстановки шрифтов для презентации:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Получить подстановки шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) с аргументом `int[] slides`, чтобы просмотреть только те подстановки, которые требуются для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, ищете слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. Для сравнения, индексатор коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) является нулевым, поэтому тот же слайд доступен как `presentation.Slides[0]`. Учтите это различие при формировании массива, чтобы избежать ошибок «на один индекс».

Вызовите перегрузку через свойство [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Оно возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат представляет объект [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и подставленное имена шрифтов. Результат отражает текущую среду шрифтов и [внешне загруженные шрифты](/slides/ru/net/custom-font/). Правила подстановки, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/), изменяют вывод, но не отражаются в результате.

Одна и та же подстановка может требоваться более чем одним выбранным слайдом. Удалите дублирование результатов, когда формируете инвентарь шрифтов или отчёт о предварительной проверке. Следующий пример выводит каждую полученную подстановку, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области рендеринговой операции:

| Перегрузка | Когда использовать |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) без аргументов | Вам нужны подстановки для всей презентации. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) с `int[] slides` | Вам нужны подстановки для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила подстановки шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).  
5. Присвойте коллекцию свойству [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на C# подставляет **Arial** вместо **SomeRareFont**, когда **SomeRareFont** недоступен, и затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифта, используемого во время рендеринга и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребоваться именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, подставляющее другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/net/custom-font/).

Это ограничение относится к раскладке уравнений. Правила подстановки, описанные выше, по‑прежнему применяются к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и подстановкой шрифтов?**

[Font replacement](/slides/ru/net/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Подстановка шрифтов выбирает шрифт для отрисованного вывода, когда выполнено заданное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [font selection sequence](/slides/ru/net/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, когда шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/net/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может требовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/net/custom-font/), и [embed fonts](/slides/ru/net/embedded-font/) при наличии соответствующей лицензии. Вы также можете вызвать [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.