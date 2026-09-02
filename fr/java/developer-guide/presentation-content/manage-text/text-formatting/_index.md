---
title: Formatage du texte de présentation en Java
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/java/text-formatting/
keywords:
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété d’ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Aperçu**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé **sample.pptx**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

Pour trouver et mettre en surbrillance du texte littéral ou des correspondances d'expression régulière, voir [Rechercher et remplacer du texte](/slides/fr/java/search-and-replace-text/).

## **Définir la couleur d'arrière‑plan du texte**

Utilisez [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pour des portions de texte individuelles.

L’exemple de code suivant montre comment définir la couleur d’arrière‑plan pour le **paragraphe entier** :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour les **portions de texte en gras** :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Définir la couleur de surbrillance pour la portion de texte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) pour définir l’alignement du paragraphe à l’intérieur d’un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe au **centre** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir l'alignement du paragraphe au centre.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l’échelle 0–255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence au **paragraphe entier** :

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir la couleur de remplissage du texte à une couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Définir la transparence de la portion de texte.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères pour le texte**

Utilisez [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) pour élargir ou condenser l’espacement entre les caractères d’une zone de texte.

Le code Java suivant montre comment élargir l’espacement des caractères dans le **paragraphe entier** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Augmenter l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dess dessous montre comment élargir l’espacement des caractères dans les **portions de texte en gras** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3); // Augmenter l'espacement des caractères.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu se rapproche davantage de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) sur une valeur nettement supérieure à la taille réelle de la police :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce paramètre empêche le crénage d’être appliqué aux portions de texte correspondantes et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/).

Le code suivant définit la police et le style du texte pour le **paragraphe entier** : il applique la taille de police, le gras, l’italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir les propriétés de police pour le paragraphe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Définir les propriétés de police pour la portion de texte.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) pour définir une orientation de texte prédéfinie à l’intérieur d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/).

Le code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides fournit [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) et [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) pour contrôler l’espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.  
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple de code suivant montre comment spécifier l’interligne au sein du paragraphe :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L’interligne dans le paragraphe](line_spacing.png)

## **Définir le type d’ajustement automatique pour les cadres de texte**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se réduit, déborde ou redimensionne automatiquement la forme.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l’ancrage des cadres de texte**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) définit comment le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au milieu ou en bas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la tabulation du texte**

Utilisez [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) et [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getTabs--) pour configurer les tabulations dans un paragraphe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L’exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Définir l'Id d'une langue de vérification.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajouter une nouvelle forme rectangulaire avec du texte.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Vérifier la langue de la première portion.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Définir le style de texte par défaut**

Pour appliquer une mise en forme de texte par défaut au niveau de la présentation, utilisez [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

L’exemple de code suivant montre comment définir une police en gras de 14 pt par défaut pour tout le texte des diapositives d’une nouvelle présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Récupérer le format de paragraphe de niveau supérieur.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraire le texte avec l’effet Majuscules (All‑Caps)**

Dans PowerPoint, l’application de l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s’il a été tapé en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier **sample2.pptx**.

![L’effet All Caps](all_caps_effect.png)

L’exemple de code ci‑dessous montre comment extraire le texte avec l’effet **All Caps** appliqué :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.getTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/#getTextFrame--) et la mise en forme des paragraphes via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Comment appliquer une couleur de dégradé au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur de dégradé au texte, utilisez [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Définissez [IFillFormat.setFillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifillformat/#setFillType-byte-) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) et configurez les points d’arrêt du dégradé, la direction et la transparence.