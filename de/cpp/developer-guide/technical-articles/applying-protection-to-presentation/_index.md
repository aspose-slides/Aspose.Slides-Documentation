---
title: Verhindern von Präsentationsbearbeitungen mit Form-Sperren
linktitle: Präsentationsbearbeitungen verhindern
type: docs
weight: 10
url: /de/cpp/applying-protection-to-presentation/
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
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für C++ Formen in PPT-, PPTX- und ODP-Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen sowie eine schnellere Bereitstellung ermöglicht."
---

## **Hintergrund**

Ein häufiger Anwendungsfall für Aspose.Slides ist das Erstellen, Aktualisieren und Speichern von Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Benutzer von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, haben Zugriff auf die generierten Präsentationen, sodass der Schutz vor Bearbeitung ein gängiges Anliegen ist. Es ist wichtig, dass automatisch erstellte Präsentationen ihre ursprüngliche Formatierung und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für C++ einen Schutz auf eine Präsentation anwenden und später entfernen kann. Er bietet Entwicklern eine Möglichkeit, die Verwendung der von ihren Anwendungen erzeugten Präsentationen zu steuern.

## **Aufbau einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE-Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungs­linien und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für C++ wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Interface implementiert oder von einer entsprechenden Klasse erbt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Lock für alle Formtypen verwendet werden kann, unterschiedliche Formtypen unterschiedliche Locks benötigen. Das [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/)‑Interface ist die generische Sperrklasse für PPTX. Die folgenden Lock‑Typen werden in Aspose.Slides für C++ für PPTX unterstützt:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) sperrt Verbindungs­formen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) sperrt Gruppierte Formen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Jede auf alle Formobjekte in einem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt ausgeführte Aktion wird auf die gesamte Präsentation angewendet.

## **Schutz anwenden und entfernen**

Der Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt der Präsentation zu schützen.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für C++ stellt das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Interface bereit, um mit Formen auf einer Folie zu arbeiten.

Wie bereits erwähnt, besitzt jede Formklasse eine zugehörige Form‑Lock‑Klasse zum Schutz. Dieser Artikel konzentriert sich auf die Locks NoSelect, NoMove und NoResize. Diese Locks verhindern, dass Formen ausgewählt (durch Mausklicks oder andere Auswahlmethoden) sowie verschoben oder in ihrer Größe geändert werden können.

Der nachfolgende Code‑Beispiel wendet Schutz auf alle Formtypen in einer Präsentation an.
```cpp
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Durchlaufen aller Folien in der Präsentation.
for (auto&& slide : presentation->get_Slides())	{

	// Durchlaufen aller Formen in der Folie.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Typumwandlung der Form zu einer Autoform und Abrufen ihrer Form-Sperre.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Typumwandlung der Form zu einer Gruppierten Form und Abrufen ihrer Form-Sperre.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Typumwandlung der Form zu einer Verbindungslinie und Abrufen ihrer Form-Sperre.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Typumwandlung der Form zu einem Bildrahmen und Abrufen ihrer Form-Sperre.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Speichern der Präsentationsdatei.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **Schutz entfernen**

Um eine Form zu entsperren, setzen Sie den Wert des angewendeten Locks auf `false`. Der folgende Code‑Beispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden.
```cpp
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Durchlaufen aller Folien in der Präsentation.
for (auto&& slide : presentation->get_Slides())	{

	// Durchlaufen aller Formen in der Folie.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Typumwandlung der Form zu einer Autoform und Abrufen ihrer Form-Sperre.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Typumwandlung der Form zu einer Gruppierten Form und Abrufen ihrer Form-Sperre.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Typumwandlung der Form zu einer Verbindungslinie und Abrufen ihrer Form-Sperre.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Typumwandlung der Form zu einem Bildrahmen und Abrufen ihrer Form-Sperre.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Speichern der Präsentationsdatei.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Fazit**

Aspose.Slides bietet mehrere Optionen zum Schutz von Formen in einer Präsentation. Sie können eine einzelne Form sperren oder durch alle Formen einer Präsentation iterieren und jede einzelne sperren, um die gesamte Datei effektiv zu sichern. Der Schutz kann entfernt werden, indem der Lock‑Wert auf `false` gesetzt wird.

## **FAQ**

**Kann ich Form‑Locks und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Locks beschränken die Bearbeitung von Objekten innerhalb der Datei, während [Passwortschutz](/slides/de/cpp/password-protected-presentation/) den Zugriff beim Öffnen und/oder Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich und funktionieren zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Locks auf die Formen der ausgewählten Folien an; die übrigen Folien bleiben bearbeitbar.

**Gelten Form‑Locks für gruppierte Objekte und Verbindungs­linien?**

Ja. Spezielle Lock‑Typen werden für Gruppen, Verbindungs­linien, Grafik‑Objekte und andere Form­arten unterstützt.