---
title: Einschränkung von Präsentationsbearbeitungen mit Form‑Sperren in C++
linktitle: Einschränkung von Präsentationsbearbeitungen
type: docs
weight: 10
url: /de/cpp/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
- Vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größenänderung sperren
- Gruppierung sperren
- PowerPoint
- PPTX
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für C++ sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides für C++ besteht darin, PowerPoint‑Präsentationen (PPTX) im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt beizubehalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungs­operationen für einzelne Formen zu beschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Aufbau einer Präsentation verwendet werden. In Aspose.Slides für C++ wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Interface implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperr‑Optionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Form‑Sperren. Aspose.Slides für C++ stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) sperrt Autoformen.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) sperrt Connector‑Formen.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) sperrt Gruppierte Formen.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) sperrt Bildrahmen.

Um Sperren über eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) hinweg anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Sperren anwenden und entfernen**

Kompatible Präsentations‑Editoren verwenden Form‑Sperren, um einzelne Bearbeitungs­operationen zu beschränken. Dateiverschlüsselung und schreibgeschützter Dokumentschutz sind separate [presentation protection settings](/slides/de/cpp/password-protected-presentation/).

### **Sperren auf PPTX‑Formen anwenden**

Aspose.Slides für C++ bietet das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Interface zur Arbeit mit Formen auf einer Folie.

Im Beispiel wird `true` an [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) und [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) für Autoformen übergeben, mit entsprechenden Sperren für Gruppierte Formen, Connectoren und Bildrahmen. Connectoren verwenden [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) für Bewegungen; Gruppen verwenden zudem [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in jeder Folien‑Form‑Sammlung und speichert eine Kopie mit diesen Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

### **Sperren entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und hebt die Auswahl‑, Bewegungs‑ und Größen‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) auf. Außerdem wird [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) zurückgesetzt und eine Kopie der Präsentation gespeichert. Andere Sperr‑Einstellungen bleiben unverändert.

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

### **Bild‑Zuschnitt erhalten**

Platzieren Sie ein Foto namens `photo.jpg` im Arbeitsverzeichnis. Das Beispiel schneidet 12 % von links und 8 % von rechts ab und ruft dann [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) auf der Bildrahmen‑Sperre auf, um den Zuschnitt zu bewahren und weiteres Zuschneiden zu verhindern.

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

`PictureLocked.pptx` speichert die Zuschnitt‑Sperre als `true`. In PowerPoint ist der Befehl **Zuschneiden** deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft dann [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) auf der Gruppen‑Sperre auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern einer Füllung, bleiben verfügbar.

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

`DiagramLocked.pptx` speichert die Gruppierung‑Aufhebung‑Sperre als `true`. In PowerPoint ist der Befehl **Gruppierung aufheben** deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Form‑Sperren melden**

Um ein Template zu prüfen, öffnen Sie es und lesen das Sperr‑Objekt jeder Form aus. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) gibt `true` zurück, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperr‑Objekte, daher sollten Sie die Kinder auch dann inspizieren, wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft Bewegungen für Autoformen, Bildrahmen und Gruppen, Zuschnitte für Bilder und Gruppierungs‑Aufhebung für Gruppen. Es meldet die erkannten Flags und markiert Formtypen, die nicht untersucht werden.

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

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrter Gruppierung‑Aufhebung, ein Bild namens `Photo` darin mit gesperrtem Zuschnitt und ein entsperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten form‑spezifischen Bearbeitungs‑Flags, ohne sie zu ändern oder die Präsentation zu speichern. Der Dokument‑Schreibschutz ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides für C++ ermöglicht es, bestimmte Bearbeitungs­operationen für einzelne Formen zu beschränken oder dieselben Einschränkungen über mehrere Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren aus und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungs­operationen, während [password protection](/slides/de/cpp/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Beide können in derselben Datei verwendet werden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie die Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperr‑Einstellungen anderer Folien nicht verändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Gruppen‑Methode [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) zurückgegeben wird, und setzen Sie die entsprechenden Sperren für jede Kindform. Wiederholen Sie dies für verschachtelte Gruppen gemäß dem Durchlauf im Reporting‑Beispiel.