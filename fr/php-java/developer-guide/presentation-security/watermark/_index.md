---
title: Filigrane
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane textuel
- filigrane image
- PowerPoint
- présentation
- PHP
- Java
- Aspose.Slides pour PHP via Java
description: "Ajoutez des filigranes textuels et d'image aux présentations PowerPoint en PHP"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un tampon de texte ou d'image utilisé sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'Entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/), il existe différentes façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L'aspect commun est que pour ajouter des filigranes textuels, vous devez utiliser la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), et pour ajouter des filigranes d'image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), ce qui vous permet d'utiliser tous les paramètres flexibles de l'objet forme. Puisque `ITextFrame` n'est pas une forme et que ses options sont limitées, il est encapsulé dans un objet [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Il existe deux façons d'appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Slide Master est utilisé pour appliquer un filigrane à toutes les diapositives de la présentation — le filigrane est ajouté au Slide Master, entièrement conçu là, et appliqué à toutes les diapositives sans affecter le droit de modifier le filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non disponible pour modification par d'autres utilisateurs. Pour empêcher que le filigrane (ou plutôt la forme parent du filigrane) ne soit modifié, Aspose.Slides fournit une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme de filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez donner un nom au filigrane afin qu'à l'avenir, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il y a généralement des caractéristiques communes dans les filigranes, telles que l'alignement au centre, la rotation, la position avant, etc. Nous allons considérer comment utiliser ces éléments dans les exemples ci-dessous.

## **Filigrane Textuel**

### **Ajouter un Filigrane Textuel à une Diapositive**

Pour ajouter un filigrane textuel dans PPT, PPTX ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Ce type n'est pas hérité de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), qui a un large éventail de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) est encapsulé dans un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) comme indiqué ci-dessous.

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

### **Ajouter un Filigrane Textuel à une Présentation**

Si vous souhaitez ajouter un filigrane textuel à l'ensemble de la présentation (c'est-à-dire à toutes les diapositives en même temps), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Le reste de la logique est le même que lors de l'ajout d'un filigrane à une seule diapositive : créez un objet [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) et ajoutez ensuite le filigrane à celui-ci en utilisant la méthode [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIEL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/php-java/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme de Filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Les lignes suivantes de code rendent la forme transparente.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Définir la Police pour un Filigrane Textuel**

Vous pouvez changer la police du filigrane textuel comme indiqué ci-dessous.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Définir la Couleur du Texte du Filigrane**

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

### **Centrer un Filigrane Textuel**

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

![Le filigrane textuel](text_watermark.png)

## **Filigrane d'Image**

### **Ajouter un Filigrane d'Image à une Présentation**

Pour ajouter un filigrane d'image à une diapositive de présentation, vous pouvez faire ce qui suit :

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **Verrouiller un Filigrane contre l'Édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la méthode [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le regroupement avec d'autres éléments, verrouiller son texte contre l'édition, et bien plus :

```php
// Verrouiller la forme de filigrane contre la modification
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Pour ce faire, vous devez appeler cette méthode à partir de la liste des diapositives de la présentation et passer la référence de la forme ainsi que son numéro d'ordre dans la méthode. De cette façon, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code sur la façon d'ajuster la rotation du filigrane afin qu'il soit positionné en diagonale à travers la diapositive :

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder à l'avenir pour la modifier ou la supprimer. Pour définir le nom de la forme de filigrane, assignez-le à la méthode [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName) :

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

Vous voudrez peut-être consulter les outils en ligne **Aspose.Slides gratuits** [Ajouter Filigrane](https://products.aspose.app/slides/watermark) et [Supprimer Filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)