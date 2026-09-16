---
title: Διαχείριση υπερσυνδέσμων παρουσίασης σε Java
linktitle: Διαχείριση υπερσυνδέσμων
type: docs
weight: 20
url: /el/java/manage-hyperlinks/
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
- Java
- Aspose.Slides
description: "Προσθήκη, μορφοποίηση, ενημέρωση και αφαίρεση υπερσυνδέσμων σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides for Java, χρησιμοποιώντας παραδείγματα Java."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο μιας παρουσίασης με μια ιστοσελίδα ή με μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστοσελίδας από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Περιήγηση σε άλλη διαφάνεια, για παράδειγμα από πίνακα περιεχομένων.

Aspose.Slides for Java σας επιτρέπει να προσθέτετε αυτούς τους συνδέσμους, να ελέγχετε την εμφάνιση και τον ήχο τους, να ενημερώνετε τις ιδιότητές τους και να τους αφαιρείτε. Τα παραδείγματα παρακάτω δείχνουν πώς να εργαστείτε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να προσπελάσετε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαισίου κειμένου.

{{% alert color="info" title="Note" %}}

Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).

{{% /alert %}} 

## **Προσθήκη Συνδέσμων URL**

Μπορείτε να αναθέσετε μια διεύθυνση URL σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αναθέτετε τον υπερσύνδεσμο καθορίζει την περιοχή που είναι δυνατόν να κάνει κλικ: ένα τμήμα κειμένου συνδέει το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέει το αντικείμενο της διαφάνειας.

### **Προσθήκη Συνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με μια ιστοσελίδα, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/el/java/com.aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-δυνατό.

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

### **Προσθήκη Συνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο δυνατό για κλικ, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο και όχι σε κάποιο τμήμα κειμένου μέσα σε αυτό.

