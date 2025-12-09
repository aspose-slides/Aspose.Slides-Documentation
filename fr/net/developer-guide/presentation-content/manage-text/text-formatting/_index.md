---
title: Formatage du texte de présentation en .NET
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/net/text-formatting/
keywords:
- mise en évidence du texte
- expression régulière
- alignement du paragraphe
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
- ancre du cadre de texte
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

## **Aperçu**

Cet article présente comment gérer et mettre en forme du texte dans des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides for .NET. Vous apprendrez à appliquer des fonctions de mise en forme du texte telles que la sélection de police, la taille, la couleur, la mise en surbrillance, la couleur d’arrière‑plan, l’interligne et l’alignement. De plus, il couvre le travail avec les cadres de texte, les paragraphes, la mise en forme et les options avancées de mise en page comme la rotation personnalisée et les comportements d’ajustement automatique.

Que vous génériez des présentations de façon programmatique ou que vous personnalisiez du contenu existant, ces exemples vous aideront à créer des mises en page de texte claires et professionnelles qui améliorent vos diapositives et en augmentent la lisibilité.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé **« sample.pptx »**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Exemple de texte](sample_text.png)

## **Mettre en surbrillance du texte**

La méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) vous permet de mettre en surbrillance une portion de texte avec une couleur d’arrière‑plan basée sur un échantillon de texte correspondant.

Pour utiliser cette méthode, suivez les étapes suivantes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec un fichier d’entrée (PPT, PPTX, ODP, etc.).
2. Accédez à la diapositive souhaitée via la collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. Accédez à la forme cible depuis la collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) et castiez‑la en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Mettez en surbrillance le texte souhaité à l’aide de la méthode [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) en fournissant l’échantillon de texte et la couleur.
5. Enregistrez la présentation dans le format de sortie désiré (par ex., PPT, PPTX, ODP).

L’exemple de code ci‑dessous met en surbrillance toutes les occurrences des caractères **« try »** et du mot complet **« to »**.  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Obtenez la première forme de la première diapositive.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Mettez en surbrillance le mot "try" dans la forme.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Mettez en surbrillance le mot "to" dans la forme.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le texte mis en surbrillance](highlighted_text.png)

{{% alert color="primary" %}} 

Aspose propose un éditeur PowerPoint en ligne **gratuit** : [FREE Online PowerPoint Editor](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Mettre en surbrillance du texte avec des expressions régulières**

Aspose.Slides for .NET vous permet de rechercher et de mettre en surbrillance des parties spécifiques du texte dans les diapositives PowerPoint en utilisant des expressions régulières. Cette fonctionnalité est particulièrement utile lorsque vous devez souligner dynamiquement des mots‑clés, des modèles ou du contenu généré à partir de données. La méthode [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) vous permet de mettre en surbrillance des fragments de texte avec une couleur d’arrière‑plan à l’aide d’une expression régulière.

L’exemple de code ci‑dessus met en surbrillance tous les mots contenant **sept caractères ou plus** :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Mettre en surbrillance tous les mots contenant sept caractères ou plus.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le texte mis en surbrillance avec l’expression régulière](highlighted_text_using_regex.png)

## **Définir la couleur d’arrière‑plan du texte**

Aspose.Slides for .NET vous permet d’appliquer des couleurs d’arrière‑plan à des paragraphes entiers ou à des portions de texte individuelles dans les diapositives PowerPoint. Cette fonctionnalité est utile lorsque vous souhaitez mettre en évidence des mots ou des phrases spécifiques, attirer l’attention sur des messages clés ou améliorer l’aspect visuel de vos présentations.

L’exemple de code suivant montre comment définir la couleur d’arrière‑plan pour le **paragraphe entier** :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir la couleur de surbrillance pour l'ensemble du paragraphe.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour des **portions de texte en gras** :  
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

![Les portions de texte grisées](gray_text_portions.png)

## **Aligner les paragraphes de texte**

L’alignement du texte est un aspect clé du formatage des diapositives qui influence à la fois la lisibilité et l’esthétique. Dans Aspose.Slides for .NET, vous pouvez contrôler précisément l’alignement des paragraphes au sein des cadres de texte, garantissant que votre contenu soit présenté de façon cohérente—centré, aligné à gauche, à droite ou justifié. Cette section explique comment appliquer et personnaliser l’alignement du texte dans vos présentations PowerPoint.

L’exemple de code suivant montre comment aligner le paragraphe au **centre** :  
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

Ajuster la transparence du texte vous permet de créer des effets visuels subtils et d’améliorer l’esthétique des diapositives. Aspose.Slides for .NET offre la possibilité de définir le niveau de transparence des paragraphes et des portions de texte, facilitant ainsi la superposition du texte sur les arrière‑plans ou la mise en avant d’éléments spécifiques. Cette section montre comment appliquer des paramètres de transparence au texte de vos présentations.

L’exemple de code ci‑dessous montre comment appliquer la transparence au **paragraphe entier** :  
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définir la couleur de remplissage du texte sur une couleur transparente.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :  
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

## **Définir l’espacement des caractères du texte**

Aspose.Slides vous permet de régler l’espacement entre les lettres dans une zone de texte. Cela vous permet d’ajuster la densité visuelle d’une ligne ou d’un bloc de texte en élargissant ou en resserrant l’espace entre les caractères.

Le code C# suivant montre comment élargir l’espacement des caractères dans le **paragraphe entier** :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Note : utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment élargir l’espacement des caractères dans des **portions de texte en gras** :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Remarque : utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.PortionFormat.Spacing = 3;  // Étendre l'espacement des caractères.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

