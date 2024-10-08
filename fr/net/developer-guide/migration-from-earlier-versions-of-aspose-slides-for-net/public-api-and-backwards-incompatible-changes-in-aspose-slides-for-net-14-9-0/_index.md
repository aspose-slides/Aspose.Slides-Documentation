---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour .NET 14.9.0
type: docs
weight: 110
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 14.9.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Héritage des interfaces ICollection et IEnumerable génériques ajoutées à ISmartArtNodeCollection**
La classe Aspose.Slides.SmartArt.SmartArtNodeCollection (et l'interface associée Aspose.Slides.SmartArt.ISmartArtNodeCollection) hérite de l'interface générique IEnumerable<ISmartArtNode> et de l'interface ICollection.
#### **Valeur de l'énum SmartArtLayoutType.Custom ajoutée**
Le type de mise en page SmartArt Custom représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés que depuis un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Classe SmartArtShape et interface ISmartArtShape ajoutées**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) donne accès à des formes individuelles dans un diagramme SmartArt. SmartArtShape peut être utilisé pour changer FillFormat, LineFormat, ajouter des hyperliens et d'autres tâches.

{{% alert color="primary" %}} 

**Remarque**: SmartArtShape ne prend pas en charge les propriétés RawFrame, Frame, Rotation, X, Y, Width, Height d'IShape et lance une System.NotSupportedException lors de leur accès.

Exemple d'utilisation :

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
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) ajoutent l'accès à des formes individuelles dans un diagramme SmartArt. La collection contient des formes associées à SmartArtNode. La propriété SmartArtNode.Shapes retourne des collections de toutes les formes associées au nœud.

{{% alert color="primary" %}} 

**Remarque**: selon le SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

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
#### **Méthodes pour enregistrer des diapositives en gardant les numéros de page ajoutées**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent aux développeurs d'enregistrer les diapositives de présentation spécifiées au format PDF, XPS, TIFF, HTML. Le tableau 'slides' est utilisé pour spécifier les numéros de page, en commençant à partir de 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Tableau des positions des diapositives

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Méthodes pour remplacer des images ajoutées à PPImage, IPPImage**
Nouvelles méthodes ajoutées :

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Première méthode

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Deuxième méthode

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Troisième méthode

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 