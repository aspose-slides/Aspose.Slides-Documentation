---
title: Δημιουργία Πινάκων με χρήση VSTO και Aspose.Slides για .NET
linktitle: Δημιουργία Πινάκων
type: docs
weight: 50
url: /el/net/creating-a-table-on-powerpoint-slide/
keywords:
- δημιουργία πίνακα
- μεταφορά
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταφερθείτε από την αυτοματοποίηση του Microsoft Office στο Aspose.Slides για .NET και δημιουργήστε πίνακες σε διαφάνειες PowerPoint (PPT, PPTX) με C# με ευέλικτη μορφοποίηση."
---
{{% alert color="info" %}} 
Οι πίνακες χρησιμοποιούνται εκτενώς για την εμφάνιση δεδομένων σε διαφάνειες παρουσίασης. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε προγραμματιστικά έναν πίνακα 15 x 15 με μέγεθος γραμματοσειράς 10, χρησιμοποιώντας πρώτα το [VSTO 2008](/slides/el/net/creating-a-table-on-powerpoint-slide/) και στη συνέχεια το [Aspose.Slides for .NET](/slides/el/net/creating-a-table-on-powerpoint-slide/).
{{% /alert %}} 
## **Δημιουργία Πινάκων**
#### **Παράδειγμα VSTO 2008**
Τα παρακάτω βήματα προσθέτουν έναν πίνακα σε μια διαφάνεια Microsoft PowerPoint χρησιμοποιώντας VSTO:

1. Δημιουργήστε μια παρουσίαση.  
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.  
1. Προσθέστε έναν πίνακα 15 x 15 στη διαφάνεια.  
1. Προσθέστε κείμενο σε κάθε κελί του πίνακα με μέγεθος γραμματοσειράς 10.  
1. Αποθηκεύστε την παρουσίαση στο δίσκο.

```c#
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

//Διασχίστε όλες τις γραμμές
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Διασχίστε όλα τα κελιά στη γραμμή
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Αποκτήστε το πλαίσιο κειμένου κάθε κελιού
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Προσθέστε κάποιο κείμενο
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Ορίστε το μέγεθος γραμματοσειράς του κειμένου σε 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Αποθηκεύστε την παρουσίαση στο δίσκο
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **Παράδειγμα Aspose.Slides for .NET**
Τα παρακάτω βήματα προσθέτουν έναν πίνακα σε μια διαφάνεια Microsoft PowerPoint χρησιμοποιώντας Aspose.Slides:

1. Δημιουργήστε μια παρουσίαση.  
1. Προσθέστε έναν πίνακα 15 x 15 στην πρώτη διαφάνεια.  
1. Προσθέστε κείμενο σε κάθε κελί του πίνακα με μέγεθος γραμματοσειράς 10.  
1. Γράψτε την παρουσίαση στο δίσκο.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Πρόσβαση στην πρώτη διαφάνεια
ISlide sld = pres.Slides[0];

//Ορισμός στηλών με πλάτη και γραμμών με ύψη
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Προσθήκη πίνακα
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Ορισμός μορφής περιγράμματος για κάθε κελί
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Απόκτηση πλαισίου κειμένου κάθε κελιού
		ITextFrame tf = cell.TextFrame;
		//Προσθήκη κειμένου
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Ορισμός μεγέθους γραμματοσειράς 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Αποθήκευση της παρουσίασης στο δίσκο
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```