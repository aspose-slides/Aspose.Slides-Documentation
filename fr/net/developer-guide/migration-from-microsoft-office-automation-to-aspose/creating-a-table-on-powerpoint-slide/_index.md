---
title: Création d'un Tableau sur une Diapositive PowerPoint
type: docs
weight: 50
url: /net/creating-a-table-on-powerpoint-slide/
---

{{% alert color="primary" %}} 

Les tableaux sont largement utilisés pour afficher des données sur des diapositives de présentation. Cet article montre comment créer un tableau 15 x 15 avec une taille de police de 10 de manière programmatique en utilisant d'abord [VSTO 2008](/slides/net/creating-a-table-on-powerpoint-slide/) puis [Aspose.Slides pour .NET](/slides/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Création de Tableaux**
#### **Exemple VSTO 2008**
Les étapes suivantes ajoutent un tableau à une diapositive Microsoft PowerPoint en utilisant VSTO :

1. Créer une présentation.
1. Ajouter une diapositive vide à la présentation.
1. Ajouter un tableau 15 x 15 à la diapositive.
1. Ajouter du texte à chaque cellule du tableau avec une taille de police de 10.
1. Enregistrer la présentation sur le disque.

```c#
//Créer une présentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Ajouter une diapositive vierge
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Ajouter un tableau 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Boucle à travers toutes les lignes
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Boucle à travers toutes les cellules de la ligne
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Obtenir le cadre de texte de chaque cellule
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Ajouter un peu de texte
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Définir la taille de police du texte à 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Enregistrer la présentation sur le disque
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Exemple Aspose.Slides pour .NET**
Les étapes suivantes ajoutent un tableau à une diapositive Microsoft PowerPoint en utilisant Aspose.Slides :

1. Créer une présentation.
1. Ajouter un tableau 15 x 15 à la première diapositive.
1. Ajouter du texte à chaque cellule du tableau avec une taille de police de 10.
1. Écrire la présentation sur disque.

```c#
Presentation pres = new Presentation();

//Accéder à la première diapositive
ISlide sld = pres.Slides[0];

//Définir les colonnes avec largeurs et les lignes avec hauteurs
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Ajouter un tableau
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Définir le format de bordure pour chaque cellule
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Obtenir le cadre de texte de chaque cellule
		ITextFrame tf = cell.TextFrame;
		//Ajouter un peu de texte
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Définir la taille de police à 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Écrire la présentation sur le disque
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```