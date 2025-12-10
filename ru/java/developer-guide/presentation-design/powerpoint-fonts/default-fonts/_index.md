---
title: Укажите шрифты презентации по умолчанию в Java
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/java/default-font/
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
- Java
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides for Java, чтобы обеспечить корректное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет задать шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить DefaultRegularFont и DefaultAsianFont для использования в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги, чтобы загрузить шрифты из внешних каталогов с помощью Aspose.Slides for Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) на нужный вам шрифт. В приведённом ниже примере используется Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) на нужный вам шрифт. В примере также используется Wingdings.
1. Загрузите презентацию с помощью Presentation, указав параметры загрузки.
1. Затем сгенерируйте миниатюры слайдов, PDF и XPS, чтобы проверить результаты.

Реализация описанного выше представлена ниже.
```java
// Используйте параметры загрузки для определения шрифтов по умолчанию для обычных и азиатских.
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


## **FAQ**

**Что именно влияют DefaultRegularFont и DefaultAsianFont — только экспорт или также миниатюры, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых форматов вывода. Это включает миниатюры слайдов, [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/java/convert-powerpoint-to-xps/), [растрированные изображения](/slides/ru/java/convert-powerpoint-to-png/), [HTML](/slides/ru/java/convert-powerpoint-to-html/), и [SVG](/slides/ru/java/render-a-slide-as-an-svg-image/), поскольку Aspose.Slides использует одну и ту же логику компоновки и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без какого‑либо рендеринга?**

Нет. Шрифты по умолчанию влияют только тогда, когда необходимо измерять и рисовать текст. Прямое открытие‑сохранение презентации не меняет хранимые наборы шрифтов и структуру файла. Шрифты по умолчанию вступают в действие при операциях, которые выполняют рендеринг или перелив текста.

**Если я добавлю собственные папки со шрифтами или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/java/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/java/fallback-font/) сначала будут искаться в этих источниках, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Будут ли шрифты по умолчанию влиять на метрики текста (кернинг, шаги) и, следовательно, на разрывы строк и переносы?**

Да. Смена шрифта меняет метрики глифов и может изменять разрывы строк, переносы и пагинацию при рендеринге. Для стабильности макета рекомендуется [embed the original fonts](/slides/ru/java/embedded-font/) или выбирать метрично совместимые семейства шрифтов по умолчанию и резервные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты в презентации внедрены?**

Часто это не требуется, поскольку [embedded fonts](/slides/ru/java/embedded-font/) уже гарантируют одинаковый внешний вид. Шрифты по умолчанию всё же полезны как резервный вариант для символов, не покрытых внедрённым набором, или когда файл содержит смесь внедрённых и не внедрённых текстов.