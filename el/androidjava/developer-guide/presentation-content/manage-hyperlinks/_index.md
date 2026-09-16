---
title: Διαχείριση υπερσυνδέσμων παρουσίασης σε Android
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
description: "Προσθέστε, μορφοποιήστε, ενημερώστε και αφαιρέστε υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για Android μέσω Java, χρησιμοποιώντας παραδείγματα Java."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος συνδέει το περιεχόμενο παρουσίασης με έναν ιστοτόπο ή με μια θέση εντός της παρουσίασης. Στο PowerPoint, οι υπερσύνδεσμοι συνήθως εξυπηρετούν δύο σκοπούς:

* Άνοιγμα ιστοτόπου από κείμενο, σχήμα ή πλαίσιο πολυμέσων.
* Περιήγηση σε άλλη διαφάνεια, για παράδειγμα από πίνακα περιεχομένων.

Aspose.Slides for Android via Java σάς επιτρέπει να προσθέσετε αυτούς τους συνδέσμους, να ελέγξετε την εμφάνιση και τον ήχο τους, να ενημερώσετε τις ιδιότητές τους και να τους αφαιρέσετε. Τα παραδείγματα παρακάτω δείχνουν πώς να δουλέψετε με υπερσυνδέσμους σε μεμονωμένα στοιχεία και πώς να προσπελάσετε υπερσυνδέσμους σε επίπεδο παρουσίασης, διαφάνειας ή πλαίσιου κειμένου.

{{% alert color="info" title="Σημείωση" %}}

