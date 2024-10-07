---
title: Präsentation mit Fallback-Schriftart rendern
type: docs
weight: 30
url: /net/render-presentation-with-fallback-font/
keywords: 
- Fallback-Schriftart
- PowerPoint rendern
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "PowerPoint mit Fallback-Schriftart in C# oder .NET rendern"
---

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback-Schriftartregeln](/slides/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) eine Fallback-Schriftartregel und [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einer anderen Regel hinzufügen.
1. Die Regel-Sammlung der [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) Eigenschaft zuweisen.
1. Mit der Methode [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) können wir die Präsentation im selben Format speichern oder in einem anderen speichern. Nachdem die Fallback-Schriftartregeln-Sammlung dem FontsManager zugewiesen wurde, werden diese Regeln während aller Operationen über die Präsentation angewendet: speichern, rendern, konvertieren usw.

```c#
// Neue Instanz einer Regel-Sammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Eine Anzahl von Regeln erstellen
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Versuch, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
	fallBackRule.Remove("Tahoma");

	// Und die Regeln für den angegebenen Bereich aktualisieren
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Wir können auch vorhandene Regeln aus der Liste entfernen
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Zuweisen einer vorbereiteten Regelliste zur Verwendung
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering des Thumbnails mit Verwendung der initialisierten Regelsammlung und speichern als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Erfahren Sie mehr über [Speichern und Konvertieren in Präsentation](/slides/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}