---
title: Μετατροπή Διαφανειών PowerPoint σε PNG στο Android
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τις παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για Android μέσω Java, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα δείχνουν την απόδοση στην προεπιλεγμένη κλίμακα, την αύξηση της κλίμακας, τον καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και την επιλογή στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειές της μέσω της συλλογής [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . Το παράδειγμα αποδίδει κάθε διαφάνεια με τη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) χωρίς παραμέτρους για δημιουργία μικρογραφίας. Στη συνέχεια, καλείται η μέθοδος [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) με το [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) για να αποθηκευτεί κάθε αποδοθείσα διαφάνεια ως εικόνα PNG.

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
Η παράμετρος-αδερφική υπερφόρτωση [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) αποδίδει σε κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια που μετρά 720 × 540 σημεία παράγει μια μικρογραφία 144 × 108 εικονοστοιχεία. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με παράγοντες κλίμακας ή ένα ρητό μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένες διαστάσεις**

Προσδιορίστε οριζόντιους και κατακόρυφους παράγοντες κλίμακας στη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) για να ελέγξετε τις αποδοθείσες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο παράγοντες είναι 2, έτσι μια διαφάνεια 720 × 540 σημείων δημιουργεί μια εικόνα 1440 × 1080 εικονοστοιχείων. Οι ίσοι παράγοντες κλίμακας διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **Μετατροπή PowerPoint σε PNG με προσαρμοσμένο μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) αντί για παράγοντες κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια σε 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με τη μέθοδο [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Επιλέξτε διαστάσεις που ταιριάζουν στην αναλογία πλευρών της διαφάνειας ώστε να αποφύγετε το τέντωμα της εικόνας.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

## **Επιλέξτε στυλ απόδοσης διαβάθμισης**

Ας υποθέσουμε ότι μια διαφάνεια περιέχει διαβαθμισμένα γεμίσματα, αλλά οι μεταβάσεις στην εξαχθείσα PNG εμφανίζονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) που κληρονομείται από την [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το αρχείο [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον κατάλογο εργασίας της εφαρμογής. Η πρώτη διαφάνειά του περιέχει δύο γραμμικές διαβαθμίσεις: κυανό σε πορτοκαλί στην κορυφή και μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο σημεία διακοπής, στο 0 % και στο 100 %.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με τη μέθοδο [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

Οι παρακάτω εικόνες δείχνουν το αποτέλεσμα από την ίδια διαφάνεια, με και τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Προεπιλογή | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις κυανό‑πορτοκαλί και μπλε‑κίτρινο αποδομένες με Προεπιλογή](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδομένες με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, το `Default` παράγει πιο ανοιχτά ενδιάμεσα χρώματα, ενώ το `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τα σημεία διακοπής στη διαβάθμιση.

Επιλέξτε το `Default` όταν η τυπική έξοδος του Aspose.Slides καλύπτει τις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι η αντιστοίχηση της εμφάνισης στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· καμία λειτουργία δεν είναι παγκοσμίως προτιμότερη.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα γράφημα ή εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/androidjava/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η ταυτόχρονη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διαδικασία· [μην μοιράζεστε ένα ενιαίο αντικείμενο μεταξύ νημάτων](/slides/el/androidjava/multithreading/).

**Ποιες είναι οι περιορισμοί αξιολόγησης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/androidjava/licensing/) έως ότου εφαρμοστεί άδεια.