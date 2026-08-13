---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: ActiveX
type: docs
weight: 80
url: /el/java/activex/
keywords:
- ActiveX
- έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- πρόγραμμα αναπαραγωγής πολυμέσων
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides για Java αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο στις διαφάνειες."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides για Java σας επιτρέπει να προσθέτετε και να διαχειρίζεστε ελέγχους ActiveX, αλλά είναι λίγο πιο δύσκολο να τους διαχειριστείτε σε σύγκριση με τα κανονικά σχήματα παρουσίασης. Υλοποιήσαμε υποστήριξη για την προσθήκη ελέγχου Media Player Active στο Aspose.Slides. Σημειώστε ότι οι έλεγχοι ActiveX δεν είναι σχήματα· δεν αποτελούν μέρος της [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/). Αντί αυτού είναι μέρος της ξεχωριστής [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/). Σε αυτό το θέμα, θα σας δείξουμε πώς να εργάζεστε με αυτά. 

## **Προσθήκη ελέγχου Media Player ActiveX σε διαφάνεια**
Για να προσθέσετε έναν έλεγχο Media Player ActiveX, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και δημιουργήστε ένα κενό αντικείμενο παρουσίασης.  
1. Πρόσβαση στη διαφάνεια‑στόχο στην [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).  
1. Προσθέστε τον έλεγχο Media Player ActiveX χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) που εκτίθεται από το [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/).  
1. Πρόσβαση στον έλεγχο Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.  
1. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.  

Αυτό το δείγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να προσθέσετε έλεγχο Media Player ActiveX σε μια διαφάνεια:

```java
import com.aspose.slides.*;

// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Προσθήκη ελέγχου Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός διαδρομής βίντεο
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Αποθήκευση της παρουσίασης
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση ελέγχου ActiveX**
{{% alert color="info" %}} 

Το Aspose.Slides για Java 7.1.0 και νεότερες εκδοχές είναι εξοπλισμένα με στοιχεία για τη διαχείριση ελέγχων ActiveX. Μπορείτε να αποκτήσετε πρόσβαση στον ήδη προστεθέν έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή να τον διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}} 

Για να διαχειριστείτε έναν απλό έλεγχο ActiveX όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολής σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει ελέγχους ActiveX.  
1. Λάβετε μια αναφορά στη διαφάνεια με βάση τον δείκτη της.  
1. Πρόσβαση στους ελέγχους ActiveX στη διαφάνεια μέσω της [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/).  
1. Πρόσβαση στον έλεγχο TextBox1 ActiveX χρησιμοποιώντας το αντικείμενο [IControl](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrol/).  
1. Αλλάξτε τις ιδιότητες του ελέγχου TextBox1 ActiveX που περιλαμβάνουν κείμενο, γραμματοσειρά, ύψος γραμματοσειράς και θέση πλαισίου.  
1. Πρόσβαση στον δεύτερο έλεγχο που ονομάζεται CommandButton1.  
1. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.  
1. Μετατοπίστε τη θέση των πλαισίων των ελέγχων ActiveX.  
1. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

Αυτό το δείγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε έναν απλό έλεγχο ActiveX: 

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
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // αλλαγή κειμένου TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Αλλαγή εικονιδίου υποκατάστασης. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX,
        // οπότε κάποιες φορές είναι εντάξει να αφήσετε την εικόνα αμετάβλητη.
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

    // Αλλαγή λεζάντας του κουμπιού
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Αλλαγή υποκατάστασης
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

            // μετακίνηση 100 σημείων προς τα κάτω
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // αφαίρεση ελέγχων
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

### Διατηρεί το Aspose.Slides τους ελέγχους ActiveX κατά την ανάγνωση και αποθήκευση εάν δεν μπορούν να εκτελεστούν στο περιβάλλον Java;

Ναι. Το Aspose.Slides τους θεωρεί μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητες και τα πλαίσια τους· η εκτέλεση των ελέγχων δεν απαιτείται για τη διατήρησή τους.

### Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;

Οι έλεγχοι ActiveX είναι διαδραστικοί διαχειριζόμενοι έλεγχοι (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/java/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ. φύλλο εργασίας Excel). Αποθηκεύονται και διαχειρίζονται διαφορετικά και έχουν διαφορετικό μοντέλο ιδιοτήτων.

### Λειτουργούν τα γεγονότα ActiveX και τα μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.