---
title: Präsentationsbetrachter
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: 
- PowerPoint-Präsentation anzeigen
- ppt anzeigen
- PPTX anzeigen
- C++
- Aspose.Slides für C++
description: "PowerPoint-Präsentation in C++ anzeigen"
---

## **SVG-Bild aus Folie generieren**
Aspose.Slides für C++ wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können durch das Öffnen von Präsentationen mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch auch Folien als SVG-Bilder in ihrem bevorzugten Bildbetrachter anzeigen. In solchen Fällen erlaubt es Aspose.Slides für C++, eine einzelne Folie in ein SVG-Bild zu exportieren. Dieser Artikel beschreibt, wie Sie diese Funktion nutzen können. Um ein SVG-Bild aus einer gewünschten Folie mit Aspose.Slides.Pptx für C++ zu generieren, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz der gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
- Holen Sie sich das SVG-Bild in einem Speicherstream.
- Speichern Sie den Speicherstream in einer Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **SVG mit benutzerdefinierten Form-IDs generieren**
Jetzt kann Aspose.Slides für C++ verwendet werden, um SVG aus Folien mit benutzerdefinierter Form-ID zu generieren. Diese Folien können durch das Öffnen von Präsentationen mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch auch Folien als SVG-Bilder in ihrem bevorzugten Bildbetrachter anzeigen. In solchen Fällen erlaubt es Aspose.Slides für C++, eine einzelne Folie in ein SVG-Bild zu exportieren. Zu diesem Zweck wurde die ID-Eigenschaft zu ISvgShape hinzugefügt, um benutzerdefinierte IDs von Formen im generierten SVG zu unterstützen. Um diese Funktion zu implementieren, wurde ein CustomSvgShapeFormattingController eingeführt, den Sie verwenden können, um die Form-ID festzulegen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **Thumbnail-Bild von Folie erstellen**
Aspose.Slides für C++ wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können durch das Öffnen von Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch Folien als Bilder mit ihrem bevorzugten Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides für C++, Thumbnail-Bilder der Folien zu generieren. Um das Thumbnail einer gewünschten Folie mit Aspose.Slides für C++ zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem beliebigen gewünschten Bildformat.

```cpp
// Instanziieren Sie die Presentation-Klasse
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// Greifen Sie auf die erste Folie zu
auto slide = presentation->get_Slide(0);

// Erstellen Sie ein Bild im Vollmaßstab
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Thumbnail mit benutzerdefinierten Abmessungen erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab.
1. Speichern Sie das Thumbnail-Bild in einem beliebigen gewünschten Bildformat.

```cpp
// Instanziieren Sie die Presentation-Klasse
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// Greifen Sie auf die erste Folie zu
auto slide = presentation->get_Slide(0);

// Benutzerdefinierte Abmessungen
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Skalierter Wert von X und Y erhalten
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Erstellen Sie ein Bild mit benutzerdefinierten Maßstab
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Thumbnail von Folie im Notizen-Folienansicht erstellen**
Um das Thumbnail einer gewünschten Folie in der Notizen-Folienansicht mit Aspose.Slides für C++ zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie die Referenz einer gewünschten Folie, indem Sie ihre ID oder ihren Index verwenden.
1. Holen Sie sich das Thumbnail-Bild der referenzierten Folie in einem bestimmten Maßstab in der Notizen-Folienansicht.
1. Speichern Sie das Thumbnail-Bild in einem beliebigen gewünschten Bildformat.

Der folgende Codeschnipsel erzeugt ein Thumbnail der ersten Folie einer Präsentation in der Notizen-Folienansicht.

```cpp
// Instanziieren Sie die Presentation-Klasse
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// Greifen Sie auf die erste Folie zu
auto slide = presentation->get_Slide(0);

// Benutzerdefinierte Abmessungen
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// Skalierter Wert von X und Y erhalten
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// Erstellen Sie ein Bild im Vollmaßstab
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```