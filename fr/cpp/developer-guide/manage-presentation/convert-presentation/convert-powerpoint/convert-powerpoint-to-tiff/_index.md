---
title: Convertir PowerPoint en TIFF
type: docs
weight: 90
url: /fr/cpp/convert-powerpoint-to-tiff/
keywords: "Convertir Présentation PowerPoint, PowerPoint en TIFF, PPT en TIFF, PPTX en TIFF, C++, CPP, Aspose.Slides"
description: "Convertir une présentation PowerPoint en TIFF en C++"
---

**TIFF** (Tagged Image File Format) est un format d'image bitmap sans perte et de haute qualité. Les professionnels utilisent le TIFF pour leurs besoins en design, photographie et publication assistée par ordinateur. Par exemple, si vous souhaitez conserver les calques et les paramètres de votre création ou de votre image, vous voudrez peut-être enregistrer votre travail en tant que fichier image TIFF.

Aspose.Slides vous permet de convertir les diapositives de PowerPoint directement en TIFF.

{{% alert title="Conseil" color="primary" %}}

Vous voudrez peut-être consulter le [convertisseur GRATUIT de PowerPoint en Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.

{{% /alert %}}

## **Convertir PowerPoint en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), vous pouvez rapidement convertir une présentation PowerPoint entière en TIFF. Les images TIFF résultantes correspondent à la taille par défaut des diapositives.

Ce code C++ vous montre comment convertir PowerPoint en TIFF :

```c++
// Le chemin vers le répertoire des documents.
String dataDir = GetDataPath();

// Instancie un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Enregistre la présentation au format TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **Convertir PowerPoint en TIFF Noir et Blanc**

Dans Aspose.Slides 23.10, Aspose.Slides a ajouté une nouvelle propriété ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) à la classe [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) pour vous permettre de spécifier l'algorithme à suivre lors de la conversion d'une diapositive ou d'une image colorée en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la propriété [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

Ce code C++ vous montre comment convertir une diapositive ou une image colorée en TIFF noir et blanc :

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **Convertir PowerPoint en TIFF avec Taille Personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions définies, vous pouvez définir vos chiffres préférés par le biais des propriétés fournies sous [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options). En utilisant la propriété [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/), par exemple, vous pouvez définir une taille pour l'image résultante.

Ce code C++ vous montre comment convertir PowerPoint en images TIFF avec taille personnalisée :

```c++
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Instancie un objet Presentation qui représente un fichier de présentation
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");

// Instancie la classe TiffOptions
auto opts = System::MakeObject<TiffOptions>();

// Définit le type de compression
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

// Type de compression

// Default - Spécifie le schéma de compression par défaut (LZW).
// None - Spécifie aucune compression.
// CCITT3
// CCITT4
// LZW
// RLE

// La profondeur dépend du type de compression et ne peut pas être définie manuellement.
// L'unité de résolution est toujours égale à « 2 » (points par pouce)

// Définit le DPI de l'image
opts->set_DpiX(200);
opts->set_DpiY(100);

// Définit la taille de l'image
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Enregistre la présentation en TIFF avec la taille spécifiée
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```

## **Convertir PowerPoint en TIFF avec Format de Pixel d'Image Personnalisé**

En utilisant la propriété [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) sous la classe [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options), vous pouvez spécifier votre format de pixel préféré pour l'image TIFF résultante.

Ce code C++ vous montre comment convertir PowerPoint en image TIFF avec format de pixel personnalisé :

```c++
// Le chemin vers le répertoire des documents.
System::String dataDir = GetDataPath();

// Instancie un objet Presentation qui représente un fichier de présentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contient les valeurs suivantes (comme on peut le voir dans la documentation) :
Format1bppIndexed; // 1 bit par pixel, indexé.
Format4bppIndexed; // 4 bits par pixel, indexé.
Format8bppIndexed; // 8 bits par pixel, indexé.
Format24bppRgb; // 24 bits par pixel, RGB.
Format32bppArgb; // 32 bits par pixel, ARGB.
*/

// Enregistre la présentation en TIFF avec le format de pixel spécifié
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```