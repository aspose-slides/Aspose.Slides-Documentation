---
title: Schriftersetzung in Präsentationen auf Android optimieren
linktitle: Schriftersetzung
type: docs
weight: 60
url: /de/androidjava/font-replacement/
keywords:
- Schrift
- Schrift ersetzen
- Schriftersetzung
- Schrift ändern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Ersetzen Sie Schriftarten in Aspose.Slides für Android nahtlos mit Java, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---

## **Schriften ersetzen**

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt. 

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf folgende Weise zu ersetzen:

1. Laden Sie die entsprechende Präsentation. 
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart. 
4. Ersetzen Sie die Schriftart. 
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert das Ersetzen von Schriftarten:
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


{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn eine Schriftart nicht zugänglich ist), siehe [**Font Substitution**](/slides/de/androidjava/font-substitution/).

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „font replacement“, „font substitution“ und „fallback fonts“?**

Ersetzen ist ein absichtlicher Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/androidjava/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/androidjava/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basis‑Schriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird das Ersetzen auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Das Ersetzen wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schrift‑Engine berücksichtigt.

**Wird die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel) geändert?**

Nein. [OLE content](/slides/de/androidjava/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Ein Ersetzen in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezieltes Ersetzen ist möglich, wenn Sie die Schriftart auf Ebene der gewünschten Objekte/Bereiche ändern, anstatt ein globales Ersetzen für das gesamte Dokument anzuwenden. Die übergeordnete Logik zur Schriftauswahl beim Rendern bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [font manager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/): Er liefert eine Liste der [families in use](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) und Informationen über [substitutions/"unknown" fonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), was die Planung des Ersetzens erleichtert.

**Funktioniert das Ersetzen von Schriftarten beim Konvertieren in PDF/Bilder?**

Ja. Beim Export verwendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/androidjava/font-selection-sequence/), sodass ein vorher durchgeführtes Ersetzen während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [loading external fonts](/slides/de/androidjava/custom-font/) aus Benutzerordnern für die Verwendung beim [rendering and export](/slides/de/androidjava/convert-powerpoint/).

**Wird das Ersetzen „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [configure fallback](/slides/de/androidjava/fallback-font/) um die fehlenden Zeichen abzudecken.