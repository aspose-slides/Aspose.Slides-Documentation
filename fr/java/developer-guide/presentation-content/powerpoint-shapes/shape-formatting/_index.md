---
title: Formater les formes PowerPoint en Java
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/java/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme esquissée
- format du style de jointure
- remplissage en dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rendu forme noir et blanc
- rendu forme en niveaux de gris
- rotation de forme
- effet biseau 3D
- effet rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à mettre en forme les formes PowerPoint en Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et un contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont constituées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java fournit des interfaces et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [style de ligne](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [style de tiret](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de la ligne pour la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code suivant montre comment formater un rectangle `AutoShape` :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Définissez la couleur de remplissage pour la forme rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Appliquez le formatage aux lignes du rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Définissez la couleur de la ligne du rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The formatted lines in the presentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à la ligne d’une forme un aspect dessiné à la main. Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) pour accéder aux paramètres de la ligne, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformat/) pour accéder aux paramètres du croquis, et [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/).

Le code Java suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/), lire la valeur explicitement assignée et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Accédez au format de ligne de la forme et à son format de croquis.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Appliquez un effet de croquis.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lisez l'effet de croquis assigné directement à la forme.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Supprimez l'effet de croquis.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

La valeur renvoyée par [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformat/) représente le paramètre assigné directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformat/), accédez à [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformateffectivedata/), et lisez [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformateffectivedata/). La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formater les styles de jointure**

Voici les trois options de type de jointure :

* Arrondi
* Miter
* Biseau

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (par exemple au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles aigus, vous pouvez préférer l’option **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Le code Java suivant montre comment trois rectangles (illustrés dans l’image ci‑dessus) ont été créés en utilisant les paramètres de type de jointure Miter, Biseau et Arrondi :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez trois formes automatiques de type Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Définissez la couleur de remplissage pour chaque forme rectangle.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Définissez la largeur de la ligne.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Définissez la couleur de la ligne de chaque rectangle.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Définissez le style de jointure.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Ajoutez du texte à chaque rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un fondu continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou davantage de manière à ce que l’une se fond progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection de points d’arrêt du dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igradientformat/).
1. Enregistrer la présentation modifiée au format PPTX.

Le code Java suivant montre comment appliquer un effet de remplissage en dégradé à une ellipse :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquez le format de dégradé à l'ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Définissez la direction du dégradé.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Ajoutez deux points d'arrêt du dégradé.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The ellipse with gradient fill](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore — points, rayures, hachures ou carreaux — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [couleur d’arrière‑plan](https://reference.aspose.com/slides/fr/java/com.aspose.slides/patternformat/#getBackColor--) du motif.
1. Définir la [couleur de premier plan](https://reference.aspose.com/slides/fr/java/com.aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Java suivant montre comment appliquer un remplissage de motif à un rectangle :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définissez le type de remplissage sur Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Définissez le style de motif.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Définissez les couleurs d'arrière-plan et de premier plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The rectangle with pattern fill](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — en utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou tout autre mode préféré).
1. Créer un objet [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) à partir de l’image à utiliser.
1. Passer l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrer la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier « lotus.png » contenant l’image suivante :

![The lotus picture](lotus.png)

Le code Java suivant montre comment remplir une forme avec l’image :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Définissez le type de remplissage sur Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Définissez le mode de remplissage d'image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Chargez une image et ajoutez-la aux ressources de la présentation.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Définissez l'image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape with picture fill](picture-fill.png)

### **Tuiler l’image comme texture**

Si vous voulez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Définit le mode de remplissage d’image — soit `Tile`, soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Définit le décalage horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Définit le décalage vertical de la tuile (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Définit l’échelle verticale de la tuile en pourcentage.

Le fragment de code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de tuile :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définissez le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Chargez l'image et ajoutez-la aux ressources de la présentation.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Attribuez l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurez le mode de remplissage d'image et les propriétés de tuilage.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The tile options](tile-options.png)

## **Remplissage de couleur unie**

Dans PowerPoint, le remplissage de couleur unie est une option de mise en forme qui remplit une forme d’une seule couleur uniforme. Cet arrière‑plan uni est appliqué sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage de couleur unie à une forme avec Aspose.Slides, procédez comme suit :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuer la couleur de remplissage souhaitée à la forme.
1. Enregistrer la présentation modifiée au format PPTX.

Le code Java suivant montre comment appliquer un remplissage de couleur unie à un rectangle dans une diapositive PowerPoint :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définissez le type de remplissage sur Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Définissez la couleur de remplissage.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape with solid color fill](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez une couleur unie, un dégradé, une image ou un remplissage de texture à des formes, vous pouvez également définir un niveau de transparence afin de contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus transparente, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

Le code Java suivant montre comment appliquer une couleur de remplissage transparente à un rectangle :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique rectangle solide.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajoutez une forme automatique rectangle transparente au-dessus de la forme solide.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The transparent shape](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez ces étapes :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

Le code Java suivant montre comment faire pivoter une forme de 5 degrés :

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Faites pivoter la forme de 5 degrés.
    shape.setRotation(5);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The shape rotation](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez ces étapes :

1. Instancier la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrer la présentation.

Le code Java suivant montre comment appliquer des effets de biseau 3D à une forme :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme à la diapositive.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Définissez les propriétés ThreeDFormat de la forme.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Enregistrez la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The 3D bevel effect](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créer une instance de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son indice.
1. Ajouter une [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Utiliser [setCameraType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icamera/#setCameraType-int-) et [setLightType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilightrig/#setLightType-int-) pour définir la rotation 3D.
1. Enregistrer la présentation.

Le code Java suivant montre comment appliquer des effets de rotation 3D à une forme :

```java
import com.aspose.slides.*;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Enregistrez la présentation au format PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![The 3D rotation effect](3D-rotation-effect.png)

## **Contrôler le rendu en noir et blanc des formes**

La méthode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) spécifie comment une forme individuelle est rendue lorsqu’une présentation est visualisée ou traitée en mode noir et blanc. Elle ne déclenche pas l’affichage en noir et blanc et ne modifie pas le remplissage, la ligne ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/blackwhitemode/) pour choisir le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent le gris, `BlackWhite` n’utilise que le noir et le blanc, `Black` et `White` imposent une couleur unique, `Color` préserve les couleurs normales, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est attribué.

Le code Java suivant crée une forme colorée et la fait apparaître en gris en mode d’affichage noir et blanc :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Conservez le remplissage orange en mode couleur, mais affichez la forme en gris en mode noir et blanc.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. En mode d’affichage noir et blanc, il utilise le gris parce que son mode est défini sur `Gray`. Cela vous permet de préserver une diapositive en couleur complète tout en définissant un aspect distinct pour l’impression, l’aperçu ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Le code Java suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslide/) à leurs paramètres par défaut :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Réinitialisez chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement de façon minimale. Les images et les médias incorporés occupent la majorité de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes d’une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est requis.