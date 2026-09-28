---
title: Formatage du texte de présentation en Java
linktitle: Formatage du texte
type: docs
weight: 50
url: /fr/java/text-formatting/
keywords:
- aligner le paragraphe
- style du texte
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
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Personnalisez les polices, les couleurs, l'alignement, et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci-dessous. Les indices des diapositives et des formes sont à base zéro. Les exemples qui sélectionnent des portions en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Recherche et remplacement de texte](/slides/fr/java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pour des portions de texte individuelles.

L'exemple suivant définit une mise en surbrillance gris clair comme valeur par défaut pour le premier paragraphe. Les couleurs de surbrillance explicites sur des portions individuelles ont priorité sur cette valeur par défaut :

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

Le résultat:

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci-dessous montre comment définir la couleur d'arrière-plan pour **les portions de texte avec une police en gras** :

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

Le résultat:

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) pour définir l'alignement des paragraphes à l'intérieur d'un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

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

Le résultat:

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0–255, et non un pourcentage de transparence.

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

    // Définir la couleur de remplissage du texte en couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat:

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

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

Le résultat:

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l'espacement des caractères du texte**

Utilisez [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) pour augmenter ou réduire l'espacement entre les caractères dans une zone de texte. Les exemples ajoutent 3 points d'espacement ; des valeurs négatives condensent le texte.

Le code Java suivant montre comment augmenter l'espacement des caractères dans le **paragraphe entier** :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat:

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
            // Remarque : utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3); // Étendre l'espacement des caractères.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat:

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu soit plus proche de PowerPoint dans de tels cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite "presentation.pptx" avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

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

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportionformat/).

L'exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec du gras, de l'italique et un soulignement pointillé. Le formatage explicite sur des portions individuelles a priorité sur ces valeurs par défaut.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Définir les propriétés de police du paragraphe.
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

Le résultat:

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L'exemple suivant applique Times New Roman 13 points, du formatage italique et un soulignement pointillé aux portions dont le formatage effectif est en gras :

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

Le résultat:

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textverticaltype/), ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

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

Le résultat:

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/).

L'exemple de code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens horaire à l'intérieur de la forme :

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

Le résultat:

![La rotation de texte personnalisée](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides fournit [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), et [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple suivant définit l'espacement à l'intérieur du premier paragraphe à 200 % de la hauteur de ligne (espacement double) :

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

Le résultat:

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans des blocs de texte étroits et les présentations qui combinent du texte latin et est-asiatique. Les méthodes suivantes appartiennent à [IParagraphFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/), elles s'appliquent donc à un paragraphe complet :

- [setLatinLineBreak](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) contrôle les règles de retour à la ligne pour le texte latin. Dans un texte mixte, le modifier peut également changer l'endroit où le texte et la ponctuation est‑asiatiques adjacents se replient.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) contrôle les règles de retour à la ligne pour le texte est‑asiatique, y compris les restrictions sur les caractères au début et à la fin d'une ligne.

Ces règles ne remplacent pas [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), qui active le retour à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le retour à la ligne se produit ; elles n'insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L'exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit explicitement les deux options de retour à la ligne et enregistre "line_breaking.pptx". Pour expérimenter avec l'une ou l'autre règle, modifiez la valeur correspondante tout en maintenant les autres paramètres fixes. L'exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et zéro marge horizontale du cadre de texte. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) est appelé avec [TextAutofitType.None](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) permet aux ponctuations admissibles de dépasser le bord droit de la ligne de texte au lieu d'occuper la ligne suivante. Elle s'applique à tout le paragraphe et diffère d'un retrait suspendu.

L'exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 points de large et enregistre "hanging_punctuation.pptx". Avec Arial 24 points et zéro marge horizontale du cadre de texte, le point final reste après "sentence" et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool.False](https://reference.aspose.com/slides/fr/java/com.aspose.slides/nullablebool/) pour comparer : avec ces paramètres, le point occupe une ligne séparée. Le renvoi à la ligne est activé et l'ajustement automatique est désactivé afin de maintenir la largeur disponible fixe.

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

Toutes les marques de ponctuation ne peuvent pas être suspendues. Le résultat visible dépend de la disponibilité de la police et de la mise en page : changer la police, la largeur disponible, les marges ou les paramètres d'ajustement automatique peut supprimer la différence visible.

## **Définir le type d'ajustement automatique pour les cadres de texte**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, dépasse ou redimensionne automatiquement la forme. L'exemple suivant configure la forme pour qu'elle redimensionne afin de s'adapter à son texte et enregistre le résultat dans "autofit_type.pptx".

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

Pour compter les lignes après le retour à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, voir [Compter les lignes rendues](/slides/fr/java/manage-paragraph/). Le nombre de lignes seul n'indique pas si le texte dépasse son conteneur.

## **Définir l'ancre des cadres de texte**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas. L'exemple suivant ancre le texte au bas de la première forme et enregistre le résultat dans "text_anchor.pptx".

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

Utilisez [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) et [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#getTabs--) pour configurer les tabulations dans un paragraphe. L'exemple suivant définit l'intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

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

Le résultat:

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides propose [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), qui permet de définir la langue de vérification d'une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L'exemple suivant nécessite "presentation.pptx" avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par "1。", définit SimSun comme police, et attribue la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat dans "proofing_language.pptx" :

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

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation. L'exemple suivant crée une présentation avec l'anglais américain comme langue de texte par défaut, ajoute une zone de texte, et affiche `en-US` pour la première portion de texte.

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

Pour appliquer le formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

L'exemple suivant définit une police en gras de 14 points comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l'enregistre sous "default_text_style.pptx". Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus spécifique les remplace.

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

## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, l'application de l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été entré. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textcaptype/) et convertissez la chaîne retournée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite "sample2.pptx" avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient "Hello, Aspose!" avec l'effet Tout en majuscules appliqué, comme illustré ci‑dessous.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dessus montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

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

Sortie:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.getTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/#getTextFrame--) et le formatage des paragraphes via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Comment appliquer une couleur dégradée au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Définissez [IFillFormat.setFillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifillformat/#setFillType-byte-) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) et configurez les points d'arrêt du dégradé, la direction et la transparence.