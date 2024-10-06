---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour Java 14.5.0
type: docs
weight: 40
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), toutes les [restrictions](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduits avec l'API Aspose.Slides pour Java 14.5.0.

{{% /alert %}} 
## **API Publique et Changements Incompatibles avec les Versions Précédentes**
### **Classes et Méthodes Ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et des Classes PresentationInfo**
Représente des informations sur la présentation.

La méthode Boolean isEncrypted() retourne True si une présentation est cryptée, sinon retourne False.

La méthode LoadFormat getLoadFormat() obtient le type de présentation.
#### **Ajout de la Méthode Aspose.Slides.IShape.isGrouped()**
La méthode Aspose.Slides.IShape.isGrouped() détermine si la forme est groupée.
#### **Ajout de la Méthode Aspose.Slides.IShape.getParentGroup()**
La méthode Aspose.Slides.IShape.getParentGroup() retourne l'objet GroupShape parent si la forme est groupée. Sinon, elle retourne null.
#### **Ajout de la Méthode Aspose.Slides.IShapeCollection.addGroupShape()**
La méthode Aspose.Slides.IShapeCollection.addGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.

La taille et la position du cadre GroupShape seront ajustées au contenu lorsque la nouvelle forme sera ajoutée au GroupShape.
#### **Ajout de la Méthode Aspose.Slides.IShapeCollection.clear()**
La méthode Aspose.Slides.IShapeCollection.clear() supprime toutes les formes de la collection.
#### **Ajout de la Méthode Aspose.Slides.IShapeCollection.insertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.insertGroupShape(int) crée un nouveau GroupShape et l'insère dans la collection à l'index spécifié.
La taille et la position du cadre GroupShape seront ajustées au contenu lorsque la nouvelle forme sera ajoutée au GroupShape.
#### **Ajout des Méthodes IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Ces méthodes permettent aux développeurs de recevoir des informations sur un fichier/flux de présentation sans charger complètement la présentation.
#### **Ajout de la Méthode IPresentationFactory PresentationFactory.getInstance()**
Permet d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Des restrictions ont été ajoutées pour l'utilisation de valeurs non définies pour IShape.getFrame()**
Le code qui tente d'assigner un cadre non défini à IShape.setFrame(IShapeFrame) n'a pas de sens dans les cas généraux (particulièrement lorsque le GroupShape parent est multiple et imbriqué dans d'autres {{GroupShape}}). Par exemple :

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

ou

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Un tel code peut mener à des situations peu claires. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs non définies pour IShape.Frame. Les valeurs de x, y, width, height, flipH, flipV et rotationAngle doivent être définies (pas Float.NaN ou NullableBool.NotDefined). L'exemple de code ci-dessus lance maintenant une exception ArgumentException.
Cela s'applique à ces cas d'utilisation :

``` java

 IShape shape = ...;

shape.setFrame(...); // ne peut pas être indéfini

IShapeCollection shapes = ...;

// les paramètres x, y, width, height ne peuvent pas être Float.NaN :

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

Mais le cadre IShape.getRawFrame() peut être indéfini. Cela a du sens lorsqu'une forme est liée à un espace réservé. Ensuite, les valeurs de cadre de forme indéfinies sont remplacées par celles du shape parent de l'espace réservé. S'il n'y a pas de shape parent d'espace réservé pour cette forme, elle utilise des valeurs par défaut lorsqu'elle évalue le cadre effectif basé sur son IShape.getRawFrame(). Les valeurs par défaut sont 0 et NullableBool.False pour x, y, width, height, flipH, flipV et rotationAngle. Par exemple :

``` java

 IShape shape = ...; // la forme est liée à un espace réservé

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// maintenant la forme hérite des valeurs x, y, height, flipH, flipV de l'espace réservé et remplace width=100 et rotationAngle=0.

```
### **Propriétés Changées**
#### **Changement du Type et du Nom de la Méthode Aspose.Slides.IShapeCollection.getParent()**
Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est une sous-classe de ISlideComponent donc le code existant n'a pas besoin d'adaptation.

Le nom de la méthode Aspose.Slides.IShapeCollection.getParent() a été changé de getParent à getParentGroup().
#### **Changement du Type des Méthodes Aspose.Slides.IShapeFrame.getFlipH() et .getFlipV()**
Le type de la méthode Aspose.Slides.IShapeFrame.getFlipH() a été changé de bool à NullableBool.

La méthode IShape.getFrame() retourne l'instance effective de IShapeFrame (toutes ses propriétés ont des valeurs effectives définies).

La méthode IShape.getRawFrame() retourne une instance de IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (particulièrement FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).