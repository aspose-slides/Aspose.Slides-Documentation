---
title: Конфигурировать коллекцию резервных шрифтов в Python
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/python-net/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настроить шрифт
- установить шрифт
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создать коллекцию резервных шрифтов в Aspose.Slides для Python через .NET, чтобы обеспечить согласованность и четкость текста в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить свойству [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) класса [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager управляет шрифтами во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/python-net/about-fontsmanager-and-fontsloader/).

Каждая [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) имеет свойство [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) с собственным экземпляром класса FontsManager.

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в FontsManager определённой презентации:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются при рендеринге презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта — это параметры рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм замены глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Шрифты вы добавляете и используете самостоятельно, полностью на своей ответственности.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов?**

Да. Это независимые этапы единого конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/python-net/font-replacement/)/[substitution](/slides/ru/python-net/font-substitution/)), затем резервный шрифт заполняет пробелы недостающих глифов в доступных шрифтах.