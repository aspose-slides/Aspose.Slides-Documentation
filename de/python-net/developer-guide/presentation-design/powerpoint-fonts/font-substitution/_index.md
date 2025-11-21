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
description: "Aktivieren Sie optimale Schriftart-Substitution in Aspose.Slides für Python via .NET beim Konvertieren von PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate."
---

## **Substitutionsregeln festlegen**

Aspose.Slides ermöglicht es Ihnen, Regeln für Schriftarten festzulegen, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist, und das auf folgende Weise:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die zu ersetzende Schriftart.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel zur Sammlung der Schriftart‑Ersetzungsregeln der Präsentation hinzu.
6. Erzeugen Sie das Folienbild, um die Wirkung zu beobachten.

Dieser Python-Code demonstriert den Schriftart‑Substitutionsprozess:
```python
import aspose.slides as slides

# Lädt eine Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die Quellschriftart, die ersetzt werden soll
    sourceFont = slides.FontData("SomeRareFont")

    # Lädt die neue Schriftart
    destFont = slides.FontData("Arial")

    # Fügt eine Schriftartregel für den Ersatz hinzu
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Fügt die Regel zur Sammlung der Schriftart-Ersetzungsregeln hinzu
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Fügt die Schriftartregel‑sammlung zur Regel‑liste hinzu
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial-Schrift wird anstelle von SomeRareFont verwendet, wenn diese nicht zugänglich ist
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Speichert das Bild im JPEG-Format auf dem Datenträger
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


{{%  alert title="NOTE"  color="warning"   %}} 
Vielleicht möchten Sie sich [**Font Replacement**](/slides/de/python-net/font-replacement/) ansehen. 
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Font Replacement und Font Substitution?**

[Replacement](/slides/de/python-net/font-replacement/) ist ein erzwungener Ersatz einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am normalen [font selection](/slides/de/python-net/font-selection-sequence/)‑Ablauf teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird ein Ersatz oder eine Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersatz noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten liegende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [add external fonts](/slides/de/python-net/custom-font/) hinzufügen, sodass die Bibliothek sie bei der Auswahl und dem Rendering berücksichtigt, auch für nachfolgende Konvertierungen.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten selbst hinzu und verwenden sie nach eigenem Ermessen und Verantwortung.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schrifterkennung beginnt in den Schriftverzeichnissen des Betriebssystems. Die Menge der standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Satz an Schriftarten über Maschinen oder Container hinweg, [add the external fonts](/slides/de/python-net/custom-font/) für die Ausgabedokumente hinzufügen und nach Möglichkeit [embed fonts](/slides/de/python-net/embedded-font/) in Präsentationen einbetten, damit die gewünschten Schriftarten beim Rendern verfügbar sind.