---
title: Gestion des thèmes de présentation sur Android
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/androidjava/presentation-theme/
keywords:
- Thème PowerPoint
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

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème se réfèrent à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), tandis qu’une mise en page ou une diapositive individuelle peut remplacer son thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, substitution du master, substitution de la mise en page et substitution de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail de thème les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effet, et lire les valeurs effectives après résolution des héritages et des substitutions.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) expose le jeu de couleurs, le jeu de polices et le jeu de formats du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

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

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsque des substitutions de mise en page ou de diapositive peuvent être présentes.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent référencer une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets utilisant une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur du thème `Accent4` en rouge, enregistre la présentation, la rouvre, puis affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint génère des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations colorimétriques. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus foncées générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** – Couleurs principales du thème.  
**2** – Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

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

Ces variantes restent fondées sur la couleur de thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `IColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ce sont des noms alternatifs pour les mêmes emplacements de thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à une autre.

## **Modifier les polices du thème**

Un jeu de polices de thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le corps du texte. Les méthodes [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) et [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn‑lt` – Police du corps Latin (Minor Latin Font)
* `+mj‑lt` – Police du titre Latin (Major Latin Font)
* `+mn‑ea` – Police du corps Asiatique orientale (Minor East Asian Font)
* `+mj‑ea` – Police du titre Asiatique orientale (Major East Asian Font)
* `+mn‑cs` – Police du corps Script complexe (Minor Complex Script Font)
* `+mj‑cs` – Police du titre Script complexe (Major Complex Script Font)

L’exemple suivant crée un titre qui utilise la police Latin principale du thème et une ligne de corps qui utilise la police Latin secondaire du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police principale et le texte du corps suit la police secondaire. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne basculera pas automatiquement lorsque le jeu de polices du thème change.

Les collections de polices principale et secondaire peuvent également contenir des correspondances de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces correspondances, voir [Script‑Specific Theme Fonts](/slides/fr/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **Résoudre les références de police du thème**

Lors de l’inspection du texte, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) peut renvoyer une référence de thème telle que `+mn‑lt` au lieu d’un nom de famille de police. Appelez [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) avec le [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) approprié pour résoudre cette référence. Les préfixes `+mj` et `+mn` sélectionnent respectivement les jeux de polices principal et secondaire ; les suffixes `-lt`, `-ea` et `-cs` choisissent leurs polices Latin, Asiatique orientale et Script complexe.

Obtenez le thème effectif via [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) sur l’objet dont le thème s’applique au texte inspecté. Pour du texte ordinaire sur une diapositive, appelez cette méthode sur la diapositive afin que le contexte inclue le thème hérité de cette diapositive et les substitutions locales. Lors de l’inspection d’une mise en page ou d’un master, utilisez son propre thème effectif. Ne supposez pas que le thème du premier master s’applique à chaque diapositive.

L’exemple suivant crée une portion de texte qui référence explicitement la police Latin secondaire. Il initialise le jeu de polices d’une diapositive via [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) et définit les familles Latin principales et secondaires sur `Arial` et `Calibri`, rendant le résultat reproductible sans fichier d’entrée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

La sortie est `+mn‑lt -> Calibri` suivie de `Verdana -> Verdana`. La référence stockée reste inchangée, tandis qu’un nom de famille explicite est renvoyé tel quel. Si la portion utilisait `+mj‑lt`, elle se résoudrait en `Arial` dans ce thème.

Résoudre une référence de thème identifie la famille de police spécifiée par le thème. Cela ne vérifie pas la disponibilité de la police ni ne détermine le fichier de police réellement utilisé après substitution ou substitution de glyphe lors du rendu. Consultez [Font Selection Sequence](/slides/fr/androidjava/font-selection-sequence/) et [Font Substitution](/slides/fr/androidjava/font-substitution/) pour ces étapes séparées.

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d’un master**

