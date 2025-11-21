---
title: Встраивание шрифтов в PowerPoint с C#
linktitle: Встраивание шрифтов
type: docs
weight: 40
url: /ru/net/embedded-font/
keywords:
- встраивание шрифтов
- PowerPoint C#
- добавление шрифтов
- презентация
- Aspose.Slides for .NET
description: "Узнайте, как встраивать, добавлять и управлять шрифтами в презентациях PowerPoint с использованием C# и .NET"
---

**Встраивание шрифтов в PowerPoint** гарантирует, что ваша презентация сохраняет задуманное оформление на разных системах. Будь то уникальные шрифты для креативных решений или стандартные, встраивание шрифтов предотвращает искажение текста и макета.

Если вы использовали сторонний или нестандартный шрифт, потому что захотели проявить креативность в работе, у вас есть еще больше причин встроить шрифт. В противном случае (без встроенных шрифтов) тексты или цифры на слайдах, макет, стили и т.д. могут измениться или превратиться в непонятные квадраты.

Используйте классы [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) и [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) для управления встроенными шрифтами.

## **Получение и удаление встроенных шрифтов**

Получайте или удаляйте встроенные шрифты из презентации без усилий с помощью методов [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) и [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Этот C#‑код показывает, как получить и удалить встроенные шрифты из презентации:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Визуализирует слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Находит шрифт "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Удаляет шрифт "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Визуализирует презентацию; шрифт "Calibri" заменяется существующим
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Сохраняет презентацию без встроенного "Calibri" шрифта на диск
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Добавление встроенных шрифтов**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) и две перегрузки метода [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), вы можете выбрать предпочтительное правило (встраивания) для включения шрифтов в презентацию. Этот C#‑код демонстрирует, как встроить и добавить шрифты в презентацию:
```c#
 // Загружает презентацию
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Сохраняет презентацию на диск
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **Сжатие встроенных шрифтов**

Оптимизируйте размер файла, сжимая встроенные шрифты с помощью [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Пример кода для сжатия:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [информацию о подстановке](/slides/ru/net/font-substitution/) в менеджере шрифтов и [правила fallback/подстановки](/slides/ru/net/fallback-font/): если шрифт недоступен или ограничен, будет использован запасной вариант.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Но для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданных подстановок.