---
title: Настройка подстановки шрифтов в презентациях с использованием Python через Java
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/python-java/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифтов
- заменить шрифт
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите подставленные шрифты в Aspose.Slides для Python через Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, который невозможно получить при рендеринге или конвертации презентации. Подстановка влияет на выводимый результат; она не изменяет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, и можете просмотреть подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает сохранять согласованность вывода в разных средах с разным набором установленных шрифтов.

## **Получить подстановки шрифтов**

Используйте метод [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions), чтобы определить, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstitutioninfo/), идентифицирующие оригинальные и заменённые названия шрифтов.

Следующий пример на Python выводит все подстановки шрифтов для презентации:

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

## **Получить подстановки шрифтов для выбранных слайдов**

Используйте перегрузку [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions) с аргументом‑массивом целых чисел Java, чтобы просмотреть только подстановки, необходимые для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, инкрементно проверяете большую презентацию, ищете слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Массив `slides` содержит индексы слайдов, нумерация начинается с единицы: `1` обозначает первый слайд. В отличие от этого, accessor коллекции [Presentation.getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Помните об этом различии при построении массива, чтобы избежать ошибок смещения на‑один.

Вызов перегрузки происходит через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getFontsManager). Он возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое названия шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила подстановки, хранящиеся в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/python-java/custom-font/).

Одна и та же подстановка может потребоваться более чем одному выбранному слайду. Удалите дубликаты при создании инвентаризации шрифтов или отчёта о проверке. Следующий пример выводит каждую полученную подстановку, а затем формирует отсортированный список уникальных сопоставлений шрифтов:

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

Класс [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от охвата операции рендеринга:

| Overload | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions) без аргументов | Вам нужны подстановки для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions) с массивом целых чисел Java | Вам нужны подстановки для выбранного диапазона, инкрементной проверки или частичного экспорта. |

## **Установить правила подстановки шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsubstrulecollection/).  
5. Присвойте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на Python подставляет `Arial` вместо `SomeRareFont`, когда `SomeRareFont` недоступен, и затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/python-java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифтов, используемого во время рендеринга и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [external font](/slides/ru/python-java/custom-font/).

Это ограничение относится к построению макета уравнений. Описанные выше правила подстановки продолжают действовать для обычного текста презентации.

## **Часто задаваемые вопросы**

**В чём разница между заменой шрифтов и подстановкой шрифтов?**  
[Font replacement](/slides/ru/python-java/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Подстановка шрифтов выбирает шрифт для вывода, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**  
Правила участвуют в [font selection sequence](/slides/ru/python-java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не задано?**  
Aspose.Slides выбирает наиболее подходящий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**  
Да. Вы можете [load external fonts](/slides/ru/python-java/custom-font/), чтобы Aspose.Slides использовал их во время рендеринга и конвертации.

**Распространяет ли Aspose шрифты вместе с библиотекой?**  
Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**  
Да. Установленные шрифты и пути поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**  
Используйте одинаковые файлы шрифтов и их версии на всех машинах или в контейнерах, [load required external fonts](/slides/ru/python-java/custom-font/), и [embed fonts](/slides/ru/python-java/embedded-font/) при наличии соответствующей лицензии. Вы также можете вызвать [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#getSubstitutions) перед экспортом, чтобы выявить неожиданные подстановки.