Utilisez [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styler chaque diapositive dépendant d’un master particulier. Sélectionnez le master dans la collection [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), puis transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée un nouveau master slide basé sur le master sélectionné.  
2. Applique le thème externe au nouveau master.  
3. Associe le nouveau master à toutes les diapositives dépendant auparavant du master sélectionné.  
4. Retourne le [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) nouvellement créé.

L’exemple suivant applique un thème externe aux diapositives dépendant du premier master et enregistre la présentation :

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

Un thème invalide, corrompu ou non pris en charge peut déclencher [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers, et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives dépendant du master sélectionné sont ré‑assignées. Les diapositives associées à d’autres masters conservent leurs masters et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats explicitement assignés peuvent rester inchangés. Les substitutions au niveau de la mise en page et de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/androidjava/custom-font/), ou configurez la [font substitution](/slides/fr/androidjava/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des substitutions de thème au niveau de la diapositive ou de la mise en page.

### **Appliquer différents thèmes externes dans une présentation multi‑master**

Lorsque le master pertinent n’est pas connu à l’avance, récupérez‑le à partir d’une diapositive représentative via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) et [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Conservez les références des masters originaux avant d’appliquer les thèmes, car chaque appel crée un autre master dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

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

Le premier appel n’affecte que les diapositives dépendant de `firstGroupMaster`, et le second appel n’affecte que les diapositives dépendant de `secondGroupMaster`. Les diapositives appartenant à tout autre master ne sont pas re‑stylisées.

### **Conserver un thème source lors du déplacement de diapositives**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le master source dans la présentation cible avec [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), puis clonez la diapositive avec [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) et le master cloné. Cela transporte le master, ses mises en page et le thème associé ensemble.

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

C’est le flux de travail recommandé lorsque la diapositive source doit conserver exactement le même aspect dans la destination. Copier simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets dictés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa mise en page actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) copient les trois principaux composants du thème dans la substitution.

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

Cela change le thème utilisé par cette diapositive sans modifier le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Appliquer une substitution de thème à une mise en page**

Une substitution au niveau de la mise en page s’applique aux diapositives utilisant cette mise en page, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) :

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

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses mises en page et diapositives doivent partager le même design de base, une substitution de mise en page lorsque une famille de mise en page nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Un excès de substitutions au niveau de la diapositive complique les modifications globales ultérieures du thème.

