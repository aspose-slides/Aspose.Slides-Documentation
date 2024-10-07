---
title: PowerPoint in TIFF konvertieren
type: docs
weight: 90
url: /cpp/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, C++, CPP, Aspose.Slides"
description: "PowerPoint-Präsentation in TIFF in C++ konvertieren"
---

**TIFF** (Tagged Image File Format) ist ein verlustfreies Raster- und hochqualitatives Bildformat. Fachleute verwenden TIFF für Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild beibehalten möchten, sollten Sie Ihre Arbeit als TIFF-Bilddatei speichern.

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren.

{{% alert title="Tipp" color="primary" %}}

Sie sollten sich Aspose's [KOSTENLOSEN PowerPoint zu Poster Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ansehen.

{{% /alert %}}

## **PowerPoint in TIFF konvertieren**

Mit der durch die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse bereitgestellten [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) Methode können Sie eine gesamte PowerPoint-Präsentation schnell in TIFF konvertieren. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien.

Diese C++-Code zeigt Ihnen, wie Sie PowerPoint in TIFF konvertieren:

```c++
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Speichert die Präsentation als TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **PowerPoint in Schwarz-Weiß TIFF konvertieren**

In Aspose.Slides 23.10 fügte Aspose.Slides eine neue Eigenschaft ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) zur [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) Klasse hinzu, die es Ihnen ermöglicht, den Algorithmus anzugeben, der befolgt wird, wenn eine farbige Folie oder ein Bild in ein Schwarz-Weiß TIFF konvertiert wird. Beachten Sie, dass diese Einstellung nur angewendet wird, wenn die [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) Eigenschaft auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser C++-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in ein Schwarz-Weiß TIFF konvertieren:

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **PowerPoint in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Werte über die Eigenschaften der [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) festlegen. Mit der [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) Eigenschaft können Sie beispielsweise eine Größe für das resultierende Bild festlegen.

Dieser C++-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe konvertieren:

```c++
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// Instanziiert die TiffOptions-Klasse
auto opts = System::MakeObject<TiffOptions>();

// Setzt den Kompressionstyp
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// Kompressionstypen

// Default - Gibt das Standardkompressionsschema (LZW) an.
// None - Gibt keine Kompression an.
// CCITT3
// CCITT4
// LZW
// RLE

// Die Tiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.
// Die Auflösungseinheit beträgt immer „2“ (Punkte pro Zoll)

// Setzt die Bild-DPI
opts->set_DpiX(200);
opts->set_DpiY(100);

// Setzt die Bildgröße
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Speichert die Präsentation als TIFF mit der angegebenen Größe
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **PowerPoint in TIFF mit benutzerdefiniertem Bild-Pixel-Format konvertieren**

Mit der [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) Eigenschaft in der [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) Klasse können Sie Ihr bevorzugtes Pixel-Format für das resultierende TIFF-Bild angeben.

Dieser C++-Code zeigt Ihnen, wie Sie PowerPoint in ein TIFF-Bild mit benutzerdefiniertem Pixel-Format konvertieren:

```c++
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat enthält die folgenden Werte (wie aus der Dokumentation ersichtlich):
Format1bppIndexed; // 1 Bit pro Pixel, indiziert.
Format4bppIndexed; // 4 Bit pro Pixel, indiziert.
Format8bppIndexed; // 8 Bit pro Pixel, indiziert.
Format24bppRgb; // 24 Bit pro Pixel, RGB.
Format32bppArgb; // 32 Bit pro Pixel, ARGB.
*/

// Speichert die Präsentation als TIFF mit der angegebenen Größe
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```