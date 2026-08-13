---
title: Achtergronden van presentaties beheren in C++
linktitle: Dia‑achtergrond
type: docs
weight: 20
url: /nl/cpp/presentation-background/
keywords:
- presentatie‑achtergrond
- dia‑achtergrond
- effen kleur
- verloopkleur
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrond‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je dynamische achtergronden instelt in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor C++, inclusief code-tips om je presentaties te verbeteren."
---
## **Inleiding**

Vaste kleuren, verlopen en afbeeldingen worden vaak gebruikt als dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **masterdia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint‑achtergrond](powerpoint-background.png)

## **Stel een effen kleurachtergrond in voor een normale dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie—zelfs als de presentatie een masterdia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.
4. Gebruik de [get_SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_solidfillcolor/) methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Stel de achtergrondkleur van de dia in op blauw.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla de presentatie op naar schijf.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een effen kleurachtergrond in voor een masterdia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor de masterdia in een presentatie. De masterdia fungeert als een sjabloon dat de opmaak voor alle dia’s bepaalt, zodat wanneer je een effen kleur kiest voor de achtergrond van de masterdia, deze op elke dia wordt toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) van de masterdia (via `get_Masters`) in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de masterdia‑achtergrond in op `Solid`.
4. Gebruik de [get_SolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_solidfillcolor/) methode om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Stel de achtergrondkleur voor de Masterdia in op bosgroen.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Sla de presentatie op naar schijf.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een verloopachtergrond in voor een dia**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleurverandering. Wanneer het wordt gebruikt als dia‑achtergrond, kan een verloop presentaties een meer artistiek en professioneel uiterlijk geven. Aspose.Slides stelt je in staat om een verloopkleur als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.
4. Gebruik de [get_GradientFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_gradientformat/) methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om je gewenste verloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Pas een verloop‑effect toe op de achtergrond.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Sla de presentatie op naar schijf.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel een afbeelding in als dia‑achtergrond**

Naast effen- en verloopvullingen stelt Aspose.Slides je in staat om afbeeldingen te gebruiken als dia‑achtergronden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.
4. Laad de afbeelding die je wilt gebruiken als dia‑achtergrond.
5. Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
6. Gebruik de [get_PictureFillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/get_picturefillformat/) methode op [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Stel achtergrond‑afbeeldings‑eigenschappen in.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Laad de afbeelding.
auto image = Images::FromFile(u"Tulips.jpg");
// Voeg de afbeelding toe aan de afbeeldingsverzameling van de presentatie.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Sla de presentatie op naar schijf.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De volgende voorbeeldcode laat zien hoe je het achtergrondvulltype instelt op een getegelde afbeelding en de tegel‑eigenschappen aanpast:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Lees meer: [**Tile Picture As Texture**](/slides/nl/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Verander de transparantie van de achtergrondafbeelding**

Je wilt mogelijk de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter naar voren komt. De volgende C++‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding kunt wijzigen:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Bijvoorbeeld.

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Save the presentation to disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ophalen van de waarde van de dia‑achtergrond**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/) interface voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Met de `get_Background`‑methode van de [BaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseslide/) klasse kun je de effectieve achtergrond van een dia verkrijgen.

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Maak een instantie van de Presentation-klasse.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### Kan ik een aangepaste achtergrond opnieuw instellen en de thema‑/lay‑out‑achtergrond herstellen?

Ja. Verwijder de aangepaste vulling van de dia, dan wordt de achtergrond opnieuw geërfd van de bijbehorende [layout](/slides/nl/cpp/slide-layout/)/[master](/slides/nl/cpp/slide-master/) dia (d.w.z. de [theme background](/slides/nl/cpp/presentation-theme/)).

### Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?

Als een dia zijn eigen vulling heeft, blijft deze ongewijzigd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/cpp/slide-layout/)/[master](/slides/nl/cpp/slide-master/), wordt deze bijgewerkt om overeen te komen met het [new theme](/slides/nl/cpp/presentation-theme/).