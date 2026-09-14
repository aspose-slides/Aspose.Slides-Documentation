---
title: Настройка коллекций резервных шрифтов в Python через Java
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/python-java/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для Python через Java, чтобы текст оставался согласованным и чётким в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

Aspose.Slides позволяет настроить коллекцию правил резервных шрифтов для презентации. Каждое правило резервного шрифта представлено классом [FontFallBackRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/) и может быть добавлено в [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrulescollection/).

После создания коллекции её можно задать с помощью метода [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) презентации. [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) управляет шрифтами во всей презентации, и каждый объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) имеет свой собственный [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/).

Как только [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) инициализируется коллекцией резервных шрифтов, указанные резервные шрифты применяются при рендеринге презентации.

## **Применение правил резервных шрифтов**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrule/) могут быть сгруппированы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontfallbackrulescollection/). Вы можете добавлять или удалять правила из коллекции.

Эту коллекцию затем можно задать с помощью метода [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/), который управляет шрифтами во всей презентации.

У каждого [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) есть метод [getFontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getFontsManager), который возвращает его собственный экземпляр класса [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/).

Ниже приведён пример, показывающий, как создать коллекцию правил резервных шрифтов и назначить её [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

После того как [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) инициализируется коллекцией резервных шрифтов, резервные шрифты применяются при рендеринге презентации.

{{% alert color="info" title="Примечание" %}}
Узнайте больше о том, как [render a presentation with a fallback font](/slides/ru/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервных шрифтов встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервных шрифтов являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не появятся в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно, полностью на своей ответственности.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для отсутствующих глифов?**

Да. Это независимые стадии одного конвейера определения шрифтов: сначала движок решает доступность шрифтов ([replacement](/slides/ru/python-java/font-replacement/)/[substitution](/slides/ru/python-java/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.