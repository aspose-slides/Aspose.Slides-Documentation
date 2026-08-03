---
title: Konvertieren von Präsentationsfolien in Bilder in C++
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
description: "Konvertieren Sie Folien von PPT, PPTX und ODP in Bilder in C++ mit Aspose.Slides – schnelle, hochwertige Darstellung mit klaren Codebeispielen."
---
## **Einleitung**

Aspose.Slides für C++ ermöglicht es Ihnen, PowerPoint- und OpenDocument-Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [ITiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die Methode [GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/) aufrufen.

Ein [Bitmap](https://reference.aspose.com/slides/de/cpp/system.drawing/bitmap/) ist ein Objekt, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap-Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG- oder einem anderen gewünschten Format speichern.

Dieser C++‑Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format gespeichert wird:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertiere die erste Folie der Präsentation in ein Bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Speichere das Bild im PNG-Format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Mit einer Überladung der [GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/getimage/) Methode können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren.

Dieses Beispielcode zeigt, wie das geht:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Speichere das Bild im JPEG-Format.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/irenderingoptions/)—zur Verfügung, mit denen Sie die Rendering‑Optionen von Präsentationsfolien zu Bildern steuern können. Beide Schnittstellen enthalten die Methode `set_SlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser C++‑Code zeigt, wie eine Folie mit Notizen und Kommentaren konvertiert wird:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Lade eine Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Setze die Position der Notizen.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Setze die Position der Kommentare.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Setze die Breite des Kommentarbereichs.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Setze die Farbe des Kommentarbereichs.

// Erstelle die Rendering-Optionen.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konvertiere die erste Folie der Präsentation in ein Bild.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Speichere das Bild im GIF-Format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Bei jedem Folie‑zu‑Bild-Konvertierungsprozess kann die Methode [set_NotesPosition](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) kein `BottomFull` anwenden (zur Angabe der Position für Notizen), weil der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.
{{% /alert %}} 

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/itiffoptions/) Schnittstelle bietet mehr Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und weitere festlegen können.

Dieser C++‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:

```cpp 
// Lade eine Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Hole die erste Folie aus der Präsentation.
auto slide = presentation->get_Slide(0);

// Konfiguriere die Einstellungen des ausgegebenen TIFF-Bildes.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Setze die Bildgröße.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Setze das Pixelformat (schwarz-weiß).
tiffOptions->set_DpiX(300);                                         // Setze die horizontale Auflösung.
tiffOptions->set_DpiY(300);                                         // Setze die vertikale Auflösung.

// Konvertiere die Folie in ein Bild mit den angegebenen Optionen.
auto image = slide->GetImage(tiffOptions);

// Speichere das Bild im TIFF-Format.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie alle Folien einer Präsentation in C++ in Bilder konvertiert werden:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render die Präsentation Folie für Folie in Bilder.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Steuere ausgeblendete Folien (nicht rendern).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konvertiere die Folie in ein Bild.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Speichere das Bild im JPEG-Format.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Rendering von farbigen Emojis**

{{% alert title="Note" color="warning" %}} 
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise kann es vorkommen, dass Emojis in den Ausgabebildern monochrom dargestellt werden, wenn die Präsentation die Schrift **Segoe UI Emoji** verwendet und diese Schrift fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**  
Nein, die Methode `GetImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**  
Ja, ausgeblendete Folien können genauso wie reguläre verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**  
Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen Grafikeffekten beim Speichern von Folien als Bilder.