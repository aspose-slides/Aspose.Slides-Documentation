---
title: "PowerPoint-Präsentationen in TIFF konvertieren in C++"
titlelink: "PowerPoint zu TIFF"
type: docs
weight: 90
url: /de/cpp/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint konvertieren"
- "OpenDocument konvertieren"
- "Präsentation konvertieren"
- "Folie konvertieren"
- "PPT konvertieren"
- "PPTX konvertieren"
- "PowerPoint zu TIFF"
- "Präsentation zu TIFF"
- "Folie zu TIFF"
- "PPT zu TIFF"
- "PPTX zu TIFF"
- "PPT als TIFF speichern"
- "PPTX als TIFF speichern"
- "PPT nach TIFF exportieren"
- "PPTX nach TIFF exportieren"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie PowerPoint (PPT, PPTX)-Präsentationen einfach in hochwertige TIFF-Bilder mithilfe von Aspose.Slides für C++ konvertieren, inklusive Codebeispielen."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rastergrafikformat, das für seine außergewöhnliche Qualität und detaillierte Bildtreue bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbtiefe und originale Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen maximale visuelle Treue behalten.

## **Präsentation in TIFF konvertieren**

Mit der [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:
```cpp
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in der [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)‑Klasse ermöglicht das Festlegen des Algorithmus, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur wirksam ist, wenn die [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben die Datei „sample.pptx“ mit folgender Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser C++‑Code demonstriert, wie die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert wird:
```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Schwarz‑weiß TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über die Methoden der [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)‑Klasse festlegen. Beispielsweise ermöglicht die [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑Methode die Definition der Größe des resultierenden Bildes.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP, usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Setzen Sie den Kompressionstyp.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Kompressionstypen:
    Default - Gibt das Standardskompressionsschema (LZW) an.
    None - Gibt keine Kompression an.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell eingestellt werden.

// Seten Sie die Bild-DPI.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Seten Sie die Bildgröße.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


## **Präsentation in TIFF mit benutzerdefiniertem Pixel‑Format konvertieren**

Mit der [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑Methode der [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)‑Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:
```cpp
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
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


{{% alert title="Tipp" color="primary" %}}
Entdecken Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht das separate Konvertieren einzelner Folien aus PowerPoint‑ und OpenDocument‑Präsentationen in TIFF‑Bilder.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht übernommen; es wird nur ein statischer Schnappschuss der Folien exportiert.