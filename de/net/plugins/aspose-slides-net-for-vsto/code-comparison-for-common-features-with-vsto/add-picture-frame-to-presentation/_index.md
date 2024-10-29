---
title: Fügen Sie einen Bilderrahmen zur Präsentation hinzu
type: docs
weight: 50
url: /de/net/add-picture-frame-to-presentation/
---

## **VSTO**
Unten steht der Code zum Hinzufügen eines Bildes in einer VSTO-Präsentation:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Um einen einfachen Bilderrahmen zu Ihrer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Erstellen Sie ein Image-Objekt, indem Sie ein Bild zur Bildersammlung hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
1. Berechnen Sie die Breite und Höhe des Bildes.
1. Erstellen Sie einen PictureFrame gemäß der Breite und Höhe des Bildes, indem Sie die von dem Shapes-Objekt bereitgestellte AddPictureFrame-Methode verwenden, die mit der referenzierten Folie verbunden ist.
1. Fügen Sie einen Bilderrahmen (der das Bild enthält) zur Folie hinzu.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die oben genannten Schritte sind im folgenden Beispiel implementiert.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instanziieren Sie die Präsentationsklasse, die das PPTX darstellt

  Presentation pres = new Presentation();

  //Erhalten Sie die erste Folie

  ISlide sld = pres.Slides[0];

  //Instanziieren Sie die ImageEx-Klasse

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Fügen Sie einen Bilderrahmen mit Höhe und Breite des Bildes hinzu

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download des ausführbaren Codes**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Beispielcode**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)