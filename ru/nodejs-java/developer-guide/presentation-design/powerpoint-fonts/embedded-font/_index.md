---
title: "Встроенный шрифт - PowerPoint JavaScript API"
linktitle: "Встроенный шрифт"
type: docs
weight: 40
url: /ru/nodejs-java/embedded-font/
keywords: "Шрифты, встроенные шрифты, добавление шрифтов, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Использование встроенных шрифтов в презентации PowerPoint на JavaScript"
---

**Встроенные шрифты в PowerPoint** полезны, когда нужно, чтобы ваша презентация отображалась правильно на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в работе, то у вас есть ещё больше причин встраивать шрифт. В противном случае (без встроенных шрифтов) текст или цифры на слайдах, макет, стили и т.д. могут измениться или превратиться в непонятные прямоугольники. 

Классы [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/), [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) и их члены содержат большинство свойств и методов, необходимых для работы со встроенными шрифтами в презентациях PowerPoint.

## **Получить или удалить встроенные шрифты из презентации**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (доступный через класс [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)), позволяющий получить (или узнать) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) того же класса.

Этот JavaScript‑код показывает, как получить и удалить встроенные шрифты из презентации:
```javascript
// Создаёт объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Рендерит слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Сохраняет изображение на диск в формате JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Получает все встроенные шрифты
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Находит шрифт "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Удаляет шрифт "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Рендерит презентацию; шрифт "Calibri" заменяется существующим
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Сохраняет изображение на диск в формате JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Сохраняет презентацию без встроенного шрифта "Calibri" на диск
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавить встроенные шрифты в презентацию**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) и два перегруженных варианта метода [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), вы можете выбрать предпочтительное правило встраивания шрифтов в презентацию. Этот JavaScript‑код показывает, как встроить и добавить шрифты в презентацию:
```javascript
// Загружает презентацию
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Сохраняет презентацию на диск
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Сжать встроенные шрифты**

Чтобы позволить сжать встроенные в презентацию шрифты и уменьшить её размер, Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (доступный через класс [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)).

Этот JavaScript‑код показывает, как сжать встроенные шрифты PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как понять, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о замене](/slides/ru/nodejs-java/font-substitution/) в менеджере шрифтов и [правила резервирования/замены](/slides/ru/nodejs-java/fallback-font/): если шрифт недоступен или ограничен, будет использован резервный шрифт.

**Стоит ли встраивать системные шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной портативности в «плотных» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданной замены.