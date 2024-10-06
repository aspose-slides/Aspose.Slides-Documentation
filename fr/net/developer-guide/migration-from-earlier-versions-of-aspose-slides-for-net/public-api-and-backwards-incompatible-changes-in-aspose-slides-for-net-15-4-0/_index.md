---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 15.4.0
type: docs
weight: 150
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ou [supprimées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) et d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.4.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **L'énumération OrganizationChartLayoutType a été ajoutée**
L'énumération Aspose.Slides.SmartArt.OrganizationChartLayoutType représente le type de formatage des nœuds enfants dans un organigramme.
#### **La méthode IBulletFormat.ApplyDefaultParagraphIndentsShifts a été ajoutée**
La méthode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts définit des décalages par défaut non nuls pour l'indentation effective du paragraphe et la marge gauche lorsque les puces sont activées (comme PowerPoint le fait si les puces/numerotations de paragraphe sont activées). Si les puces sont désactivées, alors réinitialiser simplement l'indentation du paragraphe et la marge gauche (comme PowerPoint le fait si les puces/numerotations de paragraphe sont désactivées).

Voir des exemples [ici](/slides/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **La méthode IConnector.Reroute a été ajoutée**
La méthode Aspose.Slides.IConnector.Reroute redirige le connecteur de sorte qu'il prenne le chemin le plus court possible entre les formes qu'il connecte. Pour ce faire, la méthode Reroute() peut changer l'index du site de connexion de la forme de départ et l'index du site de connexion de la forme de fin.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **La méthode IPresentation.GetSlideById a été ajoutée**
La méthode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) renvoie une diapositive, un master slide ou une layout slide par l'ID de la diapositive.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **La propriété IShape.ConnectionSiteCount a été ajoutée**
La propriété Aspose.Slides.IShape.ConnectionSiteCount renvoie le nombre de sites de connexion sur la forme.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **La propriété ISmartArt.IsReversed a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArt.IsReversed permet d'obtenir ou de définir l'état du diagramme SmartArt en ce qui concerne (de gauche à droite) LTR ou (de droite à gauche) RTL, si le diagramme prend en charge l'inversion.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **La propriété ISmartArt.Nodes a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArt.Nodes renvoie la collection des nœuds racines dans l'objet SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // sélectionne le deuxième nœud racine

  node.TextFrame.Text = "Deuxième nœud racine";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **La propriété ISmartArtNode.IsHidden a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.IsHidden renvoie true si ce nœud est un nœud caché dans le modèle de données.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //renvoie true

  if(hidden)

  {

    //effectuer certaines actions ou notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **La propriété ISmartArtNode.OrganizationChartLayout a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permet d'obtenir ou de définir le type d'organigramme associé au nœud actuel.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **La méthode set pour la propriété ISmartArt.Layout a été ajoutée**
La méthode set pour la propriété Aspose.Slides.SmartArt.ISmartArt.Layout a été ajoutée. Elle permet de changer le type de mise en page d'un diagramme existant.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Changements mineurs de l'API**
**Voici la liste des changements mineurs de l'API :**

|Enum Aspose.Slides.BevelColorMode |supprimé, énumération non utilisée |
| :- | :- |
|Propriété ThreeDFormatEffectiveData.BevelColorMode |supprimée, propriété non utilisée |
|Propriété Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Propriété Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |ajoutée |
|Propriété Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Héritage de IParagraphFormatEffectiveData de ISlideComponent <br>Propriété Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Héritage de IThreeDFormat de ISlideComponent |supprimée |
|Propriété Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Propriété Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Propriété Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Propriété Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Propriété Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Propriété Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |supprimées comme obsolètes |