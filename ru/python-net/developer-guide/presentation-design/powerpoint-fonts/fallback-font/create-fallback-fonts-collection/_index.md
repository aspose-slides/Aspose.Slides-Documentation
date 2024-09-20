---
title: Создание коллекции запасных шрифтов
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords: "Коллекция запасных шрифтов, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Коллекция запасных шрифтов в PowerPoint на Python"
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/), который реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) интерфейс. Можно добавлять или удалять правила из коллекции.

Затем эта коллекция может быть назначена свойству [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) класса [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). FontsManager управляет шрифтами в презентации. Узнайте больше [О FontsManager и FontsLoader](/slides/python-net/about-fontsmanager-and-fontsloader/).

Каждая [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) имеет свойство [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) с экземпляром класса FontsManager.

Вот пример того, как создать коллекцию правил запасных шрифтов и назначить её в FontsManager определенной презентации:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

После инициализации FontsManager с коллекцией запасных шрифтов, запасные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Узнайте больше о том, как [Рендерить презентацию с запасным шрифтом](/slides/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}