## **Gérer les propriétés de police du texte**

Aspose.Slides for .NET vous permet d’ajuster finement les paramètres de police au niveau du paragraphe et pour chaque portion de texte, assurant la cohérence visuelle et répondant aux exigences de conception de votre présentation. Vous pouvez définir les styles de police, les tailles et d’autres options de mise en forme pour des paragraphes entiers, ce qui vous donne un contrôle accru sur l’apparence du texte. Cette section montre comment gérer les propriétés de police pour les paragraphes de texte d’une diapositive.

Le code suivant définit la police et le style de texte pour le **paragraphe entier** : il applique la taille de police, le gras, l’italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.  
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

![Propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :  
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

![Propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Faire pivoter le texte peut améliorer la mise en page de vos diapositives et aider à mettre en avant un contenu spécifique. Avec Aspose.Slides for .NET, vous pouvez facilement appliquer une rotation au texte à l’intérieur des formes, en ajustant l’angle selon votre conception. Cette section montre comment définir et contrôler la rotation du texte pour obtenir l’effet visuel souhaité.

Le code suivant définit l’orientation du texte dans la forme à `Vertical270`, ce qui fait pivoter le texte de **90 ° dans le sens inverse des aiguilles d’une montre** :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Définir un angle de rotation personnalisé pour un `TextFrame` vous permet de positionner le texte à des angles précis, offrant ainsi des conceptions de diapositives plus créatives et flexibles. Aspose.Slides for .NET donne un contrôle complet sur la rotation des cadres de texte, facilitant l’alignement du texte avec d’autres éléments de la diapositive. Cette section vous guide dans l’application d’un angle de rotation spécifique à un `TextFrame`.

Le code suivant fait pivoter le cadre de texte de **3 ° dans le sens horaire** à l’intérieur de la forme :  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides propose les propriétés `SpaceAfter`, `SpaceBefore` et `SpaceWithin` dans la classe [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), permettant de gérer l’interligne d’un paragraphe. Ces propriétés s’utilisent de la façon suivante :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

Le code suivant montre comment spécifier l’interligne à l’intérieur du paragraphe :  
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

![Interligne du paragraphe](line_spacing.png)

## **Définir le type d’ajustement automatique pour les cadres de texte**

La propriété `AutofitType` détermine le comportement du texte lorsqu’il dépasse les limites de son conteneur. Aspose.Slides for .NET vous permet de contrôler si le texte doit se réduire, dépasser ou redimensionner automatiquement la forme. Cette section montre comment définir le `AutofitType` pour un `TextFrame` afin de gérer efficacement la mise en page du texte dans les formes.  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Définir l’ancre des cadres de texte**

L’ancrage définit la position verticale du texte à l’intérieur d’une forme. Avec Aspose.Slides for .NET, vous pouvez définir le type d’ancre d’un `TextFrame` pour aligner le texte en haut, au centre ou en bas de la forme. Cette section montre comment ajuster les paramètres d’ancrage pour obtenir l’alignement vertical souhaité du contenu texte.  
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Définir la tabulation du texte**

La tabulation aide à organiser le texte en dispositions bien structurées en ajoutant un espacement cohérent entre les éléments de contenu. Aspose.Slides for .NET prend en charge la définition d’arrêts de tabulation personnalisés au sein des paragraphes de texte, permettant un contrôle précis du positionnement du texte. Cette section montre comment configurer la tabulation du texte pour améliorer l’alignement et la mise en forme.  
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

![Tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification orthographique**

Aspose.Slides fournit la propriété `LanguageId` de la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), qui vous permet de définir la langue de vérification orthographique d’un document PowerPoint. La langue de vérification détermine la langue utilisée pour les contrôles d’orthographe et de grammaire dans PowerPoint.

Le code suivant montre comment définir la langue de vérification pour une portion de texte :  
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

    // Définir l'Id d'une langue de verification orthographique.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **Définir la langue par défaut**

Spécifier la langue par défaut du texte assure une correction orthographique, une césure et un comportement de synthèse vocale corrects dans PowerPoint. Aspose.Slides for .NET vous permet de définir la langue au niveau de la portion de texte ou du paragraphe. Cette section montre comment définir la langue par défaut pour le texte de votre présentation.  
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

Si vous devez appliquer le même formatage texte par défaut à tous les éléments texte d’une présentation en une seule fois, vous pouvez utiliser la propriété `DefaultTextStyle` de l’interface [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) et définir le formatage souhaité.

Le code suivant montre comment définir une police par défaut en gras avec une taille de 14 pt pour tout le texte des diapositives d’une nouvelle présentation.  
```cs
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


## **Extraire du texte avec l’effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été entré. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) — si la valeur indique `All`, convertissez simplement la chaîne retournée en majuscules afin que votre sortie corresponde à ce que les utilisateurs voient sur la diapositive.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier **sample2.pptx**.

![Effet Tout en majuscules](all_caps_effect.png)

 Le code suivant montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :  
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

**Comment modifier le texte d’un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, vous devez utiliser l’objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Vous pouvez parcourir toutes les cellules du tableau et changer le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat` à l’intérieur de chaque cellule.

**Comment appliquer un dégradé de couleur au texte d’une diapositive PowerPoint ?**

Pour appliquer un dégradé de couleur au texte, utilisez la propriété `FillFormat` dans [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Définissez le `FilFormat` sur `Gradient`, où vous pouvez spécifier les couleurs de départ et de fin du dégradé, ainsi que d’autres propriétés telles que la direction et la transparence pour créer l’effet dégradé sur le texte.