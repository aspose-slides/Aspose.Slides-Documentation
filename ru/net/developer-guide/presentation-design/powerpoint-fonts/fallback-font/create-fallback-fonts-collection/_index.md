---
title: Создание коллекции шрифтов резервирования
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Коллекция шрифтов резервирования, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Коллекция шрифтов резервирования в PowerPoint на C# или .NET"
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection). Можно добавлять или удалять правила из коллекции.

Затем эта коллекция может быть назначена свойству [FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)класса [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager). FontsManager управляет шрифтами в презентации. Читать далее [О FontsManager и FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Каждая [Презентация ](https://reference.aspose.com/slides/net/aspose.slides/presentation)имеет свойство [FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)с собственным экземпляром класса FontsManager.

Вот пример того, как создать коллекцию правил резервирования шрифтов и назначить ее в FontsManager определенной презентации:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

После инициализации FontsManager с коллекцией шрифтов резервирования, шрифты резервирования применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Читать далее, как [Отрисовать презентацию с резервным шрифтом](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}