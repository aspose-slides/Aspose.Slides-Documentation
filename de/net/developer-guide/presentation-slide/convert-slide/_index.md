---
title: Präsentationsfolien in .NET in Bilder konvertieren
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
description: "Konvertieren Sie Folien von PPT, PPTX und ODP zu Bildern in C# mit Aspose.Slides für .NET—schnelle, hochwertige Darstellung mit klaren Codebeispielen."
---

## **Übersicht**

Aspose.Slides für .NET ermöglicht es Ihnen, PowerPoint- und OpenDocument-Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Schnittstelle, oder
    - Die [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) Schnittstelle.
2. Erzeugen Sie das Folienbild, indem Sie die [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) Methode aufrufen.

In .NET ist ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ein Objekt, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmaps konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG‑Format oder einem anderen gewünschten Format speichern.

Dieser C#‑Code zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild anschließend im PNG‑Format speichern:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertiert die erste Folie der Präsentation in ein Bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Speichert das Bild im PNG-Format.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Mit einer Überladung der [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)‑Methode können Sie eine Folie in ein Bild mit speziellen Abmessungen (Breite und Höhe) konvertieren. 

Dieser Beispielcode demonstriert, wie das geht:
```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konvertiert die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Speichert das Bild im JPEG-Format.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```


## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides bietet zwei Schnittstellen – [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) –, mit denen Sie das Rendern von Präsentationsfolien zu Bildern steuern können. Beide Schnittstellen enthalten die Eigenschaft `SlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser C#‑Code zeigt, wie Sie eine Folie mit Notizen und Kommentaren konvertieren:
```cs
float scaleX = 2;
float scaleY = scaleX;

// Lade eine Präsentationsdatei.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Erstelle die Rendering-Optionen.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Setze die Position der Notizen.
            CommentsPosition = CommentsPositions.Right,      // Setze die Position der Kommentare.
            CommentsAreaWidth = 500,                         // Setze die Breite des Kommentarbereichs.
            CommentsAreaColor = Color.AntiqueWhite           // Setze die Farbe des Kommentarbereichs.
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


{{% alert title="Note" color="warning" %}} 

In jedem Folie‑zu‑Bild‑Konvertierungsprozess kann die [NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/)‑Eigenschaft nicht auf `BottomFull` gesetzt werden (um die Position für Notizen festzulegen), da der Text einer Notiz zu groß sein kann, um in die angegebene Bildgröße zu passen.

{{% /alert %}} 

## **Folien in Bilder mit TIFF-Optionen konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Schnittstelle bietet eine größere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpallet und weitere festlegen können.

Dieser C#‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:
```cs
// Lade eine Präsentationsdatei.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Hole die erste Folie aus der Präsentation.
    ISlide slide = presentation.Slides[0];

    // Konfiguriere die Einstellungen des Ausgabe-TIFF-Bildes.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Bildgröße festlegen.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Pixelformat festlegen (schwarz-weiß).
        DpiX = 300,                                        // Horizontale Auflösung festlegen.
        DpiY = 300                                         // Vertikale Auflösung festlegen.
    };

    // Konvertiere die Folie in ein Bild mit den angegebenen Optionen.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Bild im TIFF-Format speichern.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation effektiv in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie Sie alle Folien einer Präsentation in C# in Bilder konvertieren:
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Rendere die Präsentation zu Bildern Folie für Folie.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Versteckte Folien steuern (versteckte Folien nicht rendern).
        if (presentation.Slides[i].Hidden)
            continue;

        // Konvertiere die Folie in ein Bild.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Speichere das Bild im JPEG-Format.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```


## **FAQ**

**1. Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die `GetImage`‑Methode speichert nur ein statisches Bild der Folie, ohne Animationen.

**2. Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können genauso wie reguläre verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**3. Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen Grafikeffekten beim Speichern von Folien als Bilder.