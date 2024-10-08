---
title: Filigrane
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane texte
- filigrane image
- PowerPoint
- présentation
- PHP
- Java
- Aspose.Slides pour PHP via Java
description: "Ajoutez des filigranes de texte et d'image aux présentations PowerPoint en PHP"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un texte ou une image utilisée en tant que timbre sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'entreprise"), identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations des droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX, et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), il existe diverses façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L'aspect commun est que pour ajouter des filigranes de texte, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), et pour ajouter des filigranes d'image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), vous permettant d'utiliser tous les réglages flexibles de l'objet forme. Étant donné que `ITextFrame` n'est pas une forme et que ses réglages sont limités, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Il existe deux manières d'appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Master de Diapositive est utilisé pour appliquer un filigrane à toutes les diapositives de la présentation — le filigrane est ajouté au Master de Diapositive, entièrement conçu là-bas, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d'autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d'être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Master de Diapositive. Lorsque la forme de filigrane est verrouillée sur le Master de Diapositive, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez définir un nom pour le filigrane afin que dans le futur, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il existe généralement des caractéristiques communes dans les filigranes, telles que l'alignement central, la rotation, la position devant, etc. Nous allons considérer comment les utiliser dans les exemples ci-dessous.

## **Filigrane Texte**

### **Ajouter un Filigrane Texte à une Diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX, ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Ce type n'est pas hérité de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), qui dispose d'un large ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l'objet [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) comme indiqué ci-dessous.

```php
$watermarkText = "CONFIDENTIEL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/php-java/text-formatting/)
{{% /alert %}}

### **Ajouter un Filigrane Texte à une Présentation**

Si vous souhaitez ajouter un filigrane texte à l'ensemble de la présentation (c'est-à-dire, toutes les diapositives à la fois), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Le reste de la logique est le même que lorsque vous ajoutez un filigrane à une seule diapositive — créez un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) et ajoutez ensuite le filigrane en utilisant la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIEL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Master de Diapositive](/slides/php-java/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme de Filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Définir la Police pour un Filigrane Texte**

Vous pouvez changer la police du texte du filigrane comme indiqué ci-dessous.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Définir la Couleur du Texte de Filigrane**

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

### **Centrer un Filigrane Texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

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

L'image ci-dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane Image**

### **Ajouter un Filigrane Image à une Présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez faire ce qui suit :

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **Verrouiller un Filigrane pour Édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la méthode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, la mise en groupe avec d'autres éléments, verrouiller son texte contre la modification, et bien plus encore :

```php
// Verrouiller la forme de filigrane contre modification
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Pour ce faire, vous devez appeler cette méthode à partir de la liste des diapositives de la présentation et passer la référence de la forme ainsi que son numéro d'ordre dans la méthode. De cette manière, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code sur la façon d'ajuster la rotation du filigrane afin qu'il soit positionné en diagonale sur la diapositive :

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder dans le futur pour la modifier ou la supprimer. Pour définir le nom de la forme de filigrane, assignez-le à la méthode [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) :

```php
$watermarkShape->setName("filigrane");
```

## **Supprimer un Filigrane**

Pour supprimer la forme de filigrane, utilisez la méthode [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme de filigrane à la méthode [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove) :

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "filigrane") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Un Exemple en Direct**

Vous pouvez vouloir consulter les outils en ligne **Aspose.Slides gratuits** [Ajouter Filigrane](https://products.aspose.app/slides/watermark) et [Supprimer Filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)