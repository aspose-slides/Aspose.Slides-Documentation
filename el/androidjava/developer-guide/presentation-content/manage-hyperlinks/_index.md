---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης στο Android
linktitle: Διαχείριση Υπερσυνδέσμων
type: docs
weight: 20
url: /el/androidjava/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Android μέσω Java, χρησιμοποιώντας παραδείγματα Java."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με μια ιστοσελίδα ή μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστοσελίδας από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Πλοήγηση σε άλλη διαφάνεια, για παράδειγμα, από πίνακα περιεχομένων.

Το Aspose.Slides για Android μέσω Java σας επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παρακάτω παραδείγματα δείχνουν πώς να δουλέψετε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να αποκτήσετε πρόσβαση σε υπερσυνδέσμους στο επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}
Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με το [δωρεάν διαδικτυακό πρόγραμμα επεξεργασίας Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Προσθήκη URL Υπερσυνδέσμων**

Μπορείτε να αντιστοιχίσετε ένα URL ιστοσελίδας σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο ανατίθεται ο υπερσύνδεσμος καθορίζει την περιοχή κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

Για παρουσιάσεις που περιέχουν σχετικούς υπερσυνδέσμους, δείτε [Διαχείριση της βάσης του υπερσυνδέσμου](/slides/el/androidjava/presentation-properties/#manage-the-hyperlink-base) για ανάγνωση, αλλαγή ή εκκαθάριση της βάσης σε επίπεδο εγγράφου.

### **Προσθήκη URL Υπερσυνδέσμων σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ‑συμβατό.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Προσθήκη URL Υπερσυνδέσμων σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ‑συμβατό, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για εικόνες, ήχο και πλαίσια βίντεο: αντιστοιχίστε τον υπερσύνδεσμο στο πλαίσιο και καλέστε τη μέθοδο [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) εφόσον χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ‑συμβατό:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) του [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσύνδεσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο χρώμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ήχος**

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να διακόψει ήχο που ήδη αναπαράγεται. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτές τις συμπεριφορές:

* [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) καθορίζει το ηχητικό αρχείο που σχετίζεται με τον υπερσύνδεσμο.
* [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου διακόπτει τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου Υπερσυνδέσμου**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί, αναπαράγεται ο ήχος και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια διακόπτει τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια πλοήγησης.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Εξαγωγή Ήχου Υπερσυνδέσμου**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε προηγουμένως και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των μεθόδων [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) και [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Ρυθμίσεις Υπόδειξης (Tooltip) και Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) μετά την ανάθεση υπερσυνδέσμου σε κείμενο ή σχήμα:

* [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ορίζει το κείμενο που μπορεί να εμφανίσει ο θεατής ως υπόδειξη για τον σύνδεσμο.
* [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) καθορίζει το πλαίσιο προορισμού μέσα σε ένα γονικό HTML frameset, όταν ισχύει.
* [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβλεπόμενων υπερσυνδέσμων.
* [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε το [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) για τη συλλογή των containers υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για να αφαιρέσετε μόνο έναν τύπο, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί την αντίστοιχη ενέργεια mouse‑over.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Για απαράβατη αφαίρεση, το [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο πεδίο με μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, κάντε εφορία των διαδραστικών ενέργειών της καθώς και των διαδικτυακών συνδέσμων της. Το [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/), όχι μια απλή λίστα συμβολοσειρών URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) σε κάθε container. Είναι ανεξάρτητα: το ίδιο container μπορεί να εκθέτει και τις δύο ενέργειες, οπότε μια πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά container.

Η σάρωση μόνο των υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσμους που είναι συνδεδεμένοι σε τμήματα κειμένου. Κάντε ερώτημα στο κατάλληλο πεδίο αντί αυτού και διατηρήστε τα επιστρεφόμενα containers ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα σε Επίπεδα Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω των [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), και [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Κάθε πεδίο υποστηρίζει τις ίδιες ερωτήσεις:

* [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) επιστρέφει containers με ενέργεια κλικ.
* [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) επιστρέφει containers με ενέργεια mouse‑over.
* [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει containers με είτε ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, έναν σύνδεσμο κειμένου mouse‑over και μια ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Οι ίδιες τρεις ερωτήσεις λειτουργούν σε κάθε πεδίο· οι αριθμοί περιγράφουν containers, όχι σύνολα ενεργειών. Το πεδίο πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Για αυτό το παράδειγμα, οι ερωτήσεις παρουσίασης και διαφάνειας αναφέρουν τρία containers κλικ, δύο containers mouse‑over, και τρία containers με είτε ενέργεια. Η ερώτηση πλαισίου κειμένου αναφέρει ένα container σε κάθε κατηγορία.

### **Κατηγοριοποίηση Δράσεων και Προορισμών**

Χρησιμοποιήστε το [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Values | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται σε πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Λήξη της τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από web URLs. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή μη αναγνωρισμένη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς από το [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) και συγκεκριμένους εσωτερικούς προορισμούς από το [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το container δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει το [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε την υπόδειξη (tooltip) που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) όταν είναι διαθέσιμη.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα Java διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ανοίγει ξανά για να ελέγξει και τις δύο ενέργειες ενεργοποίησης. Συλλέγει containers πριν τα αλλάξει και χρησιμοποιεί ισότητα αναφοράς για να αποφύγει την επεξεργασία του ίδιου container δύο φορές. Οι ερωτήσεις παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για εφορία σε όλο το πακέτο, ερωτά ρητά επίσης τα master, τα layout, τις σημειώσεις και τα master σημειώσεων/δείγματος όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας αρχής από το 1 και το [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) όπου είναι διαθέσιμο. Το [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) παρέχει τη διαφάνεια κτήματος για υποστηριζόμενα containers. Τα master, τα layout και οι σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και προσδιορίζονται με το πεδίο τους. Τα containers σχήματος και τα containers μορφοποίησης τμημάτων κειμένου χαρακτηριστούν ξεχωριστά· άλλοι τύποι containers διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε container λαμβάνει ένα τοπικό ID στην αναφορά ώστε οι δύο ενέργειές του να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενέργειας ως ακέραιους σταθερούς που ορίζονται από την κλήση Java.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλες σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι απόφαση ασφαλείας του Aspose.Slides. Το HTTPS μόνο δεν εγγυάται εμπιστοσύνη: προσθέστε λίστας επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει τα μεταδεδομένα χωρίς να ακολουθήσει συνδέσμους ή να εκτελέσει ενέργειες.

Για διόρθωση, το [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) του container υποστηρίζει τα [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλοι απαγορευμένοι κλικ και απαγορευμένες ενέργειες mouse‑over αφαιρούνται ανεξαρτήτως. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβιάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια επιφυλακτική πολιτική ελέγχου PDF: σημαίνει ενέργειες mouse‑over και οτιδήποτε εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι υποδείξη ελέγχου, όχι δοκιμή δυνατοτήτων ή εγγύηση ότι οι μη σημειωμένοι σύνδεσμοι θα παραμείνουν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) και [HTML](/slides/el/androidjava/convert-powerpoint-to-html/) ενδέχεται να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και τον προβολέα. Τα ραστερ [images](/slides/el/androidjava/convert-powerpoint-to-png/) και [video](/slides/el/androidjava/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σημαίνετε κάθε ενέργεια όταν κάνετε έλεγχο για αυτές τις εξόδους.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Σειριοποίηση των ισοπεδωμένων γραμμών αυτής της αναφοράς χωρίς πρόσθετη εξάρτηση JSON.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Με το παραπάνω εισαγόμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και ο κλικ μακροεντολής αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εμφανίζει μηδέν απαγορευμένες ενέργειες. Ένα είσοδο που περιέχει απαγορευμένο εξωτερικό URL κλικ επίσης εκτελεί το κλάδο αντικατάστασης. Ένα container με επιτρεπόμενο κλικ και απαγορευμένο mouse‑over διατηρεί την ενέργεια κλικ.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο πεδίο ανεξάρτητα από την πολιτική. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσύνδεσμου· δεν αφαιρεί ενσωματωμένα έργα VBA, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επικυρώνει ένα εξαχθέν PDF ή HTML αρχείο.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη της διαφάνεια;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει μια συγκεκριμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε μια ενότητα, συνδέστε στην πρώτη διαφάνεια εκείνης της ενότητας.

**Μπορώ να προσθέσω έναν υπερσύνδεσμο σε στοιχεία master διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master διαφάνειας και του layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML ενδέχεται να διατηρήσουν τους υπερσυνδέσμους· τα ραστερ εικόνας και το βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).