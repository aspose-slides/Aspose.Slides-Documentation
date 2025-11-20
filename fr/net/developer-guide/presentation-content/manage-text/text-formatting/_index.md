---
title: Formater le texte PowerPoint en C#
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/net/text-formatting/
keywords:
- mise en surbrillance du texte
- expression régulière
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
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- C#
- Aspose.Slides
description: "Apprenez à formater et styliser le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Personnalisez les polices, les couleurs, l'alignement et bien plus encore avec des exemples de code C# puissants."
---

## **Vue d'ensemble**

Cet article présente comment gérer et formater le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Vous apprendrez à appliquer des fonctionnalités de formatage du texte telles que la sélection de police, la taille, la couleur, la mise en surbrillance, la couleur d'arrière‑plan, l'espacement et l'alignement. De plus, il couvre le travail avec les cadres de texte, les paragraphes, le formatage et les options de mise en page avancées comme la rotation personnalisée et les comportements d'ajustement automatique.

Que vous génériez des présentations de façon programmatique ou que vous personnalisiez du contenu existant, ces exemples vous aideront à créer des mises en page de texte claires et professionnelles qui améliorent vos diapositives et augmentent la lisibilité.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Mettre en surbrillance du texte**

La méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) permet de mettre en surbrillance une partie du texte avec une couleur d'arrière‑plan basée sur un échantillon de texte correspondant.

Pour utiliser cette méthode, suivez les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec un fichier d'entrée (PPT, PPTX, ODP, etc.).
1. Accéder à la diapositive souhaitée à l'aide de la collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
1. Accéder à la forme cible depuis la collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) et la convertir en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Mettre en surbrillance le texte souhaité en utilisant la méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) en fournissant le texte d'échantillon et la couleur.
1. Enregistrer la présentation dans le format de sortie souhaité (par ex., PPT, PPTX, ODP).

L'exemple de code ci‑dessus met en surbrillance toutes les occurrences des caractères **"try"** et du mot complet **"to"**.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Récupérer la première forme de la première diapositive.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Mettre en surbrillance le mot "try" dans la forme.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Mettre en surbrillance le mot "to" dans la forme.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le texte mis en surbrillance](highlighted_text.png)

{{% alert color="primary" %}} 
Aspose fournit un simple [Éditeur PowerPoint en ligne GRATUIT](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Mettre en surbrillance du texte avec des expressions régulières**

Aspose.Slides pour .NET vous permet de rechercher et de mettre en surbrillance des parties spécifiques du texte dans les diapositives PowerPoint en utilisant des expressions régulières. Cette fonctionnalité est particulièrement utile lorsque vous devez mettre en évidence dynamiquement des mots‑clefs, des motifs ou du contenu basé sur les données. La méthode [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) permet de mettre en surbrillance des parties du texte avec une couleur d'arrière‑plan en utilisant une expression régulière.

L'exemple de code ci‑dessus met en surbrillance tous les mots contenant **au moins sept caractères** :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Mettre en surbrillance tous les mots de sept caractères ou plus.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le texte mis en surbrillance avec l'expression régulière](highlighted_text_using_regex.png)

## **Définir la couleur d'arrière‑plan du texte**

Aspose.Slides pour .NET vous permet d'appliquer des couleurs d'arrière‑plan à des paragraphes entiers ou à des portions de texte individuelles dans les diapositives PowerPoint. Cette fonctionnalité est utile lorsque vous souhaitez mettre en évidence des mots ou des phrases spécifiques, attirer l'attention sur des messages clés ou améliorer l'attrait visuel de vos présentations.

L'exemple de code suivant montre comment définir la couleur d'arrière‑plan pour le **paragraphe entier** :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir la couleur de surbrillance du paragraphe entier.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d'arrière‑plan pour des **portions de texte en gras** :
```cs
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

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

L'alignement du texte est un aspect clé du formatage des diapositives qui affecte à la fois la lisibilité et l'attrait visuel. Dans Aspose.Slides pour .NET, vous pouvez contrôler précisément l'alignement des paragraphes à l'intérieur des cadres de texte, garantissant que votre contenu est présenté de manière cohérente — centré, aligné à gauche, à droite ou justifié. Cette section explique comment appliquer et personnaliser l'alignement du texte dans vos présentations PowerPoint.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :
```cs
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

Modifier la transparence du texte vous permet de créer des effets visuels subtils et d'améliorer l'esthétique des diapositives. Aspose.Slides pour .NET offre la possibilité de définir le niveau de transparence des paragraphes et des portions de texte, facilitant la fusion du texte avec les arrière‑plans ou la mise en évidence d'éléments spécifiques. Cette section montre comment appliquer des paramètres de transparence au texte dans vos présentations.

L'exemple de code ci‑dessus montre comment appliquer la transparence à **l'ensemble du paragraphe** :
```cs
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

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :
```cs
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

## **Définir l'espacement des caractères du texte**

Aspose.Slides vous permet de définir l'espacement entre les lettres dans une zone de texte. Cela vous permet d'ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en resserrant l'espace entre les caractères.

