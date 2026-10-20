---
title: Omezit úpravy prezentace pomocí zámků tvarů v C++
linktitle: Omezit úpravy prezentace
type: docs
weight: 10
url: /cs/cpp/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- ochránit před úpravami
- uzamknout tvar
- uzamknout pozici
- uzamknout výběr
- uzamknout změnu velikosti
- uzamknout seskupování
- PowerPoint
- PPTX
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak zamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides pro C++ a omezit výběr, přesun, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné použití Aspose.Slides pro C++ je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary organizovány na snímcích a jak použít a odebrat zámky tvarů v PPTX prezentaci. Tyto zámky vám umožňují omezit konkrétní operace úprav na jednotlivých tvarech.

## **Složení snímku**

Snímek prezentace se skládá z komponent, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, video rámečky, spoje a další prvky použité k vytvoření prezentace. V Aspose.Slides pro C++ je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) nebo z něj dědí.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) je základní rozhraní pro zámky tvarů. Aspose.Slides pro C++ poskytuje následující rozhraní zámků:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) zamyká automatické tvary.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) zamyká tvary spojů.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) zamyká seskupené tvary.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) zamyká rámečky obrázků.

Pro použití zámků napříč [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), iterujte přes její snímky a nastavte příslušné zámky na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Zámky tvarů omezují operace, jako je výběr, přesun a změna velikosti tvarů. Nezpřístupní celou prezentaci.

### **Použití ochrany na PPTX tvary**

Aspose.Slides pro C++ poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pro práci s tvary na snímku.

Příklad předává `true` metodám [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) a [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spoje a rámečky obrázků. Spoje používají [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) pro pohyb; skupiny také používají [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) pro omezení seskupování.

Příklad načte existující PPTX prezentaci, zkontroluje tvary v kolekci tvarů každého snímku a uloží kopii s těmito omezeními aplikovanými. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

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

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), a [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Také vymaže [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají nezměněna.

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

### **Závěr**

Aspose.Slides pro C++ vám umožňuje omezit konkrétní operace úprav na jednotlivých tvarech nebo použít stejná omezení napříč snímky. Vyberte zámky podporované daným typem tvaru a nastavte jejich hodnoty na `false`, pokud potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochrana heslem](/slides/cs/cpp/password-protected-presentation/) může omezit otevírání nebo úpravu prezentace. V souboru můžete použít obojí.

**Mohu omezit úpravy na konkrétních snímcích, aniž by to ovlivnilo ostatní?**

Ano. Pouze na tvary na vybraných snímcích použijte zámky. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu použít zámky na jednotlivé tvary uvnitř skupiny?**

Iterujte přes kolekci vrácenou metodou [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) skupiny a použijte příslušné zámky na každý podřízený tvar. Opakujte to pro jakékoli vnořené skupiny. Výše uvedené příklady zpracovávají pouze kolekci tvarů snímku, takže nenastavují zámky na jednotlivé členy skupiny.