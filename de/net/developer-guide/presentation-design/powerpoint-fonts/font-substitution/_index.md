---
title: Schriftarten‑Substitution in Präsentationen in .NET konfigurieren
linktitle: Schriftarten‑Substitution
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart‑Substitution
- Schriftart ersetzen
- Schriftart‑Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Optimale Schriftart‑Substitution in Aspose.Slides für .NET ermöglichen, wenn PowerPoint‑ und OpenDocument‑Präsentationen in andere Dateiformate konvertiert werden."
---

## **Font‑Ersetzungen abrufen**

Um die während des Renderns einer Präsentation ersetzten Präsentations‑Fonts herauszufinden, stellt Aspose.Slides die Methode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) vom Interface [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) bereit.

Der C#‑Code zeigt, wie Sie alle Font‑Ersetzungen erhalten, die beim Rendern einer Präsentation durchgeführt werden:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```



## **Font‑Ersetzungsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Regeln für Fonts, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn ein Font nicht verfügbar ist) zu tun ist:

1. Laden Sie die betreffende Präsentation.
2. Laden Sie den Font, der ersetzt werden soll.
3. Laden Sie den neuen Font.
4. Fügen Sie eine Regel für die Ersetzung hinzu.
5. Fügen Sie die Regel der Sammlung von Font‑Ersetzungsregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser C#‑Code demonstriert den Font‑Ersetzungsprozess:
```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt wird
IFontData sourceFont = new FontData("SomeRareFont");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Arial");

// Fügt eine Schriftartregel für die Ersetzung hinzu
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Fügt die Regel zur Sammlung von Schriftart-Substitutionsregeln hinzu
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Fügt die Schriftartregel-Sammlung zur Regel-Liste hinzu
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

[Replacement](/slides/de/net/font-replacement/) ist ein erzwungenes Ersetzen eines Fonts durch einen anderen in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn der ursprüngliche Font nicht verfügbar ist, und dann ein festgelegter Ersatz‑Font verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der standardmäßigen [font selection](/slides/de/net/font-selection-sequence/)‑Sequenz teil, die beim Laden, Rendern und Konvertieren ausgewertet wird; ist der ausgewählte Font nicht verfügbar, wird eine Ersetzung oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und der Font im System fehlt?**

Die Bibliothek versucht, den am nächsten liegenden verfügbaren System‑Font zu wählen, ähnlich dem Verhalten von PowerPoint.

**Kann ich benutzerdefinierte externe Fonts zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [externe Fonts hinzufügen](/slides/de/net/custom-font/) sodass die Bibliothek sie bei Auswahl und Rendering berücksichtigt, auch für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Fonts mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Fonts; Sie fügen Fonts nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Font‑Erkennung beginnt in den Font‑Verzeichnissen des Betriebssystems. Die Menge der standardmäßig verfügbaren Fonts und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Stapelkonvertierungen zu minimieren?**

Synchronisieren Sie den Font‑Satz über Maschinen oder Container hinweg, [externe Fonts hinzufügen](/slides/de/net/custom-font/) für die Ausgabedokumente und, wenn möglich, [Fonts einbetten](/slides/de/net/embedded-font/) in Präsentationen, damit die ausgewählten Fonts während des Renderings verfügbar sind.