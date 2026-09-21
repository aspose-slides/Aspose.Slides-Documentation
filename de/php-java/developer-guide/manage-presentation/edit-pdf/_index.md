---
title: PDF-Dokumente in PHP bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/php-java/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- PHP
- Aspose.Slides
description: "PDF-Dokumente in PHP bearbeiten, indem sie in Aspose.Slides importiert, der Text ersetzt und die modifizierte Präsentation wieder als PDF gespeichert wird."
---
## **Übersicht**

Aspose.Slides für PHP via Java ermöglicht das Bearbeiten von PDF‑Inhalten, indem seine Seiten als Folien importiert, die Präsentation geändert und wieder als PDF exportiert wird. Dieser Artikel zeigt einen einfachen Textaustausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einem PDF ersetzen**

Verwenden Sie [SlideCollection::addFromPdf](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/#addFromPdf), um die Seiten zu importieren, [Presentation::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceText), um den Text zu aktualisieren, und [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save), um das Ergebnis zu exportieren.

Im folgenden Beispiel wird davon ausgegangen, dass `input.pdf` nach dem Import das Wort „Draft“ als editierbaren Text enthält. Es ersetzt dieses Wort durch „Final“ und schreibt `edited.pdf`. Das Leeren der Anfangsfolie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit derselben Groß‑ und Kleinschreibung überein; `null` bedeutet, dass kein Rückruf für das Ergebnis benötigt wird.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Weitere Optionen finden Sie unter [Search and Replace Text](/slides/de/php-java/search-and-replace-text/) und [Convert PowerPoint to PDF](/slides/de/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Der Textaustausch funktioniert bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann Layout und Formatierung beeinflussen, daher sollte das Ergebnis überprüft werden, insbesondere wenn der Ersatztext länger ist als der ursprüngliche.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX‑Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie die Datei anschließend in PowerPoint weiter bearbeiten möchten; siehe [Save Presentations](/slides/de/php-java/save-presentation/).

**Warum bleibt ein Teil des Textes unverändert?**

Das Beispiel stimmt das ganze Wort „Draft“ exakt in Groß‑ und Kleinschreibung überein. Als Bild importierter Text oder Text, der über mehrere Textfelder verteilt ist, wird die Suche wahrscheinlich nicht treffen. Prüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.