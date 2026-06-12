---
title: Presentatievergrendeling
type: docs
weight: 110
url: /nl/net/presentation-locking/
---
## **Presentatievergrendeling**
Een veelvoorkomende toepassing van **Aspose.Slides** is het maken, bijwerken en opslaan van Microsoft PowerPoint 2007 (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Gebruikers van de toepassing die Aspose.Slides op deze manier gebruikt, krijgen toegang tot de resulterende presentaties. Het beschermen tegen bewerking is een veelvoorkomend punt van zorg. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit legt uit hoe presentaties en dia's worden opgebouwd en hoe Aspose.Slides voor .NET bescherming kan toepassen op een presentatie en deze vervolgens kan verwijderen. Deze functie is uniek voor Aspose.Slides en is op het moment van schrijven nog niet beschikbaar in Microsoft PowerPoint. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun toepassingen maken, worden gebruikt.
## **Samenstelling van een dia**
Een PPTX-dia bestaat uit een aantal componenten, zoals automatische vormen, tabellen, OLE-objecten, gegroepeerde vormen, afbeeldingskaders, videokaders, connectoren en de verschillende andere elementen die beschikbaar zijn om een presentatie op te bouwen.

In Aspose.Slides voor .NET wordt elk element op een dia omgezet naar een Shape-object. Met andere woorden, elk element op de dia is ofwel een Shape-object of een object dat afgeleid is van het Shape-object.

De structuur van PPTX is complex, dus in tegenstelling tot PPT, waar een algemene vergrendeling voor alle soorten vormen kan worden gebruikt, zijn er verschillende soorten vergrendelingen voor verschillende vormtypen. De BaseShapeLock-klasse is de algemene PPTX-vergrendelingsklasse. De volgende soorten vergrendelingen worden ondersteund in Aspose.Slides voor .NET voor PPTX.

- AutoShapeLock vergrendelt automatische vormen.
- ConnectorLock vergrendelt connectorvormen.
- GraphicalObjectLock vergrendelt grafische objecten.
- GroupshapeLock vergrendelt gegroepeerde vormen.
- PictureFrameLock vergrendelt afbeeldingskaders.

Elke handeling die op alle Shape-objecten in een Presentation-object wordt uitgevoerd, is van toepassing op de volledige presentatie.
## **Bescherming toepassen en verwijderen**
Het toepassen van bescherming zorgt ervoor dat een presentatie niet kan worden bewerkt. Het is een handige techniek om de inhoud van een presentatie te beschermen.

**Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor .NET biedt de Shape‑klasse om een vorm op de dia te behandelen.

Zoals eerder vermeld heeft elke vormklasse een bijbehorende shape-lock-klasse voor bescherming. Dit artikel richt zich op de NoSelect-, NoMove- en NoResize‑vergrendelingen. Deze vergrendelingen zorgen ervoor dat vormen niet kunnen worden geselecteerd (via muisklikken of andere selectiemethoden) en dat ze niet kunnen worden verplaatst of van grootte veranderd.

De onderstaande code‑samples passen bescherming toe op alle vormtypen in een presentatie.

``` csharp

 //Instantiëren van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instantiëren van de Presentation-klasse die een PPTX-bestand vertegenwoordigt


//ISlide-object voor toegang tot de dia's in de presentatie
SlideEx slide = pTemplate.Slides[0];

//IShape-object voor het vasthouden van tijdelijke vormen
ShapeEx shape;

//Alle dia's in de presentatie doorlopen
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Alle vormen in de dia's doorlopen
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//indien vorm een AutoShape is
		if (shape is AutoShapeEx)
		{
			//Type-casting naar AutoShape en het ophalen van de AutoShape-vergrendeling
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			AutoShapeLock.PositionLocked = true;
			AutoShapeLock.SelectLocked = true;
			AutoShapeLock.SizeLocked = true;
		}
		//indien vorm een groepsvorm is
		else if (shape is GroupShapeEx)
		{
			//Type-casting naar groepsvorm en het ophalen van de groepsvorm-vergrendeling
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			groupShapeLock.GroupingLocked = true;
			groupShapeLock.PositionLocked = true;
			groupShapeLock.SelectLocked = true;
			groupShapeLock.SizeLocked = true;
		}
		//indien vorm een connector is
		else if (shape is ConnectorEx)
		{
			//Type-casting naar connector en het ophalen van de connector-vergrendeling
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			ConnLock.PositionMove = true;
			ConnLock.SelectLocked = true;
			ConnLock.SizeLocked = true;
		}
		//indien vorm een afbeeldingskader is
		else if (shape is PictureFrameEx)
		{
			//Type-casting naar afbeeldingskader en het ophalen van de afbeeldingskader-vergrendeling
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			PicLock.PositionLocked = true;
			PicLock.SelectLocked = true;
			PicLock.SizeLocked = true;
		}
	}
}

//De presentatie opslaan
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**Bescherming verwijderen**

Bescherming die met Aspose.Slides voor .NET is toegepast, kan alleen met Aspose.Slides voor .NET worden verwijderd. Om een vorm te ontgrendelen, stelt u de waarde van de toegepaste vergrendeling in op false. De onderstaande code‑sample laat zien hoe vormen in een vergrendelde presentatie worden ontgrendeld.

``` csharp

 //Open de gewenste presentatie

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide-object voor toegang tot de dia's in de presentatie

SlideEx slide = pTemplate.Slides[0];

//IShape-object voor het vasthouden van tijdelijke vormen

ShapeEx shape;

//Doorlopen van alle dia's in de presentatie

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Doorlopen van alle vormen in de dia's
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//indien vorm een autoshape is
		if (shape is AutoShapeEx)
		{
			//Typecasten naar Auto shape en het verkrijgen van de auto shape lock
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//indien vorm een groepsvorm is
		else if (shape is GroupShapeEx)
		{
			//Typecasten naar groepsvorm en het verkrijgen van de groepsvorm lock
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//indien vorm een connector is
		else if (shape is ConnectorEx)
		{
			//Typecasten naar connector shape en het verkrijgen van de connector lock
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//indien vorm een afbeeldingskader is
		else if (shape is PictureFrameEx)
		{
			//Typecasten naar picture frame shape en het verkrijgen van de picture frame lock
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Vergrendelingen op de vormen toepassen
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//De presentatie opslaan
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Voorbeeldcode downloaden**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)