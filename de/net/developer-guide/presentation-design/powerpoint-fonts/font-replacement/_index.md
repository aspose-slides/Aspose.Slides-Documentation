---
title: Schriftarten-Ersetzung in Präsentationen in .NET optimieren
linktitle: Schriftart-Ersetzung
type: docs
weight: 60
url: /de/net/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Schriftarten nahtlos in Aspose.Slides für .NET ersetzen, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung über die Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die entsprechende Präsentation.
2. Laden Sie die Schriftart, die ersetzt werden soll.
3. Laden Sie die neue Schriftart.
4. Ersetzen Sie die Schriftart.
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert das Ersetzen von Schriftarten:
```c#
// Lädt eine Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die Quellschriftart, die ersetzt wird
IFontData sourceFont = new FontData("Arial");

// Lädt die neue Schriftart
IFontData destFont = new FontData("Times New Roman");

// Ersetzt die Schriftarten
presentation.FontsManager.ReplaceFont(sourceFont, destFont");

// Speichert die Präsentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Font Substitution**](/slides/de/net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen "font replacement", "font substitution" und "fallback fonts"?**

Ersetzung ist ein absichtlicher Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/net/font-substitution/) ist eine Regel wie "if the font is unavailable, use X." [Fallback](/slides/de/net/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basis‑Schriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird die Ersetzung auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Ersetzung wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schriftengine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE content](/slides/de/net/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie kann als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die Gesamtheit der Schriftartauswahl‑Logik beim Rendern bleibt unverändert.

**Wie kann ich im Voraus ermitteln, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [font manager] der Präsentation (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/): Er liefert eine Liste der [families in use] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) und Informationen zu [substitutions/"unknown" fonts] (https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), was die Planung der Ersetzung erleichtert.

**Funktioniert die Schriftarten‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides dieselbe [font selection/substitution sequence](/slides/de/net/font-selection-sequence/) an, sodass eine vorherige Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel‑Schriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [loading external fonts](/slides/de/net/custom-font/) aus Benutzerordnern für die Verwendung beim [rendering and export](/slides/de/net/convert-powerpoint/).

**Korrigiert die Ersetzung das "tofu" (Quadrate) anstelle von Zeichen?**

Nur wenn die Ziel‑Schriftart tatsächlich die erforderlichen Glyphen enthält. Andernfalls [configure fallback](/slides/de/net/fallback-font/) zur Abdeckung der fehlenden Zeichen.