---
title: Format des formes PowerPoint sur Android
linktitle: Mise en forme des formes
type: docs
weight: 20
url: /fr/androidjava/shape-formatting/
keywords:
- format de forme
- format de ligne
- effet de croquis
- ligne de forme croquis
- format du style de jointure
- remplissage en dégradé
- remplissage en motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rendu noir et blanc de forme
- rendu en niveaux de gris de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialiser le formatage
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint sur Android avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et plein contrôle."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont constituées de lignes, vous pouvez les formater en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format de forme PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java fournit des interfaces et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

En utilisant Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. La procédure est décrite ci‑détect :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [style de ligne](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linestyle/) de la forme.
1. Définir la largeur de la ligne.
1. Définir le [style de tiret](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linedashstyle/) de la ligne.
1. Définir la couleur de la ligne pour la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Le code suivant montre comment formater un rectangle `AutoShape` :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Supprimer le remplissage de la forme rectangle afin que seules ses lignes soient visibles.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Appliquer le formatage aux lignes du rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Définir la couleur de la ligne du rectangle.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis donne à une ligne de forme un aspect dessiné à la main. Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/) pour accéder aux paramètres de ligne, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilineformat/) pour accéder aux paramètres de croquis, et [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linesketchtype/).

Le code Java suivant montre comment appliquer l’effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linesketchtype/) , lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/linesketchtype/) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Accéder au format de ligne de la forme et à son format de croquis.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Appliquer un effet de croquis.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Lire l'effet de croquis assigné directement à la forme.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Supprimer l'effet de croquis.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

La valeur retournée par [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isketchformat/) représente le paramètre assigné directement à la forme. Si le format de ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilineformat/), accédez à [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilineformateffectivedata/), et lisez [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isketchformateffectivedata/). La valeur effective reflète le format réellement appliqué après résolution de l’héritage :

```java
import com.aspose.slides.*;

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

* Round
* Miter
* Bevel

Par défaut, lorsque PowerPoint rejoint deux lignes à un angle (par exemple au coin d’une forme), il utilise le paramètre **Round**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code Java suivant montre comment trois rectangles (comme indiqué sur l’image ci‑dessus) ont été créés en utilisant les paramètres de type de jointure Miter, Bevel et Round :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter trois formes auto de type Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Définir la couleur de remplissage pour chaque forme rectangle.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Définir la largeur de la ligne.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Définir la couleur de la ligne de chaque rectangle.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Définir le style de jointure.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Ajouter du texte à chaque rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplissage en dégradé**

Dans PowerPoint, le remplissage en dégradé est une option de mise en forme qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de manière à ce que l’une se fonde progressivement dans l’autre.

Voici comment appliquer un remplissage en dégradé à une forme avec Aspose.Slides :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajouter vos deux couleurs préférées avec les positions définies en utilisant les méthodes `add` de la collection d’arrêts de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/igradientformat/).
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer un format de dégradé à l'ellipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Définir la direction du dégradé.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Ajouter deux arrêts de dégradé.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![L’ellipse avec remplissage en dégradé](gradient-fill.png)

## **Remplissage en motif**

Dans PowerPoint, le remplissage en motif est une option de mise en forme qui vous permet d’appliquer un dessin à deux couleurs — par exemple des points, des rayures, des hachures croisées ou des carreaux — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’attrait visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez spécifier les couleurs exactes à utiliser.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisir un style de motif parmi les options prédéfinies.
1. Définir la [Background Color](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/patternformat/#getBackColor--) du motif.
1. Définir la [Foreground Color](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Définir le style du motif.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Définir les couleurs d'arrière-plan et de premier plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Le rectangle avec remplissage en motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de mise en forme qui vous permet d’insérer une image à l’intérieur d’une forme — utilisant ainsi l’image comme arrière‑plan de la forme.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) de la forme sur `Picture`.
1. Définir le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créer un objet [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Passer l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

Supposons que nous ayons un fichier « lotus.png » avec l’image suivante :

![L’image lotus](lotus.png)

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Définir le type de remplissage sur Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Définir le mode de remplissage d'image.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Charger une image et l'ajouter aux ressources de la présentation.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Définir l'image.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forme avec remplissage d’image](picture-fill.png)

### **Mosaïque d’image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Définit le mode de remplissage d’image — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Définit le décalage horizontal de la tuile (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Définit le décalage vertical de la tuile (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Définit l’échelle verticale de la tuile en pourcentage.

Le code suivant montre comment ajouter une forme rectangulaire avec un remplissage d’image en mosaïque et configurer les options de tuile :

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Définir le type de remplissage de la forme sur Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Charger l'image et l'ajouter aux ressources de la présentation.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Affecter l'image à la forme.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurer le mode de remplissage d'image et les propriétés de carrelage.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Les options de tuile](tile-options.png)

## **Remplissage en couleur unie**

Dans PowerPoint, le remplissage en couleur unie est une option de mise en forme qui remplit une forme avec une couleur unique et uniforme. Cette couleur d’arrière‑plan simple est appliquée sans aucun dégradé, texture ou motif.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuer votre couleur de remplissage préférée à la forme.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Définir le type de remplissage sur Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Définir la couleur de remplissage.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forme avec remplissage en couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage en couleur unie, en dégradé, d’image ou de texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir le [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) sur `Solid`.
1. Utiliser `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrer la présentation.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto rectangle solide.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ajouter une forme auto rectangle transparente au-dessus de la forme solide.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter les formes dans les présentations PowerPoint. Cela peut être utile pour positionner des éléments visuels avec des exigences d’alignement ou de conception spécifiques.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Définir la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrer la présentation.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Faire pivoter la forme de 5 degrés.
    shape.setRotation(5);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/threedformat/).

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Configurer le [ThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrer la présentation.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Créer une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme à la diapositive.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Définir les propriétés ThreeDFormat de la forme.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Enregistrer la présentation en tant que fichier PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/threedformat/).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenir une référence à une diapositive par son index.
1. Ajouter un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Utiliser [setCameraType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icamera/#setCameraType-int-) et [setLightType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) pour définir la rotation 3D.
1. Enregistrer la présentation.

```java
import com.aspose.slides.*;

// Créer une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Enregistrer la présentation en tant que fichier PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc des formes**

La méthode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) spécifie comment une forme individuelle est rendue lorsqu’une présentation est visualisée ou traitée en mode noir et blanc. Elle n’active pas l’affichage en noir et blanc elle‑même, et ne modifie pas le remplissage, la ligne ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent une coloration grise, `BlackWhite` n’utilise que le noir et blanc, `Black` et `White` imposent une couleur unique, `Color` préserve la coloration normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Le code Java suivant crée une forme colorée et la fait apparaître grise en mode d’affichage noir et blanc :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Conserver le remplissage orange en mode couleur, mais rendre la forme avec une coloration grise en mode noir et blanc.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. Dans un flux de travail d’affichage noir et blanc, il utilise une coloration grise parce que son mode est réglé sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, l’aperçu ou d’autres flux qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Le code Java suivant montre comment réinitialiser le formatage d’une diapositive et restaurer la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/layoutslide/) à leurs paramètres par défaut :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Réinitialiser chaque forme sur la diapositive qui possède un espace réservé sur la mise en page.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Seulement légèrement. Les images et les médias intégrés occupent la majorité de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés comme métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent le même formatage afin de les regrouper ?**

Comparez les propriétés de formatage clés de chaque forme — remplissage, ligne et paramètres d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un diaporama modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et réappliquez leur formatage où cela est nécessaire.