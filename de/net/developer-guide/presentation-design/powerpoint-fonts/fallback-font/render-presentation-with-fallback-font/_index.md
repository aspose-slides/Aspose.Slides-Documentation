---
title: Präsentationen mit Fallback-Schriftarten in .NET rendern
linktitle: Präsentationen rendern
type: docs
weight: 30
url: /de/net/render-presentation-with-fallback-font/
keywords:
- Fallback-Schriftart
- PowerPoint rendern
- Präsentation rendern
- Folie rendern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Rendern von Präsentationen mit Fallback-Schriftarten in Aspose.Slides für .NET – gewährleisten einer konsistenten Textdarstellung in PPT, PPTX und ODP mit schrittweisen C#-Beispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [erstellen die Fallback-Schriftart-Regelsammlung](/slides/de/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) eine Fallback-Schriftart-Regel und [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einer anderen Regel.
1. Setzen Sie die Regelsammlung auf die [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) Eigenschaft.
1. Mit der [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) Methode können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Fallback-Schriftart-Regelsammlung dem FontsManager zugewiesen wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.
```c#
// Neue Instanz einer Regelsammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Eine Anzahl von Regeln erstellen
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
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

    // Rendern einer Miniatur mit der initialisierten Regelsammlung und Speichern als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```



{{% alert color="primary" %}} 
Erfahren Sie mehr über [Speichern und Konvertieren in Presentation](/slides/de/net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}