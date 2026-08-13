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
description: "Δημιουργήστε μια παρουσίαση Hello World PowerPoint PPT, PPTX και ODP σε .NET με το Aspose.Slides, χρησιμοποιώντας τόσο την κληρονομική όσο και τη σύγχρονη API, σε έναν απλό οδηγό."
---
{{% alert color="info" %}} 

Ένα νέο [Aspose.Slides for .NET API](/slides/el/net/) έχει κυκλοφορήσει και πλέον αυτό το ενιαίο προϊόν υποστηρίζει τη δυνατότητα δημιουργίας εγγράφων PowerPoint από το μηδενικό και την επεξεργασία των υφιστάμενων.

{{% /alert %}} 
## **Υποστήριξη Παλαιού Κώδικα**
Για να χρησιμοποιήσετε τον κώδικα κληρονομιάς που αναπτύχθηκε με εκδόσεις του Aspose.Slides for .NET προγενέστερες της 13.x, πρέπει να κάνετε μερικές μικρές αλλαγές στον κώδικά σας και ο κώδικας θα λειτουργεί όπως πριν. Όλες οι κλάσεις που υπήρχαν στην παλιά έκδοση του Aspose.Slides for .NET στα namespaces Aspose.Slide και Aspose.Slides.Pptx έχουν πλέον συγχωνευτεί σε ένα ενιαίο namespace Aspose.Slides. Παρακαλούμε δείτε το παρακάτω απλό απόσπασμα κώδικα για τη δημιουργία ενός εγγράφου Παρουσίασης Hello World στην κληρονομική API του Aspose.Slides και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στη νέα συγχωνευμένη API.
## **Κληρονομική Προσέγγιση Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο PPT
Presentation pres = new Presentation();

//Δημιουργεί ένα αντικείμενο License
License license = new License();

//Ορίζει την άδεια του Aspose.Slides για .NET ώστε να αποφευχθούν οι περιορισμοί αξιολόγησης
license.SetLicense("Aspose.Slides.lic");

//Προσθήκη κενού διαφάνειας στην παρουσίαση και λήψη της αναφοράς του
//αυτής της κενής διαφάνειας
Slide slide = pres.AddEmptySlide();

//Προσθήκη ενός ορθογωνίου (X=2400, Y=1800, Πλάτος=1000 & Ύψος=500) στη διαφάνεια
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Απόκρυψη των γραμμών του ορθογωνίου
rect.LineFormat.ShowLines = false;

//Προσθήκη πλαισίου κειμένου στο ορθογώνιο με "Hello World" ως προεπιλεγμένο κείμενο
rect.AddTextFrame("Hello World");

//Αφαίρεση της πρώτης διαφάνειας της παρουσίασης, η οποία προστίθεται πάντα από
//το Aspose.Slides για .NET ως προεπιλογή κατά τη δημιουργία της παρουσίασης
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **Νέα Προσέγγιση Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία Presentation
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