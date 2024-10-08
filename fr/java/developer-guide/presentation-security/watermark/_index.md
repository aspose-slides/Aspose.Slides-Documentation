---
title: Filigrane
type: docs
weight: 40
url: /java/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane texte
- filigrane image
- PowerPoint
- présentation
- Java
- Aspose.Slides pour Java
description: "Ajouter des filigranes texte et image aux présentations PowerPoint en Java"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un texte ou une image utilisé comme tampon sur une diapositive ou sur l'ensemble des diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'Entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations des droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/java/), il existe plusieurs façons de créer des filigranes dans les documents PowerPoint ou OpenOffice et de modifier leur design et leur comportement. L'aspect commun est que pour ajouter des filigranes texte, vous devez utiliser l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/), et pour ajouter des filigranes images, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l'interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), vous permettant d'utiliser tous les paramètres flexibles de l'objet forme. Comme `ITextFrame` n'est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/).

Il existe deux façons d'appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de présentation. Le Maître de Diapositive est utilisé pour appliquer un filigrane à toutes les diapositives de présentation : le filigrane est ajouté au Maître de Diapositive, entièrement conçu là, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme indisponible pour l'édition par d'autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parente du filigrane) d'être modifié, Aspose.Slides offre une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Maître de Diapositive. Lorsque la forme de filigrane est verrouillée sur le Maître de Diapositive, elle sera verrouillée sur toutes les diapositives de présentation.

Vous pouvez définir un nom pour le filigrane afin que, dans le futur, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il existe généralement des caractéristiques communes dans les filigranes, telles que l'alignement centré, la rotation, la position au premier plan, etc. Nous allons voir comment utiliser ces éléments dans les exemples ci-dessous.

## **Filigrane Texte**

### **Ajouter un Filigrane Texte à une Diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/). Ce type n'est pas hérité de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), qui possède un large éventail de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) comme montrée ci-dessous.

```java
String watermarkText = "CONFIDENTIEL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/java/text-formatting/)
{{% /alert %}}

### **Ajouter un Filigrane Texte à une Présentation**

Si vous souhaitez ajouter un filigrane texte à la présentation entière (c'est-à-dire à toutes les diapositives à la fois), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). Le reste de la logique est identique à celle d'ajout d'un filigrane à une seule diapositive : créez un objet [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) puis ajoutez-y le filigrane en utilisant la méthode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIEL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Maître de Diapositive](/slides/java/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme du Filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Définir la Police pour un Filigrane Texte**

Vous pouvez changer la police du filigrane texte comme montré ci-dessous.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Définir la Couleur du Texte du Filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Centrer un Filigrane Texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

L'image ci-dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane Image**

### **Ajouter un Filigrane Image à une Présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez faire ce qui suit :

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **Verrouiller un Filigrane contre l'Édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la méthode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le regroupement avec d'autres éléments, verrouiller son texte contre l'édition, et bien plus encore :

```java
// Verrouiller la forme du filigrane contre les modifications
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Pour cela, vous devez appeler cette méthode à partir de la liste des diapositives de présentation et passer la référence de la forme et son numéro d'ordre dans la méthode. De cette manière, il est possible de remonter une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu'il soit positionné en diagonale à travers la diapositive :

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, assignez-lui la méthode [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-) :

```java
watermarkShape.setName("filigrane");
```

## **Supprimer un Filigrane**

Pour supprimer la forme de filigrane, utilisez la méthode [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme du filigrane à la méthode [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("filigrane".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Un Exemple en Direct**

Vous voudrez peut-être vérifier les outils en ligne **Aspose.Slides gratuits** [Ajouter un Filigrane](https://products.aspose.app/slides/watermark) et [Retirer un Filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et retirer des filigranes](online_tools.png)