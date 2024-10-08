---
title: API public et changements incompatibles avec les versions antérieures dans Aspose.Slides pour .NET 14.5.0
type: docs
weight: 70
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) de classes, méthodes, propriétés, etc., toutes les nouvelles [restrictions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) et autres [modifications](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduites avec l'API Aspose.Slides pour .NET 14.5.0.

{{% /alert %}} 
## **API publique et changements incompatibles avec les versions antérieures**
### **Interfaces, classes, propriétés et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et de la classe PresentationInfo**
Représente les informations sur la présentation.

- La propriété booléenne IsEncrypted obtient la valeur True si une présentation est cryptée, sinon elle obtient la valeur False.
- La propriété LoadFormat LoadFormat obtient le type d'une présentation.
#### **Ajout de la propriété Aspose.Slides.IShape.IsGrouped**
La propriété Aspose.Slides.IShape.IsGrouped détermine si une forme est groupée.
#### **Ajout de la propriété Aspose.Slides.IShape.ParentGroup**
La propriété Aspose.Slides.IShape.ParentGroup renvoie l'objet GroupShape parent si une forme est groupée. Sinon, cela renvoie null.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.AddGroupShape()**
La méthode Aspose.Slides.IShapeCollection.AddGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.
La taille et la position du cadre GroupShape seront ajustées au contenu lors de l'ajout d'une nouvelle forme.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.Clear()**
La méthode Aspose.Slides.IShapeCollection.Clear() supprime toutes les formes de la collection.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int) crée un nouveau GroupShape et l'insère dans la collection à la position d'index spécifiée.
La taille et la position du cadre GroupShape seront ajustées au contenu lors de l'ajout d'une nouvelle forme.
#### **Ajout des méthodes IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Ces méthodes permettent de recevoir des informations sur un fichier de présentation ou un flux sans charger entièrement la présentation.
#### **Ajout de la propriété IPresentationFactory PresentationFactory.Instance**
Cette propriété permet aux développeurs d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Restrictions à IShape.Frame**
Des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Le code qui tente d'assigner un cadre indéfini à IShape.Frame n'a pas de sens dans la plupart des cas (particulièrement lorsque le GroupShape parent est imbriqué plusieurs fois dans d'autres {{GroupShape}}s). Par exemple :

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

ou

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Un tel code peut conduire à des situations floues. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Les valeurs de x, y, largeur, hauteur, flipH, flipV et rotationAngle doivent être définies (et non définies comme float.NaN ou NullableBool.NotDefined). Le code exemple ci-dessus génère maintenant une exception ArgumentException.
Cela s'applique à ces cas d'utilisation :

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Ne peut pas être indéfini

IShapeCollection shapes = ...;

// Les paramètres x, y, largeur, hauteur ne peuvent pas être float.NaN :

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

Mais les propriétés de cadre IShape.RawFrame peuvent être indéfinies. Cela a du sens lorsqu'une forme est liée à un espace réservé. Alors, les valeurs de cadre de forme indéfinies sont remplacées par les valeurs du cadre d'espace réservé parent. S'il n'y a pas de cadre d'espace réservé parent, alors cette forme utilise des valeurs par défaut lorsqu'elle évalue le cadre effectif en fonction de son IShape.RawFrame. Les valeurs par défaut sont 0 et NullableBool.False pour x, y, largeur, hauteur, flipH, flipV et rotationAngle. Par exemple :

``` csharp

 IShape shape = ...; // la forme est liée à un espace réservé

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// maintenant la forme hérite des valeurs x, y, hauteur, flipH, flipV de l'espace réservé et remplace largeur=100 et rotationAngle=0.

``` 
### **Propriétés modifiées**
#### **Changement du nom et du type de la propriété Aspose.Slides.IShapeCollection.Parent**
- Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est un descendant de ISlideComponent, donc le code existant n'a pas besoin d'adaptations.
- Le nom de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de Parent à ParentGroup.
#### **Changement des types des propriétés Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Le type de la propriété Aspose.Slides.IShapeFrame.FlipH a été changé de bool à NullableBool.
- La propriété IShape.Frame renvoie une instance effective de IShapeFrame (toutes ses propriétés ayant des valeurs effectives définies).
- La propriété IShape.RawFrame renvoie une instance de IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (particulièrement FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).