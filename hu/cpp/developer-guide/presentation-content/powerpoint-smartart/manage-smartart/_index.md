---
title: SmartArt kezelése PowerPoint prezentációkban C++ használatával
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
- képes szervezeti diagram
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan építhet és szerkeszthet PowerPoint SmartArt-ot az Aspose.Slides for C++ segítségével, világos kódrészletekkel, amelyek felgyorsítják a dia tervezését és automatizálását."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for C++ segítségével létrehozhat SmartArt-ot, beolvashatja a szöveget a csomópontjaiból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képes szervezeti diagramokat.

## **Szöveg lekérése egy SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének beolvasásához iteráljon a [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), majd olvassa el a [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) amelyet a [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) visszaad.

A példa egy legalább egy diát tartalmazó prezentációt, valamint egy SmartArt objektumot igényel, amely az adott dián az első alakzat. Kiírja az összes elérhető szövegkeretet a konzolra.

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

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés határozza meg, hogyan vannak a csomópontok elrendezve és összekötve. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` értékkel, átállítja `BasicProcess` értékre, és elmenti a prezentációt. A [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) számára megadott pozíciót és méretet pontban mérik. Használja a [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) metódust az elrendezés módosításához.

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

## **Annak ellenőrzése, hogy egy SmartArt csomópont rejtett-e**

Az [ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a választott elrendezés nem jeleníti meg őket látható diagramelemekként.

A következő példa egy csomópontot ad hozzá egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Ha a csomópont rejtett, üzenetet ír ki, és elmenti a diagramot.

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

## **A szervezeti diagram elrendezés lekérése vagy beállítása**

A szervezeti diagram elrendezést használó SmartArt diagramok esetén az [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) és [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) határozza meg, hogyan rendeződnek a gyermekcsomópontok a szülőcsomópont alatt. Például a gyermekcsomópontok elhelyezhetők balra, jobbra vagy mindkét oldalra, a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) függvényében.

A következő példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` értékre állítja. A 0‑alapú index `0` az első felső szintű csomópontot választja; gyermekcsomópontjai a kiválasztott elrendezést használják. Ezután a módosított prezentációt elmenti.

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

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchiai diagramokhoz készült, és képlehelyeket tartalmaz. A [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` értéket használja a SmartArt objektum diára történő hozzáadásakor. Ez a példa egy diagramot ment el képlehelyekkel; a lemezeket képekkel nem tölti fel.

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

## **Legacy diagramok átalakítása alakzategységekbe**

A meglévő prezentáció modernizálásakor előfordulhat, hogy frissíteni kell egy eredetileg PowerPoint 97–2003-ban készült szervezeti diagramot. Az Aspose.Slides ezeket a legacy diagramokat [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) objektumokként ábrázolja. Használja az [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) metódust, hogy egy diagramot alakzategységbe konvertáljon, így egyes vizuális elemeket szerkeszthet. A részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) oldalt.

A konverzió új csoportot ad a alakzategyűjteményhez az eredeti diagram eltávolítása nélkül. Sikeres konverzió után távolítsa el az eredetit az [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) metódussal, hogy elkerülje a duplikált tartalmat. A konvertálás előtt gyűjtse össze a legacy diagramokat egy vektorba, hogy az alakzatok hozzáadása és eltávolítása ne szakítsa meg az iterációt.

A következő példa megnyit egy prezentációt, minden diát átvizsgál, a diagramokat alakzategységgé konvertálja, és elmenti a frissített prezentációt PPTX formátumban.

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

Az elmentett prezentáció a konvertált legacy diagramok helyén szerkeszthető alakzategységeket tartalmaz, az eredeti diagramok már nem maradtak. Nyissa meg a PPTX fájlt a PowerPointban, hogy szerkessze az egyes csoportok elemeit, például szövegüket, kitöltésüket vagy pozíciójukat.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy fordítást jobb‑bal (RTL) nyelveknél?**

Igen. A [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) metódus átváltja a diagram irányát balról jobbra jobbra‑balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a fordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik prezentációba a formázás megtartása mellett?**

A [SmartArt alakzat klónozásával](/slides/hu/cpp/shape-manipulations/) a [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) vagy a SmartArt-ot tartalmazó diák [klónozásával](/slides/hu/cpp/clone-slides/) másolhatja. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képpé előnézethez vagy webes exporthoz?**

[A dia renderelésével](/slides/hu/cpp/convert-powerpoint-to-png/) vagy a teljes prezentáció PNG vagy JPEG formátumba exportálásával. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy konkrét SmartArt objektumot egy dián, ha több is van?**

Állítson be egy egyedi [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) vagy [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) értéket a SmartArt alakzaton, keresse ezt az értéket a [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) között, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).