---
title: Διαχείριση Placeholder Παρουσιάσεων σε Java
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/java/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να επιθεωρείτε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοήσετε την κληρονομικότητα των σύμβολων κράτησης με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που κρατά μια θέση για έναν συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι οι placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένας placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή μια κύρια διαφάνεια.

Η Aspose.Slides εκθέτει πληροφορίες placeholder μέσω της μεθόδου [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) . Η μέθοδος επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) για να καθορίσετε τι προορίζεται να περιέχει ο placeholder.

Η διεπαφή του σχήματος εξακολουθεί να είναι σημαντική αφού γνωρίζετε τον τύπο του placeholder:

- Ένας κενός placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου αντιπροσωπεύεται συνήθως από ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Ένας γεμάτος placeholder εικόνας μπορεί να αντιπροσωπευθεί από ένα [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Ένας γεμάτος placeholder διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Ένας placeholder περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) όσο και τη διεπαφή σχήματος χρόνου εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) περιγράφει τον ρόλο ενός placeholder· δεν εγγυάται τον τύπο σχήματος χρόνου εκτέλεσης. Πάντα να κάνετε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε κείμενο, εικόνα, διάγραμμα, πίνακα ή μέλη ειδικά για πολυμέσα.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Placeholder**

Οι placeholders σχηματίζουν ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders σε επίπεδο master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια.
3. Μια κανονική διαφάνεια περιέχει τους placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) για να μετακινήσετε ένα επίπεδο επάνω σε αυτήν την ιεραρχία. Ένας placeholder διαφάνειας συνήθως επιστρέφει τον placeholder της διάταξής του· ένας placeholder διάταξης μπορεί να επιστρέψει τον placeholder της κύριας. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα παραθέτει τους placeholders στην πρώτη διαφάνεια και αναφέρει τους βασικούς τους placeholders:

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

Η επεξεργασία ενός placeholder σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική αντικατάσταση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή της κύριας μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αφαίρεση Κατάστασης Placeholder**

Κατά την προσαρμογή ενός προτύπου, χρησιμοποιήστε το [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) για να διατηρήσετε ένα υπάρχον αντικείμενο ως συνηθισμένο σχήμα. Η μέθοδός του [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) επιστρέφει `null`, αλλά το σχήμα παραμένει στη συλλογή της διαφάνειας. Αντιθέτως, το [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) διαγράφει το σχήμα από εκείνη τη συλλογή.

Το παρακάτω παράδειγμα απαιτεί το `template.pptx` με τουλάχιστον μία διαφάνεια και έναν μη-κενό placeholder κειμένου στην πρώτη διαφάνεια. Χρησιμοποιήστε έναν placeholder με μορφοποίηση κληρονομημένη από τη διάταξη ή το master για να δείτε το αποτέλεσμα της αφαίρεσης αυτής της σχέσης. Το παράδειγμα ελέγχει ότι το ίδιο σχήμα παραμένει, καλεί ξανά τη μέθοδο στο πλέον συνηθισμένο σχήμα και αποθηκεύει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η αφαίρεση της κατάστασης placeholder δεν διατηρεί αυτόματα τις κληρονομημένες ρυθμίσεις εμφάνισης. Το παρακάτω παράδειγμα αφήνει σκόπιμα αυτές τις ρυθμίσεις αμετάβλητες, έτσι το αποτέλεσμα μπορεί να φαίνεται διαφορετικό. Ένα σχήμα του οποίου η θέση και το μέγεθος κληρονομούνται πλήρως μπορεί να έχει μηδενικές συντεταγμένες και διαστάσεις μετά την κλήση και να γίνει αόρατο παρόλο που παραμένει στη συλλογή.
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

        // Η κλήση της μεθόδου σε ένα συνηθισμένο σχήμα δεν έχει καμία επίδραση.
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

Για έναν αντιστοιχούντα placeholder, και οι τρεις έλεγχοι εκτυπώνουν `true`. Το κείμενο παραμένει, αλλά η κληρονομημένη θέση, μέγεθος, περιστροφή, γραμματοσειρά, στοίχιση παραγράφου, περιθώρια πλαισίου κειμένου, κατακόρυφη αγκύρωση, γέμισμα και ρυθμίσεις γραμμής μπορούν να αλλάξουν όταν η σχέση placeholder αφαιρεθεί. Για παράδειγμα, η κληρονομημένη μορφοποίηση τίτλου μπορεί να επιστρέψει σε απλή μορφοποίηση κειμένου. Δείτε το [Slide Layout](/slides/el/java/slide-layout/) για περισσότερα σχετικά με τις διατάξεις.

