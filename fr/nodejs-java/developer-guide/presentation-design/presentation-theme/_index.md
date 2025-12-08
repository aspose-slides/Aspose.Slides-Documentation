---
title: "Thème de présentation"
type: docs
weight: 10
url: /fr/nodejs-java/presentation-theme/
keywords: "Thème, Thème PowerPoint, Présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Thème de présentation PowerPoint en JavaScript"
---

Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d’éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/nodejs-java/powerpoint-fonts/), [styles d’arrière-plan](/slides/fr/nodejs-java/presentation-background/), et des effets.

![theme-constituents](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments d’une diapositive. Si vous n’aimez pas les couleurs, vous les modifiez en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs dans l’énumération [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SchemeColor).

Ce code JavaScript montre comment changer la couleur d’accent pour un thème:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Vous pouvez déterminer la valeur effective de la couleur résultante de cette façon :
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


Pour démontrer davantage l’opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d’accent (provenant de l’opération initiale). Ensuite, nous modifions la couleur dans le thème :
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la couleur du thème à partir de la palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème(1), des couleurs de la palette supplémentaire(2) sont générées. Vous pouvez alors définir et obtenir ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1** - Couleurs principales du thème

**2** - Couleurs de la palette supplémentaire.

Ce code JavaScript montre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème puis utilisées dans des formes :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, plus clair 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, plus clair 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, plus clair 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, plus sombre 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, plus sombre 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d’autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du corps latin (Police latine mineure)
* **+mj-lt** - Police de titre latin (Police latine majeure)
* **+mn-ea** - Police du corps est‑asiatique (Police est‑asiatique mineure)
* **+mj-ea** - Police du corps est‑asiatique (Police est‑asiatique majeure)

Ce code JavaScript montre comment attribuer la police Latin à un élément du thème :
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


Ce code JavaScript montre comment modifier la police du thème de présentation :
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


La police dans toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="ASTUCE" %}} 
Vous pourriez vouloir consulter les [polices PowerPoint](/slides/fr/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière-plan du thème**

Par défaut, l’application PowerPoint propose 12 arrière-plans prédéfinis mais seulement 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique.

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l’application PowerPoint, vous pouvez exécuter ce code JavaScript pour connaître le nombre d’arrière-plans prédéfinis dans la présentation :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 
En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) de la classe [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme), vous pouvez ajouter ou accéder au style d’arrière-plan dans un thème PowerPoint.
{{% /alert %}} 

Ce code JavaScript montre comment définir l’arrière-plan d’une présentation :
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**Guide d’index** : 0 indique aucun remplissage. L’index commence à 1.

{{% alert color="primary" title="ASTUCE" %}} 
Vous pourriez vouloir consulter le [Arrière‑plan PowerPoint](/slides/fr/nodejs-java/presentation-background/).
{{% /alert %}}

## **Modifier l’effet du thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) de la classe [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme), vous pouvez modifier les éléments d’un thème (de manière encore plus flexible que les options de PowerPoint).

Ce code JavaScript montre comment changer un effet de thème en modifiant certaines parties des éléments :
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Les changements résultants dans la couleur de remplissage, le type de remplissage, l’effet d’ombre, etc. :
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Puis-je appliquer un thème à une seule diapositive sans changer le maître ?**

Oui. Aspose.Slides prend en charge les substitutions de thème au niveau de la diapositive, vous pouvez donc appliquer un thème local uniquement à cette diapositive tout en conservant le thème maître intact (via le [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/)).

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

[Clone slides](/slides/fr/nodejs-java/clone-slides/) avec leur maître dans la présentation cible. Cela préserve le maître original, les dispositions et le thème associé afin que l’apparence reste cohérente.

**Comment puis‑je voir les valeurs « effectives » après toutes les héritages et substitutions ?**

Utilisez les vues « effectives » de l’API [/slides/nodejs-java/shape-effective-properties/] pour le thème/couleur/police/effet. Elles renvoient les propriétés résolues et finales après l’application du maître ainsi que des éventuelles substitutions locales.