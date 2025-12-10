---
title: Встраивание шрифтов в презентации с использованием Java
linktitle: Встраивание шрифта
type: docs
weight: 40
url: /ru/java/embedded-font/
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
- Java
- Aspose.Slides
description: "Встраивание TrueType шрифтов в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Java, обеспечивая точный рендеринг на всех платформах."
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась правильно на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, у вас есть еще больше причин встроить шрифт. В противном случае (без встроенных шрифтов) тексты или цифры на слайдах, макет, стилизация и т.д. могут измениться или превратиться в непонятные прямоугольники. 

Классы [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/), [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) и их интерфейсы содержат большинство свойств и методов, необходимых для работы со встроенными шрифтами в презентациях PowerPoint. 

## **Получить и удалить встроенные шрифты**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (доступный через класс [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)), позволяющий получить (или узнать) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (также доступный через тот же класс).

Этот Java‑код показывает, как получить и удалить встроенные шрифты из презентации:
```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Рендерит слайд, содержащий текстовый кадр, использующий встроенный "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Сохраняет изображение на диск в формате JPEG
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

     // Сохраняет изображение на диск в формате JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Сохраняет презентацию без встроенного "Calibri" шрифта на диск
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавить встроенные шрифты**

С помощью перечисления [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) и двух перегрузок метода [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) вы можете выбрать предпочтительное правило (встраивания) для включения шрифтов в презентацию. Этот Java‑код демонстрирует, как встроить и добавить шрифты в презентацию:
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

Чтобы вы могли сжать встроенные в презентацию шрифты и уменьшить размер файла, Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (доступный через класс [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

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


## **Часто задаваемые вопросы**

**Как можно определить, что конкретный шрифт в презентации все равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о замене](/slides/ru/java/font-substitution/) в менеджере шрифтов и [правила резервного/заменяющего](/slides/ru/java/fallback-font/): если шрифт недоступен или ограничен, будет использован запасной вариант.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Однако для полной переносимости в «ограниченных» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может избавиться от риска неожиданных замен.