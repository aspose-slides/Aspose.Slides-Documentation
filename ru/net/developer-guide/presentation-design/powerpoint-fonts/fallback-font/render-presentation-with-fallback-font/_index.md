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
description: "Отображение презентаций с резервными шрифтами в Aspose.Slides для .NET – сохраняет единообразие текста в PPT, PPTX и ODP с пошаговыми примерами кода на C#."
---

В следующем примере содержатся следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) правило резервного шрифта и [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) к другому правилу.
3. Установите коллекцию правил в свойство [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. С помощью метода [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов установлена в FontsManager, эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```c#
// Создать новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
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

// Также можно удалить любые существующие правила из списка
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Назначаем подготовленный список правил для использования
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Рендерим миниатюру с использованием инициализированной коллекции правил и сохраняем в PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```



{{% alert color="primary" %}} 
Подробнее о [Save and Convertion in Presentation](/slides/ru/net/convert-powerpoint-to-png/).
{{% /alert %}}