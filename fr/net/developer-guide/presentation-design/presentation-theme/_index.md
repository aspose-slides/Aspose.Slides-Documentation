---
title: Thème de Présentation
type: docs
weight: 10
url: /net/presentation-theme/
keywords: "Thème, thème PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Thème de présentation PowerPoint en C# ou .NET"
---

Un thème de présentation définit les propriétés des éléments de design. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et de leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/net/powerpoint-fonts/), [styles d'arrière-plan](/slides/net/presentation-background/), et effets.

![theme-constituents](theme-constituents.png)

## **Changer la Couleur du Thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments sur une diapositive. Si vous n'aimez pas les couleurs, vous pouvez les changer en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs sous l'énumération [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

Ce code C# vous montre comment changer la couleur d'accent pour un thème :

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

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Couleur [A=255, R=128, G=100, B=162])
```

Pour démontrer davantage l'opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d'accent (de l'opération initiale). Ensuite, nous changeons la couleur dans le thème :

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

La nouvelle couleur est automatiquement appliquée aux deux éléments.

### **Définir la Couleur du Thème à partir d'une Palette Supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème(1), des couleurs de la palette supplémentaire(2) sont formées. Vous pouvez ensuite définir et obtenir ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1** - Couleurs principales du thème

**2** - Couleurs de la palette supplémentaire.

Ce code C# démontre une opération où des couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème et ensuite utilisées dans des formes :

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, Plus Clair 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Plus Clair 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Plus Clair 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Plus Foncé 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Plus Foncé 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **Changer la Police du Thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d'autres fins, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du Corps Latin (Police Latina Mineure)
* **+mj-lt** - Police de Titre Latin (Police Latina Majeure)
* **+mn-ea** - Police du Corps Est Asiatique (Police Est Asiatique Mineure)
* **+mj-ea** - Police de Titre Est Asiatique (Police Est Asiatique Majeure)

Ce code C# vous montre comment attribuer la police latine à un élément de thème :

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Format de texte du thème");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Ce code C# vous montre comment changer la police du thème de présentation :

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

La police dans toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="CONSEIL" %}} 

Vous voudrez peut-être voir [polices PowerPoint](/slides/net/powerpoint-fonts/).

{{% /alert %}}

## **Changer le Style d'Arrière-plan du Thème**

Par défaut, l'application PowerPoint fournit 12 arrière-plans prédéfinis mais seulement 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique. 

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l'application PowerPoint, vous pouvez exécuter ce code C# pour savoir combien d'arrière-plans prédéfinis se trouvent dans la présentation :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Le nombre de styles de remplissage d'arrière-plan pour le thème est {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) de la classe [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/), vous pouvez ajouter ou accéder au style d'arrière-plan dans un thème PowerPoint. 

{{% /alert %}}

Ce code C# vous montre comment définir l'arrière-plan pour une présentation :

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Guide des indices** : 0 est utilisé pour aucun remplissage. L'indice commence à partir de 1.

{{% alert color="primary" title="CONSEIL" %}} 

Vous voudrez peut-être voir [Arrière-plan PowerPoint](/slides/net/presentation-background/).

{{% /alert %}}

## **Changer l'Effet du Thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de style. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) de la classe [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme), vous pouvez changer les éléments dans un thème (avec même plus de flexibilité que les options dans PowerPoint).

Ce code C# vous montre comment changer un effet de thème en modifiant des parties des éléments :

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

Les changements résultants dans la couleur de remplissage, le type de remplissage, l'effet d'ombre, etc :

![todo:image_alt_text](presentation-design_11.png)