---
title: Verwalten von Präsentationsplatzhaltern in C++
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/cpp/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Aufforderungstext
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Müheloses Verwalten von Platzhaltern in Aspose.Slides für C++: Text ersetzen, Eingabeaufforderungen anpassen & Bildtransparenz festlegen in PowerPoint- und OpenDocument-Dateien."
---

## **Text in einem Platzhalter ändern**
Mit [Aspose.Slides for C++](/slides/de/cpp/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, den Text in einem Platzhalter zu ändern.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Eine solche Präsentation können Sie mit der üblichen Microsoft PowerPoint‑Anwendung erstellen.

So verwenden Sie Aspose.Slides, um den Text in dem Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die Klasse [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) und übergeben Sie die Präsentation als Argument.
2. Holen Sie eine Folienreferenz über ihren Index.
3. Durchlaufen Sie die Shapes, um den Platzhalter zu finden.
4. Wandeln Sie das Platzhalter‑Shape in ein [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) um und ändern Sie den Text mithilfe des [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/), das dem [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) zugeordnet ist.
5. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie man den Text in einem Platzhalter ändert:
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Greift auf den ersten und zweiten Platzhalter in der Folie zu und wandelt ihn in ein AutoShape um
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Speichert die Präsentation auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Aufforderungstext in einem Platzhalter festlegen**
Standard‑ und vorgefertigte Layouts enthalten Platzhalter‑Aufforderungstexte wie ***Klicken Sie, um einen Titel hinzuzufügen*** oder ***Klicken Sie, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre gewünschten Aufforderungstexte in Platzhalter‑Layouts einfügen.

Dieser C++‑Code zeigt, wie Sie den Aufforderungstext in einem Platzhalter festlegen:
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Wenn kein Text darin ist, zeigt PowerPoint "Click to add title" an. 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Macht dasselbe für Untertitel.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Transparenz eines Platzhalter‑Bildes festlegen**
Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbildes in einem Text‑Platzhalter einzustellen. Durch Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (abhängig von den Farben von Text und Bild).

Dieser C++‑Code zeigt, wie Sie die Transparenz für einen Bild‑Hintergrund (innerhalb eines Shapes) festlegen:
```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```


## **FAQ**

**Was ist ein Basis‑Platzhalter und wie unterscheidet er sich von einer lokalen Form auf einer Folie?**

Ein Basis‑Platzhalter ist die ursprüngliche Form in einem Layout oder einer Master‑Folien, von der die Form der Folie erbt — Typ, Position und einige Formatierungen stammen daraus. Eine lokale Form ist unabhängig; gibt es keinen Basis‑Platzhalter, findet keine Vererbung statt.

**Wie kann ich alle Titel oder Beschriftungen in einer Präsentation aktualisieren, ohne jede Folie einzeln zu durchlaufen?**

Bearbeiten Sie den entsprechenden Platzhalter im Layout oder im Master. Folien, die auf diesen Layouts/diesem Master basieren, erben die Änderung automatisch.

**Wie steuere ich die Standard‑Kopf‑/Fußzeilen‑Platzhalter – Datum & Uhrzeit, Foliennummer und Fußzeilentext?**

Verwenden Sie die HeaderFooter‑Manager im jeweiligen Geltungsbereich (normale Folien, Layouts, Master, Notizen/Handzettel), um diese Platzhalter ein‑ oder auszuschalten und ihren Inhalt festzulegen.