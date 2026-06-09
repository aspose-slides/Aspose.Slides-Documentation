---
title: "Διαχείριση Zoom Παρουσίασης σε JavaScript"
linktitle: "Διαχείριση Zoom"
type: docs
weight: 60
url: /el/nodejs-java/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με Aspose.Slides για Node.js — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σάς επιτρέπουν να πηδείτε προς και από συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης. Όταν παρουσιάζετε, αυτή η δυνατότητα γρήγορης πλοήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![overview_image](overview.png)

* Για να συνοψίσετε μια ολόκληρη παρουσίαση σε μία διαφάνεια, χρησιμοποιήστε ένα [Περίληψη Zoom](#Summary-Zoom).
* Για να εμφανίσετε μόνο επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Zoom Διαφάνειας](#Slide-Zoom).
* Για να εμφανίσετε μόνο μία ενότητα, χρησιμοποιήστε ένα [Zoom Ενότητας](#Section-Zoom).

## **Zoom Διαφάνειας**

Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να πλοηγηθείτε ελεύθερα μεταξύ διαφανειών με την σειρά που θέλετε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφανειών είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε να τα χρησιμοποιήσετε και σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφάνειες σας βοηθούν να εμβαθύνετε σε πολλαπλά κομμάτια πληροφορίας ενώ νιώθετε ότι βρίσκεστε σε έναν ενιαίο καμβά. 

![overview_image](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ZoomImageType), την κλάση [ZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ZoomFrame) και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).

### **Δημιουργία Πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει νέες διαφάνειες στην παρουσίαση
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Προσθέτει αντικείμενα ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**

Με το Aspose.Slides for Node.js via Java, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα προεπισκόπησης διαφάνειας ως εξής:
1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια στην οποία θα συνδέσετε το πλαίσιο zoom. 
3.	Προσθέστε κείμενο ταυτοποίησης και φόντο στην διαφάνεια.
4.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
5.	Προσθέστε πλαίσια zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει το αντικείμενο ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Μορφοποίηση Πλαισίων Zoom**

Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο σύνθετα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν αρκετές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια με τον εξής τρόπο:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες που θα συνδέσετε με το πλαίσιο zoom. 
3.	Προσθέστε κάποιο κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4.	Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
6.	Ορίστε μια προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7.	Αλλάξτε τη μορφή της γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8.	Αφαιρέστε το φόντο από μια εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
5.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει νέες διαφάνειες στην παρουσίαση
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Δημιουργεί φόντο για τη δεύτερη διαφάνεια
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Δημιουργεί φόντο για την τρίτη διαφάνεια
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Προσθέτει αντικείμενα ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
    zoomFrame1.setImage(picture);
    // Ορίζει μορφοποίηση πλαισίου zoom για το αντικείμενο zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Ρύθμιση για να μην εμφανίζεται φόντο στο αντικείμενο zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom Ενότητας**

Ένα zoom ενότητας είναι ένας σύνδεσμος προς μια ενότητα στην παρουσίασή σας. Μπορείτε να χρησιμοποιήσετε τα zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να τονίσετε πώς συγκεκριμένα κομμάτια της παρουσίασής σας συνδέονται. 

![overview_image](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει την κλάση [SectionZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SectionZoomFrame) και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom ενότητας σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια. 
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Προσθέτει ένα αντικείμενο SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides for Node.js via Java, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom ενότητας με διαφορετική εικόνα προεπισκόπησης διαφάνειας ως εξής:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει μια αναφορά στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Προσθέτει αντικείμενο SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο σύνθετα πλαίσια zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε μια νέα διαφάνεια.
3.	Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4.	Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5.	Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6.	Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη συλλογή Images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη αρχική διαφάνεια από την συνδεόμενη ενότητα*.
10.	Αφαιρέστε το φόντο από μια εικόνα του αντικειμένου zoom ενότητας.
11.	Αλλάξτε τη μορφή της γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα Ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Προσθέτει αντικείμενο SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Μορφοποίηση για SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoom Συνοψίσεων**

Ένα zoom συνοψίσεων λειτουργεί σαν μια σελίδα προορισμού όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το zoom για να μεταβείτε από ένα σημείο της παρουσίασης σε άλλο με οποιαδήποτε σειρά επιθυμείτε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε μέρη ή να επιστρέψετε σε τμήματα της παρουσίασης χωρίς να διακόψετε τη ροή.

![overview_image](sumzoomsel.png)

Για αντικείμενα zoom συνοψίσεων, το Aspose.Slides παρέχει τις κλάσεις [SummaryZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SummaryZoomSection) και [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SummaryZoomSectionCollection) καθώς και μερικές μεθόδους στην κλάση [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ShapeCollection).

### **Δημιουργία Zoom Συνοψίσεων**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom συνοψίσεων σε μια διαφάνεια ως εξής:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε το πλαίσιο zoom συνοψίσεων στην πρώτη διαφάνεια.
4.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom συνοψίσεων σε μια διαφάνεια:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 3", slide);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 4", slide);
    // Προσθέτει ένα αντικείμενο SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Προσθήκη και Αφαίρεση Ενότητα Zoom Συνοψίσεων**

Όλες οι ενότητες σε ένα πλαίσιο zoom συνοψίσεων αντιπροσωπεύονται από αντικείμενα [SummaryZoomSection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SummaryZoomSection), τα οποία αποθηκεύονται στο αντικείμενο [SummaryZoomSectionCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Μπορείτε να προσθέσετε ή να αφαιρέσετε μια ενότητα zoom συνοψίσεων μέσω της κλάσης [SummaryZoomSectionCollection] με τον εξής τρόπο:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom συνοψίσεων στην πρώτη διαφάνεια.
4.	Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5.	Προσθέστε τη δημιουργημένη ενότητα στο πλαίσιο zoom συνοψίσεων.
6.	Αφαιρέστε την πρώτη ενότητα από το πλαίσιο zoom συνοψίσεων.
7.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα πλαίσιο zoom συνοψίσεων:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);
    // Προσθέτει αντικείμενο SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Προσθέτει ενότητα στο Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Αφαιρεί ενότητα από το Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Μορφοποίηση Ενοτήτων Zoom Συνοψίσεων**

Για να δημιουργήσετε πιο σύνθετα αντικείμενα ενότητας zoom συνοψίσεων, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν πολλές επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom συνοψίσεων. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom συνοψίσεων σε ένα πλαίσιο zoom συνοψίσεων ως εξής:

1.	Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation).
2.	Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3.	Προσθέστε ένα πλαίσιο zoom συνοψίσεων στην πρώτη διαφάνεια.
4.	Αποκτήστε ένα αντικείμενο ενότητας zoom συνοψίσεων για το πρώτο αντικείμενο από το `ISummaryZoomSectionCollection`.
7.	Δημιουργήστε ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/PPImage) προσθέτοντας μια εικόνα στη συλλογή images που συνδέεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/Presentation) και θα χρησιμοποιηθεί για το γέμισμα του πλαισίου.
8.	Ορίστε μια προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο zoom ενότητας.
9.	Ορίστε τη δυνατότητα *επιστροφής στη αρχική διαφάνεια από την συνδεόμενη ενότητα*.
11.	Αλλάξτε τη μορφή της γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12.	Αλλάξτε τη διάρκεια της μετάβασης.
13.	Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας JavaScript δείχνει πώς να αλλάξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom συνοψίσεων:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 1", slide);
    // Προσθέτει μια νέα διαφάνεια στην παρουσίαση
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Προσθέτει μια νέα ενότητα στην παρουσίαση
    pres.getSections().addSection("Section 2", slide);
    // Προσθέτει ένα αντικείμενο SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Λαμβάνει το πρώτο αντικείμενο SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Μορφοποίηση για το αντικείμενο SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Αποθηκεύει την παρουσίαση
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να ελέγξω την επιστροφή στη «μητρική» διαφάνεια μετά την προβολή του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectionzoomframe/) διαθέτει τη μέθοδο `setReturnToParent` που, όταν είναι ενεργοποιημένη, επιστρέφει τους θεατές στην αρχική διαφάνεια μετά την επίσκεψη στο περιεχόμενο-στόχο.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom παρέχει τη μέθοδο `setTransitionDuration` ώστε να ελέγχετε πόσο χρόνο διαρκεί το εφέ μετάβασης.

**Υπάρχουν όρια στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρό όριο API που να έχει τεκμηριωθεί. Τα πρακτικά όρια εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και την απόδοση του θεατή. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά να λαμβάνετε υπόψη το μέγεθος του αρχείου και το χρόνο απόδοσης.