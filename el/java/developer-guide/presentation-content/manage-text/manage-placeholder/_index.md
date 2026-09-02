---
title: Διαχείριση Placeholder Παρουσίασης σε Java
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
description: "Μάθετε πώς να εξετάζετε και να επεξεργάζεστε σύμβολα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των placeholder με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Ένας placeholder είναι ένα σχήμα που διατηρεί μια θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συνήθη παραδείγματα είναι οι placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένας placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Aspose.Slides αποκαλύπτει πληροφορίες placeholder μέσω της μεθόδου [IShape.getPlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/). Η μέθοδος επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [IPlaceholder.getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/) για να προσδιορίσετε τι προορίζεται να περιέχει ο placeholder.

Το interface σχήματος εξακολουθεί να είναι σημαντικό μετά τον προσδιορισμό του τύπου placeholder:

- Ένας κενός placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου αντιπροσωπεύεται συνήθως από ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/).
- Ένας γεμάτος placeholder εικόνας μπορεί να αντιπροσωπευθεί από ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/).
- Ένας γεμάτος placeholder διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [IChart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/).
- Ένας placeholder περιεχομένου μπορεί να περιέχει πολλαπλά είδη περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/) όσο και το runtime interface του σχήματος αντί να υποθέτετε ότι κάθε placeholder είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/) περιγράφει τον ρόλο ενός placeholder· δεν εγγυάται τον τύπο του σχήματος σε χρόνο εκτέλεσης. Πάντα κάντε έλεγχο τύπου πριν προσπελάσετε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομιάς Placeholder**

Οι placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders σε επίπεδο master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τους placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να μεταβείτε ένα επίπεδο πιο πάνω σε αυτήν την ιεραρχία. Ένας placeholder διαφάνειας συνήθως επιστρέφει τον placeholder της διάταξής του· ένας placeholder διάταξης μπορεί να επιστρέψει τον placeholder του master. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει base placeholder.

Το παρακάτω παράδειγμα παραθέτει τους placeholders στην πρώτη διαφάνεια και αναφέρει τα base placeholders τους:

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

Η επεξεργασία ενός placeholder σε κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό κανονικό σχήμα δεν έχει base placeholder και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Οι placeholders τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/).

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

Αυτό το μοτίβο αποφεύγει την εκτίμηση (casting) placeholders εικόνας, διαγράμματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/). Επίσης, εντοπίζει τον placeholder κατά σκοπό αντί να βασίζεται σε ευαίσθητο δείκτη σχήματος.

## **Ορισμός Προτροπής Κειμένου σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία κατά το σχεδιασμό που εμφανίζεται σε έναν κενό placeholder, όπως *Κάντε κλικ για προσθήκη τίτλου*. Ορίστε προσαρμοσμένο κείμενο προτροπής στον placeholder της διάταξης αντί να προσπαθήσετε να το προσπελάσετε μέσω της συλλογής σ Shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/) και επαναλάβετε τη συλλογή που επιστρέφει το [ILayoutSlide.getShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές τίτλου και υπότιτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

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

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά το υπάρχον κείμενο σε διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις προς χειρισμό:

- Αν ο placeholder εικόνας είναι ήδη γεμάτος και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipicturefillformat/) και του [ISlidesPicture.setImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidespicture/).
- Αν είναι ακόμα κενός placeholder, προσθέστε ένα picture frame στις συντεταγμένες του placeholder με το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishapecollection/) και αφαιρέστε τον κενό placeholder.

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

Η αντικατάσταση που δημιουργείται για έναν κενό placeholder είναι ένα τοπικό picture frame, όχι ένας νέος placeholder, επειδή το [IShape.getPlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πια τη συμπεριφορά συγκεκριμένης placeholder. Εάν η διατήρηση της σχέσης placeholder είναι ουσιώδης, προετοιμάστε και γεμίστε τον placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφωτεινότητα εικόνας, περικοπή και άλλες ειδικές επιδράσεις εικόνας, δείτε το άρθρο [Manage Picture Frames](/slides/el/java/picture-frame/). Οι λειτουργίες αυτές ανήκουν στο picture frame ή στο picture fill, όχι στα metadata του placeholder.

## **Εργασία με Placeholder Διαγράμματος και Περιεχομένου**

Ένας γεμάτος placeholder διαγράμματος μπορεί να αντιπροσωπευθεί από ένα [IChart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα τόσο με βάση τον τύπο placeholder όσο και το runtime interface, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένας γενικός placeholder περιεχομένου συνήθως έχει [PlaceholderType.Object](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλαπλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Μετά το γέμισμα, επιθεωρήστε το πραγματικό interface σχήματος για να μάθετε τι περιέχει. Ειδικές διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει έναν κενό placeholder [IAutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/iautoshape/) σε [IChart](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichart/) απλώς αλλάζοντας το [IPlaceholder.getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/placeholder/); ο τύπος δεν μπορεί να αλλάξει μέσω του interface. Για να γεμίσετε προγραμματικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε τον κενό placeholder. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα απλό τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από τον placeholder της διάταξης. Χρησιμοποιήστε τα εξειδικευμένα άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/java/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Εικόνας Περιεχομένου**

Το παρακάτω end-to-end παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε έναν placeholder τίτλου είτε εικόνας, ελέγχει τους τύπους placeholder και σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει συνειδητά την υπόθεση δείκτη σχήματος ή τη μετατροπή (casting) κάθε placeholder στο ίδιο interface.

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

## **FAQ**

**Τι είναι ένας base placeholder;**

Ένας base placeholder είναι το αντίστοιχο σχήμα στην διάταξη ή στον master από το οποίο κληρονομεί ένας άλλος placeholder. Χρησιμοποιήστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) για να τον ανακτήσετε. Ένα κανονικό τοπικό σχήμα επιστρέφει `null` επειδή δεν είναι μέρος της ιεραρχίας placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντας έναν placeholder διάταξης;**

Μπορείτε να αλλάξετε κληρονομημένη μορφοποίηση ή κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον περιεχόμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο διαφάνειας, διάταξης, master, σημειώσεων ή φυλλάδας. Δείτε το άρθρο [Manage Presentation Header and Footer](/slides/el/java/presentation-header-and-footer/) για πλήρη παραδείγματα.