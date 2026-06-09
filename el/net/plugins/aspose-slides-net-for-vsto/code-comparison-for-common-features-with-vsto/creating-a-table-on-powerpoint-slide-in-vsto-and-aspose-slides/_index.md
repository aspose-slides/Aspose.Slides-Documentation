---
title: Δημιουργία πίνακα σε διαφάνεια PowerPoint με VSTO και Aspose.Slides
type: docs
weight: 90
url: /el/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
Οι παρακάτω βήματα προσθέτουν έναν πίνακα σε μια διαφάνεια του Microsoft PowerPoint χρησιμοποιώντας VSTO:

- Δημιουργήστε μια παρουσίαση.
- Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
- Προσθέστε έναν πίνακα 15 x 15 στη διαφάνεια.
- Προσθέστε κείμενο σε κάθε κελί του πίνακα με μέγεθος γραμματοσειράς 10.
- Αποθηκεύστε την παρουσίαση στο δίσκο.
## **VSTO**
``` csharp

 //Δημιουργία παρουσίασης

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Προσθήκη κενής διαφάνειας

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Προσθήκη πίνακα 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Διάσχιση όλων των σειρών

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Διάσχιση όλων των κελιών στη σειρά

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Λήψη πλαισίου κειμένου κάθε κελιού

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Προσθήκη κειμένου

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Ορισμός μεγέθους γραμματοσειράς κειμένου σε 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Αποθήκευση παρουσίασης στον δίσκο

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Οι παρακάτω βήματα προσθέτουν έναν πίνακα σε μια διαφάνεια του Microsoft PowerPoint χρησιμοποιώντας Aspose.Slides:

- Δημιουργήστε μια παρουσίαση.
- Προσθέστε έναν πίνακα 15 x 15 στην πρώτη διαφάνεια.
- Προσθέστε κείμενο σε κάθε κελί του πίνακα με μέγεθος γραμματοσειράς 10.
- Γράψτε την παρουσίαση στο δίσκο.
## **Aspose.Slides**
``` csharp

 //Δημιουργία παρουσίασης
Presentation pres = new Presentation();

 //Πρόσβαση στην πρώτη διαφάνεια
Slide sld = pres.GetSlideByPosition(1);

 //Προσθήκη πίνακα
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

 //Διάσχιση σειρών
for (int i = 0; i < tbl.RowsNumber; i++)
	 //Διάσχιση κελιών
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//Λήψη πλαισίου κειμένου κάθε κελιού
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//Προσθήκη κειμένου
		tf.Text = "T" + i.ToString() + j.ToString();
		//Ορισμός μεγέθους γραμματοσειράς σε 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//Εγγραφή παρουσίασης στον δίσκο
pres.Write("tblSLD.ppt");

``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)