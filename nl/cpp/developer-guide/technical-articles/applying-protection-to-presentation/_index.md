---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in C++
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 10
url: /nl/cpp/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- formaat vergrendelen
- groeperen vergrendelen
- PowerPoint
- PPTX
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties met Aspose.Slides voor C++ kunt vergrendelen en ontgrendelen om selectie, verplaatsing, formaatwijziging en groeperen te beperken."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides voor C++ is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay-out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia’s zijn georganiseerd en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Met deze vergrendelingen kunt u specifieke bewerkingsacties op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals AutoShapes, tabellen, OLE‑objecten, gegroepeerde vormen, afbeelding‑frames, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides voor C++ wordt elk element op een dia weergegeven door een object dat de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑interface implementeert of van een klasse erft die dat doet.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) interface is de basisklasse voor vormvergrendelingen. Aspose.Slides voor C++ levert de volgende vergrendelings‑interfaces:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) vergrendelt autosvormen.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) vergrendelt connectorvormen.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) vergrendelt grafische objecten.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) vergrendelt gegroepeerde vormen.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) vergrendelt afbeelding‑frames.

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), doorloopt u de dia’s en stelt u de juiste vergrendelingen in voor elke ondersteunde vorm.

## **Toepassen en verwijderen van beveiliging**

Compatibele presentatieredacteurs gebruiken vormvergrendelingen om individuele bewerkingsacties te beperken. Bestandversleuteling en document‑niveau schrijfbescherming zijn afzonderlijke [presentatie‑beveiligingsinstellingen](/slides/nl/cpp/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor C++ biedt de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface om met vormen op een dia te werken.

Het voorbeeld geeft `true` door aan [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) en [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) voor autosvormen, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectoren en afbeelding‑frames. Connectoren gebruiken [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) voor verplaatsing; groepen gebruiken ook [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormcollectie van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier verwerkte typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

### **Beveiliging verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `false`. Het onderstaande voorbeeld laadt een presentatie met vormvergrendelingen en verwijdert de selectie‑, verplaatsings‑ en formaat‑beperkingen via [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) en [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Het verwijdert ook [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Afbeeldingsuitsnede behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en roept daarna [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) aan op de afbeelding‑frame‑vergrendeling om de uitsnede te behouden en verdere bijsnijdingen te beperken.

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

`PictureLocked.pptx` slaat de uitsnede‑vergrendeling op als `true`. In PowerPoint is de opdracht **Crop** (Uitsnijden) uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) aan op de vergrendeling van de groep om de componenten van het diagram bij elkaar te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

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

`DiagramLocked.pptx` slaat de ontgroeperings‑vergrendeling op als `true`. In PowerPoint is de opdracht **Ungroup** (Degroeperen) uitgeschakeld wanneer het volledige diagram is geselecteerd.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te beoordelen, opent u deze en leest u het vergrendelingsobject voor elke vorm. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) geeft `true` terug wanneer alle vlaggen op dat object uitgeschakeld zijn en `false` wanneer er ten minste één is ingeschakeld. Een groep en haar onderliggende vormen hebben aparte vergrendelings‑objecten, dus inspecteer de onderliggende vormen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert verplaatsing voor autosvormen, afbeelding‑frames en groepen, uitsnijden voor afbeeldingen en ontgroeperen voor groepen. Het rapporteert de vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

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

Stel dat dia 1 van `Sample.pptx` een groep met de naam `Layout` bevat waarbij ontgroeperen vergrendeld is, een afbeelding met de naam `Photo` erin waarbij uitsnijden vergrendeld is, en een ontgrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en drukt deze twee regels af:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen vorm‑niveau bewerkingsvlaggen zonder ze te wijzigen of de presentatie op te slaan. Document‑niveau schrijfbescherming is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

## **Conclusie**

Aspose.Slides voor C++ stelt u in staat specifieke bewerkingsacties op individuele vormen te beperken of dezelfde beperkingen op meerdere dia’s toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en stel hun waarden in op `false` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsacties, terwijl [wachtwoordbeveiliging](/slides/nl/cpp/password-protected-presentation/) opening of wijziging van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking beperken op specifieke dia’s zonder anderen te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia’s. Dit verandert de vergrendelingsinstellingen op andere dia’s niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Itereer door de collectie die wordt geretourneerd door de [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor geneste groepen, volgens de doorloop in het rapportage‑voorbeeld.