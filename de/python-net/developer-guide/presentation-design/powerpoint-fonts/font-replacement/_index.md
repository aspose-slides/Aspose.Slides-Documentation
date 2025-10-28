---
title: Schriftart-Ersetzung in Präsentationen mit Python optimieren
linktitle: Schriftart-Ersetzung
type: docs
weight: 60
url: /de/python-net/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftarten-Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Ersetzen Sie Schriftarten in Aspose.Slides Python via .NET nahtlos, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen zu gewährleisten."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich der Verwendung einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt.

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die betreffende Präsentation.  
2. Laden Sie die Schriftart, die ersetzt werden soll.  
3. Laden Sie die neue Schriftart.  
4. Ersetzen Sie die Schriftart.  
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert die Schriftart‑Ersetzung:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Hinweis" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn eine Schriftart nicht zugänglich ist), siehe [**Schriftart-Substitution**](/slides/de/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen „Schriftart-Ersetzung“, „Schriftart-Substitution“ und „Fallback-Schriftarten“?**

Ersetzung ist ein beabsichtigter Wechsel von einer Schriftfamilie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/python-net/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/python-net/fallback-font/) wird gezielt für einzelne fehlende Glyphen angewendet, wenn die Basis‑Schriftart installiert ist, aber die erforderlichen Zeichen nicht enthält.

**Wird die Ersetzung auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Die Ersetzung betrifft alle Präsentationsobjekte, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schrift‑Engine berücksichtigt.

**Wird die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel) geändert?**

Nein. [OLE‑Inhalt](/slides/de/python-net/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Die Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie kann als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der erforderlichen Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die allgemeine Logik der Schriftartauswahl während des Renderings bleibt unverändert.

**Wie kann ich im Voraus feststellen, welche Schriftarten die Präsentation überhaupt verwendet?**

Verwenden Sie den [Font‑Manager] der Präsentation (https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) und Informationen zu [Substitutionen/„unbekannten“ Schriftarten](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), was bei der Planung der Ersetzung hilft.

**Funktioniert die Schriftart‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides dieselbe [Schriftart‑Auswahl‑/‑Substitutionssequenz](/slides/de/python-net/font-selection-sequence/) an, sodass eine vorher durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel‑Schriftart im System installieren, oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/python-net/custom-font/) aus Benutzerordnern für die Verwendung während des [Renderings und Exports](/slides/de/python-net/convert-powerpoint/).

**Behoben die Ersetzung das „Tofu“ (Quadrate) anstelle von Zeichen?**

Nur wenn die Ziel‑Schriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [Fallback konfigurieren](/slides/de/python-net/fallback-font/), um die fehlenden Zeichen abzudecken.