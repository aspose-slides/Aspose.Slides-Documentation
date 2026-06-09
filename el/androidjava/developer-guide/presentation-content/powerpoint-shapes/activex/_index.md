---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις στο Android
linktitle: ActiveX
type: docs
weight: 80
url: /el/androidjava/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- αναπαραγωγέας πολυμέσων
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides for Android μέσω Java αξιοποιεί το ActiveX για να αυτοματοποιήσει και να βελτιώσει τις παρουσιάσεις PowerPoint, δίνοντας στους προγραμματιστές ισχυρό έλεγχο πάνω στις διαφάνειες."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for Android μέσω Java σάς επιτρέπει να προσθέτετε και να διαχειρίζεστε ελέγχους ActiveX, αλλά είναι λίγο πιο δύσκολος στην διαχείριση σε σύγκριση με τα κανονικά σχήματα της παρουσίασης. Υλοποιήσαμε υποστήριξη για την προσθήκη του ελέγχου Media Player Active στο Aspose.Slides. Σημειώστε ότι οι έλεγχοι ActiveX δεν είναι σχήματα· δεν αποτελούν μέρος του [IShapeCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/) της παρουσίασης. Αντίθετα, είναι μέρος του ξεχωριστού [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/) . Σε αυτό το θέμα, θα σας δείξουμε πώς να εργάζεστε με αυτούς.

## **Προσθήκη ελέγχου Media Player ActiveX σε διαφάνεια**
Για να προσθέσετε ένα έλεγχο Media Player ActiveX, κάντε τα εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και δημιουργήστε ένα κενό αντικείμενο παρουσίασης.
2. Προσεγγίστε τη διαφάνεια‑στόχο στην [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
3. Προσθέστε το έλεγχο Media Player ActiveX χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) που εκτίθεται από το [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/).
4. Προσεγγίστε το έλεγχο Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να προσθέσετε το έλεγχο Media Player ActiveX σε μια διαφάνεια:

```java
// Δημιουργήστε κενή παρουσίαση
Presentation pres = new Presentation();
try {
    // Προσθήκη του ελέγχου Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Προσπελάστε τον έλεγχο Media Player ActiveX και ορίστε τη διαδρομή του βίντεο
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Αποθηκεύστε την παρουσίαση
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση ελέγχου ActiveX**
{{% alert color="primary" %}} 

Το Aspose.Slides for Android μέσω Java 7.1.0 και νεότερες εκδόσεις διαθέτουν στοιχεία για τη διαχείριση ελέγχων ActiveX. Μπορείτε να προσπελάσετε τον ήδη προστιθέμενο έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή να τον διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}} 

Για να διαχειριστείτε έναν απλό έλεγχο ActiveX όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολής σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει ελέγχους ActiveX.
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Προσεγγίστε τους ελέγχους ActiveX στη διαφάνεια μέσω του [IControlCollection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrolcollection/).
4. Προσεγγίστε το έλεγχο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο [IControl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icontrol/).
5. Αλλάξτε τις ιδιότητες του ελέγχου ActiveX TextBox1, που περιλαμβάνουν το κείμενο, τη γραμματοσειρά, το ύψος γραμματοσειράς και τη θέση του πλαισίου.
6. Προσεγγίστε το δεύτερο στοιχείο ελέγχου με όνομα CommandButton1.
7. Αλλάξτε την ετικέτα του κουμπιού, τη γραμματοσειρά και τη θέση.
8. Μετακινήστε τη θέση των πλαισίων των ελέγχων ActiveX.
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε έναν απλό έλεγχο ActiveX: 

```java
// Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.getSlides().get_Item(0);

    // Αλλαγή κειμένου του TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Αλλαγή εικονιδίου υποκατάστασης. Το PowerPoint θα αντικαταστήσει αυτή την εικόνα κατά την ενεργοποίηση του ActiveX,
        // οπότε κάποιες φορές είναι εντάξει να αφήσουμε την εικόνα αμετάβλητη.
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

## **Συχνές Ερωτήσεις**

**Το Aspose.Slides διατηρεί τους ελέγχους ActiveX κατά την ανάγνωση και την επαναφορά, εάν δεν μπορούν να εκτελεστούν στο περιβάλλον Java;**

Ναι. Το Aspose.Slides τα θεωρεί μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· η εκτέλεση των ίδιων των ελέγχων δεν απαιτείται για τη διατήρησή τους.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Οι έλεγχοι ActiveX είναι διαδραστικοί διαχειριζόμενοι έλεγχοι (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/androidjava/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ., ένα φύλλο εργασίας Excel). Αποθηκεύονται και αντιμετωπίζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα συμβάντα ActiveX και οι μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και μεταδεδομένα· ωστόσο, τα συμβάντα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.