---
title: Propriétés Effectives de la Forme
type: docs
weight: 50
url: /fr/net/shape-effective-properties/
keywords: "Propriétés de forme, propriétés de caméra, rig de lumière, forme biseautée, cadre de texte, style de texte, valeur de hauteur de police, format de remplissage pour tableau, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Obtenez les propriétés effectives des formes dans les présentations PowerPoint en C# ou .NET"
---

Dans ce sujet, nous discuterons des propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion.
1. Dans le style de texte de forme prototype sur la mise en page ou la diapositive maître (si la forme de cadre de texte de la portion en a un).
1. Dans les paramètres de texte globaux de la présentation.

ces valeurs sont alors appelées valeurs **locales**. À n'importe quel niveau, les valeurs **locales** peuvent être définies ou omises. Mais finalement, lorsqu'il s'agit du moment où l'application doit savoir à quoi doit ressembler la portion, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **getEffective()** à partir du format local.

L'exemple suivant montre comment obtenir des valeurs effectives.

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



## **Obtenir les Propriétés Effectives de la Caméra**
Aspose.Slides pour .NET permet aux développeurs d'obtenir des propriétés effectives de la caméra. Pour cette fin, la classe **CameraEffectiveData** a été ajoutée dans Aspose.Slides. La classe CameraEffectiveData représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la caméra.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propriétés effectives de la caméra =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Champ de vision: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **Obtenir les Propriétés Effectives du Rig de Lumière**
Aspose.Slides pour .NET permet aux développeurs d'obtenir des propriétés effectives du Rig de Lumière. Pour cette fin, la classe **LightRigEffectiveData** a été ajoutée dans Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable qui contient les propriétés effectives du rig de lumière. Une instance de la classe **LightRigEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour le Rig de Lumière.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propriétés effectives du rig de lumière =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Obtenir les Propriétés Effectives de la Forme Biseautée**
Aspose.Slides pour .NET permet aux développeurs d'obtenir des propriétés effectives de la forme biseautée. Pour cette fin, la classe **ShapeBevelEffectiveData** a été ajoutée dans Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable qui contient les propriétés de relief de la face effective de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la forme biseautée.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Propriétés de relief de la face supérieure effective de la forme =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Largeur: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Hauteur: " + threeDEffectiveData.BevelTop.Height);
}
```



## **Obtenir les Propriétés Effectives du Cadre de Texte**
Utilisant Aspose.Slides pour .NET, vous pouvez obtenir les propriétés effectives du Cadre de Texte. Pour cette fin, la classe **TextFrameFormatEffectiveData** a été ajoutée dans Aspose.Slides, qui contient les propriétés de formatage effectives du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectives du cadre de texte.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();

	Console.WriteLine("Type d'ancrage: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Type d'ajustement automatique: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Type de texte vertical: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Marges");
	Console.WriteLine("   Gauche: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Haut: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Droit: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bas: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **Obtenir les Propriétés Effectives du Style de Texte**
Utilisant Aspose.Slides pour .NET, vous pouvez obtenir les propriétés effectives du Style de Texte. Pour cette fin, la classe **TextStyleEffectiveData** a été ajoutée dans Aspose.Slides, qui contient les propriétés de style de texte effectives.

L'exemple de code suivant montre comment obtenir les propriétés de style de texte effectives.

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Formatage de paragraphe effectif pour le niveau de style #" + i + " =");

        Console.WriteLine("Profondeur: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Retrait: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignement: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Alignement de police: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **Obtenir la Valeur de Hauteur de Police Effective**
Utilisant Aspose.Slides pour .NET, vous pouvez obtenir les propriétés effectives de la Hauteur de Police. Voici le code démontrant la valeur de hauteur de police effective de la portion qui change après avoir défini des valeurs de hauteur de police locales à différents niveaux de structure de présentation.

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Texte d'exemple avec la première portion");
    IPortion portion1 = new Portion(" et la deuxième portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Hauteur de police effective juste après la création:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Hauteur de police effective après avoir défini la hauteur de police par défaut de toute la présentation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Hauteur de police effective après avoir défini la hauteur de police par défaut du paragraphe:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Hauteur de police effective après avoir défini la hauteur de police de la portion #0:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Hauteur de police effective après avoir défini la hauteur de police de la portion #1:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **Obtenir le Format de Remplissage Effectif pour le Tableau**
Utilisant Aspose.Slides pour .NET, vous pouvez obtenir le formatage de remplissage effectif pour différentes parties logiques d'un tableau. Pour cette fin, l'interface **IFillFormatEffectiveData** a été ajoutée dans Aspose.Slides, qui contient les propriétés de formatage de remplissage effectives. Veuillez noter que le formatage des cellules a toujours une priorité plus élevée que le formatage des lignes, une ligne a une priorité plus élevée qu'une colonne et une colonne plus élevée que l'ensemble du tableau.

Ainsi, finalement, les propriétés **CellFormatEffectiveData** sont toujours utilisées pour dessiner le tableau. L'exemple de code suivant montre comment obtenir le formatage de remplissage effectif pour différentes parties logiques du tableau.

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