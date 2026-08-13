---
title: Beheer afbeeldingsframes in presentaties met C++
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/cpp/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- afbeeldingsframe opmaak
- afbeeldingsframe eigenschappen
- relatieve schaal
- afbeeldingseffect
- aspectverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Voeg afbeeldingsframes toe aan PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor C++. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Een afbeeldingsframe is een vorm die een afbeelding bevat — het is als een foto in een frame.

U kunt een afbeelding aan een dia toevoegen via een afbeeldingsframe. Op deze manier kunt u de afbeelding opmaken door het afbeeldingsframe op te maken.

{{% alert  title="Tip" color="info" %}} 
Aspose biedt gratis converters —[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die gebruikers in staat stellen om snel presentaties uit afbeeldingen te maken. 
{{% /alert %}} 

## **Een afbeeldingsframe maken**

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Haal een verwijzing naar een dia op via de index.
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)-object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_frame) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die beschikbaar is op het vorm‑object dat aan de betreffende dia is gekoppeld.
6. Voeg een afbeeldingsframe (met de afbeelding) toe aan de dia.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code toont hoe u een afbeeldingsframe maakt:

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

// Het pad naar de documentmap.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laadt de afbeelding die zal worden toegevoegd aan de afbeeldingsverzameling van de presentatie
// Haalt de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingsverzameling van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingsframe toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt de relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Past enige opmaak toe op het afbeeldingsframe
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Schrijft het PPTX‑bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Afbeeldingsframes stellen u in staat om snel presentatiedia's op basis van afbeeldingen te maken. Wanneer u een afbeeldingsframe combineert met de opslaan‑opties van Aspose.Slides, kunt u in‑ en uitvoerbewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. Mogelijk wilt u deze pagina's bekijken: converteer [image to JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/).
{{% /alert %}} 

## **Een afbeeldingsframe maken met relatieve schaal**

Door de relatieve schaal van een afbeelding te wijzigen, kunt u een complexer afbeeldingsframe maken. 

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Haal een verwijzing naar een dia op via de index. 
3. Voeg een afbeelding toe aan de afbeeldingsverzameling van de presentatie.
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)-object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingsframe.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code toont hoe u een afbeeldingsframe met relatieve schaal maakt:

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

// Het pad naar de documentmap.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laadt de afbeelding die moet worden toegevoegd aan de afbeeldingsverzameling van de presentatie
// Haalt de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingsverzameling van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingsframe toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt de relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schrijft het PPTX‑bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rasterafbeeldingen uit afbeeldingsframes extraheren**

U kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_frame)-objecten extraheren en opslaan als PNG, JPG en andere formaten. Het codevoorbeeld hieronder laat zien hoe u een afbeelding uit het document “sample.pptx” extraheert en opslaat in PNG‑formaat.

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

## **SVG‑afbeeldingen uit afbeeldingsframes extraheren**

Wanneer een presentatie SVG‑grafieken bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/)-vormen geplaatst zijn, maakt Aspose.Slides voor C++ het mogelijk om de oorspronkelijke vector‑afbeeldingen met volledige nauwkeurigheid op te halen. Door de vormverzameling van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) SVG‑inhoud bevat, en daarna die afbeelding naar schijf of een stroom opslaan in het oorspronkelijke SVG‑formaat.

Het volgende codevoorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingsframe haalt:

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

## **Transparantie van een afbeelding ophalen**

Aspose.Slides stelt u in staat om het transparantie‑effect dat op een afbeelding toegepast is op te halen. Deze C++‑code demonstreert de bewerking:

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
Alle effecten die op afbeeldingen toegepast kunnen worden, zijn te vinden in [Aspose::Slides::Effects](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides stelt u in staat om de helderheids‑ en contrast‑effecten die op een afbeelding toegepast zijn op te halen. De [ILuminance](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/iluminance/) interface vertegenwoordigt dit afbeeldingstransformatie‑effect.

Deze C++‑code laat zien hoe u de helderheids‑ en contrastinstellingen van een afbeeldingsframe ophaalt:

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

## **Afbeeldingsframe‑opmaak**

Aspose.Slides biedt vele opmaakopties die op een afbeeldingsframe toegepast kunnen worden. Met die opties kunt u een afbeeldingsframe aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).
2. Haal een verwijzing naar een dia op via de index. 
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)-object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die aan het presentatie‑object is gekoppeld en die zal worden gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van de afbeelding op.
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)‑methode die beschikbaar is op het [IShapes](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection)‑object dat aan de betreffende dia gekoppeld is.
6. Voeg het afbeeldingsframe (met de afbeelding) toe aan de dia.
7. Stel de lijnekleur van het afbeeldingsframe in.
8. Stel de lijndikte van het afbeeldingsframe in.
9. Draai het afbeeldingsframe door een positieve of negatieve waarde op te geven.
   * Een positieve waarde draait de afbeelding met de klok mee. 
   * Een negatieve waarde draait de afbeelding tegen de klok in.
10. Voeg het afbeeldingsframe (met de afbeelding) toe aan de dia.
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code demonstreert het proces van afbeeldingsframe‑opmaak:

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

