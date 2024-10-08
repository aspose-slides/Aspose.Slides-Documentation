---
title: Gérer les cellules
type: docs
weight: 30
url: /fr/net/manage-cells/
keywords:
- tableau
- cellules fusionnées
- cellules séparées
- image dans la cellule du tableau
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Cellules de tableau dans des présentations PowerPoint en C# ou .NET"
---

## **Identifier une cellule de tableau fusionnée**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez le tableau de la première diapositive. 
3. Itérez à travers les lignes et les colonnes du tableau pour trouver les cellules fusionnées.
4. Imprimez un message lorsque des cellules fusionnées sont trouvées.

Ce code C# montre comment identifier les cellules de tableau fusionnées dans une présentation :

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // en supposant que Diapositive#0.Forme#0 est un tableau
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cellule {0};{1} fait partie d'une cellule fusionnée avec RowSpan={2} et ColSpan={3} commençant à partir de la Cellule {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Supprimer la bordure des cellules du tableau**
1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive par son index. 
3. Définissez un tableau de colonnes avec des largeurs.
4. Définissez un tableau de lignes avec des hauteurs.
5. Ajoutez un tableau à la diapositive via la méthode `AddTable`.
6. Itérez à travers chaque cellule pour supprimer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C# montre comment supprimer les bordures des cellules de tableau :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{
   // Accède à la première diapositive
    Slide sld = (Slide)pres.Slides[0];

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de tableau à la diapositive
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
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), le tableau résultant sera numéroté. Ce code C# démontre le processus :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide sld = presentation.Slides[0];

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

Nous fusionnons ensuite les cellules davantage en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre : 

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

## **Numérotation dans une cellule séparée**
Dans les exemples précédents, lorsque les cellules du tableau ont été fusionnées, la numérotation ou le système de numérotation dans d'autres cellules n'a pas changé. 

Cette fois, nous prenons un tableau normal (un tableau sans cellules fusionnées) et essayons ensuite de séparer la cellule (1,1) pour obtenir un tableau spécial. Vous voudrez peut-être faire attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c'est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait la même chose. 

Ce code C# démontre le processus que nous avons décrit :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

    // Sépare la cellule (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Écrit le fichier PPTX sur le disque
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Changer la couleur d'arrière-plan d'une cellule de tableau**

Ce code C# vous montre comment changer la couleur d'arrière-plan d'une cellule de tableau :

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crée un nouveau tableau
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // définit la couleur d'arrière-plan pour une cellule 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Ajouter une image dans une cellule de tableau**

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive par son index.
3. Définissez un tableau de colonnes avec des largeurs.
4. Définissez un tableau de lignes avec des hauteurs.
5. Ajoutez un tableau à la diapositive via la méthode `AddTable`. 
6. Créez un objet `Bitmap` pour contenir le fichier image.
7. Ajoutez l'image bitmap à l'objet `IPPImage`.
8. Définissez le `FillFormat` pour la cellule de tableau sur `Image`.
9. Ajoutez l'image à la première cellule du tableau.
10. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code C# montre comment placer une image dans une cellule de tableau lors de la création d'un tableau :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = presentation.Slides[0];

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Ajoute une forme de tableau à la diapositive
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Charge une image à partir d'un fichier et l'ajoute aux ressources de la présentation
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