Μπορείτε επίσης να επεξεργαστείτε παρουσιάσεις με τον [δωρεάν διαδικτυακό επεξεργαστή Aspose PowerPoint](https://products.aspose.app/slides/el/editor).

{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

Μπορείτε να αντιστοιχίσετε μια διεύθυνση URL ιστοτόπου σε κείμενο, σχήμα ή πλαίσιο πολυμέσων. Το στοιχείο στο οποίο αντιστοιχίζετε τον υπερσύνδεσμο καθορίζει την περιοχή που μπορεί να γίνει κλικ: ένα τμήμα κειμένου συνδέεται με το επιλεγμένο κείμενο, ενώ ένα σχήμα ή πλαίσιο συνδέεται με το αντικείμενο της διαφάνειας.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Για να συνδέσετε κείμενο με έναν ιστότοπο, περάστε ένα [Hyperlink](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/hyperlink/) στη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του τμήματος κειμένου, όπως φαίνεται παρακάτω. Μόνο αυτό το τμήμα κειμένου γίνεται κλικ-ενεργό.

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

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα και Πλαίσια Πολυμέσων**

Για να κάνετε ένα σχήμα ή πλαίσιο κλικ-ενεργό, καλέστε τη μέθοδο [setHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) του. Ο υπερσύνδεσμος ανήκει στο ίδιο το αντικείμενο αντί για τμήμα κειμένου μέσα σε αυτό.

Το ίδιο ισχύει για εικόνες, ήχο και βίντεο: αντιστοιχίστε τον υπερσύνδεσμο στο πλαίσιο και καλέστε το [setTooltip](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) αν χρειάζεται.

Το παρακάτω παράδειγμα κάνει ένα ορθογώνιο κλικ-ενεργό:

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

Οι εσωτερικοί υπερσύνδεσμοι επιτρέπουν στους αναγνώστες να μεταβούν από έναν πίνακα περιεχομένων σε μια συγκεκριμένη διαφάνεια. Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [setInternalHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) για να συνδέσει το κείμενο “Page 2” στην πρώτη διαφάνεια με τη δεύτερη διαφάνεια.

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

Η μέθοδος [setColorSource](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) του [IHyperlink](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/) καθορίζει αν ένας υπερσύνδεσμος χρησιμοποιεί το χρώμα υπερσυνδέσμου της παρουσίασης ή τη μορφοποίηση του τμήματος κειμένου. Για να εφαρμόσετε προσαρμοσμένο χρώμα κειμένου, επιλέξτε το [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/hyperlinkcolorsource/) και ορίστε το χρώμα γεμίσματος του τμήματος. Αυτή η δυνατότητα εισήχθη στο PowerPoint 2019· παλαιότερες εκδόσεις δεν εφαρμόζουν αυτήν τη ρύθμιση.

Το ακόλουθο παράδειγμα προσθέτει δύο υπερσυνδέσμους κειμένου στην ίδια διαφάνεια. Ο πρώτος χρησιμοποιεί κόκκινο γέμισμα κειμένου, ενώ ο δεύτερος διατηρεί το προεπιλεγμένο χρώμα υπερσυνδέσμου.

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

Ένας υπερσύνδεσμος μπορεί να αναπαράγει ήχο όταν ενεργοποιείται ή να σταματήσει ήχο που ήδη αναπαράγεται. Χρησιμοποιήστε τις παρακάτω μεθόδους για να διαμορφώσετε αυτές τις συμπεριφορές:

- [IHyperlink.setSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) καθορίζει τον ήχο που συνδέεται με τον υπερσύνδεσμο.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) ελέγχει αν η ενεργοποίηση του υπερσυνδέσμου σταματά τον προηγούμενο ήχο.

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Το παρακάτω παράδειγμα φορτώνει το `sampleaudio.wav` και το συνδέει με ένα κουμπί στην πρώτη διαφάνεια. Το κλικ στο κουμπί αναπαράγει τον ήχο και μεταβαίνει στην επόμενη διαφάνεια. Ένα δεύτερο σχήμα σε αυτή τη διαφάνεια σταματά τον προηγούμενο ήχο όταν κλικάρεται, χωρίς να εκτελεί ενέργεια μετάβασης.

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

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση που δημιουργήθηκε παραπάνω και διαβάζει τον ήχο υπερσυνδέσμου του πρώτου σχήματος στη μνήμη μέσω των μεθόδων [getSound](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getSound--) και [getBinaryData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

Μπορείτε να καλέσετε τις παρακάτω μεθόδους του [IHyperlink](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/) μετά την ανάθεση ενός υπερσυνδέσμου σε κείμενο ή σχήμα:

- [setTooltip](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) ορίζει το κείμενο που μπορεί να δείξει ο θεατής ως υπόδειξη για τον σύνδεσμο.
- [setTargetFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) καθορίζει το πλαίσιο-στόχο σε ένα γονικό HTML frameset, όταν εφαρμόζεται.
- [setHistory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) ελέγχει αν η ενεργοποίηση του συνδέσμου προσθέτει τον προορισμό του στη λίστα των προβληθέντων υπερσυνδέσμων.
- [setHighlightClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) ελέγχει αν ο υπερσύνδεσμος επισημαίνεται όταν γίνεται κλικ.

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Χρησιμοποιήστε τη μέθοδο [getAnyHyperlinks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) για να συλλέξετε κοντέινερ υπερσυνδέσμων, συμπεριλαμβανομένων των συνδέσμων τμημάτων κειμένου, πριν τα αλλάξετε. Το παρακάτω παράδειγμα αφαιρεί και τους δύο τύπους ενεργοποίησης από την πρώτη διαφάνεια. Για αφαίρεση μόνο ενός τύπου, καλέστε μόνο το [removeHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ή το [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); η αφαίρεση μιας ενέργειας κλικ δεν αφαιρεί το αντίστοιχο mouse‑over.

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

Για αφαίρεση χωρίς προϋποθέσεις, το [removeAllHyperlinks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) αφαιρεί και τους δύο τύπους ενεργοποίησης στο επιλεγμένο εύρος με μία κλήση. Για επιλεκτική εκκαθάριση και κάλυψη των master, layout και σημειώσεων, δείτε το [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Δημιουργία Πλήρους Καταλόγου Υπερσυνδέσμων**

Πριν διανείμετε μια παρουσίαση, καταγράψτε τις διαδραστικές ενέργειές της καθώς και τους διαδικτυακούς συνδέσμους. Το [getAnyHyperlinks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει αντικείμενα [IHyperlinkContainer](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkcontainer/), όχι μια επίπεδη λίστα URL. Εξετάστε τόσο το [getHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) όσο και το [getHyperlinkMouseOver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) σε κάθε κοντέινερ. Είναι ανεξάρτητα: το ίδιο κοντέινερ μπορεί να εκθέτει και τις δύο ενέργειες, έτσι ένας πλήρης αναφορά χρειάζεται έως δύο γραμμές ανά κοντέινερ.

Η σάρωση μόνο υπερσυνδέσμων σε επίπεδο σχήματος μπορεί να παραλείψει συνδέσμους που είναι προσαρτημένοι σε τμήματα κειμένου. Εκτελέστε το ερώτημα στο κατάλληλο εύρος και διατηρήστε τα επιστρεφόμενα κοντέινερ ώστε να μπορείτε αργότερα να ενημερώσετε ή να αφαιρέσετε τις ενέργειές τους.

### **Ερώτημα Ευρών Παρουσίασης, Διαφάνειας και Πλαισίου Κειμένου**

Η διεπαφή [IHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/) είναι διαθέσιμη μέσω του [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), του [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) και του [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Κάθε εύρος υποστηρίζει τα ίδια ερωτήματα:

- [getHyperlinkClicks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) επιστρέφει κοντέινερ με ενέργεια κλικ.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) επιστρέφει κοντέινερ με ενέργεια mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) επιστρέφει κοντέινερ με μία ή και τις δύο ενέργειες.

Το παρακάτω παράδειγμα δημιουργεί το `hyperlink-audit-input.pptx` με έναν εξωτερικό σύνδεσμο κλικ, έναν σύνδεσμο αρχείου mouse‑over, εσωτερική πλοήγηση διαφάνειας, σύνδεσμο κειμένου mouse‑over και ενέργεια μακροεντολής. Δεν εκτελεί καμία από αυτές τις ενέργειες. Τα τρία ερωτήματα λειτουργούν σε κάθε εύρος· οι αριθμοί περιγράφουν κοντέινερ, όχι συνολικό αριθμό ενεργειών. Το εύρος πλαισίου κειμένου εξαιρεί τους συνδέσμους του περιβάλλοντος σχήματος.

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

Σε αυτό το παράδειγμα, τα ερωτήματα παρουσίασης και διαφάνειας αναφέρουν τρία κοντέινερ κλικ, δύο κοντέινερ mouse‑over και τρία κοντέινερ με οποιαδήποτε ενέργεια. Το ερώτημα πλαισίου κειμένου αναφέρει ένα κοντέινερ σε κάθε κατηγορία.

### **Κατάταξη Ενεργειών και Προορισμών**

Χρησιμοποιήστε το [IHyperlink.getActionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getActionType--) για να ερμηνεύσετε μια ενέργεια πριν ερμηνεύσετε τον προορισμό της. Οι τιμές του [HyperlinkActionType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/hyperlinkactiontype/) καλύπτουν περισσότερα από πλοήγηση στο web:

| Τιμές | Σημασία για έλεγχο |
| --- | --- |
| `Hyperlink` | Εξωτερικός υπερσύνδεσμος· ελέγξτε το URL και το σχήμα του. |
| `JumpSpecificSlide` | Εσωτερική πλοήγηση σε συγκεκριμένη διαφάνεια. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ενσωματωμένη πλοήγηση παρουσίασης, επιλύεται στο πλαίσιο παρουσίασης. |
| `JumpEndShow`, `StartCustomSlideShow` | Τερματισμός τρέχουσας παρουσίασης ή έναρξη προσαρμοσμένης παρουσίασης. |
| `StartMacro` | Εκτέλεση μακροεντολής. |
| `StartProgram` | Εκκίνηση προγράμματος. |
| `OpenFile`, `OpenPresentation` | Άνοιγμα αρχείου ή άλλης παρουσίασης· ελέγξτε ξεχωριστά από URL web. |
| `StartStopMedia` | Έναρξη ή τερματισμός αναπαραγωγής πολυμέσων. |
| `NoAction`, `Unknown` | Καμία ενέργεια πλοήγησης ή άγνωστη ενέργεια που απαιτεί έλεγχο. |

Διαβάστε εξωτερικούς προορισμούς μέσω του [getExternalUrl](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) και συγκεκριμένους εσωτερικούς προορισμούς μέσω του [getTargetSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Οι εσωτερικές ενέργειες και οι ενσωματωμένες εντολές ενδέχεται να μην έχουν εξωτερικό URL· ένα κενό URL δεν σημαίνει ότι το κοντέινερ δεν έχει ενέργεια. Διατηρήστε την τιμή που επιστρέφει το [getExternalUrlOriginal](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) όταν διαφέρει από το κανονικοποιημένο URL, και συμπεριλάβετε το tooltip που επιστρέφει το [getTooltip](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) όταν είναι διαθέσιμο.

### **Αναφορά, Καθαρισμός και Επαλήθευση Υπερσυνδέσμων**

Το παρακάτω παράδειγμα Java διαβάζει μια υπάρχουσα παρουσίαση (χρησιμοποιήστε το αρχείο που δημιουργήθηκε παραπάνω), γράφει το `hyperlink-audit.json`, εφαρμόζει μια πολιτική, αποθηκεύει το `hyperlink-sanitized.pptx` και το ξαναανοίγει για να ελέγξει ξανά και τους δύο τύπους ενεργοποίησης. Συλλέγει κοντέινερ πριν τα αλλάξει και χρησιμοποιεί ισότητα αναφοράς για να αποφύγει την επεξεργασία του ίδιου κοντέινερ δύο φορές. Τα ερωτήματα παρουσίασης καλύπτουν τις κανονικές διαφάνειες· για απόθεμα σε επίπεδο πακέτου, ερωτά  επίσης ρητά τα master, layout, σημειώσεις και τους master σημειώσεων/handout όταν υπάρχουν.

Η αναφορά καταγράφει έναν δείκτη διαφάνειας που αρχίζει από το 1 και το [getSlideId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) όταν υπάρχει. Το [ISlideComponent.getSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidecomponent/#getSlide--) παρέχει τη διαφάνεια ιδιοκτήτρια για τα υποστηριζόμενα κοντέινερ. Τα master, layout και σημειώσεις δεν έχουν κανονικό δείκτη διαφάνειας και τα αναγνωρίζουν με το εύρος τους. Τα κοντέινερ σχήματος και τα κοντέινερ μορφοποίησης τμημάτων κειμένου επισημαίνονται ξεχωριστά· άλλοι τύποι κοντέινερ διατηρούν το όνομα του τύπου χρόνου εκτέλεσης. Κάθε κοντέινερ λαμβάνει τοπικό ID αναφοράς ώστε οι δύο ενέργειές του να συσχετιστούν. Η αναφορά αποθηκεύει τους τύπους ενεργειών ως ακέραιες σταθερές που ορίζονται από την αριθμητική σύνολο της Java.

Αυτή η σκόπιμα περιοριστική πολιτική εφαρμογής επιτρέπει μόνο απόλυτες HTTPS URL και έγκυρους εσωτερικούς προορισμούς διαφάνειας. Απορρίπτει μακροεντολές, προγράμματα, ενέργειες αρχείων, άλλες ενέργειες παρουσίασης, άγνωστες ενέργειες και άλλα σχήματα URL. Αυτές οι απορρίψεις είναι αποφάσεις πολιτικής, όχι κρίση ασφαλείας του Aspose.Slides. Το HTTPS μόνο δεν εγγυάται εμπιστοσύνη: προσθέστε λιστές επιτρεπόμενων κεντρικών υπολογιστών και άλλους ελέγχους για την εφαρμογή σας. Ελέγχονται τόσο τα αρχικά όσο και τα κανονικοποιημένα εξωτερικά URLs. Το παράδειγμα ελέγχει μεταδεδομένα χωρίς να ακολουθεί συνδέσμους ή να εκτελεί ενέργειες.

Για αποκατάσταση, ο [getHyperlinkManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager-) του κοντέινερ υποστηρίζει τις μεθόδους [setExternalHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) και [removeHyperlinkMouseOver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Εδώ, τα απαγορευμένα εξωτερικά click links αντικαθίστανται με μια σταθερή σελίδα προορισμού HTTPS· άλλα απαγορευμένα click και mouse‑over ενεργειές αφαιρούνται ανεξάρτητα. Ορίστε το `replaceExternalClicks` σε `false` για να αφαιρέσετε όλες τις παραβάσεις πολιτικής. Επιλέξτε μια σελίδα αντικατάστασης που ανήκει στην εφαρμογή σας πριν από την ανάπτυξη.

Η σημαία εξαγωγής της αναφοράς χρησιμοποιεί μια συντηρητική πολιτική ελέγχου PDF: επισημαίνει τις ενέργειες mouse‑over και ο,τιδήποτε εκτός από εξωτερικό σύνδεσμο ή συγκεκριμένο άλμα διαφάνειας ως ενδέχεται να μην υποστηρίζεται. Είναι μια υπόδειξη ελέγχου, όχι δοκιμή δυνατότητας ή εγγύηση ότι οι μη επισημασμένοι σύνδεσμοι θα διατηρηθούν στην εξαγωγή. Οι υποστηριζόμενες εξαγωγές σε [PDF](/slides/el/androidjava/convert-powerpoint-to-pdf/) και [HTML](/slides/el/androidjava/convert-powerpoint-to-html/) μπορεί να διατηρήσουν υπερσυνδέσμους, ανάλογα με την ενέργεια, τις επιλογές εξαγωγής και το πρόγραμμα προβολής. Οι εξαγώμενες [εικόνες](/slides/el/androidjava/convert-powerpoint-to-png/) και [βίντεο](/slides/el/androidjava/convert-powerpoint-to-video/) δεν μπορούν να διατηρήσουν διαδραστικούς υπερσυνδέσμους· επισημάνετε κάθε ενέργεια όταν ελέγχετε για αυτές τις εξόδους.

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

    // Σειριοποιεί τις επίπεδες σειρές αυτής της αναφοράς χωρίς πρόσθετη εξάρτηση JSON.
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

Με το παραπάνω εισαγώμενο αρχείο, η αναφορά περιέχει πέντε γραμμές ενεργειών. Ο σύνδεσμος αρχείου mouse‑over και το macro click αφαιρούνται, ενώ τα HTTPS links και η εσωτερική πλοήγηση διαφάνειας παραμένουν. Η επαλήθευση εκτυπώνει μηδενικές απαγορευμένες ενέργειες. Ένα εισαγώμενο αρχείο με απαγορευμένο εξωτερικό click URL ενεργοποιεί επίσης τον κλάδο αντικατάστασης. Ένα κοντέινερ με επιτρεπόμενο click και απαγορευμένο mouse‑over διατηρεί την ενέργεια click του.

Αυτή η επιλεκτική εκκαθάριση διαφέρει από το [removeAllHyperlinks](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), το οποίο αφαιρεί και τους δύο τύπους ενεργοποίησης σε όλο το επιλεγμένο εύρος ανεξαρτήτως πολιτικής. Η επαλήθευση εδώ ελέγχει μόνο τις ενέργειες υπερσυνδέσμων· δεν αφαιρεί ενσωματωμένα VBA projects, αντικείμενα OLE ή άλλο ενεργό περιεχόμενο, και δεν επαληθεύει ένα εξαγόμενο αρχείο PDF ή HTML.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να συνδέσω σε μια ενότητα ή στην πρώτη διαφάνειά της;**

Οι ενότητες στο PowerPoint ομαδοποιούν διαφάνειες, αλλά ένας εσωτερικός υπερσύνδεσμος στοχεύει μια μεμονωμένη διαφάνεια. Για να δημιουργήσετε πλοήγηση σε ενότητα, συνδέστε στο πρώτο slide της ενότητας.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία master slide ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία master slide και layout υποστηρίζουν υπερσυνδέσμους. Οι σύνδεσμοι σε αυτά τα στοιχεία είναι διαθέσιμοι κατά την παρουσίαση στις διαφάνειες που χρησιμοποιούν το αντίστοιχο master ή layout.

**Θα διατηρηθούν οι υπερσύνδεσμοι όταν εξάγονται σε PDF, HTML, εικόνες ή βίντεο;**

Οι υποστηριζόμενες εξαγωγές PDF και HTML μπορούν να διατηρήσουν υπερσυνδέσμους· οι raster εικόνες και το βίντεο δεν μπορούν. Δείτε τις παραμέτρους εξαγωγής στο [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).