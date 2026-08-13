---
title: PowerPoint-Präsentationen in Word-Dokumente in C++ konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Word
- Präsentation zu Word
- Folie zu Word
- PPT zu Word
- PPTX zu Word
- PowerPoint zu DOCX
- Präsentation zu DOCX
- Folie zu DOCX
- PPT zu DOCX
- PPTX zu DOCX
- PowerPoint zu DOC
- Präsentation zu DOC
- Folie zu DOC
- PPT zu DOC
- PPTX zu DOC
- PPT als DOCX speichern
- PPTX als DOCX speichern
- PPT nach DOCX exportieren
- PPTX nach DOCX exportieren
- C++
- Aspose.Slides
description: Konvertieren Sie PowerPoint PPT und PPTX Folien in bearbeitbare Word Dokumente mit C++ mittels Aspose.Slides, wobei das genaue Layout, Bilder und Formatierungen erhalten bleiben.
---
## **Einführung**

Wenn Sie planen, Textinhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu nutzen, kann es vorteilhaft sein, die Präsentation in Word (DOC oder DOCX) zu konvertieren.

* Im Vergleich zu Microsoft PowerPoint bietet die Microsoft Word‑App mehr Werkzeuge oder Funktionen für Inhalte.
* Neben den Bearbeitungsfunktionen in Word können Sie auch von erweiterten Kollaborations-, Druck‑ und Freigabefunktionen profitieren.

{{% alert color="info" %}}

Vielleicht möchten Sie unseren [**Presentation to Word Online Converter**](https://products.aspose.app/slides/de/conversion/ppt-to-word) testen, um zu sehen, welchen Nutzen Sie aus der Arbeit mit Textinhalten aus Folien ziehen können.

{{% /alert %}}

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint‑Datei (PPTX oder PPT) in Word (DOCX oder DOCX) zu konvertieren, benötigen Sie sowohl [Aspose.Slides for C++](https://products.aspose.com/slides/de/cpp/) als auch [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für C++ Funktionen, mit denen Sie Texte aus Präsentationen extrahieren können.

[Aspose.Words](https://docs.aspose.com/words/cpp/) ist eine fortschrittliche Dokumentverarbeitungs‑API, die Anwendungen ermöglicht, Dateien zu erzeugen, zu ändern, zu konvertieren, zu rendern, zu drucken und weitere Aufgaben mit Dokumenten auszuführen, ohne Microsoft Word zu verwenden.

## **PowerPoint‑Präsentation in ein Word‑Dokument konvertieren**

Verwenden Sie dieses Code‑Snippet, um die PowerPoint‑Datei in Word zu konvertieren:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generiert ein Folienbild als Byte-Array-Stream
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // fügt die Texte der Folie ein
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Welche Komponenten müssen installiert werden, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?

Sie müssen lediglich die entsprechenden Pakete für [Aspose.Slides for C++](https://releases.aspose.com/slides/de/cpp/) und [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) zu Ihrem Projekt hinzufügen. Beide Bibliotheken funktionieren als eigenständige APIs, und es ist keine Installation von Microsoft Office erforderlich.

### Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?

Aspose.Slides [supports all presentation formats](/slides/de/cpp/supported-file-formats/), einschließlich PPT, PPTX, ODP und anderer gängiger Dateitypen. Das stellt sicher, dass Sie mit Präsentationen arbeiten können, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.