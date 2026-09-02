---
title: Präsentationsfolien in C++ in Bilder konvertieren
linktitle: Folien zu Bild
type: docs
weight: 41
url: /de/cpp/convert-slide/
keywords:
- Folien konvertieren
- Folien exportieren
- Folien zu Bild
- Folien als Bild speichern
- Folien zu EMF
- Folien zu PNG
- Folien zu JPEG
- Folien zu Bitmap
- Folien zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP‑Präsentationen in PNG, JPEG, GIF, TIFF, EMF und andere Bildformate in C++ mit Aspose.Slides für C++."
---
## **Einleitung**

Aspose.Slides für C++ kann einzelne Folien aus PowerPoint- und OpenDocument-Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls erforderlich, konfigurieren Sie das Rendering mit der [RenderingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/renderingoptions/)‑ oder [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/)‑Klasse.
4. Rufen Sie die Methode [ISlide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/) auf. Sie gibt ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt zurück.
5. Rufen Sie die Methode [IImage::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/save/) auf und geben Sie das Ausgabeformat mit einem [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/)‑Wert an.

## **Eine Folie in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die standardmäßigen Rendering‑Einstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt kann im Speicher verarbeitet oder in einer Datei gespeichert werden.

Das folgende C++‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Verwenden Sie die Überladung von [ISlide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/), die einen [Size](https://reference.aspose.com/slides/de/cpp/system.drawing/size/)‑Wert akzeptiert, um eine Folie mit exakt angegebenen Pixelmaßen zu rendern.

Das folgende Beispiel erzeugt ein 1820 × 1040 JPEG‑Bild:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Weisen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Objekt der Methode [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) zu, um zu steuern, wo Notizen und Kommentare erscheinen.

Das folgende Beispiel platziert gekürzte Notizen unterhalb der Folie und Kommentare rechts davon:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Verwenden Sie bei der Folie‑zu‑Bild‑Konvertierung nicht die Methode [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) mit dem Wert [BottomFull](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notespositions/). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/) ermöglicht die Steuerung von Größe, Auflösung und anderen Eigenschaften des gerenderten TIFF‑Bildes.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880‑TIFF‑Bild mit 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Alle Folien in Bilder konvertieren**

Iterieren Sie über die Folien‑Collection, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Ausgeblendete Folien werden einbezogen, sofern Sie sie nicht explizit überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Enhanced Metafile‑Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierte Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen ausgetauscht werden müssen, die Windows‑Metafiles unterstützen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektor‑Zeichenoperationen beibehalten, die ohne gleichen Schärfeverlust skaliert werden können. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metafile‑Unterstützung und kein universelles Austauschformat. Darüber hinaus können komplexe Folieninhalte, wie Bitmap‑Bilder und einige Effekte, als gerasterte Elemente im Vektor‑Metafile‑Container gespeichert werden.

### **Eine Folie nach EMF exportieren**

Die Methode [ISlide::WriteAsEmf](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/writeasemf/) schreibt ein [ISlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/) in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Datei‑Stream:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Der Aufrufer besitzt den an [ISlide::WriteAsEmf](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/writeasemf/) übergebenen Stream und muss ihn schließen oder freigeben. Aspose.Slides schreibt an der aktuellen Position des Streams und lässt den Stream geöffnet.

### **Ein SVG‑Bild in EMF umwandeln und zu einer Präsentation hinzufügen**

Verwenden Sie [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/writeasemf/), um SVG‑Inhalte in EMF zu konvertieren. Die resultierenden Bytes können über [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/) zur Präsentation hinzugefügt und mit [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addpictureframe/) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF im Speicher, fügt das Metafile auf der ersten Folie ein und speichert die Präsentation:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

Die Methode [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/writeasemf/) übernimmt den Ziel‑Stream nicht. Nach dem Schreiben befindet sich die Stream‑Position am Ende der erzeugten Daten. Das Beispiel ruft [MemoryStream::ToArray](https://reference.aspose.com/slides/de/cpp/system.io/memorystream/toarray/) auf, um den vollständigen Puffer unabhängig von der aktuellen Stream‑Position zu erhalten, und übergibt dieses Byte‑Array an [IImageCollection::AddImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/addimage/). Halten Sie den Stream geöffnet, bis der Verbraucher das Lesen abgeschlossen hat, und schließen Sie ihn anschließend.

Die EMF‑Erzeugung ist auf den von Aspose.Slides für C++ unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering auf verschiedenen Plattformen variieren, wenn Schriften oder native Grafikabhängigkeiten nicht verfügbar sind. Installieren Sie die für den Quellinhalt verwendeten Schriften oder konfigurieren Sie geeignete Ersatzschriften, befolgen Sie die [Plattform‑Anforderungen](/slides/de/cpp/system-requirements/) für Aspose.Slides für C++ und überprüfen Sie das Ergebnis in der Ziel‑EMF‑verarbeitenden Anwendung. Linux‑ und macOS‑Anwendungen haben oft nur eingeschränkte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metafiles.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispiel: Wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schrift fehlt, können Emojis in den Ausgabebildern monochrom erscheinen.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [ISlide::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja. Ausgeblendete Folien können wie reguläre Folien gerendert werden. Binden Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern erhalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.