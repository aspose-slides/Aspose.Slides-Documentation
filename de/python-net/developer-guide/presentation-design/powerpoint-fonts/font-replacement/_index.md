---
title: Schriftarten in Präsentationen mit Python effizient ersetzen
linktitle: Schriftarten ersetzen
type: docs
weight: 60
url: /de/python-net/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart-Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Schriftarten nahtlos in Aspose.Slides für Python via .NET ersetzen, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen sicherzustellen."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung zur Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart wie folgt:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die zu ersetzende Schriftart.  
3. Laden Sie die neue Schriftart.  
4. Ersetzen Sie die Schriftart.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieses Python‑Beispiel demonstriert das Ersetzen von Schriftarten:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Lädt eine Präsentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Lädt die Quellschriftart, die ersetzt werden soll
    sourceFont = slides.FontData("Arial")

    # Lädt die neue Schriftart
    destFont = slides.FontData("Times New Roman")

    # Ersetzt die Schriftarten
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Speichert die Präsentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Schriftart‑Substitution**](/slides/de/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftart‑Ersetzung“, „Schriftart‑Substitution“ und „Fallback‑Schriftarten“?**

Ersetzung ist ein beabsichtigter Wechsel von einer Familie zur anderen im gesamten Dokument. [Substitution](/slides/de/python-net/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/python-net/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basisschriftart installiert ist, aber die benötigten Zeichen nicht enthält.

**Wird die Ersetzung auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Die Ersetzung betrifft alle Präsentationsobjekte, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schriftengine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE‑Inhalte](/slides/de/python-net/manage-ole/) werden von ihrer eigenen Anwendung gesteuert. Die Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie werden möglicherweise als Bild oder als extern bearbeitbarer Inhalt angezeigt.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die gesamte Logik zur Schriftartauswahl während des Renderns bleibt unverändert.

**Wie kann ich im Voraus bestimmen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [Font‑Manager] der Präsentation (https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien] und Informationen zu [Substitutionen/„unbekannten“ Schriftarten](), was die Planung der Ersetzung erleichtert.

**Funktioniert die Schriftart‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides dieselbe [Schriftart‑Auswahl‑/‑Substitutionssequenz](/slides/de/python-net/font-selection-sequence/) an, sodass eine zuvor durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel‑Schriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/python-net/custom-font/) aus Benutzer‑Ordnern für die Verwendung während des [Renderns und Exports](/slides/de/python-net/convert-powerpoint/).

**Wird die Ersetzung „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Ziel‑Schriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls sollte [Fallback](/slides/de/python-net/fallback-font/) konfiguriert werden, um die fehlenden Zeichen abzudecken.