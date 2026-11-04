---
title: Mise en forme des formes PowerPoint en Java
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
- remplissage dégradé
- remplissage de motif
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
- Java
- Aspose.Slides
description: "Apprenez à mettre en forme les formes PowerPoint en Java avec Aspose.Slides — définissez les styles de remplissage, de ligne et d’effet pour les fichiers PPT et PPTX avec précision et contrôle total."
---
## **Introduction**

Formatez les formes dans PowerPoint en ajustant leurs contours, remplissages et effets. Aspose.Slides for Java vous permet de contrôler ces paramètres par programme, y compris la transparence, la rotation et le formatage 3D.

![Options de formatage des formes dans PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java fournit des interfaces et des méthodes qui vous permettent de formater les formes en utilisant les mêmes options disponibles dans PowerPoint.

## **Formater les lignes**

Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) pour contrôler le contour d’une forme. Cet exemple crée un rectangle sans remplissage avec un contour bleu en pointillés. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) sélectionne une ligne composée épaisse-fine, tandis que [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) définit sa largeur à 7 points et [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) sélectionne le motif de tirets.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les lignes formatées dans la présentation](formatted-lines.png)

### **Définir des motifs de tirets personnalisés**

Utilisez [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) lorsque les styles de ligne prédéfinis ne fournissent pas les longueurs de tirets et les espaces dont vous avez besoin, par exemple pour des contours de marque ou des diagrammes techniques. L’attribution d’un motif change automatiquement le style de tiret de ligne en [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Les entrées du tableau alternent entre les longueurs de tiret et d’espace, en commençant par un tiret. Chaque valeur est un multiple de la largeur de la ligne : `{ 4, 2 }` avec une largeur de 3 points produit un tiret de 12 points suivi d’un espace de 6 points. Utilisez des paires de valeurs finies et non négatives pour définir des segments complets de tiret et d’espace. L’exemple utilise des valeurs positives pour garder chaque tiret et espace visible.

Cet exemple crée cinq lignes bleues de même longueur et avec des extrémités plates. Les trois premières comparent des motifs avec une largeur de 3 points. La quatrième répète le premier motif avec le double de la largeur, doublant ainsi les longueurs du tiret et de l’espace. La cinquième passe d’un motif personnalisé à une ligne pleine.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Retourner la dernière ligne à un style plein.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour revenir à un style pointillé prédéfini, transmettez [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) à [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Le style sélectionné contrôle l’apparence de la ligne.

Le résultat dans PowerPoint, de haut en bas : **{4, 2}, 3 pt** ; **{1, 2}, 3 pt** ; **{6, 2, 1, 2}, 3 pt** ; **{4, 2}, 6 pt** ; et **Solide, 3 pt**.

![Trois motifs de tirets personnalisés, une ligne plus large utilisant le premier motif, et une ligne pleine dans PowerPoint](custom-dash-patterns.png)

### **Définir les extrémités de ligne**

Utilisez [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) pour définir les extrémités d’une ligne ouverte. La classe [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) fournit trois styles d’extrémité explicites :

- `Flat` : Le tracé s’arrête au point final.
- `Round` : Une extrémité semi‑circulaire dépasse le point final de la moitié de la largeur de la ligne.
- `Square` : Une extrémité carrée dépasse le point final de la moitié de la largeur de la ligne.

La classe comprend également `NotDefined`, ce qui signifie qu’aucun style d’extrémité n’est explicitement attribué.

Les extrémités diffèrent des pointes de flèche, qui ajoutent des symboles aux extrémités de la ligne, et des jointures, qui contrôlent les coins entre les segments de ligne. Cet exemple désactive les pointes de flèche via [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) et [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) afin que seules les formes d’extrémité soient comparées.

L’exemple suivant crée trois lignes horizontales autrement identiques, d’une largeur de 20 points. De haut en bas, elles utilisent respectivement les caps plat, rond et carré. Leurs points d’extrémité ont les mêmes coordonnées horizontales ; les caps rond et carré s’étendent de 10 points au-delà de chaque point d’extrémité.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat dans PowerPoint, de haut en bas : **Flat**, **Round**, et **Square**.

![Extrémités plates, rondes et carrées sur des lignes épaisses identiques dans PowerPoint](line-caps.png)

## **Appliquer des effets de croquis aux lignes de forme**

Un effet de croquis rend la ligne d’une forme semblable à un dessin à main levée. Utilisez [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) pour accéder aux paramètres de la ligne, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) pour accéder aux paramètres du croquis, et [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) pour sélectionner une valeur dans la classe [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Le code Java suivant montre comment appliquer un effet [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , lire la valeur explicitement attribuée, et supprimer l’effet avec [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

La valeur renvoyée par [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) représente le paramètre attribué directement à la forme. Si le formatage de la ligne peut être hérité d’un thème, d’une diapositive maîtresse ou d’une diapositive de mise en page, utilisez [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) , accédez à [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) , et lisez [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) . La valeur effective reflète le formatage réellement appliqué après résolution de l’héritage. Cet exemple nécessite une présentation existante contenant au moins une forme sur sa première diapositive et affiche les deux valeurs :

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

Le style de jointure contrôle la façon dont deux segments de contour se rejoignent à un coin. Utilisez **Round** pour des coins arrondis, **Miter** pour des coins pointus, ou **Bevel** pour des coins aplatis.

![Le style de jointure dans la présentation](join-style-powerpoint.png)

Cet exemple crée trois rectangles noirs avec des contours bleus de 15 points de largeur. Il utilise [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) pour définir les valeurs miter, bevel et round de [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) , respectivement, afin de comparer la façon dont les coins sont dessinés.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Limiter les jointures de type Miter aux coins pointus**

Utilisez [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) avec [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) réglé sur [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) pour limiter l’étendue d’un coin pointu.

La limite est un rapport entre la distance entre les coins interne et externe de la jointure et la largeur de la ligne. Par exemple, une valeur de `8` permet une longueur de jointure jusqu’à huit fois la largeur de la ligne ; ce n’est pas une mesure en points. Si le coin dépasse la limite, PowerPoint utilise une jointure biseautée à ce coin. Une limite plus grande permet des pointes plus aiguës. Ce paramètre affecte uniquement les jointures de type miter, et le modifier n’a aucun effet visible lorsque le coin reste dans les deux limites.

Cet exemple crée deux triangles identiques, sans remplissage, avec des contours de 20 points de largeur. Le triangle de gauche utilise une limite de `2`, et celui de droite utilise `8`. Chaque triangle mesure 80 points de largeur et 160 points de hauteur, donnant à son coin supérieur un rapport longueur‑miter/largeur‑ligne d’environ `4.12`. Ainsi, PowerPoint bisea le sommet gauche et préserve le sommet droit.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat dans PowerPoint : **Miter limit 2** à gauche et **miter limit 8** à droite.

![Un sommet biseauté avec une limite miter de 2 et un sommet pointu avec une limite miter de 8 dans PowerPoint](miter-limits.png)

## **Remplissage dégradé**

Un dégradé mélange les couleurs à travers une forme. Cet exemple remplit une ellipse avec un dégradé linéaire à un angle de 45 degrés du rouge au violet en utilisant [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) . La méthode [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) place les arrêts de couleur à 0 et 1, le début et la fin du dégradé. Effacer les arrêts existants garantit que seules ces deux couleurs sont utilisées.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’ellipse avec remplissage dégradé](gradient-fill.png)

Si un dégradé apparaît différemment dans une image exportée que dans PowerPoint, consultez [Choose a Gradient Rendering Style](/slides/fr/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Vous pouvez sélectionner un style de rendu sans modifier le remplissage dégradé stocké dans la présentation.

### **Définir l’angle du dégradé linéaire**

Utilisez [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) pour contrôler l’orientation d’un remplissage [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) . L’angle est mesuré en degrés et augmente dans le sens horaire : `0` va de gauche à droite, `90` de haut en bas, `180` de droite à gauche, et `270` de bas en haut. Les angles fractionnaires sont pris en charge. Les angles finis en dehors de `[0, 360)` sont normalisés à une révolution ; par exemple, `-45` devient `315` et `360` devient `0`.

Cet exemple crée six rectangles avec des arrêts rouge, vert et bleu identiques aux positions `0`, `0.5` et `1`. Le redimensionnement est désactivé afin que l’angle puisse être comparé indépendamment des proportions des rectangles. Les angles, de gauche à droite, sont `0`, `45` et `90` dans la première rangée, et `135`, `180` et `270` dans la deuxième rangée.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat dans PowerPoint :

![Dégradés linéaires à 0, 45 et 90 degrés dans la rangée supérieure, et 135, 180 et 270 degrés dans la rangée inférieure](linear-gradient-angles.png)

### **Mise à l’échelle d’un dégradé linéaire avec la forme**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) accepte une valeur [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) . Réglez-la explicitement sur `False` pour conserver l’angle géométrique du dégradé lorsque les proportions de la forme changent, ou sur `True` pour mettre le dégradé à l’échelle avec la largeur et la hauteur de la forme. Avec le redimensionnement activé, l’angle visible peut différer de l’angle assigné sur une forme non carrée.

L’exemple suivant utilise un angle de `45` degrés et les mêmes arrêts de couleur que la comparaison d’angles. La colonne de gauche utilise `False` ; la colonne de droite utilise `True`. Chaque colonne contient un rectangle large au-dessus d’un rectangle haut. Les deux commencent avec les mêmes dimensions larges ; modifier la largeur et la hauteur du deuxième rectangle montre comment le remplissage réagit au redimensionnement sans modifier ses paramètres de dégradé.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat dans PowerPoint, avec le redimensionnement désactivé à gauche et activé à droite :

![Rectangles larges et hauts avec un dégradé de 45 degrés, comparant LinearGradientScaled False à gauche et True à droite](linear-gradient-scaling.png)

Avec le redimensionnement désactivé, les bandes de couleur diagonales conservent la même orientation dans les deux rectangles. Avec le redimensionnement activé, les bandes s’étirent avec les proportions de la forme. Cela aide à reproduire le dégradé d’un modèle lors de l’adaptation d’une forme à une taille différente. Sur un carré, activer le redimensionnement ne modifie pas l’apparence de ce dégradé de `45` degrés.

Les paramètres d’angle et de redimensionnement s’appliquent aux dégradés linéaires. Ils ne contrôlent pas les remplissages [GradientShape.Radial ou GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) .

### **Combiner l’angle avec la direction du dégradé**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) sélectionne un style de dégradé dans la classe [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) ; ce n’est pas un substitut à un angle numérique. Pour un dégradé linéaire, les styles de coin peuvent modifier la zone sur laquelle les couleurs sont réparties sans changer l’angle assigné via [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) . Conservez la direction inchangée lors de la comparaison d’angles ou du redimensionnement.

L’exemple suivant applique les mêmes paramètres dans des ordres inversés. Les deux rectangles ont le même aspect : assigner la direction avant ou après l’angle ne modifie pas le résultat.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remplissage de motif**

Un remplissage de motif applique un dessin bicolore, tel que points, rayures ou damiers. Cet exemple utilise [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) pour sélectionner un motif en treillis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) fournit le fond gris clair, et [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) fournit la couleur jaune du motif.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le rectangle avec remplissage de motif](pattern-fill.png)

## **Remplissage d’image**

Un remplissage d’image utilise une image à l’intérieur d’une forme. Cet exemple nécessite une image locale et utilise [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) pour la charger dans la collection d’images de la présentation. Définir [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) sur le mode mosaïque répète l’image à l’intérieur du rectangle. L’image source utilisée ici est affichée ci‑dessous :

![L’image du lotus](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La forme avec remplissage d’image](picture-fill.png)

### **Mosaïquer l’image comme texture**

Si vous souhaitez définir une image en mosaïque comme texture et personnaliser le comportement du pavage, vous pouvez utiliser les méthodes suivantes de l’interface [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) : Définit le mode de remplissage d’image—soit `Tile` soit `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) : Spécifie l’alignement des tuiles à l’intérieur de la forme.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) : Contrôle si la tuile est retournée horizontalement, verticalement, ou les deux.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) : Définit le décalage horizontal de la tuile (en points) depuis l’origine de la forme.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) : Définit le décalage vertical de la tuile (en points) depuis l’origine de la forme.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) : Définit l’échelle horizontale de la tuile en pourcentage.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) : Définit l’échelle verticale de la tuile en pourcentage.

Cet exemple nécessite une image locale et configure [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) pour la répéter à 50 % de sa taille d’origine. Des décalages de –32 points déplacent les tuiles horizontalement et verticalement ; l’alignement en bas à droite et le retournement dans les deux directions déterminent comment la texture répétée est disposée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les options de mosaïque](tile-options.png)

## **Remplissage de couleur unie**

Un remplissage uni donne à une forme une couleur unique et uniforme. Cet exemple utilise [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) pour définir le mode de remplissage uni et attribue le jaune via [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) , puis enregistre le rectangle dans une présentation.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La forme avec remplissage de couleur unie](solid-color-fill.png)

## **Utiliser l’arrière‑plan de la diapositive comme remplissage de forme**

Utilisez [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) lorsque qu’une forme doit correspondre à l’arrière‑plan de la diapositive, par exemple dans un modèle de présentation. Utilisez [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) pour définir d’abord [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) afin de supprimer tout remplissage explicite. Avec cette combinaison, la forme utilise l’arrière‑plan de la diapositive à la place de son remplissage de style. Activer le drapeau seul ne supprime pas un remplissage explicite existant.

Cela diffère de [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) : le remplissage d’arrière‑plan couvre les objets derrière la forme avec la zone correspondante de l’arrière‑plan de la diapositive, tandis que Aucun remplissage laisse ces objets visibles. Un dégradé reste aligné avec la diapositive plutôt que de redémarrer à l’intérieur de chaque forme.

L’exemple suivant crée un arrière‑plan maître hérité par la diapositive et place une bande magenta derrière trois rectangles. Le rectangle de gauche utilise l’arrière‑plan, le rectangle du milieu n’a aucun remplissage, et le rectangle de droite passe du remplissage d’arrière‑plan à un remplissage orange explicite.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hériter du dégradé du maître.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Ajouter cet objet en premier afin qu’il apparaisse derrière les rectangles.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Désactiver le remplissage d’arrière-plan avant d’appliquer un remplissage explicite.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat, de gauche à droite : **remplissage d’arrière‑plan**, **sans remplissage**, et **remplissage explicite**. La bande magenta est masquée par les rectangles gauche et droit mais reste visible à travers le rectangle du milieu.

![Remplissage d’arrière‑plan, aucun remplissage et remplissage orange explicite sur une bande magenta](background-fill.png)

Le même comportement s’applique à un arrière‑plan défini directement sur la diapositive ou hérité d’une mise en page. La forme utilise l’arrière‑plan résolu de la diapositive ; l’exemple laisse les arrière‑plans de la diapositive et de la mise en page indéfinis afin que le maître le fournisse.

## **Définir la transparence**

Pour un remplissage uni, le composant alpha de la couleur contrôle l’opacité : 0 est complètement transparent et 255 est complètement opaque. Cet exemple utilise une valeur alpha de 128 pour un rectangle jaune, le rendant approximativement à 50 % transparent afin que le rectangle en dessous reste visible. La couleur est attribuée via [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) .

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La forme transparente](shape-transparency.png)

## **Faire pivoter les formes**

Utilisez [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) pour faire pivoter une forme dans le plan de la diapositive. L’angle est mesuré en degrés ; cet exemple fait pivoter un rectangle de 5 degrés dans le sens horaire et enregistre la présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La rotation de la forme](shape-rotation.png)

## **Ajouter des effets de biseau 3D**

Utilisez [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) pour donner à une forme de la profondeur et des biseaux. Cet exemple crée une ellipse verte avec un contour orange, utilise [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) pour définir la profondeur à 4 points, et applique un biseau supérieur circulaire avec une largeur et une hauteur de 6 points via [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) . Une caméra orthographique frontale et un éclairage à trois points rendent le biseau visible.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’effet de biseau 3D](3D-bevel-effect.png)

## **Ajouter des effets de rotation 3D**

La vue 3D d’une forme est contrôlée par les paramètres de sa caméra. Cet exemple utilise [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) avec des angles de latitude, longitude et révolution de 40, 35 et 20 degrés, respectivement. Il sélectionne une caméra isométrique via [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) et un éclairage équilibré via [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) , puis enregistre le rectangle formaté.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’effet de rotation 3D](3D-rotation-effect.png)

## **Contrôler le rendu noir et blanc pour les formes**

La méthode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) spécifie comment une forme individuelle est rendue lorsqu’une présentation est affichée ou traitée en mode noir et blanc. Elle n’active pas l’affichage noir et blanc seule, et ne modifie pas le remplissage, le contour ou tout autre formatage de la forme en mode couleur normal.

Utilisez une valeur de la classe [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) pour sélectionner le comportement souhaité. Par exemple, `Automatic` laisse l’application de rendu choisir la conversion, `Gray` et `LightGray` utilisent une coloration grise, `BlackWhite` utilise uniquement le noir et blanc, `Black` et `White` forcent une couleur unique, `Color` préserve la coloration normale, et `Hidden` omet la forme en mode noir et blanc. `NotDefined` signifie qu’aucun mode au niveau de la forme n’est assigné.

Cet exemple crée un rectangle orange et utilise [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) pour régler le mode sur gris. La forme enregistrée conserve son remplissage orange pour l’affichage en couleur normale et demande une coloration grise aux applications qui respectent les paramètres d’affichage noir et blanc :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En mode couleur normal, le rectangle conserve son remplissage orange. Dans un flux de travail d’affichage noir et blanc, il utilise une coloration grise parce que son mode est réglé sur `Gray`. Cela vous permet de conserver une diapositive en couleur complète tout en définissant une apparence distincte pour l’impression, la prévisualisation ou d’autres flux de travail qui respectent les paramètres d’affichage noir et blanc de la présentation.

## **Réinitialiser le formatage**

Utilisez [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) pour restaurer la position, la taille et le formatage des espaces réservés de diapositive à partir de leurs espaces réservés de mise en page correspondants. Cet exemple nécessite une présentation existante avec des espaces réservés liés à la mise en page et réinitialise chaque diapositive avant l’enregistrement. Les formes sans espace réservé de mise en page correspondant ne sont pas réinitialisées.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le formatage des formes affecte-t-il la taille finale du fichier de présentation ?**

Les couleurs, les styles de ligne et les paramètres d’effets ajoutent généralement peu de données comparés aux images et médias incorporés. Les remplissages d’image peuvent augmenter la taille du fichier car leurs images sont stockées dans la présentation.

**Comment puis‑je détecter les formes sur une diapositive qui partagent un formatage identique afin de les regrouper ?**

Comparez les propriétés clés de formatage de chaque forme — remplissage, contour et paramètres d’effet. Si toutes les valeurs correspondantes correspondent, considérez leurs styles comme identiques et regroupez logiquement ces formes, ce qui simplifie la gestion ultérieure des styles.

**Puis‑je enregistrer un ensemble de styles de forme personnalisés dans un fichier séparé pour les réutiliser dans d’autres présentations ?**

Oui. Stockez des formes d’exemple avec les styles souhaités dans un jeu de diapositives modèle ou un fichier de modèle .POTX. Lors de la création d’une nouvelle présentation, ouvrez le modèle, clonez les formes stylisées dont vous avez besoin, et réappliquez leur formatage où cela est requis.