---
title: Gérer les thèmes de présentation dans .NET
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/net/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- thème externe
- THMX
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, polices, styles d’arrière-plan, remplissages, lignes et effets. Les objets compatibles avec le thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets d’un coup.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/). Une présentation peut également contenir des remplacements de thème à des niveaux inférieurs. Un maître peut remplacer le thème de la présentation via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/masterthememanager/overridetheme/), une disposition peut remplacer le thème hérité via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, remplacement du maître, remplacement de la disposition, et remplacement de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière-plan et effets](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des remplacements.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/) expose le [ColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/colorscheme/), le [FontScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/fontscheme/) et le [FormatScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/mastertheme/formatscheme/) du thème. Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le maître associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsque des remplacements de disposition ou de diapositive peuvent être présents.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes compatibles avec le thème peuvent se référer à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et imprime la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint génère des variantes plus claires et plus sombres à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/fr/net/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus sombres générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** – Couleurs principales du thème.  
**2** – Variantes plus claires et plus sombres produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, puis enregistre le résultat :

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

Ces variantes restent basées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `IColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ce sont des noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à une autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un jeu de polices majeur pour les titres et un jeu mineur pour le corps du texte. Les propriétés [FontScheme.Major](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/major/) et [FontScheme.Minor](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/fontscheme/minor/) exposent ces jeux.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` – Police du corps Latin (Minor Latin Font)
* `+mj-lt` – Police du titre Latin (Major Latin Font)
* `+mn-ea` – Police du corps Asiatique de l’Est (Minor East Asian Font)
* `+mj-ea` – Police du titre Asiatique de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème évoluera.

Les collections de polices majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, voir **[Polices de thème spécifiques aux scripts](/slides/fr/net/script-specific-font-mappings/)**.

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, consultez **[Polices PowerPoint](/slides/fr/net/powerpoint-fonts/)**.
{{% /alert %}}

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d’un maître**

Utilisez [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez restyliser chaque diapositive dépendant d’un maître particulier. Sélectionnez le maître dans la collection [Presentation.Masters](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/masters/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/), et transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée une nouvelle diapositive maître basée sur le maître sélectionné.  
1. Applique le thème externe au nouveau maître.  
1. Assigne le nouveau maître à toutes les diapositives qui dépendaient auparavant du maître sélectionné.  
1. Retourne le nouvellement créé [IMasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/).

L’exemple suivant applique un thème externe aux diapositives dépendant du premier maître, enregistre la présentation et rouvre le résultat :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Un thème invalide, corrompu ou non pris en charge peut provoquer une [PptxException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxexception/) ou l’une de ses sous‑classes liées au format. Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives dépendant du maître sélectionné sont réassignées. Les diapositives associées à d’autres maîtres conservent leurs maîtres et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets dépendants du thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats attribués directement peuvent rester inchangés. Les remplacements au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau maître.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via **[sources de polices personnalisées](/slides/fr/net/custom-font/)**, ou configurez **[la substitution de polices](/slides/fr/net/font-substitution/)**.

Il s’agit d’un flux de travail direct au niveau du maître : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des remplacements de thème au niveau de la disposition ou de la diapositive.

### **Appliquer différents thèmes externes dans une présentation multi‑maîtres**

Lorsque le maître pertinent n’est pas connu à l’avance, obtenez‑le à partir d’une diapositive représentative via [ISlide.LayoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/layoutslide/) et [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/masterslide/). Conservez les références originales des maîtres avant d’appliquer des thèmes, car chaque appel crée un autre maître dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs maîtres et applique un thème externe différent à chaque groupe :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Le premier appel n’affecte que les diapositives dépendant de `firstGroupMaster`, et le second appel n’affecte que les diapositives dépendant de `secondGroupMaster`. Les diapositives appartenant à tout autre maître ne sont pas restylisées.

### **Conserver le thème source lors du déplacement de diapositives**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le maître source dans la présentation cible avec [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/) et le maître cloné. Cela transporte le maître, ses dispositions et le thème associé ensemble.

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

C’est le flux de travail recommandé lorsque la diapositive source doit rester identique dans la destination. Cloner simplement le contenu sur un maître de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son maître et sa disposition actuels, initialisez un remplacement au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois principaux composants du thème dans le remplacement.

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

Un remplacement au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive possède son propre remplacement. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/layoutslidethememanager/) de la disposition :

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

