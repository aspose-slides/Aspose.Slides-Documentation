---
title: PDF-Dokumente auf Android bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/androidjava/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- Android
- Java
- Aspose.Slides
description: "PDF-Dokumente auf Android mit Java bearbeiten, indem sie in Aspose.Slides importiert, der Text ersetzt und die geänderte Präsentation wieder als PDF gespeichert wird."
---
## **Übersicht**

Aspose.Slides for Android via Java ermöglicht das Bearbeiten von PDF‑Inhalten, indem dessen Seiten als Folien importiert, die Präsentation geändert und anschließend wieder als PDF exportiert wird. Dieser Artikel zeigt einen einfachen Text‑Ersetzungsvorgang. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einem PDF ersetzen**

Verwenden Sie [addFromPdf](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-), um die Seiten zu importieren, [replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), um den Text zu aktualisieren, und [save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), um das Ergebnis zu exportieren.

Das folgende Beispiel geht davon aus, dass `input.pdf` nach dem Import das Wort „Draft“ als editierbaren Text enthält. Es ersetzt dieses Wort durch „Final“ und schreibt `edited.pdf`. Das Löschen der Anfangsfolie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit exakt gleicher Groß‑ und Kleinschreibung überein; `null` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

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

Weitere Optionen finden Sie unter [Suchen und Ersetzen von Text](/slides/de/androidjava/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Der Text‑Ersetzungs‑Vorgang funktioniert nur bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen; prüfen Sie daher die Ausgabe, insbesondere wenn der Ersetzungstext länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie die Datei anschließend weiter in PowerPoint bearbeiten möchten; siehe [Präsentationen speichern](/slides/de/androidjava/save-presentation/).

**Warum bleibt ein Teil des Textes unverändert?**

Das Beispiel sucht das ganze Wort „Draft“ mit exakt gleicher Groß‑ und Kleinschreibung. Als Bild importierter Text oder Text, der auf mehrere Textfelder verteilt ist, wird die Suche möglicherweise nicht gefunden. Überprüfen Sie den importierten Inhalt und passen Sie die Suche an Ihr Dokument an.