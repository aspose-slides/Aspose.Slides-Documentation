---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις σε Android
linktitle: ActiveX
type: docs
weight: 80
url: /el/androidjava/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- Διαχείριση ActiveX
- Προσθήκη ActiveX
- Τροποποίηση ActiveX
- Αναπαραγωγέας πολυμέσων
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides for Android via Java αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο στις διαφάνειες."
---
## **Εισαγωγή**

Τα controls ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for Android via Java σάς επιτρέπει να προσθέσετε και να διαχειριστείτε controls ActiveX, αλλά είναι λίγο πιο δύσκολο να τα διαχειριστείτε σε σύγκριση με τα κανονικά σχήματα παρουσίασης. Υλοποιήσαμε υποστήριξη για την προσθήκη του ελέγχου Media Player Active στο Aspose.Slides. Σημειώστε ότι τα controls ActiveX δεν είναι σχήματα· δεν είναι μέρος του [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/). Αντίθετα, ανήκουν στο ξεχωριστό [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/). Σε αυτό το θέμα, θα σας δείξουμε πώς να εργάζεστε με αυτά.

## **Προσθήκη ελέγχου ActiveX Media Player σε διαφάνεια**

Για να προσθέσετε ένα control Media Player ActiveX, κάντε τα εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και δημιουργήστε μια κενή παρουσίαση.
2. Πρόσβαση στη διαφάνεια-στόχο στην [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
3. Προσθέστε το control Media Player ActiveX χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) που εκτίθεται από το [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/).
4. Πρόσβαση στο control Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να προσθέσετε το Media Player ActiveX Control σε μια διαφάνεια:

```java
import com.aspose.slides.*;

// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Προσθήκη ελέγχου Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός της διαδρομής βίντεο
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Αποθήκευση της παρουσίασης
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση ελέγχου ActiveX**
{{% alert color="info" %}} 

Το Aspose.Slides for Android via Java 7.1.0 και νεότερες εκδόσεις είναι εξοπλισμένα με στοιχεία για τη διαχείριση ελέγχων ActiveX. Μπορείτε να αποκτήσετε πρόσβαση στον ήδη προστιθέμενο έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή να τον διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}} 

Για να διαχειριστείτε έναν απλό έλεγχο ActiveX όπως ένα πεδίο κειμένου και ένα απλό κουμπί εντολών σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε ένα αντίτυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση με ελέγχους ActiveX.
2. Λάβετε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.
3. Πρόσβαση στους ελέγχους ActiveX στη διαφάνεια μέσω του [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/).
4. Πρόσβαση στον έλεγχο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο [IControl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrol/).
5. Αλλάξτε τις ιδιότητες του ελέγχου ActiveX TextBox1 που περιλαμβάνουν το κείμενο, τη γραμματοσειρά, το ύψος γραμματοσειράς και τη θέση του πλαισίου.
6. Πρόσβαση στον δεύτερο έλεγχο που ονομάζεται CommandButton1.
7. Αλλάξτε την ετικέτα του κουμπιού, τη γραμματοσειρά και τη θέση του.
8. Μετακινήστε τη θέση των πλαισίων των ελέγχων ActiveX.
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε έναν απλό έλεγχο ActiveX:

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Πρόσβαση στην πρώτη διαφάνεια στην παρουσίαση
    ISlide slide = pres.getSlides().get_Item(0);

    // Αλλαγή κειμένου TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Αλλαγή εναλλακτικής εικόνας. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX,
        // οπότε μερικές φορές είναι εντάξει να αφήσουμε την εικόνα αμετάβλητη.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Αλλαγή λεζάντας κουμπιού
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);

        // Αλλαγή εναλλακτικού
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Μετακίνηση 100 μονάδων προς τα κάτω
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // Κατάργηση ελέγχων
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Συχνές ερωτήσεις**

### Διατηρεί το Aspose.Slides τα ελέγχου ActiveX όταν διαβάζει και ξανασώζει εάν δεν μπορούν να εκτελεστούν στο χρόνο εκτέλεσης της Java;

Ναί. Το Aspose.Slides τα αντιμετωπίζει ως μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητες και τα πλαίσια τους· δεν απαιτείται η εκτέλεση των ελέγχων για τη διατήρησή τους.

### Πώς διαφέρουν τα ελέγχου ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;

Τα ελέγχου ActiveX είναι διαδραστικοί διαχειριζόμενοι έλεγχοι (κουμπιά, πεδία κειμένου, media player), ενώ το [OLE](/slides/el/androidjava/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ. φύλλο Excel). Αποθηκεύονται και αντιμετωπίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

### Λειτουργούν τα γεγονότα ActiveX και τα μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;

Το Aspose.Slides διατηρεί το υπάρχον markup και τα μεταδεδομένα· ωστόσο, τα γεγονότα και τα μακροεντολές εκτελούνται μόνο εντός του PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.