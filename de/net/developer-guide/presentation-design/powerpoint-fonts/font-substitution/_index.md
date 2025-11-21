---
title: Schriftart-Substitution in Präsentationen in .NET konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/net/font-substitution/
keywords:
- Schriftart
- Ersatzschriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Optimale Schriftart-Substitution in Aspose.Slides für .NET aktivieren, wenn PowerPoint‑ und OpenDocument‑Präsentationen in andere Dateiformate konvertiert werden."
---

## **Abrufen von Schriftarten-Substitution**

Damit Sie die während des Renderns einer Präsentation ersetzten Präsentations‑Schriftarten ermitteln können, stellt Aspose.Slides die Methode [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) aus dem Interface [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) bereit.

Der C#‑Code zeigt, wie Sie alle Schriftarten‑Substitutionen erhalten, die beim Rendern einer Präsentation durchgeführt werden:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```



## **Festlegen von Schriftarten‑Substitutionsregeln**

Aspose.Slides ermöglicht das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen geschehen soll (z. B. wenn eine Schriftart nicht zugänglich ist), wie folgt:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die Schriftart, die ersetzt werden soll.  
3. Laden Sie die neue Schriftart.  
4. Fügen Sie eine Regel für die Ersetzung hinzu.  
5. Fügen Sie die Regel der Sammlung von Schriftarten‑Ersetzungsregeln der Präsentation hinzu.  
6. Erzeugen Sie das Folien‑Bild, um die Wirkung zu beobachten.

Dieser C#‑Code demonstriert den Schriftarten‑Substitutionsprozess:
```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt werden soll
IFontData sourceFont = new FontData("SomeRareFont");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Arial");

// Fügt eine Schriftartregel für den Schriftersatz hinzu
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Fügt die Regel zur Sammlung von Schriftersatzregeln hinzu
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Fügt die Schriftersatzregelsammlung zur Regelliste hinzu
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Speichert das Bild im JPEG-Format auf der Festplatte
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Vielleicht möchten Sie sich [**Schriftersatz**](/slides/de/net/font-replacement/) ansehen. 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftersatz und Schriftarten‑Substitution?**

[Ersetzung](/slides/de/net/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die Originalschriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am Standard‑[Schriftauswahl](/slides/de/net/font-selection-sequence/)-Ablauf teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am besten passende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich zur Laufzeit benutzerdefinierte externe Schriftarten anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [externe Schriftarten hinzufügen](/slides/de/net/custom-font/), sodass die Bibliothek diese bei Auswahl und Rendering berücksichtigt, einschließlich bei nachfolgenden Konvertierungen.

**Liefert Aspose irgendwelche Schriftarten mit der Bibliothek aus?**

Nein. Aspose verteilt weder kostenpflichtige noch kostenlose Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schrifterkennung beginnt in den Schriftarten‑Verzeichnissen des jeweiligen Betriebssystems. Der Satz standardmäßig verfügbarer Schriftarten und die Suchpfade unterscheiden sich plattformabhängig, was die Verfügbarkeit und die Notwendigkeit von Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartensatz über Maschinen oder Container hinweg, [fügen Sie die externen Schriftarten](/slides/de/net/custom-font/) hinzu, die für die Ausgabedokumente benötigt werden, und betten Sie nach Möglichkeit [Schriftarten ein](/slides/de/net/embedded-font/) in Präsentationen ein, sodass die gewünschten Schriftarten beim Rendering verfügbar sind.