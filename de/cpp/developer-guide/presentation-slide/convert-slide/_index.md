---
title: Präsentationsfolien in C++ in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/cpp/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Folie zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder in C++ mit Aspose.Slides—schnelles, hochwertiges Rendering mit klaren Codebeispielen."
---

## **Übersicht**

Aspose.Slides für C++ ermöglicht es Ihnen, PowerPoint- und OpenDocument‑Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die Methode [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) aufrufen.

Ein [Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) ist ein Objekt, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑Format oder einem anderen gewünschten Format speichern.

Dieser C++‑Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format gespeichert wird:
```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertieren Sie die erste Folie der Präsentation in ein Bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Speichern Sie das Bild im PNG-Format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```


## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Mit einer Überladung der [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) können Sie eine Folie in ein Bild mit konkreten Abmessungen (Breite und Höhe) konvertieren.

Dieser Beispielcode demonstriert, wie das geht:
```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertieren Sie die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Speichern Sie das Bild im JPEG-Format.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```


## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)—zur Verfügung, mit denen Sie die Rendering‑Ausgabe von Präsentationsfolien in Bilder steuern können. Beide Schnittstellen enthalten die Methode `set_SlidesLayoutOptions`, mit der Sie das Rendering von Notizen und Kommentaren einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser C++‑Code zeigt, wie eine Folie mit Notizen und Kommentaren konvertiert wird:
```cpp
float scaleX = 2;
float scaleY = scaleX;

// Laden Sie eine Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Setzen Sie die Position der Notizen.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Setzen Sie die Position der Kommentare.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Setzen Sie die Breite des Kommentarbereichs.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Setzen Sie die Farbe des Kommentarbereichs.

// Erstellen Sie die Rendering-Optionen.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konvertieren Sie die erste Folie der Präsentation in ein Bild.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Speichern Sie das Bild im GIF-Format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```


{{% alert title="Hinweis" color="warning" %}} 

Bei jedem Vorgang zur Konvertierung von Folien in Bilder kann die Methode [set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) `BottomFull` (zur Angabe der Position für Notizen) nicht anwenden, da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Die Schnittstelle [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) bietet eine genauere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpallette und weitere festlegen können.

Dieser C++‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:
```cpp 
// Laden Sie eine Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Holen Sie die erste Folie aus der Präsentation.
auto slide = presentation->get_Slide(0);

// Konfigurieren Sie die Einstellungen des Ausgabe-TIFF-Bildes.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Bildgröße festlegen.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Pixelformat festlegen (schwarz-weiß).
tiffOptions->set_DpiX(300);                                         // Horizontale Auflösung festlegen.
tiffOptions->set_DpiY(300);                                         // Vertikale Auflösung festlegen.

// Folie mit den angegebenen Optionen in ein Bild konvertieren.
auto image = slide->GetImage(tiffOptions);

// Bild im TIFF-Format speichern.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```


## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Bildreihe umgewandelt wird.

Dieser Beispielcode zeigt, wie alle Folien einer Präsentation in C++ in Bilder konvertiert werden:
```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Präsentation Folie für Folie in Bilder rendern.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Versteckte Folien steuern (versteckte Folien nicht rendern).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Folie in ein Bild konvertieren.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Bild im JPEG-Format speichern.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `GetImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.