---
title: Ajouter des filigranes aux présentations en Java
linktitle: Filigrane
type: docs
weight: 40
url: /fr/java/watermark/
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
- Java
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en Java pour indiquer un brouillon, des informations confidentielles, des droits d’auteur et plus encore."
---

## **À propos des filigranes**

**Un filigrane** dans une présentation est un texte ou une image apposés sur une diapositive ou sur toutes les diapositives d’une présentation. En général, un filigrane sert à indiquer que la présentation est un brouillon (par exemple, un filigrane « Brouillon »), qu’elle contient des informations confidentielles (par exemple, un filigrane « Confidentiel »), à préciser à quelle société elle appartient (par exemple, un filigrane « Nom de l’entreprise »), à identifier l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/java/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), ce qui vous permet d’utiliser toutes les options flexibles de l’objet forme. Étant donné que `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le Masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Masque des diapositives, pleinement conçu là‑bas, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être édité, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Masque des diapositives. Lorsque la forme du filigrane est verrouillée sur le Masque des diapositives, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez définir un nom pour le filigrane afin que, plus tard, si vous souhaitez le supprimer, vous puissiez le retrouver parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane comme vous le souhaitez ; toutefois, il existe généralement des caractéristiques communes aux filigranes, telles que l’alignement centré, la rotation, la position en avant‑plan, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), qui possède un large ensemble de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) comme indiqué ci‑dessous.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/java/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’un filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) puis ajoutez le filigrane à l’aide de la méthode [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Masque des diapositives](/slides/fr/java/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangle est stylisée avec des couleurs de remplissage et de bordure. Les lignes de code suivantes rendent la forme transparente.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du filigrane texte comme indiqué ci‑dessous.
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
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive ; pour cela, vous pouvez procéder comme suit :
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


L’image ci‑dessous montre le résultat final.

![The text watermark](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez procéder comme suit :
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **Verrouiller un filigrane contre l’édition**

S’il est nécessaire d’empêcher la modification d’un filigrane, utilisez la méthode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, verrouiller son texte contre l’édition, etc. :
```java
// Verrouiller la forme du filigrane contre les modifications
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **Faire passer un filigrane en avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation en passant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme en avant‑plan ou en arrière‑plan de la diapositive. Cette fonction est particulièrement utile si vous devez placer un filigrane devant le contenu de la présentation :
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la méthode [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-) :
```java
watermarkShape.setName("watermark");
```


### **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) afin de la trouver parmi les formes de la diapositive. Puis, passez la forme du filigrane à la méthode [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :
```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?**

Un filigrane est un texte ou une image superposés aux diapositives qui aident à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

**Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?**

Oui, Aspose.Slides vous permet d’ajouter programmatiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

**Comment ajuster la transparence du filigrane ?**

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getFillFormat--)) de la forme. Ainsi le filigrane reste discret et ne distrait pas du contenu de la diapositive.

**Quels formats d’image sont pris en charge pour les filigranes ?**

Aspose.Slides prend en charge plusieurs formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

**Puis‑je personnaliser la police et le style d’un filigrane texte ?**

Oui, vous pouvez choisir n’importe quelle police, taille et style afin de les adapter au design de votre présentation et de conserver la cohérence de la marque.

**Comment modifier la position ou l’orientation d’un filigrane ?**

Vous pouvez ajuster la position et l’orientation du filigrane progammaticalement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.