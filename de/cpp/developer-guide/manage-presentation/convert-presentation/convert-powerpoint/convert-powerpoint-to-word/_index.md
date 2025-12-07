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
description: "PowerPoint‑PPT‑ und PPTX‑Folien in editierbare Word‑Dokumente in C++ konvertieren mit Aspose.Slides, wobei Layout, Bilder und Formatierung exakt erhalten bleiben."
---

Wenn Sie planen, Textinhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu nutzen, kann es vorteilhaft sein, die Präsentation in Word (DOC oder DOCX) zu konvertieren. 

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word‑App besser mit Werkzeugen oder Funktionen für Inhalte ausgestattet. 
* Neben den Bearbeitungsfunktionen in Word können Sie auch von erweiterten Kollaborations‑, Druck‑ und Freigabefunktionen profitieren. 

{{% alert color="primary" %}} 

Sie können unseren [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, welchen Nutzen Sie daraus ziehen können, mit Textinhalten aus Folien zu arbeiten. 

{{% /alert %}} 

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint‑Datei (PPTX oder PPT) in Word (DOCX oder DOCX) zu konvertieren, benötigen Sie sowohl [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) als auch [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für C++ Funktionen, mit denen Sie Texte aus Präsentationen extrahieren können. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) ist eine fortschrittliche Dokumentverarbeitungs‑API, die Anwendungen ermöglicht, Dateien zu erzeugen, zu ändern, zu konvertieren, zu rendern, zu drucken und weitere Aufgaben mit Dokumenten auszuführen, ohne Microsoft Word zu verwenden.

## **PowerPoint‑Präsentation in ein Word‑Dokument konvertieren**

Verwenden Sie dieses Code‑Snippet, um die PowerPoint‑Datei in Word zu konvertieren:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // erzeugt und fügt das Folienbild ein
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```


## **FAQ**

**Welche Komponenten müssen installiert werden, um PowerPoint‑ und OpenDocument‑Präsentationen in Word‑Dokumente zu konvertieren?**

Sie müssen lediglich die jeweiligen Pakete für [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) und [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) zu Ihrem Projekt hinzufügen. Beide Bibliotheken funktionieren als eigenständige APIs, und es ist keine Installation von Microsoft Office erforderlich.

**Werden alle PowerPoint‑ und OpenDocument‑Präsentationsformate unterstützt?**

Aspose.Slides [unterstützt alle Präsentationsformate](/slides/de/cpp/supported-file-formats/), darunter PPT, PPTX, ODP und andere gängige Dateitypen. Damit können Sie mit Präsentationen arbeiten, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.