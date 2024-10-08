---
title: Platzhalter verwalten
type: docs
weight: 10
url: /de/cpp/manage-placeholder/
keywords: "Platzhalter, Platzhaltertext, Eingabetext, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Ändern Sie Platzhaltertext und Eingabetext in PowerPoint-Präsentationen in C++"
---

## **Text im Platzhalter ändern**
Mit [Aspose.Slides für C++](/slides/de/cpp/) können Sie Platzhalter auf Folien in Präsentationen finden und ändern. Aspose.Slides ermöglicht es Ihnen, Änderungen am Text in einem Platzhalter vorzunehmen.

**Voraussetzung**: Sie benötigen eine Präsentation, die einen Platzhalter enthält. Sie können eine solche Präsentation in der Standardanwendung Microsoft PowerPoint erstellen.

So verwenden Sie Aspose.Slides, um den Text im Platzhalter dieser Präsentation zu ersetzen:

1. Instanziieren Sie die [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse und übergeben Sie die Präsentation als Argument.
2. Holen Sie sich eine Folienreferenz über ihren Index.
3. Durchlaufen Sie die Formen, um den Platzhalter zu finden.
4. Typkonvertieren Sie die Platzhalterform in eine [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) und ändern Sie den Text mit dem [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) , der mit der [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) verknüpft ist.
5. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt, wie man den Text in einem Platzhalter ändert:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Greift auf den ersten und zweiten Platzhalter in der Folie zu und konvertiert ihn in ein AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"Dies ist ein Platzhalter");
	
// Speichert die Präsentation auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Eingabetext im Platzhalter festlegen**
Standard- und vorgefertigte Layouts enthalten Platzhalter-Eingabetexte wie ***Klicken Sie hier, um einen Titel hinzuzufügen*** oder ***Klicken Sie hier, um einen Untertitel hinzuzufügen***. Mit Aspose.Slides können Sie Ihre bevorzugten Eingabetexte in Platzhalter-Layouts einfügen.

Dieser C++-Code zeigt Ihnen, wie Sie den Eingabetext in einem Platzhalter festlegen:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Wenn kein Text enthalten ist, zeigt PowerPoint "Klicken Sie hier, um einen Titel hinzuzufügen" an. 
        {
            text = u"Klicken Sie hier, um einen Titel hinzuzufügen";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Macht das Gleiche für den Untertitel.
        {
            text = u"Klicken Sie hier, um einen Untertitel hinzuzufügen";
        }
        System::Console::WriteLine(u"Platzhalter : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hintergrundbildtransparenz im Platzhalter festlegen**

Aspose.Slides ermöglicht es Ihnen, die Transparenz des Hintergrundbilds in einem Textplatzhalter festzulegen. Durch das Anpassen der Transparenz des Bildes in einem solchen Rahmen können Sie den Text oder das Bild hervorheben (je nach Farben des Textes und des Bildes).

Dieser C++-Code zeigt Ihnen, wie Sie die Transparenz für einen Bildhintergrund (innerhalb einer Form) festlegen:

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