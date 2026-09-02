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
- ligne de forme en croquis
- format du style de jointure
- remplissage dégradé
- remplissage de motif
- remplissage d'image
- remplissage de texture
- remplissage couleur unie
- transparence de forme
- rotation de forme
- effet de biseau 3D
- effet de rotation 3D
- réinitialisation du formatage
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à formater les formes PowerPoint en Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT, PPTX et ODP avec précision et un contrôle complet."
---
## **Introduction**

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Comme les formes sont composées de lignes, vous pouvez les mettre en forme en modifiant ou en appliquant des effets à leurs contours. De plus, vous pouvez formater les formes en spécifiant des paramètres qui contrôlent la façon dont leurs intérieurs sont remplis.

![format-forme-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java fournit des interfaces et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

Avec Aspose.Slides, vous pouvez spécifier un style de ligne personnalisé pour une forme. Les étapes suivantes décrivent la procédure :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [line style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linestyle/) de la forme.
1. Définissez la largeur de la ligne.
1. Définissez le [dash style](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linedashstyle/) de la ligne.
1. Définissez la couleur de la ligne pour la forme.
1. Enregistrez la présentation modifiée au format PPTX.

Le code suivant montre comment formater un `AutoShape` rectangle :

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Définir la couleur de remplissage pour la forme rectangle.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Appliquer le formatage aux lignes du rectangle.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Définir la couleur pour la ligne du rectangle.
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

Un effet de croquis rend la ligne d’une forme semblable à un dessin à la main. Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) pour accéder aux paramètres de la ligne, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformat/) pour accéder aux paramètres de croquis, et [ISketchFormat.setSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformat/) pour sélectionner une valeur dans l’énumération [LineSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/).

Le code Java suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/), lire la valeur explicitement assignée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/fr/java/com.aspose.slides/linesketchtype/) :

```java
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

La valeur renvoyée par [ISketchFormat.getSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformat/) représente le paramètre assigné directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformat/), accédez à [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilineformateffectivedata/), et lisez [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isketchformateffectivedata/). La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage :

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

Par défaut, lorsque PowerPoint joint deux lignes à un angle (comme au coin d’une forme), il utilise le paramètre **Arrondi**. Cependant, si vous dessinez une forme avec des angles vifs, vous pouvez préférer l’option **Miter**.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Le code Java suivant montre comment trois rectangles (comme montré sur l’image ci‑dessus) ont été créés en utilisant les paramètres de jointure Miter, Bevel et Round :

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter trois formes automatiques de type Rectangle.
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

    // Définir la couleur pour la ligne de chaque rectangle.
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

## **Remplissage dégradé**

Dans PowerPoint, le remplissage dégradé est une option de formatage qui vous permet d’appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus de façon à ce que l’une passe progressivement à l’autre.

Voici comment appliquer un remplissage dégradé à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Gradient`.
1. Ajoutez vos deux couleurs préférées avec des positions définies en utilisant les méthodes `add` de la collection d’arrêts de dégradé exposée par l’interface [IGradientFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/igradientformat/).
1. Enregistrez la présentation modifiée au format PPTX.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation();
try {
    // Obtenir la première diapositive.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une forme auto de type Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Appliquer le formatage de dégradé à l'ellipse.
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

Le résultat :

![L’ellipse avec remplissage dégradé](gradient-fill.png)

## **Remplissage de motif**

Dans PowerPoint, le remplissage de motif est une option de formatage qui vous permet d’appliquer un dessin à deux couleurs — tel que des points, des rayures, des hachures croisées ou des carreaux — à une forme. Vous pouvez choisir des couleurs personnalisées pour le premier plan et l’arrière‑plan du motif.

Aspose.Slides propose plus de 45 styles de motif prédéfinis que vous pouvez appliquer aux formes pour améliorer l’aspect visuel de vos présentations. Même après avoir sélectionné un motif prédéfini, vous pouvez toujours spécifier les couleurs exactes à utiliser.

Voici comment appliquer un remplissage de motif à une forme avec Aspose.Slides :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Pattern`.
1. Choisissez un style de motif parmi les options prédéfinies.
1. Définissez la [Background Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/patternformat/#getBackColor--) du motif.
1. Définissez la [Foreground Color](https://reference.aspose.com/slides/fr/java/com.aspose.slides/patternformat/#getForeColor--) du motif.
1. Enregistrez la présentation modifiée au format PPTX.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

    // Définir les couleurs d'arrière-plan et d'avant-plan du motif.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Enregistrer le fichier PPTX sur le disque.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Dans PowerPoint, le remplissage d’image est une option de formatage qui vous permet d’insérer une image à l’intérieur d’une forme — en utilisant effectivement l’image comme arrière‑plan de la forme.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage d’image à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Picture`.
1. Définissez le mode de remplissage d’image sur `Tile` (ou un autre mode préféré).
1. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) à partir de l’image que vous souhaitez utiliser.
1. Passez l’image à la méthode `ISlidesPicture.setImage`.
1. Enregistrez la présentation modifiée au format PPTX.

