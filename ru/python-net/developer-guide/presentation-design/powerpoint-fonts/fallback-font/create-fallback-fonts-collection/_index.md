---
title: Настройка резервных шрифтов в Python
linktitle: Настройка резервных шрифтов
type: docs
weight: 20
url: /ru/python-net/create-fallback-fonts-collection/
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
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для Python через .NET, чтобы текст оставался согласованным и чётким в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), который реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) интерфейс. Можно добавлять или удалять правила из этой коллекции.

Затем эту коллекцию можно присвоить свойству [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) класса [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager управляет шрифтами во всей презентации. Подробнее [About FontsManager and FontsLoader](/slides/ru/python-net/about-fontsmanager-and-fontsloader/).

Каждая [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) имеет свойство [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) c собственным экземпляром класса FontsManager.

Ниже приведён пример создания коллекции правил резервных шрифтов и назначения её FontsManager конкретной презентации:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


После инициализации FontsManager коллекцией резервных шрифтов, эти шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно, полностью отвечая за их наличие.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для отсутствующих глифов?**

Да. Это независимые стадии одного и того же конвейера разрешения шрифтов: сначала механизм определяет доступность шрифтов ([replacement](/slides/ru/python-net/font-replacement/)/[substitution](/slides/ru/python-net/font-substitution/)), затем резервный шрифт заполняет пробелы отсутствующих глифов в доступных шрифтах.