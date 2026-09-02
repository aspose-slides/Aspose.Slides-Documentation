---
title: Управление шрифтами темы, специфичными для скриптов, в Python
linktitle: Шрифты темы, специфичные для скриптов
type: docs
weight: 15
url: /ru/python-net/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скрипта
- отображение шрифтов темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- шрифт таана
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Просматривайте, добавляйте, заменяйте и удаляйте отображения шрифтов, специфичных для скриптов, в темах PowerPoint с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Тема презентации может выбирать разные семейства шрифтов для различных систем письма. Это позволяет использовать многоязычный текст, который всё равно применяет шрифты темы, следуя единой схеме шрифтов, при этом используя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других письменностей.

Тема содержит объект [FontScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/), в котором есть основная коллекция шрифтов, обычно используемая для заголовков, и вспомогательная коллекция, обычно используемая для основного текста. Помимо их латинских и восточноазиатских свойств шрифтов, обе коллекции предоставляют отображения из тегов систем письма в имена семейств шрифтов через класс [Fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/).

В этой статье показано, как просматривать и изменять эти отображения в главной теме презентации и проверить, что изменения сохраняются после сохранения и повторной загрузки.

## **Понимание тегов скриптов**

Методы работы со шрифтами скриптов используют четырёхбуквенные субтеги BCP 47 для идентификации систем письма. Распространённые значения включают:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллица |
| `Arab` | Арабский |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японский |
| `Geor` | Грузинский |
| `Thaa` | Таана |

Эти отображения принадлежат схеме шрифтов темы, а не отдельным участкам текста. Презентация может определять разные отображения для основных и вспомогательных коллекций, а также может не определять отображения для некоторых скриптов.

## **Доступ и просмотр отображений шрифтов скриптов**

Используйте [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/) для доступа к теме уровня презентации. Свойства [FontScheme.major](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/major/) и [FontScheme.minor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/minor/) возвращают две коллекции [Fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/).

Вызовите [Fonts.get_script_font_map](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/get_script_font_map/) чтобы получить все отображения из коллекции. Чтобы найти шрифт для конкретной системы письма, вызовите [Fonts.get_script_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/get_script_font/) с её тегом. `get_script_font` возвращает `None`, если в этой коллекции не определено запрошенное отображение.

## **Изменение отображений и проверка их сохранения**

Используйте [Fonts.set_script_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/set_script_font/) чтобы создать новое отображение или заменить текущее семейство шрифта. Используйте [Fonts.remove_script_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/remove_script_font/) чтобы удалить отображение.

Ниже приведён сквозной пример, который читает все существующие основные и вспомогательные отображения, ищет основной японский шрифт, меняет основной кириллический шрифт, удаляет вспомогательное отображение таана, сохраняет презентацию и открывает её заново для проверки обоих изменений. Чтобы шаг удаления был независим от исходной темы, пример сначала создаёт отображение таана только если оно ещё не определено.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Проверка использует то же поведение `None`, что и обычный поиск: после сохранения удаления вызов `get_script_font("Thaa")` возвращает `None` для вспомогательной коллекции.

## **Различие отображений темы от других настроек шрифтов**

Отображения шрифтов, специфичных для скриптов, участвуют в выборе шрифта, но решают другую задачу, чем прямое форматирование текста, подстановка и резервные шрифты:

| Механизм | Цель | Эффект изменения отображения темы |
|---|---|---|
| Отображение шрифта темы, специфичное для скрипта | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, продолжающий использовать соответствующий шрифт темы, может перейти к новому семейству. |
| Шрифт, назначенный явно части текста | Фиксирует запрашиваемое семейство шрифта для этой части, не полагаясь на тему. | Часть текста может остаться без изменений, потому что её прямое форматирование переопределяет выбор темы. |
| Подстановка шрифтов | Заменяет запрошенный шрифт, когда он недоступен или применяется правило подстановки. | Действует после запроса шрифта; не переопределяет скриптовое отображение темы. |
| Резервный шрифт | Предоставляет глифы, которых нет в выбранном шрифте, зачастую для конкретных диапазонов Unicode. | Заполняет отсутствующее покрытие глифов; не меняет сохранённое отображение темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/python-net/font-substitution/) и [Fallback Fonts](/slides/ru/python-net/fallback-font/).

Изменение отображения в [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/) влияет только на контент, чьё эффективное форматирование всё ещё зависит от этой темы. Текст может вместо этого наследовать переопределение темы от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверьте эти уровни, когда видимый результат не соответствует отображению уровня презентации.

## **Сделайте отображённые шрифты доступными и проверьте результат**

Отображение скрипта сохраняет только имя семейства шрифта; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного отображения и экспорта каждый отображённый шрифт должен быть установлен в среде или предоставлен Aspose.Slides через пользовательский источник, такой как [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fontsloader/load_external_fonts/) или [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/document_level_font_sources/). Смотрите раздел [Custom Fonts](/slides/ru/python-net/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого отображения подтверждает лишь то, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все требуемые глифы или создает ожидаемую разметку. Отрендерите репрезентативный текст для каждой требуемой системы письма в изображение или PDF и проанализируйте результат. Это позволит выявить отсутствующие шрифты, неполное покрытие глифов, поведение резервных шрифтов и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/python-net/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `get_script_font`, когда скрипт не отображён?**

[Fonts.get_script_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/get_script_font/) возвращает `None`, когда запрошенное отображение скрипта не определено в основной или вспомогательной коллекции шрифтов.

**Добавляет ли `set_script_font` второе отображение, если скрипт уже существует?**

Нет. [Fonts.set_script_font](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fonts/set_script_font/) создаёт отображение, если его нет, и заменяет семейство шрифта, когда тег скрипта уже присутствует.

**Почему изменение отображения темы не изменило некоторый текст?**

Текст мог иметь явно назначенный шрифт, наследовать другую тему через переопределение или быть затронут подстановкой или резервным шрифтом во время рендеринга. Скриптовое отображение уровня презентации управляет только тем текстом, чьё эффективное форматирование всё ещё ссылается на эту тему.

**Достаточно ли сохранить и открыть заново для проверки многоязычного вывода?**

Нет. Открытие заново проверяет только сохранность данных темы. Также необходимо отрендерить репрезентативный текст для каждой требуемой системы письма, чтобы убедиться, что отображённые шрифты доступны и содержат необходимые глифы.