Για να διατηρήσετε την προοριζόμενη εμφάνιση, καταγράψτε τη διευκρινισμένη θέση, μέγεθος και περιστροφή πριν από την κλήση και αντιγράψτε τις απαιτούμενες τιμές αποτελεσματικής μορφοποίησης σε ξεχωριστές μεταβλητές. Ανακτήστε αυτές τις τιμές μέσω των μεθόδων [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), και [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Μην βασίζεστε μόνο στα αντικείμενα αποτελεσματικής μορφοποίησης, επειδή οι τιμές μορφοποίησης κειμένου τους μπορούν να αλλάξουν μετά την αφαίρεση της σχέσης. Εφαρμόστε ρητά τις καταχωρημένες τιμές στο συνηθισμένο σχήμα μετά, συμπεριλαμβανομένης της οικογένειας γραμματοσειράς, μεγέθους, στυλ, χρώματος, ρυθμίσεων παραγράφου, ρυθμίσεων πλαισίου κειμένου, γέμισματος και γραμμής που χρησιμοποιεί το πρότυπό σας.

Η κληρονομημένη γεωμετρία του σχήματος μπορεί επίσης να χρειαστεί ρητή εκχώρηση μέσω του [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Για έναν ορθογώνιο placeholder κειμένου, αυτό σημαίνει την εκχώρηση του [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); η αποκατάσταση μόνο του γέμισματος και της γραμμής μπορεί να μην επαναφέρει το ορατό ορθογώνιο. Τα πρότυπα με πρόσθετα εφέ ή πιο σύνθετη μορφοποίηση απαιτούν επίσης την επεξεργασία αυτών των ρυθμίσεων.

## **Αλλαγή Κειμένου σε Placeholder**

Οι placeholders τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) πριν χρησιμοποιήσετε τη μέθοδό του [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

Αυτό το παράδειγμα ενημερώνει τον πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

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

Αυτό το μοτίβο αποφεύγει την μετατροπή placeholder εικόνας, διαγράμματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Επίσης, εντοπίζει τον placeholder με βάση τον σκοπό του αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία σε χρόνο σχεδίασης που εμφανίζεται σε έναν κενό placeholder, π.χ. *Click to add title*. Ορίστε προσαρμοσμένο κείμενο προτροπής στον placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Προσπελάστε τη διάταξη μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) και επαναλάβετε πάνω στη συλλογή που επιστρέφει το [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές τίτλου και υποτίτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πια. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις προς επεξεργασία:

- Αν ο placeholder εικόνας είναι ήδη γεμάτος και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) και του [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Αν είναι ακόμη κενός placeholder, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του placeholder με το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) και αφαιρέστε τον κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Η αντικατάσταση που δημιουργείται για έναν κενό placeholder είναι ένα τοπικό πλαίσιο εικόνας, όχι ένας νέος placeholder, επειδή το [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά ειδική για placeholder. Αν η διατήρηση της σχέσης placeholder είναι κρίσιμη, προετοιμάστε και γεμίστε τον placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) με την Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνα, δείτε το [Manage Picture Frames](/slides/el/java/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στη γεμιστική εικόνα, όχι στα μεταδεδομένα του placeholder.

## **Εργασία με Placeholder Διαγραμμάτων και Περιεχομένου**

Ένας γεμάτος placeholder διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα με βάση τόσο τον τύπο placeholder όσο και τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένας γενικός placeholder περιεχομένου έχει συνήθως [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, συμπεριλαμβανομένων διαγραμμάτων, πινάκων, διαγραμμάτων, εικόνων και πολυμέσων. Αφού γεμίσει, ελέγξτε τη πραγματική διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Η Aspose.Slides δεν μετατρέπει έναν κενό placeholder [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) σε [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) απλώς αλλάζοντας το [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); ο τύπος δεν μπορεί να αλλάξει μέσω της διεπαφής. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και, στη συνέχεια, αφαιρέστε τον κενό placeholder. Το παρακάτω παράδειγμα κάνει αυτό για ένα διάγραμμα:

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

Το προστεθειμένο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων ([chart management articles](/slides/el/java/powerpoint-charts/)) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω παράδειγμα από άκρη σε άκρη ανοίγει ένα πρότυπο, ψάχνει στην πρώτη διαφάνεια είτε για placeholder τίτλου είτε για εικόνας, ελέγχει τους τύπους placeholder και σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση δείκτη σχήματος ή τη μετατροπή κάθε placeholder στην ίδια διεπαφή.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

## **Συχνές Ερωτήσεις**

**Τι είναι ένας βασικός placeholder;**

Ένας βασικός placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο ένας άλλος placeholder κληρονομεί. Χρησιμοποιήστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν είναι μέρος της ιεραρχίας placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους των διαφάνειων επεξεργάζοντας έναν placeholder διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε πραγματικά το κείμενο τίτλου σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο – διαφάνεια, διάταξη, master, σημειώσεις ή φυλλάδιο. Δείτε το [Manage Presentation Header and Footer](/slides/el/java/presentation-header-and-footer/) για πλήρη παραδείγματα.