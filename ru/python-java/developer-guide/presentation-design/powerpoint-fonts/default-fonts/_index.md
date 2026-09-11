---
title: Указание шрифтов презентации по умолчанию в Python через Java
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/python-java/default-font/
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
- Java
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides для Python через Java, чтобы обеспечить правильное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---
## **Обзор**

Aspose.Slides позволяет задавать шрифты по умолчанию, которые используются при рендеринге презентации. Это полезно при создании миниатюр слайдов или экспорте презентации в такие форматы, как PDF и XPS. Шрифты по умолчанию настраиваются через [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/) до загрузки презентации.

Метод [setDefaultRegularFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) определяет шрифт по умолчанию для обычного текста, а [setDefaultAsianFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) — шрифт по умолчанию для азиатского текста. После установки этих параметров презентацию можно загрузить и отрендерить, используя указанные шрифты.

## **Использование шрифтов по умолчанию для рендеринга презентации**

Aspose.Slides позволяет задавать шрифты по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этом разделе показано, как определить шрифты по умолчанию для обычного и азиатского текста с помощью Aspose.Slides for Python via Java:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/).
2. Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) для указания требуемого шрифта. В следующем примере используется Wingdings.
3. Вызовите [setDefaultAsianFont](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) для указания требуемого шрифта. В следующем примере также используется Wingdings.
4. Загрузите презентацию, используя [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) с параметрами загрузки.
5. Сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Используйте параметры загрузки для определения шрифтов по умолчанию для обычного и азиатского текста.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Загрузите презентацию.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Создайте миниатюру слайда.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Сохраните изображение на диск.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Создайте PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Создайте документ XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Что именно влияют шрифты по умолчанию для обычного и азиатского текста — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых выводов. Это включает миниатюры слайдов, [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/), [raster images](/slides/ru/python-java/convert-powerpoint-to-png/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), и [SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/), поскольку Aspose.Slides использует одну и ту же логику размещения и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без рендеринга?**

Нет. Шрифты по умолчанию важны, когда текст необходимо измерять и отрисовывать. Прямое открытие и сохранение презентации не изменяет сохранённые наборы шрифтов и структуру файла. Шрифты по умолчанию вступают в действие при операциях, которые рендерят или переоформляют текст.

**Если я добавлю свои собственные папки шрифтов или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/python-java/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/python-java/fallback-font/) будут сначала проверять эти источники, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (кернинг, длину), а следовательно, на разрывы строк и переносы?**

Да. Смена шрифта меняет метрики глифов и может изменять разрывы строк, переносы и пагинацию при рендеринге. Для стабильности макета рекомендуется [embed the original fonts](/slides/ru/python-java/embedded-font/) или выбирать метрично совместимые семейства шрифтов по умолчанию и резервные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты, использованные в презентации, встроены?**

Часто это не требуется, поскольку [embedded fonts](/slides/ru/python-java/embedded-font/) уже гарантируют одинаковый внешний вид. Шрифты по умолчанию всё равно могут служить резервной мерой для символов, не покрытых встроенным набором, или когда файл сочетает встроенный и не встроенный текст.