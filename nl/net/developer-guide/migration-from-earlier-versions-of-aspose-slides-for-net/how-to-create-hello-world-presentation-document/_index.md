---
title: Hoe je Hello World-presentaties maakt in .NET
linktitle: Hello World-presentatie
type: docs
weight: 10
url: /nl/net/how-to-create-hello-world-presentation-document/
keywords:
- migratie
- hello world
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak een Hello World PowerPoint PPT, PPTX en ODP-presentatie in .NET met Aspose.Slides, gebruikmakend van zowel legacy- als moderne API's in één eenvoudige gids."
---
{{% alert color="info" %}} 

Een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) is uitgebracht en dit enkele product ondersteunt nu de mogelijkheid om PowerPoint-documenten vanaf nul te genereren en bestaande te bewerken.

{{% /alert %}} 
## **Ondersteuning voor legacy-code**
Om de legacy-code te gebruiken die is ontwikkeld met Aspose.Slides for .NET versies vóór 13.x, moet u enkele kleine wijzigingen in uw code aanbrengen en de code zal werken zoals eerder. Alle klassen die aanwezig waren in oude Aspose.Slides for .NET onder de namespaces Aspose.Slide en Aspose.Slides.Pptx zijn nu samengevoegd in één Aspose.Slides namespace. Bekijk het volgende eenvoudige code-fragment voor het maken van een Hello World-presentatiedocument in de legacy Aspose.Slides API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengevoegde API.
## **Legacy Aspose.Slides for .NET aanpak**
```c#
using System.Drawing;
using Aspose.Slides;

//Instantieer een Presentation-object dat een PPT-bestand voorstelt
Presentation pres = new Presentation();

//Maak een License-object aan
License license = new License();

//Stel de licentie van Aspose.Slides for .NET in om de evaluatie-beperkingen te vermijden
license.SetLicense("Aspose.Slides.lic");

//Voeg een lege dia toe aan de presentatie en verkrijg de referentie van
//die lege dia
Slide slide = pres.AddEmptySlide();

//Voeg een rechthoek (X=2400, Y=1800, Breedte=1000 & Hoogte=500) toe aan de dia
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Verberg de lijnen van de rechthoek
rect.LineFormat.ShowLines = false;

//Voeg een tekstframe toe aan de rechthoek met "Hello World" als standaardtekst
rect.AddTextFrame("Hello World");

//Verwijder de eerste dia van de presentatie die altijd wordt toegevoegd door
//Aspose.Slides for .NET standaard bij het maken van de presentatie
pres.Slides.RemoveAt(0);

//Schrijf de presentatie weg als een PPT-bestand
pres.Write("C:\\hello.ppt");
```



## **Nieuwe Aspose.Slides for .NET 13.x aanpak**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```