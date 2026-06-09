---
title: "Διαχείριση Ελέγχων ActiveX σε Παρουσιάσεις με JavaScript"
linktitle: "ActiveX"
type: docs
weight: 80
url: /el/nodejs-java/activex/
keywords:
- "ActiveX"
- "Έλεγχος ActiveX"
- "Διαχείριση ActiveX"
- "Προσθήκη ActiveX"
- "Τροποποίηση ActiveX"
- "Αναπαραγωγέας πολυμέσων"
- "PowerPoint"
- "παρουσίαση"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Μάθετε πώς το Aspose.Slides για Node.js μέσω Java αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση των παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο στις διαφάνειες."
---
## **Εισαγωγή**

Τα στοιχεία ελέγχου ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides για Node.js μέσω Java σας επιτρέπει να προσθέτετε και να διαχειρίζεστε στοιχεία ελέγχου ActiveX, αλλά είναι λίγο πιο δύσκολα στη διαχείριση σε σύγκριση με τα κανονικά σχήματα παρουσίασης. Υλοποιήσαμε υποστήριξη για την προσθήκη ελέγχου Media Player Active στο Aspose.Slides. Σημειώστε ότι τα στοιχεία ελέγχου ActiveX δεν είναι σχήματα· δεν αποτελούν μέρος του παρουσίασης’s [ShapeCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shapecollection/). Είναι μέρος της ξεχωριστής [ControlCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/controlcollection/) αντί για αυτό. Σε αυτό το θέμα, θα σας δείξουμε πώς να εργαστείτε με αυτά.

## **Προσθήκη Ελέγχου Media Player ActiveX στη Διαφάνεια**
Για να προσθέσετε ένα στοιχείο ελέγχου Media Player ActiveX, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και δημιουργήστε ένα κενό αντικείμενο παρουσίασης.
1. Αποκτήστε πρόσβαση στη διαφάνεια-στόχο στην [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Προσθέστε το έλεγχο Media Player ActiveX χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) που εκτίθεται από το [ControlCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/controlcollection/).
1. Αποκτήστε πρόσβαση στο έλεγχο Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
1. Αποθηκεύστε την παρουσία ως αρχείο PPTX.

Αυτός ο δείγμα κώδικα, με βάση τα παραπάνω βήματα, δείχνει πώς να προσθέσετε το έλεγχο Media Player ActiveX σε μια διαφάνεια:

```javascript
// Δημιουργήστε κενή παρουσία
var pres = new aspose.slides.Presentation();
try {
    // Προσθήκη ελέγχου Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός της διαδρομής του βίντεο
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Αποθήκευση της παρουσίασης
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Τροποποίηση Ελέγχου ActiveX**

Για τη διαχείριση ενός απλού ελέγχου ActiveX όπως ένα πεδίο κειμένου και ένα απλό κουμπί εντολών σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσία που περιέχει ελέγχους ActiveX.
1. Αποκτήστε μια αναφορά στη διαφάνεια με βάση το δείκτη της.
1. Αποκτήστε πρόσβαση στους ελέγχους ActiveX στη διαφάνεια μέσω του [ControlCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/controlcollection/).
1. Αποκτήστε πρόσβαση στο στοιχείο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο [Control](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/control/).
1. Αλλάξτε τις ιδιότητες του στοιχείου ActiveX TextBox1, οι οποίες περιλαμβάνουν κείμενο, γραμματοσειρά, ύψος γραμματοσειράς και θέση πλαισίου.
1. Αποκτήστε πρόσβαση στον δεύτερο έλεγχο με όνομα CommandButton1.
1. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.
1. Μετακινήστε τη θέση των πλαισίων των ελέγχων ActiveX.
1. Γράψτε την τροποποιημένη παρουσία σε αρχείο PPTX.

Αυτός ο δείγμα κώδικα, με βάση τα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε ένα απλό έλεγχο ActiveX:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    var slide = pres.getSlides().get_Item(0);
    // αλλαγή κειμένου TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Αλλαγή εικόνας υποκατάστασης. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX,
        // ώστε μερικές φορές είναι εντάξει να αφήσουμε την εικόνα αμετάβλητη.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Αλλαγή λεζάντας κουμπιού
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Αλλαγή υποκατάστασης
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // μετακίνηση 100 μονάδων προς τα κάτω
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // αφαίρεση ελέγχων
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Συχνές Ερωτήσεις**

**Διατηρεί το Aspose.Slides τα στοιχεία ελέγχου ActiveX κατά την ανάγνωση και επαναεγγραφή εάν δεν μπορούν να εκτελεστούν στο περιβάλλον εκτέλεσης Python;**

Ναι. Το Aspose.Slides τα αντιμετωπίζει ως μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· η εκτέλεση των ίδιων των ελέγχων δεν απαιτείται για την διατήρησή τους.

**Πώς διαφέρουν τα στοιχεία ελέγχου ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Τα στοιχεία ελέγχου ActiveX είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πεδία κειμένου, media player), ενώ το [OLE](/slides/el/nodejs-java/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ., ένα φύλλο εργασίας Excel). Αποθηκεύονται και χειρίζονται διαφορετικά και διαθέτουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα γεγονότα ActiveX και οι μακροεντολές VBA αν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και τα μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.