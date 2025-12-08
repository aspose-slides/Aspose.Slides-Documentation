---
title: Schriftart-Substitution - PowerPoint JavaScript-API
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/nodejs-java/font-substitution/
keywords: "Schriftart, ersetzende Schriftart, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Schriftart in PowerPoint mit JavaScript ersetzen"
---

## **Schriftart‑Ersetzungsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Schriftartregeln, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist, auf folgende Weise:

1. Laden Sie die relevante Präsentation.
2. Laden Sie die zu ersetzende Schriftart.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel der Sammlung von Schriftart‑Ersatzregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um die Wirkung zu beobachten.

Dieser JavaScript‑Code demonstriert den Schriftart‑Substitutionsprozess:
```javascript
// Lädt eine Präsentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt werden soll
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Lädt die neue Schriftart
    var destFont = new aspose.slides.FontData("Arial");
    // Fügt eine Schriftartregel für den Schriftart-Ersatz hinzu
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Fügt die Regel zur Sammlung von Schriftart-Ersetzungsregeln hinzu
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Fügt eine Schriftartregel-Sammlung zur Regel-Liste hinzu
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Speichert das Bild auf die Festplatte im JPEG-Format
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Vielleicht möchten Sie sich [**Schriftart‑Ersatz**](/slides/de/nodejs-java/font-replacement/) ansehen.
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersatz und Schriftart‑Substitution?**

[Replacement](/slides/de/nodejs-java/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die Originalschriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am standardmäßigen [Schriftartauswahl](/slides/de/nodejs-java/font-selection-sequence/) Ablauf teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersatz oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersatz noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten liegende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [externe Schriftarten hinzufügen](/slides/de/nodejs-java/custom-font/) so dass die Bibliothek sie für Auswahl und Rendering berücksichtigt, einschließlich späterer Konvertierungen.

**Verteilt Aspose Schriftarten mit der Bibliothek?**

Nein. Aspose stellt keine kostenpflichtigen oder kostenlosen Schriftarten bereit; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schriftartenerkennung beginnt in den Schriftverzeichnissen des Betriebssystems. Die Menge der standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartenbestand über Maschinen oder Container hinweg, [externe Schriftarten hinzufügen](/slides/de/nodejs-java/custom-font/) die für die Ausgabedokumente erforderlich sind, und [Schriftarten einbetten](/slides/de/nodejs-java/embedded-font/) in Präsentationen, sofern möglich, damit die ausgewählten Schriftarten während des Renderings verfügbar sind.