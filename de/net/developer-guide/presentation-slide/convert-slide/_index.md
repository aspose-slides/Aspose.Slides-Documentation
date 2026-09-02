---
title: Folien einer Präsentation in .NET in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/net/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu EMF
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
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP‑Präsentationen in PNG, JPEG, GIF, TIFF, EMF und andere Bildformate in C# mit Aspose.Slides für .NET."
---
## **Einleitung**

Aspose.Slides für .NET kann einzelne Folien aus PowerPoint- und OpenDocument-Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse.
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls nötig, konfigurieren Sie das Rendering mit der [RenderingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/renderingoptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/) Klasse.
4. Rufen Sie die Methode [GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/) auf. Sie gibt ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) Objekt zurück.
5. Rufen Sie die Methode [IImage.Save](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/save/) auf und geben Sie das Ausgabeformat mit einem [ImageFormat](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/) Wert an.

## **Eine Folie in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die standardmäßigen Rendering‑Einstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) Objekt kann im Speicher verarbeitet oder in eine Datei gespeichert werden.

Das folgende C#‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Verwenden Sie die [GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/) Überladung, die einen [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) Wert akzeptiert, um eine Folie mit genauen Pixelmaßen zu rendern.

Das folgende Beispiel erstellt ein 1820 × 1040 JPEG‑Bild:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Weisen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/) Objekt der Eigenschaft [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) zu, um zu steuern, wo Notizen und Kommentare erscheinen.

Das folgende Beispiel platziert gekürzte Notizen unterhalb der Folie und Kommentare rechts davon:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Für die Folie‑zu‑Bild‑Konvertierung setzen Sie die Eigenschaft [NotesPosition](https://reference.aspose.com/slides/de/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) nicht auf [BottomFull](https://reference.aspose.com/slides/de/net/aspose.slides.export/notespositions/). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [BottomTruncated](https://reference.aspose.com/slides/de/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/) ermöglicht es, Größe, Auflösung und weitere Eigenschaften des gerenderten TIFF‑Bildes zu steuern.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880 TIFF‑Bild mit 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Alle Folien in Bilder konvertieren**

Iterieren Sie über die Folien‑Sammlung, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Versteckte Folien werden einbezogen, sofern Sie sie nicht explizit überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Enhanced‑Metafile‑Ausgabe erstellen**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierten Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen ausgetauscht werden müssen, die Windows‑Metadateien unterstützen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektor‑Zeichenvorgänge beibehalten, die sich skalieren lassen, ohne dass die Schärfe verloren geht. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metadatei‑Unterstützung und kein universelles Austauschformat. Darüber hinaus kann komplexer Folieninhalt, wie Bitmap‑Bilder und einige Effekte, als gerasterte Elemente im Vektor‑Metadatei‑Container gespeichert werden.

### **Eine Folie als EMF exportieren**

Die Methode [ISlide.WriteAsEmf](https://reference.aspose.com/slides/de/net/aspose.slides/islide/writeasemf/) schreibt ein [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/) in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Der Aufrufer besitzt den an [ISlide.WriteAsEmf](https://reference.aspose.com/slides/de/net/aspose.slides/islide/writeasemf/) übergebenen Stream und muss ihn schließen oder freigeben. Aspose.Slides schreibt an der aktuellen Position des Streams und lässt den Stream geöffnet.

### **Ein SVG‑Bild in EMF konvertieren und einer Präsentation hinzufügen**

Verwenden Sie [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/writeasemf/) um SVG‑Inhalte in EMF zu konvertieren. Die resultierenden Bytes können über [IImageCollection.AddImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection/addimage/) zur Präsentation hinzugefügt und mit [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/net/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF‑Bild im Speicher, fügt die Metadatei auf der ersten Folie ein und speichert die Präsentation:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/de/net/aspose.slides/isvgimage/writeasemf/) übernimmt den Ziel‑Stream nicht. Nach dem Schreiben befindet sich die Stream‑Position am Ende der erzeugten Daten. Setzen Sie `Position` auf den Anfang, bevor Sie denselben seek‑fähigen Stream einem Leser übergeben, wie oben gezeigt. Halten Sie den Stream geöffnet, bis der Verbraucher das Lesen abgeschlossen hat, und geben Sie ihn anschließend frei. Alternativ rufen Sie `ToArray` auf und übergeben das zurückgegebene Byte‑Array an [IImageCollection.AddImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimagecollection/addimage/); `ToArray` liefert den vollständigen Puffer, unabhängig von der aktuellen Stream‑Position.

EMF‑Generierung ist auf den von der gewählten Aspose.Slides‑für‑.NET‑Build unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering auf verschiedenen Plattformen variieren, wenn Schriften oder native Grafik‑Abhängigkeiten nicht vorhanden sind. Installieren Sie die von den Quellinhalten verwendeten Schriften oder konfigurieren Sie geeignete Ersatzschriften, folgen Sie den [Plattformanforderungen](/slides/de/net/system-requirements/) für Ihr Aspose.Slides‑Paket und prüfen Sie das Ergebnis in der Ziel‑EMF‑verarbeitenden Anwendung. Linux‑ und macOS‑Anwendungen haben oft nur begrenzte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metadateien.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um farbige Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise können Emojis in monochrom erscheinen, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schrift fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können versteckte Folien als Bilder exportiert werden?**

Ja. Versteckte Folien können wie reguläre Folien gerendert werden. Binden Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern beibehalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.