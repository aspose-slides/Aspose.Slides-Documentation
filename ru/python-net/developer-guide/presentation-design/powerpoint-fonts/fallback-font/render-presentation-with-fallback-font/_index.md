---
title: Отображение презентаций с резервными шрифтами в Python
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/python-net/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- рендеринг PowerPoint
- рендеринг презентации
- рендеринг слайда
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для Python через .NET – сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода."
---

Следующий пример включает следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) правило резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) к другому правилу.
1. Установите коллекцию правил в свойство [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) мы можем сохранить презентацию в том же формате или сохранить её в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```py
import aspose.slides as slides

# Создать новый экземпляр коллекции правил
rulesList = slides.FontFallBackRulesCollection()

# создать несколько правил
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
	fallBackRule.remove("Tahoma")

	# И обновить правила для указанного диапазона
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Также можем удалить любые существующие правила из списка
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Присваивание подготовленного списка правил для использования
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранением в PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```



{{% alert color="primary" %}} 
Узнайте больше о том, как [Конвертировать слайды PowerPoint в PNG на Python](/slides/ru/python-net/convert-powerpoint-to-png/).
{{% /alert %}}