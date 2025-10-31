---
title: Verhindern von Präsentationsbearbeitungen mit Formverschlüssen in Python
linktitle: Verhindern von Präsentationsbearbeitungen
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
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
description: "Entdecken Sie, wie Aspose.Slides für Python via .NET Formen in PPT-, PPTX- und ODP-Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen sowie eine schnellere Bereitstellung ermöglicht."
---

## **Hintergrund**

Ein häufiger Anwendungsfall für Aspose.Slides besteht darin, Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, erhalten Zugriff auf die generierten Präsentationen, sodass der Schutz vor Bearbeitung ein häufiges Anliegen ist. Es ist wichtig, dass automatisch erstellte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für Python Schutz auf eine Präsentation anwenden und später entfernen kann. Er bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erzeugten Präsentationen verwendet werden.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Videorahmen, Verbindungsformen und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Python wird jedes Element einer Folie durch ein Objekt repräsentiert, das von der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) erbt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Sperrmechanismus für alle Formtypen verwendet werden kann, unterschiedliche Formtypen verschiedene Sperren benötigen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) ist die generische Sperrklasse für PPTX. Die folgenden Sperrtypen werden in Aspose.Slides für Python für PPTX unterstützt:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) sperrt Verbindungsformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) sperrt Gruppenformen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Jede Aktion, die an allen Formobjekten in einem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt durchgeführt wird, wirkt sich auf die gesamte Präsentation aus.

## **Schutz anwenden und entfernen**

Der Einsatz von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt der Präsentation zu schützen.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Python stellt die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) zur Arbeit mit Formen auf einer Folie bereit. Wie bereits erwähnt, besitzt jede Formklasse eine zugehörige Form‑Sperrklasse zum Schutz. Dieser Artikel konzentriert sich auf die Sperren NoSelect, NoMove und NoResize. Diese Sperren stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder skaliert werden können.

Der folgende Code wendet Schutz auf alle Formtypen in einer Präsentation an.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, die eine PPTX‑Datei darstellt.
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

Um eine Form zu entsperren, setzen Sie den Wert der angewendeten Sperre auf `False`. Das folgende Codebeispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden können.

```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse, die eine PPTX‑Datei darstellt.
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

Aspose.Slides bietet mehrere Optionen zum Schutz von Formen in einer Präsentation. Sie können eine einzelne Form sperren oder über alle Formen in einer Präsentation iterieren und jede einzelne sperren, um die gesamte Datei effektiv zu sichern. Der Schutz kann entfernt werden, indem der Sperrwert auf `False` gesetzt wird.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Sperren beschränken die Bearbeitung von Objekten innerhalb der Datei, während [password protection](/slides/de/python-net/password-protected-presentation/) den Zugriff auf das Öffnen und/oder das Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich und arbeiten zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Sperren Sie die Formen auf den ausgewählten Folien; die übrigen Folien bleiben bearbeitbar.

**Gelten Form‑Sperren für gruppierte Objekte und Verbindungsformen?**

Ja. Spezielle Sperrtypen werden für Gruppen, Verbindungsformen, grafische Objekte und andere Formarten unterstützt.