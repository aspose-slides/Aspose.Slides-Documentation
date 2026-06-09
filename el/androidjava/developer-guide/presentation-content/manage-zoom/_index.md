---
title: Διαχείριση Zoom Παρουσίασης σε Android
linktitle: Διαχείριση Zoom
type: docs
weight: 60
url: /el/androidjava/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με Aspose.Slides για Android μέσω Java — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zooms στο PowerPoint σας επιτρέπουν να μεταβαίνετε σε συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης και να επιστρέφετε από αυτά.Κατά την παρουσίαση, αυτή η δυνατότητα γρήγορης περιήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![overview_image](overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Περίληψη Zoom](#Summary-Zoom).
* Για να εμφανίσετε μόνο τις επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Zoom Διαφάνειας](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Zoom Ενότητας](#Section-Zoom).

## **Zoom Διαφάνειας**
Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να περιηγηθείτε ελεύθερα μεταξύ των διαφανειών με οποιαδήποτε σειρά επιλέγετε χωρίς να διακόπτετε τη ροή της παρουσίασής σας. Τα zoom διαφανειών είναι εξαιρετικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφανειών σας βοηθούν να εμβαθύνετε σε πολλά κομμάτια πληροφορίας ενώ αισθάνεστε ότι βρίσκεστε σε ένα ενιαίο καμβά. 

![overview_image](slidezoomsel.png)

Για αντικείμενα zoom διαφανειών, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ZoomImageType), τη διεπαφή [IZoomFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IZoomFrame) και μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).

### **Δημιουργία Καρέ Zoom**

Μπορείτε να προσθέσετε ένα καρέ zoom σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες θέλετε να συνδέσετε τα καρέ zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε καρέ zoom (με τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα καρέ zoom σε μια διαφάνεια:

``` java
Presentation pres = new Presentation();
try {
    // Προσθέτει νέες διαφάνειες στην παρουσίαση
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

    // Προσθέτει αντικείμενα ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Δημιουργία Καρέ Zoom με Προσαρμοσμένες Εικόνες**
Με το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε ένα καρέ zoom με διαφορετική εικόνα προεπισκόπησης διαφάνειας με αυτόν τον τρόπο:
1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια στην οποία θέλετε να συνδέσετε το καρέ zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στη διαφάνεια.
4.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) το οποίο θα χρησιμοποιηθεί για το γέμισμα του καρέ.
5.	Προσθέστε καρέ zoom (με την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα καρέ zoom με διαφορετική εικόνα:

``` java
Presentation pres = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Δημιουργεί πλαίσιο κειμένου για τη τρίτη διαφάνεια
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Δημιουργεί μια νέα εικόνα για το αντικείμενο Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Προσθέτει το αντικείμενο ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Μορφοποίηση Καρέ Zoom**
Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά καρέ zoom. Για να δημιουργήσετε πιο σύνθετα καρέ zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού καρέ. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα καρέ zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός καρέ zoom σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες θέλετε να συνδέσετε το καρέ zoom. 
3.	Προσθέστε κάποιο κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε καρέ zoom (με τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) το οποίο θα χρησιμοποιηθεί για το γέμισμα του καρέ.
6.	Ορίστε μια προσαρμοσμένη εικόνα για το πρώτο αντικείμενο καρέ zoom.
7.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο καρέ zoom.
8.	Αφαιρέστε το φόντο από μια εικόνα του δεύτερου αντικειμένου καρέ zoom.
5.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη μορφοποίηση ενός καρέ zoom σε μια διαφάνεια: 

``` java 
Presentation pres = new Presentation();
try {
    // Προσθέτει νέες διαφάνειες στην παρουσίαση
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

    // Προσθέτει αντικείμενα ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
    zoomFrame1.setImage(picture);

    // Ορίζει μορφοποίηση πλαισίου zoom για το αντικείμενο zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Ρύθμιση για απόκρυψη φόντου του αντικειμένου zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom Ενότητας**

Ένα zoom ενότητας είναι ένας σύνδεσμος προς μια ενότητα στην παρουσίασή σας. Μπορείτε να χρησιμοποιήσετε τα zoom ενότητας για να επιστρέφετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να αναδείξετε πώς συνδέονται συγκεκριμένα τμήματα της παρουσίασής σας. 

![overview_image](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει τη διεπαφή [ISectionZoomFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISectionZoomFrame) και μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).

### **Δημιουργία Καρέ Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα καρέ zoom ενότητας σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια. 
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία θέλετε να συνδέσετε το καρέ zoom. 
5.	Προσθέστε ένα καρέ zoom ενότητας (με τις αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα καρέ zoom σε μια διαφάνεια:

``` java
Presentation pres = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    // Προσθέτει ένα αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Δημιουργία Καρέ Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides για Android μέσω Java, μπορείτε να δημιουργήσετε ένα καρέ zoom ενότητας με διαφορετική εικόνα προεπισκόπησης διαφάνειας με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία θέλετε να συνδέσετε το καρέ zoom. 
5.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) το οποίο θα χρησιμοποιηθεί για το γέμισμα του καρέ.
5.	Προσθέστε ένα καρέ zoom ενότητας (με την αναφορά στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα καρέ zoom με διαφορετική εικόνα:

``` java 
Presentation pres = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    // Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
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
### **Μορφοποίηση Καρέ Zoom Ενότητας**

Για να δημιουργήσετε πιο σύνθετα καρέ zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού καρέ. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα καρέ zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός καρέ zoom ενότητας σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία θέλετε να συνδέσετε το καρέ zoom. 
5.	Προσθέστε ένα καρέ zoom ενότητας (με τις αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) το οποίο θα χρησιμοποιηθεί για το γέμισμα του καρέ.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο καρέ zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
10.	Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου καρέ zoom ενότητας.
11.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο καρέ zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη μορφοποίηση ενός καρέ zoom ενότητας:

``` java
Presentation pres = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    // Προσθέτει αντικείμενο SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Μορφοποίηση για το SectionZoomFrame
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

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom Περίληψης**

Ένα zoom περίληψης λειτουργεί όπως μια αρχική σελίδα όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το zoom για να μεταβείτε από ένα σημείο της παρουσίασής σας σε άλλο με οποιαδήποτε σειρά θέλετε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε τμήματα ή να επανεπισκεφθείτε μέρη του slideshow χωρίς να διακόπτετε τη ροή της παρουσίασής σας.

![overview_image](sumzoomsel.png)

Για αντικείμενα zoom περίληψης, το Aspose.Slides παρέχει τις διεπαφές [ISummaryZoomFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomSection) και [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) καθώς και μεθόδους στην διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection).

