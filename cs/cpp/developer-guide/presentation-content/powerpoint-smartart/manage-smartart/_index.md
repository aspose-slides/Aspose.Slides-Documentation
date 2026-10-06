---
title: Správa SmartArt v prezentacích PowerPoint pomocí C++
linktitle: Správa SmartArt
type: docs
weight: 10
url: /cs/cpp/manage-smartart/
keywords:
- SmartArt
- Text SmartArt
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro C++ s přehlednými ukázkami kódu, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu vytvořený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro C++ můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, kontrolovat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet organizační diagramy s obrázky.

## **Získání textu ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro čtení textu z tvarů uzlu projděte [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), a poté přečtěte [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) , který vrací [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objekt SmartArt jako první tvar na tomto snímku. Vypíše každý dostupný textový rámeček do konzole.

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

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou `BasicBlockList` typu [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/), změní ji na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávaná metodě [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) jsou měřeny v bodech. K změně rozvržení použijte [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/).

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

## **Kontrola, zda je uzel SmartArt skrytý**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) určuje, zda je uzel skryt v datovém modelu SmartArt. Skryté uzly mohou ve struktuře existovat i v případě, že vybrané rozvržení nezobrazuje je jako viditelné prvky diagramu.

Následující příklad přidá uzel do objektu SmartArt, který používá hodnotu `RadialCycle` typu [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/), a zkontroluje skrytý stav přidaného uzlu. Vypíše zprávu, pokud je uzel skryt, a uloží diagram.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro diagramy SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) a [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) definují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit, aby se podřízené uzly zavěšovaly vlevo, vpravo nebo na obou stranách, v závislosti na vybraném typu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu `LeftHanging` typu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/). Index `0` (nula‑základní) vybírá první uzel nejvyšší úrovně; jeho podřízené uzly použijí vybranou úpravu. Upravená prezentace je následně uložena.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu `PictureOrganizationChart` typu [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/). Tento příklad uloží diagram se zástupnými obrázky; nezaplní však zástupné prvky obrázky.

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

## **Převod starých diagramů na skupiny tvarů**

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram vytvořený v PowerPointu 97–2003. Aspose.Slides představuje tyto staré diagramy jako objekty [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Použijte [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/), abyste diagram převedli na skupinu tvarů, což vám umožní upravovat jednotlivé vizuální prvky. Podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál pomocí [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/), abyste se vyhnuli duplicitnímu obsahu. Před konverzí si shromážděte staré diagramy do vektoru, aby přidávání a odstraňování tvarů nerušilo iteraci.

Následující příklad otevře prezentaci, prohledá každý snímek, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

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

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, přičemž žádné původní diagramy již nezůstávají. Otevřete PPTX v PowerPointu a upravujte jednotlivé prvky v každé skupině, jako je jejich text, výplň nebo pozice.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Metoda [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) přepíná směr diagramu z levé‑pravou na pravou‑levou nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/cpp/shape-manipulations/) pomocí [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/cpp/clone-slides/) , který SmartArt obsahuje. Oba přístupy zachovají velikost, pozici i formátování.

**Jak renderuji SmartArt do rastrového obrázku pro náhled nebo export na web?**

[Renderovat snímek](/slides/cs/cpp/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je renderován jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Nastavte charakteristickou hodnotu [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) nebo [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) na tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), a poté ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).