---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour Java 14.5.0
type: docs
weight: 40
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) de classes, méthodes, propriétés, etc., toutes nouvelles [restrictions](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) et autres [changements](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduits avec l'API Aspose.Slides pour Java 14.5.0.

{{% /alert %}} 
## **API publique et changements incompatibles en arrière**
### **Classes et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et de la classe PresentationInfo**
Représente les informations sur la présentation.

La méthode Boolean isEncrypted() renvoie True si une présentation est chiffrée, sinon elle renvoie False.

La méthode LoadFormat getLoadFormat() obtient le type de présentation.
#### **Ajout de la méthode Aspose.Slides.IShape.isGrouped()**
La méthode Aspose.Slides.IShape.isGrouped() détermine si la forme est groupée.
#### **Ajout de la méthode Aspose.Slides.IShape.getParentGroup()**
La méthode Aspose.Slides.IShape.getParentGroup() renvoie l'objet GroupShape parent si la forme est groupée. Sinon, elle renvoie null.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.addGroupShape()**
La méthode Aspose.Slides.IShapeCollection.addGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.

La taille et la position du cadre GroupShape seront adaptées au contenu lorsque la nouvelle forme sera ajoutée au GroupShape.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.clear()**
La méthode Aspose.Slides.IShapeCollection.clear() supprime toutes les formes de la collection.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.insertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.insertGroupShape(int) crée un nouveau GroupShape et l'insère dans la collection à l'index spécifié. 
La taille et la position du cadre GroupShape seront adaptées au contenu lorsque la nouvelle forme sera ajoutée au GroupShape.
#### **Ajout des méthodes IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Ces méthodes permettent aux développeurs d'obtenir des informations sur un fichier/de flux de présentation sans charger complètement la présentation.
#### **Ajout de la méthode IPresentationFactory PresentationFactory.getInstance()**
Permet d'utiliser les fonctionnalités de la fabrique sans instanciation.
### **Restrictions**
#### **Des restrictions ont été ajoutées pour l’utilisation de valeurs indéfinies pour IShape.getFrame()**
Le code qui tente d'assigner un cadre indéfini à IShape.setFrame(IShapeFrame) n'a pas de sens dans les cas généraux (en particulier lorsque le GroupShape parent est nesté plusieurs fois dans d'autres {{GroupShape}}s). Par exemple :

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

ou

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Un tel code peut conduire à des situations floues. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Les valeurs de x, y, largeur, hauteur, flipH, flipV et angle de rotation doivent être définies (pas Float.NaN ou NullableBool.NotDefined). Le code d'exemple ci-dessus lance maintenant une exception ArgumentException.
Cela s'applique à ces cas d'utilisation :

``` java

 IShape shape = ...;

shape.setFrame(...); // ne peut pas être indéfini

IShapeCollection shapes = ...;

// les paramètres x, y, largeur, hauteur ne peuvent pas être Float.NaN :

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Mais le cadre IShape.getRawFrame() peut être indéfini. Cela a du sens lorsqu'une forme est liée à un espace réservé. Ensuite, les valeurs de cadre de forme indéfinies sont remplacées par celles de la forme d'espace réservé parent. S'il n'y a pas de forme d'espace réservé parent pour cette forme, elle utilise des valeurs par défaut lorsqu'elle évalue le cadre effectif en fonction de son IShape.getRawFrame(). Les valeurs par défaut sont 0 et NullableBool.False pour x, y, largeur, hauteur, flipH, flipV et angle de rotation. Par exemple :

``` java

 IShape shape = ...; // la forme est liée à l'espace réservé

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// maintenant, la forme hérite des valeurs x, y, hauteur, flipH, flipV de l'espace réservé et remplace largeur=100 et angle de rotation=0.

```
### **Propriétés modifiées**
#### **Changement de type et de nom de la méthode Aspose.Slides.IShapeCollection.getParent()**
Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est une descendante de ISlideComponent donc le code existant n'a pas besoin d'adaptation.

Le nom de la méthode Aspose.Slides.IShapeCollection.getParent() a été changé de getParent à getParentGroup().
#### **Changement de type des méthodes Aspose.Slides.IShapeFrame.getFlipH() et .getFlipV()**
Le type de la méthode Aspose.Slides.IShapeFrame.getFlipH() a été changé de bool à NullableBool.

La méthode IShape.getFrame() renvoie l'instance effective d'IShapeFrame (toutes ses propriétés ont des valeurs effectives définies).

La méthode IShape.getRawFrame() renvoie une instance IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (particulièrement FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).