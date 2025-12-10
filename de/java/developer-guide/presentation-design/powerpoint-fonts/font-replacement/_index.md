---
title: Optimieren Sie den Austausch von Schriftarten in Präsentationen mit Java
linktitle: Schriftart-Austausch
type: docs
weight: 60
url: /de/java/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Austausch
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Ersetzen Sie Schriftarten in Aspose.Slides für Java nahtlos, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich der Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Instanzen der alten Schriftart werden durch die neue Schriftart ersetzt. 

Aspose.Slides ermöglicht das Ersetzen einer Schriftart wie folgt:

1. Laden Sie die relevante Präsentation. 
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart. 
4. Ersetzen Sie die Schriftart. 
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java‑Code demonstriert das Ersetzen von Schriftarten:
```java
// Lädt eine Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Lädt die Quellschriftart, die ersetzt wird
    IFontData sourceFont = new FontData("Arial");
    
    // Lädt die neue Schriftart
    IFontData destFont = new FontData("Times New Roman");
    
    // Ersetzt die Schriftarten
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Speichert die Präsentation
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn eine Schriftart nicht zugänglich ist), siehe [**Font Substitution**](/slides/de/java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftart ersetzen“, „Schriftart substituieren“ und „Fallback‑Schriftarten“?**

Ersetzen ist ein absichtlicher Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/java/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/java/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basis­schriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird das Ersetzen auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Das Ersetzen wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare gehören ebenfalls zum Dokument und werden vom Schriftart‑Engine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE content](/slides/de/java/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Das Ersetzen in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezieltes Ersetzen ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt ein globales Ersetzen für das gesamte Dokument anzuwenden. Die Gesamt‑Logik zur Schriftartauswahl während des Renderings bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den Präsentations‑[font manager](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/): er liefert eine Liste der [families in use](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getFonts--) und Informationen zu [substitutions/"unknown" fonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getSubstitutions--), was die Planung des Ersetzens erleichtert.

**Funktioniert das Ersetzen von Schriftarten beim Konvertieren zu PDF/Bildern?**

Ja. Beim Export wendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/java/font-selection-sequence/) an, sodass ein vorher durchgeführtes Ersetzen während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel‑schriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [loading external fonts](/slides/de/java/custom-font/) aus Benutzerordnern für die Verwendung während [rendering and export](/slides/de/java/convert-powerpoint/).

**Wird das Ersetzen „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Ziel‑schriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [configure fallback](/slides/de/java/fallback-font/) zur Abdeckung der fehlenden Zeichen.