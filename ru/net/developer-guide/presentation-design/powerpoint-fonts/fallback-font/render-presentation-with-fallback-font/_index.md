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
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для .NET - сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на C#."
---

В следующем примере приведены следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) резервное правило шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) к другому правилу.
1. Устанавливаем коллекцию правил в свойство [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```c#
// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Trying to remove FallBack font "Tahoma" from loaded rules
	fallBackRule.Remove("Tahoma");

	//And to update of rules for specified range
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Assigning a prepared rules list for using
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering of thumbnail with using of initialized rules collection and saving to PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```



{{% alert color="primary" %}} 
Подробнее о [Сохранении и конвертации в презентации](/slides/ru/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}