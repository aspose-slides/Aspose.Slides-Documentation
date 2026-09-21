---
title: PDF-Dokumente in Python via Java bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/python-java/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- Python
- Java
- Aspose.Slides
description: "PDF-Dokumente in Python via Java bearbeiten, indem Sie sie in Aspose.Slides importieren, Text ersetzen und die geänderte Präsentation wieder als PDF speichern."
---
## **Übersicht**

Aspose.Slides for Python via Java lässt Sie PDF‑Inhalte bearbeiten, indem Sie deren Seiten als Folien importieren, die Präsentation ändern und sie wieder als PDF exportieren. Dieser Artikel zeigt einen einfachen Textaustausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einer PDF ersetzen**

Verwenden Sie [addFromPdf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromPdf) zum Importieren der Seiten, [replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#replaceText) zum Aktualisieren des Textes und [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) zum Exportieren des Ergebnisses.

Im folgenden Beispiel wird erwartet, dass `input.pdf` nach dem Import das Wort "Draft" als editierbaren Text enthält. Es ersetzt dieses Wort durch "Final" und schreibt `edited.pdf`. Das Leeren der Anfangsfolie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit exakt gleicher Groß‑ und Kleinschreibung überein; `None` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Weitere Optionen finden Sie unter [Suchen und Ersetzen von Text](/slides/de/python-java/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Text ersetzen funktioniert bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, daher sollten Sie das Ergebnis prüfen, insbesondere wenn der zu ersetzende Text länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie die Datei weiterhin in PowerPoint bearbeiten möchten; siehe [Save Presentations](/slides/de/python-java/save-presentation/).

**Warum bleibt ein Teil des Textes unverändert?**

Das Beispiel stimmt das ganze Wort „Draft“ mit exakt gleicher Groß‑ und Kleinschreibung überein. Als Bild importierter Text oder Text, der auf mehrere Textfelder verteilt ist, trifft möglicherweise nicht auf die Suche zu. Überprüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.