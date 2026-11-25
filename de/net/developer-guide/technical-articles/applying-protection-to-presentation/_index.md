---
title: Präsentationsbearbeitungen mit Form‑Sperren in .NET einschränken
linktitle: Präsentationsbearbeitungen einschränken
type: docs
weight: 70
url: /de/net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- Vor Bearbeitung schützen
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
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für .NET sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Ein häufiger Anwendungsfall von Aspose.Slides für .NET besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen, bestimmte Bearbeitungs­operationen für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für .NET wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Interface implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Form‑Sperren. Aspose.Slides für .NET stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) sperrt Verbindungsformen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) sperrt Gruppierungsformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentations‑Editoren verwenden Form‑Sperren, um einzelne Bearbeitungs­operationen einzuschränken. Dateiverschlüsselung und schreibgeschützte Dokument‑Ebene sind separate [Präsentations‑Schutzeinstellungen](/slides/de/net/password-protected-presentation/).

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für .NET stellt das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Interface zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel setzt [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) , [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) und [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) für Autoformen auf `true`, mit entsprechenden Sperren für Gruppierungsformen, Verbinder und Bildrahmen. Verbinder verwenden [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) für Bewegungen; Gruppen verwenden außerdem [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) , um das Gruppieren zu beschränken.

Das Beispiel lädt eine bestehende PPTX‑Präsentation, überprüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl‑, Bewegungs‑ und Größen‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) . Es löscht außerdem [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) , und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Bildausschnitt beibehalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts ab und setzt dann [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) auf dem Bildrahmen. Dieses Flag verhindert weiteres Zuschneiden und bewahrt den bestehenden Bildausschnitt.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` speichert die Zuschneide‑Sperre als `true`. In PowerPoint ist der Befehl **Crop** deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert behalten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und setzt anschließend [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) auf die Gruppe selbst, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung einer Komponente, bleiben verfügbar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` speichert die Entgruppier‑Sperre als `true`. In PowerPoint ist der Befehl **Ungroup** deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Form‑Sperren melden**

Um eine Vorlage zu überprüfen, öffnen Sie sie und lesen das Sperr‑Objekt jeder Form aus. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) ist `true`, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperr‑Objekte, daher sollten Sie die Kinder inspizieren, selbst wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung für Autoformen, Bildrahmen und Gruppen, das Zuschneiden für Bilder und das Entgruppieren für Gruppen. Es meldet die erkannte Flags und markiert Form‑Typen, die es nicht inspiziert.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrtem Entgruppieren, ein Bild namens `Photo` darin mit gesperrtem Zuschneiden und ein entsperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest gespeicherte, form‑spezifische Bearbeitungs‑Flags, ohne sie zu ändern oder die Präsentation zu speichern. Der schreibgeschützte Dokument‑Level ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

## **Fazit**

Aspose.Slides für .NET ermöglicht es, bestimmte Bearbeitungs­operationen für einzelne Formen einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungs­operationen, während [Passwortschutz](/slides/de/net/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beides in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Anwenden Sie Sperren nur auf die Formen der ausgewählten Folien. Dadurch werden die Sperreinstellungen anderer Folien nicht verändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑Sammlung der Gruppe und setzen Sie die entsprechenden Sperren für jede Kindform. Wiederholen Sie dies für verschachtelte Gruppen, indem Sie der Traversierung im Bericht‑Beispiel folgen.