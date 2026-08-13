---
title: Verwalten von Bildrahmen in Präsentationen mit C++
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/cpp/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design Ihrer Folien."
---
## **Einführung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.  

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="info" %}} 
Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Ein Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, das mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_frame) basierend auf Breite und Höhe des Bildes, über die Methode `AddPictureFrame`, die vom Shape‑Objekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.  
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung für Breite und Höhe
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Wendet einige Formatierungen auf den Bildrahmen an
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Schreibt die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien basierend auf Bildern. Wenn Sie Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabe‑Operationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie sollten sich diese Seiten ansehen: konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/de/cpp/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/de/cpp/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/de/cpp/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Ein Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen.  

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.  
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, das mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.  
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.  
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung für Breite und Höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_frame)-Objekten extrahieren und sie im PNG‑, JPG‑ und anderen Formaten speichern. Das nachfolgende Codebeispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für C++ das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) SVG‑Inhalte enthält, und das Bild dann im nativen SVG‑Format auf Festplatte oder in einen Stream speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Transparenz eines Bildes ermitteln**

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Der folgende C++‑Code demonstriert die Operation:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
Alle auf Bilder angewendeten Effekte finden Sie unter [Aspose::Slides::Effects](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Helligkeit und Kontrast eines Bildes ermitteln**

Aspose.Slides ermöglicht das Abrufen von Helligkeits‑ und Kontrasteffekten, die auf ein Bild angewendet wurden. Das [ILuminance](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iluminance/)-Interface repräsentiert diesen Bildtransformationseffekt.

Der nachstehende C++‑Code zeigt, wie Sie die Helligkeits‑ und Kontrasteinstellungen aus einem Bildrahmen auslesen:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen an spezifische Anforderungen anpassen.

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation).  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_p_p_image)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) hinzufügen, das mit dem Präsentationsobjekt verknüpft ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein `PictureFrame` basierend auf Breite und Höhe des Bildes über die Methode [AddPictureFrame](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9), die vom [IShapes](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_shape_collection)-Objekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.  
7. Setzen Sie die Linienfarbe des Bildrahmens.  
8. Setzen Sie die Linienstärke des Bildrahmens.  
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (der das Bild enthält) erneut der Folie hinzu.  
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Lädt die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Lädt das Bild, das zur Bildsammlung der Präsentation hinzugefügt wird
// Holt das Bild
auto image = Images::FromFile(filePath);

// Fügt ein Bild zur Bildsammlung der Präsentation hinzu
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Fügt der Folie einen Bildrahmen hinzu
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Setzt relative Skalierung für Breite und Höhe
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes die PPTX-Datei auf die Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/de/collage/photo-grid) möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen zu reduzieren, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser C++‑Code zeigt, wie ein Bild und ein Video in einen Platzhalter eingefügt werden:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bilder zuschneiden**

Dieser C++‑Code demonstriert das Zuschneiden eines vorhandenen Bildes auf einer Folie:

```CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Erstellt ein neues Bildobjekt
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Adds a PictureFrame to a Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Crops the image (percentage values)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Saves the result
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes entfernen möchten, können Sie die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, falls kein Zuschneiden nötig ist.

Der folgende C++‑Code demonstriert die Operation:

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Holt den Bildrahmen von der ersten Folie
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Löscht die zugeschnittenen Bereiche des Bildrahmenbildes und gibt das zugeschnittene Bild zurück
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Speichert das Ergebnis
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

Die Methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) verwendet wird, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien während des Zuschneidevorgangs in ein Raster‑PNG‑Bild. 
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipicturefillformat/compressimage/) komprimieren. Diese Methode reduziert die Bildgröße basierend auf der Formgröße und der angegebenen Auflösung, mit der Option, zugeschnittene Bereiche zu löschen.

Sie passt die Bildgröße und Auflösung ähnlich wie die PowerPoint‑Funktion **Bildformat → Bilder komprimieren → Auflösung** an.

Die folgenden C++‑Beispiele zeigen, wie Sie ein Bild in einer Präsentation komprimieren, indem Sie eine Zielauflösung angeben und optional zugeschnittene Bereiche entfernen:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) komprimieren und zugeschnittene Bereiche entfernen.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Ergebnis der Kompression prüfen.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Oder indem Sie direkt einen benutzerdefinierten DPI‑Wert verwenden:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Bild auf 150 DPI (Web-Auflösung) komprimieren, zugeschnittene Bereiche entfernen.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

Die Methode konvertiert das Bild zu einer niedrigeren Auflösung basierend auf der Größe der Form und dem angegebenen DPI. Zuge‑schneiderte Bereiche können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Falls das Bild ein Metafile (WMF/EMF) oder SVG ist, wird keine Kompression angewendet. Außerdem bleibt die JPEG‑Qualität erhalten oder wird bei niedriger Auflösung leicht reduziert, ähnlich wie PowerPoint mit hochauflösenden JPEGs umgeht. 
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [set_AspectRatioLocked()](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) verwenden, um die Einstellung *Seitenverhältnis sperren* zu setzen.  

Der folgende C++‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes. 
{{% /alert %}}

## **Verwendung der StretchOff‑Eigenschaft**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) und [StretchOffsetBottom](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) der [IPictureFillFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_picture_fill_format)-Schnittstelle und der [PictureFillFormat](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.picture_fill_format)-Klasse können Sie ein Füllrechteck angeben. 

Wenn das Strecken eines Bildes angegeben wird, wird ein Quellrechteck so skaliert, dass es in das angegebene Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Einzug an. Ein negativer Prozentsatz gibt ein Herausragen an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation)-Klasse.  
2. Rufen Sie die Referenz einer Folie über ihren Index ab.  
3. Fügen Sie ein Rechteck `AutoShape` hinzu.  
4. Erstellen Sie ein Bild.  
5. Setzen Sie den Fülltyp der Form.  
6. Setzen Sie den Bildfüllmodus der Form.  
7. Fügen Sie ein Bild zum Füllen der Form hinzu.  
8. Geben Sie Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an.  
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.  

Der folgende C++‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Setzt das Bild, das von jeder Seite im Formkörper gestreckt wird
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektor‑Bilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

### Wie beeinflusst das Hinzufügen von Dutzenden großer Bilder die PPTX‑Größe und -Leistung?

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin verfügbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

### Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/get_pictureframelock/) für einen [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) (z. B. Verschieben oder Größenändern deaktivieren). Der Sperr‑Mechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/cpp/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/), unterstützt.

### Bleibt die Vektor‑Treue von SVG erhalten, wenn eine Präsentation in PDF/Bilder exportiert wird?

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Exportieren nach PDF](/slides/de/cpp/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/cpp/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; das Vorhandensein des Original‑SVG als Vektor wird durch das Extraktionsverhalten bestätigt.