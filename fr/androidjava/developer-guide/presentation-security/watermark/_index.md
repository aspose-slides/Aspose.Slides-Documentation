---
title: Filigrane
type: docs
weight: 40
url: /androidjava/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane texte
- filigrane image
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides pour Android via Java
description: "Ajoutez des filigranes texte et image aux présentations PowerPoint en Java"
---

## **À propos des filigranes**

**Un filigrane** dans une présentation est un tampon de texte ou d'image utilisé sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/android-java/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L'aspect commun est que pour ajouter des filigranes texte, vous devez utiliser l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l'interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), vous permettant d'utiliser tous les paramètres flexibles de l'objet de forme. Puisque `ITextFrame` n'est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

Il y a deux façons dont un filigrane peut être appliqué : à une seule diapositive ou à toutes les diapositives de la présentation. Le maître de diapositive est utilisé pour appliquer un filigrane à toutes les diapositives de la présentation — le filigrane est ajouté au maître de diapositive, entièrement conçu là-bas, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d'autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d'être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un maître de diapositive. Lorsque la forme de filigrane est verrouillée sur le maître de diapositive, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez définir un nom pour le filigrane afin que, dans le futur, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il existe généralement des caractéristiques communes dans les filigranes, telles que l'alignement central, la rotation, la position avant, etc. Nous allons voir comment utiliser ces caractéristiques dans les exemples ci-dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/). Ce type n'est pas hérité de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), qui a un large éventail de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) comme montré ci-dessous.

```java
String watermarkText = "CONFIDENTIEL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/androidjava/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l'ensemble de la présentation (c'est-à-dire à toutes les diapositives à la fois), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/). Le reste de la logique est le même que lorsque vous ajoutez un filigrane à une seule diapositive : créez un objet [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) puis ajoutez le filigrane en utilisant la méthode [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIEL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Maître de Diapositive](/slides/androidjava/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire est stylisée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Définir la police pour un filigrane texte**

Vous pouvez changer la police du filigrane texte comme montré ci-dessous.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

```java
SizeF slideSize = presentation.getSlideSize().getSize();

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

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez faire ce qui suit :

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **Verrouiller un filigrane contre l'édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la méthode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d'autres éléments, verrouiller son texte contre l'édition, et bien plus encore :

```java
// Verrouiller la forme de filigrane contre la modification
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Amener un filigrane au premier plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Pour ce faire, vous devez appeler cette méthode à partir de la liste des diapositives de présentation et passer la référence de la forme et son numéro d'ordre à la méthode. De cette manière, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Définir la rotation du filigrane**

Voici un exemple de code sur la façon d'ajuster la rotation du filigrane afin qu'il soit positionné diagonale à travers la diapositive :

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Définir un nom pour un filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder à l'avenir pour le modifier ou le supprimer. Pour définir le nom de la forme de filigrane, affectez-le à la méthode [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) :

```java
watermarkShape.setName("filigrane");
```

## **Supprimer un filigrane**

Pour supprimer la forme de filigrane, utilisez la méthode [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme de filigrane à la méthode [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("filigrane".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Un exemple en direct**

Vous pouvez consulter les outils en ligne **Aspose.Slides gratuits** [Ajouter un filigrane](https://products.aspose.app/slides/watermark) et [Supprimer un filigrane](https://products.aspose.app/slides/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)