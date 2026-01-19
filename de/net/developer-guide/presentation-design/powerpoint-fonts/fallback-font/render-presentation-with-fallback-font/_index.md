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
description: "Präsentationen mit Fallback-Schriftarten in Aspose.Slides für .NET rendern – Text über PPT, PPTX und ODP hinweg konsistent halten mit Schritt-für-Schritt C# Code-Beispielen."
---

Das folgende Beispiel enthält diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback‑Schriftartenregeln](/slides/de/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) einer Fallback‑Schriftartregel und [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einer anderen Regel.
1. Setzen Sie die Regelsammlung auf die Eigenschaft [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Mit [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) können wir die Präsentation im selben Format speichern oder in einem anderen Format. Nachdem die Fallback‑Schriftartenregelsammlung auf FontsManager gesetzt wurde, werden diese Regeln bei allen Vorgängen mit der Präsentation angewendet: speichern, rendern, konvertieren usw.
```c#
// Neue Instanz einer Regelsammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Erstelle eine Anzahl von Regeln
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Versucht die Fallback-Schriftart "Tahoma" aus geladenen Regeln zu entfernen
	fallBackRule.Remove("Tahoma");

	// Und die Regeln für den angegebenen Bereich zu aktualisieren
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

    // Rendern eines Thumbnails unter Verwendung der initialisierten Regelsammlung und Speicherung als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
Lesen Sie mehr über [Speichern und Konvertierung in Präsentation](/slides/de/net/convert-powerpoint-to-png/).
{{% /alert %}}