Η ίδια προσέγγιση ισχύει για πλαίσια εικόνων, ήχου και βίντεο: αναθέστε τον υπερσύνδεσμο στο πλαίσιο και, αν χρειάζεται, καλέστε τη [setTooltip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-δυνατό:

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

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [setInternalHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setColorSource-int-) του [IHyperlink](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· οι παλαιότερες εκδόσεις δεν εφαρμόζουν αυτή τη ρύθμιση.

Το παρακάτω παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη παίζει. Χρησιμοποιήστε τις παρακάτω μεθόδους για να ρυθμίσετε αυτή τη συμπεριφορά:

- [IHyperlink.setSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) καθορίζει τον ήχο που συνδέεται με τον υπερσύνδεσμο.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συσχετίζει με ένα κουμπί στην πρώτη διαφάνεια. Κάνοντας κλικ στο κουμπί αναπαράγεται ο ήχος και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα στην ίδια διαφάνεια σταματά τον προηγούμενο ήχο όταν κάνει κλικ, χωρίς να εκτελεί ενέργεια πλοήγησης.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

#### **Ανάκτηση Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε προηγουμένως και διαβάζει τον ήχο του πρώτου σχήματος σε μνήμη μέσω των μεθόδων [getSound](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getSound--) και [getBinaryData](https://reference.aspose.com/slides/el/java/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Tooltip και Ρυθμίσεις Αλληλεπίδρασης**

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [IHyperlink](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/) αφού αναθέσετε έναν υπερσύνδεσμο σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ορίζει το κείμενο που εμφανίζεται ως υπόδειξη για τον σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) καθορίζει το πλαίσιο προορισμού μέσα σε ένα γονικό HTML frameset, όταν ισχύει.
- [setHistory](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) ελέγχει αν η ενεργοποίηση του συνδέσμου προστίθεται στη λίστα των προβληθέντων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε τη μέθοδο [getAnyHyperlinks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) για να συλλέξετε τους κοντέινερ υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τους τροποποιήσετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για αφαίρεση μόνο ενός τύπου, καλέστε μόνο [removeHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ή [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί την αντίστοιχη λειτουργία όταν το ποντίκι βρίσκεται πάνω.

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

Για μη υπό όρους αφαίρεση, η μέθοδος [removeAllHyperlinks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο πεδίο σε μία κλήση. Για επιλεκτικό καθαρισμό και κάλυψη των master, layout και σημειώσεων, δείτε το τμήμα [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς της συνδέσμους. Η μέθοδος [getAnyHyperlinks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/), όχι απλή λίστα URL. Εξετάστε τόσο τη [getHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) όσο και τη [getHyperlinkMouseOver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) σε κάθε κοντέινερ. Είναι ανεξάρτητες: ο ίδιος κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφοράς χρειάζεται έως δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να χάσει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Κάντε ερώτημα στο κατάλληλο πεδίο και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα Στοιχείων Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω των μεθόδων [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), και [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Κάθε πεδίο υποστηρίζει τα ίδια ερωτήματα:

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) επιστρέφει κοντέινερ με ενέργεια ποντικιού πάνω.
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει κοντέινερ με οποιαδήποτε ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με εξωτερικό σύνδεσμο κλικ, σύνδεσμο αρχείου ποντικιού πάνω, εσωτερική πλοήγηση διαφάνειας, σύνδεσμο κειμένου ποντικιού πάνω και δράση μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Τα τρία ερωτήματα λειτουργούν σε κάθε πεδίο· οι μετρήσεις περιγράφουν κοντέινερ, όχι συνολικές ενέργειες. Το πεδίο πλαισίου κειμένου εξαιρεί τους δικούς του συνδέσμους του περιβάλλοντος σχήματος.

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

Σε αυτό το παράδειγμα, τα ερωτήματα παρουσίασης και διαφάνειας καταγράφουν τρία κοντέινερ κλικ, δύο κοντέινερ ποντικιού πάνω και τρία κοντέινερ με οποιαδήποτε ενέργεια. Το ερώτημα πλαισίου κειμένου καταγράφει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατηγοριοποίηση Ενεργειών και Προορισμών**

Χρησιμοποιήστε τη μέθοδο [IHyperlink.getActionType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getActionType--) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/java/com.aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από την πλοήγηση στο web:

| Τιμές | Νόημα για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· εξετάστε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Λήξη τρέχουσας παρουσίασης ή εκκίνηση προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από URL web. |
| `StartStopMedia` | Έναρξη ή διακοπή αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Δεν υπάρχει ενέργεια πλοήγησης ή μη αναγνωρίσιμη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς με τη μέθοδο [getExternalUrl](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getExternalUrl--) και συγκεκριμένους εσωτερικούς προορισμούς με τη [getTargetSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές μπορεί να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι ο κοντέινερ δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει η [getExternalUrlOriginal](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) όταν διαφέρει από το κανονικοποιημένο URL και συμπεριλάβετε το tooltip που επιστρέφει η [getTooltip](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlink/#getTooltip--) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα Java διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε πιο πάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ξαναφορτώνει για να ελέγξει ξανά και τους δύο τύπους ενεργοποίησης. Συλλέγει κοντέινερ πριν τις αλλαγές και χρησιμοποιεί ισότητα αναφοράς ώστε να μην επεξεργαστεί τον ίδιο κοντέινερ δύο φορές. Τα ερωτήματα παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για συνολική καταγραφή σε όλο το πακέτο, ερωτά ρητά και τα master, layout, σημειώσεις και τους master σημειώσεων και εκτυπώσεων όταν υπάρχουν.

Η αναφορά καταγράφει δείκτη διαφάνειας με βάση το 1 και το [getSlideId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getSlideId--) όταν είναι διαθέσιμο. Η μέθοδος [ISlideComponent.getSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidecomponent/#getSlide--) παρέχει τη διαφάνεια-ιδιοκτήτη για υποστηριζόμενα κοντέινερ. Τα master, layout και σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και τα αναγνωρίζουμε με το πεδίο τους. Τα κοντέινερ σχήματος και μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλους τύπους κοντέινερ διατηρούν το όνομα τύπου χρόνου εκτέλεσης. Κάθε κοντέινερ παίρνει τοπικό ID στην αναφορά ώστε οι δύο ενέργειές του να συσχετιστούν. Οι τύποι ενεργειών αποθηκεύονται ως ακέραιες σταθερές του Java enum.

Αυτή η αυστηρή πολιτική εφαρμογής επιτρέπει μόνο απόλυτα HTTPS URLs και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείου, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις αποτελούν αποφάσεις πολιτικής, όχι ασφαλιστική εκτίμηση της Aspose.Slides. Το HTTPS από μόνο του δεν εγγυάται εμπιστοσύνη· προσθέστε λιστές επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Και τα αρχικά και τα κανονικοποιημένα εξωτερικά URLs ελέγχονται. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [getHyperlinkManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) του κοντέινερ υποστηρίζει τις μεθόδους [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Εδώ, οι απαγορευμένοι εξωτερικοί σύνδεσμοι κλικ αντικαθίστανται με μια σταθερή σελίδα προσγείωσης HTTPS· οι άλλοι απαγορευμένοι κλικ και οι απαγορευμένες ενέργειες ποντικιού πάνω αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή πριν την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί συντηρητική πολιτική ελέγχου PDF: σηματοδοτεί ενέργειες ποντικιού πάνω και οτιδήποτε άλλο εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένη μεταπήδηση διαφάνειας ως πιθανώς μη υποστηριζόμενο. Είναι υπόδειξη ελέγχου, όχι δοκιμή ικανότητας ή εγγύηση ότι οι μη σημανμένοι σύνδεσμοι θα διατηρηθούν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές [PDF](/slides/el/java/convert-powerpoint-to-pdf/) και [HTML](/slides/el/java/convert-powerpoint-to-html/) μπορούν να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και το πρόγραμμα προβολής. Οι raster [images](/slides/el/java/convert-powerpoint-to-png/) και [video](/slides/el/java/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· σηματοδοτήστε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // Σειριοποιήστε τις επίπεδες γραμμές αυτής της αναφοράς χωρίς επιπλέον εξάρτηση JSON.
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

Με το παραπάνω δεδομένο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου ποντικιού πάνω και η μακροεντολή κλικ αφαιρούνται, ενώ οι HTTPS σύνδεσμοι και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδενικές απαγορευμένες ενέργειες. Ένα δεδομένο που περιέχει απαγορευμένο εξωτερικό σύνδεσμο κλικ επίσης ενεργοποιεί το κλάδο αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο κλικ και απαγορευμένο ποντίκι πάνω διατηρεί την ενέργεια κλικ του.

Αυτός ο επιλεκτικός καθαρισμός διαφέρει από την [removeAllHyperlinks](https://reference.aspose.com/slides/el/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) που αφαιρεί και τις δύο ενέργειες σε όλο το επιλεγμένο πεδίο ανεξαρτήτως πολιτικής. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες των υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, ούτε επικυρώνει το εξαγόμενο αρχείο PDF ή HTML.

## **ΣΥΧΝΑ ΕΡΩΤΗΣΗΣ (FAQ)**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει σε μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε την πρώτη διαφάνεια της ενότητας.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία master slide ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία του master slide και του layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά τη διάρκεια της παρουσίασης στις διαφάνειες που χρησιμοποιούν τον αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML ενδέχεται να διατηρήσουν τους υπερσυνδέσμους· οι raster εικόνες και τα βίντεο δεν μπορούν. Δείτε τις σημειώσεις εξαγωγής στο τμήμα [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).