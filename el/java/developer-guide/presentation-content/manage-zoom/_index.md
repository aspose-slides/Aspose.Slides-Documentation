---
title: Διαχείριση Zoom παρουσίασης σε Java
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με το Aspose.Slides για Java — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint επιτρέπουν να μεταβαίνετε σε συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης και να επιστρέφετε από αυτές. Κατά τη διάρκεια μιας παρουσίασης, αυτή η δυνατότητα γρήγορης πλοήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![overview_image](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία μόνο διαφάνεια, χρησιμοποιήστε ένα [Zoom περίληψης](#Summary-Zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Zoom διαφάνειας](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Zoom ενότητας](#Section-Zoom).

## **Zoom διαφάνειας**
Ένα Zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να πλοηγηθείτε ελεύθερα μεταξύ διαφανειών με τη σειρά που επιθυμείτε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα Zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε επίσης να τα χρησιμοποιήσετε σε διαφορετικά σενάρια παρουσίασης.

Τα Zoom διαφάνειας σας βοηθούν να εμβαθύνσετε σε πολλαπλά κομμάτια πληροφορίας ενώ νιώθετε ότι βρίσκεστε σε έναν ενιαίο καμβά. 

![overview_image](slidezoomsel.png)

Για αντικείμενα Zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ZoomImageType), τη διεπαφή [IZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/IZoomFrame) και κάποιες μεθόδους κάτω από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).

### **Δημιουργία πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο Zoom σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια Zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια Zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει νέες διαφάνειες στην παρουσίαση
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Προσθέτει αντικείμενα ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Δημιουργία πλαισίων Zoom με προσαρμοσμένες εικόνες**
Με το Aspose.Slides for Java, μπορείτε να δημιουργήσετε ένα πλαίσιο Zoom με διαφορετική εικόνα προεπισκόπησης διαφάνειας με τον εξής τρόπο: 
1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε το πλαίσιο Zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στη διαφάνεια.
4.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
5.	Προσθέστε πλαίσια Zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Δημιουργεί νέα εικόνα για το αντικείμενο zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Προσθέτει το αντικείμενο ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Μορφοποίηση πλαισίων Zoom**
Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια Zoom. Για να δημιουργήσετε πιο σύνθετα πλαίσια Zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο Zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου Zoom σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε το πλαίσιο Zoom. 
3.	Προσθέστε κάποιο κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια Zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
6.	Ορίστε μια προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου Zoom.
7.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο πλαισίου Zoom.
8.	Αφαιρέστε το φόντο από την εικόνα του δεύτερου αντικειμένου πλαισίου Zoom.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Προσθέτει νέες διαφάνειες στην παρουσίαση
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Προσθέτει αντικείμενα ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Δημιουργεί νέα εικόνα για το αντικείμενο zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
    zoomFrame1.setImage(picture);

    // Ορίζει μορφή πλαισίου zoom για το αντικείμενο zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Ρύθμιση για απόκρυψη φόντου για το αντικείμενο zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom ενότητας**

Ένα Zoom ενότητας είναι ένας σύνδεσμος σε μια ενότητα της παρουσίασής σας. Μπορείτε να χρησιμοποιήσετε τα Zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να αναδείξετε πώς συγκεκριμένα τμήματα της παρουσίασής σας συνδέονται. 

![overview_image](seczoomsel.png)

Για αντικείμενα Zoom ενότητας, το Aspose.Slides παρέχει τη διεπαφή [ISectionZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISectionZoomFrame) και κάποιες μεθόδους κάτω από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).

### **Δημιουργία πλαισίων Zoom ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο Zoom ενότητας σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια. 
3.	Προσθέστε φόντο ταυτοποίησης στην δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο Zoom. 
5.	Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει τις αναφορές στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Προσθέτει ένα αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Δημιουργία πλαισίων Zoom ενότητας με προσαρμοσμένες εικόνες**

Χρησιμοποιώντας το Aspose.Slides for Java, μπορείτε να δημιουργήσετε ένα πλαίσιο Zoom ενότητας με διαφορετική εικόνα προεπισκόπησης διαφάνειας με τον εξής τρόπο: 

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στην δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο Zoom. 
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
5.	Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει μια αναφορά στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Προσθέτει νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Προσθέτει αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Μορφοποίηση πλαισίων Zoom ενότητας**

