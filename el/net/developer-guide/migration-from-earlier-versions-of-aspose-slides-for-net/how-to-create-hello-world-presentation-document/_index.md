---
title: Πώς να Δημιουργήσετε Παρουσιάσεις Hello World στο .NET
linktitle: Παρουσίαση Hello World
type: docs
weight: 10
url: /el/net/how-to-create-hello-world-presentation-document/
keywords:
- μετάβαση
- γειά κόσμε
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
description: "Δημιουργήστε μια παρουσίαση PowerPoint PPT, PPTX και ODP Hello World σε .NET με το Aspose.Slides χρησιμοποιώντας τόσο το παραδοσιακό όσο και το σύγχρονο API σε έναν απλό οδηγό."
---
{{% alert color="info" %}} 

Ένα νέο [Aspose.Slides for .NET API](/slides/el/net/) έχει κυκλοφορήσει και τώρα αυτό το μοναδικό προϊόν υποστηρίζει τη δυνατότητα δημιουργίας εγγράφων PowerPoint από το μηδέν και την επεξεργασία των υπαρχόντων.

{{% /alert %}} 
## **Υποστήριξη Παλαιού Κώδικα**
Για να χρησιμοποιήσετε τον κώδικα κληρονομίας που αναπτύχθηκε με εκδόσεις του Aspose.Slides for .NET πριν από την 13.x, πρέπει να κάνετε ορισμένες μικρές αλλαγές στον κώδικά σας και ο κώδικας θα λειτουργεί όπως παλαιότερα. Όλες οι κλάσεις που υπήρχαν στο παλιό Aspose.Slides for .NET στα ονομαστικούς χώρους Aspose.Slide και Aspose.Slides.Pptx έχουν πλέον ενωθεί σε ένα μοναδικό όνομα χώρου Aspose.Slides. Δείτε το παρακάτω απλό απόσπασμα κώδικα για τη δημιουργία ενός παρουσίασης Hello World στο κληρονομικό API του Aspose.Slides και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στο νέο ενοποιημένο API.
## **Προσέγγιση Κληρονομικού Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Δημιουργήστε ένα αντικείμενο Presentation που αντιπροσωπεύει αρχείο PPT
Presentation pres = new Presentation();

//Δημιουργήστε ένα αντικείμενο License
License license = new License();

//Ορίστε την άδεια του Aspose.Slides for .NET για να αποφύγετε τους περιορισμούς αξιολόγησης
license.SetLicense("Aspose.Slides.lic");

//Προσθήκη μιας κενής διαφάνειας στην παρουσίαση και λήψη της αναφοράς της
//της κενής διαφάνειας
Slide slide = pres.AddEmptySlide();

//Προσθήκη ενός ορθογωνίου (X=2400, Y=1800, Πλάτος=1000 & Ύψος=500) στη διαφάνεια
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Απόκρυψη των γραμμών του ορθογωνίου
rect.LineFormat.ShowLines = false;

//Προσθήκη ενός πλαισίου κειμένου στο ορθογώνιο με "Hello World" ως προεπιλεγμένο κείμενο
rect.AddTextFrame("Hello World");

//Αφαίρεση της πρώτης διαφάνειας της παρουσίασης που πάντα προστίθεται από
//το Aspose.Slides for .NET εξ' ορισμού κατά τη δημιουργία της παρουσίασης
pres.Slides.RemoveAt(0);

//Γράψιμο της παρουσίασης ως αρχείο PPT
pres.Write("C:\\hello.ppt");
```



## **Νέα Προσέγγιση Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε Παρουσίαση
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```