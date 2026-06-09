---
title: Δημιουργία μιας Νέας Παρουσίασης σε VSTO και Aspose.Slides
type: docs
weight: 80
url: /el/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Παρακάτω παρουσιάζονται δύο παραδείγματα κώδικα που δείχνουν πώς μπορούν να χρησιμοποιηθούν το VSTO και το Aspose.Slides για .NET για να επιτύχουν τον ίδιο στόχο.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Λάβετε τη διάταξη διαφάνειας τίτλου

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Προσθέστε μια διαφάνεια τίτλου.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Ορίστε το κείμενο του τίτλου

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Ορίστε το κείμενο του υπότιτλου

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Γράψτε το αποτέλεσμα στο δίσκο

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Δημιουργία παρουσίασης
	Presentation pres = new Presentation();

	//Προσθήκη διαφάνειας τίτλου
	Slide slide = pres.AddTitleSlide();

	//Ορισμός κειμένου τίτλου
	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Ορισμός κειμένου υπότιτλου
	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Εγγραφή εξόδου στο δίσκο
	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Λήψη Δείγματος Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)