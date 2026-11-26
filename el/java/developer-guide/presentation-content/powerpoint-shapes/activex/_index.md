---
title: Διαχείριση των ActiveX Controls σε Παρουσιάσεις σε Java
linktitle: ActiveX
type: docs
weight: 80
url: /el/java/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- πρόγραμμα αναπαραγωγής πολυμέσων
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Επεξεργαστείτε τα πλαίσια κειμένου και τα κουμπιά ActiveX, ενημερώστε τις προεπισκοπήσεις των ελέγχων και επαναχρησιμοποιήστε έναν έλεγχο Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java."
---
## **Εισαγωγή**

Τα ActiveX controls παρέχουν σε μια διαφάνεια του PowerPoint διαδραστικά στοιχεία όπως πλαίσια κειμένου, κουμπιά εντολών και αναπαραγωγείς πολυμέσων. Το Aspose.Slides for Java εκθέτει τους ελέγχους μιας διαφάνειας μέσω [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε έναν έλεγχο, να τον μετακινήσετε στη διαφάνεια ή να τον αφαιρέσετε.

## **Λίστα των ActiveX Controls και των Αποθηκευμένων Ιδιοτήτων τους**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τους ελέγχους σε κάθε διαφάνεια. Το παράδειγμα αναφέρει τον αριθμό της διαφάνειας, το όνομα του ελέγχου, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), και κάθε ζευγάρι κλειδί-τιμής στο [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Διαβάζει την παρουσίαση χωρίς να ενεργοποιεί τους ελέγχους, να καλεί συμβάντα ή μακροεντολές, να αλλάζει τιμές ή να αποθηκεύει το αρχείο.

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

Η επιλεγμένη έξοδος από `ActiveX.pptm` δείχνει ένα πλαίσιο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για ελέγχους που χρησιμοποιούν δυαδική αποθήκευση, το [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) μπορεί να επιστρέψει `null`, που εμφανίζεται ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) μετά τον έλεγχο για null. Η αναφορά καταγράφει τις ιδιότητες που είναι διαθέσιμες από την παρουσίαση. Ένας έλεγχος μπορεί να υποστηρίζει πρόσθετες ιδιότητες κατά τη διάρκεια εκτέλεσης.

## **Τροποποίηση ActiveX Controls**

Το παράδειγμα αναμένει μια παρουσίαση με ενεργοποιημένα μακροεντολές που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και τη λεζάντα του κουμπιού. Κάθε έλεγχος διαθέτει επίσης μια στατική προεπισκόπηση που μπορεί να εμφανίσει το PowerPoint πριν από την ενεργοποίηση. Παρέχετε ένα PNG για κάθε έλεγχο που δείχνει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αναθέτει αυτές τις εικόνες μέσω του [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Το παράδειγμα μετακινεί κάθε έλεγχο στην πρώτη διαφάνεια προς τα κάτω κατά 100 μονάδες καθορίζοντας το πλαίσιο του με το [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM και, στη συνέχεια, χρησιμοποιεί το [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλους τους ActiveX controls αφαιρεμένους από εκείνη τη διαφάνεια.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
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

## **Προσθήκη ελέγχου ActiveX Media Player**

Για να επαναχρησιμοποιήσετε έναν ρυθμισμένο έλεγχο Windows Media Player, ξεκινήστε με ένα πρότυπο της πρώτης διαφάνειας του οποίου περιέχει έναν αναγνώστη με όνομα `WindowsMediaPlayer1`. Το [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του αναγνώστη στη [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως την μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, επομένως επιλέξτε μια διαδρομή που ο αναγνώστης μπορεί να προσπελάσει κατά την αναπαραγωγή.

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

## **FAQ**

**Μπορεί το Aspose.Slides να διατηρήσει τα ActiveX controls χωρίς να τα εκτελέσει;**

Ναι. Το Aspose.Slides μπορεί να διαβάσει και να αποθηκεύσει τους ελέγχους, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τους ενεργοποιήσει.

**Πώς διαφέρουν τα ActiveX controls από τα αντικείμενα OLE;**

Τα ActiveX controls επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή κάνοντας κλικ σε ένα κουμπί. Ένα [OLE object](/slides/el/java/manage-ole/) επιτρέπει στη διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας Excel.

**Θα ενεργοποιούν τα γεγονότα ActiveX ακόμη και τα VBA macros μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή που υποστηρίζει μακροεντολές, όπως PPTM, για να διατηρήσετε το έργο VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο τα ActiveX controls όσο και τις μακροεντολές.