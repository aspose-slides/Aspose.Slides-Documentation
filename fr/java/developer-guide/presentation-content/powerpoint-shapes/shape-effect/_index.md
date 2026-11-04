---
title: Appliquer des effets de forme aux présentations en Java
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/java/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides for Java — créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d’une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus agréables que d’autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de préréglage sont des combinaisons de deux effets ou plus dont l’aspect est jugé bon. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides propose des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Apply a Shadow Effect**

Aspose.Slides for Java prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre au design de votre présentation.

### **Apply an Outer Shadow**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau sur le fond de la diapositive. L’ombre dépasse les bords de la forme, créant l’impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, sa direction, sa distance et son rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code Java montre comment appliquer l’[effet d’ombre externe](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) à un rectangle :
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Effet d'ombre](shadow_effect.png)

### **Apply an Inner Shadow**

Lors de la reproduction du style visuel d’un modèle, utilisez une ombre interne pour donner à une carte ou un panneau une apparence en retrait. Une ombre externe s’étend à l’extérieur de la forme et la fait paraître surélevée, tandis qu’une ombre interne ombre l’intérieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), puis configurez l’ombre renvoyée par [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Des valeurs de rayon de flou plus grandes produisent des bords plus doux.

Cet exemple Java crée une carte bleu clair avec une ombre interne gris foncé et l’enregistre au format PPTX. La direction de l’ombre est de 225 degrés, sa distance est de 7 points, et son rayon de flou est de 6 points :
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l’ombre interne, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) sur le format d’effet de la forme.

## **Apply a Reflection Effect**

Pour appliquer un effet de réflexion dans Aspose.Slides for Java, vous pouvez ajouter une réflexion semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus soigné et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code Java montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) à une forme :
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

## **Apply a Glow Effect**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés telles que la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant et accrocheur à votre présentation. Il est facile à mettre en œuvre avec peu de code, améliorant l’aspect général de vos diapositives.

Ce code Java montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) à une forme :
```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Apply a Soft Edges Effect**

Pour appliquer un effet de bords doux dans Aspose.Slides for Java, vous pouvez créer une transition lisse et floue autour des bords d’une forme. Cet effet ajoute un aspect plus subtil et raffiné, idéal pour les conceptions qui nécessitent une apparence douce et délicate. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l’effet souhaité sur diverses formes de votre présentation.

Ce code Java montre comment appliquer l’[effet de bords doux](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) à une forme :
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

## **Apply a Blur Effect**

Utilisez le flou de forme pour adoucir le remplissage et le contour d’une forme tout en la conservant éditable. Appelez [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) sur le format d’effet de la forme. Le rayon est mesuré en points (1/72 pouce) : utilisez une valeur non négative, des valeurs plus élevées produisant un flou plus fort. Un rayon de zéro laisse l’apparence inchangée.

Le paramètre [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) contrôle les limites visibles de l’effet. Avec `false`, le flou est découpé aux limites peintes d’origine, y compris le contour. Avec `true`, le flou peut s’étendre au‑delà de ces limites. Aucun des deux réglages ne modifie la position ou les dimensions de la forme.

La comparaison ci‑dessous utilise le même remplissage, le même contour et les mêmes dimensions de forme partout. La rangée du haut utilise `grow = false` ; la rangée du bas utilise `grow = true`.

![Rectangle original comparé aux rayons de flou de 5 et 15 points, avec grow désactivé et activé](shape_blur_comparison.png)

Cet exemple Java crée un rectangle orange avec un contour bleu foncé, applique un flou de 5 points, puis le met à jour avec un flou de 15 points en rappelant à nouveau [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Il enregistre les deux états floutés, puis appelle [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) et enregistre la forme sans flou.
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Le flou de forme affecte à la fois le remplissage et le contour. Un effet de bords doux atténue les bords de la forme, tandis que le flou d’ombre adoucit uniquement l’ombre. Les effets de transformation d’image s’appliquent au contenu de l’image ; cet exemple applique le flou directement au format d’effet de la forme sans convertir la forme en image.

## **FAQ**

**Can I apply multiple effects to the same shape?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une seule forme pour créer un aspect plus dynamique.

**What shapes can I apply effects to?**

Vous pouvez appliquer des effets à diverses formes, notamment les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Can I apply effects to grouped shapes?**

Oui, vous pouvez appliquer des effets aux formes groupées. L’effet sera appliqué à l’ensemble du groupe.