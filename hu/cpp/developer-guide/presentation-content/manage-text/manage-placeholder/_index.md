---
title: Diavetítések helyőrzőinek kezelése C++-ban
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/cpp/manage-placeholder/
keywords:
- helyőrző
- szöveghelyőrző
- képhelyőrző
- diagramhelyőrző
- tartalomhelyőrző
- utasító szöveg
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan ellenőrizheti és szerkesztheti a szöveg, kép, diagram és tartalom helyőrzőket, valamint hogyan értheti meg a helyőrző öröklődést az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A helyőrző olyan alakzat, amely helyet foglal egy adott típusú tartalom számára egy bemutató sablonban. Gyakori példák a cím, törzs, kép, diagram és általános célú tartalomhelyőrzők. Egy szokásos alakzattól eltérően a helyőrző örökölheti pozícióját, méretét, formázását és egyéb beállításait egy elrendezés vagy mester dia alapján.

Aspose.Slides a helyőrző információkat a [IShape::get_Placeholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_placeholder/) metóduson keresztül teszi elérhetővé. A metódus egy [IPlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iplaceholder/) objektumot ad vissza, vagy `nullptr`-t egy normál alakzat esetén. Használja a [IPlaceholder::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iplaceholder/get_type/) metódust annak meghatározásához, hogy a helyőrző milyen tartalomra van szánva.

Az alakzat interfész továbbra is fontos, miután megismerte a helyőrző típusát:

- Egy üres szöveg, kép, diagram vagy tartalomhelyőrző általában egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) által van reprezentálva.
- Egy kitöltött képhelyőrző egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) segítségével képviselhető.
- Egy kitöltött diagramhelyőrző egy [IChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/) által van ábrázolva.
- Egy tartalomhelyőrző többféle tartalmat is tartalmazhat. Ellenőrizze mind a [IPlaceholder::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iplaceholder/get_type/) értékét, mind a futási időben elérhető alakzat interfészt, ahelyett, hogy feltételezné, hogy minden helyőrző egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iplaceholder/get_type/) leírja a helyőrző szerepét; nem garantálja az alakzat futási időbeli típusát. Mindig végezzen típusellenőrzést, mielőtt szöveg, kép, diagram, táblázat vagy média‑specifikus tagokhoz férne hozzá.
{{% /alert %}}

## **A helyőrzők öröklődésének megértése**

A helyőrzők hierarchiát alkotnak:

1. A mester dia határozza meg a újra felhasználható stílusokat, és bizonyos esetekben a mester szintű helyőrzőket.
2. Az elrendezés dia határozza meg a kiosztást, amelyet egy vagy több normál dia használ, és örökölhet a mesterből.
3. Egy normál dia a saját helyőrzőit tartalmazza, és örökölhet az elrendezéséből.

Hívja meg a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) metódust, hogy egy szinttel feljebb lépjen ebben a hierarchiában. Egy diahelyőrző általában visszaadja az elrendezéshelyőrzőjét; egy elrendezéshelyőrző visszaadhatja a mesterhelyőrzőjét. A metódus `nullptr`-t ad vissza, ha az alakzatnak nincs alaphelyőrzője.

A következő példa felsorolja az első dián lévő helyőrzőket, és jelentést készít azok alaphelyőrzőiről:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Egy helyőrző szerkesztése egy normál dián helyi felülírást hoz létre vagy módosít a dián. A kapcsolódó elrendezés vagy mester szerkesztése minden olyan diát befolyásolhat, amely még örökli azt a beállítást. Egy helyi szokásos alakzatnak nincs alaphelyőrzője, és nem kezd el öröklődni csak azért, mert ugyanazokat a koordinátákat foglalja el.

## **Szöveg módosítása egy helyőrzőben**

A cím, középre igazított cím, alcím, törzs és szöveghelyőrzők általában támogatják a szöveget. Ellenőrizze, hogy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) van‑e jelen, mielőtt a [get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_textframe/) metódust használja.

Ez a példa frissíti az első címhelyőrzőt az első dián, és elmenti az eredményt:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ez a minta elkerüli a kép, diagram, táblázat vagy médiahelyőrzők [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/)-re való átkasztását. Emellett a helyőrzőt a célja alapján azonosítja, ahelyett, hogy egy törékeny alakzat indexre támaszkodna.

## **Útmutató szöveg beállítása egy elrendezésen**

Az útmutató szöveg egy üres helyőrzőben megjelenő tervezési időbeli utasítás, például *Kattintson a cím hozzáadásához*. Állítson be saját útmutató szöveget az elrendezéshelyőrzőn, ahelyett, hogy egy normál dia alakzatelmélyítésén keresztül próbálná elérni. Az elrendezéshez a [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/get_layoutslide/) segítségével férhet hozzá, majd iteráljon a [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/get_shapes/) gyűjteményén.

