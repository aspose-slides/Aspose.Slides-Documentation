---
title: Vereinfachen Sie die Schriftart-Ersetzung in Präsentationen mit Python über Java
linktitle: Schriftart-Ersetzung
type: docs
weight: 60
url: /de/python-java/font-replacement/
keywords:
- Schriftart
- Schriftart ersetzen
- Schriftart Ersetzung
- Schriftart ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Ersetzen Sie Schriftarten nahtlos in Aspose.Slides für Python via Java, um eine konsistente Typografie in PowerPoint- und OpenDocument-Präsentationen sicherzustellen."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, eine Schriftart in einer gesamten Präsentation durch eine andere zu ersetzen. Wenn eine Schriftart ersetzt wird, werden alle Vorkommen der ursprünglichen Schriftart durch die neue Schriftart geändert.

Um eine Schriftart‑Ersetzung durchzuführen, laden Sie die Präsentation, definieren die Quellschriftart und die Ersatzschriftart, rufen die Methode zur Schriftart‑Ersetzung auf und speichern die modifizierte Präsentation als PPTX‑Datei. Dieser Ansatz ist nützlich, wenn Sie gezielt von einer Schriftfamilie zu einer anderen in der gesamten Präsentation wechseln möchten.

## **Schriftarten ersetzen**

Wenn Sie Ihre Meinung bezüglich einer Schriftart ändern, können Sie diese Schriftart durch eine andere ersetzen. Alle Vorkommen der alten Schriftart werden durch die neue Schriftart ersetzt. 

Aspose.Slides ermöglicht es Ihnen, eine Schriftart auf diese Weise zu ersetzen:

1. Laden Sie die betreffende Präsentation. 
2. Laden Sie die Schriftart, die ersetzt werden soll. 
3. Laden Sie die neue Schriftart. 
4. Ersetzen Sie die Schriftart. 
5. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert die Schriftart‑Ersetzung:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Lade eine Präsentation.
presentation = Presentation("Fonts.pptx")
try:
    # Lade die Quellschriftart, die ersetzt werden soll.
    source_font = FontData("Arial")

    # Lade die neue Schriftart.
    destination_font = FontData("Times New Roman")

    # Ersetze die Schriftart.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Speichere die Präsentation.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
Um Regeln festzulegen, die bestimmen, was unter bestimmten Bedingungen geschieht (z. B. wenn auf eine Schriftart nicht zugegriffen werden kann), siehe [Schriftart‑Substitution](/slides/de/python-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen "Schriftart‑Ersetzung", "Schriftart‑Substitution" und "Fallback‑Schriftarten"?**

Ersetzung ist ein gezielter Wechsel von einer Familie zu einer anderen im gesamten Dokument. [Substitution](/slides/de/python-java/font-substitution/) ist eine Regel wie »wenn die Schriftart nicht verfügbar ist, verwende X«. [Fallback](/slides/de/python-java/fallback-font/) wird auf einzelne fehlende Glyphen angewendet, wenn die Basisschriftart installiert ist, aber nicht die benötigten Zeichen enthält.

**Wird die Ersetzung auf Masterfolien, Layouts, Notizen und Kommentare angewendet?**

Ja. Die Ersetzung wirkt sich auf alle Präsentationsobjekte aus, die die ursprüngliche Schriftart verwenden, einschließlich Masterfolien und Notizen; Kommentare sind ebenfalls Teil des Dokuments und werden von der Schriftart‑Engine berücksichtigt.

**Ändert sich die Schriftart in eingebetteten OLE‑Objekten (z. B. Excel)?**

Nein. [OLE‑Inhalt](/slides/de/python-java/manage-ole/) wird von seiner eigenen Anwendung gesteuert. Eine Ersetzung in der Präsentation formatiert die internen OLE‑Daten nicht neu; sie kann als Bild oder als extern bearbeitbarer Inhalt angezeigt werden.

**Kann ich eine Schriftart nur in einem Teil der Präsentation (nach Folien oder Bereichen) ersetzen?**

Eine gezielte Ersetzung ist möglich, wenn Sie die Schriftart auf Ebene der gewünschten Objekte/Bereiche ändern, anstatt eine globale Ersetzung für das gesamte Dokument anzuwenden. Die übergeordnete Logik zur Schriftartauswahl beim Rendern bleibt unverändert.

**Wie kann ich im Voraus feststellen, welche Schriftarten die Präsentation verwendet?**

Verwenden Sie den [Schriftarten‑Manager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/): er liefert eine Liste der [verwendeten Familien](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFonts) und Informationen zu [Substitutionen/„unbekannten“ Schriftarten](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions), was bei der Planung der Ersetzung hilft.

**Funktioniert die Schriftart‑Ersetzung beim Konvertieren in PDF/Bilder?**

Ja. Beim Export verwendet Aspose.Slides dieselbe [Schriftartauswahl‑/Substitutionssequenz](/slides/de/python-java/font-selection-sequence/), sodass eine vorher durchgeführte Ersetzung während der Konvertierung berücksichtigt wird.

**Muss ich die Zielschriftart im System installieren, oder kann ich einen Schriftartenordner anhängen?**

Eine Installation ist nicht erforderlich: Die Bibliothek ermöglicht das [Laden externer Schriftarten](/slides/de/python-java/custom-font/) aus Benutzerordnern für die Verwendung beim [Rendern und Exportieren](/slides/de/python-java/convert-powerpoint/).

**Wird die Ersetzung „Tofu“ (Quadrate) anstelle von Zeichen beheben?**

Nur wenn die Zielschriftart die erforderlichen Glyphen tatsächlich enthält. Andernfalls [Fallback konfigurieren](/slides/de/python-java/fallback-font/), um die fehlenden Zeichen abzudecken.