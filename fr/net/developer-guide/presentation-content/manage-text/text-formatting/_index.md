---
title: Formatage du texte
linktitle: Formatage du texte
type: docs
weight: 50
url: /fr/net/text-formatting/
keywords:
- surligner du texte
- expression régulière
- aligner des paragraphes de texte
- transparence du texte
- propriétés de police de paragraphe
- famille de polices
- rotation du texte
- rotation d'angle personnalisé
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancre du cadre de texte
- tabulation de texte
- style de texte par défaut
- C#
- Aspose.Slides pour .NET
description: "Gérer et manipuler les propriétés de texte et de cadre de texte en C#"
---

## Aperçu

Cet article décrit comment **travailler avec le formatage du texte des présentations PowerPoint en C#**, par exemple pour surligner du texte, appliquer une expression régulière, aligner des paragraphes de texte, définir la transparence du texte, changer les propriétés de police des paragraphes, utiliser des familles de polices, définir une rotation de texte, personnaliser une rotation d'angle, gérer un cadre de texte, définir un interligne, utiliser la propriété d'ajustement automatique, définir une ancre de cadre de texte et changer la tabulation du texte. L'article couvre ces sujets.

## **Surligner du texte**
Une nouvelle méthode HighlightText a été ajoutée à l'interface ITextFrame et à la classe TextFrame.

Elle permet de surligner une partie du texte avec une couleur d'arrière-plan en utilisant un échantillon de texte, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec le fichier d'entrée.
   - Le fichier d'entrée peut être PPT, PPTX, ODP, etc.
3. Accédez à sa diapositive en utilisant la collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
4. Accédez à la forme en utilisant la collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) comme [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Surlignez le texte en utilisant la méthode [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext).
6. Enregistrez la présentation dans le format de sortie désiré, c'est-à-dire PPT, PPTX ou ODP, etc.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // surligner tous les mots 'important'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // surligner toutes les occurrences séparées 'the'
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose propose un service de [édition PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Surligner du texte en utilisant une expression régulière**
Une nouvelle méthode HighlightRegex a été ajoutée à l'interface ITextFrame et à la classe TextFrame.

Elle permet de surligner une partie du texte avec une couleur d'arrière-plan en utilisant regex, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

Le code snippet ci-dessous montre comment utiliser cette fonctionnalité :

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // surligner tous les mots de 10 symboles ou plus
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **Définir la couleur d'arrière-plan du texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code C# vous montre comment définir la couleur d'arrière-plan pour un texte entier : 

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Noir");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rouge ");
    
    var portion3 = new Portion("Noir");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

Ce code C# vous montre comment définir la couleur d'arrière-plan pour uniquement une partie d'un texte :

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Noir");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rouge ");
    
    var portion3 = new Portion("Noir");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Rouge"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **Aligner les paragraphes de texte**

