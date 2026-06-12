---
title: Beheer afbeeldingskaders in presentaties met C++
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/cpp/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff-eigenschap
- opmaak van afbeeldingskader
- eigenschappen van afbeeldingskader
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- transparantie van afbeelding
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Versnel uw workflow en verbeter het ontwerp van dia's."
---
## **Introductie**

Een afbeeldingskader is een vorm die een afbeelding bevat – het is als een foto in een lijst.  

U kunt een afbeelding aan een dia toevoegen via een afbeeldingskader. Op die manier kunt u de afbeelding opmaken door het afbeeldingskader op te maken.

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die gebruikers in staat stellen snel presentaties te maken vanuit afbeeldingen. 

{{% /alert %}} 

## **Een afbeeldingskader maken**

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_frame) op basis van de breedte en hoogte van de afbeelding via de `AddPictureFrame`‑methode die wordt aangeboden door het vorm‑object dat hoort bij de refererende dia.  
6. Voeg een afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```c++
// Het pad naar de documentmap.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laadt de afbeelding die aan de afbeeldingencollectie van de presentatie wordt toegevoegd
// Haalt de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingencollectie van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingskader toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Past enige opmaak toe op het afbeeldingskader
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Schrijft het PPTX-bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Afbeeldingskaders stellen u in staat snel dia’s te maken op basis van afbeeldingen. Wanneer u een afbeeldingskader combineert met de opslaan‑opties van Aspose.Slides, kunt u invoer/uitvoer‑bewerkingen manipuleren om afbeeldingen van het ene formaat naar het andere te converteren. U wilt misschien deze pagina’s bekijken: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/jpg-to-png/), converteer [PNG naar JPG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/cpp/conversion/png-to-svg/), converteer [SVG naar PNG](https://products.aspose.com/slides/nl/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Een afbeeldingskader maken met relatieve schaal**

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een afbeelding toe aan de presentatie‑afbeeldingscollectie.  
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
5. Geef de relatieve breedte en hoogte van de afbeelding op in het afbeeldingskader.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```c++
// Het pad naar de documentmap.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Laadt de afbeelding die aan de afbeeldingencollectie van de presentatie wordt toegevoegd
// Haalt de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingencollectie van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingskader toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes het PPTX-bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Rasterafbeeldingen extraheren uit afbeeldingskaders**

U kunt rasterafbeeldingen extraheren uit [PictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_frame)‑objecten en deze opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder laat zien hoe u een afbeelding uit het document “sample.pptx” extraheert en opslaat in PNG‑formaat.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **SVG‑afbeeldingen extraheren uit afbeeldingskaders**

