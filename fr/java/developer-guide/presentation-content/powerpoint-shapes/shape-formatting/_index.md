---
title: Formater les formes PowerPoint en Java
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/java/shape-formatting/
keywords:
- mise en forme de forme
- mise en forme de ligne
- effet de croquis
- ligne de forme en croquis
- mise en forme du style de jointure
- remplissage en dégradé
- remplissage à motif
- remplissage image
- remplissage texture
- remplissage couleur unie
- transparence de forme
- rendu forme noir et blanc
- rendu forme en niveaux de gris
- rotation de forme
- effet chanfrein 3D
- effet rotation 3D
- réinitialiser la mise en forme
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment formater les formes PowerPoint en Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et contrôle total."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez mettre en forme les formes en spécifiant les paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-forme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pour Java fournit des interfaces et des méthodes qui vous permettent de mettre en forme les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Format des lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [style de ligne](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [style de tirets](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

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

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à une ligne de forme un aspect dessiné à la main. Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pour accéder aux paramètres de ligne, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) pour accéder aux paramètres de croquis, et [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Le code Java suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) :

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

La valeur renvoyée par [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) représente le paramètre attribué directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maître ou d’une diapositive de mise en page, utilisez [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), accédez à [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), et lisez [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

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

## **Format des styles de jointure**

Voici les trois options de type de jointure :

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes sous un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code Java suivant démontre comment trois rectangles (comme illustré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

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

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une s’estompe progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies à l’aide des méthodes `add` de la collection de points d’arrêt du dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique de type Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquez le formatage en dégradé à l'ellipse.
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

![L’ellipse avec remplissage dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choose a Gradient Rendering Style](/slides/fr/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage en dégradé stocké dans la présentation.

## **Remplissage avec motif**

Dans PowerPoint, le remplissage avec motif est une option de mise en forme qui vous permet d’appliquer un motif bicolore — tel que des points, des rayures, des hachures ou des damiers — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage avec motif à une forme à l’aide d’Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

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

    // Définissez le style du motif.
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

![Le rectangle avec remplissage à motif](pattern-fill.png)

## **Remplissage image**

Dans PowerPoint, le remplissage image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — utilisant ainsi l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage image sur `Tile` (ou un autre mode de votre choix).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Transmettez l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier "lotus.png" avec l’image suivante :

![L’image du lotus](lotus.png)

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

    // Définissez le mode de remplissage image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Chargez une image et ajoutez‑la aux ressources de la présentation.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Définissez l’image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Enregistrez le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La forme avec remplissage image](picture-fill.png)

### **Texte en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement de la mosaïque, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Définit le mode de remplissage image — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Contrôle si la tuile est retournée horizontalement, verticalement ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Définit le décalage horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Définit le décalage vertical de la tuile (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Définit l’échelle verticale de la tuile en pourcentage.

```java
import com.aspose.slides.*;

// Instanciez la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenez la première diapositive.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Ajoutez une forme automatique rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définissez le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Chargez l'image et ajoutez‑la aux ressources de la présentation.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Attribuez l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurez le mode de remplissage image et les propriétés de mosaïquage.
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

![Les options de mosaïque](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de mise en forme qui remplit une forme avec une seule couleur uniforme. Cette couleur d’arrière‑plan simple est appliquée sans dégradés, textures ou motifs.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez la couleur de remplissage de votre choix à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

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

![La forme avec remplissage couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

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

![La forme transparente](shape-transparency.png)

## **Pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour pivoter une forme sur une diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrez la présentation.

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

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de chanfrein 3D**

Aspose.Slides vous permet d’appliquer des effets de chanfrein 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Pour ajouter des effets de chanfrein 3D à une forme, suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) de la forme pour définir les paramètres de chanfrein.
1. Enregistrez la présentation.

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

![L’effet de chanfrein 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Utilisez [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) et [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) pour définir la rotation 3D.
1. Enregistrez la présentation.

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

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc elle‑même et ne modifie pas le remplissage, le contour ou d’autres formats de la forme en mode couleur normal.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent le gris, `BlackWhite` n’utilise que le noir et blanc, `Black` et `White` forcent une couleur unique, `Color` préserve les couleurs normales, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` indique qu’aucun mode de forme n’est assigné.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Conservez le remplissage orange en mode couleur, mais affichez la forme avec une coloration grise en mode noir et blanc.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. En flux de travail d’affichage noir et blanc, il utilise le gris parce que son mode est défini sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant un aspect distinct pour l’impression, l’aperçu ou d’autres flux qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser la mise en forme**

Le code Java suivant montre comment réinitialiser la mise en forme d’une diapositive et remettre à leurs valeurs par défaut la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) :

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

Seulement de façon minimale. Les images et médias intégrés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent un même formatage afin de les regrouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, contour et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, traitez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est nécessaire.