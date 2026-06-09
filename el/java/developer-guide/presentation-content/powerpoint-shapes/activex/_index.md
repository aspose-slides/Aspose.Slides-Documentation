---
title: "Διαχείριση ActiveX Controls σε Παρουσιάσεις με Java"
linktitle: "ActiveX"
type: docs
weight: 80
url: /el/java/activex/
keywords:
- "ActiveX"
- "Έλεγχος ActiveX"
- "Διαχείριση ActiveX"
- "Προσθήκη ActiveX"
- "Τροποποίηση ActiveX"
- "Πρόγραμμα Αναπαραγωγής Μέσων"
- "PowerPoint"
- "Παρουσίαση"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς το Aspose.Slides for Java αξιοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση των παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο των διαφάνειων."
---
## **Εισαγωγή**

Τα ActiveX controls χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for Java σάς επιτρέπει να προσθέτετε και να διαχειρίζεστε ActiveX controls, αλλά είναι ελαφρώς πιο δύσκολα στη διαχείριση σε σχέση με τα κανονικά σχήματα παρουσίασης. Έχουμε υλοποιήσει υποστήριξη για προσθήκη του Media Player Active control στο Aspose.Slides. Σημειώστε ότι τα ActiveX controls δεν είναι σχήματα· δεν αποτελούν μέρος του [IShapeCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/). Αντίθετα, είναι μέρος του ξεχωριστού [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/) . Σε αυτό το θέμα, θα σας δείξουμε πώς να εργαστείτε με αυτά. 

## **Προσθήκη ενός Media Player ActiveX Control σε μια Διαφάνεια**
Για να προσθέσετε ένα Media Player ActiveX control, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και δημιουργήστε ένα κενό αντικείμενο παρουσίασης.  
2. Προσπελάστε τη διαφάνεια‑στόχο στην [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).  
3. Προσθέστε το Media Player ActiveX control χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) που εκτίθεται από το [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/).  
4. Προσπελάστε το Media Player ActiveX control και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.  
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.  

Αυτό το δείγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να προσθέσετε ένα Media Player ActiveX Control σε μια διαφάνεια:

```java
// Δημιουργία κενής παρουσίασης
Presentation pres = new Presentation();
try {
    // Προσθήκη του ελέγχου Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός της διαδρομής βίντεο
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Αποθήκευση της παρουσίασης
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση ενός ActiveX Control**
{{% alert color="primary" %}} 

Το Aspose.Slides for Java 7.1.0 και νεότερες εκδόσεις διαθέτουν στοιχεία για τη διαχείριση ActiveX controls. Μπορείτε να προσπελάσετε το ήδη προστεθέν ActiveX control στην παρουσίασή σας και να το τροποποιήσετε ή να το διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}} 

Για να διαχειριστείτε ένα απλό ActiveX control όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολής σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει ActiveX controls.  
2. Λάβετε μια αναφορά σε διαφάνεια με βάση το δείκτη της.  
3. Προσπελάστε τα ActiveX controls στη διαφάνεια ανακτώντας το [IControlCollection](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrolcollection/).  
4. Προσπελάστε το ActiveX control TextBox1 χρησιμοποιώντας το αντικείμενο [IControl](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrol/).  
5. Αλλάξτε τις ιδιότητες του ActiveX control TextBox1 που περιλαμβάνουν το κείμενο, τη γραμματοσειρά, το ύψος γραμματοσειράς και τη θέση του πλαισίου.  
6. Προσπελάστε τον δεύτερο έλεγχο πρόσβασης που ονομάζεται CommandButton1.  
7. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.  
8. Μετακινήστε τη θέση των πλαισίων των ActiveX controls.  
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.  

Αυτό το δείγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε ένα απλό ActiveX control: 

```java
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

        // Αλλαγή αντικαταστατικής εικόνας. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX,
        // έτσι μερικές φορές είναι εντάξει να αφήσετε την εικόνα αμετάβλητη.
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
        // Αλλαγή αντικαταστάτη
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

            // μετακίνηση 100 μονάδων κάτω
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

## **Συχνές Ερωτήσεις**

**Το Aspose.Slides διατηρεί τα ActiveX controls κατά την ανάγνωση και επανεγγραφή αν δεν μπορούν να εκτελεστούν στο Java runtime;**

Ναι. Το Aspose.Slides τα αντιμετωπίζει ως μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· η εκτέλεση των ελέγχων δεν απαιτείται για τη διατήρησή τους.

**Πώς διαφέρουν τα ActiveX controls από τα αντικείμενα OLE σε μια παρουσίαση;**

Τα ActiveX controls είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/java/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ. ένα φύλλο εργασίας Excel). Αποθηκεύονται και αντιμετωπίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα γεγονότα ActiveX και οι μακροεντολές VBA αν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και τα μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο στο PowerPoint σε Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.