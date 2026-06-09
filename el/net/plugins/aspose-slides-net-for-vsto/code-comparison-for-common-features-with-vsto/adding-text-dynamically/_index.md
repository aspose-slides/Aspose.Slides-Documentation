---
title: Προσθήκη Κειμένου Δυναμικά
type: docs
weight: 40
url: /el/net/adding-text-dynamically/
---
Και οι δύο μέθοδοι ακολουθούν τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση.
- Προσθέστε μια κενή διαφάνεια.
- Προσθέστε ένα πλαίσιο κειμένου.
- Ορίστε κάποιο κείμενο.
- Αποθηκεύστε την παρουσίαση.
## **VSTO**
``` csharp

 private void AddTextBox()

{

	//Δημιουργία παρουσίασης

	PowerPoint.Presentation pres = Globals.ThisAddIn.Application

		.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

	//Λήψη κενής διάταξης διαφάνειας

	PowerPoint.CustomLayout layout = pres.SlideMaster.

		CustomLayouts[7];

	//Προσθήκη κενής διαφάνειας

	PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

	//Προσθήκη κειμένου

	PowerPoint.Shape shp =sld.Shapes.AddTextbox

	(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,150, 100, 400, 100);

	//Ορισμός κειμένου

	PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

	txtRange.Text = "Text added dynamically";

	txtRange.Font.Name = "Arial";

	txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;

	txtRange.Font.Size = 32;

	//Αποθήκευση του αποτελέσματος στο δίσκο

	pres.SaveAs("outVSTOAddingText.ppt",

		PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

		Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 static void AddTextBox()

{

	//Δημιουργία παρουσίασης

	Presentation pres = new Presentation();

	//Η κενή διαφάνεια προστίθεται αυτόματα, όταν δημιουργείτε

	//παρουσίαση από τον προεπιλεγμένο κατασκευαστή

	//Έτσι, δεν χρειάζεται να προσθέσουμε καμία κενή διαφάνεια

	Slide sld = pres.GetSlideByPosition(1);

	//Λήψη του δείκτη γραμματοσειράς για Arial

	//Είναι πάντα 0 αν δημιουργήσετε παρουσίαση από

	//προεπιλεγμένο κατασκευαστή

	int arialFontIndex = 0;

	//Προσθήκη πλαισίου κειμένου

	//Για να το προσθέσουμε, πρώτα θα προσθέσουμε ένα ορθογώνιο

	Shape shp = sld.Shapes.AddRectangle(1200, 800, 3200, 370);

	//Απόκρυψη της γραμμής του

	shp.LineFormat.ShowLines = false;

	//Στη συνέχεια προσθέστε ένα πλαίσιο κειμένου μέσα σε αυτό

	TextFrame tf = shp.AddTextFrame("");

	//Ορισμός κειμένου

	tf.Text = "Text added dynamically";

	Portion port = tf.Paragraphs[0].Portions[0];

	port.FontIndex = arialFontIndex;

	port.FontBold = true;

	port.FontHeight = 32;

	//Αποθήκευση του αποτελέσματος στο δίσκο

	pres.Write("outAspose.ppt");

}

``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Text.Dynamically.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Text%20Dynamically%20using%20VSTO%20and%20Aspose.Slides/)