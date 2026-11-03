---
title: Gérer les espaces réservés de présentation dans .NET
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/net/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d'image, de graphique et de contenu et à comprendre l'héritage des espaces réservés avec Aspose.Slides pour .NET."
---
## **Aperçu**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d’image, de graphique et d’un contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de mise en page ou d’une diapositive maître.

Aspose.Slides expose les informations d’espace réservé via la propriété [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). La propriété renvoie un objet [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) ou `null` pour une forme normale. Utilisez [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) pour déterminer ce que l’espace réservé est censé contenir.

L’interface de forme reste importante après avoir déterminé le type d’espace réservé :

- Un espace réservé vide de texte, d’image, de graphique ou de contenu est généralement représenté par un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Un espace réservé d’image rempli peut être représenté par un [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) et l’interface de forme au moment de l’exécution au lieu de supposer que chaque espace réservé est un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) décrit le rôle d’un espace réservé ; il ne garantit pas le type d’exécution de la forme. Utilisez toujours une vérification de type avant d’accéder aux membres spécifiques au texte, à l’image, au graphique, au tableau ou aux médias.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maître définit des styles réutilisables et, dans certains cas, des espaces réservés de niveau maître.
2. Une diapositive de mise en page définit la disposition utilisée par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) pour remonter d’un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `null` lorsque la forme n’a aucun espace réservé de base.

L’exemple suivant répertorie les espaces réservés sur la première diapositive et indique leurs espaces réservés de base :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme ordinaire locale n’a pas d’espace réservé de base et ne commence pas à hériter simplement parce qu’elle occupe les mêmes coordonnées.

## **Supprimer le statut d'espace réservé**

Lors de l’adaptation d’un modèle, utilisez [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) pour conserver un objet existant comme une forme ordinaire. Sa propriété [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) devient `null`, mais la forme reste dans la collection de la diapositive. En revanche, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) supprime la forme de cette collection.

L’exemple suivant nécessite `template.pptx` contenant au moins une diapositive et un espace réservé de texte non vide sur la première diapositive. Utilisez un espace réservé dont le formatage est hérité de sa mise en page ou de son maître pour voir l’effet de la suppression de cette relation. L’exemple vérifie que la même forme reste, appelle à nouveau la méthode sur la forme désormais ordinaire et enregistre le résultat.

{{% alert color="warning" title="Warning" %}}
La suppression du statut d’espace réservé ne préserve pas automatiquement les paramètres d’apparence hérités. L’exemple ci‑dessous laisse délibérément ces paramètres inchangés, de sorte que la sortie peut sembler différente. Une forme dont la position et la taille sont entièrement héritées peut avoir des coordonnées et des dimensions à zéro après l’appel et devenir invisible même si elle reste dans la collection.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Appeler la méthode sur une forme ordinaire n'a aucun effet.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Pour un espace réservé correspondant, les trois vérifications affichent `True`. Le texte reste, mais la position, la taille, la rotation, la police, l’alignement des paragraphes, les marges du cadre de texte, l’ancrage vertical, le remplissage et les paramètres de ligne hérités peuvent changer lorsque la relation d’espace réservé est supprimée. Par exemple, le formatage de titre hérité peut retomber sur le formatage de texte ordinaire. Voir [Slide Layout](/slides/fr/net/slide-layout/) pour plus d’informations sur les mises en page.