Wanneer een presentatie SVG‑grafieken bevat die zijn geplaatst in [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/)‑vormen, maakt Aspose.Slides voor C++ het mogelijk om de originele vectorafbeeldingen met volledige getrouwheid op te halen. Door de vormcollectie van de dia te doorlopen, kunt u elke [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het oorspronkelijke SVG‑formaat.

Het volgende code‑voorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingskader extraheert:

```cpp
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

Aspose.Slides maakt het mogelijk de transparanteffecten die op een afbeelding zijn toegepast op te halen. Deze C++‑code demonstreert de bewerking:

```c++
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

{{% alert color="primary" %}} 
Alle effecten die op afbeeldingen worden toegepast zijn te vinden in [Aspose::Slides::Effects](https://reference.aspose.com/slides/nl/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Opmaak van een afbeeldingskader**

Aspose.Slides biedt vele opmaakopties die kunnen worden toegepast op een afbeeldingskader. Met die opties kunt u een afbeeldingskader aanpassen zodat het aan specifieke eisen voldoet.

1. Maak een instantie van de [Presentation class](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation).  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_p_p_image)‑object door een afbeelding toe te voegen aan de [IImagescollection](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_image_collection) die hoort bij het presentatie‑object dat zal worden gebruikt om de vorm te vullen.  
4. Geef de breedte en hoogte van de afbeelding op.  
5. Maak een `PictureFrame` op basis van de breedte en hoogte van de afbeelding via de [AddPictureFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9)‑methode die wordt aangeboden door het [IShapes](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape_collection)‑object dat hoort bij de refererende dia.  
6. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
7. Stel de lijnkleur van het afbeeldingskader in.  
8. Stel de lijndikte van het afbeeldingskader in.  
9. Roteer het afbeeldingskader door een positieve of negatieve waarde op te geven.  
   * Een positieve waarde roteert de afbeelding met de klok mee.  
   * Een negatieve waarde roteert de afbeelding tegen de klok in.  
10. Voeg het afbeeldingskader (met de afbeelding) toe aan de dia.  
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Laadt de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Laadt de afbeelding die zal worden toegevoegd aan de afbeeldingencollectie van de presentatie
// Haalt de afbeelding op
auto image = Images::FromFile(filePath);

// Voegt een afbeelding toe aan de afbeeldingencollectie van de presentatie
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Voegt een afbeeldingskader toe aan de dia
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Stelt relatieve schaalbreedte en -hoogte in
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Schrijft het PPTX-bestand naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose heeft recentelijk een gratis Collage Maker ontwikkeld ([link](https://products.aspose.app/slides/nl/collage)). Als u ooit JPEG/JPG‑ of PNG‑afbeeldingen wilt samenvoegen, of roosters van foto’s wilt maken, kunt u deze service gebruiken. 

{{% /alert %}}

## **Een afbeelding toevoegen als link**

Om de bestandsgrootte van een presentatie te beperken, kunt u afbeeldingen (of video’s) via koppelingen toevoegen in plaats van de bestanden direct in de presentatie te embedden. Deze C++‑code laat zien hoe u een afbeelding en video toevoegt in een plaatshouder:

```cpp
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

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Maakt een nieuw afbeeldingobject
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Voegt een afbeeldingskader toe aan een dia
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Bijsnijdt de afbeelding (percentage waarden)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Slaat het resultaat op
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bijgesneden gebieden van een afbeelding verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een kader wilt verwijderen, kunt u de methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) gebruiken. Deze methode retourneert de bijgesneden afbeelding of de originele afbeelding als bijsnijden niet nodig is.

Deze C++‑code demonstreert de bewerking: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Haalt het PictureFrame op van de eerste dia
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Verwijdert bijgesneden gebieden van de PictureFrame-afbeelding en retourneert de bijgesneden afbeelding
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Slaat het resultaat op
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="OPMERKING" color="warning" %}} 

De methode [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) voegt de bijgesneden afbeelding toe aan de presentatie‑afbeeldingscollectie. Als de afbeelding alleen wordt gebruikt in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/), kan deze instelling de presentatiesize verkleinen. Anders zal het aantal afbeeldingen in de uiteindelijke presentatie toenemen.

Deze methode converteert WMF/EMF‑metabestanden naar een raster‑PNG‑afbeelding tijdens de bijsnijd‑operatie. 

{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de methode [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipicturefillformat/compressimage/).  
Deze methode verkleint een afbeelding door de grootte aan te passen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan op dezelfde manier als de PowerPoint‑functie **Afbeeldingsopmaak → Afbeeldingen comprimeren → Resolutie**.

De volgende C++‑voorbeelden laten zien hoe u een afbeelding in een presentatie comprimeert door een doel‑resolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```c++
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

Of door direct een aangepaste DPI‑waarde te gebruiken:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Comprimeer de afbeelding naar 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="OPMERKING" color="warning" %}}

De methode verlaagt de resolutie van de afbeelding op basis van de vormgrootte en de opgegeven DPI. Bijgesneden delen kunnen tevens worden verwijderd om de bestandsgrootte te optimaliseren.  
Indien de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. JPEG‑kwaliteit wordt behouden of licht verminderd afhankelijk van de resolutie, overeenkomstig de manier waarop PowerPoint hoge‑resolutie JPEG‑s behandelt.

{{% /alert %}}

## **Aspectratio vergrendelen**

Als u wilt dat een vorm die een afbeelding bevat de aspectratio behoudt, zelfs wanneer u de afmetingen van de afbeelding wijzigt, kunt u de methode [set_AspectRatioLocked()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) gebruiken om de instelling *Aspectratio vergrendelen* in te schakelen.  

Deze C++‑code laat zien hoe u de aspectratio van een vorm vergrendelt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// stel de vorm in om de aspectratio te behouden bij het schalen
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="OPMERKING" color="warning" %}} 

Deze instelling *Aspectratio vergrendelen* behoudt alleen de aspectratio van de vorm en niet van de afbeelding die erin zit.

{{% /alert %}}

## **Gebruik de StretchOff‑eigenschap**

Met de eigenschappen [StretchOffsetLeft](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) en [StretchOffsetBottom](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) van de [IPictureFillFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_picture_fill_format)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.picture_fill_format)‑klasse, kunt u een vul‑rechthoek opgeven.  

Wanneer stretching van een afbeelding wordt gespecificeerd, wordt een bron‑rechthoek geschaald om te passen in de opgegeven vul‑rechthoek. Elke rand van de vul‑rechthoek wordt gedefinieerd door een percentage‑offset ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm. Een positief percentage geeft een inspringing aan. Een negatief percentage geeft een uitspatting aan.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een `AutoShape`‑rechthoek toe.  
4. Maak een afbeelding.  
5. Stel het vultype van de vorm in.  
6. Stel de picture‑fill‑modus van de vorm in.  
7. Voeg de ingestelde afbeelding toe om de vorm te vullen.  
8. Geef afbeeldingsoffsets op ten opzichte van de overeenkomstige rand van de begrenzings‑box van de vorm.  
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code demonstreert een proces waarbij de StretchOff‑eigenschap wordt gebruikt:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Stelt de afbeelding in die vanaf elke kant wordt uitgerekt in het vormlichaam
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeelding‑object dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/). De lijst van ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Grote afbeeldingen embedden vergroot de bestandsgrootte en het geheugengebruik; afbeeldingen koppelen helpt de presentatiesize te beperken, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een link toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeeldingobject vergrendelen tegen per ongeluk verplaatsen of schalen?**

Gebruik [vorm‑vergrendelingen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/get_pictureframelock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) (bijvoorbeeld verplaatsen of schalen uitschakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [beschermings‑artikel](/slides/nl/cpp/applying-protection-to-presentation/) en wordt ondersteund voor diverse vormtypes, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/).

**Wordt de vector‑getrouwheid van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk om een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/) of naar raster‑formaten](/slides/nl/cpp/convert-powerpoint-to-png/) kan het resultaat gerasterd worden afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector wordt bewaard, wordt bevestigd door het extractie‑gedrag.