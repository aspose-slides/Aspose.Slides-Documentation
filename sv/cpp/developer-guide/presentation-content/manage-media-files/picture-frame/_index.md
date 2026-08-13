---
title: Hantera bildramar i presentationer med C++
linktitle: Bildram
type: docs
weight: 10
url: /sv/cpp/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- lägg till bild
- skapa bild
- extrahera bild
- rasterbild
- vektorbild
- beskär bild
- beskuret område
- StretchOff-egenskap
- formatering av bildram
- egenskaper för bildram
- relativ skala
- bildeffekt
- bildförhållande
- bildtransparens
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lägg till bildramar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Effektivisera ditt arbetsflöde och förbättra bilddesignen."
---
## **Introduktion**

En bildram är en form som innehåller en bild—det är som en bild i en ram. 

Du kan lägga till en bild på en bildspel genom en bildram. På så sätt kan du formatera bilden genom att formatera bildramen.

{{% alert  title="Tips" color="info" %}} 

Aspose erbjuder gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 

{{% /alert %}} 

## **Skapa en bildram**

1. Skapa en instans av [Presentation class](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_p_p_image) objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_image_collection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_frame) baserad på bildens bredd och höjd via `AddPictureFrame`‑metoden som exponeras av formobjektet som är kopplat till den refererade bilden.
6. Lägg till en bildram (som innehåller bilden) på bilden.
7. Spara den modifierade presentationen som en PPTX‑fil.

Denna C++‑kod visar hur du skapar en bildram:

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

// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Ladda önskad presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laddar bilden som kommer att läggas till i presentationens bildsamling
// Hämtar bilden
auto image = Images::FromFile(filePath);

// Lägger till en bild i presentationens bildsamling
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Lägger till en bildram på bilden
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ställer in relativ skala för bredd och höjd
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applicerar viss formatering på bildramen
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Skriver PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Bildramar låter dig snabbt skapa presentationsbilder baserade på bilder. När du kombinerar bildram med sparalternativen i Aspose.Slides kan du manipulera in-/utdataoperationer för att konvertera bilder från ett format till ett annat. Du kanske vill se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/cpp/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Skapa en bildram med relativ skala**

Genom att ändra en bilds relativa skalning kan du skapa en mer avancerad bildram. 

1. Skapa en instans av [Presentation class](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till en bild i presentationens bildsamling.
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_p_p_image) objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_image_collection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
5. Ange bildens relativa bredd och höjd i bildramen.
6. Spara den modifierade presentationen som en PPTX‑fil.

Denna C++‑kod visar hur du skapar en bildram med relativ skala:

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

// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laddar in önskad presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laddar bilden som ska läggas till i presentationens bildsamling
// Hämtar bilden
auto image = Images::FromFile(filePath);

// Lägger till en bild i presentationens bildsamling
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Lägger till en bildram på bilden
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ställer in relativ skala för bredd och höjd
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Skriver PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extrahera rasterbilder från bildramar**

Du kan extrahera rasterbilder från [PictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_frame)‑objekt och spara dem i PNG, JPG och andra format. Kodexemplet nedan visar hur du extraherar en bild från dokumentet "sample.pptx" och sparar den i PNG‑format.

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

## **Extrahera SVG‑bilder från bildramar**

När en presentation innehåller SVG‑grafik placerad i [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/)‑former låter Aspose.Slides för C++ dig hämta de ursprungliga vektorbilderna med fullständig noggrannhet. Genom att traversera bildens formesamling kan du identifiera varje [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/), kontrollera om den underliggande [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) innehåller SVG‑innehåll, och sedan spara den bilden till disk eller en ström i dess ursprungliga SVG‑format.

Följande kodexempel demonstrerar hur du extraherar en SVG‑bild från en bildram:

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

## **Hämta transparens för en bild**

