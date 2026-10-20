---
title: Einschränken von Präsentationsbearbeitungen mit Form-Sperren in .NET
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 70
url: /de/net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größenänderung sperren
- Gruppierung sperren
- PowerPoint
- PPTX
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX-Präsentationen mit Aspose.Slides für .NET sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides für .NET besteht darin, PowerPoint‑(PPTX‑)Präsentationen zu erstellen, zu aktualisieren und zu speichern, als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Mit diesen Sperren können Sie bestimmte Bearbeitungs‑Operationen für einzelne Formen einschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungs‑Linien und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für .NET wird jedes Element auf einer Folie durch ein Objekt dargestellt, das das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Interface implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperr‑Optionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Form‑Sperren. Aspose.Slides für .NET stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) sperrt Connector‑Formen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) sperrt Gruppenformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht uneditierbar.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für .NET stellt das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Interface bereit, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel setzt [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) und [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) für Autoformen auf `true` und verwendet entsprechende Sperren für Gruppenformen, Connectoren und Bildrahmen. Connectoren nutzen [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) für Bewegungen; Gruppen verwenden außerdem [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl‑, Bewegungs‑ und Größenbeschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Es löscht außerdem [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Fazit**

Aspose.Slides für .NET ermöglicht es Ihnen, bestimmte Bearbeitungs‑Operationen für einzelne Formen zu beschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die für den jeweiligen Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungs‑Operationen, während [Passwortschutz](/slides/de/net/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung bestimmter Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht verändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑Sammlung der Gruppe und setzen die entsprechenden Sperren für jede Kindform. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.