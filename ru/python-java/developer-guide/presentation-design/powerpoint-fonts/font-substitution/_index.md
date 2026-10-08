---
title: Настройка подстановки шрифтов в презентациях с использованием Python через Java
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/python-java/font-substitution/
keywords:
- шрифт
- заменить шрифт
- подстановка шрифта
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите заменённые шрифты в Aspose.Slides для Python через Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому невозможно получить доступ при рендеринге или конвертации презентации. Замена влияет только на вывод рендеринга; она не меняет шрифт, присвоенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, и можете просматривать замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать единообразный вывод в разных средах с различными установленными шрифтами.

Если шрифт доступен, но не имеет отдельного полужирного начертания, смотрите [Обрабатывать шрифты без отдельного полужирного начертания](/slides/ru/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Этот раздел объясняет, как растрировать затронутый текст при экспорте в PDF и последствия для выбора текста, поиска и масштабирования.

## **Получить замены шрифтов**

Воспользуйтесь методом [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions), чтобы определить, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/), содержащие имена исходного и заменённого шрифтов.

Следующий пример на Python выводит все замены шрифтов для презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Получить замены шрифтов для выбранных слайдов**

Воспользуйтесь перегрузкой метода [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) с аргументом — массивом целых чисел Java, чтобы просматривать только замены, необходимые для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проводите поэтапную проверку большой презентации, находите слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` указывает первый слайд. В отличие от этого, accessor коллекции [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при формировании массива, чтобы избежать ошибок смещения на один.

Вызовите перегрузку через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Он возвращает только те замены, которые определились во время рендеринга выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/), содержащий исходное и заменённое названия шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила подстановки, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), и [externally loaded fonts](/slides/ru/python-java/custom-font/).

Одну и ту же подстановку может потребовать более чем один выбранный слайд. Удалите дублирующиеся результаты при создании инвентаризации шрифтов или отчёта о подготовке. Следующий пример выводит каждую полученную подстановку, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Класс [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от объёма операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) без аргументов | Вам нужны замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) с массивом целых чисел Java | Вам нужны замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифта.
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на Python заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, смотрите [Font Replacement](/slides/ru/python-java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого во время рендеринга и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, которое заменяет другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/python-java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила подстановки продолжают применяться к обычному тексту презентации.

## **Часто задаваемые вопросы**

**В чем разница между заменой шрифтов и подстановкой шрифтов?**

[Font replacement](/slides/ru/python-java/font-replacement/) преднамеренно меняет один шрифт на другой во всей презентации. Подстановка шрифта выбирает шрифт для вывода рендеринга, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [font selection sequence](/slides/ru/python-java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/python-java/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может требовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/python-java/custom-font/), и [embed fonts](/slides/ru/python-java/embedded-font/) при возможности лицензирования. Вы также можете вызвать [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) перед экспортом, чтобы выявить неожиданные подстановки.