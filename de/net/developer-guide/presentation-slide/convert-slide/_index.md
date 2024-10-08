---
title: Folie konvertieren
type: docs
weight: 41
url: /net/convert-slide/
keywords: 
- folie in bild konvertieren
- folie als bild exportieren
- folie als bild speichern
- folie zu bild
- folie zu PNG
- folie zu JPEG
- folie zu bitmap
- C#
- Csharp
- .NET
- Aspose.Slides für .NET
description: "Konvertieren Sie PowerPoint-Folien in Bilder (Bitmap, PNG oder JPG) in C# oder .NET"
---

Aspose.Slides für .NET ermöglicht es Ihnen, Folien (in Präsentationen) in Bilder zu konvertieren. Dies sind die unterstützten Bildformate: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, tun Sie Folgendes:

1. Zuerst legen Sie die Konvertierungsparameter und die Folienobjekte fest, die konvertiert werden sollen, mit:
   * der [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) Schnittstelle oder
   * der [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) Schnittstelle.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) Methode verwenden.

## **Über Bitmap und andere Bildformate**

In .NET ist ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ein Objekt, das es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (BMP, JPG, PNG usw.) zu speichern.

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online-[Text to GIF](https://products.aspose.app/slides/text-to-gif) Konverter entwickelt.

{{% /alert %}}

## **Konvertieren von Folien in Bitmap und Speichern der Bilder im PNG-Format**

Dieser C#-Code zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und dann das Bild im PNG-Format speichern:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Konvertiert die erste Folie in der Präsentation in ein Bitmap-Objekt
    using (IImage image = pres.Slides[0].GetImage())
    {
        // Speichert das Bild im PNG-Format
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Tipp" color="primary" %}}

Sie können eine Folie in ein Bitmap-Objekt konvertieren und dann das Objekt direkt irgendwo verwenden. Oder Sie können eine Folie in ein Bitmap konvertieren und dann das Bild im JPEG- oder in einem anderen beliebigen Format speichern.

{{% /alert %}}

## **Konvertieren von Folien in Bilder mit benutzerdefinierten Größen**

Möglicherweise müssen Sie ein Bild einer bestimmten Größe erhalten. Mit einer Überladung von [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode demonstriert die vorgeschlagene Konvertierung mit der [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) Methode in C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Konvertiert die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // Speichert das Bild im JPEG-Format
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Konvertieren von Folien mit Notizen und Kommentaren in Bilder**

Einige Folien enthalten Notizen und Kommentare.

Aspose.Slides bietet zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) und [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Schnittstellen enthalten die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) Schnittstelle, die es Ihnen erlaubt, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}}

Mit der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) Schnittstelle können Sie Ihre bevorzugte Position für Notizen und Kommentare im resultierenden Bild festlegen.

{{% /alert %}}

Dieser C#-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen und Kommentaren:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Erstellt die Rendering-Optionen
    IRenderingOptions options = new RenderingOptions();

    // Legt die Position der Notizen auf der Seite fest
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Legt die Position der Kommentare auf der Seite fest
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Legt die Breite des Kommentarausgabebereichs fest
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // Legt die Farbe für den Kommentarausgabebereich fest
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // Konvertiert die erste Folie der Präsentation in ein Bitmap-Objekt
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // Speichert das Bild im GIF-Format
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Hinweis" color="warning" %}}

In jedem Prozess, in dem Folien in Bilder konvertiert werden, kann die [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) Eigenschaft nicht auf BottomFull gesetzt werden (um die Position für Notizen festzulegen), da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}}

## **Konvertieren von Folien in Bilder unter Verwendung von ITiffOptions**

Die [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) Schnittstelle gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mit dieser Schnittstelle können Sie die Größe, Auflösung, Farbpalette und andere Parameter für das resultierende Bild festlegen.

Dieser C#-Code demonstriert einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein schwarz-weiß Bild mit einer Auflösung von 300dpi und einer Größe von 2160 × 2800 zu erzeugen:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Holt eine Folie nach ihrem Index
    ISlide slide = pres.Slides[0];

    // Erstellt ein TiffOptions-Objekt
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // Legt die Schriftart fest, die verwendet wird, falls die Quellschriftart nicht gefunden wird
    options.DefaultRegularFont = "Arial Black";

    // Legt die Position der Notizen auf der Seite fest
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Legt das Pixel-Format (schwarz-weiß) fest
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Legt die Auflösung fest
    options.DpiX = 300;
    options.DpiY = 300;

    // Konvertiert die Folie in ein Bitmap-Objekt
    using (IImage image = slide.GetImage(options))
    {
        // Speichert das Bild im BMP-Format
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzigen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die gesamte Präsentation in Bilder konvertieren.

Dieser Beispielcode zeigt Ihnen, wie Sie alle Folien in einer Präsentation in Bilder in C# konvertieren:

```csharp
// Gibt den Pfad zum Ausgabeverzeichnis an
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Rendert die Präsentation Folie für Folie in Array von Bildern
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // Gibt die Einstellung für versteckte Folien an (versteckte Folien nicht rendern)
        if (pres.Slides[i].Hidden)
            continue;

        // Konvertiert die Folie in ein Bitmap-Objekt
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // Erstellt einen Dateinamen für ein Bild
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Speichert das Bild im JPEG-Format
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```