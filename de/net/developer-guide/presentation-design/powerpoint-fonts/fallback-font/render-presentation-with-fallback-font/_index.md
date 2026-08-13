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
- Folien rendern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Rendern Sie Präsentationen mit Fallback-Schriftarten in Aspose.Slides für .NET - halten Sie den Text über PPT, PPTX und ODP hinweg konsistent mit schrittweisen C#-Codebeispielen."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Präsentationen mit Fallback‑Schriftartenregeln zu rendern. Dieser Artikel zeigt, wie Sie eine Sammlung von Fallback‑Schriftartenregeln erstellen, deren Regeln durch Entfernen oder Hinzufügen von Fallback‑Schriften ändern und die Sammlung der Eigenschaft `FontsManager.FontFallBackRulesCollection` zuweisen.

Sobald die Sammlung von Fallback‑Schriftartenregeln dem `FontsManager` der Präsentation zugewiesen ist, werden die Regeln bei Vorgängen wie Speichern, Rendern und Konvertieren der Präsentation angewendet. Das Beispiel demonstriert, wie die konfigurierten Regeln beim Rendern einer Folien‑Vorschau und beim Speichern als PNG‑Bild verwendet werden.

## **Rendern einer Folie mit Fallback‑Schriftartenregeln**

Das folgende Beispiel umfasst diese Schritte:

1. Wir [erstellen eine Sammlung von Fallback‑Schriftartenregeln](/slides/de/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrule/methods/remove) eine Fallback‑Schriftartenregel und [AddFallBackFonts()](https://reference.aspose.com/slides/de/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) zu einer anderen Regel hinzufügen.
1. Setzen Sie die Regelsammlung auf die Eigenschaft [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Mit der Methode [Presentation.Save()](https://reference.aspose.com/slides/de/net/aspose.slides.presentation/save/methods/4) können wir die Präsentation im selben Format speichern oder in ein anderes Format konvertieren. Nachdem die Sammlung von Fallback‑Schriftartenregeln dem FontsManager zugewiesen wurde, werden diese Regeln bei allen Vorgängen an der Präsentation angewendet: Speichern, Rendern, Konvertieren usw.

```c#
using Aspose.Slides;

// Neue Instanz einer Regelsammlung erstellen
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Versuchen, die Fallback-Schriftart "Tahoma" aus den geladenen Regeln zu entfernen
	fallBackRule.Remove("Tahoma");

	//Und die Regeln für den angegebenen Bereich aktualisieren
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Wir können auch vorhandene Regeln aus der Liste entfernen, wobei mindestens eine Regel zum Rendern erhalten bleibt
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Zuweisen einer vorbereiteten Regel-Liste zur Verwendung
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    //Rendern der Miniaturansicht unter Verwendung der initialisierten Regelsammlung und Speichern als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Erfahren Sie mehr über [Speichern und Konvertieren in Präsentationen](/slides/de/net/convert-powerpoint-to-png/).
{{% /alert %}}