---
title: Настройка шрифтов по умолчанию в презентациях с помощью Python
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/python-net/default-font/
keywords:
- шрифт по умолчанию
- обычный шрифт
- нормальный шрифт
- азиатский шрифт
- экспорт PDF
- экспорт XPS
- экспорт изображений
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides для Python, чтобы обеспечить правильное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использование шрифтов по умолчанию при рендеринге презентации**
Aspose.Slides позволяет задать шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить DefaultRegularFont и DefaultAsianFont для использования в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги для загрузки шрифтов из внешних каталогов с помощью Aspose.Slides for Python via .NET API:

1. Создайте экземпляр LoadOptions.
1. Установите DefaultRegularFont на нужный вам шрифт. В следующем примере я использовал Wingdings.
1. Установите DefaultAsianFont на нужный вам шрифт. Я использовал Wingdings в следующем образце.
1. Загрузите презентацию, используя Presentation и указав параметры загрузки.
1. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеописанного приведена ниже.
```py
import aspose.slides as slides

# Используйте параметры загрузки для определения шрифтов по умолчанию regular и asian# Используйте параметры загрузки для определения шрифтов по умолчанию regular и asian
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Загрузить презентацию
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Создать миниатюру слайда
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Создать PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Создать XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **FAQ**

**Что именно влияют параметры default_regular_font и default_asian_font — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых выходов. Это включает миниатюры слайдов, [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [растровые изображения](/slides/ru/python-net/convert-powerpoint-to-png/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), и [SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/), поскольку Aspose.Slides использует одинаковую логику разметки и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без какого‑либо рендеринга?**

Нет. Шрифты по умолчанию имеют значение, когда текст нужно измерять и рисовать. Прямое открытие‑и‑сохранение презентации не изменяет сохранённые наборы шрифтов или структуру файла. Шрифты по умолчанию вступают в силу во время операций, которые рендерят или переупорядочивают текст.

**Если я добавлю собственные каталоги шрифтов или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/python-net/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/python-net/fallback-font/) будут сначала проверять эти источники, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (кернинг, шаги) и, следовательно, на переносы строк и обтекание?**

Да. Смена шрифта изменяет метрики глифов и может влиять на переносы строк, обтекание и разбиение на страницы во время рендеринга. Для стабильности разметки рекомендуется [embed the original fonts](/slides/ru/python-net/embedded-font/) или выбирать метрично совместимые семейства шрифтов по умолчанию и fallback.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты в презентации уже встроены?**

Часто это не требуется, поскольку [embedded fonts](/slides/ru/python-net/embedded-font/) уже обеспечивают единообразный вид. Шрифты по умолчанию всё же могут служить страховкой для символов, не покрытых встроенным подмножеством, или когда файл сочетает встроенный и не встроенный текст.