A következő példa megváltoztatja a cím és az alcím útmutató szövegét az első dia által használt elrendezésen:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Az útmutató szöveg nem normál dia tartalom. A PowerPointhez hasonló szerkesztőalkalmazásokban üres helyőrzők számára szolgál utasításként. Amint a felhasználó vagy egy program valós tartalmat biztosít, az útmutató már nem jelenik meg. Az útmutató megváltoztatása nem írja felül a már létező szöveget azokban a diákban, amelyek az elrendezést használják.

## **Képhelyőrző frissítése**

Két esetet kell kezelni:

- Ha a képhelyőrző már ki van töltve, és egy [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) reprezentálja, cserélje a képet a [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/get_picture/) és a [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/set_image/) segítségével.
- Ha még üres helyőrző, adjon hozzá egy képkockát a helyőrző koordinátáihoz a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addpictureframe/) metódussal, majd távolítsa el az üres helyőrzőt.

A következő példa mindkét esetet támogatja, és elmenti a prezentációt:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Az üres helyőrzőhöz létrehozott helyettesítő egy helyi képkocka, nem új helyőrző, mivel a [IShape::get_Placeholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_placeholder/) csak olvasható. Megőrzi a lefoglalt pozíciót, de már nem örököl helyőrző‑specifikus viselkedést. Ha a helyőrzőkapcsolat megtartása lényeges, először készítse el és töltse fel a helyőrzőt PowerPointben, majd frissítse a kapott [IPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) objektumot az Aspose.Slides segítségével.

Képakárás, átlátszóság és egyéb kép‑specifikus effektusok tekintetében lásd a [Manage Picture Frames](/slides/hu/cpp/picture-frame/) cikket. Ezek a műveletek a képkockára vagy a képkitöltésre vonatkoznak, nem a helyőrző metaadataira.

## **Diagram és tartalomhelyőrzők kezelése**

Egy kitöltött diagramhelyőrző egy [IChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/) által van reprezentálva. Ez a példa a helyőrző típusa és a futási időbeli interfész alapján keresi meg a diagramot, módosítja a címét, majd elmenti a fájlt:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Az általános tartalomhelyőrző általában a [PlaceholderType::Object](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/) értékkel rendelkezik. PowerPointben ez többféle tartalomtípus (diagramok, táblázatok, diagramok, képek, média) indítását teszi lehetővé. Kitöltés után vizsgálja meg a tényleges alakzat interfészt, hogy megtudja, mit tartalmaz. Specializált elrendezések a [PlaceholderType::Chart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/) vagy [PlaceholderType::Diagram](https://reference.aspose.com/slides/hu/cpp/aspose.slides/placeholdertype/) típusokat is kiexponálhatja.

Az Aspose.Slides nem alakítja át egy üres [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) helyőrzőt egy [IChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/) objektummá csak a [IPlaceholder::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iplaceholder/get_type/) módosításával; a típus csak olvasható. Üres diagram vagy tartalom terület programozott feltöltéséhez adja hozzá a szükséges objektumot a helyőrző koordinátáihoz, majd távolítsa el az üres helyőrzőt. A következő példa ezt mutatja be egy diagram esetén:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

A hozzáadott diagram egy szokásos helyi diagram. Elfoglalja a helyőrző területét, de nem örököl az elrendezéshelyőrzőtől. Használja a dedikált [chart management articles](/slides/hu/cpp/powerpoint-charts/) útmutatót, ha cserélni kell a kategóriákat, sorozatokat vagy munkafüzet adatokat.

## **Teljes példa: Szöveg vagy kép tartalom frissítése**

Az alábbi végponttól‑végpontig tartó példa megnyit egy sablont, megkeresi az első dián a cím vagy kép helyőrzőt, ellenőrzi a helyőrző és az alakzat típusát, frissíti a megfelelő tartalmat, és elmenti a kimenetet. A példa szándékosan kerülőleg kerül a formaindex feltételezését vagy minden helyőrző egyforma interfészre történő átkasztását.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Mi az az alaphelyőrző?**

Az alaphelyőrző a megfelelő elrendezésen vagy mesteren lévő alakzat, amelyből egy másik helyőrző örököl. Használja a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getbaseplaceholder/) metódust a lekéréséhez. Egy szokásos helyi alakzat `nullptr`‑t ad vissza, mert nem része a helyőrzőhierarchiának.

**Módosíthatom‑e az összes dia címét egy elrendezéshelyőrző szerkesztésével?**

Az elrendezésen keresztül megváltoztathatja az örökölt formázást vagy az útmutató szöveget, de a meglévő cím tartalmak a normál diákon vannak tárolva. A cím szövegének tényleges cseréjéhez végig kell iterálni a diákon, és mindegyik címhelyőrzőt frissíteni kell.

**Hogyan kezelem a dátum, dia‑szám, fejléc és lábléc helyőrzőket?**

Használja a fejléc‑ és lábléc‑kezelőket a megfelelő diák, elrendezés, mester, jegyzet vagy előadás környezetben. Tekintse meg a [Manage Presentation Header and Footer](/slides/hu/cpp/presentation-header-and-footer/) cikket a teljes példákért.