// Het pad naar de documentmap.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Laadt de afbeelding die moet worden toegevoegd aan de afbeeldingsverzameling van de presentatie
// Haal de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingsverzameling van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingsframe toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt de relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Schrijft het PPTX‑bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}
Aspose heeft recent een [free Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u ooit JPG/JPEG‑ of PNG‑afbeeldingen wilt [samenvoegen](https://products.aspose.app/slides/nl/collage/jpg) of rasteren uit foto’s wilt [maken](https://products.aspose.app/slides/nl/collage/photo-grid), kunt u deze dienst gebruiken. 
{{% /alert %}}

## **Een afbeelding toevoegen als link**

Om de grootte van een presentatie te beperken, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie in te sluiten. Deze C++‑code laat zien hoe u een afbeelding en video in een placeholder toevoegt:

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

## **Afbeeldingen bijsnijden**

Deze C++‑code laat zien hoe u een bestaande afbeelding op een dia bijsnijdt: 

``` CPP
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
// Maakt nieuw afbeeldingobject
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

## **Bijsneden gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een frame wilt verwijderen, kunt u de [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden niet nodig is.

Deze C++‑code demonstreert de bewerking: 

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

// Haalt het PictureFrame van de eerste dia op
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Verwijdert de bijgesneden gebieden van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Slaat het resultaat op
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
De [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‑methode voegt de bijgesneden afbeelding toe aan de afbeeldingsverzameling van de presentatie. Als de afbeelding alleen gebruikt wordt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/), kan deze instelling de presentatiesize verkleinen. Anders zal het aantal afbeeldingen in de uiteindelijke presentatie toenemen.

Deze methode zet WMF/EMF‑metabestanden om naar raster‑PNG‑afbeeldingen tijdens de bijsnijd‑bewerking. 
{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/compressimage/)‑methode.
Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de mogelijkheid om bijgesneden gebieden te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan op een manier die vergelijkbaar is met de functie **Picture Format -> Compress Pictures -> Resolution** in PowerPoint.

De volgende C++‑voorbeelden laten zien hoe u een afbeelding in een presentatie comprimeert door een doelformaat (resolutie) op te geven en optioneel bijgesneden gebieden te verwijderen:

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

// Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Controleer het resultaat van de compressie.
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

Of met een aangepaste DPI‑waarde direct:

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

// Comprimeer de afbeelding tot 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
De methode maakt het beeld tot een lagere resolutie gebaseerd op de vormgrootte en opgegeven DPI. 
Bijgesneden delen kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.
Als het beeld een metafile (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit bewaard of licht verlaagd afhankelijk van de resolutie, op dezelfde wijze als PowerPoint met hoge‑resolutie JPEG‑bestanden omgaat.
{{% /alert %}}

## **Verhoudingsvergrendeling**

Als u wilt dat een vorm die een afbeelding bevat zijn verhoudingen behoudt, zelfs wanneer u de afmetingen van de afbeelding wijzigt, kunt u de [set_AspectRatioLocked()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/)‑methode gebruiken om de *Verhoudingsvergrendeling*‑instelling in te stellen. 

Deze C++‑code toont hoe u de verhoudingen van een vorm vergrendelt:

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

// stel de vorm in om de aspectverhouding te behouden bij het schalen
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
Deze *Verhoudingsvergrendeling*‑instelling behoudt alleen de verhoudingen van de vorm en niet van de afbeelding die erin zit.
{{% /alert %}}

## **De StretchOff‑eigenschap gebruiken**

Met de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_fill_format)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format)‑klasse kunt u een vulrechthoek specificeren. 

Wanneer een rek van een afbeelding wordt opgegeven, wordt een bronrechthoek geschaald om te passen in de opgegeven vulrechthoek. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de omhullende doos van de vorm. Een positieve procentuele waarde geeft een insnijding aan. Een negatieve procentuele waarde geeft een uitsteeksel aan.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een rechthoek `AutoShape` toe. 
4. Maak een afbeelding.
5. Stel het vultype van de vorm in.
6. Stel de afbeeldingvulmodus van de vorm in.
7. Voeg een set afbeelding toe om de vorm te vullen.
8. Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige rand van de omhullende doos van de vorm.
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code demonstreert een proces waarin de StretchOff‑eigenschap wordt gebruikt:

``` cpp
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

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Hoe kan ik achterhalen welke afbeeldingsformaten ondersteund worden voor PictureFrame?

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia‑ en afbeeldingsconversie‑engine.

### Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?

Grote afbeeldingen insluiten vergroot de bestandsgrootte en het geheugenverbruik; afbeeldingen linken helpt de presentatiesize te beperken, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een link toe te voegen om de bestandsgrootte te reduceren.

### Hoe kan ik een afbeeldingobject vergrendelen tegen per ongeluk verplaatsen/vergroten?

Gebruik [shape locks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/get_pictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of vergroten uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [protection article](/slides/nl/cpp/applying-protection-to-presentation/) en wordt ondersteund voor diverse vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/).

### Wordt de vector‑fidelity van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?

Aspose.Slides maakt het mogelijk om een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) te extraheren als de oorspronkelijke vector. Bij het exporteren naar PDF (/slides/nl/cpp/convert-powerpoint-to-pdf/) of rasterformaten (/slides/nl/cpp/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de oorspronkelijke SVG als vector wordt opgeslagen, wordt bevestigd door het extractie‑gedrag.