---
title: PowerPoint in Word konvertieren
type: docs
weight: 110
url: /de/cpp/convert-powerpoint-to-word/
keywords: "PowerPoint konvertieren, PPT, PPTX, Präsentation, Word, DOCX, DOC, PPTX in DOCX, PPT in DOC, PPTX in DOC, PPT in DOCX, C++, Aspose.Slides"
description: "Konvertieren Sie eine PowerPoint-Präsentation in Word in C++ "
---

Wenn Sie planen, textuelle Inhalte oder Informationen aus einer Präsentation (PPT oder PPTX) auf neue Weise zu verwenden, können Sie davon profitieren, die Präsentation in Word (DOC oder DOCX) zu konvertieren.

* Im Vergleich zu Microsoft PowerPoint ist die Microsoft Word-App besser mit Werkzeugen oder Funktionalitäten für Inhalte ausgestattet.
* Neben den Bearbeitungsfunktionen in Word können Sie auch von verbesserten Funktionen für Zusammenarbeit, Drucken und Teilen profitieren.

{{% alert color="primary" %}}

Sie möchten vielleicht unseren [**Online-Konverter für Präsentationen in Word**](https://products.aspose.app/slides/conversion/ppt-to-word) ausprobieren, um zu sehen, was Sie aus der Arbeit mit textuellen Inhalten von Folien gewinnen könnten.

{{% /alert %}}

### **Aspose.Slides und Aspose.Words**

Um eine PowerPoint-Datei (PPTX oder PPT) in Word (DOCX oder DOCX) zu konvertieren, benötigen Sie sowohl [Aspose.Slides für C++](https://products.aspose.com/slides/cpp/) als auch [Aspose.Words für C++](https://products.aspose.com/words/cpp/).

Als eigenständige API bietet [Aspose.Slides](https://products.aspose.app/slides) für C++ Funktionen, mit denen Sie Texte aus Präsentationen extrahieren können.

[Aspose.Words](https://docs.aspose.com/words/cpp/) ist eine fortschrittliche API zur Dokumentenverarbeitung, die es Anwendungen ermöglicht, Dateien zu erstellen, zu ändern, zu konvertieren, zu rendern, zu drucken und andere Aufgaben mit Dokumenten ohne die Nutzung von Microsoft Word auszuführen.

## **PowerPoint in Word konvertieren**

Verwenden Sie diesen Code-Schnipsel, um PowerPoint in Word zu konvertieren:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generiert und fügt Folienbild ein
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