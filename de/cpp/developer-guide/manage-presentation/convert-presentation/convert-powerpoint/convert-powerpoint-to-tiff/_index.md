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
- PPT zu TIFF exportieren
- PPTX zu TIFF exportieren
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint (PPT, PPTX) Präsentationen mit Aspose.Slides für C++ einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detailgetreue Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop‑Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren und dabei sicherstellen, dass Ihre Präsentationen maximale visuelle Treue bewahren.

## **Eine Präsentation in TIFF konvertieren**

Verwenden Sie die [Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/)‑Methode der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse, können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die erzeugten TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Speichern Sie die Präsentation als TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Eine Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [set_BwConversionMode](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in der [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/)‑Klasse ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur greift, wenn die [set_CompressionType](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ist eine Export‑Einstellung, die einen Pixel‑Konversions‑Algorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form dargestellt werden soll, wenn der Schwarz‑weiß‑Modus aktiv ist, verwenden Sie [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_blackwhitemode/). Siehe [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei „sample.pptx“ mit der folgenden Folie:

![A presentation slide](slide_black_and_white.png)

Dieser C++‑Code demonstriert, wie die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert wird:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Das Ergebnis:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Eine Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über Methoden der [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/) festlegen. Beispielsweise ermöglicht die [set_ImageSize](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/set_imagesize/)‑Methode, die Größe des resultierenden Bildes zu definieren.

Dieser C++‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Kompressionstyp festlegen.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Kompressionstypen:
    Default - Gibt das Standardschema für die Kompression an (LZW).
    None - Gibt an, dass keine Kompression verwendet wird.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

// Bild‑DPI festlegen.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Bildgröße festlegen.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Eine Präsentation in TIFF mit benutzerdefiniertem Pixel‑Format konvertieren**

Durch die Verwendung der [set_PixelFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)‑Methode der [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/)‑Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser C++‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert title="Tip" color="info" %}}
Probieren Sie Asposes [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) aus.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Präsentationen jeder Größe können in das TIFF‑Format konvertiert werden.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht übernommen; es werden nur statische Schnappschüsse der Folien exportiert.