---
title: Gérer les thèmes de présentation sur Android
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/androidjava/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- thème externe
- THMX
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Android via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, polices, styles d’arrière‑plan, remplissages, lignes et effets. Les objets sensibles au thème se réfèrent à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est accessible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un maître peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/masterthememanager/), tandis qu’une disposition ou une diapositive individuelle peut remplacer le thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/baseoverridethememanager/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, substitution du maître, substitution de la disposition et substitution de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants liés aux thèmes : inspection d’un thème, modification des couleurs et des polices, copie ou application d’un thème, mise à jour des styles d’arrière‑plan et d’effets, et lecture des valeurs effectives après résolution de l’héritage et des substitutions.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/mastertheme/) expose le jeu de couleurs, le jeu de polices et le jeu de formats du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/mastertheme/) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/mastertheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le maître associé à la diapositive, et utilisez le flux de travail « thème effectif » présenté plus loin dans cet article lorsque des substitutions de disposition ou de diapositive peuvent être présentes.

## **Change Theme Colors**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans [IColorScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icolorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint génère des variantes plus claires et plus sombres à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Couleurs principales du thème.

**2** - Variantes plus claires et plus sombres générées à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux et enregistre le résultat :

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

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Map `SchemeColor` Values to `IColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit de noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Change Theme Fonts**

Un jeu de polices de thème comprend un jeu de polices majeur pour les titres et un jeu de polices mineur pour le corps du texte. Les méthodes [IFontScheme.getMajor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontscheme/) et [IFontScheme.getMinor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifontscheme/) exposent ces ensembles.

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le jeu de polices du thème évolue.

Les collections de polices majeures et mineures peuvent également contenir des correspondances de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour les inspecter, les ajouter, les remplacer ou les supprimer, consultez [Script-Specific Theme Fonts](/slides/fr/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Copy or Apply a Theme**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Apply an External Theme to a Master's Dependent Slides**

Utilisez [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styler chaque diapositive dépendant d’un maître particulier. Sélectionnez le maître dans la collection [Presentation.getMasters](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/), et transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée une nouvelle diapositive maître basée sur le maître sélectionné.
1. Applique le thème externe au nouveau maître.
1. Attribue le nouveau maître à toutes les diapositives qui dépendaient auparavant du maître sélectionné.
1. Retourne le [IMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) nouvellement créé.

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier maître et enregistre la présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un thème invalide, corrompu ou non pris en charge peut déclencher [PptxReadException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxreadexception/). Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers, et n’enregistrez la présentation qu’après l’application réussie du thème.

Seules les diapositives dépendant du maître sélectionné sont réaffectées. Les diapositives associées à d’autres maîtres conservent leurs maîtres et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus à partir du thème externe. Les couleurs, polices, remplissages et autres formatages affectés directement peuvent rester inchangés. Les substitutions au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau maître.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/androidjava/custom-font/), ou configurez la [font substitution](/slides/fr/androidjava/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du maître : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas la création manuelle de substitutions de thème au niveau de la disposition ou de la diapositive.

### **Apply Different External Themes in a Multi-Master Presentation**

Lorsque le maître concerné n’est pas connu à l’avance, obtenez‑le à partir d’une diapositive représentative via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islide/) et [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/). Conservez les références des maîtres originaux avant d’appliquer des thèmes, car chaque appel crée un autre maître dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs maîtres et applique un thème externe différent à chaque groupe :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Le premier appel n’affecte que les diapositives dépendant de `firstGroupMaster`, et le second appel n’affecte que les diapositives dépendant de `secondGroupMaster`. Les diapositives appartenant à un autre maître ne sont pas re‑stylées.

### **Preserve a Source Theme When Moving Slides**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le maître source dans la présentation cible avec [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/), puis clonez la diapositive avec [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/) et le maître cloné. Cela transporte le maître, ses dispositions et le thème associé.

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

C’est le flux de travail recommandé lorsque la diapositive source doit apparaître de façon identique dans la destination. Un simple clonage du contenu sur un maître de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets dictés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son maître et sa disposition actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/overridetheme/) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/overridetheme/) copient les trois principaux composants du thème dans la substitution.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/overridetheme/).

### **Apply a Theme Override to a Layout**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/layoutslidethememanager/) :

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

Utilisez un thème de maître ou de présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Un excès de substitutions au niveau de la diapositive rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iformatscheme/). PowerPoint peut présenter davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’indice de style actuel via [Background.getStyleIndex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/background/). Un indice de style `0` signifie aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection Java, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématisée au premier maître et enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le maître et d’éventuelles substitutions d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, ne modifier que l’arrière‑plan du maître peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/background/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas l’indice de style comme un indice de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il possède la même apparence dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage de l’arrière‑plan, consultez [Presentation Background](/slides/fr/androidjava/presentation-background/).
{{% /alert %}}

## **Update Theme Effects**

Un jeu de formats de thème contient des collections séparées de remplissages, de lignes et d’effets exposées via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iformatscheme/) et [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iformatscheme/). Les thèmes Office typiques contiennent souvent trois entrées de style principales correspondant visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en Java, l’indice de collection commence à zéro : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les indices de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet, et enregistre le résultat :

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formatages directs qui remplacent le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un maître, d’un style de thème ou d’un autre niveau de formatage. Appelez [IFillFormat.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformat/) pour résoudre cette hiérarchie en un objet immuable [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformateffectivedata/). Vérifiez d’abord [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformateffectivedata/). Ce n’est que lorsqu’il vaut `FillType.Solid` que vous devez lire les propriétés du remplissage plein.

Pour un remplissage plein, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformateffectivedata/) renvoie la valeur RVB finale rendue après héritage, recherche de thème et transformations de couleur. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformateffectivedata/) renvoie l’emplacement logique correspondant de [SchemeColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/schemecolor/), tel que `Text1` ou `Accent6`. Une valeur `SchemeColor.NotDefined` indique que le remplissage plein effectif n’est pas basé sur une couleur de schéma. Dans un flux de travail où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icolorformat/) pour classer un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de schéma définie localement, son état local est donc `NotDefined`, alors que son remplissage effectif hérite d’une couleur de thème et se résout en `Text1` ou `Accent6`. Inversement, `getSolidFillSchemeColor` indique quel emplacement logique de thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la disposition, du maître ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, examine les remplissages des formes et des portions de texte, affiche chaque valeur RVB finale et la couleur de schéma associée, et signale les remplissages pleins qui ne suivront pas les changements de couleur du thème :

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La branche `NotDefined` fournit une liste d’audit des remplissages pleins qui ne réagiront pas aux changements dans les emplacements de couleur du thème. Examinez ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RVB rapportée montre toujours l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir modifié le thème de la présentation, une substitution de thème ou tout formatage hérité, appelez à nouveau `getEffective` et lisez un nouvel objet `IFillFormatEffectiveData` avant de comparer ou de signaler les couleurs.

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution de l’héritage et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/baseoverridethememanager/). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/background/), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fillformat/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/), vous pouvez manquer une substitution de maître, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**Does applying an external theme affect every slide in the presentation?**

Non. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/) ne réaffecte que les diapositives qui dépendent du maître sélectionné. Les diapositives utilisant d’autres maîtres conservent leurs thèmes existants.

**Can I apply a theme to a single slide without changing the master?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidethememanager/) de la diapositive et initialisez sa substitution de thème. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**What is the safest way to carry a theme from one presentation to another?**

Lors du déplacement d’une diapositive tout en conservant son apparence d’origine, clonez le maître source dans la destination et clonez la diapositive avec ce maître en utilisant [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslidecollection/) et [ISlideCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecollection/). Cela garde le maître, les dispositions et le thème ensemble.

**How can I see the effective values after inheritance and overrides?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/baseoverridethememanager/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/background/) et [FillFormat.getEffective](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/fillformat/). Ces API renvoient les valeurs résolues après application de l’héritage et des substitutions.