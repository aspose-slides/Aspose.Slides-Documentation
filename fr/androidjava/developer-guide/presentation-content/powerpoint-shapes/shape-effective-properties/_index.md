---
title: Obtenir les propriétés effectives des formes à partir de présentations sur Android
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/androidjava/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Android via Java calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---
## **Vue d'ensemble**

Ce sujet explique la différence entre les propriétés **locales** et **effectives**. Les valeurs locales sont des valeurs définies directement à un niveau de mise en forme spécifique, tel que :

1. Propriétés de portion sur une diapositive.  
2. Styles de texte de forme prototype sur une diapositive de disposition ou maîtresse, lorsque la forme du cadre de texte de la portion en possède un.  
3. Paramètres de texte globaux dans une présentation.

Les valeurs locales peuvent être définies ou omises à n'importe quel niveau. Lorsque Aspose.Slides a besoin du formatage final « tel qu'affiché », il résout la chaîne d'héritage et renvoie les valeurs **effectives**. Vous pouvez les obtenir en appelant la méthode `getEffective()` sur l'objet de format local.

L'exemple suivant montre comment obtenir des valeurs effectives. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) avec un cadre de texte et au moins une portion.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Les données de formatage effectif représentent le format calculé actuel après l'application de l'héritage. Dans l'implémentation actuelle, certains objets de données effectives, tels que [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportionformateffectivedata/), peuvent être mis en cache en interne. Appeler à nouveau `getEffective()` après avoir modifié le format parent ou hérité peut actualiser le cache, et un objet obtenu précédemment peut ne plus représenter l'état antérieur. Si vous devez conserver les valeurs effectives pour une réutilisation ultérieure, copiez les propriétés requises, telles que la hauteur de police, la couleur de remplissage, le style de police ou l'alignement, dans votre propre objet de données.
{{% /alert %}}

## **Obtenir les propriétés effectives d’une caméra**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’une caméra. L’interface [ICameraEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icameraeffectivedata/) représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de [ICameraEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icameraeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un Light Rig**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un Light Rig. L’interface [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilightrigeffectivedata/) représente un objet immuable contenant les propriétés effectives du système d’éclairage. Une instance de [ILightRigEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilightrigeffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’une forme à biseau**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un biseau de forme. L’interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) représente un objet immuable contenant les propriétés effectives du relief d’une forme. Une instance de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) est exposée via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformateffectivedata/), qui fournit les valeurs effectives pour [IThreeDFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un cadre de texte**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un cadre de texte. L’interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframeformateffectivedata/) contient les propriétés de formatage effectif du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif d’un cadre de texte. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) avec un cadre de texte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés effectives d’un style de texte**

Aspose.Slides vous permet d’obtenir les propriétés effectives d’un style de texte. L’interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextstyleeffectivedata/) contient les propriétés du style de texte effectif.

L'exemple de code suivant montre comment obtenir les propriétés effectives d’un style de texte. Il suppose que la première forme de la première diapositive est un [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) avec un cadre de texte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir la valeur de hauteur de police effective**

Aspose.Slides vous permet d’obtenir la hauteur de police effective. Le code suivant montre comment la hauteur de police effective d’une portion change après que des valeurs locales de hauteur de police soient définies à différents niveaux de la structure de la présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir le format de remplissage effectif d’un tableau**

Aspose.Slides vous permet d’obtenir le format de remplissage effectif pour différentes parties d’un tableau. L’interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifillformateffectivedata/) contient les propriétés de remplissage effectif. Le format de cellule a une priorité supérieure à celui de ligne, le format de ligne a une priorité supérieure à celui de colonne, et le format de colonne a une priorité supérieure à celui du tableau entier.

En conséquence, les propriétés de [ICellFormatEffectiveData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icellformateffectivedata/) sont utilisées pour dessiner la cellule du tableau. L’exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties du tableau. Il suppose que la première forme de la première diapositive est un [ITable](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### `getEffective()` renvoie-t-il un instantané ?

Pas toujours. Les données effectives représentent le format calculé après l'application de l'héritage, mais certains objets de données effectives peuvent être mis en cache en interne. Un appel ultérieur à `getEffective()` peut recalculer le format et actualiser le cache, de sorte qu'un objet précédemment obtenu ne doit pas être considéré comme un instantané durable.

### Quand faut‑il relire les propriétés effectives ?

Appelez `getEffective()` à nouveau après avoir modifié le format local, les styles parents, le format de disposition, le format maître ou les valeurs par défaut au niveau de la présentation. L’appel suivant réévalue la hiérarchie de formatage et renvoie le résultat effectif actuel.

### Le fait de modifier ou de supprimer une diapositive de disposition/maîtresse affecte‑t‑il les propriétés effectives déjà récupérées ?

Oui, mais le changement se reflète lors du prochain appel à `getEffective()`. Si une source de formatage parent est modifiée ou supprimée, les données effectives obtenues précédemment peuvent devenir obsolètes. Une fois `getEffective()` appelé de nouveau, Aspose.Slides réévalue l’arbre de formatage et les polices, couleurs, tailles ou autres valeurs peuvent changer.

### Puis‑je modifier des valeurs via les objets de données effectives ?

Non. Les objets de données effectives exposent uniquement les valeurs calculées. Effectuez les changements dans les objets de formatage locaux, puis obtenez à nouveau les valeurs effectives.

### Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la disposition/maîtresse, ni dans les paramètres globaux ?

La valeur effective est déterminée par le mécanisme par défaut, qui inclut les valeurs par défaut de PowerPoint et d’Aspose.Slides. Cette valeur résolue devient alors partie des données effectives courantes.

### À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?

Pas directement. Les données effectives renvoient la valeur finale. Pour en connaître la source, vérifiez les valeurs locales au niveau de la portion, du paragraphe, du cadre de texte et des styles de texte aux niveaux de disposition, maître et présentation afin d’identifier le premier endroit où la définition explicite apparaît.

### Pourquoi les valeurs effectives ressemblent parfois aux valeurs locales ?

Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

### Quand faut‑il utiliser les propriétés effectives et quand faut‑il travailler uniquement avec les locales ?

Utilisez les données effectives lorsque vous avez besoin du résultat « tel qu'affiché » après l'application de tout l’héritage, par exemple pour aligner les couleurs, les retraits ou les tailles. Si vous devez conserver ces valeurs indépendamment des modifications de formatage ultérieures, copiez les propriétés requises dans votre propre objet. Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez les données effectives pour vérifier le résultat.