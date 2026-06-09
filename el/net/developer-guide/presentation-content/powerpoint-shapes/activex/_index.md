---
title: Διαχείριση Στοιχείων Ελέγχου ActiveX σε Παρουσιάσεις στο .NET
linktitle: ActiveX
type: docs
weight: 80
url: /el/net/activex/
keywords:
- ActiveX
- Στοιχείο ελέγχου ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- αναπαραγωγέας πολυμέσων
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides for .NET αξιοποιεί το ActiveX για την αυτοματοποίηση και τη βελτίωση παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο πάνω στις διαφάνειες."
---
## **Εισαγωγή**

Τα στοιχεία ελέγχου ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for .NET σάς επιτρέπει να διαχειρίζεστε στοιχεία ελέγχου ActiveX, αλλά η διαχείρισή τους είναι λίγο πιο δύσκολη και διαφορετική από τα συνηθισμένα σχήματα παρουσίασης. Από το Aspose.Slides for .NET 6.9.0, το στοιχείο υποστηρίζει τη διαχείριση στοιχείων ελέγχου ActiveX. Προς το παρόν, μπορείτε να έχετε πρόσβαση σε ήδη προστιθέμενο στοιχείο ελέγχου ActiveX στην παρουσίασή σας και να το τροποποιήσετε ή να το διαγράψετε χρησιμοποιώντας τις διάφορες ιδιότητές του. Θυμηθείτε, τα στοιχεία ελέγχου ActiveX δεν είναι σχήματα και δεν αποτελούν μέρος του IShapeCollection της παρουσίασης, αλλά του ξεχωριστού IControlCollection. Αυτό το άρθρο δείχνει πώς να εργαστείτε με αυτά.

## **Τροποποίηση Στοιχείων Ελέγχου ActiveX**

1. Δημιουργήστε μια παρουσία της κλάσης Presentation και φορτώστε την παρουσίαση που περιέχει στοιχεία ελέγχου ActiveX.
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Πρόσβαση στα στοιχεία ελέγχου ActiveX στη διαφάνεια μέσω της IControlCollection.
4. Πρόσβαση στο στοιχείο ελέγχου ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο ControlEx.
5. Αλλάξτε τις διάφορες ιδιότητες του στοιχείου ελέγχου ActiveX TextBox1, συμπεριλαμβανομένου του κειμένου, της γραμματοσειράς, του ύψους γραμματοσειράς και της θέσης του πλαισίου.
6. Πρόσβαση στο δεύτερο στοιχείο ελέγχου με όνομα CommandButton1.
7. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.
8. Μετακινήστε τη θέση των πλαισίων των στοιχείων ελέγχου ActiveX.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Το παρακάτω απόσπασμα κώδικα ενημερώνει τα στοιχεία ελέγχου ActiveX στις διαφάνειες της παρουσίασης όπως φαίνεται παρακάτω.

```c#
// Πρόσβαση στην παρουσίαση με στοιχεία ελέγχου ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Πρόσβαση στη πρώτη διαφάνεια της παρουσίασης
ISlide slide = presentation.Slides[0];

// Αλλαγή κειμένου TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Αλλαγή αντικαταστατικής εικόνας. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX, οπότε μερικές φορές είναι εντάξει να αφήνουμε την εικόνα αμετάβλητη.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Αλλαγή λεζάντας κουμπιού
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // Αλλαγή αντικαταστατικού
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Μετακίνηση πλαισίων ActiveX 100 μονάδες προς τα κάτω
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Αποθήκευση της παρουσίασης με επεξεργασμένα στοιχεία ελέγχου ActiveX
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Τώρα αφαιρούνται τα στοιχεία ελέγχου
slide.Controls.Clear();

// Αποθήκευση της παρουσίασης με εκκαθαρισμένα στοιχεία ελέγχου ActiveX
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Προσθήκη Στοιχείου Ελέγχου ActiveX Media Player**

1. Δημιουργήστε μια παρουσία της κλάσης Presentation και φορτώστε τη δοκιμαστική παρουσίαση που περιέχει στοιχεία ελέγχου Media Player ActiveX.
2. Δημιουργήστε μια παρουσία της κλάσης Presentation-στόχου και δημιουργήστε μια κενή παρουσίαση.
3. Κλωνοποιήστε τη διαφάνεια που περιέχει το στοιχείο ελέγχου Media Player ActiveX από την πρότυπη παρουσίαση στο Presentation-στόχο.
4. Πρόσβαση στη κλωνοποιημένη διαφάνεια στο Presentation-στόχο.
5. Πρόσβαση στα στοιχεία ελέγχου ActiveX στη διαφάνεια μέσω της IControlCollection.
6. Πρόσβαση στο στοιχείο ελέγχου Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
7. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```c#
// Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation presentation = new Presentation("template.pptx");

// Δημιουργία κενής παρουσίασης
Presentation newPresentation = new Presentation();

// Αφαίρεση προεπιλεγμένης διαφάνειας
newPresentation.Slides.RemoveAt(0);

// Κλωνοποίηση διαφάνειας με στοιχείο ελέγχου Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Πρόσβαση στο στοιχείο ελέγχου Media Player ActiveX και ορισμός διαδρομής βίντεο
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Αποθήκευση της παρουσίασης
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Διατηρεί το Aspose.Slides τα στοιχεία ελέγχου ActiveX όταν διαβάζει και αποθηκεύει ξανά εάν δεν είναι δυνατόν να εκτελεστούν στο .NET runtime;**

Ναι. Το Aspose.Slides τα θεωρεί μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· η εκτέλεση των ίδιων των ελέγχων δεν απαιτείται για τη διατήρησή τους.

**Πώς διαφέρουν τα στοιχεία ελέγχου ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Τα στοιχεία ελέγχου ActiveX είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/net/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ. ένα φύλλο εργασίας Excel). Αποθηκεύονται και διαχειρίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα συμβάντα ActiveX και οι μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και τα μεταδεδομένα· ωστόσο, τα συμβάντα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.