---
title: Δημιουργία Νέων Παρουσιάσεων Χρησιμοποιώντας VSTO και Aspose.Slides for .NET
linktitle: Δημιουργία Νέας Παρουσίασης
type: docs
weight: 10
url: /el/net/create-a-new-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- μετάβαση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταβείτε από την αυτοματοποίηση Microsoft Office σε Aspose.Slides for .NET και δημιουργήστε νέες παρουσιάσεις PowerPoint (PPT, PPTX) σε C# με καθαρό, αξιόπιστο κώδικα."
---
{{% alert color="info" %}} 

Το VSTO αναπτύχθηκε για να επιτρέπει στους προγραμματιστές να δημιουργούν εφαρμογές που μπορούν να τρέχουν μέσα στο Microsoft Office. Το VSTO βασίζεται σε COM, αλλά είναι τυλίγεται μέσα σε ένα αντικείμενο .NET ώστε να μπορεί να χρησιμοποιηθεί σε εφαρμογές .NET. Το VSTO απαιτεί υποστήριξη του .NET Framework καθώς και το CLR‑βασισμένο runtime του Microsoft Office. Αν και μπορεί να χρησιμοποιηθεί για τη δημιουργία προσθέτων Microsoft Office, είναι σχεδόν αδύνατο να χρησιμοποιηθεί ως στοιχείο διακομιστή. Διαθέτει επίσης σοβαρά προβλήματα ανάπτυξης.

Το Aspose.Slides for .NET είναι ένα στοιχείο που μπορεί να χρησιμοποιηθεί για τη διαχείριση παρουσιάσεων Microsoft PowerPoint, όπως το VSTO, αλλά έχει αρκετά πλεονεκτήματα:

- Το Aspose.Slides περιέχει μόνο διαχειριζόμενο κώδικα και δεν απαιτεί την εγκατάσταση του runtime του Microsoft Office.
- Μπορεί να χρησιμοποιηθεί ως στοιχείο προς το μέρος του πελάτη ή ως στοιχείο προς το μέρος του διακομιστή.
- Η ανάπτυξη είναι εύκολη, καθώς το Aspose.Slides περιλαμβάνεται σε ένα μόνο DLL.

{{% /alert %}} 
## **Δημιουργία Παρουσίασης**
Παρακάτω υπάρχουν δύο παραδείγματα κώδικα που δείχνουν πώς το VSTO και το Aspose.Slides for .NET μπορούν να χρησιμοποιηθούν για την επίτευξη του ίδιου στόχου. Το πρώτο παράδειγμα είναι [VSTO](/slides/el/net/create-a-new-presentation/); [το δεύτερο παράδειγμα](/slides/el/net/create-a-new-presentation/) χρησιμοποιεί το Aspose.Slides.
### **Παράδειγμα VSTO**
**Το αποτέλεσμα VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Σημείωση: Το PowerPoint είναι ένα namespace που έχει οριστεί παραπάνω ως εξής
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Δημιουργία παρουσίασης
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Παράδειγμα Aspose.Slides for .NET**
**Το αποτέλεσμα από το Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Δημιουργία παρουσίασης
Presentation pres = new Presentation();

//Προσθήκη διαφάνειας τίτλου
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Ορισμός κειμένου τίτλου
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Ορισμός κειμένου υποτίτλου
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Γράψιμο εξόδου στο δίσκο
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```