---
title: Bildrahmen zur Präsentation hinzufügen
type: docs
weight: 50
url: /de/net/add-picture-frame-to-presentation/
---

## **VSTO**
Unten finden Sie den Code zum Hinzufügen eines Bildes in einer VSTO-Präsentation:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Um einen einfachen Bildrahmen zu Ihrer Folie hinzuzufügen, befolgen Sie bitte die untenstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Erstellen Sie ein Image-Objekt, indem Sie ein Bild zur Images-Sammlung hinzufügen, die mit dem Presentation-Objekt verknüpft ist und zum Füllen der Form verwendet wird.
4. Berechnen Sie die Breite und Höhe des Bildes.
5. Erstellen Sie einen PictureFrame entsprechend der Breite und Höhe des Bildes, indem Sie die AddPictureFrame-Methode des Shapes-Objekts verwenden, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie einen Bildrahmen (der das Bild enthält) zur Folie hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Die obigen Schritte sind im nachstehenden Beispiel implementiert.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)