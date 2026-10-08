---
title: Настройка подстановки шрифтов в презентациях с Python
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/python-net/font-substitution/
keywords:
- шрифт
- замена шрифта
- подстановка шрифтов
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите заменённые шрифты в Aspose.Slides для Python через .NET при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Замена влияет только на вывод рендеринга; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда конкретный шрифт недоступен, а также просматривать замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованный вывод в разных средах с различными установленными шрифтами.

Если шрифт доступен, но у него нет отдельного полужирного начертания, см. [Handle Fonts Without a Dedicated Bold Typeface](/slides/ru/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растеризовать затронутый текст при экспорте в PDF и какие последствия это имеет для выделения текста, поиска и масштабирования.

## **Получить замены шрифтов**

Используйте метод [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) чтобы определить, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/), идентифицирующие исходные и заменённые имена шрифтов.

Следующий пример на Python выводит все замены шрифтов для презентации:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Получить замены шрифтов для выбранных слайдов**

Используйте [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) со списком индексов слайдов, чтобы просмотреть только те замены, которые требуются для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, ищете слайды, зависящие от недоступных шрифтов, готовите минимальный набор шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Список содержит индексы слайдов, начинающиеся с 1: `1` обозначает первый слайд. Для сравнения, коллекция [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) нумеруется с 0, поэтому тот же слайд доступен как `presentation.slides[0]`. Имейте в виду это различие при построении списка, чтобы избежать ошибок off‑by‑one.

Вызовите метод через свойство [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Он возвращает только те замены, которые определены во время рендеринга выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/), содержащий исходные и заменённые имена шрифтов. Результат отражает текущую среду шрифтов, настроенные правила fallback, правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/python-net/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дубликаты результатов, когда создаёте инвентарь шрифтов или отчёт о проверке. Следующий пример выводит каждую полученную замену, а затем формирует отсортированный список уникальных сопоставлений шрифтов:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Класс [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) предоставляет обе формы метода. Выберите одну в зависимости от объёма операции рендеринга:

| Вызов метода | Когда использовать |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) без аргументов | Вам нужны замены для всей презентации. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) со списком индексов слайдов | Вам нужны замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) с условием [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию свойству [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на Python заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Замена шрифтов](/slides/ru/python-net/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифта, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/python-net/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены по‑прежнему применяются к обычному тексту презентации.

## **Вопросы и ответы**

**В чем разница между заменой шрифтов и их подстановкой?**  
[Замена шрифтов](/slides/ru/python-net/font-replacement/) сознательно меняет один шрифт на другой во всей презентации. Подстановка шрифтов выбирает шрифт для отображаемого вывода, когда выполнено сконфигурированное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**  
Правила участвуют в [последовательность выбора шрифта](/slides/ru/python-net/font-selection-sequence/) во время рендеринга и конвертации. При условии `WHEN_INACCESSIBLE` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, когда шрифт отсутствует и правило подстановки не настроено?**  
Aspose.Slides выбирает наиболее подходящий доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**  
Да. Вы можете [загружать внешние шрифты](/slides/ru/python-net/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**  
Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**  
Да. Установленные шрифты и места поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**  
Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/python-net/custom-font/), и [встраивайте шрифты](/slides/ru/python-net/embedded-font/), когда позволяют лицензии. Вы также можете вызвать [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) перед экспортом, чтобы выявить неожиданные подстановки.