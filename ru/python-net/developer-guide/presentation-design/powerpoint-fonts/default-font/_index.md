---
title: Настройка шрифтов по умолчанию в презентациях с Python
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
description: "Установите шрифты по умолчанию в Aspose.Slides для Python, чтобы обеспечить правильную конверсию PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использование шрифтов по умолчанию при визуализации презентации**
Aspose.Slides позволяет установить шрифт по умолчанию для визуализации презентации в PDF, XPS или миниатюрах. Эта статья показывает, как определить DefaultRegularFont и DefaultAsianFont для использования в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги, чтобы загрузить шрифты из внешних каталогов, используя Aspose.Slides для Python через .NET API:

1. Создайте экземпляр LoadOptions.  
2. Установите DefaultRegularFont на желаемый шрифт. В следующем примере я использовал Wingdings.  
3. Установите DefaultAsianFont на желаемый шрифт. В следующем примере я использовал Wingdings.  
4. Загрузите презентацию, используя Presentation и задав параметры загрузки.  
5. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.  

Реализация приведена ниже.

```py
import aspose.slides as slides

# Используйте параметры загрузки для определения шрифтов по умолчанию (обычных и азиатских)
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Load the presentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Сгенерировать миниатюру слайда
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Сгенерировать PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Сгенерировать XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Что именно влияют default_regular_font и default_asian_font — только экспорт, или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых выходов. Это включает миниатюры слайдов, [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ru/python-net/convert-powerpoint-to-xps/), [raster images](/slides/ru/python-net/convert-powerpoint-to-png/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), и [SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/), потому что Aspose.Slides использует одну и ту же логику размещения и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без рендеринга?**

Нет. Шрифты по умолчанию важны, когда текст необходимо измерять и отрисовывать. Прямое открытие‑сохранение презентации не меняет сохранённые наборы шрифтов или структуру файла. Шрифты по умолчанию вступают в действие во время операций, которые рендерят или перерабатывают текст.

**Если я добавлю собственные каталоги шрифтов или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/python-net/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/python-net/fallback-font/) будут сначала искать их в этих источниках, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (кернинг, шаги) и, следовательно, на переносы строк и обтекание?**

Да. Изменение шрифта меняет метрики глифов и может изменить переносы строк, обтекание и разбиение на страницы во время рендеринга. Для стабильности разметки [embed the original fonts](/slides/ru/python-net/embedded-font/) или выбирайте метрично совместимые семейства по умолчанию и fallback.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты, использованные в презентации, встроены?**

Часто это не требуется, потому что [embedded fonts](/slides/ru/python-net/embedded-font/) уже гарантируют единообразный вид. Шрифты по умолчанию всё же полезны как запасной вариант для символов, не покрытых встроенным набором, или когда файл сочетает встроенный и не встроенный текст.