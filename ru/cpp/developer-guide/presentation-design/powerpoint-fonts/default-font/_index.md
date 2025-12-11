---
title: Указание шрифтов презентации по умолчанию в С++
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/cpp/default-font/
keywords:
- шрифт по умолчанию
- обычный шрифт
- нормальный шрифт
- азиатский шрифт
- Экспорт PDF
- Экспорт XPS
- Экспорт изображений
- PowerPoint
- OpenDocument
- презентация
- С++
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides для С++, чтобы обеспечить корректную конвертацию PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Установить шрифт по умолчанию**
Using Aspose.Slides for C++ you can set the default font in PowerPoint presentations. A new method [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) has been added to [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) class. It allows to set the default font used instead of all missing fonts during saving presentations to different formats without reloading the presentations .

The code snippet below demonstrates saving presentation to [HTML](https://docs.fileformat.com/web/html/) and [PDF](https://docs.fileformat.com/pdf/) with different default regular font.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **Использовать шрифты по умолчанию при визуализации презентации**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for C++ API:

1. Создайте экземпляр LoadOptions.
1. Установите DefaultRegularFont в нужный вам шрифт. В следующем примере я использовал Wingdings.
1. Установите DefaultAsianFont в нужный вам шрифт. В следующем образце я использовал Wingdings.
1. Загрузите презентацию, используя Presentation и задав параметры загрузки.
1. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

```cpp
// Используйте параметры загрузки, чтобы указать шрифты по умолчанию: обычный и азиатский
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```


## **FAQ**

**Что именно влияют DefaultRegularFont и DefaultAsianFont — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере визуализации для всех поддерживаемых выводов. Это включает миниатюры слайдов, [PDF](/slides/ru/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/ru/cpp/convert-powerpoint-to-xps/), [растровые изображения](/slides/ru/cpp/convert-powerpoint-to-png/), [HTML](/slides/ru/cpp/convert-powerpoint-to-html/), и [SVG](/slides/ru/cpp/render-a-slide-as-an-svg-image/), потому что Aspose.Slides использует одинаковую логику размещения и разрешения глифов для этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без любой визуализации?**

Нет. Шрифты по умолчанию важны, когда текст необходимо измерять и отрисовывать. Простое открытие и сохранение презентации не меняет сохранённые наборы шрифтов и структуру файла. Шрифты по умолчанию вступают в действие при операциях, которые визуализируют или переразмещают текст.

**Если я добавлю свои папки со шрифтами или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/cpp/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/cpp/fallback-font/) будут сначала искать в этих источниках, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрику текста (кернинг, advance) и, следовательно, на переносы строк и обтекание?**

Да. Смена шрифта меняет метрику глифов и может изменить переносы строк, обтекание и разбивку страниц при визуализации. Для стабильности компоновки [embed the original fonts](/slides/ru/cpp/embedded-font/) или выбирайте метрично совместимые семейства по умолчанию и запасные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты, используемые в презентации, встроены?**

Часто это не требуется, поскольку [embedded fonts](/slides/ru/cpp/embedded-font/) уже обеспечивают согласованный внешний вид. Шрифты по умолчанию всё равно полезны как запасной вариант для символов, не покрытых встроенным набором, или когда файл сочетает встроенный и не встроенный текст.