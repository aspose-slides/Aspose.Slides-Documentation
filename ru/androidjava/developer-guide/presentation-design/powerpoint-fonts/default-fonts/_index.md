---
title: Указание шрифтов по умолчанию для презентации на Android
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides для Android через Java, чтобы обеспечить корректное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использовать шрифты по умолчанию для рендеринга презентации**
Aspose.Slides позволяет задать шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить DefaultRegularFont и DefaultAsianFont для использования их в качестве шрифтов по умолчанию. Пожалуйста, выполните нижеприведённые шаги по загрузке шрифтов из внешних каталогов с помощью Aspose.Slides для Android через Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) к желаемому шрифту. В следующем примере я использовал Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) к желаемому шрифту. Я использовал Wingdings в следующем примере.
1. Загрузите презентацию, используя Presentation и задав параметры загрузки.
1. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация выше приведена ниже.
```java
// Используйте параметры загрузки для определения шрифтов по умолчанию: обычного и азиатского
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Загрузите презентацию
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Создайте миниатюру слайда
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // сохраните изображение на диск.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Создайте PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Создайте XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Что именно влияют DefaultRegularFont и DefaultAsianFont — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых форматов. Это включает миниатюры слайдов, [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ru/androidjava/convert-powerpoint-to-xps/), [растровые изображения](/slides/ru/androidjava/convert-powerpoint-to-png/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), и [SVG](/slides/ru/androidjava/render-a-slide-as-an-svg-image/), поскольку Aspose.Slides использует одну и ту же логику размещения и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без рендеринга?**

Нет. Шрифты по умолчанию имеют значение, когда текст необходимо измерять и отрисовывать. Прямое открытие и сохранение презентации не меняет сохранённые диапазоны шрифтов или структуру файла. Шрифты по умолчанию вступают в действие в операциях, которые рендерят или перераспределяют текст.

**Если я добавлю свои папки со шрифтами или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/androidjava/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/androidjava/fallback-font/) будут сначала проверять эти источники, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (керн, шаги) и, следовательно, на разрывы строк и переносы?**

Да. Смена шрифта меняет метрики глифов и может изменять разрывы строк, переносы и разбиение на страницы во время рендеринга. Для стабильности разметки [embed the original fonts](/slides/ru/androidjava/embedded-font/) или выберите метрично совместимые семейства шрифтов по умолчанию и резервные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты, используемые в презентации, встроены?**

Часто это не требуется, поскольку [embedded fonts](/slides/ru/androidjava/embedded-font/) уже обеспечивают единообразный внешний вид. Шрифты по умолчанию всё равно могут служить страховкой для символов, не покрытых встроенным набором, или когда файл сочетает встроенный и не встроенный текст.