---
title: Προηγμένη Εξαγωγή Κειμένου από Παρουσιάσεις σε Android
linktitle: Εξαγωγή Κειμένου
type: docs
weight: 90
url: /el/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Εξαγάγετε γρήγορα κείμενο από παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Ακολουθήστε τον απλό, βήμα-βήμα οδηγό μας για να εξοικονομήσετε χρόνο."
---
## **Επισκόπηση**

Η εξαγωγή κειμένου από παρουσιάσεις είναι μια κοινή αλλά ουσιώδης εργασία για προγραμματιστές που εργάζονται με περιεχόμενο διαφανειών. Είτε διαχειρίζεστε αρχεία Microsoft PowerPoint σε μορφή PPT ή PPTX, είτε παρουσιάσεις OpenDocument (ODP), η πρόσβαση και η ανάκτηση των κειμενικών δεδομένων μπορεί να είναι κρίσιμη για ανάλυση, αυτοματοποίηση, ευρετηρίαση ή σκοπούς μετανάστευσης περιεχομένου.

Αυτό το άρθρο παρέχει έναν ολοκληρωμένο οδηγό για το πώς να εξάγετε αποτελεσματικά κείμενο από διάφορες μορφές παρουσιάσεων, συμπεριλαμβανομένων των PPT, PPTX και ODP, χρησιμοποιώντας το Aspose.Slides for Android via Java. Θα μάθετε πώς να επαναλαμβάνετε συστηματικά τα στοιχεία μιας παρουσίασης ώστε να ανακτήσετε με ακρίβεια το κείμενο που χρειάζεστε.

## **Εξαγωγή κειμένου από μια διαφάνεια**

Το Aspose.Slides for Android via Java παρέχει την κλάση [SlideUtil](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/) . Αυτή η κλάση εκθέτει πολλές υπερφορτωμένες στατικές μεθόδους για την εξαγωγή όλου του κειμένου από μια παρουσίαση ή διαφάνεια. Για να εξαγάγετε κείμενο από μια διαφάνεια σε μια παρουσίαση, χρησιμοποιήστε τη μέθοδο [getAllTextBoxes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Αυτή η μέθοδος δέχεται ένα αντικείμενο τύπου [IBaseSlide](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/) ως παράμετρο. Όταν εκτελείται, η μέθοδος σαρώει ολόκληρη τη διαφάνεια για κείμενο και επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/), διατηρώντας οποιαδήποτε μορφοποίηση κειμένου.

Το ακόλουθο απόσπασμα κώδικα εξάγει όλο το κείμενο από την πρώτη διαφάνεια της παρουσίασης:

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

Για να σαρώσετε κείμενο από ολόκληρη την παρουσίαση, χρησιμοποιήστε τη στατική μέθοδο [getAllTextFrames](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) που εκτίθεται από την κλάση [SlideUtil](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/) . Δέχεται δύο παραμέτρους:

1. Πρώτα, ένα αντικείμενο [IPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/) που αντιπροσωπεύει μια παρουσίαση PowerPoint ή OpenDocument από την οποία θα εξαχθεί το κείμενο.
1. Δεύτερον, μια τιμή `boolean` που υποδεικνύει εάν οι κύριες διαφάνειες πρέπει να συμπεριληφθούν κατά την σάρωση του κειμένου από την παρουσίαση.

Η μέθοδος επιστρέφει έναν πίνακα αντικειμένων τύπου [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/), περιλαμβάνοντας πληροφορίες μορφοποίησης κειμένου. Ο παρακάτω κώδικας σαρώει το κείμενο και τις λεπτομέρειες μορφοποίησης από μια παρουσίαση, συμπεριλαμβανομένων των κύριων διαφανειών.

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

Η κλάση [PresentationFactory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/) παρέχει επίσης μεθόδους για την εξαγωγή όλου του κειμένου από παρουσιάσεις:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Το επιχείρημα enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textextractionarrangingmode/) υποδεικνύει τη λειτουργία οργάνωσης του αποτελέσματος εξαγωγής κειμένου και μπορεί να οριστεί στις παρακάτω τιμές:
- `Unarranged` - Το ακατέργαστο κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια.
- `Arranged` - Το κείμενο είναι διατεταγμένο με την ίδια σειρά όπως στη διαφάνεια.

Η κατάσταση `Unarranged` μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι πιο γρήγορη από την κατάσταση `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationtext/) αντιπροσωπεύει το ακατέργαστο κείμενο που εξήχθη από την παρουσίαση. Η μέθοδος `getSlidesText` της επιστρέφει έναν πίνακα αντικειμένων τύπου [ISlideText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidettext/) . Κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια. Το αντικείμενο τύπου [ISlideText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidettext/) έχει τις ακόλουθες μεθόδους:

- `getText` - Το κείμενο εντός των σχήματων της διαφάνειας.
- `getMasterText` - Το κείμενο εντός των σχήματων της κύριας διαφάνειας που συνδέεται με αυτή τη διαφάνεια.
- `getLayoutText` - Το κείμενο εντός των σχήματων της διαφάνειας διάταξης που συνδέεται με αυτή τη διαφάνεια.
- `getNotesText` - Το κείμενο εντός των σχήματων της διαφάνειας σημειώσεων που συνδέεται με αυτή τη διαφάνεια.
- `getCommentsText` - Το κείμενο εντός των σχολίων που συνδέονται με αυτή τη διαφάνεια.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πόσο γρήγορα επεξεργάζεται το Aspose.Slides μεγάλες παρουσιάσεις κατά την εξαγωγή κειμένου;**

Το Aspose.Slides είναι βελτιστοποιημένο για υψηλή απόδοση και μπορεί να επεξεργαστεί ακόμη και [μεγάλες παρουσιάσεις](/slides/el/androidjava/open-presentation/), καθιστώντας το κατάλληλο για σεναρίου πραγματικού χρόνου ή μαζικής επεξεργασίας.

**Μπορεί το Aspose.Slides να εξάγει κείμενο από πίνακες και διαγράμματα εντός παρουσιάσεων;**

Ναι. Το Aspose.Slides μπορεί να εξάγει κείμενο από πολλά στοιχεία διαφανειών, συμπεριλαμβανομένων πινάκων και αντικειμένων σχετικών με διαγράμματα, ώστε να μπορείτε να έχετε πρόσβαση και να αναλύσετε το κειμενικό περιεχόμενο σε κοινές δομές παρουσιάσεων.

**Χρειάζομαι ειδική άδεια Aspose.Slides για την εξαγωγή κειμένου από παρουσιάσεις;**

Μπορείτε να εξάγετε κείμενο χρησιμοποιώντας τη δωρεάν δοκιμαστική έκδοση του Aspose.Slides, αν και θα έχει [ορισμένους περιορισμούς](/slides/el/androidjava/licensing/), όπως η επεξεργασία μόνο περιορισμένου αριθμού διαφανειών. Για απεριόριστη χρήση και για τη διαχείριση μεγαλύτερων παρουσιάσεων, συνίσταται η αγορά πλήρους άδειας.