<!-- visual-explanation:presentation-theme:start -->
[![Un thème master alimente deux mises en page ; une substitution de mise en page affecte ses diapositives sauf une diapositive avec une substitution plus locale.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Une substitution de mise en page s’applique aux diapositives utilisant cette mise en page sauf si une diapositive fournit sa propre substitution. Les valeurs basées sur le thème suivent leur schéma résolu ; les objets formatés explicitement peuvent conserver leur apparence locale. Gardez les substitutions aussi ciblées que l’exception de conception prévue.*
<!-- visual-explanation:presentation-theme:end -->

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint peut présenter davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages de thème avec les couleurs de thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et le [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) actuel. Un index de style `0` signifie aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Ceci diffère de l’indexation directe de la collection Java, où `get_Item(0)` désigne le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, affecte une référence d’arrière‑plan thématisé au premier master, puis enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le master et des éventuelles substitutions d’arrière‑plan au niveau de la mise en page ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) lorsque vous devez connaître l’arrière‑plan final après application des héritages.

{{% alert color="warning" title="Warning" %}}

Ne traitez pas l’index de style comme un index de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il ait le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Pour le formatage direct de l’arrière‑plan et l’héritage de l’arrière‑plan, consultez [Presentation Background](/slides/fr/androidjava/presentation-background/).

{{% /alert %}}

## **Mettre à jour les effets du thème**

Un jeu de formats du thème contient des collections séparées de styles de remplissage, de ligne et d’effet exposées via [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) et [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Les thèmes Office typiques contiennent souvent trois entrées de style principales correspondant visuellement à des formatages subtils, modérés et intenses, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en Java, l’index de la collection commence à zéro : `get_Item(0)` est le premier style stocké et `get_Item(2)` le troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style de thème ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre externe dans le troisième style d’effet, puis enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et du formatage direct éventuel.

![Styles d’effet du thème après modification des réglages de ligne, remplissage et ombre](presentation-design_11.png)

## **Sélectionner les styles de remplissage et de ligne du thème pour une forme**

Une forme peut sélectionner son remplissage et son contour indépendamment via [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) et [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Pour chaque méthode, l’index `1` sélectionne la première entrée de la collection de thème correspondante (`get_Item(0)`), et l’index `2` sélectionne la seconde (`get_Item(1)`).

L’exemple suivant crée deux styles de remplissage (or et bleu ciel) et deux styles de ligne (bleu foncé à 6 pt et rouge foncé à 12 pt) dans le thème par défaut d’une nouvelle présentation. Il enregistre la diapositive à trois étapes afin que vous puissiez comparer les résultats dans PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Styles initiaux | Modifier le contour droit | Modifier le premier remplissage du thème |
|:---:|:---:|:---:|
| ![Rectangles or et bleu ciel avec contours fins bleu foncé correspondants](theme-style-initial.png) | ![Le rectangle bleu ciel possède maintenant un contour épais rouge foncé](theme-style-line-changed.png) | ![Le rectangle gauche devient vert et les deux contours restent inchangés](theme-style-fill-changed.png) |

Sélectionner un style de ligne différent ne change que le contour du rectangle droit. Modifier le premier remplissage du thème met à jour chaque forme qui l’utilise. Ici, seul le rectangle gauche devient vert.

Sur une forme existante, une couleur de remplissage locale, une couleur de ligne ou une épaisseur de ligne peuvent remplacer cette partie du style du thème. Si la modification d’un index de style n’a aucun effet visible, vérifiez le [direct formatting](/slides/fr/androidjava/shape-formatting/) de la forme.

## **Déterminer si un remplissage solide effectif utilise une couleur de thème**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une mise en page, d’un master, d’un style de thème ou d’un autre niveau de formatage. Appelez [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) pour résoudre cette hiérarchie en un objet immuable [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Vérifiez d’abord [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Ce n’est que lorsqu’il est `FillType.Solid` que vous devez lire les propriétés du remplissage solide.

Pour un remplissage solide, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) renvoie la valeur RVB finale rendue après héritage, recherche dans le thème et application des transformations colorimétriques. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) renvoie l’emplacement logique [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) correspondant, tel que `Text1` ou `Accent6`. Une valeur `SchemeColor.NotDefined` signifie que le remplissage solide effectif n’est pas basé sur une couleur de schéma. Dans un flux où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) pour classifier un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de schéma définie localement, son champ local étant `NotDefined`, tandis que son remplissage effectif hérite d’une couleur de thème et se résout en `Text1` ou `Accent6`. À l’inverse, `getSolidFillSchemeColor` indique quel emplacement logique du thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la mise en page, du master ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, examine les remplissages des formes et des portions de texte, imprime chaque valeur RVB finale ainsi que la couleur de schéma associée, et signale les remplissages solides qui ne suivront pas les changements de couleur du thème :

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

La branche `NotDefined` fournit une liste d’audit des remplissages solides qui ne réagiront pas aux modifications des emplacements de couleur du thème. Passez en revue ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RVB signalée montre toujours l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir changé le thème de la présentation, une substitution de thème ou tout formatage hérité, appelez `getEffective` à nouveau et lisez un nouvel objet `IFillFormatEffectiveData` avant de comparer ou de rapporter les couleurs.

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

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

Utilisez les données effectives pour les diagnostics de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), vous pouvez passer à côté d’une substitution de master, de mise en page, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) ne réaffecte que les diapositives dépendant du master sélectionné. Les diapositives utilisant d’autres masters conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans changer le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) de la diapositive et initialisez sa substitution de thème. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la manière la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en conservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master à l’aide de [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) et [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Cela maintient le master, les mises en page et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et substitutions ?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) pour une diapositive ou un thème de mise en page, ainsi que les méthodes de données effectives correspondantes pour les objets de format tels que [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) et [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Ces API renvoient les valeurs résolues après application des héritages et des substitutions.