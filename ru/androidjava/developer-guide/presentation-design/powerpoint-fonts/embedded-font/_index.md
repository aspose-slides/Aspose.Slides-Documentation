---
title: Встраивание шрифтов в презентации на Android
linktitle: Встраивание шрифта
type: docs
weight: 40
url: /ru/androidjava/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифтов
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Встраивание шрифтов TrueType в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Android на Java, обеспечивая точную отрисовку на всех платформах."
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась правильно на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, у вас есть ещё более веские причины встроить шрифт. В противном случае (без встроенных шрифтов) текст или цифры на слайдах, макет, стиль и т.д. могут измениться или превратиться в непонятные прямоугольники. 

Класс [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), класс [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) и класс [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) вместе с их интерфейсами содержат большинство свойств и методов, необходимых для работы со встроенными шрифтами в презентациях PowerPoint.

## **Получить и удалить встроенные шрифты**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (доступный через класс [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)), позволяющий получить (или узнать) шрифты, встроенные в презентацию. Чтобы удалить шрифты, используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (доступный тем же классом).

Этот Java‑код показывает, как получить и удалить встроенные шрифты из презентации:
```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Рендерит слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Сохраняет изображение на диск в формате JPEG
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
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Удаляет шрифт "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Рендерит презентацию; шрифт "Calibri" заменяется существующим
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Сохраняет изображение на диск в формате JPEG
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



## **Добавить встроенные шрифты**

С помощью enum [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) и двух перегрузок метода [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) вы можете выбрать предпочтительное правило (встраивания) для внедрения шрифтов в презентацию. Этот Java‑код демонстрирует, как встроить и добавить шрифты в презентацию:
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


## **Сжать встроенные шрифты**

Для возможности сжатия шрифтов, встроенных в презентацию, и уменьшения её размера файл Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (доступный через класс [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

Этот Java‑код показывает, как сжать встроенные шрифты PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как я могу определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о замене](/slides/ru/androidjava/font-substitution/) в менеджере шрифтов и [правила резервных/заменяющих шрифтов](/slides/ru/androidjava/fallback-font/): если шрифт недоступен или ограничен, будет использован резервный.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, сервер Linux без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданных замен.