---
title: Шрифты по умолчанию - PowerPoint JavaScript API
linktitle: Шрифты по умолчанию
type: docs
weight: 30
url: /ru/nodejs-java/default-font/
description: PowerPoint JavaScript API позволяет задавать шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. Эта статья показывает, как определить DefaultRegular Font и DefaultAsian Font для использования в качестве шрифтов по умолчанию.
---

## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет задавать шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. Эта статья показывает, как определить DefaultRegularFont и DefaultAsianFont для использования их в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги, чтобы загрузить шрифты из внешних каталогов, используя Aspose.Slides для Node.js через Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) к желаемому шрифту. В следующем примере я использовал Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) к желаемому шрифту. Я использовал Wingdings в следующем примере.
1. Загрузите презентацию, используя Presentation и указав параметры загрузки.
1. Теперь создайте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеописанного приведена ниже.
```javascript
// Используйте параметры загрузки для определения шрифтов по умолчанию для обычного и азиатского
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Load the presentation
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Создать миниатюру слайда
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // сохранить изображение на диск.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Создать PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Создать XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Что именно влияют DefaultRegularFont и DefaultAsianFont — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых форматов вывода. Это включает миниатюры слайдов, [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/), [растровые изображения](/slides/ru/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), и [SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/), поскольку Aspose.Slides использует одну и ту же логику размещения и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без любого рендеринга?**

Нет. Шрифты по умолчанию важны, когда требуется измерять и отрисовывать текст. Прямая операция «открыть‑сохранить» презентации не меняет сохранённые наборы шрифтов и структуру файла. Шрифты по умолчанию вступают в силу при операциях, которые рендерят или переоформляют текст.

**Если я добавлю собственные папки со шрифтами или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/nodejs-java/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/nodejs-java/fallback-font/) сначала проверяют эти источники, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (кернинг, шаги) и, следовательно, на разрывы строк и переносы?**

Да. Смена шрифта меняет метрики глифов и может изменять разрывы строк, переносы и разбиение на страницы во время рендеринга. Для стабильности макета [embed the original fonts](/slides/ru/nodejs-java/embedded-font/) или выбирайте метрично совместимые семейства по умолчанию и резервные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты в презентации встроены?**

Часто это не требуется, потому что [embedded fonts](/slides/ru/nodejs-java/embedded-font/) уже обеспечивают согласованный вид. Шрифты по умолчанию всё же полезны как страховка для символов, не покрытых встроенным подмножеством, или когда файл сочетает встроенный и не встроенный текст.