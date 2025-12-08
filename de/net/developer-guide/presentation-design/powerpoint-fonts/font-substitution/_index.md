---
title: Schriftart-Substitution - PowerPoint C# API
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: Die C# PowerPoint API ermöglicht das Ersetzen von Schriftarten in Präsentationen
---

## **Abrufen von Font Substitution**

Um Ihnen zu ermöglichen, die während eines Präsentationsrenderings ersetzten Präsentationsschriftarten zu ermitteln, stellt Aspose.Slides die Methode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) des Interfaces [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) bereit.

Der C#‑Code zeigt, wie Sie alle Schriftart‑Substitutionen abrufen können, die beim Rendern einer Präsentation durchgeführt werden:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```



## **Festlegen von Font Substitution Rules**

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist, auf folgende Weise:

1. Laden Sie die entsprechende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für die Ersetzung hinzu.
5. Fügen Sie die Regel der Sammlung von Schriftart‑Ersetzungsregeln der Präsentation hinzu.
6. Erzeugen Sie das Folienbild, um den Effekt zu beobachten.

Dieser C#‑Code demonstriert den Schriftart‑Substitutionsvorgang:
```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt wird
IFontData sourceFont = new FontData("SomeRareFont");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Arial");

// Fügt eine Schriftartregel für die Schriftart-Ersetzung hinzu
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Fügt die Regel zur Sammlung von Schriftart-Substitutionsregeln hinzu
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Fügt die Sammlung von Schriftartregeln zur Regel-Liste hinzu
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Speichert das Bild im JPEG-Format auf die Festplatte
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vielleicht möchten Sie [**Font Replacement**](/slides/de/net/font-replacement/) sehen. 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Replacement](/slides/de/net/font-replacement/) ist ein erzwungenes Ersetzen einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann wird eine festgelegte Ersatzschriftart verwendet.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der standardmäßigen [font selection](/slides/de/net/font-selection-sequence/)-Sequenz teil, die beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird eine Ersetzung oder Substitution angewendet.

**Was ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten liegende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit hinzufügen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [add external fonts](/slides/de/net/custom-font/) hinzufügen, sodass die Bibliothek sie für die Auswahl und das Rendern berücksichtigt, auch für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schriftartenerkennung beginnt in den Schriftordnern des Betriebssystems. Die Menge der standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartensatz über Maschinen oder Container hinweg, [add the external fonts](/slides/de/net/custom-font/) für die Ausgabedokumente hinzufügen und nach Möglichkeit [embed fonts](/slides/de/net/embedded-font/) in Präsentationen einbetten, damit die ausgewählten Schriftarten beim Rendern verfügbar sind.