Για να δημιουργήσετε πιο σύνθετα πλαίσια Zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο Zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου Zoom ενότητας σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στην δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο Zoom. 
5.	Προσθέστε ένα πλαίσιο Zoom ενότητας (που περιέχει αναφορές στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου Zoom ενότητας.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο πλαισίου Zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη μητρική διαφάνεια από την συνδεδεμένη ενότητα*. 
10.	Αφαιρέστε το φόντο από την εικόνα του αντικειμένου Zoom ενότητας.
11.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο πλαισίου Zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Προσθέτει αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Μορφοποίηση για το SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    //Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom περίληψης**

Ένα Zoom περίληψης είναι σαν μια αρχική σελίδα όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το Zoom για να μεταβείτε από ένα σημείο της παρουσίασης σε άλλο με τη σειρά που προτιμάτε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε τμήματα ή να επανεξετάσετε μέρη της παρουσίασής σας χωρίς να διακόψετε τη ροή.

![overview_image](sumzoomsel.png)

Για αντικείμενα Zoom περίληψης, το Aspose.Slides παρέχει τις διεπαφές [ISummaryZoomFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISummaryZoomSection) και [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISummaryZoomSectionCollection) καθώς και κάποιες μεθόδους κάτω από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection).

### **Δημιουργία Zoom περίληψης**

Μπορείτε να προσθέσετε ένα πλαίσιο Zoom περίληψης σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε το πλαίσιο Zoom περίληψης στην πρώτη διαφάνεια.
4.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 3", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 4", slide);

    // Προσθέτει αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Προσθήκη και αφαίρεση ενότητας Zoom περίληψης**

Όλες οι ενότητες σε ένα πλαίσιο Zoom περίληψης αντιπροσωπεύονται από αντικείμενα [ISummaryZoomSection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISummaryZoomSection), τα οποία αποθηκεύονται στην συλλογή [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ISummaryZoomSectionCollection). Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας Zoom περίληψης μέσω της διεπαφής [ISummaryZoomSectionCollection] με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο Zoom περίληψης στην πρώτη διαφάνεια.
4.	Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5.	Προσθέστε την δημιουργημένη ενότητα στο πλαίσιο Zoom περίληψης.
6.	Αφαιρέστε την πρώτη ενότητα από το πλαίσιο Zoom περίληψης.
7.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);

    //Προσθέτει αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Προσθέτει μια νέα ενότητα στην παρουσίαση
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    //Προσθέτει ενότητα στο Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    //Αφαιρεί ενότητα από το Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    //Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Μορφοποίηση ενοτήτων Zoom περίληψης**

Για να δημιουργήσετε πιο σύνθετα αντικείμενα ενότητας Zoom περίληψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας Zoom περίληψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας Zoom περίληψης σε ένα πλαίσιο Zoom περίληψης με τον εξής τρόπο:

1.	Δημιουργήστε μια εμφάνιση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο Zoom περίληψης στην πρώτη διαφάνεια.
4.	Αποκτήστε ένα αντικείμενο ενότητας Zoom περίληψης για το πρώτο αντικείμενο από το `ISummaryZoomSectionCollection`.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) που θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο πλαισίου Zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη μητρική διαφάνεια από την συνδεδεμένη ενότητα*. 
11.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο πλαίσιο Zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);

    // Προσθέτει αντικείμενο SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Παίρνει το πρώτο αντικείμενο SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Μορφοποίηση για το αντικείμενο SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «μητρική» διαφάνεια μετά την εμφάνιση του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/java/com.aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/java/com.aspose.slides/sectionzoomframe/) διαθέτει τη συμπεριφορά `ReturnToParent` που, όταν ενεργοποιηθεί, στέλνει τους θεατές πίσω στη διαφάνεια προέλευσης μετά την επισκευή του περιεχομένου-στόχου.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει τον ορισμό μιας `TransitionDuration`, επιτρέποντάς σας να ελέγξετε πόσο χρόνο διαρκεί η κίνηση.

**Υπάρχουν όρια στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρό όριο API που να τεκμηριώνεται. Τα πρακτικά όρια εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και την απόδοση του προγράμματος προβολής. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά να λάβετε υπόψη το μέγεθος του αρχείου και τον χρόνο απόδοσης.