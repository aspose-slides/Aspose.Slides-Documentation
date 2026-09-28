---
title: Gérer les maîtres de diapositives de la présentation dans .NET
linktitle: Maître de diapositive
type: docs
weight: 80
url: /fr/net/slide-master/
keywords:
- maître de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs maîtres de diapositives
- comparer les maîtres de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- maître de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérer les maîtres de diapositives dans Aspose.Slides pour .NET : accéder, modifier, cloner, comparer et supprimer les maîtres de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière-plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un slide master est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for .NET prend en charge le même modèle. Une présentation peut contenir une ou plusieurs maîtres de diapositives, et chaque maître de diapositive peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas référence directement à un maître de diapositive. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à un maître de diapositive.

La hiérarchie est :

1. **Slide master** - définit la conception et le thème partagés.  
1. **Layout slide** - définit une disposition spécifique d’espaces réservés et de formatage au niveau de la mise en page.  
1. **Normal slide** - contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/). Tous les maîtres de diapositives d’une présentation sont accessibles via la collection [Presentation.Masters](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/masters/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Héritage" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un maître de diapositive et une diapositive de mise en page définissent tous deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, voir [Appliquer ou modifier les mises en page des diapositives](/slides/fr/net/slide-layout/).
{{% /alert %}}

## **Accéder aux maîtres de diapositives**

Dans PowerPoint, vous pouvez ouvrir la vue **Affichage** > **Masque des diapositives**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `Masters` pour accéder aux maîtres de diapositives :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Vous pouvez également obtenir le maître de diapositive utilisé par une diapositive normale via sa mise en page :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Ce que contient un maître de diapositives**

Un master slide est un objet de type diapositive. Il implémente [IBaseSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/), il expose donc de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page. Les membres spécifiques au maître sont listés sur la page API [IMasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/).

Les membres de maître de diapositive couramment utilisés incluent :

| Membre | But |
| --- | --- |
| `Background` | Définit l’arrière‑plan de la diapositive au niveau du maître. |
| `Shapes` | Stocke les formes placées sur le maître, comme les logos, les cadres d’image et le texte partagé. |
| `LayoutSlides` | Stocke les diapositives de mise en page qui appartiennent au maître. |
| `ThemeManager` | Fournit l’accès aux API du thème du maître. |
| `HeaderFooterManager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses mises en page enfants. |
| `GetDependingSlides` | Renvoie les diapositives normales qui dépendent du maître via leurs mises en page. |

## **Ajouter une image à un maître de diapositive**

Lorsque vous ajoutez une image à un maître de diapositive, elle apparaît sur les diapositives qui utilisent les mises en page de ce maître. C’est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier maître de diapositive :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Pour plus d’informations sur les cadres d’image, voir [Cadre d'image](/slides/fr/net/picture-frame/).

## **Contrôler la visibilité des graphiques du maître**

Utilisez [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/showmastershapes/) pour masquer les graphiques hérités du maître, tels que les logos ou formes décoratives, sans les supprimer du maître. Définissez [Slide.ShowMasterShapes](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/showmastershapes/) sur `false` pour la diapositive qui doit oublier ces graphiques et conservez‑le sur `true` pour les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un maître et deux diapositives qui utilisent la même mise en page vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d’entrée n’est requis.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

L’exemple utilise la mise en page **Blank** fournie avec une nouvelle présentation et supprime les espaces réservés initiaux de la diapositive.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son maître via [ISlide.LayoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/layoutslide/) et [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/masterslide/). La définition de la propriété sur une diapositive individuelle n’affecte que cette diapositive. La définition de [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/fr/net/aspose.slides/layoutslide/showmastershapes/) sur `false` masque les graphiques du maître pour les diapositives qui utilisent cette mise en page partagée, même si leur propre paramètre est `true`. Pour masquer les graphiques uniquement sur une diapositive, modifiez la propriété de la diapositive et laissez la mise en page partagée inchangée.

Le paramètre n’est pas pris en charge comme contrôle de visibilité sur le maître lui‑même. Sur un maître il renvoie toujours `false`, et l’assignation de `true` lève `NotSupportedException`. Appliquez‑le à une diapositive normale ou à une mise en page à la place.

### **Distinguer les graphiques de l'arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du maître | Contrôle la visibilité des formes héritées du maître sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage de l’arrière‑plan de la diapositive | Modifie la couleur, le dégradé ou l’image de l’arrière‑plan. Les graphiques du maître sont des formes distinctes et peuvent rester visibles au-dessus de cet arrière‑plan. Voir [Arrière‑plan de la présentation](/slides/fr/net/presentation-background/). |
| Supprimer une forme du maître | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce maître. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont normalement définis sur les diapositives de mise en page. Le maître de diapositive fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles dans la vue Masque des diapositives.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au maître :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Vous pouvez également mettre en forme des formes d’espace réservé déjà présentes sur un maître de diapositive. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage dégradé linéaire :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Pour plus d’options d’espace réservé et de mise en forme du texte, voir [Définir le texte d’invite dans un espace réservé](/slides/fr/net/manage-placeholder/) et [Mise en forme du texte](/slides/fr/net/text-formatting/).

## **Modifier l’arrière‑plan d’un maître de diapositive**

Un arrière‑plan de maître est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier maître de diapositive :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Pour les sujets connexes, voir [Arrière‑plan de la présentation](/slides/fr/net/presentation-background/) et [Thème de la présentation](/slides/fr/net/presentation-theme/).

## **Cloner un maître de diapositive vers une autre présentation**

Utilisez [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/addclone/) pour copier un maître de diapositive dans une autre présentation. Le maître copié peut alors être utilisé par les mises en page et les diapositives de la présentation de destination.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Si vous devez cloner des diapositives normales avec leur maître, voir [Clone Slides](/slides/fr/net/clone-slides/).

## **Ajouter plusieurs maîtres de diapositives**

Une présentation peut contenir plusieurs maîtres de diapositives. Cela est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème différents.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce maître cloné, et ajoute une nouvelle diapositive basée sur cette mise en page :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Comparer les maîtres de diapositives**

Les maîtres de diapositives peuvent être comparés avec la méthode `Equals` héritée de [IBaseSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositives, ni les valeurs dynamiques d’espaces réservés, comme la date actuelle.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Pour plus d’informations, voir [Comparer les diapositives d’une présentation](/slides/fr/net/compare-slides/).

## **Définir la vue Masque des diapositives comme vue par défaut**

Utilisez la propriété `LastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Masque des diapositives :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Pour d’autres paramètres de vue, voir [Enregistrer la présentation](/slides/fr/net/save-presentation/).

## **Supprimer les maîtres de diapositives inutilisés**

Les présentations contiennent parfois des maîtres de diapositives qui ne sont plus utilisés par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/fr/net/aspose.slides/masterslidecollection/removeunused/) pour supprimer les maîtres inutilisés de la collection `Masters` :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Vous pouvez également utiliser la méthode low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Quelle est la différence entre un maître de diapositive et une diapositive de mise en page ?**

Un maître de diapositive définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un maître de diapositive et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de mise en page, elle hérite donc à la fois de la mise en page et du maître.

**Une présentation peut-elle contenir plusieurs maîtres de diapositives ?**

Oui. Une présentation peut contenir plusieurs maîtres de diapositives. Utilisez plusieurs maîtres lorsqu’il faut des systèmes visuels ou des identités différentes pour les différentes sections.

**Dois‑je ajouter des espaces réservés à un maître de diapositive ou à une diapositive de mise en page ?**

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage commun sur le maître, puis ajoutez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis‑je supprimer un maître de diapositive qui est encore utilisé ?**

Non. Un maître de diapositive qui possède des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d’abord ces diapositives vers des mises en page sous un autre maître, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas utilisés.