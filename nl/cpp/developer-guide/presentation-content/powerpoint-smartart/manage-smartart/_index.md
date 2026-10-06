---
title: SmartArt beheren in PowerPoint-presentaties met C++
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organisatieschema
- afbeeldingsorganisatieschema
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint SmartArt kunt bouwen en bewerken met Aspose.Slides voor C++ aan de hand van duidelijke codevoorbeelden die het ontwerpen van dia's en automatisering versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram dat bestaat uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides voor C++ kunt u SmartArt maken, tekst uit de knooppunten lezen, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organisatieschema’s configureren en afbeeldingen‑organisatieschema’s maken.

## **Tekst ophalen uit een SmartArt-object**

Een SmartArt‑knooppunt kan een of meer vormen bevatten. Om tekst uit de knooppuntvormen te lezen, doorloop je [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), en lees vervolgens het [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Het voorbeeld vereist een presentatie met minstens één dia en een SmartArt-object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstkader af naar de console.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Lay-outtype van een SmartArt-object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het onderstaande voorbeeld maakt een SmartArt-object met de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en grootte die aan [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) worden doorgegeven, worden gemeten in points. Gebruik [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) om de lay-out te wijzigen.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controleren of een SmartArt-knooppunt verborgen is**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt-datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het onderstaande voorbeeld voegt een knooppunt toe aan een SmartArt-object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`‑waarde gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **De lay-out van een organisatieschema ophalen of instellen**

Voor SmartArt-diagrammen die een organisatieschema-lay-out gebruiken, definiëren [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) en [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linker-, rechter- of beide zijden, afhankelijk van de gekozen [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Het onderstaande voorbeeld maakt een organisatieschema en stelt de lay-out van het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`‑waarde. De nul-gebaseerde index `0` selecteert het eerste top-level knooppunt; de onderliggende knooppunten gebruiken de gekozen rangschikking. De gewijzigde presentatie wordt vervolgens opgeslagen.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Een afbeelding-organisatieschema maken**

Een afbeelding-organisatieschema is een SmartArt-lay-out ontworpen voor hiërarchiediagrammen met afbeeldings-plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt-object aan een dia. Dit voorbeeld slaat een diagram op met afbeeldings-plaatsaanduidingen; het vult de plaatsaanduidingen niet met afbeeldingen.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Legacy-diagrammen omzetten naar groepen van vormen**

Bij het moderniseren van een bestaande presentatie moet u mogelijk een organisatieschema dat oorspronkelijk in PowerPoint 97–2003 is gemaakt, bijwerken. Aspose.Slides vertegenwoordigt deze legacy-diagrammen als [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/)‑objecten. Gebruik [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) om een diagram om te zetten naar een groep van vormen, zodat u individuele visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) voor details.

De conversie voegt een nieuwe groep toe aan de vormcollectie zonder het originele diagram te verwijderen. Na een geslaagde conversie verwijdert u het origineel met [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) om dubbele inhoud te voorkomen. Verzamel de legacy-diagrammen in een vector voordat u ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het onderstaande voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om naar groepen van vormen en slaat de bijgewerkte presentatie op als PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De opgeslagen presentatie bevat bewerkbare groepen van vormen ter vervanging van de geconverteerde legacy-diagrammen, zonder dat er originele diagrammen naast hen achterblijven. Open de PPTX in PowerPoint om individuele elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL-talen?**

Ja. De [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/)‑methode schakelt de diagramrichting van links-naar-rechts naar rechts-naar-links (of terug) wanneer de geselecteerde SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt naar dezelfde dia of naar een andere presentatie kopiëren waarbij de opmaak behouden blijft?**

U kunt [kloon de SmartArt-vorm](/slides/nl/cpp/shape-manipulations/) met [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) of [kloon de hele dia](/slides/nl/cpp/clone-slides/) die de SmartArt bevat. Beide benaderingen behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor preview of web-export?**

[Render de dia](/slides/nl/cpp/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt-object vinden op een dia als er meerdere aanwezig zijn?**

Stel een kenmerkende [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) of [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) waarde in op de SmartArt‑vorm, zoek die waarde in [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), en controleer vervolgens of de overeenkomende vorm een [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/) is.