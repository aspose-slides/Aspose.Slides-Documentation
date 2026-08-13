---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 15.4.0
linktitle: Aspose.Slides pour .NET 15.4.0
type: docs
weight: 150
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
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
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés et ainsi de suite [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/), ainsi que les autres changements introduits avec l'API Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Enum OrganizationChartLayoutType a été ajouté**
L'énumération Aspose.Slides.SmartArt.OrganizationChartLayoutType représente le type de formatage des nœuds enfants dans un organigramme.
#### **Méthode IBulletFormat.ApplyDefaultParagraphIndentsShifts a été ajoutée**
La méthode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts définit les décalages par défaut non nuls pour l'indentation de paragraphe effective et la marge gauche (MarginLeft) lorsque les puces sont activées (comme PowerPoint le fait lorsqu'on active les puces/numérotation de paragraphe). Si les puces sont désactivées, elle réinitialise simplement l'indentation de paragraphe et la marge gauche (comme PowerPoint le fait lorsqu'on désactive les puces/numérotation de paragraphe).

Voir des exemples [ici](/slides/fr/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx) :
#### **Méthode IConnector.Reroute a été ajoutée**
La méthode Aspose.Slides.IConnector.Reroute redirige le connecteur afin qu'il emprunte le chemin le plus court possible entre les formes qu'il relie. Pour ce faire, la méthode Reroute() peut modifier les propriétés StartShapeConnectionSiteIndex et EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
#### **Méthode IPresentation.GetSlideById a été ajoutée**
La méthode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) renvoie une Slide, MasterSlide ou LayoutSlide à partir de l'ID de la diapositive.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Propriété IShape.ConnectionSiteCount a été ajoutée**
La propriété Aspose.Slides.IShape.ConnectionSiteCount renvoie le nombre de points de connexion sur la forme.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
#### **Propriété ISmartArt.IsReversed a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArt.IsReversed permet d'obtenir ou de définir l'état du diagramme SmartArt par rapport à la direction de lecture (de gauche à droite) LTR ou (de droite à gauche) RTL, si le diagramme prend en charge l'inversion.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}

``` 
#### **Propriété ISmartArt.Nodes a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArt.Nodes renvoie la collection des nœuds racines de l'objet SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // sélectionner le deuxième nœud racine

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Propriété ISmartArtNode.IsHidden a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.IsHidden renvoie true si ce nœud est masqué dans le modèle de données.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //renvoie true

  if(hidden)

  {

    //effectuer certaines actions ou notifications

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Propriété ISmartArtNode.OrganizationChartLayout a été ajoutée**
La propriété Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permet d'obtenir ou de définir le type d'organigramme associé au nœud actuel.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Méthode set pour la propriété ISmartArt.Layout a été ajoutée**
La méthode set pour la propriété Aspose.Slides.SmartArt.ISmartArt.Layout a été ajoutée. Elle permet de modifier le type de mise en page d'un diagramme existant.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Modifications mineures de l'API**
**Voici la liste des modifications mineures de l'API :**

|Enum Aspose.Slides.BevelColorMode |supprimé, enum inutilisé |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |supprimée, propriété inutilisée |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |ajouté |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Héritage de IParagraphFormatEffectiveData depuis ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Héritage de IThreeDFormat depuis ISlideComponent |supprimé |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |supprimé car obsolète |