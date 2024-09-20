---
title: Отрисовка презентации с резервным шрифтом
type: docs
weight: 30
url: /python-net/render-presentation-with-fallback-font/
keywords: "Резервный шрифт, отрисовка PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Отрисовка PowerPoint с резервным шрифтом в Python"
---

Следующий пример включает следующие шаги:

1. Мы [создаем коллекцию правил резервных шрифтов](/slides/python-net/create-fallback-fonts-collection/).
1. [Удаляем()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) правило резервного шрифта и [Добавляем резервные шрифты()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) к другому правилу.
1. Устанавливаем коллекцию правил для свойства [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) мы можем сохранить презентацию в том же формате или сохранить ее в другом. После установки коллекции правил резервных шрифтов на FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, отрисовка, конвертация и т.д.

```py
import aspose.slides as slides

# Создаем новый экземпляр коллекции правил
rulesList = slides.FontFallBackRulesCollection()

# создаем несколько правил
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
	fallBackRule.remove("Tahoma")

	# И обновляем правила для указанного диапазона
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Также мы можем удалить любые существующие правила из списка
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Присваиваем подготовленный список правил для использования
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Отрисовка миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Читать далее о [Сохранении и конвертации презентации](/slides/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}