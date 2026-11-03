---
title: "Διαχείριση Placeholder Παρουσίασης σε Android"
linktitle: "Διαχείριση Placeholder"
type: docs
weight: 10
url: /el/androidjava/manage-placeholder/
keywords:
- "θέση κράτησης"
- "placeholder κειμένου"
- "placeholder εικόνας"
- "placeholder γραφήματος"
- "placeholder περιεχομένου"
- "κείμενο προτροπής"
- "PowerPoint"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Μάθετε πώς να ελέγχετε και να επεξεργάζεστε placeholders κειμένου, εικόνας, γραφήματος και περιεχομένου και να κατανοείτε την κληρονόμηση των placeholders με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά μια θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι τα placeholder τίτλου, σώματος, εικόνας, γραφήματος και γενικής χρήσης περιεχομένου. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή από την κύρια διαφάνεια.

Aspose.Slides εμφανίζει πληροφορίες placeholder μέσω της μεθόδου [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/). Η μέθοδος επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) για να καθορίσετε τι προορίζεται να περιέχει το placeholder.

Η διεπαφή σχήματος εξακολουθεί να έχει σημασία αφού γνωρίζετε τον τύπο του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, γραφήματος ή περιεχομένου συνήθως αναπαρίσταται από ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Ένα γεμάτο placeholder εικόνας μπορεί να αναπαριστάται από ένα [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Ένα γεμάτο placeholder γραφήματος μπορεί να αναπαριστάται από ένα [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) όσο και τη διεπαφή σχήματος χρόνου εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) περιγράφει το ρόλο του placeholder· δεν εγγυάται τον τύπο του σχήματος χρόνου εκτέλεσης. Πάντα χρησιμοποιήστε έναν έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, γραφήματος, πίνακα ή ειδικά για πολυμέσα.
{{% /alert %}}

## **Κατανόηση Κληρονόμησης Placeholder**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια διαφάνεια.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλείτε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) για να μετακινηθείτε ένα επίπεδο πάνω στην ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξης· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder της κύριας διαφάνειας. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει base placeholder.

Το ακόλουθο παράδειγμα καταγράφει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα base placeholders τους:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Η επεξεργασία ενός placeholder σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική αντικατάσταση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή της κύριας διαφάνειας μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει base placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Κατάργηση Κατάστασης Placeholder**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) για να κρατήσετε ένα υπάρχον αντικείμενο ως συνηθισμένο σχήμα. Η μέθοδος [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) του επιστρέφει `null`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντίθετα, το [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) διαγράφει το σχήμα από αυτή τη συλλογή.

