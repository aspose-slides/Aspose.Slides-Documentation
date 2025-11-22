---
title: Filigrane
type: docs
weight: 40
url: /fr/nodejs-java/watermark/
keywords: "filigrane dans une présentation"
description: "Utilisez le filigrane dans PowerPoint avec Aspose.Slides. Ajoutez un filigrane dans une présentation ppt ou supprimez le filigrane. Insérez un filigrane image ou un filigrane texte."
---

## **À propos du filigrane**

**Un filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur l’ensemble des diapositives d’une présentation. En général, un filigrane sert à indiquer que la présentation est un brouillon (p. ex., un filigrane « Brouillon »), qu’elle contient des informations confidentielles (p. ex., un filigrane « Confidentiel »), à préciser à quelle société elle appartient (p. ex., un filigrane « Nom de l’entreprise »), à identifier l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichier PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. Le point commun est que, pour ajouter des filigranes texte, vous devez utiliser le type [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente le type [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), vous permettant d’utiliser tous les paramètres flexibles de l’objet forme. Puisque `TextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Il existe deux manières d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le masque de diapositive (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives : le filigrane est ajouté au Slide Master, entièrement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parente du filigrane) d’être édité, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle le sera sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin que, plus tard, si vous souhaitez le supprimer, vous puissiez le retrouver parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n’importe quelle façon ; toutefois, il existe généralement des caractéristiques communes, telles que l’alignement centré, la rotation, la position en avant‑plan, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**
Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre texte à cette forme. Le cadre texte est représenté par le type [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Ce type n’est pas hérité de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), qui possède un large ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) en passant le texte du filigrane :
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser ](/slides/fr/nodejs-java/slide-master/)[TextFrame](/slides/fr/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **Ajouter un filigrane texte à la présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). Le reste de la logique est identique à celle de l’ajout d’un filigrane à une diapositive unique : créez un objet [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) puis ajoutez le filigrane en utilisant la méthode [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) :
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser ](/slides/fr/nodejs-java/slide-master/)[Slide Master](/slides/fr/nodejs-java/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de bordure. Les lignes de code suivantes rendent la forme transparente.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du texte du filigrane comme indiqué ci‑dessous.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Centrer le filigrane texte**
Il est possible de centrer le filigrane sur une diapositive en procédant comme suit :
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


L’image ci‑dessous montre le résultat final.

![The text watermark](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à toutes les diapositives de la présentation, vous pouvez procéder comme suit :
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Verrouiller un filigrane contre la modification**

S’il est nécessaire d’empêcher la modification d’un filigrane, utilisez la méthode [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) sur la forme. Grâce à cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, le verrouillage du texte contre la modification, et bien plus encore :
```javascript
// Verrouiller la forme du filigrane contre la modification
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment verrouiller les formes contre la modification](/slides/fr/nodejs-java/presentation-locking/)
{{% /alert %}}

### **Amener un filigrane au premier plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation en transmettant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme au premier plan ou à l’arrière‑plan de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer le filigrane devant le contenu de la présentation :
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la méthode [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) :
```javascript
watermarkShape.setName("watermark");
```


### **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) afin de la trouver parmi les formes de la diapositive. Ensuite, transmettez la forme du filigrane à la méthode [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) :
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi devrais‑je l’utiliser ?**

Un filigrane est une superposition texte ou image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, renforcer la reconnaissance de la marque ou empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les [paramètres de remplissage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) de la forme. Cela garantit que le filigrane reste discret et n’interfère pas avec le contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, et bien d’autres.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin d’harmoniser le filigrane avec le design de votre présentation et de maintenir la cohérence de la marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.