---
title: Встроенные шрифты - PowerPoint Java API
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "Шрифты, встроенные шрифты, добавление шрифтов, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Использование встроенных шрифтов в презентации PowerPoint на Java"

---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась корректно при открытии на любой системе или устройстве. Если вы использовали шрифт третьей стороны или нестандартный шрифт потому, что проявили креативность в своей работе, то у вас еще больше причин встроить свой шрифт. В противном случае (без встроенных шрифтов) тексты или числа на ваших слайдах, макет, стили и т. д. могут измениться или превратиться в запутанные прямоугольники.

Класс [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), класс [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) и класс [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) и их интерфейсы содержат большинство свойств и методов, необходимых для работы с встроенными шрифтами в презентациях PowerPoint.

## **Получение или удаление встроенных шрифтов из презентации**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (предоставляемый классом [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)), который позволяет получить (или выяснить) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (предоставляемый тем же классом).

Этот код на Java показывает, как получить и удалить встроенные шрифты из презентации:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Рендерит слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Сохранить изображение на диск в формате JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Получает все встроенные шрифты
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Находит шрифт "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println("" + embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Удаляет шрифт "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Рендерит презентацию; шрифт "Calibri" заменяется существующим
    slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Сохранить изображение на диск в формате JPEG
    try {
        slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    // Сохраняет презентацию без встроенного шрифта "Calibri" на диск
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление встроенных шрифтов в презентацию**

С помощью перечисления [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) и двух перегрузок метода [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) вы можете выбрать предпочитаемое правило (встраивание) для встраивания шрифтов в презентацию. Этот код на Java показывает, как встроить и добавить шрифты в презентацию:

```java
// Загружает презентацию
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Сохраняет презентацию на диск
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Сжатие встроенных шрифтов**

Чтобы вы могли сжать шрифты, встроенные в презентацию, и уменьшить ее размер файла, Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (предоставляемый классом [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

Этот код на Java показывает, как сжать встроенные шрифты PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```