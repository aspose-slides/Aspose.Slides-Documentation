---
title: PowerPoint-Folien in Bilder konvertieren in C#
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/net/convert-slide/
keywords:
- Folie konvertieren
- Folie in Bild konvertieren
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie zu Bild
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Folien mit Aspose.Slides für .NET in verschiedene Formate konvertieren. Exportieren Sie PPTX- und ODP-Folien einfach in BMP, PNG, JPEG, TIFF und weitere Formate mit hoher Qualität."
---

## **Übersicht**

Aspose.Slides für .NET ermöglicht es Ihnen, PowerPoint‑ und OpenDocument‑Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und weitere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konversionseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Das [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Interface, oder
    - Das [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) Interface.
2. Erzeugen Sie das Folienbild, indem Sie die Methode [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) aufrufen.

In .NET ist ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ein Objekt, das Ihnen die Arbeit mit Bildern ermöglicht, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (BMP, JPG, PNG usw.) zu speichern.

## **Folien in Bitmap konvertieren und die Bilder im PNG-Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen gewünschten Format speichern.

Dieser C#‑Code zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild dann im PNG‑Format speichern:
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


## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Möglicherweise benötigen Sie ein Bild in einer bestimmten Größe. Durch die Verwendung einer Überladung der [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)-Methode können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Breite und Höhe) konvertieren. 

Dieses Beispielcode zeigt, wie das geht:
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

Aspose.Slides stellt zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)—zur Verfügung, mit denen Sie das Rendern von Präsentationsfolien zu Bildern steuern können. Beide Schnittstellen enthalten die Eigenschaft `SlidesLayoutOptions`, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser C#‑Code demonstriert, wie Sie eine Folie mit Notizen und Kommentaren konvertieren:
```cs
float scaleX = 2;
float scaleY = scaleX;

// Präsentationsdatei laden.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Rendering-Optionen erstellen.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Position der Notizen festlegen.
            CommentsPosition = CommentsPositions.Right,      // Position der Kommentare festlegen.
            CommentsAreaWidth = 500,                         // Breite des Kommentarbereichs festlegen.
            CommentsAreaColor = Color.AntiqueWhite           // Farbe des Kommentarbereichs festlegen.
        }
    };

    // Erste Folie der Präsentation in ein Bild konvertieren.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Bild im GIF-Format speichern.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```


{{% alert title="Note" color="warning" %}} 
Im Prozess der Folie‑zu‑Bild‑Konvertierung kann die [NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/)‑Eigenschaft nicht auf `BottomFull` gesetzt werden (um die Position für Notizen festzulegen), da der Text einer Notiz zu groß sein kann und nicht in die angegebene Bildgröße passt.
{{% /alert %}} 

## **Folien mit TIFF-Optionen in Bilder konvertieren**

Die [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) Schnittstelle bietet eine präzisere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieser C#‑Code demonstriert einen Konversionsvorgang, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑Weiß‑Bild mit einer Auflösung von 300 DPI und einer Größe von 2160 × 2800 auszugeben:
```cs
// Präsentationsdatei laden.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Erste Folie aus der Präsentation holen.
    ISlide slide = presentation.Slides[0];

    // Einstellungen des ausgegebenen TIFF-Bildes konfigurieren.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Bildgröße festlegen.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Pixelformat festlegen (schwarz‑weiß).
        DpiX = 300,                                        // Horizontale Auflösung festlegen.
        DpiY = 300                                         // Vertikale Auflösung festlegen.
    };

    // Folie mit den angegebenen Optionen in ein Bild konvertieren.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Bild im TIFF-Format speichern.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es, alle Folien einer Präsentation in Bilder zu konvertieren, wodurch die gesamte Präsentation effektiv in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode zeigt, wie Sie alle Folien einer Präsentation in C# in Bilder konvertieren:
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Präsentation Folie für Folie in Bilder rendern.
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


## **FAQ**

**1. Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `GetImage` speichert nur ein statisches Bild der Folie, ohne Animationen.

**2. Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**3. Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.