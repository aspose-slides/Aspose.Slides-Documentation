---
title: Propriétés Effectives de la Forme
type: docs
weight: 50
url: /fr/net/shape-effective-properties/
keywords: "Propriétés de forme, Propriétés de caméra, rig d'éclairage, forme biseautée, cadre de texte, style de texte, valeur de hauteur de police, format de remplissage pour tableau, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Obtenez les propriétés effectives des formes dans les présentations PowerPoint en C# ou .NET"
---

Dans ce sujet, nous aborderons les propriétés **effective** et **local**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion.
1. Dans le style de texte de forme prototype sur la diapositive maître ou modèle (si la forme du cadre de texte de la portion en possède un).
1. Dans les paramètres de texte globaux de la présentation.

alors ces valeurs sont appelées valeurs **local**. À chaque niveau, les valeurs **local** peuvent être définies ou omises. Mais finalement, quand l'application doit savoir à quoi la portion doit ressembler, elle utilise les valeurs **effective**. Vous pouvez obtenir les valeurs **effective** en utilisant la méthode **getEffective()** du format local.

L'exemple suivant montre comment obtenir les valeurs **effective**.
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


## **Obtenir les propriétés Effective de la caméra**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés **effective** de la caméra. À cette fin, la classe **CameraEffectiveData** a été ajoutée dans Aspose.Slides. La classe CameraEffectiveData représente un objet immuable contenant les propriétés **effective** de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs **effective** pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés **effective** pour la caméra.
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


## **Obtenir les propriétés Effective de Light Rig**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés **effective** de Light Rig. À cette fin, la classe **LightRigEffectiveData** a été ajoutée dans Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable contenant les propriétés **effective** du dispositif d'éclairage. Une instance de la classe **LightRigEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs **effective** pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés **effective** pour le Light Rig.
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **Obtenir les propriétés Effective de Bevel Shape**
Aspose.Slides for .NET permet aux développeurs d’obtenir les propriétés **effective** de Bevel Shape. À cette fin, la classe **ShapeBevelEffectiveData** a été ajoutée dans Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable contenant les propriétés **effective** du relief de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs **effective** pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés **effective** pour la forme Bevel.
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


## **Obtenir les propriétés Effective de Text Frame**
Using Aspose.Slides for .NET, you can get effective properties of Text Frame. For this purpose, the **TextFrameFormatEffectiveData** class has been added in Aspose.Slides which contains effective text frame formatting properties. 

L'exemple de code suivant montre comment obtenir les propriétés de formatage **effective** du cadre de texte.
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


## **Obtenir les propriétés Effective de Text Style**
Using Aspose.Slides for .NET, you can get effective properties of Text Style. For this purpose, the **TextStyleEffectiveData** class has been added in Aspose.Slides which contains effective text style properties. 

L'exemple de code suivant montre comment obtenir les propriétés **effective** du style de texte.
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


## **Obtenir la valeur Effective de la hauteur de police**
Using Aspose.Slides for .NET, you can get effective properties of Font Height . Here is the code demonstrating the portion's effective font height value changing after setting local font height values on different presentation structure levels. 
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


## **Obtenir le format de remplissage Effective pour le tableau**
Using Aspose.Slides for .NET, you can get effective fill formatting for different table logic parts. For this purpose, the **IFillFormatEffectiveData** interface has been added in Aspose.Slides which contains effective fill formatting properties. Please note that cell formatting always has higher priority than row formatting, a row has higher priority than column and column higher that whole table. 

So finally **CellFormatEffectiveData** properties always used to draw the table. The following code sample shows how to get effective fill formatting for different table logic parts.
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

**Comment savoir si j'ai obtenu un "snapshot" plutôt qu'un "objet en direct", et quand devrais-je relire les propriétés **effective** ?**
Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l’appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données **effective** pour obtenir les valeurs mises à jour.

**Le fait de modifier la diapositive de mise en page/maître affecte‑t‑il les propriétés **effective** déjà récupérées ?**
Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour ; il faut le demander à nouveau après avoir modifié la mise en page ou le maître.

**Puis‑je modifier les valeurs via EffectiveData ?**
Non. EffectiveData est en lecture seule. Apportez les modifications aux objets de formatage locaux (forme/texte/3D, etc.) puis obtenez à nouveau les valeurs **effective**.

**Que se passe‑t‑il si une propriété n’est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**
La valeur **effective** est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue devient partie de l’instantané EffectiveData.

**À partir d’une valeur de police **effective**, puis‑je identifier le niveau qui a fourni la taille ou la police ?**
Pas directement. EffectiveData renvoie la valeur finale. Pour en connaître la source, examinez les valeurs locales au niveau de la portion/paragraph/texte et les styles de texte au niveau de la mise en page/maître/présentation pour voir où la première définition explicite apparaît.

**Pourquoi les valeurs EffectiveData ressemblent parfois exactement aux valeurs locales ?**
Parce que la valeur locale s’est avérée finale (aucune héritage de niveau supérieur n’était nécessaire). Dans ce cas, la valeur **effective** correspond à la valeur locale.

**Quand faut‑il utiliser les propriétés **effective**, et quand faut‑il travailler uniquement avec les locales ?**
Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu’il sera rendu » après que toutes les héritances aient été appliquées (par ex. pour aligner les couleurs, retraits ou tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.