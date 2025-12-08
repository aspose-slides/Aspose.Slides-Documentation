---
title: Gérer les cellules
type: docs
weight: 30
url: /fr/net/manage-cells/
keywords:
- table
- cellules fusionnées
- cellules scindées
- image dans une cellule de tableau
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Cellules de tableau dans les présentations PowerPoint en C# ou .NET"
---

## **Identifier les cellules de tableau fusionnées**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenir le tableau de la première diapositive.
3. Parcourir les lignes et colonnes du tableau pour trouver les cellules fusionnées.
4. Afficher un message lorsqu'une cellule fusionnée est trouvée.

Ce code C# montre comment identifier les cellules de tableau fusionnées dans une présentation:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // en supposant que Slide#0.Shape#0 est un tableau
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **Supprimer la bordure des cellules de tableau**
1. Créer une instance de la classe `Presentation`.
2. Obtenir la référence d'une diapositive via son index.
3. Définir un tableau de colonnes avec la largeur.
4. Définir un tableau de lignes avec la hauteur.
5. Ajouter un tableau à la diapositive à l'aide de la méthode `AddTable`.
6. Parcourir chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrer la présentation modifiée au format PPTX.

Ce code C# montre comment supprimer les bordures des cellules de tableau:
```c#
 // Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{
   // Accède à la première diapositive
    Slide sld = (Slide)pres.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute la forme de tableau à la diapositive
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Écrit le fichier PPTX sur le disque
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) × (2, 1) et (1, 2) × (2, 2), le tableau résultant sera numéroté. Ce code C# montre le processus :
```c#
 // Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide sld = presentation.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


Nous fusionnons ensuite davantage les cellules en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre :
```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Fusionne les cellules (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Fusionne les cellules (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Fusionne les cellules (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Écrit le fichier PPTX sur le disque
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **Numérotation dans les cellules scindées**
Dans les exemples précédents, lorsque les cellules du tableau étaient fusionnées, la numérotation ou le système de numération des autres cellules ne changeait pas.

Cette fois, nous prenons un tableau standard (un tableau sans cellules fusionnées) puis essayons de scinder la cellule (1, 1) afin d'obtenir un tableau spécial. Vous pouvez prêter attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait de même.

Ce code C# montre le processus décrit :
```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Fusionne les cellules (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Fusionne les cellules (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Scinde la cellule (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Écrit le fichier PPTX sur le disque
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Ce code C# montre comment changer la couleur d'arrière-plan d'une cellule de tableau :
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // créer un nouveau tableau
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // définir la couleur d'arrière-plan pour une cellule 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **Ajouter une image à l'intérieur d'une cellule de tableau**

1. Créer une instance de la classe `Presentation`.
2. Obtenir la référence d'une diapositive via son index.
3. Définir un tableau de colonnes avec la largeur.
4. Définir un tableau de lignes avec la hauteur.
5. Ajouter un tableau à la diapositive à l'aide de la méthode `AddTable`.
6. Créer un objet `Bitmap` pour contenir le fichier image.
7. Ajouter l'image bitmap à l'objet `IPPImage`.
8. Définir le `FillFormat` de la cellule de tableau sur `Picture`.
9. Ajouter l'image à la première cellule du tableau.
10. Enregistrer la présentation modifiée au format PPTX.

Ce code C# montre comment placer une image à l'intérieur d'une cellule de tableau lors de la création d'un tableau :
```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Charge une image depuis un fichier et l'ajoute aux ressources de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute l'image à la première cellule du tableau
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Enregistre le fichier PPTX sur le disque
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je définir des épaisseurs et styles de ligne différents pour les différents côtés d'une même cellule ?**

Oui. Les bordures [haut](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bas](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[gauche](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[droite](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) possèdent des propriétés distinctes, de sorte que l'épaisseur et le style de chaque côté peuvent différer. Cela découle logiquement du contrôle de bordure par côté d'une cellule démontré dans l'article.

**Que se passe-t-il pour l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (étirement/tuile). Avec l'étirement, l'image s'adapte à la nouvelle cellule ; avec le mode tuile, les carreaux sont recalculés. L'article mentionne les modes d'affichage d'image dans une cellule.

**Puis-je affecter un hyperlien à l'ensemble du contenu d'une cellule ?**

[Hyperlinks](/slides/fr/net/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre de texte de la cellule ou au niveau de l'ensemble du tableau/forme. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis-je définir des polices différentes au sein d'une même cellule ?**

Oui. Le cadre de texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (segments) avec un formatage indépendant — famille de police, style, taille et couleur.