---
title: Hoe Hello World‑presentaties te maken in .NET
linktitle: Hello World‑presentatie
type: docs
weight: 10
url: /nl/net/how-to-create-hello-world-presentation-document/
keywords:
- migratie
- hello world
- legacy‑code
- moderne code
- legacy‑aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak een Hello World PowerPoint‑PPT, PPTX‑ en ODP‑presentatie in .NET met Aspose.Slides, gebruikmakend van zowel legacy‑ als moderne API’s in één eenvoudige gids."
---
{{% alert color="primary" %}} 
Er is een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) uitgebracht en nu ondersteunt dit enkele product de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande documenten te bewerken. 
{{% /alert %}} 
## **Ondersteuning voor legacy‑code**
Om de legacy‑code te gebruiken die ontwikkeld is met Aspose.Slides for .NET voor versies ouder dan 13.x, moet u enkele kleine wijzigingen in uw code aanbrengen zodat de code weer werkt zoals daarvoor. Alle klassen die aanwezig waren in de oude Aspose.Slides for .NET onder de namespaces Aspose.Slide en Aspose.Slides.Pptx zijn nu samengevoegd in één Aspose.Slides‑namespace. Bekijk het onderstaande eenvoudige code‑fragment voor het maken van een Hello‑World‑presentatiedocument in de legacy Aspose.Slides‑API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengestelde API.
## **Legacy Aspose.Slides for .NET‑aanpak**
```c#
//Instantieer een Presentation-object dat een PPT‑bestand vertegenwoordigt
Presentation pres = new Presentation();

//Maak een License‑object
License license = new License();

//Stel de licentie van Aspose.Slides for .NET in om de evaluatie‑beperkingen te vermijden
license.SetLicense("Aspose.Slides.lic");

//Een lege slide toevoegen aan de presentatie en de referentie krijgen van
//die lege slide
Slide slide = pres.AddEmptySlide();

//Een rechthoek (X=2400, Y=1800, Breedte=1000 & Hoogte=500) toevoegen aan de slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//De lijnen van de rechthoek verbergen
rect.LineFormat.ShowLines = false;

//Een tekstkader toevoegen aan de rechthoek met "Hello World" als standaardtekst
rect.AddTextFrame("Hello World");

//Verwijderen van de eerste slide van de presentatie die altijd wordt toegevoegd door
//Aspose.Slides for .NET standaard bij het aanmaken van de presentatie
pres.Slides.RemoveAt(0);

//De presentatie opslaan als een PPT‑bestand
pres.Write("C:\\hello.ppt");
```

## **Nieuwe Aspose.Slides for .NET 13.x‑aanpak**
```c#
// Instantieer Presentation
Presentation pres = new Presentation();

// Haal de eerste slide op
ISlide sld = (ISlide)pres.Slides[0];

// Voeg een AutoShape van type Rechthoek toe
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Voeg ITextFrame toe aan de Rechthoek
ashp.AddTextFrame("Hello World");

// Verander de tekstkleur naar Zwart (wat standaard Wit is)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Verander de lijnkleur van de rechthoek naar Wit
ashp.ShapeStyle.LineColor.Color = Color.White;

// Verwijder alle opvulopmaak in de vorm
ashp.FillFormat.FillType = FillType.NoFill;

// Sla de presentatie op naar schijf
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```