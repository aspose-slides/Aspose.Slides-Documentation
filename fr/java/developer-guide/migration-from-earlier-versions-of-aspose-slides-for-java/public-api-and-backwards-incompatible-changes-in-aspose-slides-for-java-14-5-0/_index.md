---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides pour Java 14.5.0
type: docs
weight: 40
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides for Java pour migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 
Cette page répertorie toutes les classes, méthodes, propriétés et autres éléments [ajoutés](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ainsi que les nouvelles [restrictions](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) et les autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduites avec l'API Aspose.Slides for Java 14.5.0.
{{% /alert %}} 
## **API publique et changements incompatibles rétroactifs**
### **Classes et méthodes ajoutées**
#### **Ajout de l'interface Aspose.Slides.IPresentationInfo et des classes PresentationInfo**
Représente les informations sur la présentation.

Méthode Boolean isEncrypted() renvoie True si une présentation est chiffrée, sinon renvoie False.

Méthode LoadFormat getLoadFormat() renvoie le type de présentation.
#### **Ajout de la méthode Aspose.Slides.IShape.isGrouped()**
La méthode Aspose.Slides.IShape.isGrouped() détermine si la forme est groupée.
#### **Ajout de la méthode Aspose.Slides.IShape.getParentGroup()**
La méthode Aspose.Slides.IShape.getParentGroup() renvoie l'objet GroupShape parent si la forme est groupée. Sinon elle renvoie null.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.addGroupShape()**
La méthode Aspose.Slides.IShapeCollection.addGroupShape() crée un nouveau GroupShape et l'ajoute à la fin de la collection.

La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme sera ajoutée au GroupShape.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.clear()**
La méthode Aspose.Slides.IShapeCollection.clear() supprime toutes les formes de la collection.
#### **Ajout de la méthode Aspose.Slides.IShapeCollection.insertGroupShape(int)**
La méthode Aspose.Slides.IShapeCollection.insertGroupShape(int) crée un nouveau GroupShape et l'insère dans la collection à l'index spécifié.

La taille et la position du cadre du GroupShape seront ajustées au contenu lorsqu'une nouvelle forme sera ajoutée au GroupShape.
#### **Ajout des méthodes IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Ces méthodes permettent aux développeurs d'obtenir des informations sur un fichier/flux de présentation sans charger la présentation complète.
#### **Ajout de la méthode IPresentationFactory PresentationFactory.getInstance()**
Permet d'utiliser la fonctionnalité de la fabrique sans instanciation.
### **Restrictions**
#### **Des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies dans IShape.getFrame()**
Le code qui tente d'attribuer un cadre indéfini à IShape.setFrame(IShapeFrame) n'a pas de sens dans les cas généraux (en particulier lorsque le GroupShape parent est imbriqué plusieurs fois dans d'autres {{GroupShape}}s). Par exemple:
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Lance une ArgumentException : les valeurs du cadre doivent être définies.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```
ou
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lance une ArgumentException : les valeurs x, y, largeur et hauteur doivent être définies.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```
Un tel code peut entraîner des situations ambiguës. Ainsi, des restrictions ont été ajoutées pour l'utilisation de valeurs indéfinies dans IShape.Frame. Les valeurs de x, y, width, height, flipH, flipV et rotationAngle doivent être définies (pas Float.NaN ou NullableBool.NotDefined). Le code d'exemple ci‑above lève désormais une exception ArgumentException.
Cela s'applique aux cas d'utilisation suivants:
``` java
// Le cadre passé à IShape.setFrame(IShapeFrame) ne peut pas contenir de valeurs indéfinies.
// 
// Les paramètres x, y, largeur et hauteur des méthodes IShapeCollection suivantes
// ne peuvent pas non plus être Float.NaN :
// 
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```
Cependant, le cadre retourné par IShape.getRawFrame() peut être indéfini. Cela a du sens lorsqu'une forme est liée à un espace réservé. Alors les valeurs de cadre indéfinies de la forme sont remplacées par celles de la forme espace réservé parent. S'il n'existe aucun espace réservé parent pour cette forme, des valeurs par défaut sont utilisées lors de l'évaluation du cadre effectif à partir de son IShape.getRawFrame(). Les valeurs par défaut sont 0 et NullableBool.False pour x, y, width, height, flipH, flipV et rotationAngle. Par exemple:
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // La forme est liée à un espace réservé.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Maintenant la forme hérite des valeurs x, y, hauteur, flipH et flipV de l'espace réservé
    // et remplace la largeur = 100 et l'angle de rotation = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Propriétés modifiées**
#### **Modification du type et du nom de la méthode Aspose.Slides.IShapeCollection.getParent()**
Le type de la propriété Aspose.Slides.IShapeCollection.Parent a été modifié de ISlideComponent vers la nouvelle interface IGroupShape. L'interface IGroupShape est un descendant de ISlideComponent, de sorte que le code existant ne nécessite aucune adaptation.

Le nom de la méthode Aspose.Slides.IShapeCollection.getParent() a été changé de getParent à getParentGroup().
#### **Modification du type des méthodes Aspose.Slides.IShapeFrame.getFlipH() et .getFlipV()**
Le type de la méthode Aspose.Slides.IShapeFrame.getFlipH() a été changé de bool à NullableBool.

La méthode IShape.getFrame() renvoie l'instance effective de IShapeFrame (toutes ses propriétés ayant des valeurs effectives définies).

La méthode IShape.getRawFrame() renvoie une instance de IShapeFrame dont chaque propriété peut avoir une valeur indéfinie (notamment FlipH ou FlipV pouvant avoir la valeur NullableBool.NotDefined).