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
- ajouter filigrane
- modifier filigrane
- supprimer filigrane
- effacer filigrane
- ajouter filigrane à PPT
- ajouter filigrane à PPTX
- ajouter filigrane à ODP
- supprimer filigrane de PPT
- supprimer filigrane de PPTX
- supprimer filigrane de ODP
- effacer filigrane de PPT
- effacer filigrane de PPTX
- effacer filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en Java pour indiquer un brouillon, des informations confidentielles, des droits d’auteur, etc."
---
## **Introduction**

**Un filigrane** dans une présentation est un texte ou une image tampon utilisée sur une diapositive ou sur l’ensemble des diapositives. En général, un filigrane indique que la présentation est un brouillon (par ex. un filigrane « Brouillon »), qu’elle contient des informations confidentielles (par ex. un filigrane « Confidentiel »), à quelle société elle appartient (par ex. un filigrane « Nom de l’entreprise »), identifie l’auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés tant dans les formats PowerPoint que OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/fr/java/), plusieurs méthodes permettent de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) , ce qui vous permet d’utiliser tous les paramètres flexibles de l’objet forme. Comme `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/).

Il existe deux façons d’appliquer un filigrane : à une seule diapositive ou à toutes les diapositives de la présentation. Le masque de diapositive (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Slide Master, entièrement conçu là‑bas, puis appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme du filigrane est verrouillée sur le Slide Master, elle le restera sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin, ultérieurement, de pouvoir le supprimer en le recherchant parmi les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de la manière souhaitée ; toutefois, les filigranes possèdent généralement des caractéristiques communes, telles que l’alignement centré, la rotation, la position en avant‑plan, etc. Nous verrons comment les exploiter dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/), qui offre un large éventail de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l’objet [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [addTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) comme indiqué ci‑dessous.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/fr/java/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives d’un coup), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterslide/). Le reste de la logique est identique à celui d’ajout d’un filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) puis ajoutez le filigrane en utilisant la méthode [addTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/fr/java/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangle possède des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Définir la police d’un filigrane texte**

Vous pouvez modifier la police du texte du filigrane comme indiqué ci‑dessous.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Définir la couleur du texte du filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centrer un filigrane texte**

Il est possible de centrer le filigrane sur une diapositive ; pour cela, procédez comme suit :

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

L’image ci‑dessous montre le résultat final.

![The text watermark](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez procéder ainsi :

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Verrouiller un filigrane contre la modification**

S’il faut empêcher la modification d’un filigrane, utilisez la méthode [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, le verrouillage de son texte, etc. :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Verrouiller la forme du filigrane contre les modifications
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Mettre un filigrane au premier plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection.reorder](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Pour ce faire, appelez cette méthode depuis la liste des diapositives de la présentation en transmettant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme au premier plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer le filigrane devant le contenu de la présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Définir la rotation du filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu’il soit positionné en diagonale sur la diapositive :

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour définir le nom de la forme du filigrane, affectez‑le à la méthode [IAutoShape.setName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setName-java.lang.String-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la méthode [IAutoShape.getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getName--) afin de la trouver parmi les formes de la diapositive. Ensuite, transmettez la forme du filigrane à la méthode [IShapeCollection.remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?

Un filigrane est une superposition de texte ou d’image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

### Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?

Oui, Aspose.Slides vous permet d’ajouter programmétiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

### Comment ajuster la transparence du filigrane ?

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([getFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getFillFormat--)) de la forme. Cela garantit que le filigrane reste discret et ne distrait pas du contenu de la diapositive.

### Quels formats d’image sont pris en charge pour les filigranes ?

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

### Puis‑je personnaliser la police et le style d’un filigrane texte ?

Oui, vous pouvez choisir n’importe quelle police, taille et style afin de correspondre à la conception de votre présentation et de maintenir la cohérence de la marque.

### Comment modifier la position ou l’orientation d’un filigrane ?

Vous pouvez ajuster la position et l’orientation du filigrane programmétiquement en modifiant les coordonnées, la taille et les propriétés de rotation de la forme.