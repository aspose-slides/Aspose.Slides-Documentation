---
title: Präsentationsfolien in .NET in Bilder umwandeln
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT, PPTX und ODP in Bilder in C# mit Aspose.Slides für .NET - schnelle, hochwertige Darstellung mit klaren Codebeispielen."
---
## **Einführung**

Aspose.Slides for .NET ermöglicht Ihnen das einfache Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationsfolien in verschiedene Bildformate, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Das [ITiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/itiffoptions/)‑Interface oder
    - Das [IRenderingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/irenderingoptions/)‑Interface.
2. Erzeugen Sie das Folienbild, indem Sie die [GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/)‑Methode aufrufen.

In .NET ist ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ein Objekt, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (BMP, JPG, PNG usw.) zu speichern.

## **Folien in Bitmaps konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen gewünschten Format speichern.

Der folgende C#‑Code zeigt, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und anschließend im PNG‑Format gespeichert wird:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertiere die erste Folie der Präsentation in ein Bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Speichere das Bild im PNG-Format.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Mit einer Überladung der [GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/)-Methode können Sie eine Folie in ein Bild mit konkreten Abmessungen (Breite und Höhe) konvertieren.

Der folgende Beispielcode demonstriert, wie das geht:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Speichere das Bild im JPEG-Format.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides stellt zwei Interfaces—[ITiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/irenderingoptions/)—zur Verfügung, mit denen Sie die Rendereinstellungen von Präsentationsfolien zu Bildern steuern können. Beide Interfaces enthalten die Eigenschaft `SlidesLayoutOptions`, mit der Sie die Darstellung von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Der folgende C#‑Code zeigt, wie eine Folie mit Notizen und Kommentaren konvertiert wird:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Lade eine Präsentationsdatei.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Erstelle die Renderoptionen.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Setzt die Position der Notizen.
            CommentsPosition = CommentsPositions.Right,      // Setzt die Position der Kommentare.
            CommentsAreaWidth = 500,                         // Setzt die Breite des Kommentarbereichs.
            CommentsAreaColor = Color.AntiqueWhite           // Setzt die Farbe des Kommentarbereichs.
        }
    };

    // Konvertiere die erste Folie der Präsentation in ein Bild.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Speichere das Bild im GIF-Format.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Hinweis" color="warning" %}} 

Im gesamten Folie‑zu‑Bild‑Konvertierungsprozess kann die Eigenschaft [NotesPosition](https://reference.aspose.com/slides/de/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) nicht auf `BottomFull` gesetzt werden (zur Angabe der Position für Notizen), weil der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien in Bilder mit TIFF‑Optionen konvertieren**

Das [ITiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/itiffoptions/)‑Interface bietet erweiterte Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Der folgende C#‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 zu erzeugen:

```cs
// Lade eine Präsentationsdatei.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hole die erste Folie aus der Präsentation.
    ISlide slide = presentation.Slides[0];

    // Konfiguriere die Einstellungen des Ausgabebildes im TIFF-Format.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Setzt die Bildgröße.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Setzt das Pixelformat (schwarz‑weiß).
        DpiX = 300,                                        // Setzt die horizontale Auflösung.
        DpiY = 300                                         // Setzt die vertikale Auflösung.
    };

    // Konvertiere die Folie in ein Bild mit den angegebenen Optionen.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Speichere das Bild im TIFF-Format.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, sodass die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Der folgende Beispielcode zeigt, wie alle Folien einer Präsentation in C# in Bilder konvertiert werden:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Rendern der Präsentation zu Bildern Folie für Folie.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Versteckte Folien steuern (versteckte Folien nicht rendern).
        if (presentation.Slides[i].Hidden)
            continue;

        // Folie in ein Bild konvertieren.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Bild im JPEG-Format speichern.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Farbiges Emoji‑Rendering**

{{% alert title="Hinweis" color="warning" %}} 
Damit farbige Emojis bei der Konvertierung von Präsentationsfolien in Bilder korrekt gerendert werden, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung ausführt, installiert und verfügbar sein. Wenn beispielsweise die Präsentation **Segoe UI Emoji** verwendet und diese Schrift fehlt, können Emojis in den Ausgabebildern monochrom erscheinen.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die `GetImage`‑Methode speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.