Le formatage du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides pour .NET prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous allons voir comment nous pouvons contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de l'espace réservé présentes dans la diapositive et casttez-les en AutoShape.
4. Obtenez le paragraphe (qui doit être aligné) à partir du TextFrame exposé par AutoShape.
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, au centre ou justifié.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```c#
// Instancier un objet Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Accéder à la première diapositive
    ISlide slide = pres.Slides[0];

    // Accéder aux premier et deuxième espaces réservés dans la diapositive et les castter en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Modifier le texte dans les deux espaces réservés
    tf1.Text = "Alignement au centre par Aspose";
    tf2.Text = "Alignement au centre par Aspose";

    // Obtenir le premier paragraphe des espaces réservés
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Aligner le paragraphe de texte au centre
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // Écrire la présentation sous forme de fichier PPTX
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **Définir la transparence du texte**
Cet article démontre comment définir la propriété de transparence sur toute forme de texte en utilisant Aspose.Slides pour .NET. Pour définir la transparence sur le texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive.
3. Définir la couleur d'ombre.
4. Écrivez la présentation sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - transparence est : {((float)shadowColor.A / byte.MaxValue) * 100}");

    // définir la transparence à zéro pour cent
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Définir l'espacement des caractères pour le texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans un champ de texte. De cette manière, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en comprimant l'espacement entre les caractères.

Ce code C# vous montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // élargir
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // condenser

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Gérer les propriétés de police des paragraphes**

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour .NET pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d'un paragraphe en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de l'espace réservé dans la diapositive et casttez-les en AutoShape.
4. Obtenez le paragraphe à partir du TextFrame exposé par AutoShape.
5. Justifiez le paragraphe.
6. Accédez à la portion de texte d'un paragraphe.
7. Définissez la police à l'aide de FontData et définissez la police de la portion de texte en conséquence.
   1. Définissez la police en gras.
   1. Définissez la police en italique.
8. Définissez la couleur de la police à l'aide du FillFormat exposé par l'objet Portion.
9. Écrivez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation sans embellissement et formate les polices sur l'une des diapositives.

```c#
// Instancier un objet Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Accéder à une diapositive en utilisant sa position dans les diapositives
    ISlide slide = pres.Slides[0];

    // Accéder aux premier et deuxième espaces réservés dans la diapositive et les castter en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Accéder au premier paragraphe
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Accéder à la première portion
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Définir de nouvelles polices
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Assigner les nouvelles polices à la portion
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Définir la police en gras
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Définir la police en italique
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Définir la couleur de police
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // Écrire le PPTX sur le disque
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Gérer la famille de polices de texte**
Une Portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour .NET pour créer une zone de texte avec du texte et ensuite définir une police particulière, ainsi que diverses autres propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un AutoShape de type Rectangle à la diapositive.
4. Supprimez le style de remplissage associé à l'AutoShape.
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé au TextFrame.
8. Définissez la police à utiliser pour la Portion.
9. Définissez d'autres propriétés de police comme le gras, l'italique, le soulignement, la couleur et la hauteur à l'aide des propriétés pertinentes exposées par l'objet Portion.
10. Écrivez la présentation modifiée sous forme de fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```c#
// Instancier Presentation
using (Presentation presentation = new Presentation())
{
   
    // Obtenir la première diapositive
    ISlide sld = presentation.Slides[0];

    // Ajouter un AutoShape de type Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Supprimer tout style de remplissage associé à l'AutoShape
    ashp.FillFormat.FillType = FillType.NoFill;

    // Accéder au TextFrame associé à l'AutoShape
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // Accéder à la Portion associée au TextFrame
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Définir la police pour la Portion
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Définir la propriété Gras de la police
    port.PortionFormat.FontBold = NullableBool.True;

    // Définir la propriété Italique de la police
    port.PortionFormat.FontItalic = NullableBool.True;

    // Définir la propriété Souligner de la police
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Définir la hauteur de la police
    port.PortionFormat.FontHeight = 25;

    // Définir la couleur de la police
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Écrire le PPTX sur le disque 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **Définir la taille de police pour le texte**

Aspose.Slides vous permet de choisir votre taille de police préférée pour le texte existant dans un paragraphe et d'autres textes qui pourraient être ajoutés au paragraphe plus tard.

Ce code C# vous montre comment définir la taille de police pour des textes contenus dans un paragraphe :

```c#
var presentation = new Presentation("example.pptx");

// Obtient la première forme, par exemple.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // Obtient le premier paragraphe, par exemple.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Définit la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe. 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // Définit la taille de police à 20 pt pour les portions de texte actuelles dans le paragraphe. 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Définir la rotation du texte**

Aspose.Slides pour .NET permet aux développeurs de faire pivoter le texte. Le texte peut être défini pour apparaître comme Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical ou WordArtVerticalRightToLeft. Pour faire pivoter le texte de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la première diapositive.
3. Ajoutez une forme à la diapositive.
4. Accédez au TextFrame.
5. Faites pivoter le texte.
6. Enregistrez le fichier sur le disque.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtenir la première diapositive 
ISlide slide = presentation.Slides[0];

// Ajouter un AutoShape de type Rectangle
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Ajouter un TextFrame au Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accéder au cadre de texte
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// Créer l'objet Paragraph pour le cadre de texte
IParagraph para = txtFrame.Paragraphs[0];

// Créer l'objet Portion pour le paragraphe
IPortion portion = para.Portions[0];
portion.Text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Enregistrer la présentation
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **Définir un angle de rotation personnalisé pour le TextFrame**
Aspose.Slides pour .NET prend désormais en charge la définition d'un angle de rotation personnalisé pour le cadre de texte. Dans ce sujet, nous allons voir avec un exemple comment définir la propriété RotationAngle dans Aspose.Slides. La nouvelle propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat, permettant de définir l'angle de rotation personnalisé pour le cadre de texte. Pour définir la propriété RotationAngle, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Ajoutez un graphique sur la diapositive.
3. Définissez la propriété RotationAngle.
4. Écrivez la présentation sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous définissons la propriété RotationAngle.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Titre personnalisé").TextFrameFormat.RotationAngle = -30;

// Enregistrer la présentation
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Interligne d'un paragraphe**
Aspose.Slides fournit des propriétés ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore), et [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) sous la classe [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) qui vous permettent de gérer l'interligne d'un paragraphe. Les trois propriétés sont utilisées de cette manière :

