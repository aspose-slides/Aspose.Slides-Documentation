---
title: Formater le texte de présentation en .NET
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/net/text-formatting/
keywords:
- alignement de paragraphe
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
- .NET
- C#
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour .NET. Personnalisez les polices, les couleurs, l’alignement, et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l'aide d’Aspose.Slides pour .NET. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’espacement des paragraphes, le comportement d’ajustement automatique, l’ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte présenté ci‑dessous. Les indices de diapositive et de forme sont zéro‑based. Les exemples qui sélectionnent des portions en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d’expression régulière, voir [Search and Replace Text](/slides/fr/net/search-and-replace-text/).

## **Définir la couleur d'arrière‑plan du texte**

Utilisez [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) pour des portions de texte individuelles.

L’exemple suivant définit une surbrillance gris clair comme valeur par défaut du premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles prévalent sur cette valeur par défaut :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Définir la couleur de surbrillance pour le paragraphe entier.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour **les portions de texte avec une police en gras** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

Le résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) pour définir l’alignement du paragraphe à l’intérieur d’un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple suivant montre comment aligner le paragraphe au **centre** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Définir l'alignement du paragraphe au centre.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Aligner les polices au sein d’une ligne**

Utilisez [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) pour aligner verticalement les portions de texte de tailles de police différentes au sein d’une ligne. Ce paramètre s’applique à tout le paragraphe et contrôle l’alignement dans chacune de ses lignes.

L’exemple autonome suivant crée quatre zones de texte étiquetées sur une même diapositive. Chaque paragraphe contient le même texte en 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l’ajustement automatique et le renvoi à la ligne, et garde les cadres de texte suffisamment grands pour une seule ligne.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Le résultat :

![Comparaison des alignements de police Baseline, Top, Center et Bottom avec des tailles de police mixtes](font_alignment.png)

L’alignement de police utilise les métriques de police, de sorte que les bords visibles des lettres individuelles ne s’alignent pas forcément exactement. L’exemple inclut à la fois une lettre majuscule et un descendant pour illustrer la différence entre l’alignement sur la ligne de base et l’alignement bas. La disponibilité et le remplacement des polices, les caractères utilisés et la différence de taille de police influencent le résultat. Les dimensions du cadre, les marges, l’espacement des lignes, le renvoi à la ligne et l’ajustement automatique affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), qui contrôle l’alignement horizontal du paragraphe, et de [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), qui positionne le bloc de texte verticalement à l’intérieur de sa forme. Le formatage exposant et indice via [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) décale les portions individuelles par rapport à la ligne de base plutôt que de définir l’alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Dans les exemples ci‑dessous, `alpha = 50` correspond à une valeur de canal alpha ARGB sur l’échelle 0‑255, et non à un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence à **l’ensemble du paragraphe** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Définir un remplissage noir semi-transparent pour le texte.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple suivant montre comment appliquer la transparence à **les portions de texte avec une police en gras** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) pour élargir ou condenser l’espacement entre les caractères d’une zone de texte. Les exemples ajoutent 3 points d’espacement ; des valeurs négatives condensent le texte.

Le code C# suivant montre comment augmenter l’espacement des caractères dans **l’ensemble du paragraphe** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment augmenter l’espacement des caractères dans **les portions de texte avec une police en gras** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
        portion.PortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre la sortie rendue plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite “presentation.pptx” avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille est inférieure à 100 points :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

L’exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 pts avec du gras, de l’italique et un soulignement pointillé. Le formatage explicite sur les portions individuelles prévaudra sur ces valeurs par défaut.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Définir les propriétés de police pour le paragraphe.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple suivant applique Times New Roman 13 pts, de l’italique et un soulignement pointillé aux portions dont le formatage effectif est en gras :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Contrôler la normalisation de la hauteur du texte**

Utilisez [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) lors de la reproduction de la typographie d’un modèle ou de l’investigation de différences de hauteur de caractère. Dans PowerPoint, activer la normalisation étire ou compresse les caractères individuellement verticalement afin de leur donner une hauteur visible uniforme au sein de la portion de texte. Cela ne garantit pas des hauteurs de texte égales entre différentes polices.

Définissez la propriété sur [NullableBool.True ou False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) pour activer ou désactiver explicitement la normalisation. `NullableBool.NotDefined` laisse le paramètre local non défini afin que la portion hérite de la valeur du paragraphe, par exemple via son [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/). Cela ne signifie pas `False`. Utilisez [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) et lisez [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) pour obtenir la valeur booléenne résolue.

