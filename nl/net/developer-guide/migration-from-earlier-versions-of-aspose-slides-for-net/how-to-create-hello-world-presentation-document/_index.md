---
title: Hoe je Hello World‑presentaties maakt in .NET
linktitle: Hello World‑presentatie
type: docs
weight: 10
url: /nl/net/how-to-create-hello-world-presentation-document/
keywords:
- migratie
- hello world
- legacycode
- moderne code
- legacy‑aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
- description: "Maak een Hello World PowerPoint‑PPT, PPTX‑ en ODP‑presentatie in .NET met Aspose.Slides met zowel legacy‑ als moderne API’s in één eenvoudige gids."
---
{{% alert color="info" %}} 

Een nieuwe [Aspose.Slides for .NET API](/slides/nl/net/) is uitgebracht en nu biedt dit enkele product de mogelijkheid om PowerPoint‑documenten vanaf nul te genereren en bestaande te bewerken.

{{% /alert %}} 
## **Ondersteuning voor legacy‑code**
Om de legacy‑code die is ontwikkeld met Aspose.Slides voor .NET versies ouder dan 13.x te gebruiken, moet u enkele kleine aanpassingen in uw code doen en zal de code werken zoals voorheen. Alle klassen die aanwezig waren in het oude Aspose.Slides voor .NET onder de namespaces Aspose.Slide en Aspose.Slides.Pptx zijn nu samengevoegd in één enkele Aspose.Slides‑namespace. Bekijk de volgende eenvoudige code‑snippet voor het aanmaken van een Hello‑World‑presentatiedocument in de legacy Aspose.Slides‑API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengevoegde API.
## **Legacy‑aanpak van Aspose.Slides voor .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instantieer een Presentation-object dat een PPT-bestand vertegenwoordigt
Presentation pres = new Presentation();

//Maak een License-object
License license = new License();

//Stel de licentie van Aspose.Slides voor .NET in om de evaluatie-beperkingen te vermijden
license.SetLicense("Aspose.Slides.lic");

//Een lege dia toevoegen aan de presentatie en de referentie verkrijgen van
//die lege dia
Slide slide = pres.AddEmptySlide();

//Een rechthoek (X=2400, Y=1800, Breedte=1000 & Hoogte=500) aan de dia toevoegen
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//De lijnen van de rechthoek verbergen
rect.LineFormat.ShowLines = false;

//Een tekstframe aan de rechthoek toevoegen met "Hello World" als standaardtekst
rect.AddTextFrame("Hello World");

//Verwijder de eerste dia van de presentatie die altijd wordt toegevoegd door
//Aspose.Slides voor .NET standaard bij het maken van de presentatie
pres.Slides.RemoveAt(0);

//De presentatie opslaan als een PPT-bestand
pres.Write("C:\\hello.ppt");
```



## **Nieuwe Aspose.Slides voor .NET 13.x‑aanpak**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer een Presentation
Presentation pres = new Presentation();

// Verkrijg de eerste dia
ISlide sld = (ISlide)pres.Slides[0];

// Voeg een AutoShape van het type Rechthoek toe
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Voeg ITextFrame toe aan de Rechthoek
ashp.AddTextFrame("Hello World");

// Verander de tekstkleur naar Zwart (wat standaard Wit is)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Verander de lijnekleur van de rechthoek naar Wit
ashp.ShapeStyle.LineColor.Color = Color.White;

// Verwijder eventuele opvulopmaak in de vorm
ashp.FillFormat.FillType = FillType.NoFill;

// Sla de presentatie op op schijf
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```