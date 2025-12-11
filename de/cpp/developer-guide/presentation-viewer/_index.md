---
title: Erstellen eines Präsentationsbetrachters in C++
linktitle: Präsentationsbetrachter
type: docs
weight: 50
url: /de/cpp/presentation-viewer/
keywords:
- Präsentation anzeigen
- Präsentationsbetrachter
- Präsentationsbetrachter erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie einen benutzerdefinierten Präsentationsbetrachter in C++ mit Aspose.Slides. Zeigen Sie PowerPoint- und OpenDocument-Dateien einfach ohne Microsoft PowerPoint an."
---

Aspose.Slides für C++ wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder ihren eigenen Präsentationsbetrachter erstellen. In solchen Fällen ermöglicht Aspose.Slides den Export einer einzelnen Folie als Bild. Dieser Artikel beschreibt, wie das geht.

## **Ein SVG-Bild aus einer Folie erzeugen**

Um ein SVG-Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Öffnen Sie einen Dateistream.
1. Speichern Sie die Folie als SVG-Bild im Dateistream.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **Ein SVG mit benutzerdefinierter Shape-ID erzeugen**

Aspose.Slides kann verwendet werden, um ein [SVG](https://docs.fileformat.com/page-description-language/svg/) aus einer Folie mit einer benutzerdefinierten Shape-ID zu erzeugen. Verwenden Sie hierfür die `set_Id`‑Methode von [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` kann verwendet werden, um die Shape-ID festzulegen.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **Ein Folien-Thumbnail-Bild erzeugen**

Aspose.Slides unterstützt Sie beim Erzeugen von Miniaturbildern von Folien. Um ein Thumbnail einer Folie mit Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie in einem definierten Maßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Ein Folien-Thumbnail mit benutzerdefinierten Abmessungen erzeugen**

Um ein Folien-Thumbnail mit benutzerdefinierten Abmessungen zu erstellen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den definierten Abmessungen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Ein Folien-Thumbnail mit Sprecher-Notizen erzeugen**

Um das Thumbnail einer Folie mit Sprecher-Notizen mittels Aspose.Slides zu erzeugen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) Klasse.
1. Verwenden Sie die `RenderingOptions.set_SlidesLayoutOptions`‑Methode, um die Position der Sprecher-Notizen festzulegen.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Folienreferenz über ihren Index.
1. Erhalten Sie das Miniaturbild der referenzierten Folie mit den Rendering-Optionen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Live-Beispiel**

Sie können die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) ausprobieren, um zu sehen, was Sie mit der Aspose.Slides‑API umsetzen können:

![Online‑PowerPoint‑Betrachter](online-PowerPoint-viewer.png)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in eine Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig nutzen, um Folien als Bilder oder HTML zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten Betrachter anzuzeigen?**

Der empfohlene Ansatz ist, jede Folie als Bild (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in HTML zu konvertieren und die Ausgabe dann in einer Bild‑Box (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder das Rendern von Folien auf Abruf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher‑ und Ladezeit reduziert werden.