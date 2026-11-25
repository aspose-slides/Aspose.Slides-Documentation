---
title: Omezení úprav prezentace pomocí zámků tvarů v C++
linktitle: Omezení úprav prezentace
type: docs
weight: 10
url: /cs/cpp/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- zamknout tvar
- zamknout umístění
- zamknout výběr
- zamknout změnu velikosti
- zamknout seskupování
- PowerPoint
- PPTX
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides pro C++, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné využití Aspose.Slides pro C++ je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak aplikovat a odebrat zámky tvarů v prezentaci PPTX. Tyto zámky vám umožňují omezit konkrétní editační operace na jednotlivých tvarech.

## **Složení snímku**

Prezentace je složena z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámce obrázků, rámce videa, spoje a další prvky používané při tvorbě prezentace. V Aspose.Slides pro C++ je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) je základní rozhraní pro zámky tvarů. Aspose.Slides pro C++ poskytuje následující rozhraní zámků:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) zamyká automatické tvary.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) zamyká spoje.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) zamyká seskupené tvary.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) zamyká rámce obrázků.

Pro použití zámků napříč [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), procházejte její snímky a nastavte příslušné zámky na každém podporovaném tvaru.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zámky tvarů k omezení individuálních editačních operací. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/cpp/password-protected-presentation/).

### **Použití ochrany na tvary PPTX**

Aspose.Slides pro C++ poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pro práci s tvary na snímku.

Příklad předává `true` metodám [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) a [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spoje a rámce obrázků. Spoje používají [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) pro pohyb; skupiny také používají [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) k omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními. Tvary mimo čtyři zpracovávané typy zůstávají beze změny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Odebrání ochrany**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) a [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Také vymaže [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají beze změny.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Zachování ořezu obrázku**

Umístěte fotografii s názvem `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté zavolá [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) na zámku rámce obrázku, aby zachoval ořez a omezil další ořezávání.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` ukládá zámek ořezu jako `true`. V PowerPointu je příkaz **Ořez** vypnutý, když je vybrána fotografie.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku, poté zavolá [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) na zámek skupiny, aby udržel komponenty diagramu dohromady. Ostatní úpravy, jako přesun skupiny nebo změna výplně komponentu, zůstávají dostupné.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` ukládá zámek rozdělení jako `true`. V PowerPointu je příkaz **Rozdělit** vypnutý, když je vybrán celý diagram.

### **Zpráva o existujících zámcích tvarů**

Pro revizi šablony ji otevřete a přečtěte objekt zámku pro každý tvar. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) vrací `true`, když jsou všechna příznaky na tomto objektu vypnutá, a `false`, když je alespoň jeden zapnutý. Skupina a její podřízené mají oddělené objekty zámků, takže i když skupina nemá zámky, je třeba kontrolovat podřízené.

Tento příklad kontroluje pohyb automatických tvarů, rámců obrázků a skupin, ořez pro obrázky a rozdělení pro skupiny. Zaznamenává rozpoznané příznaky a označuje typy tvarů, které neprozkoumává.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` se zamčeným rozdělením, obrázek pojmenovaný `Photo` uvnitř ní se zamčeným ořezem a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vypíše následující dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva čte uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

### **Závěr**

Aspose.Slides pro C++ vám umožňuje omezit konkrétní editační operace na jednotlivých tvarech nebo aplikovat stejná omezení napříč snímky. Vyberte zámky podporované konkrétním typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní editační operace, zatímco [ochrana heslem](/slides/cs/cpp/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Obě možnosti můžete použít ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích, aniž bych ovlivnil ostatní?**

Ano. Aplikujte zámky pouze na tvary na vybraných snímcích. Tím neovlivníte nastavení zámků na ostatních snímcích.

**Jak mohu aplikovat zámky na jednotlivé tvary uvnitř skupiny?**

Procházejte kolekci vrácenou metodou [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) skupiny a aplikujte příslušné zámky na každý podřízený tvar. Opakujte to pro jakékoli vnořené skupiny podle postupu v příkladu pro hlášení.