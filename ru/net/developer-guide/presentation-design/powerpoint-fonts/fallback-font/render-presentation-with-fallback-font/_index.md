---
title: Отображение презентаций с резервными шрифтами в .NET
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/net/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Отображение презентаций с резервными шрифтами в Aspose.Slides для .NET – сохраняйте единообразие текста в PPT, PPTX и ODP с помощью пошаговых примеров кода на C#."
---
## **Обзор**

Aspose.Slides позволяет рендерить презентации, используя правила резервных шрифтов. Эта статья показывает, как создать коллекцию правил резервных шрифтов, изменить её правила, удаляя или добавляя резервные шрифты, и назначить коллекцию свойству `FontsManager.FontFallBackRulesCollection`.

После того как коллекция правил резервных шрифтов назначена `FontsManager` презентации, правила применяются во время таких операций, как сохранение, рендеринг и конвертация презентации. Пример демонстрирует, как использовать сконфигурированные правила при рендеринге миниатюры слайда и сохранении её как PNG‑изображения.

## **Отображение слайда с использованием правил резервных шрифтов**

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/net/create-fallback-fonts-collection/).
2. Вызываем [Remove()](https://reference.aspose.com/slides/ru/net/aspose.slides/fontfallbackrule/methods/remove) для правила резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/ru/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) для другого правила.
3. Устанавливаем коллекцию правил в свойство [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/ru/net/aspose.slides.presentation/save/methods/4) можно сохранить презентацию в том же формате или в другом. После установки коллекции правил резервных шрифтов в FontsManager, эти правила применяются при любых операциях над презентацией: сохранение, рендеринг, конвертация и т.д.

```c#
using Aspose.Slides;

// Создать новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// создать несколько правил
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Trying to remove FallBack font "Tahoma" from loaded rules
	//And to update of rules for specified range
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list, keeping at least one rule to render with
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Назначение подготовленного списка правил для использования
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    //Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Подробнее о [Сохранении и конвертации в презентации](/slides/ru/net/convert-powerpoint-to-png/).
{{% /alert %}}