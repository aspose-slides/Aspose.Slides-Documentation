---
title: Schriftart-Substitution in Präsentationen mit Java konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Aktivieren Sie die optimale Schriftart-Substitution in Aspose.Slides für Java beim Konvertieren von PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate."
---

## **Schriftart-Substitutionsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist, und zwar wie folgt:

1. Laden Sie die betreffende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für den Ersatz hinzu.
5. Fügen Sie die Regel der Sammlung von Schriftart‑Ersatzregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um die Wirkung zu beobachten.

Dieser Java‑Code demonstriert den Schriftart‑Substitutionsprozess:
```java
// Lädt eine Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt wird
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Lädt die neue Schriftart
    IFontData destFont = new FontData("Arial");
    
    // Fügt eine Schriftartregel für die Schriftart-Ersetzung hinzu
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Fügt die Regel zur Sammlung von Schriftart-Substitutionsregeln hinzu
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Fügt eine Schriftartregel-Sammlung zur Regel-Liste hinzu
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Die Schriftart Arial wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Speichert das Bild auf die Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```



{{%  alert title="NOTE"  color="warning"   %}} 

Vielleicht möchten Sie sich [**Font Replacement**](/slides/de/java/font-replacement/) ansehen. 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Replacement](/slides/de/java/font-replacement/) ist ein erzwungenes Ersetzen einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann wird eine festgelegte Ersatzschriftart verwendet.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen an der standardmäßigen [Schriftauswahl](/slides/de/java/font-selection-sequence/) Sequenz teil, die beim Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten passende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können [externe Schriftarten hinzufügen](/slides/de/java/custom-font/) zur Laufzeit, sodass die Bibliothek sie für die Auswahl und das Rendern berücksichtigt, einschließlich für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schrifterkennung beginnt in den Schriftverzeichnissen des Betriebssystems. Der Satz standardmäßig verfügbarer Schriftarten und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartensatz über Maschinen oder Container hinweg, [externe Schriftarten hinzufügen](/slides/de/java/custom-font/) die für die Ausgabedokumente erforderlich sind, und [Schriftarten einbetten](/slides/de/java/embedded-font/) in Präsentationen, wenn möglich, damit die ausgewählten Schriftarten während des Renderns verfügbar sind.