Le code C# suivant montre comment élargir l'espacement des caractères dans le **paragraphe entier** :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Note : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Élargir l'espacement des caractères.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment élargir l'espacement des caractères dans des **portions de texte en gras** :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Note : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.PortionFormat.Spacing = 3;  // Élargir l'espacement des caractères.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

## **Gérer les propriétés de police du texte**

Aspose.Slides pour .NET vous permet d'ajuster finement les paramètres de police à la fois au niveau du paragraphe et pour des portions de texte individuelles, assurant la cohérence visuelle et répondant aux exigences de conception de votre présentation. Vous pouvez définir les styles de police, les tailles et d'autres options de formatage pour des paragraphes entiers, vous offrant un meilleur contrôle sur l'apparence du texte. Cette section montre comment gérer les propriétés de police pour les paragraphes de texte dans une diapositive.

Le code suivant définit la police et le style de texte pour le **paragraphe entier** : il applique la taille de police, le gras, l'italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.
```cs
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

L'exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :
```cs
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

La rotation du texte peut améliorer la mise en page de vos diapositives et aider à mettre en valeur un contenu spécifique. Avec Aspose.Slides pour .NET, vous pouvez facilement appliquer une rotation au texte à l'intérieur des formes, en ajustant l'angle pour correspondre à votre conception. Cette section montre comment définir et contrôler la rotation du texte pour obtenir l'effet visuel souhaité.

L'exemple de code suivant définit l'orientation du texte dans la forme à `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :
```cs
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

Définir un angle de rotation personnalisé pour un `TextFrame` vous permet de positionner le texte à des angles précis, offrant des conceptions de diapositives plus créatives et flexibles. Aspose.Slides pour .NET donne un contrôle complet sur la rotation des cadres de texte, facilitant l'alignement du texte avec d'autres éléments de la diapositive. Cette section vous guide dans l'application d'un angle de rotation spécifique à un `TextFrame`.

L'exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides propose les propriétés `SpaceAfter`, `SpaceBefore` et `SpaceWithin` dans la classe [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), vous permettant de gérer l'espacement des lignes d'un paragraphe. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple de code suivant montre comment spécifier l'espacement des lignes à l'intérieur du paragraphe :
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Définir le type d'ajustement automatique pour les cadres de texte**

La propriété AutoFitType détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Aspose.Slides pour .NET vous permet de contrôler si le texte doit se réduire pour s'adapter, dépasser ou redimensionner automatiquement la forme. Cette section montre comment définir le `AutofitType` d'un `TextFrame` afin de gérer efficacement la mise en page du texte à l'intérieur des formes.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Définir l'ancrage des cadres de texte**

L'ancrage définit la façon dont le texte est positionné verticalement à l'intérieur d'une forme. Avec Aspose.Slides pour .NET, vous pouvez définir le type d'ancrage d'un `TextFrame` pour aligner le texte en haut, au centre ou en bas de la forme. Cette section montre comment ajuster les paramètres d'ancrage pour obtenir l'alignement vertical souhaité du contenu texte.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Définir la tabulation du texte**

La tabulation aide à organiser le texte en mises en page bien structurées en ajoutant un espacement cohérent entre les éléments de contenu. Aspose.Slides pour .NET prend en charge la définition d'arrêts de tabulation personnalisés dans les paragraphes de texte, permettant un contrôle précis du positionnement du texte. Cette section montre comment configurer la tabulation du texte pour améliorer l'alignement et le formatage.
```cs
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

Aspose.Slides propose la propriété `LanguageId` de la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), qui vous permet de définir la langue de vérification d'un document PowerPoint. La langue de vérification détermine la langue utilisée pour les contrôles orthographiques et grammaticaux dans PowerPoint.

L'exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :
```cs
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

    // Définir l'ID d'une langue de vérification.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **Définir la langue par défaut**

Spécifier la langue par défaut pour le texte garantit un contrôle orthographique, une césure et un comportement de synthèse vocale corrects dans PowerPoint. Aspose.Slides pour .NET vous permet de définir la langue au niveau de la portion de texte ou du paragraphe. Cette section montre comment définir la langue par défaut pour le texte de votre présentation.
```cs
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

Si vous devez appliquer le même formatage de texte par défaut à tous les éléments textuels d'une présentation en une fois, vous pouvez utiliser la propriété `DefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) et définir votre formatage préféré.

L'exemple de code suivant montre comment définir une police en gras par défaut avec une taille de 14 pt pour tout le texte de toutes les diapositives dans une nouvelle présentation.
```cs
using (var presentation = new Presentation())
{
    // Obtenir le format de paragraphe du niveau supérieur.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, l'application de l'effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) — si elle indique `All`, il suffit de convertir la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que les utilisateurs voient sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dessus montre comment extraire le texte avec l'effet **All Caps** appliqué :
```cs
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

Pour modifier le texte dans un tableau sur une diapositive, vous devez utiliser l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat`.

**Comment appliquer un dégradé de couleur au texte d'une diapositive PowerPoint ?**

Pour appliquer un dégradé de couleur au texte, utilisez la propriété `FillFormat` dans [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Définissez le `FilFormat` sur `Gradient`, où vous pouvez définir les couleurs de départ et de fin du dégradé, ainsi que d'autres propriétés telles que la direction et la transparence pour créer l'effet de dégradé sur le texte.