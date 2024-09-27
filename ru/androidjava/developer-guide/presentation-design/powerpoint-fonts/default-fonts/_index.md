---
title: Шрифты по умолчанию - PowerPoint Java API
linktitle: Шрифты по умолчанию
type: docs
weight: 30
url: /ru/androidjava/default-font/
description: PowerPoint Java API позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. Эта статья демонстрирует, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию.
---


## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. Эта статья демонстрирует, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию. Пожалуйста, следуйте приведенным ниже шагам, чтобы загрузить шрифты из внешних директорий с помощью Aspose.Slides для Android через Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [Установите DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) на желаемый шрифт. В следующем примере я использовал Wingdings.
1. [Установите DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) на желаемый шрифт. В следующем примере я использовал Wingdings.
1. Загрузите презентацию, используя Presentation и установив параметры загрузки.
1. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеизложенного приведена ниже.

```java
// Используйте параметры загрузки для определения шрифтов по умолчанию
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

    // Сохраните в PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Сохраните в XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```