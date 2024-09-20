---
title: Замена шрифтов - PowerPoint C# API
linktitle: Замена шрифтов
type: docs
weight: 70
url: /net/font-substitution/
keywords: "Шрифт, заменяющий шрифт, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: C# PowerPoint API позволяет вам заменять шрифт внутри презентации
---

## **Получение замены шрифтов**

Чтобы узнать шрифты презентации, которые заменяются во время процесса рендеринга презентации, Aspose.Slides предоставляет метод [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) из интерфейса [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

Код C# показывает, как получить все замены шрифтов, которые выполняются при рендеринге презентации:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **Установка правил замены шрифтов**

Aspose.Slides позволяет вам устанавливать правила для шрифтов, которые определяют, что должно быть сделано в определенных условиях (например, когда шрифт недоступен) таким образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Генерируйте изображение слайда, чтобы наблюдать эффект.

Этот код C# демонстрирует процесс замены шрифтов:

```c#
// Загружает презентацию
Presentation presentation = new Presentation("Fonts.pptx");

// Загружает исходный шрифт, который будет заменен
IFontData sourceFont = new FontData("SomeRareFont");

// Загружает новый шрифт
IFontData destFont = new FontData("Arial");

// Добавляет правило шрифта для замены шрифта
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Добавляет правило в коллекцию правил замены шрифтов
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Добавляет коллекцию правил шрифтов в список правил
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

Bitmap bmp = presentation.Slides[0].GetThumbnail(1f, 1f);

// Сохраняет изображение на диск в формате JPEG
bmp.Save("Thumbnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Возможно, вам будет интересно посмотреть [**Замена шрифтов**](/slides/net/font-replacement/). 

{{% /alert %}}