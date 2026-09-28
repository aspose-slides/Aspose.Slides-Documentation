---
title: Beheer slide-masters van presentaties in C++
linktitle: Dia-master
type: docs
weight: 80
url: /nl/cpp/slide-master/
keywords:
- slide-master
- master-dia
- PPT-master-dia
- meerdere master-dia's
- master-dia's vergelijken
- achtergrond
- placeholder
- master-dia klonen
- master-dia kopiëren
- master-dia dupliceren
- ongebruikte master-dia
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer slide-masters in Aspose.Slides voor C++: toegang, bewerken, klonen, vergelijken en verwijderen van master-dia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstin‎stellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor C++ ondersteunt hetzelfde model. Een presentatie kan één of meer master‑dia's bevatten, en elke master‑dia kan verschillende layout‑dia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een master‑dia. In plaats daarvan gebruikt een normale dia een layout‑dia, en die layout‑dia behoort tot een master‑dia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke rangschikking van placeholders en opmaak op layout‑niveau.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één layout‑dia.

![De hiërarchie van master‑dia’s, layout‑dia’s en normale dia’s](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/) interface. Alle master‑dia's in een presentatie zijn beschikbaar via de [Presentation::get_Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/) collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als zowel een master‑dia als een layout‑dia een achtergrond definiëren, gebruiken dia's die op die layout zijn gebaseerd de layout‑achtergrond. Voor meer informatie over layout‑dia's, zie [Apply or Change Slide Layouts](/slides/nl/cpp/slide-layout/).
{{% /alert %}}

## **Toegang tot Slide Masters**

In PowerPoint kun je de Slide Master‑weergave openen via **View** > **Slide Master**.

![De Slide Master‑opdracht op het PowerPoint‑tabblad View](slide-master_3.jpg)

In Aspose.Slides gebruik je de `get_Masters()` collectie om master‑dia's te benaderen:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Je kunt ook de master‑dia ophalen die door een normale dia wordt gebruikt via zijn layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Wat een Slide Master Bevat**

Een master‑dia is een dia‑achtig object. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/), waardoor het veel van dezelfde dia‑eigenschappen blootlegt die door normale en layout‑dia's worden gebruikt. Master‑specifieke leden staan opgesomd op de API‑pagina van [IMasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslide/).

Veelgebruikte master‑dia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `get_Background()` | Stelt de master‑niveau dia‑achtergrond in. |
| `get_Shapes()` | Bevat vormen die op de master zijn geplaatst, zoals logo's, afbeeldingskaders en gedeelde tekst. |
| `get_LayoutSlides()` | Bevat de layout‑dia's die bij de master horen. |
| `get_ThemeManager()` | Biedt toegang tot de master‑thema‑API’s. |
| `get_HeaderFooterManager()` | Beheert kop‑, voetteksten, datums en dia‑nummers voor de master en zijn onderliggende layouts. |
| `GetDependingSlides()` | Retourneert normale dia's die via hun layouts van de master afhangen. |

## **Een Afbeelding Aan Een Slide Master Toevoegen**

Wanneer je een afbeelding toevoegt aan een master‑dia, verschijnt deze op dia's die layouts van die master gebruiken. Dit is nuttig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste master‑dia:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Voor meer informatie over afbeeldingskaders, zie [Afbeeldingskader](/slides/nl/cpp/picture-frame/).

## **De Zichtbaarheid van Master‑Grafieken Beheersen**

Gebruik [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/set_showmastershapes/) om geërfde master‑grafieken, zoals logo's of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `false` door aan [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/set_showmastershapes/) op de dia die die grafieken moet weglaten en `true` op dia's die ze moeten weergeven.

Het volgende zelfstandige voorbeeld creëert een blauwe decoratieve band op een master en twee dia's die dezelfde lege layout gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het voorbeeld gebruikt de **Blank** layout die wordt geleverd met een nieuwe presentatie en verwijdert de placeholders van de oorspronkelijke dia.

### **Kies de Reikwijdte van de Instelling**

