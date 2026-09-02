---
title: Διαχείριση Συμβόλων Κράτησης Παρουσιάσης σε Android
linktitle: Διαχείριση Συμβόλων Κράτησης
type: docs
weight: 10
url: /el/androidjava/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κειμένου
- σύμβολο εικόνας
- σύμβολο διαγράμματος
- σύμβολο περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να εξετάζετε και να επεξεργάζεστε σύμβολα κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των συμβόλων με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένας σύμβολο κράτησης (placeholder) είναι ένα σχήμα που διατηρεί μια θέση για έναν συγκεκριμένο τύπο περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι οι σύμβολα τίτλου, σώματος, εικόνας, διαγράμματος και γενικής χρήσης περιεχομένου. Σε αντίθεση με ένα κανονικό σχήμα, ένας σύμβολο κράτησης μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις του από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Το Aspose.Slides αποκαλύπτει πληροφορίες συμβόλων κράτησης μέσω της μεθόδου [IShape.getPlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/). Η μέθοδος επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/) ή `null` για ένα κανονικό σχήμα. Χρησιμοποιούντε [IPlaceholder.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/) για να καθορίσετε τι προορίζεται να περιέχει ο σύμβολο κράτησης.

Η διεπαφή σχήματος παραμένει σημαντική μετά την γνώση του τύπου του συμβόλου κράτησης:

- Ένα κενό σύμβολο κειμένου, εικόνας, διαγράμματος ή περιεχομένου συνήθως αντιπροσωπεύεται από ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).
- Ένα συμπληρωμένο σύμβολο εικόνας μπορεί να αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/).
- Ένα συμπληρωμένο σύμβολο διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/).
- Ένα σύμβολο περιεχομένου μπορεί να περιέχει διάφορους τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/) όσο και τη διεπαφή σχήματος χρόνου εκτέλεσης, αντί να υποθέτετε ότι κάθε σύμβολο είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/) περιγράφει τον ρόλο του συμβόλου κράτησης· δεν εγγυάται τον τύπο σχήματος χρόνου εκτέλεσης. Πάντα χρησιμοποιείτε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή πολυμέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Συμβόλων Κράτησης**

Τα σύμβολα κράτησης δημιουργούν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, σύμβολα κράτησης επιπέδου κύριας διαφάνειας.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από την κύρια διαφάνεια.
3. Μια κανονική διαφάνεια περιέχει τα σύμβολα κράτησης για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να μεταβείτε ένα επίπεδο υψηλότερα σε αυτήν την ιεραρχία. Ένα σύμβολο διαφάνειας συνήθως επιστρέφει το σύμβολο διάταξης· ένα σύμβολο διάταξης μπορεί να επιστρέψει το σύμβολο κύριας διαφάνειας. Η μέθοδος επιστρέφει `null` όταν το σχήμα δεν έχει βασικό σύμβολο.

Το παρακάτω παράδειγμα παραθέτει τα σύμβολα κράτησης στην πρώτη διαφάνεια και αναφέρει τα βασικά τους σύμβολα:

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

Η επεξεργασία ενός συμβόλου κράτησης σε κανονική διαφάνεια δημιουργεί ή τροποποιεί μια τοπική αντικατάσταση για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή κύριας διαφάνειας μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτήν τη ρύθμιση. Ένα τοπικό κανονικό σχήμα δεν έχει βασικό σύμβολο και δεν αρχίζει να κληρονομεί μόνο επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Σύμβολο Κράτησης**

Τα σύμβολα τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) πριν χρησιμοποιήσετε τη μέθοδο [getTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/).

Το παρακάτω παράδειγμα ενημερώνει το πρώτο σύμβολο τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

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

Αυτό το μοτίβο αποφεύγει τη μετατροπή (casting) συμβόλων εικόνας, διαγράμματος, πίνακα ή πολυμέσων σε [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/). Επίσης προσδιορίζει το σύμβολο με βάση τον σκοπό του αντί να βασίζεται σε έναν ευαίσθητο δείκτη σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία κατά το σχεδιασμό που εμφανίζεται σε ένα κενό σύμβολο, όπως *Κάντε κλικ για να προσθέσετε τίτλο*. Ορίστε προσαρμοσμένο κείμενο προτροπής στο σύμβολο διάταξης αντί να προσπαθείτε να το προσπελάσετε μέσω της συλλογής σχημάτων μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide.getLayoutSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/) και επανάληψη στην συλλογή που επιστρέφει το [ILayoutSlide.getShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/).

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

