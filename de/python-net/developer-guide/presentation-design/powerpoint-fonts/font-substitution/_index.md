---
title: Schriftart-Substitution in Präsentationen mit Python konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/python-net/font-substitution/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Aktivieren Sie optimale Schriftart-Substitution in Aspose.Slides für Python über .NET beim Konvertieren von PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate."
---

## **Ersetzungsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen zu tun ist (z. B. wenn eine Schriftart nicht zugänglich ist) wie folgt:

1. Laden Sie die betreffende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel zur Sammlung von Präsentations‑Schriftart‑Ersetzungsregeln hinzu.
6. Generieren Sie das Folien‑Bild, um die Wirkung zu beobachten.

Dieses Python‑Beispiel demonstriert den Schriftart‑Ersetzungsprozess:

```python
import aspose.slides as slides

# Lädt eine Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die Quellschriftart, die ersetzt werden soll
    sourceFont = slides.FontData("SomeRareFont")

    # Lädt die neue Schriftart
    destFont = slides.FontData("Arial")

    # Fügt eine Schriftartregel für die Schriftersetzung hinzu
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Fügt die Regel zur Sammlung der Schriftart‑Austauschregeln hinzu
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Fügt die Schriftartregelsammlung zur Regeliste hinzu
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Arial‑Schrift wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Speichert das Bild im JPEG‑Format auf die Festplatte
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%alert title="HINWEIS" color="warning"%}} 
Sie möchten vielleicht [**Schriftart‑Ersetzung**](/slides/de/python-net/font-replacement/) sehen. 
{{%/alert%}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Ersetzung](/slides/de/python-net/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, z. B. wenn die Originalschriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am Standard‑[Schriftartauswahl](/slides/de/python-net/font-selection-sequence/)-Prozess teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten liegende verfügbare Systemschriftart zu wählen, ähnlich dem Verhalten von PowerPoint.

**Kann ich zur Laufzeit benutzerdefinierte externe Schriftarten anhängen, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten hinzufügen](/slides/de/python-net/custom-font/) zur Laufzeit, sodass die Bibliothek sie bei Auswahl und Rendering berücksichtigt, einschließlich für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder freien Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schriftarterkennung beginnt in den Schriftarten‑Verzeichnissen des Betriebssystems. Die Menge der standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich plattformabhängig, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Stapelkonvertierungen zu minimieren?**

Synchronisieren Sie das Schriftartenset über Maschinen oder Container hinweg, [fügen Sie die externen Schriftarten](/slides/de/python-net/custom-font/) hinzu, die für die Ausgabedokumente erforderlich sind, und [betten Sie Schriftarten](/slides/de/python-net/embedded-font/) in Präsentationen ein, wenn möglich, sodass die gewählten Schriftarten beim Rendern verfügbar sind.