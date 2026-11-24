---
title: Gestion des thèmes de présentation dans .NET
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/net/presentation-theme/
keywords:
- Thème PowerPoint
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
description: "Thèmes maîtres de présentation dans Aspose.Slides pour .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, polices, styles d’arrière‑plan, remplissages, lignes et effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), une disposition peut remplacer son thème hérité via [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, substitution du master, substitution de la disposition et substitution de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail thématiques les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effet, et lire les valeurs effectives après résolution des héritages et des substitutions.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) expose le [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), le [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) et le [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) du thème. Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe parce que le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

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

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail « effective‑theme » présenté plus loin dans cet article lorsque des substitutions de disposition ou de diapositive peuvent être présentes.

## **Change Theme Colors**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui font encore référence à cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la réouvre et affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur du jeu par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint génère des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Couleurs principales du thème.

**2** – Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

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

### **Map `SchemeColor` Values to `IColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements du thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit simplement de noms alternatifs pour les mêmes emplacements du thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Change Theme Fonts**

Un jeu de polices de thème contient un jeu de polices majeur pour les titres et un jeu de polices mineur pour le corps du texte. Les propriétés [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) et [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) exposent ces ensembles.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` – Police de corps Latin (Minor Latin Font)
* `+mj-lt` – Police de titre Latin (Major Latin Font)
* `+mn-ea` – Police de corps Est‑Asiatique (Minor East Asian Font)
* `+mj-ea` – Police de titre Est‑Asiatique (Major East Asian Font)
* `+mn-cs` – Police de corps Script complexe (Minor Complex Script Font)
* `+mj-cs` – Police de titre Script complexe (Major Complex Script Font)

L’exemple suivant crée un titre qui utilise la police thématique majeure Latin et une ligne de corps qui utilise la police thématique mineure Latin. Il change ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le jeu de polices du thème évoluera.

Les collections de polices majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, consultez [Script-Specific Theme Fonts](/slides/fr/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/net/powerpoint-fonts/).
{{% /alert %}}

### **Resolve Theme Font References**

Lors de l’inspection du texte, [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) peut contenir une référence thématique telle que `+mn-lt` au lieu d’un nom de famille de police. Appelez [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) avec le [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) approprié pour résoudre cette référence. Les préfixes `+mj` et `+mn` sélectionnent les jeux de polices majeures et mineures ; les suffixes `-lt`, `-ea` et `-cs` sélectionnent respectivement leurs polices Latin, Est‑Asiatique et Script complexe.

Obtenez le thème effectif via [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) sur l’objet dont le thème s’applique au texte inspecté. Pour du texte ordinaire sur une diapositive, utilisez `slide.CreateThemeEffective()` afin que le contexte inclue le thème hérité de la diapositive et les substitutions locales. Lors de l’inspection d’une disposition ou d’un master, utilisez son propre thème effectif. Ne supposez pas que le thème du premier master s’applique à chaque diapositive.

L’exemple suivant crée une portion de texte qui référence explicitement la police Latin mineure. Il initialise le jeu de polices d’une diapositive via [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) et définit les familles Latin majeures et mineures à `Arial` et `Calibri`, rendant le résultat reproductible sans fichier d’entrée.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

Le résultat affiché est `+mn-lt -> Calibri` suivi de `Verdana -> Verdana`. La référence stockée reste inchangée, tandis qu’un nom de famille explicite est renvoyé tel quel. Si la portion avait utilisé `+mj-lt`, elle aurait été résolue en `Arial` dans ce thème.

Résoudre une référence thématique indique la famille de police spécifiée par le thème. Cela ne vérifie pas la disponibilité de la police ni ne détermine le fichier de police réellement utilisé après substitution ou recherche de glyphes pendant le rendu. Consultez [Font Selection Sequence](/slides/fr/net/font-selection-sequence/) et [Font Substitution](/slides/fr/net/font-substitution/) pour ces étapes séparées.

## **Copy or Apply a Theme**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Apply an External Theme to a Master's Dependent Slides**

Utilisez [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) lorsque vous avez un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styliser chaque diapositive dépendant d’un master particulier. Sélectionnez le master dans la collection [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/), puis transmettez le chemin du fichier thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée un nouveau master slide basé sur le master sélectionné.  
1. Applique le thème externe au nouveau master.  
1. Assigne le nouveau master à toutes les diapositives qui dépendaient auparavant du master sélectionné.  
1. Retourne le nouvellement créé [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier master, enregistre la présentation et réouvre le résultat :

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

Un thème invalide, corrompu ou non pris en charge peut générer une [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) ou l’une de ses sous‑classes liées au format. Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers, et n’enregistrez la présentation qu’après l’application réussie du thème.

Seules les diapositives dépendant du master sélectionné sont réaffectées. Les diapositives associées à d’autres masters conservent leurs masters et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autre formatage explicitement assignés peuvent rester inchangés. Les substitutions au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via les [custom font sources](/slides/fr/net/custom-font/), ou configurez la [font substitution](/slides/fr/net/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des substitutions de thème au niveau des diapositives ou des dispositions.

### **Apply Different External Themes in a Multi-Master Presentation**

Lorsque le master pertinent n’est pas connu à l’avance, récupérez‑le à partir d’une diapositive représentative via [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) et [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Conservez les références des masters originaux avant d’appliquer des thèmes, car chaque appel crée un autre master dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

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

Le premier appel affecte uniquement les diapositives dépendant de `firstGroupMaster`, et le second appel affecte uniquement celles dépendant de `secondGroupMaster`. Les diapositives appartenant à tout autre master ne sont pas re‑stylisées.

### **Preserve a Source Theme When Moving Slides**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé ensemble.

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

C’est le flux de travail recommandé lorsque la diapositive source doit apparaître de façon identique dans la destination. Cloner simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets gouvernés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois composants principaux du thème dans la substitution.

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

Cela modifie le thème utilisé par cette diapositive sans modifier le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **Apply a Theme Override to a Layout**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, à moins qu’une diapositive particulière n’ait sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) de la disposition :

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

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de véritables exceptions. Un excès de substitutions au niveau des diapositives rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint peut proposer plus de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et le [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) actuel. `StyleIndex` utilise `0` pour aucun remplissage thématique ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe de la collection .NET, où `[0]` désigne le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, assigne une référence d’arrière‑plan thématique au premier master et enregistre la présentation :

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

Le résultat visible dépend de l’entrée de thème référencée par le master et de toute substitution d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, ne changer que l’arrière‑plan du master ne modifie pas forcément cette diapositive. Utilisez [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) lorsque vous avez besoin de connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `StyleIndex` comme un indice de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura la même apparence dans un autre fichier ; les définitions de style du thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct d’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/net/presentation-background/).
{{% /alert %}}

## **Update Theme Effects**

Un schéma de format de thème contient des collections distinctes de [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), de [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) et de [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales correspondant visuellement à un formatage subtil, modéré et intense, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en C#, l’indice de la collection commence à zéro : `[0]` est le premier style stocké et `[2]` le troisième. Les indices de référence de style d’une forme constituent un concept séparé, exposé via [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui font référence à ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet et enregistre le résultat :

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

Pour les formes qui font référence à ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu visuel exact dépend toujours de quels emplacements de style chaque forme référence et si un formatage direct surcharge le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Select Theme Fill and Line Styles for a Shape**

Une forme peut sélectionner son remplissage et son contour de façon indépendante via [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) et [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Pour les deux propriétés, l’indice `1` sélectionne la première entrée de la collection de thème correspondante (`FillStyles[0]` ou `LineStyles[0]`), et l’indice `2` sélectionne la seconde entrée.

L’exemple suivant crée deux styles de remplissage (or et bleu ciel) et deux styles de ligne (bleu foncé à 6 pt et rouge foncé à 12 pt) dans le thème par défaut d’une nouvelle présentation. Il enregistre la diapositive à trois étapes afin que vous puissiez comparer les résultats dans PowerPoint.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Styles initiaux | Modifier le contour droit | Modifier le premier remplissage du thème |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Sélectionner un style de ligne différent ne change que le contour du rectangle de droite. Modifier le premier remplissage du thème met à jour chaque forme qui l’utilise. Ici, seul le rectangle de gauche devient vert.

Sur une forme existante, une couleur de remplissage, une couleur de ligne ou une épaisseur de ligne locales peuvent supplanter cette partie du style de thème. Si la modification d’un indice de style n’a aucun effet visible, vérifiez le [direct formatting](/slides/fr/net/shape-formatting/) de la forme.

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un master, d’un style de thème ou d’un autre niveau de formatage. Appelez [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) pour résoudre cette hiérarchie en un objet immuable [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/). Commencez par vérifier [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Ce n’est que lorsqu’il vaut `FillType.Solid` que vous devez lire les propriétés du remplissage plein.

Pour un remplissage plein, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) renvoie la valeur RGB finale rendue après héritage, recherche dans le thème et application des transformations de couleur. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) renvoie le slot logique [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) correspondant, tel que `Text1` ou `Accent6`. Une valeur `SchemeColor.NotDefined` signifie que le remplissage plein effectif n’est pas basé sur une couleur de schéma. Dans un flux de travail où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) pour classer un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de schéma définie localement, donc sa valeur locale est `NotDefined`, tandis que son remplissage effectif hérite d’une couleur de thème et résout à `Text1` ou `Accent6`. Inversement, `SolidFillSchemeColor` indique quel slot logique a produit la couleur effective, mais ne précise pas si ce slot provient de l’objet, du paragraphe, de la disposition, du master ou d’un autre niveau de la hiérarchie.

L’exemple suivant charge une présentation, examine les remplissages des formes et des portions de texte, imprime chaque valeur RGB finale ainsi que la couleur de schéma associée, et signale les remplissages pleins qui ne suivront pas les changements de couleur du thème :

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

La branche `NotDefined` fournit une liste d’audit des remplissages pleins qui ne réagiront pas aux changements des slots de couleur du thème. Passez en revue ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RGB affichée reflète toujours l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir modifié le thème de la présentation, une substitution de thème ou tout formatage hérité, appelez de nouveau `GetEffective` et lisez un nouveau `IFillFormatEffectiveData` avant de comparer ou de rapporter les couleurs.

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Pour un arrière‑plan, utilisez [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), et pour un remplissage, utilisez [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/), vous risquez de manquer un master, une disposition, une diapositive ou une substitution de forme qui modifie l’apparence finale.

## **FAQ**

**Does applying an external theme affect every slide in the presentation?**

No. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reassigns only the slides that depend on the selected master. Slides that use other masters retain their existing themes.

**Can I apply a theme to a single slide without changing the master?**

Yes. Use the slide's [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) and initialize its override theme. The change remains local to that slide; other slides continue to inherit their existing themes.

**What is the safest way to carry a theme from one presentation to another?**

When moving a slide and preserving its source appearance, clone the source master into the destination and clone the slide with that master using [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) and [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). This keeps the master, layouts, and theme together.

**How can I see the effective values after inheritance and overrides?**

Use [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) for a slide or layout theme and the corresponding effective-data methods for format objects such as [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) and [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). These APIs return the resolved values after inheritance and overrides are applied.