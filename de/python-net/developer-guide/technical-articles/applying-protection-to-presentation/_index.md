---
title: Präsentationsbearbeitungen mit Formulärsperren in Python verhindern
linktitle: Präsentationsbearbeitungen verhindern
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
- Schutz vor Bearbeitung
- Form sperren
- Position sperren
- Auswahl sperren
- Größe sperren
- Gruppierung sperren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Python via .NET Formen in PPT-, PPTX- und ODP-Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen sowie eine schnellere Bereitstellung ermöglicht."
---

## **Hintergrund**

Ein häufiger Anwendungsfall für Aspose.Slides besteht darin, Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, erhalten Zugriff auf die erzeugten Präsentationen, sodass deren Schutz vor Bearbeitung ein häufiges Anliegen ist. Es ist wichtig, dass automatisch erstellte Präsentationen ihr ursprüngliches Layout und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für Python einen Schutz für eine Präsentation anwenden und später wieder entfernen kann. Er bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erzeugten Präsentationen verwendet werden.

## **Aufbau einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungs‑elementen und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Python wird jedes Element einer Folie durch ein Objekt repräsentiert, das von der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Klasse erbt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Sperrmechanismus für alle Formtypen verwendet werden kann, verschiedene Formtypen unterschiedliche Sperren benötigen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) ist die generische Sperrklasse für PPTX. Die folgenden Sperrtypen werden in Aspose.Slides für Python für PPTX unterstützt:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) sperrt Verbindungsformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) sperrt Gruppierten Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Jede auf alle Formobjekte in einem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt ausgeführte Aktion wird auf die gesamte Präsentation angewendet.

## **Schutz anwenden und entfernen**

Durch das Anwenden von Schutz wird sichergestellt, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt der Präsentation zu schützen.

### **Schutz auf PPTX‑Formen anwenden**

Wie bereits erwähnt, hat jede Formklasse eine zugehörige Form‑Sperrklasse zum Schutz. Dieser Artikel konzentriert sich auf die Sperren NoSelect, NoMove und NoResize. Diese Sperren stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) werden können und dass sie nicht verschoben oder in ihrer Größe verändert werden können.

Das nachfolgende Code‑Beispiel wendet Schutz auf alle Formtypen in einer Präsentation an.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert.
with slides.Presentation("Sample.pptx") as presentation:
    # Durchlaufen aller Folien in der Präsentation.
    for slide in presentation.slides:
        # Durchlaufen aller Formen in der Folie.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Speichern der Präsentationsdatei.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Schutz entfernen**

Um eine Form zu entsperren, setzen Sie den Wert der angewendeten Sperre auf `False`. Das folgende Code‑Beispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Durchlaufen aller Folien in der Präsentation.
    for slide in presentation.slides:
        # Durchlaufen aller Formen in der Folie.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Speichern der Präsentationsdatei.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Fazit**

Aspose.Slides bietet mehrere Optionen zum Schutz von Formen in einer Präsentation. Sie können eine einzelne Form sperren oder durch alle Formen einer Präsentation iterieren und jede einzeln sperren, um die gesamte Datei effektiv zu sichern. Der Schutz kann entfernt werden, indem der Sperrwert auf `False` gesetzt wird.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Sperren beschränken die Bearbeitung von Objekten innerhalb der Datei, während [password protection](/slides/de/python-net/password-protected-presentation/) den Zugriff auf das Öffnen und/oder das Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich und arbeiten zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Sperren Sie die Formen auf den ausgewählten Folien; die übrigen Folien bleiben bearbeitbar.

**Gelten Form‑Sperren für gruppierte Objekte und Verbindungs‑elemente?**

Ja. Spezielle Sperrtypen werden für Gruppen, Verbindungs‑elemente, grafische Objekte und andere Formarten unterstützt.