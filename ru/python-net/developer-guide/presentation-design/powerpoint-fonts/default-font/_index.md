---
title: Настройте шрифт по умолчанию в презентациях с помощью Python
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/python-net/default-font/
keywords:
  - шрифт по умолчанию
  - обычный шрифт
  - нормальный шрифт
  - азиатский шрифт
  - экспорт в PDF
  - экспорт в XPS
  - экспорт изображений
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides for Python, чтобы обеспечить корректное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию. Пожалуйста, следуйте приведённым ниже шагам для загрузки шрифтов из внешних каталогов с использованием Aspose.Slides для Python через API .NET:

1. Создайте экземпляр LoadOptions.
2. Установите DefaultRegularFont на желаемый шрифт. В следующем примере я использовал Wingdings.
3. Установите DefaultAsianFont на желаемый шрифт. Я использовал Wingdings в следующем примере.
4. Загрузите презентацию, используя Presentation и установив параметры загрузки.
5. Теперь создайте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеуказанного приведена ниже.

```py
import aspose.slides as slides

# Используйте параметры загрузки для определения шрифтов по умолчанию для обычных и азиатских шрифтов
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Загрузите презентацию
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Создайте миниатюру слайда
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Создайте PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Создайте XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```