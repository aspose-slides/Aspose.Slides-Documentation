---
title: Gérer les thèmes de présentation en JavaScript
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/nodejs-java/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- changer le thème
- gérer le thème
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation en JavaScript avec Aspose.Slides pour Node.js afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getmastertheme/). Une présentation peut également contenir des surcharges de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterthememanager/), tandis qu’une disposition ou une diapositive individuelle peut remplacer son thème hérité via [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseoverridethememanager/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, surcharge du master, surcharge de la disposition et surcharge de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail de thème les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des surcharges.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mastertheme/) expose le schéma de couleurs, le schéma de polices et le schéma de format du thème via [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mastertheme/) et [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mastertheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail de thème effectif présenté plus loin dans cet article lorsque des surcharges de disposition ou de diapositive peuvent être présentes.

## **Change Theme Colors**

Les remplissages, lignes et textes sensibles au thème peuvent se référer à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/colorscheme/), tous les objets qui font encore référence à cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre, et imprime la couleur de remplissage effective :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint génère des variantes plus claires et plus sombres à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Couleurs principales du thème.

**2** – Variantes plus claires et plus sombres produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, et enregistre le résultat :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change ultérieurement, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Map `SchemeColor` Values to `ColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que le [ColorScheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/colorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit simplement de noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs dynamiquement converties d’une forme à l’autre.

## **Change Theme Fonts**

Un schéma de polices de thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le texte de corps. Les méthodes [FontScheme.getMajor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontscheme/) et [FontScheme.getMinor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fontscheme/) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` – Police du corps Latin (Minor Latin Font)
* `+mj-lt` – Police du titre Latin (Major Latin Font)
* `+mn-ea` – Police du corps Asiatique de l’Est (Minor East Asian Font)
* `+mj-ea` – Police du titre Asiatique de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème évoluera.

{{% alert color="info" title="Tip" %}}

Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Copy or Apply a Theme**

Il existe deux flux de travail courants, qui résolvent des problèmes différents.

### **Preserve a Source Theme When Moving Slides**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslidecollection/), puis clonez la diapositive avec [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé ensemble.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

C’est le flux de travail recommandé lorsque la diapositive source doit conserver exactement le même aspect dans la destination. Cloner simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une surcharge au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/overridetheme/) et [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/overridetheme/) copient les trois principaux composants du thème dans la surcharge.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la surcharge locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/overridetheme/).

### **Apply a Theme Override to a Layout**

Une surcharge au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède sa propre surcharge. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslidethememanager/) :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une surcharge de disposition lorsqu’une famille de dispositions nécessite un style différent, et une surcharge de diapositive uniquement pour de véritables exceptions. Un excès de surcharges au niveau des diapositives rend les modifications globales de thème ultérieures plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/formatscheme/). PowerPoint peut présenter davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’[Background.getStyleIndex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/background/) actuel. Un index de style de `0` signifie aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Ceci diffère de l’indexation directe de la collection JavaScript, où l’index `0` correspond au premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématisé au premier master, puis enregistre la présentation :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat visible dépend de l’entrée de thème référencée par le master et de toute surcharge d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/background/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}

Ne traitez pas l’index de style comme un index de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style du thème sont spécifiques à chaque présentation.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/nodejs-java/presentation-background/).

{{% /alert %}}

## **Update Theme Effects**

Un schéma de format du thème contient des collections séparées de remplissages, de lignes et d’effets exposées via [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/formatscheme/) et [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/formatscheme/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en JavaScript, l’index de la collection est zéro‑based : l’index `0` correspond au premier style stocké et l’index `2` au troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [ShapeStyle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapestyle/). Modifier un style de thème affecte les formes qui font référence à ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet, et enregistre le résultat :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt opaque, et le troisième style d’effet acquiert une ombre extérieure avec une distance de 10 points. Le rendu exact dépend toujours des emplacements de style que chaque forme référence et si un formatage direct l’emporte sur le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des surcharges locales. Pour une diapositive, appelez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseoverridethememanager/). Pour un arrière‑plan, utilisez [Background.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/background/), et pour un remplissage, utilisez [FillFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fillformat/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.getMasterTheme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getmastertheme/), vous pouvez passer à côté d’une surcharge de master, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidethememanager/) de la diapositive et initialisez son thème de surcharge. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**What is the safest way to carry a theme from one presentation to another?**

Lors du déplacement d’une diapositive tout en préservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master en utilisant [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslidecollection/) et [SlideCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/). Cela conserve le master, les dispositions et le thème ensemble.

**How can I see the effective values after inheritance and overrides?**

Utilisez [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseoverridethememanager/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/background/) et [FillFormat.getEffective](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fillformat/). Ces API renvoient les valeurs résolues après l’application des héritages et des surcharges.