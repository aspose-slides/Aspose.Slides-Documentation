---
title: Einschränkung von Präsentationsbearbeitungen mit Form‑Sperren in C++
linktitle: Präsentationsbearbeitungen einschränken
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
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für C++ sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung einzuschränken."
---
## **Hintergrund**

Ein häufiger Anwendungsfall von Aspose.Slides für C++ besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, z. B. im Rahmen eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dazu beitragen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Mit diesen Sperren können Sie bestimmte Bearbeitungsoperationen für einzelne Formen einschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für C++ wird jedes Element einer Folie durch ein Objekt repräsentiert, das die [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Schnittstelle implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) Schnittstelle ist die Basisschnittstelle für Form‑Sperren. Aspose.Slides für C++ stellt die folgenden Sperrschnittstellen bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) sperrt Autoformen.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) sperrt Verbinderformen.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) sperrt Gruppierungsformen.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) sperrt Bildrahmen.

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Bewegen und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht unveränderlich.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für C++ stellt die [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) Schnittstelle zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel übergibt `true` an [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) und [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) für Autoformen, mit entsprechenden Sperren für Gruppierungsformen, Verbinder und Bildrahmen. Verbinder verwenden [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) für Bewegungen; Gruppen verwenden zudem [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/), um das Gruppieren einzuschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl-, Bewegungs- und Größenänderungs‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Es löscht zudem [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Fazit**

Aspose.Slides für C++ ermöglicht es Ihnen, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken oder dieselben Einschränkungen über mehrere Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [Kennwortschutz](/slides/de/cpp/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide im selben Dokument verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie die Sperren nur auf die Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) Methode der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für alle verschachtelten Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.