Aspose.Slides låter dig hämta transparenseffekten som applicerats på en bild. Denna C++‑kod demonstrerar operationen:

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
Alla effekter som tillämpas på bilder finns i [Aspose::Slides::Effects](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Hämta ljusstyrka och kontrast för en bild**

Aspose.Slides låter dig hämta ljusstyrke‑ och kontrasteffekten som tillämpas på en bild. Gränssnittet [ILuminance](https://reference.aspose.com/slides/sv/cpp/aspose.slides.effects/iluminance/) representerar denna bildtransformations‑effekt.

Denna C++‑kod demonstrerar hur du får ljusstyrke‑ och kontrastinställningarna från en bildram:

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

## **Formatering av bildram**

Aspose.Slides erbjuder många formateringsalternativ som kan tillämpas på en bildram. Med dessa alternativ kan du ändra en bildram så att den uppfyller specifika krav.

1. Skapa en instans av [Presentation class](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Hämta en bilds referens via dess index. 
3. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_p_p_image) objekt genom att lägga till en bild i [IImagescollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_image_collection) som är kopplad till presentationsobjektet och som kommer att användas för att fylla formen.
4. Ange bildens bredd och höjd.
5. Skapa en `PictureFrame` baserad på bildens bredd och höjd via [AddPictureFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)‑metoden som exponeras av [IShapes](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape_collection)‑objektet som är kopplat till den refererade bilden.
6. Lägg till bildramen (som innehåller bilden) på bilden.
7. Ange bildramens linjefärg.
8. Ange bildramens linjebredd.
9. Rotera bildramen genom att ge den ett positivt eller negativt värde.
   * Ett positivt värde roterar bilden medurs. 
   * Ett negativt värde roterar bilden moturs.
10. Lägg till bildramen (som innehåller bilden) på bilden.
11. Spara den modifierade presentationen som en PPTX‑fil.

Denna C++‑kod demonstrerar bildramens formateringsprocess:

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

// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laddar in önskad presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämtar den första bilden
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Laddar bilden som ska läggas till i presentationens bildsamling
// Hämtar bilden
auto image = Images::FromFile(filePath);

// Lägger till en bild i presentationens bildsamling
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Lägger till en bildram på bilden
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Ställer in relativ skala för bredd och höjd
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Skriver PPTX-filen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tips" color="info" %}}

Aspose har nyligen utvecklat en [gratis Collage Maker](https://products.aspose.app/slides/sv/collage). Om du någonsin behöver [sammanfoga JPG/JPEG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑bilder, [skapa rutnät från foton](https://products.aspose.app/slides/sv/collage/photo-grid), kan du använda den här tjänsten. 

{{% /alert %}}

## **Lägg till en bild som länk**

För att undvika stora presentationsstorlekar kan du lägga till bilder (eller videor) via länkar i stället för att bädda in filerna direkt i presentationerna. Denna C++‑kod visar hur du lägger till en bild och video i en platshållare:

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

## **Beskära bilder**

Denna C++‑kod visar hur du beskär en befintlig bild på en bild:

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
// Skapar nytt bildobjekt
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

## **Ta bort beskurna områden i en bild**

Om du vill ta bort de beskurna områdena i en bild som finns i en ram kan du använda metoden [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Metoden returnerar den beskurna bilden eller originalbilden om beskärning inte är nödvändig.

Denna C++‑kod demonstrerar operationen: 

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

// Hämtar PictureFrame från den första bilden
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Tar bort beskurna områden av PictureFrame-bilden och returnerar den beskurna bilden
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Sparar resultatet
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="OBS" color="warning" %}} 

Metoden [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) lägger till den beskurna bilden i presentationens bildsamling. Om bilden endast används i den bearbetade [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/), kan denna inställning minska presentationens storlek. Annars kommer antalet bilder i den resulterande presentationen att öka.

Denna metod konverterar WMF/EMF‑metafiler till raster‑PNG‑bild i beskärningsoperationen. 

{{% /alert %}}

## **Komprimera bilder**

Du kan komprimera en bild i en presentation med hjälp av metoden [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipicturefillformat/compressimage/). 
Denna metod komprimerar en bild genom att minska dess storlek baserat på formens storlek och angiven upplösning, med möjlighet att ta bort beskurna områden.

Den justerar bildens storlek och upplösning på liknande sätt som PowerPoints funktion **Picture Format -> Compress Pictures -> Resolution**.

Följande C++‑exempel demonstrerar hur du komprimerar en bild i en presentation genom att ange en målupplösning och eventuellt ta bort beskurna områden:

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

// Komprimera bilden med en målupplösning på 150 DPI (webbupplösning) och ta bort beskurna områden.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Kontrollera resultatet av komprimeringen.
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

Eller genom att direkt använda ett eget DPI‑värde:

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

// Komprimera bilden till 150 DPI (webbupplösning), ta bort beskurna områden.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="OBS" color="warning" %}}

Metoden konverterar bilden till en lägre upplösning baserat på formens storlek och angivet DPI. Beskurna områden kan också tas bort för att optimera filstorleken.
Om bilden är en metafil (WMF/EMF) eller SVG kommer komprimering inte att tillämpas. Dessutom bevaras JPEG‑kvaliteten eller minskas något beroende på upplösning, på liknande sätt som PowerPoint hanterar högupplösta JPEG‑bilder.

{{% /alert %}}

## **Låsa bildförhållande**

Om du vill att en form som innehåller en bild ska behålla sitt bildförhållande även efter att du ändrat bildens dimensioner kan du använda metoden [set_AspectRatioLocked()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) för att ställa in *Lock Aspect Ratio*-inställningen. 

Denna C++‑kod visar hur du låser ett forms bildförhållande:

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

{{% alert title="OBS" color="warning" %}} 

Denna *Lock Aspect Ratio*-inställning bevarar endast formens bildförhållande och inte bilden som den innehåller.

{{% /alert %}}

## **Använd egenskapen StretchOff**

Genom att använda egenskaperna [StretchOffsetLeft](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) och [StretchOffsetBottom](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_picture_fill_format) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.picture_fill_format), kan du ange en fyllningsrektangel. 

När stretchning av en bild anges skalas en källrektangel för att passa in i den angivna fyllningsrektangeln. Varje kant av fyllningsrektangeln definieras av en procentuell förskjutning från motsvarande kant på formens omgivande låda. En positiv procentsats anger en insetting. En negativ procentsats anger en outset.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation)‑klassen.
2. Hämta en bilds referens via dess index.
3. Lägg till en rektangel `AutoShape`. 
4. Skapa en bild.
5. Ange formens fyllningstyp.
6. Ange formens bildfyllnadsläge.
7. Lägg till en bild för att fylla formen.
8. Ange bildens förskjutningar från motsvarande kant på formens omslutande låda
9. Spara den modifierade presentationen som en PPTX‑fil.

