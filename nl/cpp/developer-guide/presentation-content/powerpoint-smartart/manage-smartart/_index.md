---
title: Beheer SmartArt in PowerPoint-presentaties met C++
linktitle: Beheer SmartArt
type: docs
weight: 10
url: /nl/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- afbeelding-organigram
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint-SmartArt kunt maken en bewerken met Aspose.Slides voor C++ aan de hand van duidelijke code-voorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram dat bestaat uit knooppunten, knooppuntvormen en een lay‑out. Met Aspose.Slides voor C++ kunt u SmartArt maken, tekst lezen uit de knooppunten, de lay‑out wijzigen, verborgen knooppunten inspecteren, organigramlay‑outs configureren en afbeeldingorganigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan een of meerdere vormen bevatten. Om de zichtbare tekst te lezen, doorloopt u [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartart/get_allnodes/), en leest u vervolgens het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knooppunten worden gerangschikt en met elkaar verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartlayouttype/)‑waarde `BasicBlockList`, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen bestaan in de structuur, zelfs als de geselecteerde lay‑out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartlayouttype/)‑waarde `RadialCycle` gebruikt en controleert de verborgen status van het knooppunt.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Organigramlay‑out ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay‑out gebruiken, definiëren [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) en [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. Bijvoorbeeld, u kunt onderliggende knooppunten laten hangen aan de linker‑, rechter‑ of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay‑out van het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/organizationchartlayouttype/)‑waarde `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Een afbeelding‑organigram maken**

Een afbeelding‑organigram is een SmartArt‑lay‑out die is ontworpen voor hiërarchiediagrammen met afbeelding‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartartlayouttype/)‑waarde `PictureOrganizationChart` bij het toevoegen van het SmartArt‑object aan een dia.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [SmartArt::set_IsReversed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartart/set_isreversed/)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de gekozen SmartArt‑lay‑out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [clonen](/slides/nl/cpp/shape-manipulations/) met [ShapeCollection::AddClone](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapecollection/addclone/) of de hele dia die de SmartArt bevat [clonen](/slides/nl/cpp/clone-slides/). Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

[Render de dia](/slides/nl/cpp/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Stel een onderscheidende [Shape::set_AlternativeText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/set_alternativetext/)‑ of [Shape::set_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/set_name/)‑waarde in op de SmartArt‑vorm, zoek die waarde in [BaseSlide::get_Shapes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseslide/get_shapes/), en controleer vervolgens of de overeenkomende vorm een [ISmartArt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/ismartart/) is.