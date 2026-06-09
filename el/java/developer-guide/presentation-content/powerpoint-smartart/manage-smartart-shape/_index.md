---
title: Διαχείριση Γραφικών SmartArt σε Παρουσιάσεις με Java
linktitle: Γραφικά SmartArt
type: docs
weight: 20
url: /el/java/manage-smartart-shape/
keywords:
- Αντικείμενο SmartArt
- Γραφική SmartArt
- Στυλ SmartArt
- Χρώμα SmartArt
- Δημιουργία SmartArt
- Προσθήκη SmartArt
- Επεξεργασία SmartArt
- Αλλαγή SmartArt
- Πρόσβαση SmartArt
- Τύπος διάταξης SmartArt
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Αυτοματοποιήστε τη δημιουργία, την επεξεργασία και το styling των SmartArt σε PowerPoint με Java χρησιμοποιώντας το Aspose.Slides, παρέχοντας σύντομες παραδείγματα κώδικα και οδηγίες εστιασμένες στην απόδοση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να δημιουργείτε και να διαχειρίζεστε γραφικά SmartArt σε παρουσιάσεις PowerPoint προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να προσθέσετε ένα σχήμα SmartArt σε μια διαφάνεια, πώς να αποκτήσετε πρόσβαση σε υπάρχοντα σχήματα SmartArt, πώς να εντοπίσετε SmartArt με συγκεκριμένο τύπο διάταξης και πώς να ενημερώσετε την οπτική του εμφάνιση αλλάζοντας το στυλ SmartArt ή το στυλ χρώματος.

Τα παραδείγματα δείχνουν πώς να εργαστείτε με σχήματα SmartArt μέσω της συλλογής σχημάτων της διαφάνειας παρουσίασης, πώς να ελέγξετε εάν ένα σχήμα είναι SmartArt και στη συνέχεια να τροποποιήσετε ή να ελέγξετε τις ιδιότητές του.

## **Δημιουργία σχήματος SmartArt**
Το Aspose.Slides for Java παρέχει ένα API για τη δημιουργία σχημάτων SmartArt. Για να δημιουργήσετε ένα σχήμα SmartArt σε μια διαφάνεια, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) .
1. Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
1. [Προσθέστε ένα σχήμα SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) ορίζοντας το [LayoutType](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArtLayoutType) .
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```java
// Αρχικοποίηση κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Απόκτηση πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Προσθήκη σχήματος SmartArt
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
Ο παρακάτω κώδικας θα χρησιμοποιηθεί για την πρόσβαση στα σχήματα SmartArt που προστέθηκαν σε διαφάνεια παρουσίασης. Στον παράδειγμα κώδικα θα διασχίσουμε κάθε σχήμα μέσα στη διαφάνεια και θα ελέγξουμε εάν είναι σχήμα [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt). Αν το σχήμα είναι τύπου SmartArt, τότε θα το μετατρέψουμε σε παρουσίαση [**SmartArt**](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) .

```java
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Πρόσβαση σε σχήμα SmartArt με συγκεκριμένο LayoutType**
Ο παρακάτω κώδικας δείγμα θα βοηθήσει στην πρόσβαση στο σχήμα [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) με συγκεκριμένο LayoutType. Παρακαλούμε σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν το σχήμα [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) προστίθεται.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Ελέγξτε το σχήμα SmartArt με συγκεκριμένο LayoutType και εκτελέστε ό,τι απαιτείται μετά.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
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

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Style.
1. Ορίστε το νέο Style για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή του σχήματος σε SmartArtEx
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
|**Σχήμα: Σχήμα SmartArt με αλλαγμένο Style**|

## **Αλλαγή στυλ χρώματος σχήματος SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αλλάξουμε το στυλ χρώματος για οποιοδήποτε σχήμα SmartArt. Στον παρακάτω κώδικα θα αποκτήσουμε πρόσβαση στο σχήμα SmartArt με συγκεκριμένο στυλ χρώματος και θα το αλλάξουμε.

1. Δημιουργήτε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/Presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.
1. Αποκτήστε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.
1. Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια.
1. Ελέγξτε εάν το σχήμα είναι τύπου [SmartArt](https://reference.aspose.com/slides/el/java/com.aspose.slides/SmartArt) και μετατρέψτε το επιλεγμένο σχήμα σε SmartArt εάν είναι SmartArt.
1. Βρείτε το σχήμα SmartArt με συγκεκριμένο Color Style.
1. Ορίστε το νέο Color Style για το σχήμα SmartArt.
1. Αποθηκεύστε την Παρουσίαση.

```java
// Δημιουργία αντικειμένου κλάσης Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Λήψη πρώτης διαφάνειας
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Διασχίστε κάθε σχήμα μέσα στην πρώτη διαφάνεια
    for (IShape shape : slide.getShapes()) 
    {
        // Ελέγξτε εάν το σχήμα είναι τύπου SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Μετατροπή του σχήματος σε SmartArtEx
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
|**Σχήμα: Σχήμα SmartArt με αλλαγμένο Color Style**|

## **Συχνές ερωτήσεις**

**Μπορώ να κάνω animation το SmartArt ως ένα ενιαίο αντικείμενο;**

Ναι. Το SmartArt είναι σχήμα, έτσι μπορείτε να εφαρμόσετε [τυπικές αναδράσεις](/slides/el/java/powerpoint-animation/) μέσω του API αναδράσεων (είσοδο, έξοδο, έμφαση, διαδρομές κίνησης) όπως και για άλλα σχήματα.

**Πώς μπορώ να βρω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν δεν γνωρίζω το εσωτερικό του ID;**

Ορίστε και χρησιμοποιήστε το Εναλλακτικό Κείμενο (AltText) και αναζητήστε το σχήμα με αυτήν την τιμή — αυτή είναι μια συνιστώμενη μέθοδος για τον εντοπισμό του στόχου.

**Μπορώ να ομαδοποιήσω το SmartArt με άλλα σχήματα;**

Ναι. Μπορείτε να ομαδοποιήσετε το SmartArt με άλλα σχήματα (εικόνες, πίνακες, κλπ.) και έπειτα να [χειριστείτε την ομάδα](/slides/el/java/group/).

**Πώς μπορώ να λάβω μια εικόνα ενός συγκεκριμένου SmartArt (π.χ. για προεπισκόπηση ή αναφορά);**

Εξάγετε μια μικρογραφία/εικόνα του σχήματος· η βιβλιοθήκη μπορεί να [αποδώσει μεμονωμένα σχήματα](/slides/el/java/create-shape-thumbnails/) σε αρχεία raster (PNG/JPG/TIFF).

**Θα διατηρηθεί η εμφάνιση του SmartArt όταν μετατρέπεται ολόκληρη η παρουσίαση σε PDF;**

Ναι. Η μηχανή απόδοσης στοχεύει σε υψηλή πιστότητα για [εξαγωγή PDF](/slides/el/java/convert-powerpoint-to-pdf/), με ένα σύνολο επιλογών ποιότητας και συμβατότητας.