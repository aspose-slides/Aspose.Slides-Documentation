---
title: SmartArt kezelése PowerPoint bemutatókban C++-al
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti diagram
- képi szervezeti diagram
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan építhet és szerkeszthet PowerPoint SmartArt-ot az Aspose.Slides for C++ segítségével, tiszta kódmintákkal, amelyek felgyorsítják a dia tervezését és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for C++ segítségével létrehozhat SmartArt-ot, olvashat szöveget a csomópontjaiból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képi szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg beolvasásához iteráljon a [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartart/get_allnodes/), majd olvassa el a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot, amelyet a [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartshape/get_textframe/) ad vissza.

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

## **SmartArt objektum elrendezéstípusának megváltoztatása**

A SmartArt elrendezés határozza meg, hogyan helyezkednek el és kapcsolódnak a csomópontok. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` értékkel, átállítja `BasicProcess` értékre, és elmenti a bemutatót.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett‑e**

Az [ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) azt jelzi, hogy a csomópont rejtett‑e a SmartArt adatmodellben. Rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagram elemekként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

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

## **A szervezeti diagram elrendezésének lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti diagram elrendezést használnak, az [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) és az [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) meghatározzák, hogyan helyezkednek el a gyermek csomópontok a szülő csomópont alatt. Például a gyermek csomópontokat beállíthatja balra, jobbra vagy mindkét oldalra akadásra, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/organizationchartlayouttype/) függvényében.

A következő példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` értékre állítja.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Képi szervezeti diagram létrehozása**

A képi szervezeti diagram egy SmartArt elrendezés, amely hierarchikus diagramokhoz készült, és képhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való felvételéhez.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy visszafordítást RTL nyelvekhez?**

Igen. A [SmartArt::set_IsReversed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartart/set_isreversed/) metódus a diagram irányát balról jobbra → jobbról balra, vagy visszaállítja, ha a kiválasztott SmartArt elrendezés támogatja a visszafordítást.

**Hogyan másolhatom a SmartArt‑ot ugyanarra a diára vagy egy másik prezentációba, miközben megőrzöm a formázást?**

A [SmartArt alakzat klónozásával](/slides/hu/cpp/shape-manipulations/) a [ShapeCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapecollection/addclone/) vagy a SmartArt‑ot tartalmazó teljes dia [klónozásával](/slides/hu/cpp/clone-slides/) másolhatja. Mindkét megközelítés megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt‑ot raszteres képre előnézet vagy webes export céljából?**

A [dia renderelése](/slides/hu/cpp/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy meghatározott SmartArt objektumot egy dián, ha több is van?**

Adjon meg egy egyedi [Shape::set_AlternativeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/set_alternativetext/) vagy [Shape::set_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/set_name/) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [BaseSlide::get_Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseslide/get_shapes/) között, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/ismartart/).