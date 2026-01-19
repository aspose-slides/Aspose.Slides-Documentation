---
title: Präsentationssperrung
type: docs
weight: 110
url: /de/net/presentation-locking/
---

## **Präsentationssperrung**
Ein häufiger Anwendungsfall für **Aspose.Slides** ist das Erstellen, Aktualisieren und Speichern von Microsoft PowerPoint 2007 (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Benutzer der Anwendung, die Aspose.Slides auf diese Weise nutzt, erhalten Zugriff auf die erzeugten Präsentationen. Sie vor einer Bearbeitung zu schützen, ist ein gängiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dies erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für .NET Schutz auf eine Präsentation anwenden und anschließend wieder entfernen kann. Diese Funktion ist einzigartig für Aspose.Slides und war zum Zeitpunkt der Erstellung nicht in Microsoft PowerPoint verfügbar. Sie bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erstellten Präsentationen verwendet werden.
## **Aufbau einer Folie**
Eine PPTX‑Folie besteht aus einer Reihe von Komponenten wie Autoformen, Tabellen, OLE‑Objekten, Gruppenelementen, Bildrahmen, Video‑Frames, Verbindern und den verschiedenen anderen Elementen, die zum Aufbau einer Präsentation zur Verfügung stehen.

In Aspose.Slides für .NET wird jedes Element einer Folie in ein Shape‑Objekt umgewandelt. Anders ausgedrückt ist jedes Element auf der Folie entweder ein Shape‑Objekt oder ein von Shape abgeleitetes Objekt.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Sperrmechanismus für alle Formenarten verwendet werden kann, für verschiedene Formtypen unterschiedliche Sperrtypen existieren. Die Klasse BaseShapeLock ist die generische PPTX‑Sperrklasse. Die folgenden Sperrtypen werden in Aspose.Slides für .NET für PPTX unterstützt.

- AutoShapeLock sperrt Autoformen.  
- ConnectorLock sperrt Verbindungsformen.  
- GraphicalObjectLock sperrt grafische Objekte.  
- GroupshapeLock sperrt Gruppenelemente.  
- PictureFrameLock sperrt Bildrahmen.  

Jede auf alle Shape‑Objekte in einem Presentation‑Objekt angewandte Aktion gilt für die gesamte Präsentation.
## **Schutz anwenden und entfernen**
Der Einsatz von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.

**Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für .NET stellt die Klasse Shape zur Verfügung, um eine Form auf der Folie zu behandeln.

Wie bereits erwähnt, verfügt jede Formklasse über eine zugehörige Form‑Sperrklasse für den Schutz. Dieser Artikel konzentriert sich auf die Sperren NoSelect, NoMove und NoResize. Diese Sperren gewährleisten, dass Formen nicht ausgewählt (weder per Mausklick noch über andere Auswahlmethoden), bewegt oder in ihrer Größe verändert werden können.

Der folgende Code wendet Schutz auf alle Formtypen in einer Präsentation an.

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Schutz entfernen**

Der mit Aspose.Slides für .NET angewandte Schutz kann nur mit Aspose.Slides für .NET entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert der angewandten Sperre auf false. Der folgende Code zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden können.

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)