Το κείμενο προτροπής δεν αποτελεί κανονικό περιεχόμενο της διαφάνειας. Προορίζεται για κενά σύμβολα σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά το υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Συμβόλου Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να διαχειριστείτε:

- Εάν το σύμβολο εικόνας είναι ήδη συμπληρωμένο και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipicturefillformat/) και του [ISlidesPicture.setImage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidespicture/).
- Εάν παραμένει κενό σύμβολο, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του συμβόλου με το [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishapecollection/) και αφαιρέστε το κενό σύμβολο.

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

Η αντικατάσταση που δημιουργείται για ένα κενό σύμβολο είναι ένα τοπικό πλαίσιο εικόνας, όχι ένα νέο σύμβολο, επειδή το [IShape.getPlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) δεν παρέχει setter. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά που σχετίζεται με το σύμβολο. Εάν η διατήρηση της σχέσης του συμβόλου είναι απαραίτητη, προετοιμάστε και συμπληρώστε το σύμβολο στο PowerPoint πρώτα, και στη συνέχεια ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλες ειδικές επιδράσεις εικόνας, δείτε το [Manage Picture Frames](/slides/el/androidjava/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στη γέμιση εικόνας, όχι στα μεταδεδομένα του συμβόλου.

## **Εργασία με Σύμβολα Διαγράμματος και Περιεχομένου**

Ένα συμπληρωμένο σύμβολο διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/). Αυτό το παράδειγμα εντοπίζει τέτοιο διάγραμμα τόσο με βάση τον τύπο του συμβόλου όσο και τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

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

Ένα γενικό σύμβολο περιεχομένου συνήθως έχει [PlaceholderType.Object](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για διάφορους τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και πολυμέσα. Αφού συμπληρωθεί, εξετάστε τη συγκεκριμένη διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType.Chart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/), ή [PlaceholderType.Diagram](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides δεν μετατρέπει ένα κενό σύμβολο [IAutoShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iautoshape/) σε [IChart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichart/) απλώς αλλάζοντας το [IPlaceholder.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/placeholder/); ο τύπος δεν μπορεί να αλλάξει μέσω της διεπαφής. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του συμβόλου και, στη συνέχεια, αφαιρέστε το κενό σύμβολο. Το παρακάτω παράδειγμα το κάνει για ένα διάγραμμα:

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

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του συμβόλου αλλά δεν κληρονομεί από το σύμβολο διάταξης. Χρησιμοποιήστε τα ειδικά [chart management articles](/slides/el/androidjava/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα βιβλίου εργασίας του.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω εν κατακμή παράδειγμα ανοίγει ένα πρότυπο, αναζητά στην πρώτη διαφάνεια είτε σύμβολο τίτλου είτε σύμβολο εικόνας, ελέγχει τους τύπους του συμβόλου και του σχήματος, ενημερώνει το κατάλληλο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση δείκτη σχήματος ή τη μετατροπή (casting) κάθε συμβόλου στην ίδια διεπαφή.

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

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό σύμβολο κράτησης;**

Ένα βασικό σύμβολο κράτησης είναι το αντίστοιχο σχήμα στη διάταξη ή την κύρια διαφάνεια από το οποίο κληρονομεί ένα άλλο σύμβολο. Χρησιμοποιήστε το [IShape.getBasePlaceholder](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `null` επειδή δεν αποτελεί μέρος της ιεραρχίας των συμβόλων.

**Μπορώ να αλλάξω όλους τους τίτλους διαφανειών επεξεργαζόμενο ένα σύμβολο διάταξης;**

Μπορείτε να αλλάξετε τη κληρονομημένη μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον κείμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε ολόκληρη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε το κάθε σύμβολο τίτλου.

**Πώς διαχειρίζομαι τα σύμβολα ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στο κατάλληλο επίπεδο (διαφάνεια, διάταξη, κύρια, σημειώσεις ή φυλλάδιο). Δείτε το [Manage Presentation Header and Footer](/slides/el/androidjava/presentation-header-and-footer/) για πλήρη παραδείγματα.