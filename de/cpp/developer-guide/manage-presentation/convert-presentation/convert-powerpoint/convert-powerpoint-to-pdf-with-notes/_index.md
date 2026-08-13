---
title: PowerPoint-Präsentationen mit Notizen in C++ in PDF konvertieren
linktitle: PowerPoint zu PDF mit Notizen
type: docs
weight: 50
url: /de/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- Folien zu PDF
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
description: "Formate PPT und PPTX mit Notizen mithilfe von Aspose.Slides für C++ in PDF konvertieren. Layouts und Sprechernotizen für professionelle Präsentationen erhalten."
---
## **Übersicht**

In diesem Artikel lernen Sie, wie Sie PowerPoint‑Präsentationen mit Sprechernotizen mithilfe von Aspose.Slides in das PDF‑Format konvertieren. Dieser Leitfaden behandelt die erforderlichen Schritte und liefert Codebeispiele, die Ihnen helfen, diese Aufgabe effizient zu erledigen. Am Ende dieses Artikels können Sie:

- Den Konvertierungsprozess implementieren, um PowerPoint‑Folien in PDF‑Dokumente zu transformieren und dabei die Sprechernotizen beizubehalten.
- Das Ausgabepdf anpassen, um sicherzustellen, dass die Sprechernotizen enthalten und nach Ihren Anforderungen formatiert sind.

## **PowerPoint in PDF mit Notizen konvertieren**

Die `Save`‑Methode in der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse kann verwendet werden, um eine PPT‑ oder PPTX‑Präsentation in ein PDF mit Sprechernotizen zu konvertieren. Mit Aspose.Slides laden Sie einfach die Präsentation, konfigurieren die Layout‑Optionen mithilfe der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um Sprechernotizen einzuschließen, und speichern die Datei anschließend als PDF. Das folgende Code‑Snippet zeigt, wie Sie eine Beispielpräsentation in ein PDF im Notizfolien‑Ansicht konvertieren.

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

// PDF-Optionen für das Rendern der Sprechernotizen konfigurieren.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Sprechernotizen unterhalb der Folie rendern.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Die Präsentation mit Sprechernotizen als PDF speichern.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Vielleicht möchten Sie den Aspose [Online PowerPoint zu PDF Konverter](https://products.aspose.app/slides/de/conversion) ausprobieren. 
{{% /alert %}}