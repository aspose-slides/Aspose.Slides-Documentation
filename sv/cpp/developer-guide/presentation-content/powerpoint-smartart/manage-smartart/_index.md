---
title: Hantera SmartArt i PowerPoint-presentationer med C++
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för C++ med tydliga kodexempel som snabbar upp bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för C++ kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayouter och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/get_allnodes/), och läs sedan [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) som returneras av [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

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
## **Ändra layouttypen för ett SmartArt-objekt**

SmartArt‑layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType]‑värdet `BasicBlockList`, ändrar det till värdet `BasicProcess` och sparar presentationen.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Kontrollera om en SmartArt-nod är dold**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) visar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType]‑värdet `RadialCycle` och kontrollerar nodens dolda tillstånd.

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
## **Hämta eller ange organisationsdiagramlayouten**

För SmartArt-diagram som använder en organisationsdiagramlayout definierar [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) och [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) hur barnnoder ordnas under en föräldranod. Till exempel kan du ställa in att barnnoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och anger layouten för den första noden till [OrganizationChartLayoutType]‑värdet `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType]‑värdet `PictureOrganizationChart` när du lägger till SmartArt‑objektet på en bild.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Metoden [SmartArt::set_IsReversed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/set_isreversed/) byter diagramriktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formatet bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/cpp/shape-manipulations/) med [ShapeCollection::AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/cpp/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/cpp/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett särskiljande [Shape::set_AlternativeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/set_alternativetext/) eller [Shape::set_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/set_name/) värde på SmartArt‑formen, sök efter det värdet i [BaseSlide::get_Shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseslide/get_shapes/), och kontrollera sedan att den matchande formen är en [ISmartArt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/ismartart/).