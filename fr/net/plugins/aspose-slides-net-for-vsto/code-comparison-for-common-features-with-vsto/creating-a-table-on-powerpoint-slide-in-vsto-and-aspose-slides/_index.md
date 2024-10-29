---
title: Création d'un tableau sur une diapositive PowerPoint dans VSTO et Aspose.Slides
type: docs
weight: 90
url: /fr/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

Les étapes suivantes ajoutent un tableau à une diapositive Microsoft PowerPoint à l'aide de VSTO :

- Créer une présentation.
- Ajouter une diapositive vide à la présentation.
- Ajouter un tableau de 15 x 15 à la diapositive.
- Ajouter du texte à chaque cellule du tableau avec une taille de police de 10.
- Enregistrer la présentation sur le disque.
## **VSTO**
``` csharp

 //Créer une présentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Ajouter une diapositive vierge

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Ajouter un tableau de 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Boucler à travers toutes les lignes

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Boucler à travers toutes les cellules dans la ligne

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

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Les étapes suivantes ajoutent un tableau à une diapositive Microsoft PowerPoint à l'aide d'Aspose.Slides :

- Créer une présentation.
- Ajouter un tableau de 15 x 15 à la première diapositive.
- Ajouter du texte à chaque cellule du tableau avec une taille de police de 10.
- Écrire la présentation sur le disque.
## **Aspose.Slides**
``` csharp

 //Créer une présentation

Presentation pres = new Presentation();

//Accéder à la première diapositive

Slide sld = pres.GetSlideByPosition(1);

//Ajouter un tableau

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Boucler à travers les lignes

for (int i = 0; i < tbl.RowsNumber; i++)

	//Boucler à travers les cellules

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Obtenir le cadre de texte de chaque cellule

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Ajouter un peu de texte

		tf.Text = "T" + i.ToString() + j.ToString();

		//Définir la taille de police à 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Écrire la présentation sur le disque

pres.Write("tblSLD.ppt");

``` 
## **Télécharger le code exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)