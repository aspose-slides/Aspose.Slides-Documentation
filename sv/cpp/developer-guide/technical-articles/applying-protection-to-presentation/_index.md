---
title: Begränsa presentationens redigeringar med formulås i C++
linktitle: Begränsa presentationens redigeringar
type: docs
weight: 10
url: /sv/cpp/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för C++ för att begränsa urval, förflyttning, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides for C++ är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former är organiserade på bildspel och hur man applicerar och tar bort formulås i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for C++ representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) eller ärver från en klass som gör det.

Olika formtyper exponerar olika låsalternativ. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) är basgränssnittet för formulås. Aspose.Slides for C++ tillhandahåller följande låsgränssnitt:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) låser autoshapes.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) låser connector shapes.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) låser graphical objects.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) låser group shapes.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) låser picture frames.

För att applicera lås över en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), iterera genom dess bilder och ställ in lämpliga lås på varje stödd form.

## **Applicera och ta bort skydd**

Kompatibla presentationsredigerare använder formulås för att begränsa individuella redigeringsåtgärder. Filkryptering och skrivskydd på dokumentnivå är separata [presentationsskyddsinställningar](/slides/sv/cpp/password-protected-presentation/).

### **Applicera skydd på PPTX-former**

Aspose.Slides for C++ tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) för att arbeta med former på en bild.

Exemplet skickar `true` till [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) och [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) för förflyttning; grupper använder också [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte underformerna i en grupp.

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

### **Ta bort skydd**

För att ta bort ett formulås, sätt dess värde till `false`. Följande exempel läser in en presentation med formulås och rensar urvalet, förflyttning och storleksändringsrestriktioner via [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) och [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Det rensar också [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

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

### **Bevara bildbeskärning**

Placera ett foto med namnet `photo.jpg` i arbetskatalogen. Exemplet beskär 12 % från vänster och 8 % från höger, och anropar sedan [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) på bildramens lås för att bevara beskärningen och begränsa ytterligare beskärning.

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

`PictureLocked.pptx` lagrar beskärningslåset som `true`. I PowerPoint är kommandot **Crop** inaktiverat när fotot är markerat.

### **Behålla ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och anropar sedan [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) på gruppens lås för att hålla diagrammets komponenter tillsammans. Andra redigeringar, såsom att flytta gruppen eller ändra en komponents fyllning, förblir tillgängliga.

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

`DiagramLocked.pptx` lagrar avgrupperingslåset som `true`. I PowerPoint är kommandot **Ungroup** inaktiverat när hela diagrammet är markerat.

### **Rapportera befintliga formulås**

För att granska en mall, öppna den och läs låsobjektet för varje form. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) returnerar `true` när alla flaggor på objektet är inaktiverade och `false` när minst en är aktiverad. En grupp och dess barn har separata låsobjekt, så inspektera barnen även när gruppen saknar lås.

Detta exempel kontrollerar förflyttning för autoshapes, bildramar och grupper, beskärning för bilder samt avgruppering för grupper. Det rapporterar de flaggor det känner igen och markerar formtyper som det inte inspekterar.

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

Anta att bild 1 i `Sample.pptx` innehåller en grupp med namnet `Layout` där avgruppering är låst, en bild med namnet `Photo` inuti den med beskärning låst, och en olåst rektangel med namnet `Free`. Rapporten hoppar över `Free` och skriver ut dessa två rader:

```text
Bild 1 | Layout | GroupShape | UngroupingLocked
Bild 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapporten läser lagrade redigeringsflaggor på formnivå utan att ändra dem eller spara presentationen. Skrivskydd på dokumentnivå är en separat inställning, och verkställandet av varje flagga beror på redigeraren.

### **Slutsats**

Aspose.Slides for C++ låter dig begränsa specifika redigeringsåtgärder på enskilda former eller applicera samma begränsningar på flera bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera formulås och lösenordsskydd i samma presentation?**

Ja. Formulås begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/cpp/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Applicera lås endast på formerna på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag applicera lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)-metod och applicera lämpliga lås på varje underform. Upprepa detta för eventuella nästlade grupper, enligt genomgången i rapportexemplet.