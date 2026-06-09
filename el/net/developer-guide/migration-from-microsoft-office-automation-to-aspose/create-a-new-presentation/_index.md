---
title: Δημιουργία Νέων Παρουσιάσεων Χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Δημιουργία Νέας Παρουσίασης
type: docs
weight: 10
url: /el/net/create-a-new-presentation/
keywords:
- δημιουργία παρουσίασης
- νέα παρουσίαση
- μετάπτωση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μεταφορά από την αυτοματοποίηση του Microsoft Office στο Aspose.Slides για .NET και δημιουργία νέων παρουσιάσεων PowerPoint (PPT, PPTX) σε C# με καθαρό, αξιόπιστο κώδικα."
---
{{% alert color="primary" %}} 

Το VSTO αναπτύχθηκε για να επιτρέπει στους προγραμματιστές να δημιουργούν εφαρμογές που μπορούν να εκτελούνται μέσα στο Microsoft Office. Το VSTO βασίζεται σε COM, αλλά περιβάλλεται μέσα σε ένα αντικείμενο .NET ώστε να μπορεί να χρησιμοποιηθεί σε εφαρμογές .NET. Το VSTO απαιτεί υποστήριξη του .NET framework καθώς και το CLR‑βάσιμο runtime του Microsoft Office. Παρόλο που μπορεί να χρησιμοποιηθεί για τη δημιουργία πρόσθετων του Microsoft Office, είναι σχεδόν αδύνατο να χρησιμοποιηθεί ως εξαρτημένο στοιχείο διακομιστή. Επίσης έχει σοβαρά προβλήματα ανάπτυξης.

Το Aspose.Slides για .NET είναι ένα στοιχείο που μπορεί να χρησιμοποιηθεί για τη διαχείριση παρουσιάσεων Microsoft PowerPoint, όπως το VSTO, αλλά προσφέρει αρκετά πλεονεκτήματα:

- Το Aspose.Slides περιέχει μόνο διαχειριζόμενο κώδικα και δεν απαιτεί την εγκατάσταση του runtime του Microsoft Office.
- Μπορεί να χρησιμοποιηθεί ως στοιχείο στην πλευρά του πελάτη ή ως στοιχείο στην πλευρά του διακομιστή.
- Η ανάπτυξη είναι εύκολη επειδή το Aspose.Slides περιέχεται σε ένα ενιαίο DLL.

{{% /alert %}} 
## **Δημιουργία Παρουσίασης**
Παρακάτω υπάρχουν δύο παραδείγματα κώδικα που δείχνουν πώς μπορούν να χρησιμοποιηθούν το VSTO και το Aspose.Slides για .NET ώστε να επιτευχθεί ο ίδιος στόχος. Το πρώτο παράδειγμα είναι [VSTO](/slides/el/net/create-a-new-presentation/); [το δεύτερο παράδειγμα](/slides/el/net/create-a-new-presentation/) χρησιμοποιεί το Aspose.Slides.
### **Παράδειγμα VSTO**
**Η έξοδος VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Σημείωση: Το PowerPoint είναι ένας χώρος ονόματος που έχει οριστεί παραπάνω όπως αυτό
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


### **Παράδειγμα Aspose.Slides για .NET**
**Η έξοδος από το Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Δημιουργία παρουσίασης
Presentation pres = new Presentation();

//Προσθήκη διαφάνειας τίτλου
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Ορισμός κειμένου τίτλου
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Ορισμός κειμένου υπότιτλου
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Εγγραφή εξόδου στο δίσκο
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```