Utilisez un thème au niveau du maître ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, un remplacement de disposition lorsqu’une famille de dispositions nécessite un style différent, et un remplacement de diapositive uniquement pour de vraies exceptions. Un excès de remplacements au niveau de la diapositive rend les modifications globales ultérieures du thème plus difficiles à prévoir.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint peut proposer davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages de thème avec les couleurs de thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et la propriété actuelle [Background.StyleIndex](https://reference.aspose.com/slides/fr/net/aspose.slides/background/styleindex/). `StyleIndex` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection .NET, où `[0]` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, assigne une référence d’arrière‑plan thématisé au premier maître et enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le maître et de tout remplacement d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du maître peut ne pas affecter cette diapositive. Utilisez [Background.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/background/geteffective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `StyleIndex` comme un index de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de styles de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct d’arrière‑plan et l’héritage d’arrière‑plan, consultez **[Arrière‑plan de la présentation](/slides/fr/net/presentation-background/)**.
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format de thème contient des collections distinctes de [FillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/linestyles/) et [EffectStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en C#, l’index de la collection commence à zéro : `[0]` est le premier style stocké et `[2]` le troisième. Les index de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, change le premier style de ligne, change le troisième style de remplissage, active une ombre externe dans le troisième style d’effet, puis enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et si un formatage direct remplace le thème.

![Styles d’effet du thème après modification des paramètres de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Déterminer si un remplissage plein effectif utilise une couleur de thème**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un maître, d’un style de thème ou d’un autre niveau de formatage. Appelez [IFillFormat.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformat/geteffective/) pour résoudre cette hiérarchie en un [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/) immuable. Vérifiez d’abord [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/filltype/). Ce n’est que lorsqu’il vaut `FillType.Solid` que vous devez lire les propriétés du remplissage plein.

Pour un remplissage plein, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) renvoie la valeur RVB finale rendue après hériter, recherche de thème et transformations de couleur. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) renvoie l’emplacement logique correspondant de [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/), tel que `Text1` ou `Accent6`. Une valeur `SchemeColor.NotDefined` signifie que le remplissage plein effectif ne repose pas sur une couleur de schéma. Dans un flux de travail où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

Ne vous fiez pas uniquement à la valeur locale [IColorFormat.SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/icolorformat/schemecolor/) pour classer un remplissage. Par exemple, une portion de texte peut ne pas définir localement de couleur de schéma, son état local est donc `NotDefined`, tandis que son remplissage effectif hérite d’une couleur de thème et se résout en `Text1` ou `Accent6`. Inversement, `SolidFillSchemeColor` indique quel emplacement logique du thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la disposition, du maître ou d’un autre niveau de la hiérarchie.

L’exemple suivant charge une présentation, audite les remplissages des formes et des portions de texte, imprime chaque valeur RVB finale et la couleur de schéma associée, et signale les remplissages pleins qui ne suivront pas les changements de couleur de thème :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

La branche `NotDefined` fournit une liste d’audit des remplissages pleins qui ne réagiront pas aux modifications des emplacements de couleur du thème. Examinez ces objets lorsqu’une présentation doit respecter une nouvelle palette de marque. La valeur RVB affichée représente toujours l’apparence actuelle, tandis que la valeur de schéma indique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir changé le thème de la présentation, un remplacement de thème ou tout formatage hérité, appelez à nouveau `GetEffective` et lisez un nouvel objet `IFillFormatEffectiveData` avant de comparer ou de rapporter les couleurs.

## **Lire les valeurs de thème effectives**

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.MasterTheme](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/mastertheme/), vous risquez de manquer un remplacement au niveau du maître, de la disposition, de la diapositive ou de la forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) ne réaffecte que les diapositives dépendant du maître sélectionné. Les diapositives utilisant d’autres maîtres conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans modifier le maître ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/slidethememanager/) de la diapositive et initialisez son thème de remplacement. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en préservant son apparence source, clonez le maître source dans la destination et clonez la diapositive avec ce maître en utilisant [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslidecollection/addclone/) et [ISlideCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/islidecollection/addclone/). Cela maintient le maître, les dispositions et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après les héritages et les remplacements ?**

Utilisez [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) pour un thème de diapositive ou de disposition, ainsi que les méthodes de données effectives correspondantes pour les objets de format tels que [Background.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/background/geteffective/) et [FillFormat.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/geteffective/). Ces API renvoient les valeurs résolues après application des héritages et des remplacements.