### **Δημιουργία Zoom Περίληψης**

Μπορείτε να προσθέσετε ένα καρέ zoom περίληψης σε μια διαφάνεια με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε το καρέ zoom περίληψης στην πρώτη διαφάνεια.
4.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να δημιουργήσετε ένα καρέ zoom περίληψης σε μια διαφάνεια:

``` java 
Presentation pres = new Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);

    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);

    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 3", slide);

    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
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

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Περίληψης**

Όλες οι ενότητες σε ένα καρέ zoom περίληψης αντιπροσωπεύονται από αντικείμενα [ISummaryZoomSection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomSection), τα οποία αποθηκεύονται στο αντικείμενο [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Μπορείτε να προσθέσετε ή να αφαιρέσετε ένα αντικείμενο ενότητας zoom περίληψης μέσω της διεπαφής [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα καρέ zoom περίληψης στην πρώτη διαφάνεια.
4.	Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5.	Προσθέστε την δημιουργημένη ενότητα στο καρέ zoom περίληψης.
6.	Αφαιρέστε την πρώτη ενότητα από το καρέ zoom περίληψης.
7.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα καρέ zoom περίληψης:

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

    //Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Προσθέτει μια ενότητα στο Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Αφαιρεί ενότητα από το Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Μορφοποίηση Ενοτήτων Zoom Περίληψης**

Για να δημιουργήσετε πιο σύνθετα αντικείμενα ενότητας zoom περίληψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού καρέ. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom περίληψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom περίληψης σε ένα καρέ zoom περίληψης με αυτόν τον τρόπο:

1.	Δημιουργήστε μια παρουσίαση δημιουργώντας ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνεις.
3.	Προσθέστε ένα καρέ zoom περίληψης στην πρώτη διαφάνεια.
4.	Αποκτήστε ένα αντικείμενο ενότητας zoom περίληψης για το πρώτο αντικείμενο από το `ISummaryZoomSectionCollection`.
7.	Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPPImage) προσθέτοντας μια εικόνα στη συλλογή images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) το οποίο θα χρησιμοποιηθεί για το γέμισμα του καρέ.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο καρέ zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
11.	Αλλάξτε τη μορφοποίηση της γραμμής για το δεύτερο αντικείμενο καρέ zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom περίληψης:

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

    // Λαμβάνει το πρώτο αντικείμενο SummaryZoomSection
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

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «μητρική» διαφάνεια μετά την προβολή του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sectionzoomframe/) διαθέτει συμπεριφορά επιστροφής‑στο‑γονέα που, όταν ενεργοποιείται, στέλνει τους θεατές πίσω στη διαφάνεια προέλευσης μετά την επίσκεψη στο περιεχόμενο-στόχο.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει ορισμό διάρκειας μετάβασης ώστε μπορείτε να ελέγχετε πόσο χρόνο διαρκεί το εφέ μετάβασης.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός API που να έχει τεκμηριωθεί. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και την απόδοση του θεατή. Μπορείτε να προσθέσετε πολλά καρέ Zoom, αλλά πρέπει να ληφθεί υπόψη το μέγεθος του αρχείου και ο χρόνος απόδοσης.