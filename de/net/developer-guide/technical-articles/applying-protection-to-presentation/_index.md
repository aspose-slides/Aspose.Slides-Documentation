---
title: Verhindern der Bearbeitung von Präsentationen mit Formschlössern in .NET
linktitle: Präsentationsbearbeitung verhindern
type: docs
weight: 70
url: /de/net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- Vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größe sperren
- Gruppierung sperren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für .NET Formen in PPT-, PPTX- und ODP-Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen ermöglicht."
---

## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Anwender von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, haben Zugriff auf die erzeugten Präsentationen, sodass der Schutz vor Bearbeitung ein häufiges Anliegen ist. Es ist wichtig, dass automatisch erzeugte Präsentationen ihre ursprüngliche Formatierung und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für .NET Schutz auf eine Präsentation anwenden und später entfernen kann. Er bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erzeugten Präsentationen verwendet werden.

## **Zusammensetzung einer Folie**

Eine Folie einer Präsentation besteht aus Komponenten wie Autoformen, Tabellen, OLE-Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungselementen und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für .NET wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) Interface implementiert oder von einer entsprechenden Klasse erbt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Sperre für alle Formtypen verwendet werden kann, verschiedene Formtypen unterschiedliche Sperren benötigen. Das [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) Interface ist die generische Sperrklasse für PPTX. Die folgenden Sperrtypen werden in Aspose.Slides für .NET für PPTX unterstützt:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) sperrt Verbindungselemente.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) sperrt gruppierte Formen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Jede auf alle Formobjekte in einem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Objekt ausgeführte Aktion wird auf die gesamte Präsentation angewendet.

## **Schutz anwenden und entfernen**

Das Anwenden von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik zum Schutz des Inhalts einer Präsentation.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für .NET stellt das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) Interface bereit, um mit Formen auf einer Folie zu arbeiten.

Wie bereits erwähnt, verfügt jede Formklasse über eine zugehörige Form‑Sperrklasse zum Schutz. Dieser Artikel konzentriert sich auf die Sperren NoSelect, NoMove und NoResize. Diese Sperren stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder in der Größe verändert werden können.

Das nachfolgende Code‑Beispiel wendet Schutz auf alle Formtypen in einer Präsentation an.
```cs
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert.
using Presentation presentation = new Presentation("Sample.pptx");

// Durchlaufen aller Folien in der Präsentation.
foreach (ISlide slide in presentation.Slides)
{
    // Durchlaufen aller Formen in der Folie.
    foreach (IShape shape in slide.Shapes)
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

// Speichern der Präsentationsdatei.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **Schutz entfernen**

Um eine Form zu entsperren, setzen Sie den Wert der angewendeten Sperre auf `false`. Das folgende Code‑Beispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden.
```cs
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Durchlaufen aller Folien in der Präsentation.
foreach (ISlide slide in presentation.Slides)
{
    // Durchlaufen aller Formen in der Folie.
    foreach (IShape shape in slide.Shapes)
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

// Speichern der Präsentationsdatei.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **Fazit**

Aspose.Slides bietet mehrere Optionen zum Schutz von Formen in einer Präsentation. Sie können eine einzelne Form sperren oder alle Formen in einer Präsentation durchlaufen und jede einzeln sperren, um die gesamte Datei effektiv zu sichern. Der Schutz kann entfernt werden, indem der Sperrwert auf `false` gesetzt wird.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Sperren beschränken die Bearbeitung von Objekten innerhalb der Datei, während [password protection](/slides/de/net/password-protected-presentation/) den Zugriff auf das Öffnen und/oder das Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich und arbeiten zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Sperren Sie die Formen auf den ausgewählten Folien; die übrigen Folien bleiben bearbeitbar.

**Gelten Form‑Sperren für gruppierte Objekte und Verbindungen?**

Ja. Für Gruppen, Verbindungen, Grafik‑Objekte und andere Formarten werden dedizierte Sperrtypen unterstützt.