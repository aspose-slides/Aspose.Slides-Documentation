---
title: Замена шрифтов
type: docs
weight: 70
url: /ru/python-net/font-substitution/
keywords: "Шрифт, замена шрифта, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Замена шрифта в PowerPoint на Python"
---

Aspose.Slides позволяет задавать правила для шрифтов, которые определяют, что необходимо делать при определенных условиях (например, когда шрифт недоступен) следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Сгенерируйте изображение слайда, чтобы увидеть эффект.

Этот код на Python демонстрирует процесс замены шрифтов:

```python
import aspose.slides as slides

# Загружает презентацию
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Загружает исходный шрифт, который будет заменен
    sourceFont = slides.FontData("SomeRareFont")

    # Загружает новый шрифт
    destFont = slides.FontData("Arial")

    # Добавляет правило шрифта для замены шрифта
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Добавляет правило в коллекцию правил замены шрифтов
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Добавляет коллекцию правил шрифтов в список правил
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Шрифт Arial будет использован вместо SomeRareFont, когда последний недоступен
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Сохраняет изображение на диск в формате JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Вы можете посмотреть [**Замена шрифтов**](/slides/ru/python-net/font-replacement/). 

{{% /alert %}}