L’exemple autonome suivant nécessite **Arial** installé. Il crée deux blocs de texte contenant les mêmes lettres majuscules, minuscules, descendantes et caractères accentués à 54 pts. Les deux paragraphes activent la normalisation par défaut. La portion du haut la désactive explicitement ; celle du bas l’hérite. Les tailles de cadre, les marges et l’espacement des paragraphes sont identiques, le renvoi à la ligne et l’ajustement automatique sont désactivés pour garantir une comparaison cohérente. L’exemple affiche `False: False` et `NotDefined: True`, puis enregistre “text_height_normalization.pptx”.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

La comparaison ci‑dessous a été exportée depuis la présentation enregistrée. La ligne du haut a la normalisation désactivée (`False`) ; la ligne du bas l’hérite (`NotDefined` → `True`). Gardez Arial installé pour reproduire cet aspect.

![Texte Arial 54 pts avec normalisation désactivée en haut et normalisation hérité activée en bas](text_height_normalization.png)

La normalisation modifie la hauteur du caractère sans changer la valeur [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) assignée, qui indique la taille de la police en points. Le [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) du paragraphe contrôle l’espacement des lignes, tandis que l’[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) du cadre de texte contrôle comment le texte ou son conteneur s’ajuste. Ces paramètres servent à des fins différentes et peuvent influencer la mise en page globale indépendamment. Pour plus d’informations sur le formatage des paragraphes et l’héritage, voir [Manage Paragraph](/slides/fr/net/manage-paragraph/).

## **Appliquer et supprimer le texte barré**

Utilisez [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) sur une portion de texte pour afficher des corrections, des termes annulés ou des prix antérieurs sans supprimer le texte original. Réglez-le sur [TextStrikethroughType.Single ou Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) pour une ou deux lignes traversant le texte.

Pour supprimer le texte barré, attribuez `TextStrikethroughType.None`. Cela désactive explicitement l’effet, même si le formatage environnant spécifie un texte barré. En revanche, `TextStrikethroughType.NotDefined` laisse le paramètre local indéfini, permettant à la portion d’hériter du formatage, par exemple du paragraphe. Cela ne garantit pas la suppression du texte barré. Utilisez [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) pour lire le formatage résultant, y compris les valeurs héritées.

L’exemple autonome suivant crée trois comparaisons de prix. Chaque paragraphe possède des portions distinctes pour le libellé, le prix précédent et le prix actuel, de sorte que seul le prix précédent est affecté. La première ligne applique puis supprime le texte barré ; les autres lignes conservent les textes barrés simple et double. Modifier cette propriété préserve le texte et son autre formatage, y compris le prix précédent en gras.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Appliquer le texte barré, puis le supprimer explicitement du premier prix précédent.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Le résultat, de haut en bas : aucun texte barré, texte barré simple, texte barré double.

![Prix précédents sans texte barré, avec texte barré simple et avec texte barré double](strikethrough.png)

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) pour définir une orientation de texte prédéfinie au sein d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Afficher les chiffres côte à côte dans du texte vertical**

Pour maintenir un nombre à deux chiffres ensemble dans une étiquette japonaise verticale, placez les deux chiffres dans une même portion de texte et définissez [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) sur cette portion. L’exemple utilise [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) et la police MS Gothic 40 pts pour les deux étiquettes. Seule la valeur de [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) assignée à la portion numérique diffère.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

Dans PowerPoint, l’étiquette de gauche (`True`) montre les chiffres droits et côte à côte entre 和 et 年. Dans l’étiquette de droite (`False`), la paire est pivotée de 90 degrés dans le sens des aiguilles d’une montre. Les caractères japonais environnants restent droits dans les deux cas.

![Comparaison PowerPoint des étiquettes de date verticales avec les chiffres droits à gauche et les chiffres pivotés à droite.](vertical_date.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

L’exemple de code ci‑dessous tourne le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides propose [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) et [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) pour contrôler l’espacement des paragraphes. Ces propriétés s’utilisent comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple suivant définit l’espacement à l’intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Le résultat :

![L’interligne à l’intérieur du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans des blocs de texte étroits et des présentations mêlant du texte latin et des caractères d’Asie de l’Est. Les propriétés suivantes appartiennent à [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), elles s’appliquent donc à un paragraphe entier :

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) contrôle les règles de retour à la ligne du texte latin. Dans un texte mixte, le modifier peut également changer l’endroit où le texte et la ponctuation d’Asie de l’Est adjacents sont renvoyés.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) contrôle les règles de retour à la ligne de l’Asie de l’Est, y compris les restrictions sur les caractères au début et à la fin d’une ligne.

