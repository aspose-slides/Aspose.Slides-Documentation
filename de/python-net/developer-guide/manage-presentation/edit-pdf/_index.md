---
title: PDF-Dokumente in Python bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/python-net/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- Python
- Aspose.Slides
description: "PDF-Dokumente in Python bearbeiten, indem Sie sie in Aspose.Slides importieren, den Text ersetzen und die modifizierte Präsentation wieder als PDF speichern."
---
## **Übersicht**

Aspose.Slides für Python via .NET ermöglicht das Bearbeiten von PDF-Inhalten, indem Sie dessen Seiten als Folien importieren, die Präsentation ändern und sie wieder als PDF exportieren. Dieser Artikel zeigt einen einfachen Textaustausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX-Format optional ist.

## **Text in einer PDF ersetzen**

Verwenden Sie [add_from_pdf](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/add_from_pdf/) zum Importieren der Seiten, [replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_text/) zum Aktualisieren des Textes und [save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) zum Exportieren des Ergebnisses.

Das folgende Beispiel erwartet, dass `input.pdf` nach dem Import das Wort "Draft" als editierbaren Text enthält. Es ersetzt dieses Wort durch "Final" und schreibt `edited.pdf`. Das Löschen der ersten Folie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit derselben Groß- und Kleinschreibung überein; `None` bedeutet, dass kein Ergebnis-Callback erforderlich ist.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Weitere Optionen finden Sie unter [Text suchen und ersetzen](/slides/de/python-net/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Der Textaustausch funktioniert bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, daher sollten Sie die Ausgabe überprüfen, insbesondere wenn der ersetzte Text länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX-Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie sie weiterhin in PowerPoint bearbeiten möchten; siehe [Präsentationen speichern](/slides/de/python-net/save-presentation/).

**Warum könnte ein Teil des Textes unverändert bleiben?**

Das Beispiel stimmt das ganze Wort "Draft" mit exakter Groß- und Kleinschreibung überein. Text, der als Bild importiert wurde oder über mehrere Textfelder verteilt ist, stimmt möglicherweise nicht mit der Suche überein. Überprüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.