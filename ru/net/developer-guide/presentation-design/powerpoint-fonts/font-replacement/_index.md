---
title: Замена шрифта - PowerPoint C# API
linktitle: Замена шрифта
type: docs
weight: 60
url: /net/font-replacement/
keywords: "Шрифт, замена шрифта, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: С помощью C# PowerPoint API вы можете явно заменить шрифт другим шрифтом в презентации.
---

Если вы измените свое мнение о использовании шрифта, вы можете заменить этот шрифт на другой. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет вам заменить шрифт следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Замените шрифт.
5. Сохраните измененную презентацию как файл PPTX.

Этот код на C# демонстрирует замену шрифта:

```c#
// Загружает презентацию
Presentation presentation = new Presentation("Fonts.pptx");

// Загружает исходный шрифт, который будет заменен
IFontData sourceFont = new FontData("Arial");

// Загружает новый шрифт
IFontData destFont = new FontData("Times New Roman");

// Заменяет шрифты
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Сохраняет презентацию
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Примечание" color="warning" %}}

Чтобы установить правила, определяющие, что происходит в определенных условиях (например, если шрифт недоступен), смотрите [**Замена шрифта**](/slides/net/font-substitution/).

{{% /alert %}}