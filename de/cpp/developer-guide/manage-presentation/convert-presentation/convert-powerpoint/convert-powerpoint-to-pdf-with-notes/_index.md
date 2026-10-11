---
title: PowerPoint-Präsentationen mit Notizen in C++ in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- Folie zu PDF
- PPT zu PDF
- PPTX zu PDF
- Präsentation als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Sprechernotizen
- PDF mit Notizen
- C++
- Aspose.Slides
description: "Konvertieren Sie die Formate PPT und PPTX mit Notizen in PDF mithilfe von Aspose.Slides für C++. Bewahren Sie Layouts und Sprechernotizen für professionelle Präsentationen."
---
## **Übersicht**

In diesem Artikel erfahren Sie, wie Sie PowerPoint‑Präsentationen mit Sprechernotizen mithilfe von Aspose.Slides in das PDF‑Format konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, um diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu verwandeln und dabei die Sprechernotizen zu erhalten.
- Das Ausgabe‑PDF anpassen, um sicherzustellen, dass die Sprechernotizen enthalten und gemäß Ihren Anforderungen formatiert sind.

Um die Abmessungen und die Ausrichtung der Notizenseite vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/cpp/notes-size/).

## **PowerPoint in PDF mit Notizen konvertieren**

`Save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprechernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/) , um Sprechernotizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie Sie eine Beispiels‑Präsentation in ein PDF im Notiz‑Folien‑Ansicht konvertieren.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// PDF-Optionen für das Rendern von Sprechernotizen konfigurieren.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Sprechernotizen unterhalb der Folie rendern.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Präsentation als PDF mit Sprechernotizen speichern.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Vielleicht möchten Sie den Aspose [Online PowerPoint zu PDF Konverter](https://products.aspose.app/slides/de/conversion) ausprobieren.
{{% /alert %}}