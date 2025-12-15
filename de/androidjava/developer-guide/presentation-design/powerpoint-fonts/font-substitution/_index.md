---
title: Schriftart-Substitution in Präsentationen für Android konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Aktivieren Sie die optimale Schriftart-Substitution in Aspose.Slides für Android via Java beim Konvertieren von PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate."
---

## **Schriftart‑Ersetzungsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn eine Schriftart nicht zugänglich ist) zu tun ist, auf folgende Weise:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die Schriftart, die ersetzt werden soll.  
3. Laden Sie die neue Schriftart.  
4. Fügen Sie eine Regel für den Austausch hinzu.  
5. Fügen Sie die Regel zur Sammlung von Schriftart‑Ersetzungsregeln der Präsentation hinzu.  
6. Erzeugen Sie das Folienbild, um den Effekt zu beobachten.

Dieser Java‑Code demonstriert den Prozess der Schriftart‑Ersetzung:
```java
// Lädt eine Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt wird
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Lädt die neue Schriftart
    IFontData destFont = new FontData("Arial");
    
    // Fügt eine Schriftartregel für die Ersetzung hinzu
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Fügt die Regel zur Sammlung von Schriftart-Ersetzungsregeln hinzu
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Fügt eine Schriftartregel‑Sammlung zur Regel­liste hinzu
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Die Schriftart Arial wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Speichert das Bild auf der Festplatte im JPEG-Format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="HINWEIS"  color="warning"   %}} 

Vielleicht möchten Sie sich [**Schriftart‑Ersetzung**](/slides/de/androidjava/font-replacement/) ansehen.

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Ersetzung](/slides/de/androidjava/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die ursprüngliche Schriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am regulären [Schriftart‑Auswahl](/slides/de/androidjava/font-selection-sequence/)‑Prozess teil, der beim Laden, Rendern und Konvertieren ausgewertet wird; ist die ausgewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Wie ist das Standardverhalten, wenn weder Ersetzung noch Substitution konfiguriert ist und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am besten passende Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [externe Schriftarten](/slides/de/androidjava/custom-font/) hinzufügen, sodass die Bibliothek sie für die Auswahl und das Rendern berücksichtigt, auch für nachfolgende Konvertierungen.

**Verteilt Aspose irgendwelche Schriftarten mit der Bibliothek?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schriftarterkennung beginnt in den Schriftartenverzeichnissen des Betriebssystems. Der Satz an standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich je nach Plattform, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie den Schriftartenbestand über Maschinen oder Container hinweg, [fügen Sie die externen Schriftarten](/slides/de/androidjava/custom-font/) hinzu, die für die Ausgabedokumente erforderlich sind, und [betten Sie Schriftarten](/slides/de/androidjava/embedded-font/) in Präsentationen ein, wenn möglich, damit die gewünschten Schriftarten beim Rendern verfügbar sind.