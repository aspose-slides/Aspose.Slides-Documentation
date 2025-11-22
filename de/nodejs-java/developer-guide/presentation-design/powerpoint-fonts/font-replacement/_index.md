---
title: Schrift Ersetzung - PowerPoint JavaScript API
linktitle: Schrift Ersetzung
type: docs
weight: 60
url: /de/nodejs-java/font-replacement/
description: Erfahren Sie, wie Sie Schriftarten mit der expliziten Ersetzungsmethode in PowerPoint mithilfe der JavaScript-API ersetzen.
---

## **Schriften ersetzen**

Wenn Sie Ihre Meinung zur Verwendung einer Schrift ändern, können Sie diese Schrift durch eine andere Schrift ersetzen. Alle Vorkommen der alten Schrift werden durch die neue Schrift ersetzt. 

Aspose.Slides ermöglicht das Ersetzen einer Schrift auf folgende Weise:

1. Laden Sie die betreffende Präsentation. 
2. Laden Sie die Schrift, die ersetzt werden soll.
3. Laden Sie die neue Schrift. 
4. Ersetzen Sie die Schrift. 
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser JavaScript‑Code demonstriert das Ersetzen von Schriften:
```javascript
// Lädt eine Präsentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt wird
    var sourceFont = new aspose.slides.FontData("Arial");
    // Lädt die neue Schriftart
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Ersetzt die Schriftarten
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Speichert die Präsentation
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schrift nicht zugegriffen werden kann), siehe [**Font Substitution**](/slides/de/nodejs-java/font-substitution/).

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen "font replacement", "font substitution" und "fallback fonts"?**

Ersetzen ist ein absichtlicher Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/nodejs-java/font-substitution/) ist eine Regel wie „wenn die Schrift nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/nodejs-java/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basisschrift installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird das Ersetzen auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Das Ersetzen wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schrift verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schrift‑Engine berücksichtigt.

**Wird die Schrift innerhalb eingebetteter OLE‑Objekte (z. B. Excel) geändert?**

Nein. [OLE content](/slides/de/nodejs-java/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Das Ersetzen in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schrift nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Zielgerichtetes Ersetzen ist möglich, wenn Sie die Schrift auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt ein globales Ersetzen für das gesamte Dokument anzuwenden. Die allgemeine Logik zur Schriftauswahl während des Renderns bleibt unverändert.

**Wie kann ich im Voraus ermitteln, welche Schriften die Präsentation überhaupt verwendet?**

Verwenden Sie den [font manager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) der Präsentation: Er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/) und Informationen zu [Substitutionen/„unbekannten“ Schriften](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), was bei der Planung des Ersetzens hilft.

**Funktioniert das Ersetzen von Schriften beim Konvertieren zu PDF/Bildern?**

Ja. Beim Export wendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/nodejs-java/font-selection-sequence/) an, sodass ein im Voraus durchgeführtes Ersetzen während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschrift im System installieren, oder kann ich einen Schriftordner anhängen?**

Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [loading external fonts](/slides/de/nodejs-java/custom-font/) aus Benutzerordnern für die Verwendung während des [rendering and export](/slides/de/nodejs-java/convert-powerpoint/).

**Wird das Ersetzen „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschrift die erforderlichen Glyphen tatsächlich enthält. Andernfalls [configure fallback](/slides/de/nodejs-java/fallback-font/) zur Abdeckung der fehlenden Zeichen.