Pour préserver l’apparence prévue, capturez la position, la taille et la rotation résolues avant l’appel, et copiez les valeurs de formatage effectif requises dans des variables séparées. Récupérez ces valeurs via [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), et [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Ne comptez pas uniquement sur les objets de formatage effectif, car leurs valeurs de formatage de texte peuvent changer après la suppression de la relation. Appliquez explicitement les valeurs capturées à la forme ordinaire par la suite, y compris la famille de police, la taille, le style, la couleur, les paramètres de paragraphe, les paramètres du cadre de texte, le remplissage et la ligne utilisés par votre modèle.

La géométrie de forme héritée peut également devoir être affectée explicitement via [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Pour un espace réservé de texte rectangulaire, cela signifie affecter [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); ne restaurer que le remplissage et la ligne peut ne pas restaurer le rectangle visible. Les modèles avec des effets supplémentaires ou un formatage plus complexe nécessitent également la prise en charge de ces paramètres.

## **Modifier le texte d'un espace réservé**

Les espaces réservés de titre, titre centré, sous‑titre, corps et texte prennent normalement en charge le texte. Vérifiez la présence de [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) avant d’utiliser sa propriété [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ce modèle évite le casting des espaces réservés d’image, de graphique, de tableau ou de médias en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Il identifie également l’espace réservé par son objectif au lieu de se baser sur un indice de forme fragile.

## **Définir le texte d'invite sur une mise en page**

Le texte d’invite est l’instruction affichée en temps de conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez le texte d’invite personnalisé sur l’espace réservé de la mise en page plutôt que d’essayer de l’atteindre via la collection de formes d’une diapositive normale. Accédez à la mise en page via [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) et itérez sur [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

L’exemple suivant modifie les invites de titre et de sous‑titre sur la mise en page utilisée par la première diapositive :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Le texte d’invite n’est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d’édition comme PowerPoint. Une fois qu’un utilisateur ou un programme fournit du contenu réel, l’invite n’est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d'image**

Il y a deux cas à gérer :

- Si l’espace réservé d’image est déjà rempli et représenté par un [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), remplacez l’image via [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) et [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- S’il s’agit encore d’un espace réservé vide, ajoutez un cadre d’image aux coordonnées de l’espace réservé avec [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) et supprimez l’espace réservé vide.

L’exemple suivant prend en charge les deux cas et enregistre la présentation :

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Le remplacement créé pour un espace réservé vide est un cadre d’image local, pas un nouvel espace réservé, car [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) est en lecture seule. Il conserve la position réservée mais n’hérite plus du comportement spécifique à l’espace réservé. Si la conservation de la relation d’espace réservé est essentielle, préparez et remplissez l’espace réservé dans PowerPoint d’abord, puis mettez à jour le [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) résultant avec Aspose.Slides.

Pour la transparence d’image, le recadrage et d’autres effets spécifiques aux images, voir [Manage Picture Frames](/slides/fr/net/picture-frame/). Ces opérations appartiennent au cadre d’image ou au remplissage d’image, pas aux métadonnées de l’espace réservé.

## **Travailler avec les espaces réservés de graphiques et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Cet exemple trouve un tel graphique à la fois par le type d’espace réservé et par l’interface d’exécution, modifie son titre et enregistre le fichier :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Un espace réservé de contenu général a généralement [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, y compris graphiques, tableaux, diagrammes, images et médias. Après qu’il a été rempli, inspectez l’interface de forme réelle pour savoir ce qu’il contient. Des mises en page spécialisées peuvent également exposer [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un espace réservé vide de [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) en [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) simplement en modifiant [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) ; le type est en lecture seule. Pour remplir programmétiquement un graphique ou une zone de contenu vide, ajoutez l’objet requis aux coordonnées de l’espace réservé puis supprimez l’espace réservé vide. L’exemple suivant le fait pour un graphique :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l’espace réservé mais n’hérite pas du maître de mise en page. Utilisez les articles dédiés à la [gestion des graphiques](/slides/fr/net/powerpoint-charts/) lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : mettre à jour le texte ou le contenu image**

L’exemple de bout en bout suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d’image, vérifie les types d’espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L’exemple évite délibérément de supposer un indice de forme ou de caster chaque espace réservé vers la même interface.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qu'est-ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) pour le récupérer. Une forme locale ordinaire renvoie `null` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis-je changer tous les titres de diapositives en modifiant un espace réservé de mise en page ?**

Vous pouvez changer le formatage hérité ou le texte d’invite via une mise en page, mais le contenu réel des titres est stocké sur les diapositives normales. Pour remplacer le texte réel des titres dans toute une présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéro de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d’en‑tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du livret appropriés. Voir [Manage Presentation Header and Footer](/slides/fr/net/presentation-header-and-footer/) pour des exemples complets.