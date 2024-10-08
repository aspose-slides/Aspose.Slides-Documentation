---
title: Anwendung von Schutz auf Präsentationen
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint 2007 (PPTX) Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwenden, haben Zugang zu den ausgegebenen Präsentationen. Sie vor Bearbeitung zu schützen, ist ein häufiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihre ursprüngliche Formatierung und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie [Präsentationen und Folien konstruiert sind](/slides/de/python-net/applying-protection-to-presentation/) und wie Aspose.Slides für Python über .NET [Schutz anwendet](/slides/de/python-net/applying-protection-to-presentation/) und dann [von](/slides/de/python-net/applying-protection-to-presentation/) einer Präsentation entfernt. Dieses Feature ist einzigartig für Aspose.Slides und zum Zeitpunkt des Schreibens nicht in Microsoft PowerPoint verfügbar. Es gibt Entwicklern eine Möglichkeit, zu steuern, wie die Präsentationen, die ihre Anwendungen erstellen, verwendet werden.

{{% /alert %}} 
## **Zusammensetzung einer Folie**
Eine PPTX-Folie besteht aus mehreren Komponenten wie Autoformen, Tabellen, OLE-Objekten, gruppierten Formen, Bildrahmen, Video-Frames, Verbindern und verschiedenen anderen Elementen, die zum Erstellen einer Präsentation zur Verfügung stehen.

In Aspose.Slides für Python über .NET wird jedes Element auf einer Folie in ein Shape-Objekt umgewandelt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein von Shape abgeleitetes Objekt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Schließmechanismus für alle Formen verwendet werden kann, es unterschiedliche Arten von Schließmechanismen für verschiedene Formtypen gibt. Die Klasse BaseShapeLock ist die generische PPTX-Sperrklasse. Die folgenden Arten von Sperren werden in Aspose.Slides für Python über .NET für PPTX unterstützt.

- AutoShapeLock sperrt Autoformen.
- ConnectorLock sperrt Verbindungselemente.
- GraphicalObjectLock sperrt grafische Objekte.
- GroupshapeLock sperrt Gruppenformen.
- PictureFrameLock sperrt Bildrahmen.

Jede Aktion, die auf alle Shape-Objekte in einem Präsentationsobjekt ausgeführt wird, wird auf die gesamte Präsentation angewendet.
## **Anwendung und Entfernung von Schutz**
Der angewandte Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.
### **Anwendung von Schutz auf PPTX-Formen**
Aspose.Slides für Python über .NET bietet die Shape-Klasse, um eine Form auf der Folie zu handhaben.

Wie bereits erwähnt, hat jede Formklasse eine zugehörige Shape-Lock-Klasse zum Schutz. Dieser Artikel konzentriert sich auf die NoSelect-, NoMove- und NoResize-Sperren. Diese Sperren sorgen dafür, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder in der Größe verändert werden können.

Die folgenden Codebeispiele wenden Schutz auf alle Formtypen in einer Präsentation an.

```py
import aspose.slides as slides

#Instantiere die Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #ISlide-Objekt zum Zugriff auf die Folien in der Präsentation
    slide = pres.slides[0]

    #Durchlaufen aller Folien in der Präsentation
    for slide in pres.slides:
        for shape in slide.shapes:
            #wenn die Form eine Autoform ist
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #wenn die Form eine Gruppenform ist
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #wenn die Form ein Verbindungselement ist
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #wenn die Form ein Bildrahmen ist
            elif type(shape) is slides.PictureFrame:
                #Typumwandlung zu Bildrahmenform und Abrufen der Bildrahmen-Sperre
                picture_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Speichern der Präsentationsdatei
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Entfernen von Schutz**
Der mit Aspose.Slides für Python über .NET angewandte Schutz kann nur mit Aspose.Slides für Python über .NET entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert der angewandten Sperre auf false. Das folgende Codebeispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden.

```py
import aspose.slides as slides

#Öffnen der gewünschten Präsentation
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Anwenden von Form-Sperren
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Speichern der Präsentationsdatei
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **Zusammenfassung**
{{% alert color="primary" %}} 

Aspose.Slides bietet eine Reihe von Optionen, um Schutz auf Formen in einer Präsentation anzuwenden. Es ist möglich, eine bestimmte Form zu sperren oder durch alle Formen in einer Präsentation zu iterieren und sie alle zu sperren, um die Präsentation effektiv zu sperren.

Nur Aspose.Slides für Python über .NET kann den Schutz von einer Präsentation entfernen, die zuvor geschützt wurde. Entfernen Sie den Schutz, indem Sie den Wert einer Sperre auf false setzen.

{{% /alert %}} 