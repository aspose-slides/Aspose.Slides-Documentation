---
title: PDF-Dokumente in .NET bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/net/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- .NET
- C#
- Aspose.Slides
description: "PDF-Dokumente in C# bearbeiten, indem sie in Aspose.Slides importiert, der Text ersetzt und die geänderte Präsentation wieder als PDF gespeichert wird."
---
## **Übersicht**

Aspose.Slides für .NET ermöglicht das Bearbeiten von PDF‑Inhalten, indem dessen Seiten als Folien importiert, die Präsentation geändert und anschließend wieder als PDF exportiert wird. Dieser Artikel zeigt einen einfachen Text‑Ersetzungsvorgang. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einem PDF ersetzen**

Verwenden Sie [AddFromPdf](https://reference.aspose.com/slides/de/net/aspose.slides/slidecollection/addfrompdf/), um die Seiten zu importieren, [ReplaceText](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/replacetext/), um den Text zu aktualisieren, und [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), um das Ergebnis zu exportieren.

Im folgenden Beispiel wird davon ausgegangen, dass `input.pdf` nach dem Import das Wort „Draft“ als editierbaren Text enthält. Es ersetzt dieses Wort durch „Final“ und schreibt `edited.pdf`. Das Löschen der Anfangsfolie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit exakt gleicher Groß‑ und Kleinschreibung überein; `null` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Weitere Optionen finden Sie unter [Text suchen und ersetzen](/slides/de/net/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Die Textersetzung funktioniert nur bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, prüfen Sie daher die Ausgabe, insbesondere wenn der Ersetzungstext länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können die gleiche Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie sie anschließend in PowerPoint weiterbearbeiten möchten; siehe [Save Presentations](/slides/de/net/save-presentation/).

**Warum bleibt ein Teil des Textes unverändert?**

Das Beispiel sucht nach dem gesamten Wort „Draft“ mit exakt gleicher Schreibweise. Als Bild importierter Text oder über mehrere Textfelder aufgeteilter Text wird die Suche möglicherweise nicht treffen. Überprüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.