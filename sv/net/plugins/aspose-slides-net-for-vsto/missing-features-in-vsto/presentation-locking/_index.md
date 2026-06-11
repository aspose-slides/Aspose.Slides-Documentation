---
title: Låsning av presentation
type: docs
weight: 110
url: /sv/net/presentation-locking/
---
## **Låsning av presentation**
En vanlig användning för **Aspose.Slides** är att skapa, uppdatera och spara Microsoft PowerPoint 2007 (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationen som använder Aspose.Slides på detta sätt får åtkomst till de genererade presentationerna. Att skydda dem mot redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och sitt innehåll.

Detta förklarar hur presentationer och bilder konstrueras och hur Aspose.Slides för .NET kan tillämpa skydd på, och sedan ta bort det från, en presentation. Denna funktion är unik för Aspose.Slides och, vid skrivande stund, finns den inte i Microsoft PowerPoint. Den ger utvecklare ett sätt att kontrollera hur de presentationer deras applikationer skapar används.
## **Komposition av en bild**
En PPTX-bild består av ett antal komponenter som autoformer, tabeller, OLE-objekt, grupperade former, bildramar, videoram, anslutningar och olika andra element som finns för att bygga upp en presentation.

I Aspose.Slides för .NET omvandlas varje element på en bild till ett Shape-objekt. Med andra ord är varje element på bilden antingen ett Shape-objekt eller ett objekt som är härlett från Shape-objektet.

Strukturen i PPTX är komplex så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, finns det olika typer av lås för olika formtyper. Klassen BaseShapeLock är den generiska PPTX-låsklassen. Följande typer av lås stöds i Aspose.Slides för .NET för PPTX.

- AutoShapeLock låser autoformer.
- ConnectorLock låser anslutningsformer.
- GraphicalObjectLock låser grafiska objekt.
- GroupshapeLock låser gruppformer.
- PictureFrameLock låser bildramar.

Alla åtgärder som utförs på alla Shape-objekt i ett Presentation-objekt tillämpas på hela presentationen.
## **Tillämpa och ta bort skydd**
Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda en presentations innehåll.

**Tillämpa skydd på PPTX-former**

Aspose.Slides för .NET tillhandahåller Shape-klassen för att hantera en form på bilden.

Som nämnts tidigare har varje formklass en tillhörande shape lock-klass för skydd. Denna artikel fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom musklik eller andra urvalsmetoder), och att de inte kan flyttas eller ändras i storlek.

Kodexemplen nedan tillämpar skydd på alla formtyper i en presentation.

``` csharp

 //Instansiera Presentation-klassen som representerar en PPTX-fil

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instansiera Presentation-klassen som representerar en PPTX-fil


//ISlide-objekt för att komma åt bilderna i presentationen

SlideEx slide = pTemplate.Slides[0];

//IShape-objekt för att hålla tillfälliga former

ShapeEx shape;

//Traversering av alla bilder i presentationen

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Traversering av alla former i bilderna

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//om formen är en autoshape

		if (shape is AutoShapeEx)

		{

			//Typkonvertering till Auto shape och  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applicerar lås på former

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//om formen är en gruppform

		else if (shape is GroupShapeEx)

		{

			//Typkonvertering till gruppform och  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applicerar lås på former

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//om formen är en connector

		else if (shape is ConnectorEx)

		{

			//Typkonvertering till connector shape och  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applicerar lås på former

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//om formen är en bildram

		else if (shape is PictureFrameEx)

		{

			//Typkonvertering till bildram shape och  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applicerar lås på former

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Sparar presentationsfilen

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Ta bort skydd**

Skydd som tillämpats med Aspose.Slides för .NET kan endast tas bort med Aspose.Slides för .NET. För att låsa upp en form, sätt värdet på det tillämpade låset till false. Kodexemplet nedan visar hur man låser upp former i en låst presentation.

``` csharp

 //Öppna önskad presentation
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide-objekt för att komma åt bilderna i presentationen
SlideEx slide = pTemplate.Slides[0];

//IShape-objekt för att hålla tillfälliga former
ShapeEx shape;

//Traversering av alla bilder i presentationen
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Traversering av alla former i bilderna
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//om formen är en autoshape
		if (shape is AutoShapeEx)
		{
			//Typkonvertering till Auto shape och  hämtar auto shape lock
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Applicerar lås på former
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//om formen är en gruppform
		else if (shape is GroupShapeEx)
		{
			//Typkonvertering till gruppform och  hämtar gruppform lock
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Applicerar lås på former
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//om formen är en Connector shape
		else if (shape is ConnectorEx)
		{
			//Typkonvertering till connector-form och  hämtar connector shape lock
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Applicerar lås på former
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//om formen är en bildram
		else if (shape is PictureFrameEx)
		{
			//Typkonvertering till bildram-form och  hämtar picture frame shape lock
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Applicerar lås på former
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Sparar presentationsfilen
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Ladda ner exempel kod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)