Een normale dia gebruikt zijn master via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/get_layoutslide/) en [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_masterslide/). Het instellen van de eigenschap op een individuele dia beïnvloedt alleen die dia. Door `false` door te geven aan [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/set_showmastershapes/) worden master‑grafieken verborgen voor dia's die die gedeelde layout gebruiken, zelfs als hun eigen instelling `true` is. Om grafieken alleen op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde layout ongewijzigd.

De instelling wordt niet ondersteund als zichtbaarheid‑controle op de master‑dia zelf. Op een master geeft deze altijd `false` terug, en het toewijzen van `true` veroorzaakt `System::NotSupportedException`. Pas het toe op een normale dia of een layout.

### **Grafieken Onderscheiden Van De Achtergrond**

| Operatie | Effect |
| --- | --- |
| Master‑grafieken verbergen | Beheert de zichtbaarheid van geërfde master‑vormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Dia‑achtergrondvulling wijzigen | Wijzigt de achtergrondkleur, -gradient of -afbeelding. Master‑grafieken zijn afzonderlijke vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/cpp/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet langer beschikbaar is voor enige dia die die master gebruikt. |

## **Met Placeholders Werken**

Placeholders worden normaal gedefinieerd op layout‑dia's. De master‑dia levert de gedeelde stijl en het thema waar deze layouts van erven, terwijl elke layout beslist welke placeholders beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De Insert Placeholder‑opdracht in de PowerPoint Slide Master‑weergave](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de layout‑dia die bij de master hoort:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Je kunt ook placeholder‑vormen opmaken die al op een master‑dia bestaan. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire gradientvulling toe:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Opgemaakte titel‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer placeholder‑ en tekstopmaakopties, zie [Set Prompt Text in Placeholder](/slides/nl/cpp/manage-placeholder/) en [Text Formatting](/slides/nl/cpp/text-formatting/).

## **Een Slide Master‑Achtergrond Wijzigen**

Een master‑achtergrond wordt geërfd door layouts en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste master‑dia:

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zie voor gerelateerde onderwerpen [Presentation Background](/slides/nl/cpp/presentation-background/) en [Presentation Theme](/slides/nl/cpp/presentation-theme/).

## **Een Slide Master Naar Een Andere Presentatie Klonen**

Gebruik [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterslidecollection/addclone/) om een master‑dia te kopiëren naar een andere presentatie. De gekopieerde master kan daarna worden gebruikt door layouts en dia's in de doeldocumentatie.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Als je normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/cpp/clone-slides/).

## **Meerdere Slide Masters Toevoegen**

Een presentatie kan meerdere master‑dia's bevatten. Dit is nuttig wanneer verschillende secties verschillende branding, paginavormgeving of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van master‑dia's](slide-master_9.jpg)

Het volgende voorbeeld klont de standaard master, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die layout:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slide Masters Vergelijken**

Master‑dia's kunnen worden vergeleken met de `Equals` methode geërfd van [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/cpp/compare-slides/).

## **Slide Master‑Weergave Als Standaardweergave Instellen**

Gebruik de `set_LastView` methode op [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/cpp/save-presentation/).

## **Ongebruikte Master‑Dia's Verwijderen**

Presentaties bevatten soms master‑dia's die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslidecollection/removeunused/) om ongebruikte masters te verwijderen uit de `get_Masters()` collectie:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Je kunt ook de low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) methode gebruiken:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layout slide?**

Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een master‑dia en definieert een specifieke rangschikking van placeholders. Een normale dia gebruikt een layout slide, zodat hij zowel van de layout als van de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding vereisen.

**Moet ik placeholders aan een master slide of een layout slide toevoegen?**

In de meeste gevallen voeg je placeholders toe aan layout‑dia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de master‑dia, en plaats content‑placeholders op de layouts die normale dia's zullen gebruiken.

**Kan ik een master slide verwijderen die nog in gebruik is?**

Nee. Een master‑dia die afhankelijke dia's heeft, kan niet veilig direct worden verwijderd. Verplaats eerst die dia's naar layouts onder een andere master, of gebruik een opruimingsmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.