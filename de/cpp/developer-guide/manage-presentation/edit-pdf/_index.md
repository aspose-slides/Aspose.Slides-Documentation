---
title: PDF-Dokumente in C++ bearbeiten
linktitle: PDF bearbeiten
type: docs
weight: 65
url: /de/cpp/edit-pdf/
keywords:
- PDF bearbeiten
- PDF-Text ersetzen
- PDF zu PPTX
- PPTX zu PDF
- C++
- Aspose.Slides
description: "PDF-Dokumente in C++ bearbeiten, indem sie in Aspose.Slides importiert, Text ersetzt und die geänderte Präsentation wieder als PDF gespeichert wird."
---
## **Übersicht**

Aspose.Slides for C++ ermöglicht das Bearbeiten von PDF‑Inhalten, indem dessen Seiten als Folien importiert, die Präsentation geändert und anschließend wieder als PDF exportiert wird. Dieser Artikel zeigt einen einfachen Textaustausch. Die Präsentation bleibt im Speicher, sodass das Speichern einer Zwischendatei im PPTX‑Format optional ist.

## **Text in einer PDF ersetzen**

Verwenden Sie [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidecollection/addfrompdf/), um die Seiten zu importieren, [Presentation::ReplaceText](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/replacetext/), um den Text zu aktualisieren, und [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/), um das Ergebnis zu exportieren.

Das folgende Beispiel erwartet, dass `input.pdf` das Wort "Draft" als editierbaren Text nach dem Import enthält. Es ersetzt dieses Wort durch "Final" und schreibt `edited.pdf`. Das Leeren der Anfangsfolie vor dem Import verhindert eine zusätzliche leere Seite in der Ausgabe. Die Suche stimmt ganze Wörter mit derselben Groß‑ und Kleinschreibung überein; `nullptr` bedeutet, dass kein Ergebnis‑Callback benötigt wird.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Für weitere Optionen siehe [Suchen und Ersetzen von Text](/slides/de/cpp/search-and-replace-text/) und [PowerPoint in PDF konvertieren](/slides/de/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Die Textersetzung funktioniert bei importiertem Text, nicht bei Text in gescannten Bildern. Die Konvertierung kann das Layout und die Formatierung beeinflussen, daher sollten Sie die Ausgabe überprüfen, insbesondere wenn der ersetzte Text länger ist als der Originaltext.
{{% /alert %}}

## **FAQ**

**Muss ich eine PPTX-Datei speichern, bevor ich das PDF exportiere?**

Nein. Sie können dieselbe Präsentation im Speicher bearbeiten und exportieren. Speichern Sie eine PPTX‑Kopie nur, wenn Sie die Datei weiterhin in PowerPoint bearbeiten möchten; siehe [Präsentationen speichern](/slides/de/cpp/save-presentation/).

**Warum könnte ein Teil des Textes unverändert bleiben?**

Das Beispiel stimmt das gesamte Wort "Draft" mit exakt gleicher Groß‑ und Kleinschreibung überein. Text, der als Bild importiert wurde oder über mehrere Textfelder verteilt ist, wird nicht unbedingt von der Suche erfasst. Überprüfen Sie den importierten Inhalt und passen Sie die Suche für Ihr Dokument an.