---
title: Встраиваемые шрифты - PowerPoint C# API
linktitle: Встраиваемый шрифт
type: docs
weight: 40
url: /ru/net/embedded-font/
keywords: "Шрифты, встроенные шрифты, добавление шрифтов, PowerPoint презентация C#, Csharp, Aspose.Slides для .NET"
description: "Используйте встроенные шрифты в PowerPoint-презентации на C# или .NET"
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась корректно на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, у вас есть еще больше причин для встраивания шрифта. В противном случае (без встроенных шрифтов) текст или числа на ваших слайдах, компоновка, стилизация и т. д. могут измениться или превратиться в запутанные прямоугольники.

Класс [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), класс [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) и класс [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) и их интерфейсы содержат большинство свойств и методов, необходимых для работы с встроенными шрифтами в PowerPoint-презентациях.

## **Получение или удаление встроенных шрифтов из презентации**

Aspose.Slides предоставляет метод [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) (предоставляемый классом [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)), который позволяет получить (или узнать) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) (предоставляемый тем же классом).

Этот код C# демонстрирует, как получить и удалить встроенные шрифты из презентации:

```c#
// Создает объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    // Отображает слайд, содержащий текстовый блок, использующий встроенный шрифт "FunSized"
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture1_out.png", ImageFormat.Png);

    IFontsManager fontsManager = presentation.FontsManager;

    // Получает все встроенные шрифты
    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Находит шрифт "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate(IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Удаляет шрифт "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Отображает презентацию; шрифт "Calibri" заменяется существующим
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture2_out.png", ImageFormat.Png);

    // Сохраняет презентацию без встроенного шрифта "Calibri" на диск
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Добавление встроенных шрифтов в презентацию**
Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) и два перегруженных метода [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), вы можете выбрать предпочитаемое правило (встраивания) для встраивания шрифтов в презентацию. Этот код C# демонстрирует, как встроить и добавить шрифты в презентацию:

```c#
// Загружает презентацию
Presentation presentation = new Presentation("Fonts.pptx");

// Загружает исходный шрифт для замены
IFontData sourceFont = new FontData("Arial");

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

Чтобы сжать встроенные шрифты в презентации и уменьшить ее размер, Aspose.Slides предоставляет метод [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) (предоставляемый классом [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)).

Этот код C# показывает, как сжать встроенные шрифты PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```