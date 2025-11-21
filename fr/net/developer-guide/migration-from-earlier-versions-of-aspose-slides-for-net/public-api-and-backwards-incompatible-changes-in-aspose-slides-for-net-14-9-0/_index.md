---
title: "API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 14.9.0"
linktitle: "Aspose.Slides pour .NET 14.9.0"
type: docs
weight: 110
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. ajoutées ou supprimées, ainsi que les autres changements introduits avec l'API Aspose.Slides pour .NET 14.9.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Héritage des interfaces ICollection et IEnumerable génériques ajouté à ISmartArtNodeCollection**
La classe Aspose.Slides.SmartArt.SmartArtNodeCollection (et l'interface associée Aspose.Slides.SmartArt.ISmartArtNodeCollection) héritent de l'interface générique IEnumerable<ISmartArtNode> et de l'interface ICollection.
#### **Valeur d'énumération SmartArtLayoutType.Custom ajoutée**
Le type de disposition SmartArt Custom représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés qu'à partir d'un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Classe SmartArtShape et interface ISmartArtShape ajoutées**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) donnent accès aux formes individuelles d'un diagramme SmartArt. SmartArtShape peut être utilisée pour modifier FillFormat, LineFormat, ajouter des hyperliens et d'autres opérations.

{{% alert color="primary" %}} 

**Note** : SmartArtShape ne prend pas en charge les propriétés IShape RawFrame, Frame, Rotation, X, Y, Width, Height et lève une System.NotSupportedException lorsqu’on tente d’y accéder.

Exemple d’utilisation :

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Classe SmartArtShapeCollection, interface ISmartArtShapeCollection et propriété ISmartArtNode.Shapes ajoutées**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) donnent accès aux formes individuelles d'un diagramme SmartArt. La collection contient les formes associées à SmartArtNode. La propriété SmartArtNode.Shapes renvoie les collections de toutes les formes associées au nœud.

{{% alert color="primary" %}} 

**Note** : selon le SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Méthodes d'enregistrement de diapositives avec conservation des numéros de page ajoutées**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent aux développeurs d’enregistrer des diapositives de présentation spécifiées aux formats PDF, XPS, TIFF, HTML. Le tableau *slides* sert à indiquer les numéros de page, à partir de 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Méthodes de remplacement d'images ajoutées à PPImage, IPPImage**
Nouvelles méthodes ajoutées :

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```