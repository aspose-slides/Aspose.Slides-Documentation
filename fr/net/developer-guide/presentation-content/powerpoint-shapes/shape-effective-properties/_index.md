---
title: Obtenir les propriétés effectives des formes depuis les présentations en .NET
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/net/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de caméra
- système d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for .NET calcule et applique les propriétés effectives des formes pour un rendu PowerPoint précis."
---

Dans ce sujet, nous allons examiner les propriétés **effectives** et **locales**. Lorsqu’on définit des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion.  
1. Dans le style de texte de forme prototype sur la diapositive de disposition ou maîtresse (si la forme de cadre de texte de la portion en possède une).  
1. Dans les paramètres de texte globaux de la présentation.

alors ces valeurs sont appelées valeurs **locales**. À n’importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais au final, lorsqu’il faut savoir à quoi doit ressembler la portion, l’application utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** du format local.

L’exemple suivant montre comment obtenir les valeurs effectives.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```




## **Obtenir les propriétés effectives de la caméra**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés effectives de la caméra. À cette fin, la classe **CameraEffectiveData** a été ajoutée à Aspose.Slides. La classe CameraEffectiveData représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

Le fragment de code suivant montre comment obtenir les propriétés effectives de la caméra.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```



## **Obtenir les propriétés effectives du système d’éclairage**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés effectives du système d’éclairage. À cette fin, la classe **LightRigEffectiveData** a été ajoutée à Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable qui contient les propriétés effectives du système d’éclairage. Une instance de la classe **LightRigEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

Le fragment de code suivant montre comment obtenir les propriétés effectives du système d’éclairage.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Obtenir les propriétés effectives de la forme biseautée**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés effectives de la forme biseautée. À cette fin, la classe **ShapeBevelEffectiveData** a été ajoutée à Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable qui contient les propriétés effectives du relief de la face de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

Le fragment de code suivant montre comment obtenir les propriétés effectives de la forme biseautée.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```




## **Obtenir les propriétés effectives du cadre de texte**
Avec Aspose.Slides for .NET, vous pouvez obtenir les propriétés effectives du cadre de texte. À cette fin, la classe **TextFrameFormatEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés effectives de mise en forme du cadre de texte.

Le fragment de code suivant montre comment obtenir les propriétés de mise en forme effectives du cadre de texte.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```




## **Obtenir les propriétés effectives du style de texte**
Avec Aspose.Slides for .NET, vous pouvez obtenir les propriétés effectives du style de texte. À cette fin, la classe **TextStyleEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés effectives du style de texte.

Le fragment de code suivant montre comment obtenir les propriétés effectives du style de texte.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```



## **Obtenir la valeur effective de la hauteur de police**
Avec Aspose.Slides for .NET, vous pouvez obtenir les propriétés effectives de la hauteur de police. Voici le code illustrant la valeur effective de la hauteur de police d’une portion qui change après avoir défini des valeurs locales de hauteur de police à différents niveaux de la structure de la présentation.  
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```



## **Obtenir le format de remplissage effectif pour le tableau**
Avec Aspose.Slides for .NET, vous pouvez obtenir le format de remplissage effectif pour les différentes parties logiques d’un tableau. À cette fin, l’interface **IFillFormatEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés effectives de format de remplissage. Veuillez noter que le format de cellule a toujours une priorité supérieure à celui de la ligne, une ligne a une priorité supérieure à celle de la colonne et une colonne a une priorité supérieure à celle du tableau entier.

Ainsi, les propriétés **CellFormatEffectiveData** sont toujours utilisées pour dessiner le tableau. Le fragment de code suivant montre comment obtenir le format de remplissage effectif pour les différentes parties logiques du tableau.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```


## **FAQ**

**Comment savoir si j’ai obtenu un « instantané » plutôt qu’un « objet en direct » et quand dois‑je relire les propriétés effectives ?**

Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**La modification de la diapositive de disposition/maîtresse affecte‑t‑elle les propriétés effectives déjà récupérées ?**

Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour — il faut le demander à nouveau après avoir changé la disposition ou la maîtresse.

**Puis‑je modifier les valeurs via EffectiveData ?**

Non. EffectiveData est en lecture seule. Apportez les changements dans les objets de mise en forme locaux (forme/texte/3D, etc.) puis récupérez à nouveau les valeurs effectives.

**Que se passe‑t‑il si une propriété n’est définie ni au niveau de la forme, ni dans la disposition/maîtresse, ni dans les paramètres globaux ?**

La valeur effective est déterminée par le mécanisme par défaut (paramètres par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police effective, puis‑je identifier le niveau qui a fourni la taille ou la police ?**

Pas directement. EffectiveData renvoie la valeur finale. Pour en connaître la source, examinez les valeurs locales au niveau de la portion/paragraphe/cadre de texte ainsi que les styles de texte au niveau de la disposition/maîtresse/presentation pour voir où se trouve la première définition explicite.

**Pourquoi les valeurs EffectiveData semblent parfois identiques aux valeurs locales ?**

Parce que la valeur locale s’est révélée finale (aucune hérité de niveau supérieur n’a été nécessaire). Dans ces cas, la valeur effective correspond à la valeur locale.

**Quand faut‑il utiliser les propriétés effectives et quand travailler uniquement avec les locales ?**

Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’affiché » après l’application de toute l’héritage (par ex., pour aligner les couleurs, retraits ou tailles). Si vous devez modifier la mise en forme à un niveau spécifique, modifiez les propriétés locales puis, si besoin, relisez EffectiveData pour vérifier le résultat.