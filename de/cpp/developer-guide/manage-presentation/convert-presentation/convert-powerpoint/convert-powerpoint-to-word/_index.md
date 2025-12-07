---
title: PowerPoint-Präsentationen in Word-Dokumente in C++ konvertieren
linktitle: PowerPoint zu Word
type: docs
weight: 110
url: /de/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
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
description: "PowerPoint PPT- und PPTX-Folien in editierbare Word-Dokumente in C++ konvertieren, dabei das genaue Layout, Bilder und die Formatierung mit Aspose.Slides beibehalten."
---

Wenn Sie planen, Textinhalte oder Informationen aus einer Praesentation (PPT oder PPTX) auf neue Weise zu nutzen, koennen Sie davon profitieren, die Praesentation in Word (DOC oder DOCX) zu konvertieren. 

* Im Vergleich zu Microsoft PowerPoint bietet die Microsoft Word-App mehr Werkzeuge oder Funktionen fuer Inhalte. 
* Neben den Bearbeitungsfunktionen in Word koennen Sie auch von erweiterten Funktionen fuer Zusammenarbeit, Druck und Freigabe profitieren. 

{{% alert color="primary" %}} 

Vielleicht moechten Sie unseren [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, welchen Nutzen Sie aus der Arbeit mit Textinhalten aus Folien ziehen koennen. 

{{% /alert %}} 

## **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOCX) zu konvertieren, benoetigen Sie sowohl [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) als auch [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Als eigenstaendige API stellt [Aspose.Slides](https://products.aspose.app/slides) fuer C++ Funktionen bereit, mit denen Sie Texte aus Praesentationen extrahieren koennen. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) ist eine fortschrittliche Dokumenten-Verarbeitungs-API, die Anwendungen ermoeglicht, Dateien zu erstellen, zu aendern, zu konvertieren, zu rendern, zu drucken und weitere Aufgaben mit Dokumenten auszufuehren, ohne Microsoft Word zu verwenden.

## **PowerPoint-Praesentation in ein Word-Dokument konvertieren**

Verwenden Sie dieses Code-Snippet, um die PowerPoint-Datei in Word zu konvertieren:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // erzeugt und fügt das Folienbild ein
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // fügt den Folientext ein
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

**Welche Komponenten muessen installiert werden, um PowerPoint- und OpenDocument-Praesentationen in Word-Dokumente zu konvertieren?**

Sie muessten lediglich die entsprechenden Pakete fuer [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) und [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) zu Ihrem Projekt hinzufuegen. Beide Bibliotheken funktionieren als eigenstaendige APIs, und es ist nicht erforderlich, Microsoft Office zu installieren.

**Werden alle PowerPoint- und OpenDocument-Praesentationsformate unterstuetzt?**

Aspose.Slides [unterstuetzt alle Praesentationformate](/slides/de/cpp/supported-file-formats/), einschliesslich PPT, PPTX, ODP und anderen gaengigen Dateitypen. Damit koennen Sie mit Praesentationen arbeiten, die in verschiedenen Versionen von Microsoft PowerPoint erstellt wurden.