---
title: Настройка подстановки шрифтов в презентациях с помощью Python
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/python-net/font-substitution/
keywords:
- шрифт
- заменить шрифт
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
description: "Настройте правила подстановки шрифтов и просмотрите подставленные шрифты в Aspose.Slides для Python через .NET при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Подстановка влияет только на отрисованный вывод; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в разных средах с различными установленными шрифтами.

## **Получение подстановок шрифтов**

Используйте метод [FontsManager.get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) для определения, какие шрифты будут подменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsubstitutioninfo/), содержащие оригинальные и подставленные названия шрифтов.

Ниже приведён пример на Python, который выводит все подстановки шрифтов для презентации:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Получение подстановок шрифтов для выбранных слайдов**

Используйте [FontsManager.get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) со списком индексов слайдов, чтобы просмотреть только те подстановки, которые требуются для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию пошагово, находите слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Список содержит индексы слайдов, начинающиеся с 1: `1` обозначает первый слайд. В отличие от этого, коллекция [Presentation.slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) использует нулевую основу, поэтому тот же слайд доступен как `presentation.slides[0]`. Учтите это различие при построении списка, чтобы избежать ошибок «на один».



Вызовите метод через свойство [Presentation.fonts_manager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/fonts_manager/). Он возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и подставленное имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила подстановки, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/python-net/custom-font/).

Одна и та же подстановка может потребоваться более чем одному выбранному слайду. Удалите дубликаты результатов при создании инвентаризации шрифтов или отчёта о проверке. Ниже пример, который выводит каждую найденную подстановку, а затем создаёт отсортированный список уникальных соответствий шрифтов:

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

Класс [FontsManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/) предоставляет обе формы метода. Выберите одну в зависимости от объёма операции рендеринга:

| Вызов метода | Когда использовать |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) без аргументов | Нужно получить подстановки для всей презентации. |
| [get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) со списком индексов слайдов | Нужно получить подстановки для выбранного диапазона, пошаговой проверки или частного экспорта. |

## **Установка правил подстановки шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и подставного шрифтов.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsubstrule/) с условием [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsubstrulecollection/).  
5. Назначьте коллекцию свойству [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Выполните рендеринг или конвертацию презентации.

Ниже пример на Python, который подменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Подставляемый шрифт должен быть доступен Aspose.Slides.

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
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/python-net/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических формул**

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифта, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным, указанным правилом.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, подменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступной Aspose.Slides. Установите её в операционной системе или загрузите как [внешний шрифт](/slides/ru/python-net/custom-font/).

Это ограничение относится только к макету уравнений. Описанные выше правила подстановки продолжают применяться к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифта и подстановкой шрифта?**

[Font replacement](/slides/ru/python-net/font-replacement/) целенаправленно меняет один шрифт на другой по всей презентации. Подстановка шрифта выбирает шрифт для отрисованного вывода, когда выполнено заданное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [font selection sequence](/slides/ru/python-net/font-selection-sequence/) во время рендеринга и конвертации. При условии `WHEN_INACCESSIBLE` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [load external fonts](/slides/ru/python-net/custom-font/), чтобы Aspose.Slides использовал их при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [load required external fonts](/slides/ru/python-net/custom-font/), и [embed fonts](/slides/ru/python-net/embedded-font/) при наличии соответствующей лицензии. Также можно вызвать [FontsManager.get_substitutions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsmanager/get_substitutions/) перед экспортом, чтобы выявить неожиданные подстановки.