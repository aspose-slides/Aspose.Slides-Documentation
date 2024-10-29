---
title: Präsentation Locking
type: docs
weight: 110
url: /de/net/presentation-locking/
---

## **Präsentation Locking**
Ein häufiges Einsatzgebiet für **Aspose.Slides** ist das Erstellen, Aktualisieren und Speichern von Microsoft PowerPoint 2007 (PPTX) Präsentationen im Rahmen eines automatisierten Workflows. Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwenden, erhalten Zugriff auf die ausgegebenen Präsentationen. Diese vor Bearbeitung zu schützen, ist ein häufiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Hier wird erklärt, wie Präsentationen und Folien aufgebaut sind und wie Aspose.Slides für .NET Schutz auf eine Präsentation anwenden und diesen dann wieder entfernen kann. Diese Funktion ist einzigartig für Aspose.Slides und ist zum Zeitpunkt des Schreibens in Microsoft PowerPoint nicht verfügbar. Sie bietet Entwicklern die Möglichkeit, zu steuern, wie die Präsentationen, die ihre Anwendungen erstellen, verwendet werden.

## **Zusammensetzung einer Folie**
Eine PPTX-Folie besteht aus verschiedenen Komponenten wie Autoformen, Tabellen, OLE-Objekten, gruppierten Formen, Bilderrahmen, Videorahmen, Verbindern und den verschiedenen anderen Elementen, die zur Erstellung einer Präsentation verfügbar sind.

In Aspose.Slides für .NET wird jedes Element auf einer Folie in ein Shape-Objekt umgesetzt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein Objekt, das vom Shape-Objekt abgeleitet ist.

Die Struktur von PPTX ist komplex, daher gibt es im Gegensatz zu PPT, wo ein generischer Lock für alle Arten von Shapes verwendet werden kann, verschiedene Arten von Locks für verschiedene Shape-Typen. Die BaseShapeLock-Klasse ist die generische PPTX-Locking-Klasse. Folgende Typen von Locks werden in Aspose.Slides für .NET für PPTX unterstützt.

- AutoShapeLock sperrt Autoformen.
- ConnectorLock sperrt Verbindungsformen.
- GraphicalObjectLock sperrt grafische Objekte.
- GroupshapeLock sperrt Gruppenformen.
- PictureFrameLock sperrt Bilderrahmen.

Jede Aktion, die an allen Shape-Objekten in einem Präsentationsobjekt durchgeführt wird, wird auf die gesamte Präsentation angewendet.

## **Anwenden und Entfernen von Schutz**
Das Anwenden von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.

**Anwendung des Schutzes auf PPTX Shapes**

Aspose.Slides für .NET bietet die Shape-Klasse zur Handhabung einer Form auf der Folie.

Wie bereits erwähnt, hat jede Shape-Klasse eine zugehörige Shape-Lock-Klasse zum Schutz. Dieser Artikel konzentriert sich auf die NoSelect-, NoMove- und NoResize-Locks. Diese Locks stellen sicher, dass Shapes nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht bewegt oder in der Größe verändert werden können.

Die folgenden Codebeispiele wenden Schutz auf alle Shape-Typen in einer Präsentation an.

``` csharp

 //Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt


//ISlide-Objekt zum Zugreifen auf die Folien in der Präsentation

SlideEx slide = pTemplate.Slides[0];

//IShape-Objekt zum Halten von temporären Shapes

ShapeEx shape;

//Durchlaufen aller Folien in der Präsentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Durchlaufen aller Shapes in den Folien

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//wenn shape eine Autoform ist

		if (shape is AutoShapeEx)

		{

			//Typumwandlung in Autoform und Abrufen des Autoform-Locks

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Anwenden der Shape-Locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//wenn shape eine Gruppenform ist

		else if (shape is GroupShapeEx)

		{

			//Typumwandlung in Gruppenform und Abrufen des Gruppenform-Locks

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Anwenden der Shape-Locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//wenn shape ein Verbindungsstück ist

		else if (shape is ConnectorEx)

		{

			//Typumwandlung in Verbindungsform und Abrufen des Verbindungsform-Locks

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Anwenden der Shape-Locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//wenn shape ein Bilderrahmen ist

		else if (shape is PictureFrameEx)

		{

			//Typumwandlung in Bilderrahmen-Form und Abrufen des Bilderrahmen-Locks

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Anwenden der Shape-Locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Speichern der Präsentationsdatei

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Entfernen des Schutzes**

Der durch Aspose.Slides für .NET angewendete Schutz kann nur mit Aspose.Slides für .NET entfernt werden. Um ein Shape zu entsperren, setzen Sie den Wert des angewendeten Locks auf false. Das folgende Codebeispiel zeigt, wie Sie Shapes in einer gesperrten Präsentation entsperren.

``` csharp

 //Öffnen der gewünschten Präsentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide-Objekt zum Zugreifen auf die Folien in der Präsentation

SlideEx slide = pTemplate.Slides[0];

//IShape-Objekt zum Halten von temporären Shapes

ShapeEx shape;

//Durchlaufen aller Folien in der Präsentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Durchlaufen aller Shapes in den Folien

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//wenn shape eine Autoform ist

		if (shape is AutoShapeEx)

		{

			//Typumwandlung in Autoform und Abrufen des Autoform-Locks

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Anwenden der Shape-Locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//wenn shape eine Gruppenform ist

		else if (shape is GroupShapeEx)

		{

			//Typumwandlung in Gruppenform und Abrufen des Gruppenform-Locks

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Anwenden der Shape-Locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//wenn shape eine Verbindungsform ist

		else if (shape is ConnectorEx)

		{

			//Typumwandlung in Verbindungsform und Abrufen des Verbindungsform-Locks

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Anwenden der Shape-Locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//wenn shape ein Bilderrahmen ist

		else if (shape is PictureFrameEx)

		{

			//Typumwandlung in Bilderrahmen-Form und Abrufen des Bilderrahmen-Locks

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Anwenden der Shape-Locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Speichern der Präsentationsdatei

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Beispielcode Herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)