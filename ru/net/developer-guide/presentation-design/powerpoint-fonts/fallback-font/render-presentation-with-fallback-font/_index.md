---
title: Отображение презентации с резервным шрифтом
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
keywords: "Резервный шрифт, отображение PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Отображение PowerPoint с резервным шрифтом на C# или .NET"
---

Следующий пример включает в себя эти шаги:

1. Мы [создаем коллекцию правил резервных шрифтов](/slides/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) правило резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) к другому правилу.
1. Устанавливаем коллекцию правил в свойство [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) мы можем сохранить презентацию в том же формате или сохранить ее в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются во время любых операций с презентацией: сохранение, отображение, конвертация и т.д.

```c#
// Создаем новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// создаем ряд правил
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
	fallBackRule.Remove("Tahoma");

	// И обновить правила для указанного диапазона
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Также мы можем удалить любые существующие правила из списка
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
	// Назначение подготовленного списка правил для использования
	pres.FontsManager.FontFallBackRulesCollection = rulesList;

	// Отображение миниатюры с использованием инициализированной коллекции правил и сохранение в PNG
	pres.Slides[0].GetThumbnail(1f, 1f).Save("Slide_0.png", ImageFormat.Png);
}
```

{{% alert color="primary" %}} 
Читайте больше о [Сохранении и Конвертации в Презентации](/slides/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}