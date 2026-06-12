---
title: Spravovat SmartArt v prezentacích PowerPoint pomocí C++
linktitle: Spravovat SmartArt
type: docs
weight: 10
url: /cs/cpp/manage-smartart/
keywords:
- SmartArt
- Text SmartArtu
- Typ rozvržení
- Skrytá vlastnost
- Organizační diagram
- Obrázkový organizační diagram
- PowerPoint
- Prezentace
- C++
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro C++ s přehlednými ukázkami kódu, které urychlují navrhování snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu sestavený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro C++ můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, kontrolovat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu ze SmartArt objektu**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro přečtení viditelného textu projděte [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/get_allnodes/), pak přečtěte [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) vrácený metodou [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

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

## **Změna typu rozvržení SmartArt objektu**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří SmartArt objekt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, změní jej na hodnotu `BasicProcess` a uloží prezentaci.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kontrola, zda je uzel SmartArt skrytý**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení nezobrazuje je jako viditelné diagramové prvky.

Následující příklad přidá uzel do SmartArt objektu, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, a zkontroluje stav skrytí uzlu.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro diagramy SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) a [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) definují, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit, aby podřízené uzly visely vlevo, vpravo nebo na obou stranách, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` při přidávání SmartArt objektu na snímek.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro RTL jazyky?**

Ano. Metoda [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartart/set_isreversed/) přepíná směr diagramu zleva doprava na zprava doleva, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace a zachovat formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/cpp/shape-manipulations/) pomocí [ShapeCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/cpp/clone-slides/) obsahující SmartArt. Oba přístupy zachovají velikost, umístění a formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo webový export?**

[Vykreslete snímek](/slides/cs/cpp/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak najdu konkrétní SmartArt objekt na snímku, pokud jich je několik?**

Nastavte výrazný [Shape::set_AlternativeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/set_alternativetext/) nebo [Shape::set_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/set_name/) na tvaru SmartArt, vyhledejte tuto hodnotu v [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseslide/get_shapes/), a pak ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/ismartart/).