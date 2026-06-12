---
title: Afbeeldingsframe toevoegen aan presentatie
type: docs
weight: 50
url: /nl/net/add-picture-frame-to-presentation/
---
## **VSTO**
Hieronder staat de code voor het toevoegen van een afbeelding in een VSTO-presentatie:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Om een eenvoudige afbeeldingsframe aan uw dia toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse Presentation.
2. Verkrijg de referentie van een dia door zijn index te gebruiken.
3. Maak een Image-object aan door een afbeelding toe te voegen aan de Images-collectie die bij het Presentation-object hoort en die wordt gebruikt om de Shape te vullen.
4. Bereken de breedte en hoogte van de afbeelding.
5. Maak een PictureFrame aan op basis van de breedte en hoogte van de afbeelding met behulp van de methode AddPictureFrame die beschikbaar is via het Shapes-object dat bij de referentie‑dia hoort.
6. Voeg een picture frame (bevat de afbeelding) toe aan de dia.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het onderstaande voorbeeld.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantieer de Presentation-klasse die de PPTX vertegenwoordigt

  Presentation pres = new Presentation();

  //Haal de eerste dia op

  ISlide sld = pres.Slides[0];

  //Instantieer de ImageEx-klasse

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Voeg een afbeeldingsframe toe met hoogte en breedte gelijk aan de afbeelding

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)