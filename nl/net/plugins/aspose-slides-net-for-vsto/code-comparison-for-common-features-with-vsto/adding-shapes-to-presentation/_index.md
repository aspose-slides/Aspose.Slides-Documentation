---
title: Vormen toevoegen aan presentatie
type: docs
weight: 30
url: /nl/net/adding-shapes-to-presentation/
---
## **VSTO**
Hieronder staat de codefragment voor het toevoegen van een lijnvorm:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volg de onderstaande stappen:

- Maak een instantie van de klasse Presentation aan
- Verkrijg de referentie van een dia door de Index te gebruiken
- Voeg een AutoShape van het type Lijn toe met behulp van de AddAutoShape‑methode die wordt aangeboden door het Shapes‑object
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

``` csharp

   //Instantieer de Presentation-klasse die de PPTX vertegenwoordigt

  Presentation pres = new Presentation();

  //Haal de eerste dia op

  ISlide slide = pres.Slides[0];

  //Voeg een autovorm van het type lijn toe

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)