---
title: Formater le texte d'une présentation en Java
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
- espacement des lignes
- propriété d'ajustement automatique
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Formater et styliser le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Aperçu**

Cet article montre comment formater du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Java. Il couvre les couleurs d’arrière-plan, la transparence, l'espacement des caractères, les propriétés des polices, la rotation, l'espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres linguistiques.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme sur sa première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci‑dessous. Les indices des diapositives et des formes sont basés sur zéro. Les exemples qui sélectionnent des portions en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour trouver et mettre en surbrillance du texte littéral ou des correspondances d’expression régulière, voir [Rechercher et remplacer du texte](/slides/fr/java/search-and-replace-text/).

## **Définir la couleur d’arrière-plan du texte**

Utilisez [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) pour définir la couleur de surlignage par défaut d'un paragraphe, ou utilisez [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pour les portions de texte individuelles.

L'exemple suivant définit un surlignage gris clair comme couleur par défaut pour le premier paragraphe. Les couleurs de surlignage explicites sur les portions individuelles priment sur cette valeur par défaut :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir la couleur de surlignage pour le paragraphe entier.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour **les portions de texte avec une police en gras** :

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
            // Définir la couleur de surlignage pour la portion de texte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) pour définir l'alignement du paragraphe à l'intérieur d'un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

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

## **Aligner les polices à l'intérieur d'une ligne**

Utilisez [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) pour aligner verticalement les portions de texte de différentes tailles de police au sein d'une ligne. Ce réglage s'applique à l'ensemble du paragraphe et contrôle l'alignement dans chacune de ses lignes.

L'exemple autonome suivant crée quatre zones de texte étiquetées sur une même diapositive. Chaque paragraphe contient le même texte aux tailles 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l’ajustement automatique et le retour à la ligne, et maintient les cadres de texte suffisamment grands pour une seule ligne.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Comparaison de l'alignement de police de ligne de base, haut, centre et bas avec des tailles de police mixtes :

