---
title: Schriftart-Substitution in Präsentationen mit PHP konfigurieren
linktitle: Schriftart-Substitution
type: docs
weight: 70
url: /de/php-java/font-substitution/
keywords:
- Schriftart
- ersetzende Schriftart
- Schriftart-Substitution
- Schriftart ersetzen
- Schriftart-Ersetzung
- Substitutionsregel
- Ersetzungsregel
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Aktivieren Sie optimale Schriftart-Substitution in Aspose.Slides für PHP über Java beim Konvertieren von PowerPoint- und OpenDocument-Präsentationen in andere Dateiformate."
---

## **Schriftart‑Ersetzungsregeln festlegen**

Aspose.Slides ermöglicht das Festlegen von Regeln für Schriftarten, die bestimmen, was unter bestimmten Bedingungen (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann) zu tun ist:

1. Laden Sie die betreffende Präsentation.
2. Laden Sie die zu ersetzende Schriftart.
3. Laden Sie die neue Schriftart.
4. Fügen Sie eine Regel für die Ersetzung hinzu.
5. Fügen Sie die Regel der Sammlung von Schriftart‑Ersetzungsregeln der Präsentation hinzu.
6. Generieren Sie das Folienbild, um den Effekt zu beobachten.

Dieser PHP‑Code demonstriert den Prozess der Schriftart‑Substitution:
```php
  # Lädt eine Präsentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Lädt die Quellschriftart, die ersetzt werden soll
    $sourceFont = new FontData("SomeRareFont");
    # Lädt die neue Schriftart
    $destFont = new FontData("Arial");
    # Fügt eine Schriftartregel für die Ersetzung hinzu
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Fügt die Regel zur Sammlung von Schriftart-Ersetzungsregeln hinzu
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Fügt eine Schriftartregel-Sammlung zur Regel-Liste hinzu
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Arial-Schriftart wird anstelle von SomeRareFont verwendet, wenn Letztere nicht zugänglich ist
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Speichert das Bild auf die Festplatte im JPEG-Format
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="NOTE"  color="warning"   %}} 
Vielleicht möchten Sie [**Schriftart‑Ersetzung**](/slides/de/php-java/font-replacement/).
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen Schriftart‑Ersetzung und Schriftart‑Substitution?**

[Ersetzung](/slides/de/php-java/font-replacement/) ist ein erzwungenes Überschreiben einer Schriftart durch eine andere in der gesamten Präsentation. Substitution ist eine Regel, die unter einer bestimmten Bedingung ausgelöst wird, zum Beispiel wenn die originale Schriftart nicht verfügbar ist, und dann eine festgelegte Ersatzschriftart verwendet wird.

**Wann genau werden Substitutionsregeln angewendet?**

Die Regeln nehmen am normalen [Schriftauswahl](/slides/de/php-java/font-selection-sequence/)‑Ablauf teil, der während Laden, Rendern und Konvertieren ausgewertet wird; ist die gewählte Schriftart nicht verfügbar, wird Ersetzung oder Substitution angewendet.

**Welches Standardverhalten tritt ein, wenn weder Ersetzung noch Substitution konfiguriert sind und die Schriftart im System fehlt?**

Die Bibliothek versucht, die am nächsten liegende verfügbare Systemschriftart zu wählen, ähnlich wie PowerPoint es tun würde.

**Kann ich benutzerdefinierte externe Schriftarten zur Laufzeit anhängen, um Substitution zu vermeiden?**

Ja. Sie können zur Laufzeit [externe Schriftarten hinzufügen](/slides/de/php-java/custom-font/) hinzufügen, sodass die Bibliothek sie für die Auswahl und das Rendern berücksichtigt, auch für nachfolgende Konvertierungen.

**Stellt Aspose Schriftarten mit der Bibliothek bereit?**

Nein. Aspose verteilt keine kostenpflichtigen oder kostenlosen Schriftarten; Sie fügen Schriftarten nach eigenem Ermessen und Verantwortung hinzu und verwenden sie.

**Gibt es Unterschiede im Substitutionsverhalten unter Windows, Linux und macOS?**

Ja. Die Schriftartenerkennung beginnt in den Schriftartenordnern des Betriebssystems. Die Menge der standardmäßig verfügbaren Schriftarten und die Suchpfade unterscheiden sich plattformabhängig, was die Verfügbarkeit und den Bedarf an Substitution beeinflusst.

**Wie sollte ich die Umgebung vorbereiten, um unerwartete Substitutionen bei Batch‑Konvertierungen zu minimieren?**

Synchronisieren Sie das Schriftartenset über Maschinen oder Container hinweg, [externe Schriftarten hinzufügen](/slides/de/php-java/custom-font/) die für die Ausgabedokumente benötigt werden, und [Schriftarten einbetten](/slides/de/php-java/embedded-font/) in Präsentationen einbetten, wenn möglich, damit die ausgewählten Schriftarten beim Rendern verfügbar sind.