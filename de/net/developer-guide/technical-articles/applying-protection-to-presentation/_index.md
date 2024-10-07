---
title: Anwendung von Schutz auf Präsentationen
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint 2007 (PPTX) Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Die Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwenden, erhalten Zugriff auf die erstellten Präsentationen. Sie vor Bearbeitung zu schützen, ist ein häufiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie [Präsentationen und Folien aufgebaut sind](/slides/net/applying-protection-to-presentation/) und wie Aspose.Slides für .NET [Schutz anwenden kann](/slides/net/applying-protection-to-presentation/) und anschließend [von](/slides/net/applying-protection-to-presentation/) einer Präsentation entfernt. Diese Funktion ist einzigartig für Aspose.Slides und ist zum Zeitpunkt des Schreibens in Microsoft PowerPoint nicht verfügbar. Sie gibt Entwicklern die Möglichkeit, zu steuern, wie die Präsentationen, die ihre Anwendungen erstellen, verwendet werden.

{{% /alert %}} 
## **Zusammensetzung einer Folie**
Eine PPTX-Folie besteht aus einer Reihe von Komponenten wie Autoshapes, Tabellen, OLE-Objekten, gruppierten Formen, Bilderrahmen, Video-Frames, Verbindungen und anderen verschiedenen Elementen, die zur Erstellung einer Präsentation zur Verfügung stehen.

In Aspose.Slides für .NET wird jedes Element auf einer Folie in ein Shape-Objekt umgewandelt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein von Shape abgeleitetes Objekt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generisches Sperre für alle Formen verwendet werden kann, es unterschiedliche Sperrtypen für verschiedene Formtypen gibt. Die BaseShapeLock-Klasse ist die generische PPTX-Sperrklasse. Die folgenden Sperrtypen werden in Aspose.Slides für .NET für PPTX unterstützt.

- AutoShapeLock sperrt Autoshapes.
- ConnectorLock sperrt Verbindungselemente.
- GraphicalObjectLock sperrt grafische Objekte.
- GroupshapeLock sperrt Gruppierungen.
- PictureFrameLock sperrt Bilderrahmen.

Jede Aktion, die auf alle Shape-Objekte in einem Präsentationsobjekt ausgeführt wird, wird auf die gesamte Präsentation angewendet.
## **Anwenden und Entfernen von Schutz**
Das Anwenden von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.
### **Schutz auf PPTX-Formen anwenden**
Aspose.Slides für .NET stellt die Shape-Klasse zur Verfügung, um eine Form auf der Folie zu behandeln.

Wie bereits erwähnt, hat jede Formklasse eine zugehörige Shape-Sperrklasse zum Schutz. In diesem Artikel liegt der Fokus auf den Sperren NoSelect, NoMove und NoResize. Diese Sperren stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden), nicht verschoben oder in der Größe verändert werden können.

Die folgenden Codeschnipsel wenden Schutz auf alle Formtypen in einer Präsentation an.

```c#
//Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pTemplate = new Presentation("RectPicFrame.pptx");
           
//ISlide-Objekt zum Zugriff auf die Folien in der Präsentation
ISlide slide = pTemplate.Slides[0];

//IShape-Objekt zum Halten temporärer Formen
IShape shape;

//Durchlaufen aller Folien in der Präsentation
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Durchlaufen aller Formen in den Folien
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //Wenn die Form ein Autoshape ist
        if (shape is IAutoShape)
        {
            //Umwandlung in ein Autoshape und Abrufen des Autoshape-Sperrs
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Anwenden der Form-Sperren
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //Wenn die Form eine Gruppierung ist
        else if (shape is IGroupShape)
        {
            //Umwandlung in eine Gruppierung und Abrufen des Gruppen-Sperrs
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Anwenden der Form-Sperren
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //Wenn die Form ein Connector ist
        else if (shape is IConnector)
        {
            //Umwandlung in ein Connector-Shapel und Abrufen des Connector-Sperrs
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Anwenden der Form-Sperren
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //Wenn die Form ein Bilderrahmen ist
        else if (shape is IPictureFrame)
        {
            //Umwandlung in ein Bilderrahmen-Shape und Abrufen des Bilderrahmen-Sperrs
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Anwenden der Form-Sperren
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }
}

//Speichern der Präsentationsdatei
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Schutz entfernen**
Der mit Aspose.Slides für .NET angewandte Schutz kann nur mit Aspose.Slides für .NET entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert der angewendeten Sperre auf false. Der folgende Codeschnipsel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden.

```c#
//Öffnen der gewünschten Präsentation
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//ISlide-Objekt zum Zugriff auf die Folien in der Präsentation
ISlide slide = pTemplate.Slides[0];

//IShape-Objekt zum Halten temporärer Formen
IShape shape;

//Durchlaufen aller Folien in der Präsentation
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Durchlaufen aller Formen in den Folien
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //Wenn die Form ein Autoshape ist
        if (shape is IAutoShape)
        {
            //Umwandlung in ein Autoshape und Abrufen des Autoshape-Sperrs
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Anwenden der Form-Sperren
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //Wenn die Form eine Gruppierung ist
        else if (shape is IGroupShape)
        {
            //Umwandlung in eine Gruppierung und Abrufen des Gruppen-Sperrs
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Anwenden der Form-Sperren
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //Wenn die Form ein Connector ist
        else if (shape is IConnector)
        {
            //Umwandlung in ein Connector-Shape und Abrufen des Connector-Sperrs
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Anwenden der Form-Sperren
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //Wenn die Form ein Bilderrahmen ist
        else if (shape is IPictureFrame)
        {
            //Umwandlung in ein Bilderrahmen-Shape und Abrufen des Bilderrahmen-Sperrs
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Anwenden der Form-Sperren
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}

//Speichern der Präsentationsdatei
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Zusammenfassung**
{{% alert color="primary" %}} 

Aspose.Slides bietet eine Reihe von Optionen zum Anwenden von Schutz auf Formen in einer Präsentation. Es ist möglich, eine bestimmte Form zu sperren oder durch alle Formen in einer Präsentation zu iterieren und alle zu sperren, um die Präsentation effektiv zu schützen.

Nur Aspose.Slides für .NET kann den Schutz von einer zuvor geschützten Präsentation entfernen. Entfernen Sie den Schutz, indem Sie den Wert einer Sperre auf false setzen.

{{% /alert %}} 