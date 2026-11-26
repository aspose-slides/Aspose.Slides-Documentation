---
title: Διαχείριση Ελέγχων ActiveX σε Παρουσιάσεις στο Android
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
description: "Επεξεργασία πεδίων κειμένου και κουμπιών ActiveX, ενημέρωση των προεπισκοπήσεων των ελέγχων και επαναχρησιμοποίηση ελέγχου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX παρέχουν σε μια διαφάνεια του PowerPoint διαδραστικά στοιχεία, όπως πεδία κειμένου, κουμπιά εντολών και προγράμματα αναπαραγωγής πολυμέσων. Το Aspose.Slides για Android μέσω Java εκθέτει τους ελέγχους μιας διαφάνειας μέσω [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον αφαιρέσετε. Στα παρακάτω παραδείγματα, χρησιμοποιήστε διαδρομές αρχείων που η εφαρμογή Android μπορεί να διαβάσει και επιλέξτε μια εγγράψιμη θέση για κάθε παρουσίαση εξόδου.

## **Λίστα Ελέγχων ActiveX και των Αποθηκευμένων Ιδιοτήτων τους**

Για να επιθεωρήσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα αναφέρει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), και κάθε ζεύγος κλειδιού‑τιμής στο [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Διαβάζει την παρουσίαση χωρίς να ενεργοποιήσει τους ελέγχους, να εκτελέσει συμβάντα ή μακροεντολές, να αλλάξει τιμές ή να αποθηκεύσει το αρχείο.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Η επιλεγμένη έξοδος από `ActiveX.pptm` εμφανίζει ένα πεδίο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) μπορεί να επιστρέψει `null`, εμφανιζόμενο ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) μετά τον έλεγχο για `null`. Η αναφορά καταγράφει τις ιδιότητες που είναι διαθέσιμες στην παρουσίαση. Ένας έλεγχος μπορεί να υποστηρίζει πρόσθετες ιδιότητες κατά την εκτέλεση.

## **Τροποποίηση Ελέγχων ActiveX**

Το παράδειγμα αναμένει μια παρουσίαση με δυνατότητα μακροεντολών που περιέχει ένα πεδίο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) για να αλλάξει την τιμή του πεδίου κειμένου και τη λεζάντα του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που το PowerPoint μπορεί να εμφανίσει πριν από την ενεργοποίηση. Παρέχετε ένα PNG για κάθε έλεγχο που δείχνει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αναθέτει αυτές τις εικόνες μέσω του [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 μονάδες ορίζοντας το πλαίσιο του με το [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Αποθηκεύει τη επεξεργασμένη παρουσίαση σε μορφή PPTM, έπειτα χρησιμοποιεί το [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ελέγχους ActiveX αφαιρεμένους από αυτή τη διαφάνεια.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```
## **Προσθήκη Ελέγχου Media Player ActiveX**

Για να επαναχρησιμοποιήσετε έναν προρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο του οποίου η πρώτη διαφάνεια περιέχει έναν αναπαραγωγέα με όνομα `WindowsMediaPlayer1`. Το [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του αναπαραγωγέα στη [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, γι’ αυτό επιλέξτε μια διαδρομή στην οποία ο αναπαραγωγέας να μπορεί να έχει πρόσβαση κατά την αναπαραγωγή.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```
## **Συχνές ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τους ελέγχους ActiveX χωρίς να τους εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει τους ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεων τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE;**

Οι έλεγχοι ActiveX επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [αντικείμενο OLE](/slides/el/androidjava/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα εξαπολύουν τα γεγονότα ActiveX ακόμη μακροεντολές VBA αφού αποθηκεύσω μια παρουσίαση με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή με δυνατότητα μακροεντολών, όπως PPTM, για να διατηρήσετε το έργο VBA της. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο τους ελέγχους ActiveX όσο και τις μακροεντολές.