---
title: Μετατροπή διαφανειών PowerPoint σε PNG σε Java
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/java/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για Java, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Java. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να τη σώσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα δείχνουν απόδοση στην προεπιλεγμένη κλίμακα, αύξηση της κλίμακας, καθορισμό των διαστάσεων εξόδου σε πίξελ και επιλογή στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και προσπελάστε τις διαφάνειες της μέσω της συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--). Το παράδειγμα αποδίδει κάθε διαφάνεια με την μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) χωρίς παραμέτρους για δημιουργία μικρογραφίας. Στη συνέχεια καλεί τη μέθοδο [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) με το [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) για να αποθηκεύσει κάθε αποδοθείσα διαφάνεια ως εικόνα PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) χωρίς παραμέτρους αποδίδει με κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια με μέγεθος 720 × 540 σημεία παράγει μια μικρογραφία 144 × 108 εικονοστοιχείων. Για έλεγχο των διαστάσεων εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας που φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Περάστε οριζόντιους και κάθετους παράγοντες κλίμακας στη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) για να ελέγξετε τις αποδοθείσες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια με μέγεθος 720 × 540 σημεία παράγει μια εικόνα 1440 × 1080 εικονοστοιχείων. Ισόκλιμα παράγοντες διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια στα 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με τη [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Επιλέξτε διαστάσεις που ταιριάζουν στην αναλογία διαστάσεων της διαφάνειας ώστε να αποφύγετε την τράνσα της εικόνας.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Επιλογή Στυλ Απόδοσης Διαβάθμισης**

Υποθέστε ότι μια διαφάνεια περιέχει διαβαθμισμένες γεμίσεις, αλλά οι μεταβάσεις στην εξαχθείσα PNG φαίνονται πιο ανοιχτές ή με διαφορετικό τρόπο από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) που κληρονομείται από το [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) για να επιλέξετε πώς θα αποδοθούν οι διαβαθμίσεις.

Κατεβάστε το αρχείο [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει δύο γραμμικές διαβαθμίσεις: κυανό σε πορτοκαλί στο άνω μέρος και μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο σημεία στάσης, στο 0% και στο 100%.

Το παρακάτω παράδειγμα φορτώνει αυτή την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με τη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Οι εικόνες παρακάτω δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με και τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Default | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις από κυανό-πορτοκαλί και μπλε-κίτρινο αποδομένες με Default](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδομένες με PowerPointUI](gradient-PowerPointUI.png) |

Στο παράδειγμα αυτό, το `Default` παράγει πιο φωτεινά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τα σημεία στάσης στη διαβάθμιση.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides εξυπηρετεί τις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν προτεραιότητά σας είναι η αντιστοίχηση της εμφάνισης στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιδιωκόμενο αποτέλεσμα· κανένα από τα δύο δεν είναι γενικά προτιμητέο.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή μια εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/java/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διαδικασία· [μην μοιράζεστε ένα αντικείμενο παρουσίασης μεταξύ νημάτων](/slides/el/java/multithreading/).

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η δοκιμαστική λειτουργία προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/java/licensing/) μέχρι να εφαρμοστεί άδεια.