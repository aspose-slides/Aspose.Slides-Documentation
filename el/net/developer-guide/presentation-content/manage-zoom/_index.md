---
title: Διαχείριση Zoom Παρουσίασης σε .NET
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/net/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με Aspose.Slides για .NET — πηγαίνετε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σάς επιτρέπουν να πηδάνετε σε συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης και πίσω. Όταν παρουσιάζετε, αυτή η δυνατότητα γρήγορης πλοήγησης μέσα στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![εικόνα_επισκόπησης](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία μόνο διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#Summary-Zoom).
* Για να εμφανίσετε μόνο τις επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Section Zoom](#Section-Zoom).

## **Zoom Διαφάνειας**
Το Zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να περιηγηθείτε ελεύθερα μεταξύ των διαφανειών με οποιαδήποτε σειρά επιλέγετε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα Zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα Zoom διαφάνειας σας βοηθούν να εμβαθύνετε σε πολλαπλά κομμάτια πληροφορίας ενώ νιώθετε ότι βρίσκεστε σε έναν ενιαίο καμβά. 

![zoom_διαφάνειας](slidezoomsel.png)

Για αντικείμενα slide zoom, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/net/aspose.slides/zoomimagetype), τη διεπαφή [IZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/izoomframe) και μερικές μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection).

### **Δημιουργία Πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom.
3.	Προσθέστε κείμενο αναγνώρισης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει νέες διαφάνειες στην παρουσίαση
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Προσθέτει αντικείμενα ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**
Με το Aspose.Slides για .NET, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα προεπισκόπησης διαφάνειας με αυτόν τον τρόπο: 
1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3.	Προσθέστε κείμενο αναγνώρισης και φόντο στη διαφάνεια.
4.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
5.	Προσθέστε πλαίσια zoom (περιέχοντας την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Δημιουργεί πλαίσιο κειμένου για τη τρίτη διαφάνεια
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Δημιουργεί νέα εικόνα για το αντικείμενο zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Προσθέτει το αντικείμενο ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Μορφοποίηση Πλαισίων Zoom**
Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο πολύπλοκα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια με τον ακόλουθο τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3.	Προσθέστε κάποιο κείμενο αναγνώρισης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
6.	Ορίστε μια προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7.	Αλλάξτε τη μορφοποίηση γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8.	Αφαιρέστε το φόντο από μια εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
9.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει νέες διαφάνειες στην παρουσίαση
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Προσθέτει αντικείμενα ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Δημιουργεί νέα εικόνα για το αντικείμενο ζουμ
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Ορίζει μορφοποίηση πλαισίου ζουμ για το αντικείμενο zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Ρύθμιση για μη εμφάνιση φόντου στο αντικείμενο zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom Ενότητας**

Ένα Zoom ενότητας είναι ένας σύνδεσμος προς μια ενότητα στην παρουσίασή σας. Μπορείτε να χρησιμοποιήσετε τα Zoom ενότητας για να επιστρέφετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να αναδείξετε πώς συγκεκριμένα τμήματα της παρουσίασής σας συνδέονται. 

![zoom_ενότητας](seczoomsel.png)

Για αντικείμενα section zoom, το Aspose.Slides παρέχει τη διεπαφή [ISectionZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/isectionzoomframe) και μερικές μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection).

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom ενότητας σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε μια νέα διαφάνεια. 
3.	Προσθέστε φόντο αναγνώρισης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    // Προσθέτει ένα αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides για .NET, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom ενότητας με διαφορετική εικόνα προεπισκόπησης διαφάνειας με αυτόν τον τρόπο: 

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο αναγνώρισης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει την αναφορά στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    // Δημιουργεί νέα εικόνα για το αντικείμενο ζουμ
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο πολύπλοκα πλαίσια zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας σε μια διαφάνεια με τον ακόλουθο τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο αναγνώρισης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο πλαίσιο zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από τη συνδεδεμένη ενότητα*. 
10.	Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου zoom ενότητας.
11.	Αλλάξτε τη μορφοποίηση γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    // Προσθέτει αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Μορφοποίηση για SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom Περίληψης**

Ένα Zoom περίληψης είναι σαν μια σελίδα προσγείωσης όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το zoom για να μεταβείτε από ένα σημείο της παρουσίασής σας σε άλλο με οποιαδήποτε σειρά θέλετε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε τμήματα ή να επιστρέψετε σε τμήματα της παρουσίασής σας χωρίς να διακόψετε τη ροή της παρουσίασης.

![zoom_περίληψης](sumzoomsel.png)

Για αντικείμενα summary zoom, το Aspose.Slides παρέχει τις διεπαφές [ISummaryZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomsection) και [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomsectioncollection) καθώς και μερικές μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection).

### **Δημιουργία Zoom Περίληψης**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom περίληψης σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε το πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 2", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 3", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 4", slide);

    // Προσθέτει ένα αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Περίληψης**

Όλες οι ενότητες σε ένα πλαίσιο zoom περίληψης εκπροσωπούνται από αντικείμενα [ISummaryZoomFrameSection](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomsection) που αποθηκεύονται στο αντικείμενο [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomsectioncollection). Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας zoom περίληψης μέσω της διεπαφής [ISummaryZoomSectionCollection] με τον εξής τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4.	Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5.	Προσθέστε τη δημιουργημένη ενότητα στο πλαίσιο zoom περίληψης.
6.	Αφαιρέστε την πρώτη ενότητα από το πλαίσιο zoom περίληψης.
7.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 2", slide);

    // Προσθέτει αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Προσθέτει ενότητα στο Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Αφαιρεί ενότητα από το Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Μορφοποίηση Ενοτήτων Zoom Περίληψης**

Για να δημιουργήσετε πιο πολύπλοκα αντικείμενα ενότητας zoom περίληψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom περίληψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom περίληψης σε ένα πλαίσιο zoom περίληψης με τον εξής τρόπο:

1.	Δημιουργήστε μια παρουσίαση με τη κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο αναγνώρισης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4.	Λάβετε ένα αντικείμενο ενότητας zoom περίληψης για το πρώτο αντικείμενο από το `ISummaryZoomSectionCollection`.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage) προσθέτοντας μια εικόνα στη συλλογή images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και θα χρησιμοποιηθεί για την πλήρωση του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από τη συνδεδεμένη ενότητα*. 
11.	Αλλάξτε τη μορφοποίηση γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.Sections.AddSection("Section 2", slide);

    // Προσθέτει αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Λαμβάνει το πρώτο αντικείμενο SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Μορφοποίηση για το αντικείμενο SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Αποθηκεύει την παρουσίαση
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «γονική» διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/net/aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/net/aspose.slides/sectionzoomframe/) διαθέτει τη συμπεριφορά `ReturnToParent` που, όταν ενεργοποιηθεί, επιστρέφει τον θεατή στην αρχική διαφάνεια μετά την επίσκεψη στο περιεχόμενο-στόχο.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει τον ορισμό μιας `TransitionDuration` ώστε μπορείτε να ελέγξετε πόσο χρόνο διαρκεί η κίνηση μετάβασης.

**Υπάρχουν όρια στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρό όριο API που να έχει τεκμηριωθεί. Τα πρακτικά όρια εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις δυνατότητες του προβολέα. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά πρέπει να λάβετε υπόψη το μέγεθος του αρχείου και τον χρόνο απόδοσης.