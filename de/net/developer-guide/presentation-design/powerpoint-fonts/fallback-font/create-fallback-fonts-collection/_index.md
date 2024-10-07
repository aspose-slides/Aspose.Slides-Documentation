---
title: Erstellen einer Fallback-Schriftarten-Sammlung
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Fallback-Schriftarten-Sammlung, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fallback-Schriftarten-Sammlung in PowerPoint in C# oder .NET"
---

Instanzen der [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) Klasse können in der [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) organisiert werden, die das [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) Interface implementiert. Es ist möglich, Regeln zur Sammlung hinzuzufügen oder zu entfernen.

Diese Sammlung kann dann der [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) Eigenschaft der [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) Klasse zugewiesen werden. FontsManager steuert die Schriftarten in der Präsentation. Erfahren Sie mehr [Über FontsManager und FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Jede [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) hat eine [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager) Eigenschaft mit seiner eigenen Instanz der FontsManager-Klasse.

Hier ist ein Beispiel, wie man eine Fallback-Schriftarten-Regelsammlung erstellt und diese in den FontsManager einer bestimmten Präsentation zuweist:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Nachdem der FontsManager mit der Fallback-Schriftarten-Sammlung initialisiert wurde, werden die Fallback-Schriftarten während der Präsentationsgerendering angewendet.

{{% alert color="primary" %}} 
Erfahren Sie mehr darüber, wie Sie eine [Präsentation mit Fallback-Schriftart rendern](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}