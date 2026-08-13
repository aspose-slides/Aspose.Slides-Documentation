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
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 
Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), ainsi que les nouvelles [restrictions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) et les autres [modifications](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduites avec l'API Aspose.Slides for .NET 14.5.0.
{{% /alert %}} 
## **API publique et modifications incompatibles rétroactives**
### **Interfaces, classes, propriétés et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et de la classe PresentationInfo**
Représente les informations sur la présentation.

- La propriété booléenne IsEncrypted renvoie True si une présentation est chiffrée, sinon renvoie False.
- La propriété LoadFormat LoadFormat renvoie le type d'une présentation.
#### **Ajout de la propriété Aspose.Slides.IShape.IsGrouped**
La propriété Aspose.Slides.IShape.IsGrouped détermine si une forme est groupée.
#### **Ajout de la propriété Aspose.Slides.IShape.ParentGroup**
La propriété Aspose.Slides.IShape.ParentGroup renvoie l'objet GroupShape parent si une forme est groupée. Sinon, elle renvoie null.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.AddGroupShape()**
La méthode Aspose.Slides.IShapeCollection.AddGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.
La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme est ajoutée.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.Clear()**
La méthode Aspose.Slides.IShapeCollection.Clear() supprime toutes les formes de la collection.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.InsertGroupShape(int) crée un nouveau GroupShape et l'insère dans la collection à la position d'index spécifiée.
La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme est ajoutée.
#### **Ajout des méthodes IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Ces méthodes permettent d'obtenir des informations sur un fichier ou un flux de présentation sans charger entièrement la présentation.
#### **Ajout de la propriété IPresentationFactory PresentationFactory.Instance**
Cette propriété permet aux développeurs d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Restrictions concernant IShape.Frame**
Des restrictions ont été ajoutées pour l'utilisation de valeurs non définies pour IShape.Frame. Le code qui tente d'assigner un cadre non défini à IShape.Frame n'a généralement aucun sens (en particulier lorsque le GroupShape parent est imbriqué plusieurs fois dans d'autres {{GroupShape}}s). Par exemple :

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Lance ArgumentException: les valeurs du cadre doivent être définies.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

ou

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lance ArgumentException: x, y, width et height doivent être définis.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Un tel code peut entraîner des situations peu claires. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs non définies pour IShape.Frame. Les valeurs de x, y, width, height, flipH, flipV et rotationAngle doivent être définies (et ne pas être assignées à float.NaN ou NullableBool.NotDefined). Le code d'exemple ci‑dessus lève maintenant une exception ArgumentException.
Cela s'applique aux cas d'utilisation suivants :

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Les paramètres x, y, width et height ne peuvent pas être float.NaN, et flipH, flipV
// ne peuvent pas être NullableBool.NotDefined :
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// La même restriction s'applique à chaque méthode qui crée une forme :
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Cependant, les propriétés de cadre IShape.RawFrame peuvent être indéfinies. Cela a un sens lorsqu'une forme est liée à un espace réservé. Dans ce cas, les valeurs de cadre indéfinies sont remplacées par celles du parent espace réservé. S'il n'existe aucun espace réservé parent, la forme utilise les valeurs par défaut lorsqu'elle évalue le cadre effectif à partir de son IShape.RawFrame. Les valeurs par défaut sont 0 et NullableBool.False pour x, y, width, height, flipH, flipV et rotationAngle. Par exemple :

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // La forme est liée à un espace réservé
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // maintenant la forme hérite des valeurs x, y, height, flipH, flipV de l'espace réservé et remplace width=100 et rotationAngle=0.
}
``` 
### **Propriétés modifiées**
#### **Modification du nom et du type de la propriété Aspose.Slides.IShapeCollection.Parent**
- Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été modifié de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est un descendant de ISlideComponent, ainsi le code existant ne nécessite aucune adaptation.
- Le nom de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de Parent à ParentGroup.
#### **Modification des types des propriétés Aspose.Slides.IShapeFrame.FlipH et .FlipV**
- Le type de la propriété Aspose.Slides.IShapeFrame.FlipH a été modifié de bool en NullableBool.
- La propriété IShape.Frame renvoie une instance effective de IShapeFrame (toutes les propriétés ayant des valeurs effectives définies).
- La propriété IShape.RawFrame renvoie une instance de IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (notamment FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).