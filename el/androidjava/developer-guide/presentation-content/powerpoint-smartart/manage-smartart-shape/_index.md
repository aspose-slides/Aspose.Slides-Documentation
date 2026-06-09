---
title: Διαχείριση γραφικών SmartArt σε παρουσιάσεις στο Android
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/androidjava/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφικό SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- Παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, την επεξεργασία και το styling των SmartArt στο PowerPoint χρησιμοποιώντας το Aspose.Slides για Android, με σύντομα παραδείγματα κώδικα Java και οδηγίες επικεντρωμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, να έχετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, να βρείτε SmartArt με συγκεκριμένο τύπο διάταξης και να ενημερώσετε την οπτική εμφάνισή του αλλάζοντας το στυλ SmartArt ή το χρωματικό στυλ.

Τα παραδείγματα δείχνουν πώς να εργαστείτε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας παρουσίασης, να ελέγξετε εάν ένα σχήμα είναι SmartArt και, στη συνέχεια, να τροποποιήσετε ή να εξετάσετε τις ιδιότητές του.

## **Δημιουργία σχήματος SmartArt**
Το Aspose.Slides για Android μέσω Java έχει προσφέρει ένα API για τη δημιουργία σχημάτων SmartArt. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation).
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. [Προσθήκη σχήματος SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) ορίζοντας το [LayoutType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation();
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη σχήματος Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Αποθήκευση παρουσίασης
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt προστέθηκε στη διαφάνεια**|

## **Πρόσβαση σε σχήμα SmartArt σε μια διαφάνεια**
Ο ακόλουθος κώδικας θα χρησιμοποιηθεί για την πρόσβαση στα σχήματα SmartArt που προστέθηκαν στη διαφάνεια παρουσίασης. Στο παράδειγμα κώδικα θα διασχίσουμε κάθε σχήμα μέσα στη διαφάνεια και θα ελέγξουμε εάν πρόκειται για σχήμα [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt). Εάν το σχήμα είναι τύπου SmartArt, τότε θα το μετατρέψουμε σε αντικείμενο [**SmartArt**](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) .

```java
// Φόρτωση της επιθυμητής παρουσίασης
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Διάσχιση όλων των σχημάτων μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt)
        {
            // Μετατροπή τύπου του σχήματος σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε σχήμα SmartArt με συγκεκριμένο LayoutType**
Ο παρακάτω κώδικας δείγματος θα σας βοηθήσει να αποκτήσετε πρόσβαση στο σχήμα [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) με συγκεκριμένο LayoutType. Παρακαλώ σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) προστεθεί.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Ελέγξτε το σχήμα SmartArt με συγκεκριμένο LayoutType και εκτελέστε ό,τι απαιτείται κατόπιν.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Διάσχιση όλων των σχημάτων μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt)
        {
            // Μετατροπή του σχήματος σε SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Έλεγχος διάταξης SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Αλλαγή στυλ σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το γρήγορο στυλ για οποιοδήποτε σχήμα SmartArt.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Style.
1. Ορίστε το νέο Style για το σχήμα SmartArt.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Διάσχιση όλων των σχημάτων μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή σχήματος σε SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Έλεγχος στυλ SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Αλλαγή στυλ SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με τροποποιημένο Style**|

## **Αλλαγή χρωματικού στυλ σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το χρωματικό στυλ για οποιοδήποτε σχήμα SmartArt. Στον παρακάτω κώδικα δείγματος θα αποκτήσουμε πρόσβαση στο σχήμα SmartArt με συγκεκριμένο χρωματικό στυλ και θα το αλλάξουμε.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Color Style.
1. Ορίστε το νέο Color Style για το σχήμα SmartArt.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργία αντικειμένου Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Διάσχιση όλων των σχημάτων μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Έλεγχος εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή σχήματος σε SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Έλεγχος τύπου χρώματος SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Αλλαγή τύπου χρώματος SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Σχήμα: Σχήμα SmartArt με τροποποιημένο Color Style**|

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω animation στο SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, οπότε μπορείτε να εφαρμόσετε [standard animations](/slides/el/androidjava/powerpoint-animation/) μέσω του API animations (είσοδο, έξοδο, έμφαση, διαδρομές κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και αναζητήστε το σχήμα με αυτήν την τιμή—αυτή είναι η συνιστούμενη μέθοδος για τον εντοπισμό του επιθυμητού σχήματος.

**Μπορώ να ομαδοποιήσω SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες, κ.λπ.) και στη συνέχεια να [manipulate the group](/slides/el/androidjava/group/).

**Πώς μπορώ να λάβω μια εικόνα ενός συγκεκριμένου SmartArt (π.χ., για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [render individual shapes](/slides/el/androidjava/create-shape-thumbnails/) σε αρχείο raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt όταν μετατρέπεται ολόκληρη η παρουσίαση σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για την [PDF export](/slides/el/androidjava/convert-powerpoint-to-pdf/), με μια σειρά από επιλογές ποιότητας και συμβατότητας.