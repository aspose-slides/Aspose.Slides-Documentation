---
title: PowerPoint-Präsentationen nach TIFF konvertieren in C++
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mit Aspose.Slides für C++ einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Code‑Beispielen."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rastergrafikformat, das für seine außergewöhnliche Qualität und die detailgetreue Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie mühelos Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) direkt in hochwertige TIFF‑Bilder konvertieren und dabei sicherstellen, dass Ihre Präsentationen maximale visuelle Treue bewahren.

## **Präsentation in TIFF konvertieren**

Durch die Verwendung der [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF umwandeln. Die entstehenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Speichern Sie die Präsentation als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Präsentation in Schwarzweiß‑TIFF konvertieren**

Die Methode [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in der [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)‑Klasse ermöglicht es Ihnen, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarzweiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur wirkt, wenn die [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![A presentation slide](slide_black_and_white.png)

Dieser C++‑Code zeigt, wie die farbige Folie in ein Schwarzweiß‑TIFF konvertiert wird:
```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie Ihre gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise erlaubt die [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑Methode die Definition der Größe des resultierenden Bildes.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit einer benutzerdefinierten Größe konvertiert wird:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Legen Sie den Kompressionstyp fest.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Kompressionstypen:
    Default - Gibt das standardmäßige Kompressionsschema (LZW) an.
    None - Gibt an, dass keine Kompression verwendet wird.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

// Legen Sie die Bild-DPI fest.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Legen Sie die Bildgröße fest.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation as TIFF with the specified size.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑Methode der [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)‑Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit einem benutzerdefinierten Pixel‑Format konvertiert wird:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
    Format1bppIndexed - 1 Bit pro Pixel, indiziert.
    Format4bppIndexed - 4 Bit pro Pixel, indiziert.
    Format8bppIndexed - 8 Bit pro Pixel, indiziert.
    Format24bppRgb    - 24 Bit pro Pixel, RGB.
    Format32bppArgb   - 32 Bit pro Pixel, ARGB.
*/

// Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


{{% alert title="Tip" color="primary" %}}
Entdecken Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kann ich anstatt einer gesamten PowerPoint‑Präsentation ein einzelnes Folienbild in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Folienanzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format umwandeln.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien zu TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht übernommen; es werden nur statische Schnappschüsse der Folien exportiert.