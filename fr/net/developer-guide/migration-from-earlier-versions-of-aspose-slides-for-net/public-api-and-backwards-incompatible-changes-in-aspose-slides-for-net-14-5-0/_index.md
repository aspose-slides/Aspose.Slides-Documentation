---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 14.5.0
linktitle: Aspose.Slides pour .NET 14.5.0
type: docs
weight: 70
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) classes, méthodes, propriétés, etc., toutes les nouvelles [restrictions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) et autres [modifications](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduites avec l'Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **API publique et changements incompatibles rétroactifs**
### **Interfaces, classes, propriétés et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et de la classe PresentationInfo**
Représente les informations sur une présentation.

- La propriété booléenne IsEncrypted renvoie True si une présentation est chiffrée, sinon renvoie False.
- La propriété LoadFormat LoadFormat renvoie le type d'une présentation.
#### **Ajout de la propriété Aspose.Slides.IShape.IsGrouped**
La propriété Aspose.Slides.IShape.IsGrouped détermine si une forme est groupée.
#### **Ajout de la propriété Aspose.Slides.IShape.ParentGroup**
La propriété Aspose.Slides.IShape.ParentGroup renvoie l'objet GroupShape parent si une forme est groupée. Sinon elle renvoie null.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.AddGroupShape()**
La méthode Aspose.Slides.IShapeCollection.AddGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.
La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme est ajoutée.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.Clear()**
La méthode Aspose.Slides.IShapeCollection.Clear() supprime toutes les formes de la collection.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int) crée un nouveau GroupShape et l’insère dans la collection à l’index spécifié.
La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme est ajoutée.
#### **Ajout des méthodes IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Ces méthodes permettent d'obtenir des informations sur un fichier ou un flux de présentation sans charger entièrement la présentation.
#### **Ajout de la propriété IPresentationFactory PresentationFactory.Instance**
Cette propriété permet aux développeurs d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Restrictions concernant IShape.Frame**
Des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Le code qui tente d'assigner un cadre indéfini à IShape.Frame n'a pas de sens dans la plupart des cas (en particulier lorsque le GroupShape parent est imbriqué plusieurs fois dans d'autres {{GroupShape}}s). Par exemple:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

or

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Un tel code peut conduire à des situations ambiguës. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Les valeurs de x, y, width, height, flipH, flipV et rotationAngle doivent être définies (et ne pas être réglées à float.NaN ou NullableBool.NotDefined). Le code d'exemple ci‑dessus génère maintenant une exception ArgumentException.
Cela s'applique aux cas d'utilisation suivants:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

Mais les propriétés du cadre IShape.RawFrame peuvent être indéfinies. Cela a du sens lorsqu'une forme est liée à un espace réservé. Alors les valeurs de cadre indéfinies sont remplacées par celles de la forme espace réservé parente. S'il n'existe pas d'espace réservé parent, la forme utilise les valeurs par défaut lors du calcul du cadre effectif basé sur son IShape.RawFrame. Les valeurs par défaut sont 0 et NullableBool.False pour x, y, width, height, flipH, flipV et rotationAngle. Par exemple:

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **Propriétés modifiées**
#### **Modification du nom et du type de la propriété Aspose.Slides.IShapeCollection.Parent**
- Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est un descendant de ISlideComponent, donc le code existant n'a besoin d'aucune adaptation.
- Le nom de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de Parent à ParentGroup.
#### **Modification des types des propriétés Aspose.Slides.IShapeFrame.FlipH et .FlipV**
- Le type de la propriété Aspose.Slides.IShapeFrame.FlipH a été changé de bool à NullableBool.
- La propriété IShape.Frame renvoie une instance effective d'IShapeFrame (toutes ses propriétés ayant des valeurs effectives définies).
- La propriété IShape.RawFrame renvoie une instance d'IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (en particulier FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).