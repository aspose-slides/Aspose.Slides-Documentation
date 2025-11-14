---
title: Оптимизируйте замену шрифтов в презентациях с помощью Python
linktitle: Замена шрифтов
type: docs
weight: 60
url: /ru/python-net/font-replacement/
keywords:
- шрифт
- замена шрифта
- изменить шрифт
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Беспрепятственно заменяйте шрифты в Aspose.Slides for Python via .NET, чтобы обеспечить единообразную типографику в презентациях PowerPoint и OpenDocument."
---

Если вы передумали использовать шрифт, вы можете заменить его другим шрифтом. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет заменить шрифт следующим образом:

1. Загрузите нужную презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Замените шрифт.
5. Запишите измененную презентацию в файл PPTX.

Этот код на Python демонстрирует замену шрифта:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Загрузка презентации
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Загружает исходный шрифт, который будет заменен
    sourceFont = slides.FontData("Arial")

    # Загружает новый шрифт
    destFont = slides.FontData("Times New Roman")

    # Заменяет шрифты
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Сохраняет презентацию
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Примечание" color="warning" %}} 

Чтобы установить правила, определяющие, что происходит в определенных условиях (например, если шрифт недоступен), смотрите [**Замена шрифтов**](/slides/ru/python-net/font-substitution/). 

{{% /alert %}}