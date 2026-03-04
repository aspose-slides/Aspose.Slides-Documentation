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
description: "Gérez les thèmes de présentation maîtres dans Aspose.Slides pour .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous choisissez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/net/powerpoint-fonts/), [styles d'arrière‑plan](/slides/fr/net/presentation-background/), et des effets.

![éléments du thème](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments d’une diapositive. Si vous n’aimez pas les couleurs, vous pouvez les modifier en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs dans l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/).

Ce code C# montre comment modifier la couleur d’accent d’un thème :

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Vous pouvez déterminer la valeur effective de la couleur résultante de cette manière :

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Pour illustrer davantage l’opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d’accent (de l’opération initiale). Ensuite, nous modifions la couleur dans le thème :

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la couleur du thème à partir d’une palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème (1), des couleurs provenant de la palette supplémentaire (2) sont générées. Vous pouvez alors définir et récupérer ces couleurs de thème.

![couleurs de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème  
**2** - Couleurs de la palette supplémentaire.

Ce code C# démontre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème puis utilisées dans des formes :

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, Plus clair 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Plus clair 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Plus clair 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Plus foncé 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Plus foncé 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mapper `SchemeColor` aux couleurs `IColorScheme`**

Lorsque vous travaillez avec [SchemeColor](https://reference.aspose.com/slides/fr/net/aspose.slides/schemecolor/), vous pouvez remarquer qu’il contient les valeurs de couleur de thème suivantes : `Background1`, `Background2`, `Text1` et `Text2`.

Cependant, `Presentation.MasterTheme.ColorScheme` renvoie un [IColorScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/icolorscheme/), qui expose les couleurs correspondantes sous les noms : `Dark1`, `Dark2`, `Light1` et `Light2`.

Cette différence ne réside que dans la dénomination. Ces valeurs correspondent aux mêmes emplacements de couleur du thème et le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il n’y a aucune conversion dynamique entre `Text`/`Background` et `Dark`/`Light`. Ce ne sont simplement des noms alternatifs pour les mêmes couleurs de thème.

Cette différence de dénomination provient de la terminologie de Microsoft Office. Les versions plus anciennes d’Office utilisaient `Dark 1`, `Light 1`, `Dark 2` et `Light 2`, tandis que les versions UI plus récentes affichent les mêmes emplacements sous les noms `Text 1`, `Background 1`, `Text 2` et `Background 2`.

## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d’autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du corps Latin (Police Latin Mineure)
* **+mj-lt** - Police du titre Latin (Police Latin Majeure)
* **+mn-ea** - Police du corps Asie de l’Est (Police Asie de l’Est Mineure)
* **+mj-ea** - Police du corps Asie de l’Est (Police Asie de l’Est Mineure)

Ce code C# montre comment affecter la police Latin à un élément du thème :

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Ce code C# montre comment modifier la police du thème de présentation :

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

La police de toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="CONSEIL" %}} 
Vous souhaiterez peut‑être consulter les [polices PowerPoint](/slides/fr/net/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière‑plan du thème**

Par défaut, l’application PowerPoint propose 12 arrière‑plans prédéfinis mais seuls 3 de ces 12 arrière‑plans sont enregistrés dans une présentation typique.

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l’application PowerPoint, vous pouvez exécuter ce code C# pour connaître le nombre d’arrière‑plans prédéfinis dans la présentation :

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) de la classe [FormatScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/), vous pouvez ajouter ou accéder au style d’arrière‑plan dans un thème PowerPoint. 
{{% /alert %}}

Ce code C# montre comment définir l’arrière‑plan d’une présentation :

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Guide d’index** : 0 correspond à aucun remplissage. L’index commence à 1.

{{% alert color="primary" title="CONSEIL" %}} 
Vous souhaiterez peut‑être consulter l’[arrière‑plan PowerPoint](/slides/fr/net/presentation-background/).
{{% /alert %}}

## **Modifier l’effet du thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme/effectstyles)) de la classe [FormatScheme](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/formatscheme) vous pouvez modifier les éléments d’un thème (plus souplement que les options dans PowerPoint).

Ce code C# montre comment modifier un effet de thème en changeant certaines parties des éléments :

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Les changements résultants dans la couleur de remplissage, le type de remplissage, l’effet d’ombre, etc. :

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Puis-je appliquer un thème à une seule diapositive sans modifier le maître ?**  
Oui. Aspose.Slides prend en charge les remplacements de thème au niveau de la diapositive, vous permettant d’appliquer un thème local uniquement à cette diapositive tout en conservant le thème principal inchangé (via le [SlideThemeManager](https://reference.aspose.com/slides/fr/net/aspose.slides.theme/slidethememanager/)).

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**  
[Clone slides](/slides/fr/net/clone-slides/) avec leur maître dans la présentation cible. Cela préserve le maître d’origine, les mises en page et le thème associé, de sorte que l’apparence reste cohérente.

**Comment puis‑je voir les valeurs « effectives » après toute l’héritage et les remplacements ?**  
Utilisez les vues « effectives » de l’API [/slides/fr/net/shape-effective-properties/] pour le thème/la couleur/la police/l’effet. Elles renvoient les propriétés résolues, finales, après l’application du maître ainsi que des éventuels overrides locaux.