---
title: Настройка подстановки шрифтов в презентациях в .NET
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/net/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифта
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
description: "Настройте правила подстановки шрифтов и проверьте заменённые шрифты в Aspose.Slides для .NET при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому невозможно получить доступ при рендеринге или конвертации презентации. Замена влияет только на вывод; она не меняет шрифт, назначенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть замену, которую Aspose.Slides выполнит во время рендеринга. Это помогает сохранять единообразие вывода в средах с разным набором установленных шрифтов.

## **Получение замен шрифтов**

Используйте метод [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstitutioninfo/), содержащие исходные и заменённые имена шрифтов.

Ниже приведён пример на C#, выводящий все замены шрифтов для презентации:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Получение замен шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) с аргументом `int[] slides` для проверки только тех замен, которые нужны для рендеринга определённых слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, ищете слайды, зависящие от недоступных шрифтов, готовите минимальный набор шрифтов для сервера или контейнера, либо диагностируете различия рендеринга без обработки остальных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с 1: `1` — первый слайд. В то время как индексатор коллекции [Presentation.Slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) работает с нулевой базой, поэтому тот же слайд доступен как `presentation.Slides[0]`. Учтите это различие при построении массива, чтобы избежать ошибок «на один меньше».

Вызовите перегрузку через свойство [Presentation.FontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/fontsmanager/). Оно возвращает только те замены, которые были определены при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstitutioninfo/), содержащий исходные и заменённые имена шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, сохранённые в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/net/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дублирование результатов, когда создаёте инвентарь шрифтов или отчет о проверке. Ниже пример, который выводит каждую возвращённую замену, а затем формирует отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области применения операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) без аргументов | Нужно получить замену шрифтов для всей презентации. |
| [GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) с `int[] slides` | Нужно получить замену шрифтов для выбранного диапазона, поэтапной проверки или частного экспорта. |

## **Установка правил замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsubstrulecollection/).  
5. Назначьте коллекцию свойству [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Выполните рендеринг или конвертацию презентации.

Ниже пример на C#, который заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

{{% alert color="info" title="Примечание" %}}
Для безусловного изменения шрифтов, используемых по всей презентации, смотрите [Замена шрифтов](/slides/ru/net/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт указанным в правиле доступным шрифтом.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для расчёта и рендеринга макета уравнения. Правило, заменяющее его на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** в этой задаче, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/net/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены продолжают действовать для обычного текста презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их подстановкой?**

[Замена шрифтов](/slides/ru/net/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Подстановка шрифта выбирает шрифт для выводимого результата, когда выполнено условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [последовательности выбора шрифтов](/slides/ru/net/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не задано?**

Aspose.Slides выбирает ближайший доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/net/custom-font/), чтобы Aspose.Slides использовал их при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в разных ОС, поэтому шрифт, доступный на одной машине, может требовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/net/custom-font/) и [встраивайте шрифты](/slides/ru/net/embedded-font/), если лицензия позволяет. Также можно вызвать [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ru/net/aspose.slides/ifontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.