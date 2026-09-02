---
title: Gérer les thèmes de présentation en Java
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/java/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets compatibles thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/masterthememanager/), tandis qu’une disposition ou une diapositive individuelle peut remplacer son thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseoverridethememanager/). En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, substitution du master, substitution de la disposition et substitution de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants liés aux thèmes : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après que l’héritage et les substitutions aient été résolus.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mastertheme/) expose le schéma de couleurs, le schéma de polices et le schéma de formats du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mastertheme/) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mastertheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail « effective‑theme » montré plus loin dans cet article lorsque des substitutions de disposition ou de diapositive peuvent être présentes.

## **Change Theme Colors**

Les remplissages, lignes et textes compatibles thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans l’[IColorScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icolorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus par rapport à la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple suivant crée une forme qui utilise `Accent4`, change la couleur de thème `Accent4` en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint dérive des variantes plus claires et plus foncées d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Couleurs principales du thème.

**2** - Variantes plus claires et plus foncées générées à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, puis enregistre le résultat :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ces variantes restent basées sur la couleur de thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur de `Accent4`.

### **Map `SchemeColor` Values to `IColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que l’[IColorScheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit de noms alternatifs pour les mêmes emplacements de thème ; ce ne sont pas des valeurs converties dynamiquement d’une forme à une autre.

## **Change Theme Fonts**

Un schéma de polices de thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le texte du corps. Les méthodes [IFontScheme.getMajor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontscheme/) et [IFontScheme.getMinor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontscheme/) exposent ces jeux.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Minor Latin Font)
* `+mj-lt` - Police du titre Latin (Major Latin Font)
* `+mn-ea` - Police du corps Asiatique de l’Est (Minor East Asian Font)
* `+mj-ea` - Police du titre Asiatique de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne basculera pas automatiquement lorsque le schéma de polices du thème change.

Les collections de polices majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, consultez [Script-Specific Theme Fonts](/slides/fr/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

For more information about presentation fonts, see [PowerPoint Fonts](/slides/fr/java/powerpoint-fonts/).

{{% /alert %}}

## **Copy or Apply a Theme**

Il existe deux flux de travail courants, qui résolvent des problèmes différents.

### **Preserve a Source Theme When Moving Slides**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/), puis clonez la diapositive avec [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé ensemble.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

C’est le flux de travail recommandé lorsque la diapositive source doit conserver exactement la même apparence dans la destination. Cloner simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/overridetheme/) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fr/java/com.aspose.slides/overridetheme/) copient les trois principaux composants du thème dans la substitution.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/overridetheme/).

### **Apply a Theme Override to a Layout**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/layoutslidethememanager/) :

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Des substitutions excessives au niveau des diapositives rendent les modifications globales de thème ultérieures plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iformatscheme/). PowerPoint peut proposer davantage de choix d’arrière‑plan dans son interface utilisateur que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages de thème avec des couleurs de thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et le [Background.getStyleIndex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/background/) actuel. Un index de style de `0` signifie aucun remplissage thématique ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection Java, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation possède le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématique au premier master et enregistre la présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat visible dépend de l’entrée de thème référencée par le master et de toute substitution d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/background/) lorsque vous avez besoin de connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}

Do not treat the style index as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

For direct background formatting and background inheritance, see [Presentation Background](/slides/fr/java/presentation-background/).

{{% /alert %}}

## **Update Theme Effects**

Un schéma de formats de thème contient des collections séparées de styles de remplissage, de ligne et d’effet exposées via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iformatscheme/) et [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iformatscheme/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en Java, l’index de la collection est basé sur zéro : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet et enregistre le résultat :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et de la présence éventuelle d’un formatage direct qui surcharge le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution de l’héritage et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseoverridethememanager/). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/background/), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/), vous risquez de manquer un master, une disposition, une diapositive ou une substitution de forme qui modifie l’apparence finale.

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

Yes. Use the slide's [SlideThemeManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidethememanager/) and initialize its override theme. The change remains local to that slide; other slides continue to inherit their existing themes.

**What is the safest way to carry a theme from one presentation to another?**

When moving a slide and preserving its source appearance, clone the source master into the destination and clone the slide with that master using [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imasterslidecollection/) and [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidecollection/). This keeps the master, layouts, and theme together.

**How can I see the effective values after inheritance and overrides?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseoverridethememanager/) for a slide or layout theme and the corresponding effective-data methods for format objects such as [Background.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/background/) and [FillFormat.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/). These APIs return the resolved values after inheritance and overrides are applied.