---
title: Vereinfachen Sie den Schriftartenaustausch in Präsentationen mit Python
linktitle: Schriftart ersetzen
type: docs
weight: 60
url: /de/python-net/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftartersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Ersetzen Sie Schriftarten nahtlos in Aspose.Slides Python über .NET, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen sicherzustellen."
---

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung ändern und eine Schriftart nicht mehr verwenden möchten, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt. 

Aspose.Slides ermöglicht das Ersetzen einer Schriftart auf folgende Weise:

1. Laden Sie die betreffende Präsentation. 
2. Laden Sie die Schriftart, die ersetzt werden soll. 
3. Laden Sie die neue Schriftart. 
4. Ersetzen Sie die Schriftart. 
5. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert das Ersetzen von Schriftarten:
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


{{% alert title="Note" color="warning" %}} 

Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen passiert (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [**Font Substitution**](/slides/de/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen "Schriftart‑Ersetzung", "Schriftart‑Substitution" und "Fallback‑Schriftarten"?**

Ersetzung ist ein gezielter Wechsel von einer Familie zur anderen im gesamten Dokument. [Substitution](/slides/de/python-net/font-substitution/) ist eine Regel wie „wenn die Schriftart nicht verfügbar ist, verwende X.“ [Fallback](/slides/de/python-net/fallback-font/) wird punktuell für einzelne fehlende Glyphen angewendet, wenn die Basis­schriftart installiert ist, aber die benötigten Zeichen nicht enthält.

**Wird die Ersetzung auf Master‑Folien, Layouts, Notizen und Kommentare angewendet?**

Ja. Die Ersetzung wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Master‑Folien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schrift‑Engine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE‑Inhalt](/slides/de/python-net/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie können als Bild oder als extern editierbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der benötigten Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument vorzunehmen. Die Gesamt‑Logik zur Schriftartauswahl beim Rendern bleibt unverändert.

**Wie kann ich im Voraus ermitteln, welche Schriftarten die Präsentation tatsächlich verwendet?**

Verwenden Sie den [Font Manager] der Präsentation(https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): Er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) und Informationen zu [Substitutionen/„unbekannten“ Schriftarten](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), was die Planung der Ersetzung unterstützt.

**Funktioniert die Schriftart‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export wendet Aspose.Slides dieselbe [Schriftart‑Auswahl/‑Substitutions‑Sequenz](/slides/de/python-net/font-selection-sequence/) an, sodass eine zuvor durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Ziel‑schriftart im System installieren oder kann ich einen Schriftarten‑Ordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/python-net/custom-font/) aus Benutzerordnern für die Verwendung während des [Renderns und Exports](/slides/de/python-net/convert-powerpoint/).

**Wird die Ersetzung „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Ziel‑schriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls sollte [Fallback](/slides/de/python-net/fallback-font/) konfiguriert werden, um die fehlenden Zeichen abzudecken.