Το ακόλουθο παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και ένα μη κενό placeholder κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε ένα placeholder με μορφοποίηση κληρονομική από τη διάταξη ή την κύρια διαφάνεια για να δείτε το αποτέλεσμα της αφαίρεσης αυτής της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον συνηθισμένο σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης placeholder δεν διατηρεί αυτόματα τις κληρονομικές ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, έτσι το αποτέλεσμα μπορεί να φαίνεται διαφορετικό. Ένα σχήμα του οποίου η θέση και το μέγεθος κληρονομούνται πλήρως μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο, ακόμη και αν παραμένει στη συλλογή.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Η κλήση της μεθόδου σε ένα συνηθισμένο σχήμα δεν έχει αποτέλεσμα.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Για ένα αντιστοιχισμένο placeholder, και οι τρεις έλεγχοι εμφανίζουν `true`. Το κείμενο παραμένει, αλλά η κληρονομική θέση, το μέγεθος, η περιστροφή, η γραμματοσειρά, η στοίχιση παραγράφου, τα περιθώρια του text-frame, η κάθετη αρδίνωση, οι ρυθμίσεις γεμίσματος και γραμμής μπορούν να αλλάξουν όταν η σχέση του placeholder αφαιρεθεί. Για παράδειγμα, η κληρονομική μορφοποίηση τίτλου μπορεί να επιστρέψει στην μορφοποίηση απλού κειμένου. Δείτε το [Slide Layout](/slides/el/androidjava/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την επιθυμητή εμφάνιση, καταγράψτε τη λύση θέση, το μέγεθος και την περιστροφή πριν την κλήση και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), και [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Μην βασίζεστε μόνο στα αντικείμενα effective-format, διότι οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταγεγραμμένες τιμές στο συνηθισμένο σχήμα μετά, συμπεριλαμβανομένης της οικογένειας γραμματοσειράς, του μεγέθους, του στυλ, του χρώματος, των ρυθμίσεων παραγράφου, των ρυθμίσεων text-frame, του γεμίσματος και της γραμμής που χρησιμοποιούνται από το πρότυπό σας.

Η κληρονομική γεωμετρία του σχήματος μπορεί επίσης να χρειαστεί να οριστεί ρητά μέσω του [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Για ένα ορθογώνιο placeholder κειμένου, αυτό σημαίνει την ανάθεση του [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle). Η αποκατάσταση μόνο του γεμίσματος και της γραμμής μπορεί να μην αποκαταστήσει το ορατό ορθογώνιο. Τα πρότυπα με πρόσθετα εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης τη διαχείριση αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υποτίτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για το [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτό το πρότυπο αποφεύγει την ανάθεση τύπου (casting) των placeholders εικόνας, γραφήματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Επίσης, αναγνωρίζει το placeholder με βάση τον σκοπό του αντί να βασίζεται σε έναν ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Υποδείγματος σε Διάταξη**

Το κείμενο prompt είναι η οδηγία κατά τη διάρκεια του σχεδιασμού που εμφανίζεται σε ένα κενό placeholder, όπως *Κάντε κλικ για προσθήκη τίτλου*. Ορίστε προσαρμοσμένο κείμενο prompt στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) και επαναλάβετε τη συλλογή που επιστρέφει το [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

Το ακόλουθο παράδειγμα αλλάζει τα prompts τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το κείμενο prompt δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, το prompt δεν εμφανίζεται πλέον. Η αλλαγή ενός prompt επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να αντιμετωπιστούν:

- Εάν το placeholder εικόνας είναι ήδη γεμάτο και αναπαρίσταται από ένα [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) και του [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Εάν παραμένει κενό placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) και αφαιρέστε το κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό picture frame, όχι ένα νέο placeholder, επειδή το [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά συγκεκριμένη για placeholder. Εάν η διατήρηση της σχέσης placeholder είναι σημαντική, προετοιμάστε και γεμίστε το placeholder στο PowerPoint πρώτα, κατόπιν ενημερώστε το αποτέλεσμα [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το [Manage Picture Frames](/slides/el/androidjava/picture-frame/). αυτές οι λειτουργίες ανήκουν στο picture frame ή στο picture fill, όχι στα μετα-δεδομένα του placeholder.

## **Δουλειά με Placeholder Γραφήματος και Περιεχομένου**

Ένα γεμάτο placeholder γραφήματος μπορεί να αναπαριστάται από ένα [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Αυτό το παράδειγμα εντοπίζει τέτοιο γράφημα τόσο με βάση τον τύπο του placeholder όσο και τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ένα γενικό placeholder περιεχομένου συνήθως έχει το [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλαπλούς τύπους περιεχομένου, όπως γραφήματα, πίνακες, διαγράμματα, εικόνες και πολυμέσα. Αφού γεμίσει, ελέγξτε τη πραγματική διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εμφανίζουν [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) σε ένα [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) απλώς αλλάζοντας το [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); ο τύπος δεν μπορεί να αλλάξει μέσω της διεπαφής. Για να γεμίσετε ένα κενό γράφημα ή περιοχή περιεχομένου προγραμματιστικά, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα γράφημα:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το προστεθειμένο γράφημα είναι ένα συνηθισμένο τοπικό γράφημα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά [άρθρα διαχείρισης γραφημάτων](/slides/el/androidjava/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε ένα placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα να υποθέτει δείκτη σχήματος ή να κάνει casting σε κάθε placeholder στην ίδια διεπαφή.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Τι είναι ένα base placeholder;**

Ένα base placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στην κύρια διαφάνεια από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας του placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφανειών επεξεργάζόμενος ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομική μορφοποίηση ή το κείμενο prompt μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε το πραγματικό κείμενο του τίτλου σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο διαφάνειας, διάταξη, master, σημειώσεις ή φυλλάδια. Δείτε το [Διαχείριση Κεφαλίδας και Υποσέλιδου Παρουσίασης](/slides/el/androidjava/presentation-header-and-footer/) για πλήρη παραδείγματα.