---
title: Mise en forme du texte de présentation en .NET
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/net/text-formatting/
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
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument a l'aide d'Aspose.Slides pour .NET. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour .NET. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement autofit, l’ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé **sample.pptx**, qui contient une zone de texte unique sur la première diapositive avec le texte suivant :

![Texte d’exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d’expression régulière, voir [Rechercher et remplacer du texte](/slides/fr/net/search-and-replace-text/).

## **Définir la couleur d’arrière‑plan du texte**

Utilisez [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaultportionformat/) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/highlightcolor/) pour des portions de texte individuelles.

L’exemple de code suivant montre comment définir la couleur d’arrière‑plan pour le **paragraphe entier** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour les **portions de texte en gras** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Définir la couleur de surbrillance pour la portion de texte.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/alignment/) pour définir l’alignement des paragraphes à l’intérieur d’un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe au **centre** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir l'alignement du paragraphe au centre.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fillformat/). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l’échelle 0–255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence au **paragraphe entier** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir la couleur de remplissage du texte à une couleur transparente.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Définir la transparence de la portion de texte.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/spacing/) pour augmenter ou réduire l’espacement entre les caractères d’une zone de texte.

Le code C# suivant montre comment augmenter l’espacement des caractères dans le **paragraphe entier** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Augmenter l'espacement des caractères.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessus montre comment augmenter l’espacement des caractères dans les **portions de texte en gras** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.PortionFormat.Spacing = 3;  // Élargir l'espacement des caractères.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rapprocher le rendu de celui de PowerPoint dans ces situations, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/kerningminimalsize/) à une valeur nettement plus grande que la taille réelle de la police :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Ce paramètre empêche l’application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaultportionformat/) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/).

Le code suivant définit la police et le style du texte pour le **paragraphe entier** : il applique la taille de police, le gras, l’italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir les propriétés de police du paragraphe.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Définir les propriétés de police pour la portion de texte.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/textverticaltype/) pour définir une orientation de texte prédéfinie à l’intérieur d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/rotationangle/) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/).

L’exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides fournit [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spacebefore/) et [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spacewithin/) pour contrôler l’espacement des paragraphes. Ces propriétés s’utilisent comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.  
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple de code suivant montre comment spécifier l’interligne au sein du paragraphe :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![L’interligne dans le paragraphe](line_spacing.png)

## **Définir le type d’autofit pour les cadres de texte**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/autofittype/) détermine le comportement du texte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte rétrécit, déborde ou redimensionne automatiquement la forme.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Définir l’ancrage des cadres de texte**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/anchoringtype/) définit la façon dont le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au centre ou en bas.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Définir la tabulation du texte**

Utilisez [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaulttabsize/) et [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/tabs/) pour configurer les arrêts de tabulation dans un paragraphe.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/), qui permet de définir la langue de vérification orthographique et grammaticale pour une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles d’orthographe et de grammaire dans PowerPoint.

L’exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Définir l'Id d'une langue de vérification.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/defaulttextlanguage/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Ajouter une nouvelle forme rectangulaire avec du texte.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Vérifier la langue de la première portion.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/defaulttextstyle/).

L’exemple de code suivant montre comment définir une police en gras de 14 pt par défaut pour tout le texte de toutes les diapositives d’une nouvelle présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Obtenir le format de paragraphe de niveau supérieur.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Extraire le texte avec l’effet tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/net/aspose.slides/textcaptype/) et convertissez la chaîne retournée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L’effet Tout en majuscules](all_caps_effect.png)

L’exemple de code ci‑dessous montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/textframe/) et le format de paragraphe via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/paragraphformat/).

**Comment appliquer une couleur dégradée au texte dans une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fillformat/). Définissez [IFillFormat.FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformat/filltype/) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) et configurez les arrêts de dégradé, la direction et la transparence.