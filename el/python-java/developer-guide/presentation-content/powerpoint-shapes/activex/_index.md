---
title: "Διαχείριση των ActiveX Controls σε Παρουσιάσεις με Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /el/python-java/activex/
keywords:
- "ActiveX"
- "ActiveX control"
- "διαχείριση ActiveX"
- "προσθήκη ActiveX"
- "τροποποίηση ActiveX"
- "αναπαραγωγέας πολυμέσων"
- "PowerPoint"
- "παρουσίαση"
- "Python"
- "Aspose.Slides"
description: "Μάθετε πώς το Aspose.Slides for Python μέσω Java χρησιμοποιεί το ActiveX για την αυτοματοποίηση και βελτίωση των παρουσιάσεων PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο πάνω στις διαφάνειες."
---
## **Εισαγωγή**

Τα ActiveX controls χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for Python μέσω Java σας επιτρέπει να προσθέσετε και να διαχειριστείτε ActiveX controls, αλλά είναι λίγο πιο δύσκολο να διαχειριστούν σε σύγκριση με τα κανονικά σχήματα παρουσίασης. Το Aspose.Slides υποστηρίζει την προσθήκη Media Player ActiveX controls. Σημειώστε ότι τα ActiveX controls δεν είναι σχήματα· δεν αποτελούν μέρος της [ShapeCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/shapecollection/) της παρουσίασης. Αντίθετα, αποτελούν μέρος της ξεχωριστής [ControlCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/controlcollection/). Σε αυτό το θέμα, θα σας δείξουμε πώς να εργαστείτε με αυτά.

## **Προσθήκη Media Player ActiveX Control σε Διαφάνεια**

Για να προσθέσετε ένα ActiveX Media Player control, ακολουθήστε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και δημιουργήστε ένα κενό παρουσίασμα.
2. Πρόσβαση στη διαφάνεια-στόχο στο [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).
3. Προσθέστε το Media Player ActiveX control χρησιμοποιώντας τη μέθοδο [addControl](https://reference.aspose.com/slides/el/python-java/aspose.slides/controlcollection/#addControl) που εκτίθεται από το [ControlCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/controlcollection/).
4. Πρόσβαση στο Media Player ActiveX control και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.
5. Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να προσθέσετε ένα Media Player ActiveX control σε διαφάνεια:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Δημιουργήστε μια κενή παρουσίαση.
presentation = Presentation()
try:
    # Προσθέστε το Media Player ActiveX control.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Ορίστε τη διαδρομή του βίντεο.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Αποθηκεύστε την παρουσίαση.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Τροποποίηση ενός ActiveX Control**

{{% alert color="info" title="Σημείωση" %}}

Το Aspose.Slides for Python μέσω Java παρέχει στοιχεία για τη διαχείριση των ActiveX controls. Μπορείτε να αποκτήσετε πρόσβαση στο ήδη προστιθέμενο ActiveX control στην παρουσίασή σας και να το τροποποιήσετε ή να το διαγράψετε μέσω των ιδιοτήτων του.

{{% /alert %}}

Για να διαχειριστείτε ένα απλό ActiveX control όπως ένα πλαίσιο κειμένου και ένα απλό κουμπί εντολής σε μια διαφάνεια, κάντε τα εξής:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει ActiveX controls.
2. Λάβετε αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Πρόσβαση στα ActiveX controls της διαφάνειας μέσω του [ControlCollection](https://reference.aspose.com/slides/el/python-java/aspose.slides/controlcollection/).
4. Πρόσβαση στο ActiveX control TextBox1 χρησιμοποιώντας το αντικείμενο [Control](https://reference.aspose.com/slides/el/python-java/aspose.slides/control/).
5. Αλλάξτε τις ιδιότητες του ActiveX control TextBox1, όπως κείμενο, γραμματοσειρά, ύψος γραμματοσειράς και θέση πλαισίου.
6. Πρόσβαση στο δεύτερο ActiveX control που ονομάζεται CommandButton1.
7. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση του.
8. Μετακινήστε τη θέση των πλαισίων των ActiveX controls.
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTM.

Αυτό το παράδειγμα κώδικα, βασισμένο στα παραπάνω βήματα, δείχνει πώς να διαχειριστείτε ένα απλό ActiveX control:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Φορτώστε την παρουσίαση με ActiveX controls.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Πρόσβαση στην πρώτη διαφάνεια.
        slide = presentation.getSlides().get_Item(0)

        # Αλλάξτε το κείμενο του πλαισίου κειμένου.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Αλλάξτε την εναλλακτική εικόνα. Το PowerPoint την αντικαθιστά κατά την ενεργοποίηση του ActiveX,
            # έτσι μπορεί μερικές φορές να παραμείνει αμετάβλητη.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Αλλάξτε τη λεζάντα του κουμπιού.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Αλλάξτε την εναλλακτική εικόνα.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Μετακινήστε τα controls προς τα κάτω κατά 100 μονάδες.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Αφαιρέστε τα controls.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Διατηρεί το Aspose.Slides τα ActiveX controls όταν διαβάζει και ξανααποθηκεύει εάν δεν μπορούν να εκτελεστούν στο περιβάλλον Python;**

Ναι. Το Aspose.Slides τα θεωρεί μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητες και τα πλαίσια τους· η εκτέλεση των ίδιων των controls δεν απαιτείται για τη διατήρησή τους.

**Πώς διαφέρουν τα ActiveX controls από τα αντικείμενα OLE σε μια παρουσίαση;**

Τα ActiveX controls είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πλαίσια κειμένου, media player), ενώ το [OLE](/slides/el/python-java/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (π.χ., ένα φύλλο εργασίας Excel). Αποθηκεύονται και επεξεργάζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα συμβάντα ActiveX και τα VBA macros εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί την υπάρχουσα σήμανση και τα μεταδεδομένα· ωστόσο, τα συμβάντα και τα macros εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.