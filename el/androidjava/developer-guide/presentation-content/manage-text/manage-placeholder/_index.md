---
title: Διαχείριση Προθέσεων Παρουσίασης σε Android
linktitle: Διαχείριση Προθέσεων
type: docs
weight: 10
url: /el/androidjava/manage-placeholder/
keywords:
- πρόθεση
- πρόθεση κειμένου
- πρόθεση εικόνας
- πρόθεση γραφήματος
- κείμενο προτροπής
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε εύκολα τις προθέσεις στο Aspose.Slides για Android μέσω Java: αντικαταστήστε κείμενο, προσαρμόστε προτροπές και ορίστε διαφάνεια εικόνας σε PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε προθέσεις παρουσίασης προγραμματιστικά. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε προθέσεις στις διαφάνειες και να αλλάζετε το κείμενό τους, να ορίζετε προσαρμοσμένο κείμενο προτροπής για τις διατάξεις προθέσεων και να ρυθμίζετε τη διαφάνεια μιας εικόνας που χρησιμοποιείται ως φόντο προθέσεων. Περιλαμβάνει επίσης μια σύντομη Συχνές Ερωτήσεις (FAQ) που διευκρινίζει τη διαφορά μεταξύ βασικών προθέσεων και τοπικών σχημάτων, εξηγεί πώς οι αλλαγές προθέσεων μπορούν να εφαρμοστούν μέσω διατάξεων ή αρίθμισης (masters), και αναφέρει τη διαχείριση προθέσεων κεφαλίδας και υποσέλιδου.

## **Αλλαγή Κειμένου σε Χώρο κράτησης**

Χρησιμοποιώντας [Aspose.Slides for Android via Java](/slides/el/androidjava/), μπορείτε να βρείτε και να τροποποιήσετε τους χώρους κράτησης στις διαφάνειες σε παρουσιάσεις. Το Aspose.Slides σας επιτρέπει να κάνετε αλλαγές στο κείμενο ενός χώρου κράτησης.

**Προαπαιτούμενο**: Χρειάζεστε μια παρουσίαση που περιέχει έναν χώρο κράτησης. Μπορείτε να δημιουργήσετε μια τέτοια παρουσίαση στην τυπική εφαρμογή Microsoft PowerPoint.

Ακολουθεί ο τρόπος με τον οποίο χρησιμοποιείτε το Aspose.Slides για να αντικαταστήσετε το κείμενο στον χώρο κράτησης σε αυτήν την παρουσίαση:

1. Δημιουργήστε μια παρουσία της κλάσης [`Presentation`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/Presentation). και περάστε την παρουσία ως όρισμα.
2. Λάβετε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.
3. Περιηγηθείτε στα σχήματα για να βρείτε τον χώρο κράτησης.
4. Κάντε μετατροπή τύπου του σχήματος χώρου κράτησης σε ένα [`AutoShape`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AutoShape) και αλλάξτε το κείμενο χρησιμοποιώντας το [`TextFrame`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/TextFrame) που σχετίζεται με το [`AutoShape`](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/AutoShape).
5. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να αλλάξετε το κείμενο σε έναν χώρο κράτησης:

```java
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Προσπελατεί την πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);

    // Διασχίζει τα σχήματα για να βρει την πρόθεση
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Αλλάζει το κείμενο σε κάθε πρόθεση
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Κειμένου Προτροπής σε Χώρο κράτησης**

Standard and pre-built layouts contain placeholder prompt texts such as ***Κάντε κλικ για να προσθέσετε έναν τίτλο*** or ***Κάντε κλικ για να προσθέσετε έναν υπότιτλο***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε το κείμενο προτροπής σε έναν χώρο κράτησης:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Διασχίζει τη διαφάνεια
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // Το PowerPoint εμφανίζει "Κάντε κλικ για να προσθέσετε τίτλο"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Προσθέτει υπότιτλο
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Διαφάνειας Εικόνας σε Χώρο κράτησης**

Το Aspose.Slides σας επιτρέπει να ορίσετε τη διαφάνεια της εικόνας φόντου σε έναν χώρο κράτησης κειμένου. Με την προσαρμογή της διαφάνειας της εικόνας σε τέτοιο πλαίσιο, μπορείτε να αναδείξετε το κείμενο ή την εικόνα (ανάλογα με τα χρώματα του κειμένου και της εικόνας).

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη διαφάνεια για το φόντο εικόνας (μέσα σε σχήμα):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Τι είναι ένα βασικό placeholder και πώς διαφέρει από ένα τοπικό σχήμα σε μια διαφάνεια;**

Ένα βασικό placeholder είναι το αρχικό σχήμα σε μια διάταξη ή master από το οποίο κληρονομείται το σχήμα της διαφάνειας—ο τύπος, η θέση και κάποιες μορφοποιήσεις προέρχονται από αυτό. Ένα τοπικό σχήμα είναι ανεξάρτητο· εάν δεν υπάρχει βασικό placeholder, η κληρονομικότητα δεν εφαρμόζεται.

**Πώς μπορώ να ενημερώσω όλους τους τίτλους ή τις λεζάντες σε όλη την παρουσίαση χωρίς να επαναλαμβάνομαι σε κάθε διαφάνεια;**

Επεξεργαστείτε το αντίστοιχο placeholder στη διάταξη ή στο master. Οι διαφάνειες που βασίζονται σε αυτές τις διατάξεις/αυτό το master θα κληρονομήσουν αυτόματα την αλλαγή.

**Πώς ελέγχω τα τυπικά placeholders κεφαλίδας/υποσέλιδου—ημερομηνία & ώρα, αριθμός διαφάνειας και κείμενο υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές HeaderFooter στο κατάλληλο πεδίο (κανονικές διαφάνειες, διατάξεις, master, σημειώσεις/πρότυπα) για να ενεργοποιήσετε ή να απενεργοποιήσετε αυτά τα placeholders και να ορίσετε το περιεχόμενό τους.