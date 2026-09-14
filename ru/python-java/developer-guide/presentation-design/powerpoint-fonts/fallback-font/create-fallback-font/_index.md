---
title: Указание резервных шрифтов для презентаций в Python через Java
linktitle: Резервный шрифт
type: docs
weight: 10
url: /ru/python-java/create-fallback-font/
keywords:
- резервный шрифт
- правило резервного шрифта
- применить шрифт
- заменить шрифт
- диапазон Unicode
- пропущенный глиф
- правильный глиф
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Освойте Aspose.Slides для Python через Java, чтобы задавать резервные шрифты в файлах PPT, PPTX и ODP, обеспечивая согласованное отображение текста на любом устройстве или ОС."
---
## **Обзор**

Aspose.Slides позволяет указывать резервные шрифты для рендеринга презентаций и операций экспорта. Резервные шрифты используются, когда основной шрифт не содержит глифов для определённых символов.

Поведение резервных шрифтов настраивается с помощью правил резервного использования. Каждое правило связывает диапазон Юникода с одним или несколькими шрифтами, которые могут содержать требуемые глифы. Вы можете определять правила для разных диапазонов символов, добавлять или удалять резервные шрифты в существующих правилах и упорядочивать несколько правил в коллекции правил резервных шрифтов.

Правила резервного использования являются настройками рендеринга во время выполнения. Они не изменяют сам файл презентации и не сохраняются внутри файла PPTX.

## **Правила резервного использования**

Aspose.Slides предоставляет класс [FontFallBackRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/) для указания правил применения резервных шрифтов. Этот класс представляет связь между диапазоном Юникода, используемым для поиска отсутствующих глифов, и списком шрифтов, которые могут содержать требуемые глифы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Используйте несколько способов указать список шрифтов.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Вы также можете удалить резервный шрифт, используя [remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/#remove), или добавить резервные шрифты, используя [addFallBackFonts](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) в существующем объекте [FontFallBackRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrulescollection/) может упорядочивать список объектов [FontFallBackRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/), когда необходимо задать правила замены резервных шрифтов для нескольких диапазонов Юникода.

{{% alert color="info" title="See also" %}} 
- [Создать коллекцию резервных шрифтов](/slides/ru/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**В чём разница между резервным шрифтом, заменой шрифта и встраиванием шрифта?**

Резервный шрифт используется только для символов, отсутствующих в основном шрифте. [Font substitution](/slides/ru/python-java/font-substitution/) заменяет весь указанный шрифт другим шрифтом. [Font embedding](/slides/ru/python-java/embedded-font/) упаковывает шрифты внутри выходного файла, чтобы получатели могли видеть текст как задумано.

**Применяются ли резервные шрифты при экспорте, например PDF, PNG или SVG, или только при рендеринге на экране?**

Да. Резервные шрифты влияют на все [rendering and export operations](/slides/ru/python-java/convert-presentation/), где необходимо отрисовать символы, но они отсутствуют в исходном шрифте.

**Изменяет ли настройка резервных шрифтов сам файл презентации и сохраняется ли она при последующих открывах?**

Нет. Правила резервного использования являются настройками рендеринга во время выполнения в вашем коде; они не сохраняются внутри .pptx и не появятся в PowerPoint.

**Влияют ли операционная система (Windows/Linux/macOS) и набор каталогов шрифтов на выбор резервного шрифта?**

Да. Движок ищет шрифты в доступных системных папках и любых [additional paths](/slides/ru/python-java/custom-font/), которые вы указываете. Если шрифт физически недоступен, правило, ссылающееся на него, не может вступить в силу.

**Работают ли резервные шрифты для WordArt, SmartArt и диаграмм?**

Да. Когда эти объекты содержат текст, применяется тот же механизм замены глифов для отрисовки отсутствующих символов.