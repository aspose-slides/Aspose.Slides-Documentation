---
title: Appliquer des effets de forme aux présentations sur Android
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/androidjava/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides pour Android via Java — créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/androidjava/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser l’éclat d’une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus réussies que d’autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Preset sont des combinaisons de deux effets ou plus qui sont connues pour être esthétiques. Ainsi, en sélectionnant un preset, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d’ombre**

Aspose.Slides pour Android via Java prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre à la conception de votre présentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau par rapport à l’arrière‑plan de la diapositive. L’ombre dépasse les bords de la forme, créant l’impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, direction, distance et rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code Java montre comment appliquer l’[effet d’ombre externe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) à un rectangle :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet d’ombre](shadow_effect.png)

### **Appliquer une ombre interne**

Lorsque vous recréez le style visuel d’un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect en retrait. Une ombre externe s’étend à l’extérieur de la forme et la fait paraître surélevée, tandis qu’une ombre interne ombre l’intérieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), puis configurez l’ombre renvoyée par [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Des valeurs de rayon de flou plus grandes produisent des bords plus doux.

Cet exemple Java crée une carte bleu clair avec une ombre interne gris foncé et l’enregistre sous forme de fichier PPTX. La direction de l’ombre est de 225 degrés, sa distance est de 7 points et son rayon de flou est de 6 points :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l’ombre interne, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) sur le format d’effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides pour Android via Java, vous pouvez ajouter une réflexion semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus poli et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide sur plusieurs éléments pour un design homogène.

Ce code Java montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) à une forme :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de réflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides pour Android via Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant et accrocheur à votre présentation. Il est facile à mettre en œuvre avec un code minimal, améliorant l’aspect général de vos diapositives.

Ce code Java montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) à une forme :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides pour Android via Java, vous pouvez créer une transition lisse et floue autour des bords d’une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions qui nécessitent une apparence douce et atténuée. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l’effet souhaité sur diverses formes de votre présentation.

Ce code Java montre comment appliquer l’[effet de bords doux](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) à une forme :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet de bords doux](soft_edges_effect.png)

## **Appliquer un effet de flou**

Utilisez le flou de forme pour adoucir le remplissage et le contour d’une forme tout en conservant la forme éditable. Appelez [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) sur le format d’effet de la forme. Le rayon est mesuré en points (1/72 pouce) : utilisez une valeur non négative, les valeurs plus grandes produisant un flou plus fort. Un rayon de zéro laisse l’apparence inchangée.

Le paramètre [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) contrôle les limites visibles de l’effet. Avec `false`, le flou est limité aux limites originales peintes, y compris le contour. Avec `true`, le flou peut s’étendre au‑delà de ces limites. Aucun des paramètres ne modifie la position ou les dimensions de la forme.

La comparaison ci‑dessous utilise le même remplissage, contour et dimensions de forme partout. La rangée supérieure utilise `grow = false` ; la rangée inférieure utilise `grow = true`.

![Rectangle original comparé avec des rayons de flou de 5 et 15 points, avec grow désactivé et activé](shape_blur_comparison.png)

Cet exemple Java crée un rectangle orange avec un contour bleu foncé, applique un flou de 5 points, puis le met à jour à un flou de 15 points en appelant à nouveau [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Il enregistre les deux états floutés, puis appelle [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) et enregistre la forme sans flou.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le flou de forme affecte le remplissage et le contour ensemble. Un effet de bords doux estompe les bords de la forme, tandis que le flou d’ombre adoucit uniquement l’ombre. Les effets de transformation d’image agissent sur le contenu de l’image ; cet exemple applique le flou directement au format d’effet de la forme sans convertir la forme en image.

## **FAQ**

**Puis‑je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets aux formes groupées ?**

Oui, vous pouvez appliquer des effets aux formes groupées. L’effet sera appliqué à l’ensemble du groupe.