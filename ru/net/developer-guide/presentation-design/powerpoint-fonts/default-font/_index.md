---
title: Шрифт по умолчанию - PowerPoint C# API
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /net/default-font/
keywords: "Шрифты, шрифты по умолчанию, рендеринг презентации PowerPoint C#, Csharp, Aspose.Slides для .NET"
description: PowerPoint C# API позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры
---

## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию. Пожалуйста, следуйте приведённым ниже шагам для загрузки шрифтов из внешних каталогов с использованием Aspose.Slides для .NET API:

1. Создайте экземпляр LoadOptions.
1. Установите DefaultRegularFont на желаемый шрифт. В следующем примере я использовал Wingdings.
1. Установите DefaultAsianFont на желаемый шрифт. Я также использовал Wingdings в следующем примере.
1. Загрузите презентацию, используя Presentation и установив параметры загрузки.
1. Теперь создайте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеизложенного приведена ниже.

```c#
// Используйте параметры загрузки для определения шрифтов по умолчанию для регулярных и азиатских шрифтов
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

// Загрузите презентацию
using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    // Создайте миниатюру слайда
    pptx.Slides[0].GetThumbnail(1, 1).Save("output_out.png", ImageFormat.Png);

    // Создайте PDF
    pptx.Save("output_out.pdf", SaveFormat.Pdf);

    // Создайте XPS
    pptx.Save("output_out.xps", SaveFormat.Xps);
}
```