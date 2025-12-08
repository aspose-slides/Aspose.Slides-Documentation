---
title: Gérer les lignes et colonnes
type: docs
weight: 20
url: /fr/net/manage-rows-and-columns/
keywords: "Tableau, lignes et colonnes de tableau, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Gérer les lignes et colonnes d'un tableau dans les présentations PowerPoint en C# ou .NET"
---

Pour vous permettre de gérer les lignes et colonnes d'un tableau dans une présentation PowerPoint, Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , l'interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , ainsi que de nombreux autres types. 

## **Définir la première ligne comme en-tête**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation. 
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) et affectez‑lui la valeur null. 
4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) afin de trouver le tableau correspondant. 
5. Définissez la première ligne du tableau comme son en‑tête. 

Ce code C# montre comment définir la première ligne d'un tableau comme son en‑tête :
```c#
// Instancie la classe Presentation
Presentation pres = new Presentation("table.pptx");

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Initialise le TableEx nul
ITable tbl = null;

// Itère sur les formes et définit une référence vers le tableau
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Définit la première ligne d'un tableau comme son en‑tête
tbl.FirstRow = true;

// Enregistre la présentation sur le disque
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Cloner la ligne ou la colonne d'un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation, 
2. Obtenez la référence d'une diapositive via son index. 
3. Définissez un tableau de `columnWidth`. 
4. Définissez un tableau de `rowHeight`. 
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive à l'aide de la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Clonez la ligne du tableau. 
7. Clonez la colonne du tableau. 
8. Enregistrez la présentation modifiée. 

Ce code C# montre comment cloner la ligne ou la colonne d'un tableau PowerPoint :
```c#
 // Instancie la classe Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accède à la première diapositive
    ISlide sld = presentation.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ajoute du texte à la cellule 1 de la ligne 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Ajoute du texte à la cellule 2 de la ligne 1
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clone la ligne 1 à la fin du tableau
    table.Rows.AddClone(table.Rows[0], false);

    // Ajoute du texte à la cellule 1 de la ligne 2
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Ajoute du texte à la cellule 2 de la ligne 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clone la ligne 2 en tant que 4ème ligne du tableau
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clone la première colonne à la fin
    table.Columns.AddClone(table.Columns[0], false);

    // Clone la 2ème colonne à l'index 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Enregistre la présentation sur le disque 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Supprimer une ligne ou une colonne d'un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation, 
2. Obtenez la référence d'une diapositive via son index. 
3. Définissez un tableau de `columnWidth`. 
4. Définissez un tableau de `rowHeight`. 
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) à la diapositive à l'aide de la méthode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). 
6. Supprimez la ligne du tableau. 
7. Supprimez la colonne du tableau. 
8. Enregistrez la présentation modifiée. 

Ce code C# montre comment supprimer une ligne ou une colonne d'un tableau :
```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Définir le formatage du texte au niveau des lignes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation, 
2. Obtenez la référence d'une diapositive via son index. 
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pertinent depuis la diapositive. 
4. Définissez la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) des cellules de la première ligne. 
5. Définissez l'[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et le [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) des cellules de la première ligne. 
6. Définissez le [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) des cellules de la deuxième ligne. 
7. Enregistrez la présentation modifiée. 

Ce code C# démontre l'opération.
```c#
// Crée une instance de la classe Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Supposons que la première forme sur la première diapositive est un tableau

// Définit la hauteur de police des cellules de la première ligne
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Définit l'alignement du texte et la marge droite des cellules de la première ligne
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Définit le type de texte vertical des cellules de la deuxième ligne
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Enregistre la présentation sur le disque
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Définir le formatage du texte au niveau des colonnes du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation, 
2. Obtenez la référence d'une diapositive via son index. 
3. Accédez à l'objet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) pertinent depuis la diapositive. 
4. Définissez la [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) des cellules de la première colonne. 
5. Définissez l'[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) et le [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) des cellules de la première colonne. 
6. Définissez le [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) des cellules de la deuxième colonne. 
7. Enregistrez la présentation modifiée. 

Ce code C# démontre l'opération :
```c#
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Supposons que la première forme sur la première diapositive est un tableau

// Définit la hauteur de police des cellules de la première colonne
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Définit l'alignement du texte et la marge droite des cellules de la première colonne en un seul appel
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Définit le type de texte vertical des cellules de la deuxième colonne
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Enregistre la présentation sur le disque
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin de les utiliser pour un autre tableau ou ailleurs. Ce code C# montre comment obtenir les propriétés de style à partir d'un style de tableau prédéfini :
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // modifier le thème du style prédéfini par défaut
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis‑je appliquer des thèmes/styles PowerPoint à un tableau déjà créé ?**

Oui. Le tableau hérite du thème de la diapositive / de la disposition / du masque, et vous pouvez toujours remplacer les remplissages, les bordures et les couleurs du texte par-dessus ce thème.

**Puis‑je trier les lignes d'un tableau comme dans Excel ?**

Non, les tableaux Aspose.Slides ne disposent pas de tri ou de filtres intégrés. Triez d'abord vos données en mémoire, puis ré‑alignez les lignes du tableau dans cet ordre.

**Puis‑je avoir des colonnes à bandes (rayées) tout en conservant des couleurs personnalisées sur certaines cellules ?**

Oui. Activez les colonnes à bandes, puis remplacez les cellules spécifiques avec un formatage local ; le formatage au niveau de la cellule prime sur le style du tableau.