---
title: Vereinfachen Sie die Schriftarten-Ersetzung in Präsentationen mit PHP
linktitle: Schriftarten-Ersetzung
type: docs
weight: 60
url: /de/php-java/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftarten-Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Ersetzen Sie Schriftarten in Aspose.Slides für PHP nahtlos über Java, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen sicherzustellen."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich der Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die relevante Präsentation.  
2. Laden Sie die Schriftart, die ersetzt werden soll.  
3. Laden Sie die neue Schriftart.  
4. Ersetzen Sie die Schriftart.  
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP‑Code demonstriert das Ersetzen von Schriftarten:
```php
  # Lädt eine Präsentation
  # Lädt die Quellschriftart, die ersetzt werden soll
  # Lädt die neue Schriftart
  # Ersetzt die Schriftarten
  # Speichert die Präsentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Loads the source font that will be replaced
    $sourceFont = new FontData("Arial");
    # Loads the new font
    $destFont = new FontData("Times New Roman");
    # Replaces the fonts
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Saves the presentation
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn eine Schriftart nicht zugänglich ist), siehe [**Font Substitution**](/slides/de/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftarten‑Ersetzung“, „Schriftarten‑Substitution“ und „Fallback‑Schriftarten“?**

Ersetzung ist ein gezielter Wechsel von einer Schriftfamilie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/php-java/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/php-java/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basisschriftart installiert ist, aber nicht die erforderlichen Zeichen enthält.

**Wird die Ersetzung auf Masterfolien, Layouts, Notizen und Kommentare angewendet?**

Ja. Die Ersetzung wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Masterfolien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schriftengine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE content](/slides/de/php-java/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der benötigten Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die Gesamtlösung für die Schriftartauswahl während des Renderns bleibt unverändert.

**Wie kann ich im Voraus feststellen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [Font‑Manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) und Informationen zu [Substitutionen/\"unknown\"‑Schriftarten](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/), die bei der Planung der Ersetzung helfen.

**Funktioniert die Schriftarten‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/php-java/font-selection-sequence/) an, sodass eine vorher durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschriftart im System installieren, oder kann ich einen Schriftartenordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/php-java/custom-font/) aus Benutzerordnern für die Nutzung während des [Renderns und Exports](/slides/de/php-java/convert-powerpoint/).

**Wird die Ersetzung „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [Fallback konfigurieren](/slides/de/php-java/fallback-font/), um die fehlenden Zeichen abzudecken.