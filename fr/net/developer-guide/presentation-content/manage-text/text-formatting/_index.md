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
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci-dessous. Les indices des diapositives et des formes sont basés sur zéro. Les exemples qui sélectionnent des portions en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Recherche et remplacement de texte](/slides/fr/net/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaultportionformat/) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/highlightcolor/) pour des portions de texte individuelles.

L'exemple suivant définit une surbrillance gris clair comme valeur par défaut pour le premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles ont la priorité sur cette valeur par défaut :

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

L'exemple de code ci-dessous montre comment définir la couleur d'arrière-plan pour **les portions de texte avec une police en gras** :

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

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [IParagraphFormat.Alignment](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/alignment/) pour définir l'alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

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

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fillformat/). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0–255, et non un pourcentage de transparence.

L'exemple de code ci‑dessous montre comment appliquer la transparence au **paragraphe entier** :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Définir un remplissage noir semi‑transparent pour le texte.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

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

## **Définir l'espacement des caractères pour le texte**

Utilisez [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/spacing/) pour augmenter ou réduire l'espacement entre les caractères dans une zone de texte. Les exemples ajoutent 3 points d'espacement ; les valeurs négatives condensent le texte.

Le code C# suivant montre comment augmenter l'espacement des caractères dans le **paragraphe entier** :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment augmenter l'espacement des caractères dans les **portions de texte avec une police en gras** :

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
        // Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
        portion.PortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu soit plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/kerningminimalsize/) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » contenant une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et définit un seuil de 100 points pour les portions utilisant Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

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

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices concernées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaultportionformat/) ou sur des portions individuelles via [IPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportionformat/).

L'exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec gras, italique et soulignement pointillé. Le formatage explicite sur les portions individuelles a priorité sur ces valeurs par défaut.

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

L'exemple suivant applique Times New Roman 13 points, format italique et soulignement pointillé aux portions dont le format effectif est gras :

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

## **Définir la rotation du texte**

Utilisez [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/textverticaltype/) pour définir une orientation de texte prédéfinie dans une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fr/net/aspose.slides/textverticaltype/), ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

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

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/rotationangle/) pour définir un angle de rotation personnalisé pour un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/).

L'exemple de code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

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

![La rotation de texte personnalisée](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides fournit [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spacebefore/) et [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/spacewithin/) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple suivant définit l'espacement à l'intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

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

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans les blocs de texte étroits et les présentations qui mélangent du texte latin et asiatique. Les propriétés suivantes appartiennent à [IParagraphFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/), elles s'appliquent donc à un paragraphe entier :

- [LatinLineBreak](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/latinlinebreak/) contrôle les règles de retour à la ligne du texte latin. Dans un texte mixte, le modifier peut également changer la façon dont le texte asiatique adjacent et la ponctuation sont enveloppés.
- [EastAsianLineBreak](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/eastasianlinebreak/) contrôle les règles de retour à la ligne du texte asiatique, y compris les restrictions sur les caractères au début et à la fin d'une ligne.

Ces règles ne remplacent pas [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/wraptext/), qui active le renvoi à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le renvoi à la ligne se produit ; elles n'insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L'exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du texte latin. Il définit explicitement les deux propriétés de retour à la ligne et enregistre "line_breaking.pptx". Pour expérimenter chaque règle, modifiez la valeur de cette propriété tout en conservant les autres paramètres inchangés. L'exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et aucune marge horizontale du cadre de texte. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/autofittype/) est définie sur [TextAutofitType.None](https://reference.aspose.com/slides/fr/net/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/hangingpunctuation/) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d'occuper la ligne suivante. Elle s'applique à l'ensemble du paragraphe et diffère d'un retrait suspendu.

L'exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 points de large et enregistre "hanging_punctuation.pptx". Avec Arial 24 points et aucune marge horizontale du cadre de texte, le point final reste après "sentence" et dépasse le bord droit du texte. Définissez la propriété sur [NullableBool.False](https://reference.aspose.com/slides/fr/net/aspose.slides/nullablebool/) pour comparer : avec ces réglages, le point occupe une ligne distincte. Le renvoi à la ligne est activé et l'ajustement automatique désactivé afin de garder la largeur disponible fixe.

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

Toutes les marques de ponctuation ne peuvent pas être suspendues. Les [conditions de police et de mise en page décrites ci‑above](#conditions-and-limitations) s'appliquent également à cette comparaison : changer la police, la largeur disponible, les marges ou les paramètres d'ajustement automatique peut supprimer la différence visible.

## **Définir le type d'ajustement automatique pour les cadres de texte**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/autofittype/) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, dépasse ou redimensionne automatiquement la forme. L'exemple suivant configure la forme pour qu'elle soit redimensionnée afin de contenir son texte et enregistre le résultat dans "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Pour compter les lignes après le renvoi à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, voir [Compter les lignes rendues](/slides/fr/net/manage-paragraph/). Le nombre de lignes à lui seul n'indique pas si le texte dépasse son conteneur.

## **Définir l'ancrage des cadres de texte**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/anchoringtype/) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas. L'exemple suivant ancre le texte en bas de la première forme et enregistre le résultat dans "text_anchor.pptx".

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

Utilisez [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/defaulttabsize/) et [IParagraphFormat.Tabs](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/tabs/) pour configurer les tabulations dans un paragraphe. L'exemple suivant définit l'intervalle de tabulation par défaut à 100 points et ajoute un arrêt de tabulation aligné à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

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

Aspose.Slides fournit [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/), qui vous permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles orthographiques et grammaticaux dans PowerPoint.

L'exemple suivant nécessite "presentation.pptx" contenant une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par "1。", définit SimSun comme police et assigne la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat dans "proofing_language.pptx" :

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

// Définir la langue de vérification sur le chinois simplifié.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/defaulttextlanguage/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation. L'exemple suivant crée une présentation avec l'anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Ajouter une nouvelle forme rectangle avec du texte.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Vérifier la langue de la première portion.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/defaulttextstyle/).

L'exemple suivant définit une police en gras de 14 points comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l'enregistre dans "default_text_style.pptx". Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus spécifique les remplace.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Récupérer le format de paragraphe de niveau supérieur.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extraire le texte avec l'effet majuscules**

Dans PowerPoint, appliquer l'effet de police **All Caps** (tout en majuscules) fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/net/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite "sample2.pptx" avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient "Hello, Aspose!" avec l'effet All Caps appliqué, comme illustré ci‑dessous.

![L'effet All Caps](all_caps_effect.png)

L'exemple de code ci‑dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :

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

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/). Parcourez les cellules et mettez à jour chaque cellule via [ICell.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/icell/textframe/) et le formatage des paragraphes via [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/paragraphformat/).

**Comment appliquer une couleur dégradée au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fillformat/). Définissez [IFillFormat.FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformat/filltype/) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.