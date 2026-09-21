---
title: PDF-Dokumente in JavaScript bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/nodejs-java/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "PDF-Dokumente in JavaScript bearbeiten, indem Sie sie in Aspose.Slides importieren, Text ersetzen und die geänderte Präsentation wieder als PDF speichern."
---
## **Übersicht**

Aspose.Slides for Node.js via Java ermöglicht das Bearbeiten von PDF‑Inhalten, indem dessen Seiten als Folien importiert, die Präsentation geändert und anschließend wieder als PDF exportiert wird. Dieser Artikel zeigt einen einfachen Text‑Austausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einem PDF ersetzen**

Verwenden Sie [addFromPdf](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/#addFromPdf), um die Seiten zu importieren, [replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceText), um den Text zu aktualisieren, und [save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), um das Ergebnis zu exportieren.

Das folgende Beispiel geht davon aus, dass `input.pdf` nach dem Import das Wort „Draft“ als editierbaren Text enthält. Es ersetzt dieses Wort durch „Final“ und schreibt `edited.pdf`. Das Leeren der ersten Folie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche entspricht ganzen Wörtern mit exakt gleicher Groß‑/Kleinschreibung; `null` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Weitere Optionen finden Sie unter [Suchen und Ersetzen von Text](/slides/de/nodejs-java/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Hinweis" %}}
Der Textaustausch funktioniert nur bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, prüfen Sie daher die Ausgabe, insbesondere wenn der ersetzte Text länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie sie anschließend weiter in PowerPoint bearbeiten möchten; siehe [Präsentationen speichern](/slides/de/nodejs-java/save-presentation/).

**Warum bleibt möglicherweise etwas Text unverändert?**

Das Beispiel sucht nach dem gesamten Wort „Draft“ mit genauer Groß‑/Kleinschreibung. Als Bild importierter Text oder Text, der auf mehrere Textfelder verteilt ist, wird die Suche möglicherweise nicht treffen. Prüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.