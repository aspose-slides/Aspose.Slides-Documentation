---
title: PowerPoint-Präsentationen in C++ in TIFF konvertieren
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
description: "Erfahren Sie, wie Sie PowerPoint (PPT, PPTX) Präsentationen mithilfe von Aspose.Slides für C++ einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Code‑Beispielen."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und detaillierte Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und Originaleinstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint-Folien (PPT, PPTX) und OpenDocument-Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen die maximale visuelle Treue beibehalten.

## **Präsentation in TIFF konvertieren**

Mit der [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)-Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Speichern Sie die Präsentation als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in der Klasse [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) ermöglicht es Ihnen, den bei der Umwandlung einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendeten Algorithmus festzulegen. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Schwarz‑weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit spezifischen Abmessungen benötigen, können Sie die gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die Methode [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) die Definition der Größe des resultierenden Bildes.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Legen Sie den Kompressionstyp fest.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Kompressionstypen:
    Default - Gibt das standardmäßige Kompressionsverfahren an (LZW).
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

// Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


## **Präsentation in TIFF mit benutzerdefiniertem Bild-Pixel-Format konvertieren**

Mit der Methode [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) der Klasse [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
    Format1bppIndexed - 1 Bit pro Pixel, indiziert.
    Format4bppIndexed - 4 Bits pro Pixel, indiziert.
    Format8bppIndexed - 8 Bits pro Pixel, indiziert.
    Format24bppRgb    - 24 Bits pro Pixel, RGB.
    Format32bppArgb   - 32 Bits pro Pixel, ARGB.
*/

// Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


{{% alert title="Tipp" color="primary" %}}
Probieren Sie den KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter von Aspose aus: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt einer gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung für die Anzahl der Folien bei der Konvertierung einer Präsentation in TIFF?**

Nein, Aspose.Slides setzt keinerlei Beschränkungen für die Folienzahl. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.