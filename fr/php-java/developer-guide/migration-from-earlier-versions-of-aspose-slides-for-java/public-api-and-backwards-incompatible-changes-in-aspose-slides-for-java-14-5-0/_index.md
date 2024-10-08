---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 14.5.0
type: docs
weight: 40
url: /fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) de classes, méthodes, propriétés, etc., toutes les nouvelles [restrictions](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) et autres [changements](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduits avec l'API Aspose.Slides pour PHP via Java 14.5.0.

{{% /alert %}} 
## **API publique et changements incompatibles avec les versions précédentes**
### **Classes et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et des classes PresentationInfo**
Représente des informations sur la présentation.

La méthode Boolean isEncrypted() renvoie True si une présentation est chiffrée, sinon elle renvoie False.

La méthode LoadFormat getLoadFormat() renvoie le type de présentation.
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
Ces méthodes permettent aux développeurs d'obtenir des informations sur un fichier/flux de présentation sans charger toute la présentation.
#### **Ajout de la méthode IPresentationFactory PresentationFactory.getInstance()**
Permet d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.getFrame()**
Le code qui tente d'assigner un cadre indéfini à IShape.setFrame(IShapeFrame) n'a généralement pas de sens (particulièrement lorsque le GroupShape parent est multiple nesté dans d'autres {{GroupShape}}s). Par exemple :

```php
  $shape = $$missing$;
  $shape->setFrame(new ShapeFrame(Float::NaN, Float::NaN, Float::NaN, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, Float::NaN));
```

ou

```php
  slide.Shapes->AddAutoShape(ShapeType::RoundCornerRectangle, Float::NaN, Float::NaN, Float::NaN, Float::NaN);
```

Ce type de code peut conduire à des situations peu claires. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies pour IShape.Frame. Les valeurs x, y, width, height, flipH, flipV et rotationAngle doivent être définies (pas Float.NaN ou NullableBool.NotDefined). Le code exemple ci-dessus provoque maintenant une exception ArgumentException.
Cela s'applique à ces cas d'utilisation :

```php
  $shape = $$missing$;
  $shape->setFrame();// ne peut pas être indéfini

  $shapes = $$missing$;
  # les paramètres x, y, width, height ne peuvent pas être Float.NaN :
  {
    $shapes->addAudioFrameCD();
    $shapes->addAudioFrameEmbedded();
    $shapes->addAudioFrameLinked();
    $shapes->addAutoShape();
    $shapes->addChart();
    $shapes->addConnector();
    $shapes->addOleObjectFrame();
    $shapes->addPictureFrame();
    $shapes->addSmartArt();
    $shapes->addTable();
    $shapes->addVideoFrame();
    $shapes->insertAudioFrameEmbedded();
    $shapes->insertAudioFrameLinked();
    $shapes->insertAutoShape();
    $shapes->insertChart();
    $shapes->insertConnector();
    $shapes->insertOleObjectFrame();
    $shapes->insertPictureFrame();
    $shapes->insertTable();
    $shapes->insertVideoFrame();
  }
```

Mais le cadre d'IShape.getRawFrame() peut être indéfini. Cela a du sens lorsque la forme est liée à un espace réservé. Ensuite, les valeurs indéfinies du cadre de forme sont remplacées par celles de la forme de l'espace réservé parent. S'il n'y a pas de forme d'espace réservé parent pour cette forme, alors elle utilise des valeurs par défaut lors de l'évaluation du cadre effectif basé sur son IShape.getRawFrame(). Les valeurs par défaut sont 0 et NullableBool.False pour x, y, width, height, flipH, flipV et rotationAngle. Par exemple :

```php
  $shape = $$missing$;// la forme est liée à un espace réservé

  $shape->setRawFrame(new ShapeFrame(Float::NaN, Float::NaN, 100, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, 0));
  # maintenant la forme hérite des valeurs x, y, height, flipH, flipV de l'espace réservé et remplace width=100 et rotationAngle=0.
```
### **Propriétés modifiées**
#### **Changement de type et de nom de la méthode Aspose.Slides.IShapeCollection.getParent()**
Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été changé de ISlideComponent à la nouvelle interface IGroupShape. L'interface IGroupShape est un descendant de ISlideComponent, donc le code existant n'a pas besoin d'adaptation.

Le nom de la méthode Aspose.Slides.IShapeCollection.getParent() a été changé de getParent à getParentGroup().
#### **Changement de type des méthodes Aspose.Slides.IShapeFrame.getFlipH() et .getFlipV()**
Le type de la méthode Aspose.Slides.IShapeFrame.getFlipH() a été changé de bool à NullableBool.

La méthode IShape.getFrame() renvoie l'instance effective d'IShapeFrame (toutes les propriétés ayant des valeurs effectives définies).

La méthode IShape.getRawFrame() renvoie une instance d'IShapeFrame de laquelle chaque propriété peut avoir une valeur indéfinie (particulièrement FlipH ou FlipV peuvent avoir la valeur NullableBool.NotDefined).