* Pour spécifier l'interligne d'un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'interligne d'un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16pt pour un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment vous spécifiez l'interligne pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte à l'intérieur.
2. Obtenez la référence d'une diapositive via son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code C# vous montre comment spécifier l'interligne pour un paragraphe :

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Obtenir la référence d'une diapositive par son index
ISlide sld = presentation.Slides[0];

// Accéder au TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Accéder au Paragraphe
IParagraph para1 = tf1.Paragraphs[0];

// Définir les propriétés du Paragraphe
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Enregistrer la présentation
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **Définir la propriété AutofitType pour le TextFrame**
Dans ce sujet, nous allons explorer les différentes propriétés de formatage du cadre de texte. Cet article couvre comment définir la propriété AutofitType du cadre de texte, l'ancre du texte et la rotation du texte dans la présentation. Aspose.Slides pour .NET permet aux développeurs de définir la propriété AutofitType de tout cadre de texte. AutofitType peut être défini sur Normal ou Shape. S'il est défini sur Normal, alors la forme restera la même tandis que le texte sera ajusté sans que la forme elle-même ne change, tandis que si AutofitType est défini sur shape, alors la forme sera modifiée pour que seul le texte requis soit contenu à l'intérieur. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez le type Autofit du TextFrame.
6. Enregistrez le fichier sur disque.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Accéder à la première diapositive 
ISlide slide = presentation.Slides[0];

// Ajouter un AutoShape de type Rectangle
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Ajouter un TextFrame au Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accéder au cadre de texte
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Créer l'objet Paragraph pour le cadre de texte
IParagraph para = txtFrame.Paragraphs[0];

// Créer l'objet Portion pour le paragraphe
IPortion portion = para.Portions[0];
portion.Text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Enregistrer la présentation
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **Définir l'ancre du TextFrame**
Aspose.Slides pour .NET permet aux développeurs de définir l'ancre de tout TextFrame. TextAnchorType spécifie où le texte est placé dans la forme. TextAnchorType peut être défini sur Top, Center, Bottom, Justified ou Distributed. Pour définir l'ancre de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez au TextFrame.
5. Définissez le TextAnchorType du TextFrame.
6. Enregistrez le fichier sur disque.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtenir la première diapositive 
ISlide slide = presentation.Slides[0];

// Ajouter un AutoShape de type Rectangle
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Ajouter un TextFrame au Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accéder au cadre de texte
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Créer l'objet Paragraph pour le cadre de texte
IParagraph para = txtFrame.Paragraphs[0];

// Créer l'objet Portion pour le paragraphe
IPortion portion = para.Portions[0];
portion.Text = "Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Enregistrer la présentation
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Définir la tabulation de texte**
- EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égal à Tabs.Count.
- La collection EffectiveTabs inclut toutes les tabulations (de la collection Tabs et des tabulations par défaut).
- EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égal à Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) montre la distance entre les tabulations par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra la première tabulation explicite (Position = 731), index = 1 - la deuxième tabulation (Position = 1241). Si vous essayez d'obtenir la tabulation suivante avec index = 2, cela renverra la première tabulation par défaut (Position = 1470), etc.
- EffectiveTabs.GetTabAfterPosition(pos) est utilisé pour obtenir la prochaine tabulation après un certain texte. Par exemple, vous avez le texte : "Helloworld !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "world !". Au départ, vous devez calculer la longueur de "Hello" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la prochaine position de tabulation pour dessiner "world !".

## **Définir la langue de vérification**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) pour vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue pour laquelle les orthographes et la grammaire dans PowerPoint sont vérifiées.

Ce code C# vous montre comment définir la langue de vérification pour un PowerPoint :

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // définir l'Id d'une langue de vérification
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Définir la langue par défaut**

Ce code C# vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint : 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Ajoute une nouvelle forme rectangulaire avec du texte
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Nouveau texte";
    
    // Vérifie la langue de la première portion
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **Définir le style de texte par défaut**

Si vous avez besoin d'appliquer le même formatage de texte par défaut à tous les éléments de texte d'une présentation en une seule fois, vous pouvez utiliser la propriété `DefaultTextStyle` de l'interface [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) et définir le formatage préféré. L'exemple de code ci-dessous montre comment définir la police en gras par défaut (14 pt) pour le texte sur toutes les diapositives d'une nouvelle présentation.

```c#
using (Presentation presentation = new Presentation())
{
    // Obtenir le format de paragraphe de niveau supérieur.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```