Denna C++‑kod demonstrerar en process där StretchOff‑egenskapen används:

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

### Hur kan jag ta reda på vilka bildformat som stöds för PictureFrame?

Aspose.Slides stödjer både rasterbilder (PNG, JPEG, BMP, GIF osv.) och vektorbilder (t.ex. SVG) via bildobjektet som tilldelas en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/). Listan över stödda format överlappar i allmänhet med funktionerna i bild‑ och konverteringsmotorn.

### Hur påverkar tillägg av dussintals stora bilder PPTX‑storlek och prestanda?

Att bädda in stora bilder ökar filstorlek och minnesanvändning; att länka bilder hjälper till att hålla presentationsstorleken nere men kräver att de externa filerna förblir åtkomliga. Aspose.Slides ger möjlighet att lägga till bilder via länkar för att minska filstorleken.

### Hur kan jag låsa ett bildobjekt så att det inte av misstag flyttas/ändras i storlek?

Använd [shape locks](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/get_pictureframelock/) för en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/) (t.ex. inaktivera flyttning eller storleksändring). Låsningsmekanismen beskrivs för former i en separat [skyddsartikel](/slides/sv/cpp/applying-protection-to-presentation/) och stöds för olika formtyper, inklusive [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/).

### Bevaras SVG‑vektornoggrannhet vid export av en presentation till PDF/bilder?

Aspose.Slides låter dig extrahera en SVG från en [PictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pictureframe/) som den ursprungliga vektorn. När du [exporterar till PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/) eller [rasterformat](/slides/sv/cpp/convert-powerpoint-to-png/) kan resultatet rasteriseras beroende på exportinställningarna; att den ursprungliga SVG‑filen lagras som en vektor bekräftas av extraktionsbeteendet.