Supposons que nous ayons un fichier "lotus.png" avec l’image suivante :

![L’image du lotus](lotus.png)

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Image en mosaïque comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du carrelage, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Définit le mode de remplissage d’image — soit `Tile` soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Spécifie l’alignement des carreaux à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Contrôle si le carreau est retourné horizontalement, verticalement, ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Définit le décalage horizontal du carreau (en points) par rapport à l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Définit le décalage vertical du carreau (en points) par rapport à l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Définit l’échelle horizontale du carreau en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Définit l’échelle verticale du carreau en pourcentage.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

    // Attribuer l'image à la forme.
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

Le résultat :

![Les options de carrelage](tile-options.png)

## **Remplissage couleur unie**

Dans PowerPoint, le remplissage couleur unie est une option de formatage qui remplit une forme d’une seule couleur uniforme. Cette couleur de fond simple est appliquée sans aucun dégradé, texture ou motif.

Pour appliquer un remplissage couleur unie à une forme avec Aspose.Slides, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de la forme sur `Solid`.
1. Attribuez la couleur de remplissage souhaitée à la forme.
1. Enregistrez la présentation modifiée au format PPTX.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

Le résultat :

![La forme avec remplissage couleur unie](solid-color-fill.png)

## **Définir la transparence**

Dans PowerPoint, lorsque vous appliquez un remplissage couleur unie, dégradé, image ou texture à des formes, vous pouvez également définir un niveau de transparence pour contrôler l’opacité du remplissage. Une valeur de transparence plus élevée rend la forme plus translucide, permettant au fond ou aux objets sous‑jacent d’être partiellement visibles.

Aspose.Slides vous permet de définir le niveau de transparence en ajustant la valeur alpha de la couleur utilisée pour le remplissage. Voici comment procéder :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) sur `Solid`.
1. Utilisez `Color` pour définir une couleur avec transparence (le composant `alpha` contrôle la transparence).
1. Enregistrez la présentation.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Aspose.Slides vous permet de faire pivoter des formes dans les présentations PowerPoint. Cela peut être utile lors du positionnement d’éléments visuels avec des exigences d’alignement ou de conception spécifiques.

Pour faire pivoter une forme sur une diapositive, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Définissez la propriété de rotation de la forme à l’angle souhaité.
1. Enregistrez la présentation.

```java
// Instancie la classe Presentation qui représente un fichier de présentation.
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

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Aspose.Slides vous permet d’appliquer des effets de biseau 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/).

Pour ajouter des effets de biseau 3D à une forme, suivez les étapes suivantes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Configurez le [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/) de la forme pour définir les paramètres de biseau.
1. Enregistrez la présentation.

```java
// Crée une instance de la classe Presentation.
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

    // Enregistrer la présentation au format PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

Aspose.Slides vous permet d’appliquer des effets de rotation 3D aux formes en configurant leurs propriétés [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/).

Pour appliquer une rotation 3D à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Utilisez les méthodes [setCameraType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icamera/#setCameraType-int-) et [setLightType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ilightrig/#setLightType-int-) pour définir la rotation 3D.
1. Enregistrez la présentation.

```java
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

    // Enregistrer la présentation au format PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Réinitialiser le formatage**

Le code Java suivant montre comment réinitialiser le formatage d’une diapositive et rétablir la position, la taille et le formatage de toutes les formes avec espaces réservés sur le [LayoutSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslide/) à leurs paramètres par défaut :

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Réinitialiser chaque forme sur la diapositive qui possède un placeholder sur la mise en page.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte‑t‑il la taille finale du fichier de présentation ?**

Seulement de façon marginale. Les images et médias incorporés occupent la majeure partie de l’espace du fichier, tandis que les paramètres de forme tels que les couleurs, les effets et les dégradés sont stockés en tant que métadonnées et n’ajoutent pratiquement aucune taille supplémentaire.

**Comment détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les principales propriétés de formatage de chaque forme — paramètres de remplissage, de ligne et d’effet. Si toutes les valeurs correspondantes sont identiques, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de formes personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un modèle de diaporama ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin et ré‑appliquez leur formatage où cela est requis.