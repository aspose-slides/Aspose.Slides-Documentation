---
title: Πώς να Δημιουργήσετε Παρουσιάσεις Hello World σε .NET
linktitle: Παρουσίαση Hello World
type: docs
weight: 10
url: /el/net/how-to-create-hello-world-presentation-document/
keywords:
- μεταφορά
- γεια κόσμε
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
- description: "Δημιουργήστε μια παρουσίαση PowerPoint PPT, PPTX και ODP Hello World σε .NET με το Aspose.Slides χρησιμοποιώντας τόσο τις παλαιές όσο και τις σύγχρονες APIs σε έναν απλό οδηγό."
---
{{% alert color="primary" %}} 
Μία νέα [Aspose.Slides for .NET API](/slides/el/net/) κυκλοφόρησε και τώρα αυτό το μοναδικό προϊόν υποστηρίζει τη δυνατότητα δημιουργίας αρχείων PowerPoint από το μηδέν και επεξεργασίας των υπαρχόντων.
{{% /alert %}} 
## **Υποστήριξη Παλαιού Κώδικα**
Για να χρησιμοποιήσετε τον κώδικα κληρονομίας που αναπτύχθηκε με εκδόσεις του Aspose.Slides for .NET παλαιότερες από την 13.x, πρέπει να κάνετε μερικές μικρές αλλαγές στον κώδικά σας και ο κώδικας θα λειτουργεί όπως πριν. Όλες οι κλάσεις που υπήρχαν στην παλιά έκδοση του Aspose.Slides for .NET στα ονοματοχώρους Aspose.Slide και Aspose.Slides.Pptx έχουν τώρα συγχωνευτεί σε έναν ενιαίο ονοματοχώρο Aspose.Slides. Ρίξτε μια ματιά στο παρακάτω απλό απόσπασμα κώδικα για δημιουργία ενός εγγράφου παρουσίασης Hello World στην παλαιά Aspose.Slides API και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στο νέο συγχωνευμένο API.
## **Παλαιά Προσέγγιση Aspose.Slides for .NET**
```c#
//Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPT
Presentation pres = new Presentation();

//Δημιουργήστε ένα αντικείμενο License
License license = new License();

//Ορίστε την άδεια του Aspose.Slides for .NET ώστε να αποφύγετε τους περιορισμούς αξιολόγησης
license.SetLicense("Aspose.Slides.lic");

//Προσθήκη μιας κενής διαφάνειας στην παρουσίαση και λήψη της αναφοράς
//αυτής της κενής διαφάνειας
Slide slide = pres.AddEmptySlide();

//Προσθήκη ενός ορθογωνίου (X=2400, Y=1800, Πλάτος=1000 & Ύψος=500) στη διαφάνεια
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Απόκρυψη των γραμμών του ορθογωνίου
rect.LineFormat.ShowLines = false;

//Προσθήκη πλαισίου κειμένου στο ορθογώνιο με "Hello World" ως προεπιλεγμένο κείμενο
rect.AddTextFrame("Hello World");

//Αφαίρεση της πρώτης διαφάνειας της παρουσίασης που πάντα προστίθεται από
//το Aspose.Slides for .NET εξ' ορισμού κατά τη δημιουργία της παρουσίασης
pres.Slides.RemoveAt(0);

//Αποθήκευση της παρουσίασης ως αρχείο PPT
pres.Write("C:\\hello.ppt");
```



## **Νέα Προσέγγιση Aspose.Slides for .NET 13.x**
```c#
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation();

// Απόκτηση της πρώτης διαφάνειας
ISlide sld = (ISlide)pres.Slides[0];

// Προσθήκη AutoShape τύπου Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Προσθήκη ITextFrame στο Rectangle
ashp.AddTextFrame("Hello World");

// Αλλαγή του χρώματος κειμένου σε Μαύρο (που είναι Λευκό από προεπιλογή)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Αλλαγή του χρώματος γραμμής του rectangle σε Λευκό
ashp.ShapeStyle.LineColor.Color = Color.White;

// Αφαίρεση τυχόν μορφοποίησης γεμίσματος στο σχήμα
ashp.FillFormat.FillType = FillType.NoFill;

// Αποθήκευση της παρουσίασης στο δίσκο
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```