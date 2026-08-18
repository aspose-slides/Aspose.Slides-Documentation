---
title: Gestion des thèmes de présentation dans .NET
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/net/presentation-theme/
keywords:
- Thème PowerPoint
- Thème de présentation
- Thème de diapositive
- Définir le thème
- Modifier le thème
- Gérer le thème
- Couleur du thème
- Palette supplémentaire
- Police du thème
- Style du thème
- Effet du thème
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, polices, styles d’arrière‑plan, remplissages, lignes et effets. Les objets sensibles au thème se réfèrent à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/masterthememanager/overridetheme/), une disposition peut remplacer le thème hérité via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, remplacement du master, remplacement de la disposition et remplacement de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous présentent les flux de travail de thème les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effet, et lire les valeurs effectives après résolution des héritages et des remplacements.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/) expose le [ColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/colorscheme/), le [FontScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/fontscheme/) et le [FormatScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/formatscheme/) du thème. Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique le nombre de styles d’arrière‑plan, de remplissage, de ligne et d’effet stockés dans le thème :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsqu’il peut y avoir des remplacements de disposition ou de diapositive.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent se référer à une couleur logique de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui référencent encore cette couleur de thème sont résolus en fonction de la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint dérive des variantes plus claires et plus foncées d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/fr/net/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus foncées générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème.  

**2** - Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, et enregistre le résultat :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change ultérieurement, les couleurs transformées sont recalculées à partir de la nouvelle valeur de `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `IColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ce sont des noms alternatifs pour les mêmes emplacements de thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un jeu de polices majeur pour les titres et un jeu de polices mineur pour le texte du corps. Les propriétés [FontScheme.Major](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/major/) et [FontScheme.Minor](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/minor/) exposent ces ensembles.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Minor Latin Font)
* `+mj-lt` - Police du titre Latin (Major Latin Font)
* `+mn-ea` - Police du corps Asie de l’Est (Minor East Asian Font)
* `+mj-ea` - Police du titre Asie de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il change ensuite les polices du thème et enregistre le résultat :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème sera modifié.

{{% alert color="info" title="Conseil" %}}
Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/net/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Il existe deux flux de travail courants, qui répondent à des problèmes différents.

### **Conserver un thème source lors du déplacement de diapositives**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) et le master cloné. Cela transfère le master, ses dispositions et le thème associé ensemble.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

C’est le flux de travail recommandé lorsque la diapositive source doit apparaître de la même façon dans la destination. Simplement cloner le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez un remplacement au niveau de la diapositive depuis le thème source. Les méthodes [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois principaux composants du thème dans le remplacement.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer le remplacement local et revenir aux valeurs héritées, appelez [OverrideTheme.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/clear/).

### **Appliquer un remplacement de thème à une disposition**

Un remplacement au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède son propre remplacement. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/layoutslidethememanager/) de la disposition :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, un remplacement de disposition lorsqu’une famille de dispositions nécessite un style différent, et un remplacement de diapositive uniquement pour de véritables exceptions. Un excès de remplacements au niveau des diapositives rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint peut présenter plus d’options d’arrière‑plan dans son interface utilisateur que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et le [Background.StyleIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/background/styleindex/) actuel. `StyleIndex` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection .NET, où `[0]` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématisé au premier master, et enregistre la présentation :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Le résultat visible dépend de l’entrée de thème référencée par le master et de tout remplacement d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/background/geteffective/) lorsque vous devez connaître l’arrière‑plan final après l’application de l’héritage.

{{% alert color="warning" title="Avertissement" %}}
Ne traitez pas `StyleIndex` comme un indice de collection basé sur zéro. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il a le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Conseil" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/net/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format de thème contient des collections distinctes de [FillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/fillstyles/), de [LineStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/linestyles/) et d’[EffectStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à un formatage subtil, modéré et intense, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en C#, l’indice de la collection commence à zéro : `[0]` est le premier style stocké et `[2]` le troisième. Les indices de référence de style d’une forme constituent un concept séparé, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre externe dans le troisième style d’effet, et enregistre le résultat :

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet obtient une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style que chaque forme référence et du fait que le formatage direct puisse écraser le thème.

![Styles d’effet du thème après modification des réglages de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des remplacements locaux. Pour une diapositive, appelez [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pour un arrière‑plan, utilisez [Background.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/background/geteffective/), et pour un remplissage, utilisez [FillFormat.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/geteffective/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/), vous pouvez manquer un master, une disposition, une diapositive ou un remplacement de forme qui modifie l’apparence finale.

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans modifier le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/slidethememanager/) de la diapositive et initialisez son thème de remplacement. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes actuels.

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

Lorsque vous déplacez une diapositive tout en conservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master en utilisant [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/addclone/) et [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/). Cela conserve le master, les dispositions et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après les héritages et les remplacements ?**

Utilisez [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/background/geteffective/) et [FillFormat.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/geteffective/). Ces API renvoient les valeurs résolues après l’application des héritages et des remplacements.