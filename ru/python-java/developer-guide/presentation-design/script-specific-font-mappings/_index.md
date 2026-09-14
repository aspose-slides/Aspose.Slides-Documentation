---
title: Управление шрифтами темы, специфичными для сценариев, в Python через Java
linktitle: Шрифты темы, специфичные для сценариев
type: docs
weight: 15
url: /ru/python-java/script-specific-font-mappings/
keywords:
- шрифт, специфичный для сценария
- сопоставление шрифта темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- шрифт Таана
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Просматривайте, добавляйте, заменяйте и удаляйте сопоставления шрифтов, специфичных для сценариев, в темах PowerPoint с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для различных систем письма. Это позволяет многоязычному тексту, который по‑прежнему использует шрифты темы, следовать единой согласованной схеме шрифтов, одновременно используя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других письменностей.

В теме находится [FontScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontscheme/), который содержит крупную коллекцию шрифтов, обычно используемую для заголовков, и небольшую коллекцию шрифтов, обычно используемую для основного текста. Помимо их настроек латинских и восточно‑азиатских шрифтов, обе коллекции предоставляют сопоставления тегов системы письма с названиями семейств шрифтов через класс [Fonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/).

Эта статья показывает, как просматривать и изменять эти сопоставления в мастер‑теме презентации и проверять, что изменения сохраняются после сохранения и повторного открытия.

## **Понимание тегов письменностей**

Методы шрифтов сценариев используют четырёхбуквенные субтеги BCP 47 для идентификации систем письма. Распространённые значения включают:

| Тег сценария | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным фрагментам текста. Презентация может определять разные сопоставления для крупной и небольшой коллекций, а также может не задавать сопоставления для некоторых письменностей.

## **Доступ и просмотр сопоставлений шрифтов сценариев**

Используйте [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasterTheme), чтобы получить доступ к теме уровня презентации. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontscheme/#getMajor) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontscheme/#getMinor) возвращают две коллекции [Fonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/).

Вызовите [Fonts.getScriptFontMap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#getScriptFontMap), чтобы получить все сопоставления из коллекции. Чтобы найти одну систему письма, вызовите [Fonts.getScriptFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#getScriptFont) с её тегом сценария. `getScriptFont` возвращает `None`, когда в этой коллекции не определено запрошенное сопоставление.

## **Изменить сопоставления и проверить сохранность**

Используйте [Fonts.setScriptFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#setScriptFont), чтобы создать сопоставление или заменить текущий шрифт. Используйте [Fonts.removeScriptFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#removeScriptFont), чтобы удалить сопоставление.

Следующий сквозной пример считывает все существующие крупные и небольшие сопоставления, ищет крупный японский шрифт, изменяет крупный кириллический шрифт, удаляет небольшое сопоставление Thaana, сохраняет презентацию и открывает её снова, чтобы проверить оба изменения. Чтобы шаг удаления был независим от исходной темы, пример сначала создаёт сопоставление Thaana только если оно ещё не определено.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

Проверка использует то же поведение `None`, что и обычный поиск: после сохранения удаления `getScriptFont("Thaa")` возвращает `None` для небольшой коллекции.

## **Отличие сопоставлений темы от других настроек шрифтов**

Сопоставления шрифтов темы, специфичные для сценариев, участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, подстановка и резервирование:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Скрипт‑специфическое сопоставление шрифта темы | Выбирает крупный или небольшой шрифт темы для системы письма. | Текст, который всё ещё использует соответствующий шрифт темы, может перейти к новому сопоставленному семейству. |
| Шрифт, явно назначенный фрагменту текста | Фиксирует запрашиваемое семейство шрифтов для этого фрагмента вместо использования темы. | Фрагмент может остаться неизменным, поскольку его прямое форматирование переопределяет выбор темы. |
| Подстановка шрифта | Заменяет запрашиваемый шрифт, когда он недоступен, или когда применяется правило подстановки. | Действует после запроса шрифта; не переопределяет скрипт‑сопоставление темы. |
| Резервный шрифт | Предоставляет глифы, которых нет в выбранном шрифте, часто для определённых диапазонов Unicode. | Заполняет отсутствующие глифы; не меняет сохранённое сопоставление темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/python-java/font-substitution/) и [Fallback Fonts](/slides/ru/python-java/fallback-font/).

Изменение сопоставления в [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasterTheme) влияет только на контент, форматирование которого всё ещё зависит от этой темы. Текст может наследовать переопределение темы из мастер‑слайда, макета или слайда, либо использовать явно назначенный шрифт. Проверяйте эти уровни, если видимый результат не соответствует сопоставлению уровня презентации.

## **Сделать сопоставленные шрифты доступными и проверить результат**

Скрипт‑сопоставление хранит название семейства шрифтов; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в среде или предоставлен Aspose.Slides через пользовательский источник, например [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/#loadExternalFonts) или [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). См. [Custom Fonts](/slides/ru/python-java/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает лишь, что определение темы осталось неизменным. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или создаёт требуемую раскладку. Сформируйте представительный текст для каждой требуемой системы письма в изображение или PDF и проверьте результат. Это позволяет выявить отсутствующие шрифты, неполное покрытие глифов, поведение резервирования и изменения раскладки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/python-java/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `getScriptFont`, когда скрипт не сопоставлен?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#getScriptFont) возвращает `None`, когда запрошенное сопоставление скрипта не определено в этой крупной или небольшой коллекции шрифтов.

**Добавляет ли `setScriptFont` второе сопоставление, если скрипт уже существует?**

Нет. [Fonts.setScriptFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fonts/#setScriptFont) создаёт сопоставление, если оно отсутствует, и заменяет сопоставленное семейство шрифтов, когда тот же тег скрипта уже присутствует.

**Почему изменение сопоставления темы не изменило некоторый текст?**

Текст может иметь явно назначенный шрифт, наследовать другую тему через переопределение или быть затронут подстановкой или резервированием при рендеринге. Сопоставление скрипта уровня презентации управляет только тем текстом, чье эффективное форматирование всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть файл заново, чтобы проверить многоязычный вывод?**

Нет. Повторное открытие проверяет только сохранность данных темы. Кроме того, необходимо отрендерить представительный текст для каждой требуемой системы письма, чтобы убедиться, что сопоставленные шрифты доступны и содержат необходимые глифы.