---
title: Προχωρημένη Εξαγωγή Κειμένου από Παρουσιάσεις σε Java
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/java/extract-text-from-presentation/
keywords:
- εξαγωγή κειμένου
- εξαγωγή κειμένου από διαφάνεια
- εξαγωγή κειμένου από παρουσίαση
- εξαγωγή κειμένου από PowerPoint
- εξαγωγή κειμένου από OpenDocument
- εξαγωγή κειμένου από PPT
- εξαγωγή κειμένου από PPTX
- εξαγωγή κειμένου από ODP
- ανάκτηση κειμένου
- ανάκτηση κειμένου από διαφάνεια
- ανάκτηση κειμένου από παρουσίαση
- ανάκτηση κειμένου από PowerPoint
- ανάκτηση κειμένου από OpenDocument
- ανάκτηση κειμένου από PPT
- ανάκτηση κειμένου από PPTX
- ανάκτηση κειμένου από ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Java. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια κοινή, αλλά ουσιώδης εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε ασχολείστε με αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε με παρουσιάσεις OpenDocument (ODP), η πρόσβαση και ανάκτηση κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή σκοπούς μετεγκατάστασης περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποδοτικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for Java. Θα μάθετε πώς να διατρέχετε συστηματικά τα στοιχεία της παρουσίασης για να ανακτήσετε με ακρίβεια το κειμενικό περιεχόμενο που χρειάζεστε.

## **Εξαγωγή κειμένου από μια διαφάνεια**

Το Aspose.Slides for Java παρέχει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/). Αυτή η κλάση εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-). Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [IBaseSlide](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/) ως παράμετρο. Όταν εκτελείται, η μέθοδος σαρώνει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/), διατηρώντας τυχόν μορφοποίηση του κειμένου.

Το παρακάτω απόσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Εξαγωγή κειμένου από μια παρουσίαση**

Για να σαρώσετε κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/). Δέχεται δύο παραμέτρους:

1. Πρώτον, ένα αντικείμενο τύπου [IPresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερον, μια τιμή `boolean` που υποδεικνύει εάν οι κύριες διαφάνειες πρέπει να συμπεριληφθούν όταν γίνεται σάρωση κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/), συμπεριλαμβανομένων πληροφοριών μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Κατηγοριοποιημένη και γρήγορη εξαγωγή κειμένου**

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Το όρισμα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/java/com.aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία για οργάνωση του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:

- `Unarranged` - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- `Arranged` - Το κείμενο είναι οργανωμένο με την ίδια σειρά όπως στην διαφάνεια.

Η λειτουργία `Unarranged` μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξάγεται από την παρουσίαση. Η μέθοδος `getSlidesText` της επιστέφε ένα πίνακα αντικειμένων τύπου [ISlideText](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidetext/). Κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια. Το αντικείμενο τύπου [ISlideText](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidetext/) διαθέτει τις ακόλουθες μεθόδους:

- `getText` - Το κείμενο εντός των σχημάτων της διαφάνειας.
- `getMasterText` - Το κείμενο εντός των σχημάτων της κύριας διαφάνειας που σχετίζεται με αυτή τη διαφάνεια.
- `getLayoutText` - Το κείμενο εντός των σχημάτων της διαφάνειας διάταξης που σχετίζεται με αυτή τη διαφάνεια.
- `getNotesText` - Το κείμενο εντός των σχημάτων της διαφάνειας σημειώσεων που σχετίζεται με αυτή τη διαφάνεια.
- `getCommentsText` - Το κείμενο εντός των σχολίων που σχετίζονται με αυτή τη διαφάνεια.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **Συχνές ερωτήσεις**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/java/open-presentation/), καθιστώντας το κατάλληλο για σενάρια επεξεργασίας σε πραγματικό χρόνο ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και διαγράμματα μέσα σε παρουσιάσεις;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία της διαφάνειας, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με τα διαγράμματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσιάσεων.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και θα έχει [συγκεκριμένους περιορισμούς](/slides/el/java/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για ανεμπόδιστη χρήση και για τη διαχείριση μεγαλύτερων παρουσιάσεων, συνιστάται η αγορά πλήρους άδειας.