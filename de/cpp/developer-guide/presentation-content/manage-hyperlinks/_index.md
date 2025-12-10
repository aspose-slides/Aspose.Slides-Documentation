---
title: Verwalten von Präsentations-Hyperlinks in C++
linktitle: Hyperlink verwalten
type: docs
weight: 20
url: /de/cpp/manage-hyperlinks/
keywords:
- URL hinzufügen
- Hyperlink hinzufügen
- Hyperlink erstellen
- Hyperlink formatieren
- Hyperlink entfernen
- Hyperlink aktualisieren
- Text-Hyperlink
- Folien-Hyperlink
- Form-Hyperlink
- Bild-Hyperlink
- Video-Hyperlink
- Veränderlicher Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Hyperlinks in PowerPoint- und OpenDocument-Präsentationen mühelos mit Aspose.Slides für C++ – steigern Sie Interaktivität und Arbeitsabläufe in Minuten."
---

Ein Hyperlink ist eine Referenz zu einem Objekt oder Daten oder einem Ort in etwas. Dies sind gängige Hyperlinks in PowerPoint‑Präsentationen:

* Links zu Websites in Texten, Formen oder Medien
* Links zu Folien

Aspose.Slides für C++ ermöglicht Ihnen die Ausführung vieler Aufgaben im Zusammenhang mit Hyperlinks in Präsentationen. 

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose Simple ausprobieren, den [kostenlosen Online-PowerPoint-Editor.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **URL-Hyperlinks hinzufügen**

### **URL-Hyperlinks zu Text hinzufügen**

Dieser C++‑Code zeigt Ihnen, wie Sie einem Text einen Website‑Hyperlink hinzufügen:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


### **URL-Hyperlinks zu Formen oder Rahmen hinzufügen**

Dieser Beispielcode in C++ zeigt Ihnen, wie Sie einer Form einen Website‑Hyperlink hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


### **URL-Hyperlinks zu Medien hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Hyperlinks zu Bildern, Audiodateien und Videodateien. 

Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Bild** hinzufügen:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Fügt ein Bild zur Präsentation hinzu
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Erstellt Bildrahmen auf Folie 1 basierend auf dem zuvor hinzugefügten Bild
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einer **Audiodatei** hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


Dieser Beispielcode zeigt Ihnen, wie Sie einen Hyperlink zu einem **Video** hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


{{%  alert  title="Tip"  color="primary"  %}} 

Vielleicht möchten Sie *[Manage OLE](https://docs.aspose.com/slides/cpp/manage-ole/)* sehen.

{{% /alert %}}

## **Hyperlinks zum Erstellen eines Inhaltsverzeichnisses verwenden**

Da Hyperlinks das Hinzufügen von Verweisen zu Objekten oder Orten ermöglichen, können Sie sie zum Erstellen eines Inhaltsverzeichnisses verwenden. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Inhaltsverzeichnis mit Hyperlinks erstellen:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **Hyperlinks formatieren**

### **Farbe**

Mit den Methoden [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) und [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) im Interface [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink) können Sie die Farbe für Hyperlinks festlegen und auch Farbinformationen von Hyperlinks abrufen. Die Funktion wurde erstmals in PowerPoint 2019 eingeführt, sodass Änderungen an dieser Eigenschaft nicht für ältere PowerPoint‑Versionen gelten.

Dieser Beispielcode demonstriert eine Operation, bei der Hyperlinks mit verschiedenen Farben zur gleichen Folie hinzugefügt wurden:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **Hyperlinks aus Präsentationen entfernen**

### **Hyperlinks aus Text entfernen**

Dieser C++‑Code zeigt Ihnen, wie Sie den Hyperlink aus einem Text in einer Präsentationsfolie entfernen:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


### **Hyperlinks aus Formen oder Rahmen entfernen**

Dieser C++‑Code zeigt Ihnen, wie Sie den Hyperlink aus einer Form in einer Präsentationsfolie entfernen: 
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


## **Veränderbarer Hyperlink**

Die Klasse [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) ist veränderlich. Mit dieser Klasse können Sie die Werte für die folgenden Methoden ändern:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Das Code‑Snippet zeigt Ihnen, wie Sie einer Folie einen Hyperlink hinzufügen und dessen Tooltip später bearbeiten:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


## **Unterstützte Methoden in IHyperlinkQueries**

Sie können IHyperlinkQueries aus einer Präsentation, Folie oder einem Text abrufen, für den der Hyperlink definiert ist. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Die Klasse IHyperlinkQueries unterstützt folgende Methoden: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Wie kann ich eine interne Navigation nicht nur zu einer Folie, sondern zu einer "Abschnitt" oder der ersten Folie eines Abschnitts erstellen?**

Abschnitte in PowerPoint sind Gruppierungen von Folien; die Navigation zielt technisch auf eine bestimmte Folie ab. Um zu einem Abschnitt zu navigieren, verlinken Sie normalerweise zu dessen erster Folie.

**Kann ich einen Hyperlink an Elemente der Master‑Folie anhängen, sodass er auf allen Folien funktioniert?**

Ja. Elemente der Master‑Folie und des Layouts unterstützen Hyperlinks. Derartige Links erscheinen auf den Folien‑Kindern und sind während der Bildschirmanzeige anklickbar.

**Werden Hyperlinks beim Exportieren in PDF, HTML, Bilder oder Video beibehalten?**

In [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/) und [HTML](/slides/de/cpp/convert-powerpoint-to-html/) ja – Links werden normalerweise erhalten. Beim Exportieren zu [Bildern](/slides/de/cpp/convert-powerpoint-to-png/) und [Video](/slides/de/cpp/convert-powerpoint-to-video/) wird die Anklickbarkeit nicht übernommen, da diese Formate (Raster‑Frames/Video) keine Hyperlinks unterstützen.