![Comparaison de l'alignement de police de ligne de base, haut, centre et bas avec des tailles de police mixtes](font_alignment.png)

L'alignement des polices utilise les métriques de police, de sorte que les bords visibles des lettres individuelles ne sont pas forcément alignés exactement. L'exemple inclut à la fois une lettre majuscule et un descendeur afin de montrer la différence entre l'alignement de base et l'alignement en bas. La disponibilité et la substitution des polices, les caractères utilisés et la différence de tailles de police affectent le résultat. Les dimensions du cadre, les marges, l'espacement des lignes, le retour à la ligne et l'ajustement automatique influencent également la mise en page ; utilisez les mêmes polices et paramètres de disposition lors de la comparaison des modes.

Ce réglage diffère de [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), qui contrôle l'alignement horizontal du paragraphe, et de [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), qui place le bloc de texte verticalement à l'intérieur de sa forme. Le formatage exposant et indice via [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) décale les portions individuelles par rapport à la ligne de base plutôt que de définir l'alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Dans les exemples ci‑dessous, `alpha = 50` est une valeur du canal alpha ARGB sur une échelle de 0 à 255, et non un pourcentage de transparence.

L'exemple de code ci‑dessous montre comment appliquer la transparence au **paragraphe entier** :

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir la couleur de remplissage du texte sur une couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

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

## **Définir l'espacement des caractères pour le texte**

Utilisez [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) pour augmenter ou réduire l'espacement entre les caractères d'une zone de texte. Les exemples ajoutent 3 points d'espacement ; les valeurs négatives condensent le texte.

Le code Java suivant montre comment augmenter l'espacement des caractères dans le **paragraphe entier** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment augmenter l'espacement des caractères dans les **portions de texte avec une police en gras** :

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
            portion.getPortionFormat().setSpacing(3); // Étendre l'espacement des caractères.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut apparaître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu se rapproche de celui de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) sur une valeur supérieure à la taille réelle de la police. Cet exemple nécessite "presentation.pptx" avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour le texte correspondant en dessous du seuil, ce réglage empêche le crénage et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

L'exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec un formatage gras, italique et souligné pointillé. Le formatage explicite sur les portions individuelles prime sur ces valeurs par défaut.

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

L'exemple suivant applique Times New Roman 13 points, le formatage italique et un soulignement pointillé aux portions dont le formatage effectif est en gras :

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

## **Contrôler la normalisation de la hauteur du texte**

Utilisez [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) lors de la reproduction d'une typographie de modèle ou de l'investigation des différences de hauteur de caractères. Dans PowerPoint, l'activation de la normalisation étire ou compresse verticalement les caractères individuels afin de leur donner une hauteur visible uniforme au sein de la portion de texte. Cela ne garantit pas des hauteurs de texte égales entre différentes polices.

Définissez la propriété sur [NullableBool.True ou False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) pour activer ou désactiver explicitement la normalisation. `NullableBool.NotDefined` laisse le réglage local non défini de sorte que la portion hérite de sa valeur, par exemple depuis le [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) du paragraphe. Cela ne signifie pas `False`. Utilisez [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) et lisez [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) pour obtenir la valeur booléenne résolue.

L'exemple autonome suivant nécessite que **Arial** soit installé. Il crée deux blocs de texte contenant les mêmes lettres majuscules, minuscules, descendeurs et caractères accentués à 54 points. Les deux paragraphes activent la normalisation par défaut. La portion supérieure la désactive explicitement ; la portion inférieure l'hérite. Les tailles de cadre, les marges et l'espacement des paragraphes sont identiques, le retour à la ligne et l'ajustement automatique étant désactivés pour garder la comparaison cohérente. L'exemple affiche `False: false` et `NotDefined: true`, puis enregistre "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous a été exportée depuis la présentation enregistrée. La rangée supérieure a la normalisation désactivée (`False`) ; la rangée inférieure hérite du réglage activé (`NotDefined` → `True`). Conservez Arial installé pour reproduire cet aspect.

![Texte Arial 54 points avec normalisation désactivée en haut et normalisation héritée activée en bas](text_height_normalization.png)

La normalisation modifie la hauteur des caractères sans changer la valeur assignée de [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) qui spécifie la taille de la police en points. Le [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) du paragraphe contrôle l'espacement des lignes, tandis que le [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) du cadre de texte contrôle comment le texte ou son conteneur s'ajuste. Ces réglages ont des objectifs différents et peuvent affecter la mise en page globale de manière indépendante. Pour plus d'informations sur le formatage des paragraphes et l'héritage, voir [Gérer les paragraphes](/slides/fr/java/manage-paragraph/).

## **Appliquer et supprimer le barré**

Utilisez [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) sur une portion de texte pour afficher des corrections, des termes annulés ou des prix précédents sans supprimer le texte original. Définissez-le sur [TextStrikethroughType.Single ou Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) pour une ou deux lignes traversant le texte.

Pour supprimer le barré, passez [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Cela désactive explicitement l'effet, même si le formatage environnant spécifie le barré. En revanche, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) laisse le réglage local non défini, permettant à la portion d'hériter du formatage, par exemple depuis le paragraphe. Cela ne garantit pas que le barré soit supprimé. Utilisez [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) pour lire le formatage résultant, y compris les valeurs héritées.

L'exemple autonome suivant crée trois comparaisons de prix. Chaque paragraphe possède des portions distinctes pour l’étiquette, le prix précédent et le prix actuel, de sorte que seul le prix précédent est affecté. La première rangée applique puis supprime le barré ; les autres rangées conservent le barré simple et double. Modifier ce réglage préserve le texte et son autre formatage, y compris le prix précédent en gras.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Appliquer le barré, puis le supprimer explicitement du premier prix précédent.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat, de haut en bas : pas de barré, barré simple et barré double.

![Prix précédents sans barré, avec barré simple et avec barré double](strikethrough.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme sur [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

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

## **Afficher les chiffres côte à côte dans du texte vertical**

Pour garder un nombre à deux chiffres groupé dans une étiquette japonaise verticale, placez les deux chiffres dans une même portion de texte et appelez [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) sur cette portion. L'exemple utilise [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) et la police MS Gothic 40 points pour les deux étiquettes. Seule la valeur [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) transmise à la portion numérique diffère.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dans PowerPoint, l'étiquette de gauche (`True`) montre les chiffres droits et côte à côte entre 和 et 年. Dans l'étiquette de droite (`False`), la paire est tournée de 90 degrés dans le sens des aiguilles d'une montre. Les caractères japonais environnants restent droits dans les deux étiquettes.

![Comparaison PowerPoint d'étiquettes de date verticales avec chiffres droits à gauche et chiffres tournés à droite.](vertical_date.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

L'exemple de code ci‑dessous tourne le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

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

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides fournit [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) et [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple suivant définit l'espacement à l'intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

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

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Contrôler le saut de ligne**

Les règles de saut de ligne de paragraphe sont utiles dans des blocs de texte étroits et des présentations qui mélangent du texte latin et est‑asiatique. Les méthodes suivantes appartiennent à [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), elles s'appliquent donc à un paragraphe complet :

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) contrôle les règles de saut de ligne latines. Dans un texte mixte, le modifier peut également changer l'endroit où le texte est‑asiatique adjacent et la ponctuation sont renvoyés à la ligne.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) contrôle les règles de saut de ligne est‑asiatiques, y compris les restrictions sur les caractères au début et à la fin d'une ligne.

Ces règles ne remplacent pas [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), qui active le retour à la ligne automatique à l'intérieur d'un cadre de texte. Elles influencent la mise en page lorsque le retour à la ligne se produit ; elles n'insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L'exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit explicitement les deux options de saut de ligne et enregistre "line_breaking.pptx". Pour expérimenter avec l'une ou l'autre règle, modifiez la valeur correspondante tout en maintenant les autres réglages fixes. L'exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et des marges horizontales du cadre de texte à zéro. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) est appelé avec [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler la ponctuation suspendue**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte plutôt que d'occuper la ligne suivante. Elle s'applique à l'ensemble du paragraphe et diffère d'un retrait suspendu.

L'exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 points de large et enregistre "hanging_punctuation.pptx". Avec Arial 24 points et des marges horizontales du cadre de texte à zéro, le point final reste après "sentence" et dépasse le bord droit du texte. Définissez la propriété sur [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) pour comparer : avec ces réglages, le point occupe une ligne séparée. Le retour à la ligne est activé et l'ajustement automatique désactivé afin de garder la largeur disponible fixe.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Les [conditions de police et de mise en page décrites ci‑dessus](#control-line-breaking) s'appliquent également à cette comparaison : changer la police, la largeur disponible, les marges ou les réglages d'ajustement automatique peut supprimer la différence visible.

## **Définir le type d'ajustement automatique pour les cadres de texte**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, dépasse ou redimensionne automatiquement la forme. L'exemple suivant configure la forme pour qu'elle redimensionne afin de s'adapter à son texte et enregistre le résultat sous "autofit_type.pptx".

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

Pour compter les lignes après le retour à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Compter les lignes rendues](/slides/fr/java/manage-paragraph/). Le simple nombre de lignes n'indique pas si le texte dépasse son conteneur.

## **Définir l'ancrage des cadres de texte**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au centre ou en bas. L'exemple suivant ancre le texte en bas de la première forme et enregistre le résultat sous "text_anchor.pptx".

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

Utilisez [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) et [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) pour configurer les tabulations dans un paragraphe. L'exemple suivant fixe l'intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces réglages affectent le texte contenant des caractères de tabulation.

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

Les tabulations du paragraphe :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), qui vous permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications d'orthographe et de grammaire dans PowerPoint.

L'exemple suivant nécessite "presentation.pptx" avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par "1。", définit SimSun comme police, et assigne la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat sous "proofing_language.pptx" :

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

    // Définir l'ID d'une langue de vérification.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copier les métadonnées de langue**

Lors de la copie de texte multilingue depuis un modèle, conservez à la fois [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) et [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). L'exemple autonome suivant crée une portion source avec l'anglais américain comme langue et le français comme langue alternative, puis copie le texte et les identifiants vers une portion d'une nouvelle présentation.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Si la source n'a pas de langue alternative, null efface la valeur de destination.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour essayer une source sans langue alternative, omettez l'affectation de "fr-FR". L'identifiant alternatif sera alors `null`, et la même instruction de copie conserve son absence sans introduire de valeur par défaut, même si la destination avait auparavant une langue alternative assignée.

Ces identifiants sont des métadonnées de langue. Les conserver ne détermine pas quel dictionnaire PowerPoint utilise pour l'orthographe ou la grammaire.

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation. L'exemple suivant crée une présentation avec l'anglais américain comme langue texte par défaut, ajoute une zone de texte, et affiche `en-US` pour sa première portion de texte.

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

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

L'exemple suivant définit une police en gras de 14 points comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l'enregistre sous "default_text_style.pptx". Le texte peut hériter de ces valeurs par défaut à moins qu'un formatage plus spécifique ne les remplace.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Récupérer le format de paragraphe du niveau supérieur.
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

## **Extraire le texte avec l'effet Majuscules**

Dans PowerPoint, l'application de l'effet de police **All Caps** (Majuscules) fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite "sample2.pptx" avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient "Hello, Aspose!" avec l'effet All Caps appliqué, comme indiqué ci‑dessous.

![L'effet Majuscules](all_caps_effect.png)

L'exemple de code ci‑dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier du texte dans un tableau sur une diapositive ?**

Pour modifier du texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) et le formatage des paragraphes via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Comment appliquer une couleur dégradée au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Définissez [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) sur [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.

Fonctionnalité connexe : [Formater le texte dans les diapositives](/slides/fr/features/text-formatting/).