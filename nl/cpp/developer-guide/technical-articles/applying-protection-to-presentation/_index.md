---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in C++
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 10
url: /nl/cpp/applying-protection-to-presentation/
keywords:
- voorkom bewerkingen
- bescherm tegen bewerken
- vergrendel vorm
- vergrendel positie
- vergrendel selectie
- vergrendel grootte aanpassen
- vergrendel groepering
- PowerPoint
- PPTX
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for C++ om selectie, verplaatsing, grootte‑aanpassing en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides for C++ is het maken, bijwerken en opslaan van PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay-out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe vormvergrendelingen toe te passen en te verwijderen in een PPTX-presentatie. Deze vergrendelingen laten u specifieke bewerkingen op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingsframes, videoframes, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for C++ wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑interface implementeert of van een klasse erft die dat doet.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) interface is de basinterface voor vormvergrendelingen. Aspose.Slides for C++ biedt de volgende vergrendelingsinterfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) vergrendelt autovormen.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) vergrendelt afbeeldingsframes.

Om vergrendelingen toe te passen over een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), doorloopt u de dia's en stelt u de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en aanpassen van de grootte van vormen. Ze maken de volledige presentatie niet onbewerkbaar.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for C++ biedt de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld geeft `true` door aan [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), en [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) voor autovormen, met gelijkwaardige vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingsframes. Connectoren gebruiken [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) voor verplaatsing; groepen gebruiken ook [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) om groepering te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia, en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier verwerkte typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de beperkingen voor selectie, verplaatsing en grootte‑aanpassing via [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), en [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Het wist ook [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Conclusie**

Aspose.Slides for C++ stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia's toe te passen. Kies de vergrendelingen die door elk type vorm worden ondersteund, en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/cpp/password-protected-presentation/) opening of wijziging van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Loop door de collectie die wordt geretourneerd door de [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, zodat ze geen vergrendelingen instellen op individuele groepsleden.