---
title: Créer et appliquer des effets WordArt en Java
linktitle: WordArt
type: docs
weight: 110
url: /fr/java/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet de réflexion
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre externe
- effet d'ombre interne
- Java
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour Java. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en Java."
---
## **Vue d’ensemble**

Les effets WordArt vous permettent de styliser le texte avec des remplissages, des contours, des ombres, des reflets, des lueurs, des transformations et un formatage 3D. Cet article explique comment créer et personnaliser ces effets dans des présentations PowerPoint à l’aide d’Aspose.Slides pour Java, sans Microsoft Office installé.

## **Créer un modèle WordArt simple et l’appliquer au texte**

Les exemples suivants créent un style WordArt simple en définissant le texte, la police, le remplissage de motif et le contour.

Chaque exemple crée une nouvelle présentation et ajoute un rectangle à sa première diapositive ; aucun fichier d’entrée n’est requis. Le premier exemple définit le texte sur « Aspose.Slides ». La position et les dimensions de la forme sont mesurées en points :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Définissez la police sur Arial Black à 36 points pour rendre le formatage plus visible :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Appliquez un motif [SmallGrid](https://reference.aspose.com/slides/fr/java/com.aspose.slides/patternstyle/#SmallGrid) avec un avant-plan orange foncé et un arrière-plan blanc, puis ajoutez un contour de texte noir d’une largeur de 1 point :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![Le modèle WordArt simple](WordArt_template.png)

## **Appliquer d’autres effets WordArt**

Les exemples suivants démontrent comment appliquer des ombres, des reflets, des lueurs, des transformations et des effets 3D au texte.

### **Appliquer des effets d’ombre externe**

Une ombre externe ajoute de la profondeur en plaçant une ombre derrière le texte. Vous pouvez personnaliser sa couleur, sa direction, sa distance, son rayon de flou, son échelle et son inclinaison.

Cet exemple appelle [enableOuterShadowEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) et définit une ombre noire avec un rayon de flou de 4 points, une direction de 230 degrés et une distance de 30 points. Des valeurs d’échelle de 100 conservent la taille de l’ombre, tandis qu’une inclinaison horizontale l’incline de 20 degrés. La transformation alpha fixe son opacité à 32 % :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![L’effet d’ombre externe](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Lorsque les ombres externes et prédéfinies sont utilisées ensemble, seule l’ombre externe est appliquée.
- Si les ombres externes et internes sont utilisées simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l’effet est doublé, alors que dans PowerPoint 2007, seule l’ombre externe est appliquée.
{{% /alert %}}

### **Appliquer des effets de réflexion**

Une réflexion crée une copie miroir du texte. Ajustez sa position, son échelle, son flou et son opacité pour contrôler son apparence.

Cet exemple appelle [enableReflectionEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effectformat/#enableReflectionEffect--) et retourne la réflexion verticalement avec une échelle de -100 %. Il utilise un rayon de flou de 0,5 point et une distance de 4,72 points. L’opacité passe de 60 % à 0,9 % entre les positions 0 % et 60 % le long de la réflexion :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![L’effet de réflexion](reflection_effect.png)

### **Appliquer des effets de lueur**

Une lueur ajoute un contour coloré doux autour du texte. Ajustez sa couleur, son opacité et son rayon pour contrôler l’effet.

Cet exemple appelle [enableGlowEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effectformat/#enableGlowEffect--) et applique une lueur rouge avec une opacité de 54 % et un rayon de 7 points :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![L’effet de lueur](glow_effect.png)

### **Appliquer des transformations WordArt**

Les transformations WordArt courbent, étirent ou déforment un bloc de texte.

Définissez [setTransform](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframeformat/#setTransform-int-) sur [ArchUpPour](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textshapetype/#ArchUpPour) pour courber l’ensemble du cadre de texte vers le haut :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![La transformation WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pour Java fournit un ensemble de [types de transformation prédéfinis](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Appliquer des effets 3D aux formes et au texte**

Vous pouvez appliquer des effets 3D à une forme ou à son texte. Les chanfreins, l’extrusion, l’éclairage et les paramètres de caméra contrôlent l’apparence résultante.

L’exemple suivant utilise [ThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/) pour ajouter des chanfreins circulaires, une extrusion orange et un contour rouge foncé au rectangle. Les dimensions du chanfrein, la hauteur d’extrusion, la largeur du contour et la profondeur sont mesurées en points. Un matériau plastique, un éclairage équilibré tourné de 40 degrés autour de l’axe Z et une caméra en perspective définissent son apparence :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

La forme résultante :

![L’effet 3D de la forme](shape_3D_effect.png)

Cet exemple applique un formatage 3D similaire au texte via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Des chanfreins plus petits façonnent les bords des lettres, tandis que l’extrusion et l’éclairage donnent de la profondeur au texte :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Le texte résultant :

![L’effet 3D du texte](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L’application d’effets 3D au texte ou à leurs formes — et l’interaction entre ces effets — est régie par des règles spécifiques. Considérez une scène impliquant à la fois le texte et la forme qui le contient. Un effet 3D comprend la représentation 3D de l’objet et la scène dans laquelle il est placé.

- Si une scène est définie à la fois pour la forme et pour le texte, la scène de la forme prend le pas et la scène du texte est ignorée.
- Si la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée.
- Si la forme n’a aucun effet 3D, elle est considérée comme plate et l’effet 3D est appliqué uniquement au texte.

Ces comportements se rapportent aux méthodes [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/#getLightRig--) et [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fr/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Pour garder le texte plat et lisible tout en conservant le formatage 3D de sa forme, consultez [Keep Text Flat on a 3D Shape](/slides/fr/java/3d-presentation/) pour une comparaison des deux réglages et un exemple complet en Java.

## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex., arabe, chinois) ?**

Oui, Aspose.Slides pour Java prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

**Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?**

Oui, vous pouvez appliquer les effets WordArt aux formes sur les masques de diapositives, y compris les espaces réservés aux titres, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la disposition du masque seront reflétées sur toutes les diapositives associées.

**Les effets WordArt affectent‑ils la taille du fichier de présentation ?**

Légèrement. Les effets WordArt tels que les ombres, les lueurs et les remplissages en dégradé peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage ajoutées, mais la différence est généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex., PNG, JPEG) à l’aide de [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage--), ou rendre des formes individuelles avec [IShape.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#getImage--). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.