Ces règles ne remplacent pas [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), qui active le renvoi à la ligne automatique à l’intérieur d’un cadre de texte. Elles influencent la mise en page lorsque le renvoi à la ligne se produit ; elles n’insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L’exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du texte latin. Il définit explicitement les deux propriétés de retour à la ligne et enregistre “line_breaking.pptx”. Pour expérimenter avec l’une ou l’autre règle, modifiez la valeur de cette propriété tout en maintenant l’autre réglage fixe. L’exemple utilise Arial 24 pts et SimSun avec une largeur de cadre de 160 pts et des marges horizontales du cadre de texte à zéro. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) est réglé sur [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Contrôler la ponctuation suspendue**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) permet aux signes de ponctuation admissibles de dépasser le bord droit de la ligne de texte au lieu d’occuper la ligne suivante. Cela s’applique à tout le paragraphe et diffère d’un retrait suspendu.

L’exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 pts de large et enregistre “hanging_punctuation.pptx”. Avec Arial 24 pts et des marges horizontales du cadre à zéro, le point final reste après le mot “sentence” et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) pour comparer : avec ces paramètres, le point occupe une ligne distincte. Le renvoi à la ligne est activé et l’ajustement automatique désactivé afin de garder la largeur disponible fixe.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Les [conditions de police et de mise en page décrites plus haut](#control-line-breaking) s’appliquent également à cette comparaison : modifier la police, la largeur disponible, les marges ou les paramètres d’ajustement peut supprimer la différence visible.

## **Définir le type d’ajustement automatique pour les cadres de texte**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se réduit, déborde ou redimensionne automatiquement la forme. L’exemple suivant configure la forme pour qu’elle redimensionne afin de s’ajuster à son texte et enregistre le résultat sous “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Pour compter les lignes après un renvoi à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, voir [Count Rendered Lines](/slides/fr/net/manage-paragraph/). Le nombre de lignes seul ne indique pas si le texte déborde de son conteneur.

## **Définir l’ancre des cadres de texte**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) définit comment le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au milieu ou en bas. L’exemple suivant ancre le texte en bas de la première forme et enregistre le résultat sous “text_anchor.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Définir la tabulation du texte**

Utilisez [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) et [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) pour configurer les tabulations dans un paragraphe. L’exemple suivant fixe l’intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), qui permet de définir la langue de vérification orthographique d’une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles d’orthographe et de grammaire dans PowerPoint.

L’exemple suivant nécessite “presentation.pptx” avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par “1。”, définit SimSun comme police et assigne la langue de vérification Simplifiée chinoise (`zh-CN`). Il enregistre le résultat sous “proofing_language.pptx” :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Définir la langue de vérification orthographique sur le chinois simplifié.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Copier les métadonnées de langue**

Lors de la copie de texte multilingue depuis un modèle, conservez à la fois [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) et [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). L’exemple autonome suivant crée une portion source avec l’anglais américain comme langue et le français comme langue alternative, puis copie le texte et les identifiants dans une portion d’une nouvelle présentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Si la source n'a pas de langue alternative, null efface la valeur de destination.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Pour tester une source sans langue alternative, omettez l’attribution de `"fr-FR"`. L’identifiant alternatif sera alors `null`, et la même instruction de copie préservera son absence sans introduire de valeur par défaut, même si la destination possédait déjà une langue alternative assignée.

Ces identifiants sont stockés comme métadonnées de langue. Les conserver n’établit pas la langue du dictionnaire que PowerPoint sélectionnera pour l’orthographe ou la grammaire.

## **Définir la langue par défaut**

Utilisez [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation. L’exemple suivant crée une présentation avec l’anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Ajouter une nouvelle forme rectangulaire avec du texte.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Vérifier la langue de la première portion.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

L’exemple suivant définit une police 14 pts en gras comme style par défaut pour les paragraphes de niveau supérieur d’une nouvelle présentation et l’enregistre sous “default_text_style.pptx”. Le texte peut hériter de ces valeurs par défaut, sauf si un formatage plus spécifique les dépasse.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Obtenir le format de paragraphe de niveau supérieur.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extraire le texte avec l’effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été entré. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite “sample2.pptx” avec une zone de texte comme première forme de la première diapositive. Sa première portion du premier paragraphe contient “Hello, Aspose!” avec l’effet Tout en majuscules appliqué, comme indiqué ci‑dessous.

![L’effet Tout en majuscules](all_caps_effect.png)

L’exemple de code suivant montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte d’un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) et le formatage des paragraphes via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Comment appliquer une couleur de dégradé au texte d’une diapositive PowerPoint ?**

Pour appliquer une couleur de dégradé au texte, utilisez [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Réglez [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) sur [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.

Fonctionnalité associée : [Format text within slides](/slides/fr/features/text-formatting/).