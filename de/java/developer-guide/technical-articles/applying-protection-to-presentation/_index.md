---
title: Verhindern von Präsentationsbearbeitungen mit Form‑Sperren
linktitle: Verhindern von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/java/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
- Vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größe sperren
- Gruppierung sperren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Java Formen in PPT-, PPTX- und ODP‑Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen sowie schnellere Bereitstellung ermöglicht."
---

## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, haben Zugriff auf die erzeugten Präsentationen, sodass der Schutz vor Bearbeitung ein gängiges Anliegen ist. Es ist wichtig, dass automatisch erzeugte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für Java Schutz auf eine Präsentation anwenden und später wieder entfernen kann. Er gibt Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erzeugten Präsentationen verwendet werden.

## **Aufbau einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE-Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Java wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface implementiert oder von einer entsprechenden Klasse erbt.

Die Struktur von PPTX ist komplex, daher kann im Gegensatz zu PPT, wo ein generischer Lock für alle Formtypen verwendet werden kann, bei PPTX für unterschiedliche Formtypen unterschiedliche Locks erforderlich sein. Das [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/)‑Interface ist die generische Sperrklasse für PPTX. Die folgenden Lock‑Typen werden in Aspose.Slides für Java für PPTX unterstützt:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) sperrt Verbinderformen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) sperrt Gruppierungsformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Jede Aktion, die an allen Formobjekten in einem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekt durchgeführt wird, wirkt sich auf die gesamte Präsentation aus.

## **Schutz anwenden und entfernen**

Der Einsatz von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt der Präsentation zu schützen.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Java stellt das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface bereit, um mit Formen auf einer Folie zu arbeiten.

Wie bereits erwähnt, besitzt jede Formklasse eine zugehörige Form‑Lock‑Klasse für den Schutz. Dieser Artikel konzentriert sich auf die Locks NoSelect, NoMove und NoResize. Diese Locks verhindern, dass Formen ausgewählt werden können (durch Mausklicks oder andere Auswahlmethoden) und dass sie verschoben oder in der Größe verändert werden können.

Das folgende Beispiel wendet Schutz auf alle Formtypen in einer Präsentation an.
```java
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert.
Presentation presentation = new Presentation("Sample.pptx");

// Durchlaufen aller Folien in der Präsentation.
for (ISlide slide : presentation.getSlides()) {

    // Durchlaufen aller Formen in der Folie.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Typumwandlung der Form in eine Autoform und Abrufen der Form-Sperre.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Typumwandlung der Form in eine Gruppierungsform und Abrufen der Form-Sperre.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Typumwandlung der Form in eine Verbindungslinie und Abrufen der Form-Sperre.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Typumwandlung der Form in einen Bildrahmen und Abrufen der Form-Sperre.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Speichern der Präsentationsdatei.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Schutz entfernen**

Um eine Form zu entsperren, setzen Sie den Wert des angewendeten Locks auf `false`. Das folgende Beispiel zeigt, wie Formen in einer gesperrten Präsentation freigegeben werden.
```java
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei repräsentiert.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Durchlaufen aller Folien in der Präsentation.
for (ISlide slide : presentation.getSlides()) {

    // Durchlaufen aller Formen in der Folie.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Typumwandlung der Form in eine Autoform und Abrufen der Form-Sperre.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Typumwandlung der Form in eine Gruppierungsform und Abrufen der Form-Sperre.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Typumwandlung der Form in eine Verbindungslinie und Abrufen der Form-Sperre.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Typumwandlung der Form in einen Bildrahmen und Abrufen der Form-Sperre.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Speichern der Präsentationsdatei.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Fazit**

Aspose.Slides bietet mehrere Möglichkeiten, Formen in einer Präsentation zu schützen. Sie können eine einzelne Form sperren oder alle Formen einer Präsentation durchlaufen und jede einzeln sperren, um die gesamte Datei effektiv zu sichern. Der Schutz kann entfernt werden, indem der Lock‑Wert auf `false` gesetzt wird.

## **FAQ**

**Kann ich Form‑Locks und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Locks begrenzen die Bearbeitung von Objekten innerhalb der Datei, während der [Passwortschutz](/slides/de/java/password-protected-presentation/) den Zugriff beim Öffnen und/oder Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich gegenseitig und arbeiten zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Locks auf die Formen der ausgewählten Folien an; die übrigen Folien bleiben editierbar.

**Gelten Form‑Locks für gruppierte Objekte und Verbinder?**

Ja. Für Gruppen, Verbinder, grafische Objekte und andere Formarten werden dedizierte Lock‑Typen unterstützt.