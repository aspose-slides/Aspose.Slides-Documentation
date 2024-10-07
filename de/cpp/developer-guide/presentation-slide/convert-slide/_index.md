---
title: Folie konvertieren
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- folie in bild konvertieren
- folie als bild exportieren
- folie als bild speichern
- folie in bild
- folie in PNG
- folie in JPEG
- folie in bitmap
- C++
- Aspose.Slides für C++
description: "Konvertieren Sie PowerPoint-Folien in Bilder (Bitmap, PNG oder JPG) in C++"
---

Aspose.Slides für C++ ermöglicht es Ihnen, Folien (in Präsentationen) in Bilder zu konvertieren. Dies sind die unterstützten Bildformate: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, tun Sie Folgendes:

1. Zuerst legen Sie die Konvertierungsparameter und die zu konvertierenden Folienobjekte fest, indem Sie:
   * die [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) Schnittstelle oder
   * die [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) Schnittstelle verwenden.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) Methode verwenden.

## **Über Bitmap und andere Bildformate**

Ein [Bitmap](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) ist ein Objekt, das es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixel-Daten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten (BMP, JPG, PNG usw.) zu speichern.

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter entwickelt.

{{% /alert %}}

## **Konvertieren von Folien in Bitmap und Speichern der Bilder im PNG-Format**

Dieser C++-Code zeigt Ihnen, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und dann das Bild im PNG-Format speichern:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Konvertieren Sie die erste Folie der Präsentation in ein Bitmap-Objekt
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// Speichern Sie das Bild im PNG-Format
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="Tipp" color="primary" %}} 

Sie können eine Folie in ein Bitmap-Objekt konvertieren und das Objekt dann direkt irgendwo verwenden. Oder Sie können eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG- oder einem anderen von Ihnen bevorzugten Format speichern.

{{% /alert %}}  

## **Konvertieren von Folien in Bilder mit benutzerdefinierten Größen**

Es kann sein, dass Sie ein Bild einer bestimmten Größe benötigen. Mit einer Überladung von [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode zeigt die vorgeschlagene Konvertierung mit der [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) Methode in C++:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Konvertiert die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// Speichert das Bild im JPEG-Format
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **Konvertieren von Folien mit Notizen und Kommentaren in Bilder**

Einige Folien enthalten Notizen und Kommentare.

Aspose.Slides bietet zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) und [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)—die Ihnen die Kontrolle über das Rendern von Präsentationsfolien zu Bildern ermöglichen. Beide Schnittstellen beinhalten die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) Schnittstelle, die es Ihnen ermöglicht, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}} 

Mit der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) Schnittstelle können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild angeben.

{{% /alert %}} 

Dieser C++-Code zeigt den Konvertierungsprozess für eine Folie mit Notizen und Kommentaren:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// Erstellt die Rendering-Optionen
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// Legt die Position der Notizen auf der Seite fest
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// Legt die Position der Kommentare auf der Seite fest
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// Legt die Breite des Kommentarausgabebereichs fest
notesCommentsLayouting->set_CommentsAreaWidth(500);
// Legt die Farbe für den Kommentarausgabebereich fest
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Konvertiert die erste Folie der Präsentation in ein Bitmap-Objekt
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// Speichert das Bild im GIF-Format
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="Hinweis" color="warning" %}} 

In jedem Konvertierungsprozess von Folien zu Bildern können Sie den Wert BottomFull (zur Angabe der Position für Notizen) nicht an die [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) Methode übergeben, da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}} 

## **Konvertieren von Folien in Bilder mit ITiffOptions**

Die [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) Schnittstelle gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mit dieser Schnittstelle können Sie die Größe, Auflösung, Farbpalette und andere Parameter für das resultierende Bild angeben.

Dieser C++-Code demonstriert einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein schwarz-weiß Bild mit einer Auflösung von 300dpi und einer Größe von 2160 × 2800 zu erzeugen:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Holen Sie sich eine Folie nach ihrem Index
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Erstellen Sie ein TiffOptions-Objekt
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Legen Sie die Schriftart fest, die verwendet wird, falls die Quellschriftart nicht gefunden wird
options->set_DefaultRegularFont(u"Arial Black");

// Legen Sie die Position der Notizen auf der Seite fest
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Legen Sie das Pixel-Format (schwarz-weiß) fest
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Legen Sie die Auflösung fest
options->set_DpiX(300);
options->set_DpiY(300);

// Konvertieren Sie die Folie in ein Bitmap-Objekt
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// Speichern Sie das Bild im BMP-Format
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzigen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die gesamte Präsentation in Bilder konvertieren.

Dieser Beispielcode zeigt Ihnen, wie Sie alle Folien in einer Präsentation in Bilder in C++ konvertieren:

``` cpp 
// Pfad zum Ausgabeverzeichnis
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Rendert die Präsentation in ein Array von Bildern, Folie für Folie
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Steuerung versteckter Folien (versteckte Folien nicht rendern)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konvertiert die Folie in ein Bitmap-Objekt
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // Erstellt den Dateinamen für ein Bild
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Speichert das Bild im PNG-Format
    image->Save(outputFilePath, ImageFormat::Png);
}
```