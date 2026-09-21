---
title: PDF-Dokumente in Java bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/java/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- Java
- Aspose.Slides
description: "PDF-Dokumente in Java bearbeiten, indem Sie sie in Aspose.Slides importieren, Text ersetzen und die modifizierte Präsentation wieder als PDF speichern."
---
## **Übersicht**

Aspose.Slides for Java ermöglicht das Bearbeiten von PDF‑Inhalten, indem Sie dessen Seiten als Folien importieren, die Präsentation ändern und wieder als PDF exportieren. Dieser Artikel zeigt einen einfachen Textaustausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einem PDF ersetzen**

Verwenden Sie [addFromPdf](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) zum Importieren der Seiten, [replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) zum Aktualisieren des Textes und [save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) zum Exportieren des Ergebnisses.

Das folgende Beispiel erwartet, dass `input.pdf` nach dem Import das Wort "Draft" als editierbaren Text enthält. Es ersetzt dieses Wort durch "Final" und schreibt `edited.pdf`. Das Leeren der ersten Folie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche entspricht ganzen Wörtern mit derselben Groß‑ und Kleinschreibung; `null` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Weitere Optionen finden Sie unter [Suche und Ersetzen von Text](/slides/de/java/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Der Textaustausch funktioniert bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, daher sollten Sie die Ausgabe überprüfen, insbesondere wenn der ersetzte Text länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie die Präsentation weiterhin in PowerPoint bearbeiten möchten; siehe [Präsentationen speichern](/slides/de/java/save-presentation/).

**Warum bleibt ein Teil des Textes unverändert?**

Das Beispiel sucht nach dem ganzen Wort "Draft" mit exakt gleicher Groß‑ und Kleinschreibung. Text, der als Bild importiert wurde oder über mehrere Textfelder verteilt ist, passt möglicherweise nicht zur Suche. Überprüfen Sie den importierten Inhalt und passen Sie die Suche an Ihr Dokument an.