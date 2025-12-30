---
title: Ajouter des filigranes aux présentations en PHP
linktitle: Filigrane
type: docs
weight: 40
url: /fr/php-java/watermark/
keywords:
- filigrane
- filigrane texte
- filigrane image
- ajouter un filigrane
- modifier le filigrane
- supprimer le filigrane
- effacer le filigrane
- ajouter un filigrane à PPT
- ajouter un filigrane à PPTX
- ajouter un filigrane à ODP
- supprimer le filigrane de PPT
- supprimer le filigrane de PPTX
- supprimer le filigrane de ODP
- effacer le filigrane de PPT
- effacer le filigrane de PPTX
- effacer le filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en PHP pour indiquer un brouillon, des informations confidentielles, des droits d'auteur, etc."
---

## **À propos des filigranes**

**Un filigrane** dans une présentation est un texte ou une image tampon utilisée sur une diapositive ou sur l’ensemble des diapositives d’une présentation. En général, un filigrane indique que la présentation est un brouillon (par ex. un filigrane « Brouillon »), qu’elle contient des informations confidentielles (par ex. un filigrane « Confidentiel »), à quelle entreprise elle appartient (par ex. un filigrane « Nom de l’entreprise »), qui en est l’auteur, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichier PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), il existe différentes manières de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), ce qui vous permet d’utiliser toutes les options flexibles de l’objet forme. Comme `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est enveloppé dans un objet [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le **Slide Master** est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Slide Master, entièrement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la possibilité de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être édité, Aspose.Slides fournit la fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle le sera sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin, à l’avenir, de le supprimer en le retrouvant parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane comme vous le souhaitez ; toutefois, les filigranes possèdent généralement des caractéristiques communes, telles que l’alignement centré, la rotation, la position en avant‑plan, etc. Nous verrons comment les exploiter dans les exemples ci‑dessous.

## **Filigrane de texte**

### **Ajouter un filigrane de texte à une diapositive**

Pour ajouter un filigrane de texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre texte à cette forme. Le cadre texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Ce type n’est pas hérité de la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), qui offre un large ensemble de propriétés permettant de positionner le filigrane de manière flexible. Ainsi, l’objet [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) comme indiqué ci‑dessous.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/php-java/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane de texte à une présentation**

Si vous souhaitez ajouter un filigrane de texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Le reste de la logique est identique à celle de l’ajout d’un filigrane à une seule diapositive — créez un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) puis ajoutez le filigrane avec la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/fr/php-java/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire possède des couleurs de remplissage et de contour. Les lignes de code suivantes rendent la forme transparente.
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **Définir la police d’un filigrane de texte**

Vous pouvez modifier la police du texte du filigrane comme indiqué ci‑dessous.
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :
```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```


### **Centrer un filigrane de texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela vous pouvez procéder ainsi :
```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```


L’image ci‑dessous montre le résultat final.

![The text watermark](text_watermark.png)

## **Filigrane d’image**

### **Ajouter un filigrane d’image à une présentation**

Pour ajouter un filigrane d’image à une diapositive de présentation, vous pouvez procéder comme suit :
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **Verrouiller un filigrane contre la modification**

Si vous devez empêcher la modification d’un filigrane, utilisez la méthode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le déplacement, le groupement avec d’autres éléments, le verrouillage du texte contre la modification, et bien plus encore :
```php
// Verrouiller la forme du filigrane contre la modification
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **Amener un filigrane en avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation en passant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme en avant‑plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant le contenu de la présentation :
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la méthode [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) :
```php
$watermarkShape->setName("watermark");
```


### **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) afin de la retrouver parmi les formes de la diapositive. Ensuite, transmettez la forme du filigrane à la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) :
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est une superposition de texte ou d’image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter programmatiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)) de la forme. Cela garantit que le filigrane reste discret et ne distraie pas le contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

**Puis‑je personnaliser la police et le style d’un filigrane de texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style pour correspondre à la conception de votre présentation et maintenir la cohérence de votre marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane programmatiquement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.