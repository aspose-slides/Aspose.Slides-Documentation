---
title: Αυτοματισμός τοπικοποίησης παρουσίασης σε Java
linktitle: Τοπικοποίηση παρουσίασης
type: docs
weight: 100
url: /el/java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- καταστολή ορθογραφικού ελέγχου
- γλώσσα απόδειξης
- αναγνωριστικό γλώσσας
- πολυγλωσσικό κείμενο
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ορίστε γλώσσες απόδειξης για το κείμενο παρουσίασης PowerPoint και OpenDocument σε Java με το Aspose.Slides, συμπεριλαμβανομένων των προεπιλογών και των πολύγλωσσων παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides for Java σάς επιτρέπει να διαμορφώσετε τα μεταδεδομένα απόδειξης για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) για να προσδιορίσετε τη γλώσσα απόδειξης, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) για να επιτρέψετε ή να καταστέλλετε τον ορθογραφικό έλεγχο και [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) για να ελέγξετε την ευρύτερη κατάσταση «μη απόδειξη». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μια παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες απόδειξης.

Αυτό το άρθρο εξηγεί πώς να αντιστοιχίσετε μια γλώσσα σε συγκεκριμένο κείμενο, να ορίσετε τη προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), να δημιουργήσετε πολύγλωσσες παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled` και να διατηρήσετε τις επιθυμητές ρυθμίσεις όταν χρησιμοποιείτε [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν λεξικό έλεγχο ορθογραφίας ή δεν επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός της γλώσσας απόδειξης για κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), αποκτήστε πρόσβαση στο απαιτούμενο τμήμα κειμένου μέσω [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#getPortionFormat--), και ορίστε το αναγνωριστικό της γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τη βρετανική αγγλική ως γλώσσα απόδειξης και αποθηκεύει το αποτέλεσμα με [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός της προεπιλεγμένης γλώσσας για νέο κείμενο**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να καθορίσετε τη γλώσσα απόδειξης που το Aspose.Slides θα αντιστοιχίσει στο νεοδημιουργηθέν κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν η πλειονότητα ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας του κειμένου που ήδη έχει ρητά ορισμένη γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση όπου το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες απόδειξης:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Χρήση πολλαπλών γλωσσών σε μια παράγραφο**

Ένα [IParagraph](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraph/) περιέχει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/java/com.aspose.slides/portion/) για κάθε γλώσσα και ορίστε ανεξάρτητα το `LanguageId` του.

Αυτό το παράδειγμα δημιουργεί μία παράγραφο με αγγλικά και γαλλικά τμήματα:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ενεργοποίηση ή καταστολή ορθογραφικού ελέγχου για μεμονωμένα τμήματα**

[IPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από το [IBasePortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/). Αποκτήστε πρόσβαση στη μορφή ενός τμήματος μέσω [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#getPortionFormat--) και χρησιμοποιήστε [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) για να ελέγξετε εάν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλεγμένη τιμή είναι `false`: το `true` επιτρέπει τον ορθογραφικό έλεγχο, ενώ το `false` τον καταστέλλει.

Η ρύθμιση ισχύει για μεμονωμένα τμήματα κειμένου. Έτσι, διαφορετικά τμήματα στην ίδια παράγραφο μπορούν να χρησιμοποιούν διαφορετικές τιμές. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) και `setSpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `setLanguageId` καθορίζει τη γλώσσα απόδειξης, ενώ το `setSpellCheck` αποφασίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για το τμήμα.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ελέγχει επίσης την απόδειξη, αλλά αντιπροσωπεύει την ευρύτερη κατάσταση «μη απόδειξη» ως ένα [NullableBool](https://reference.aspose.com/slides/el/java/com.aspose.slides/nullablebool/). Χρησιμοποιήστε το `setSpellCheck` όταν χρειάζεστε άμεσο διακόπτη Boolean ειδικά για τον ορθογραφικό έλεγχο. Χρησιμοποιήστε το `setProofDisabled` όταν θέλετε να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη απόδειξης» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NotDefined`. Αν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συμβατές· μην συνδυάσετε `setSpellCheck(true)` με `setProofDisabled(NullableBool.True)`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα απόδειξης που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση λεξικού ελέγχου ορθογραφίας ή επιστροφή λίστας λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια είσοδο παρουσίασης, τη φορτώνει, αντιστοιχίζει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες απόδειξης σε δύο τμήματα στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ανοίγει ξανά και επαληθεύει τις αποθηκευμένες τιμές:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) ενώνει γειτονικά τμήματα που έχουν την ίδια μορφοποίηση. Μία διαφορά μόνο στο `SpellCheck` δεν επαρκεί για να διατηρηθούν τα τμήματα ξεχωριστά· μετά την ένωση, το αποτέλεσμα διατηρεί την τιμή `SpellCheck` του πρώτου τμήματος. Εάν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου, καλέστε `joinPortionsWithSameFormatting` πριν ορίσετε αυτές τις ρυθμίσεις ή ελέγξτε τα όρια του προκύπτοντος τμήματος και επαναεφαρμόστε τις ρυθμίσεις κατόπιν. Τμήματα με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστά επειδή η μορφοποίηση της γλώσσας απόδειξης διαφέρει.

## **Συχνές ερωτήσεις**

**Μεταφράζει ένας αναγνωριστής γλώσσας το κείμενο;**

Όχι. Το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) αποθηκεύει μεταδεδομένα απόδειξης για ορθογραφία και γραμματική· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ο έλεγχος απόδειξης ελέγχει τις γραμματοσειρές, την συλλαβοποίηση ή τη διάσπαση γραμμών;**

Όχι. Το αναγνωριστικό γλώσσας προορίζεται για την απόδειξη. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/java/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, ρυθμίστε την [font substitution](/slides/el/java/font-substitution/) ή [ενσωματώστε γραμματοσειρές](/slides/el/java/embedded-font/) στην παρουσίαση.

**Μπορεί μια παράγραφος να χρησιμοποιεί πολλές γλώσσες απόδειξης;**

Ναι. Αναθέστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως φαίνεται στο παράδειγμα πολύγλωσσης παραγράφου.

**Πρέπει να χρησιμοποιήσω το `setDefaultTextLanguage` ή το `setLanguageId`;**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) όταν θέλετε μια προεπιλογή για το νεοδημιουργηθέν κείμενο. Χρησιμοποιήστε το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) όταν ένα συγκεκριμένο τμήμα χρειάζεται ρητά ορισμένη γλώσσα απόδειξης ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.