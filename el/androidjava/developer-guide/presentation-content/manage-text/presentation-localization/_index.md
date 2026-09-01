---
title: "Αυτοματοποίηση τοπικοποίησης παρουσίασης σε Android"
linktitle: "Τοπικοποίηση Παρουσίασης"
type: docs
weight: 100
url: /el/androidjava/presentation-localization/
keywords:
- "αλλαγή γλώσσας"
- "ορθογραφικός έλεγχος"
- "απενεργοποίηση ορθογραφικού ελέγχου"
- "γλώσσα ελέγχου"
- "Αναγνωριστικό γλώσσας"
- "πολυγλωσσικό κείμενο"
- "PowerPoint"
- "παρουσίαση"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Ορίστε γλώσσες ελέγχου για κείμενο παρουσίασης PowerPoint και OpenDocument σε Android με Aspose.Slides for Android via Java, συμπεριλαμβανομένων των προεπιλογών και των πολυγλωσσικών παραγράφων."
---
## **Επισκόπηση**

Aspose.Slides for Android via Java σας επιτρέπει να διαμορφώσετε μεταδεδομένα ελέγχου για μεμονωμένα τμήματα κειμένου. Χρησιμοποιήστε [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) για να προσδιορίσετε τη γλώσσα ελέγχου, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) για να επιτρέψετε ή να καταστείλετε τον ορθογραφικό έλεγχο, και [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) για να ελέγξετε τη γενικότερη κατάσταση «μη επιβεβαίωσης». Δεδομένου ότι αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο τμήματος, μια παράγραφος μπορεί να περιέχει πολλές γλώσσες και διαφορετικούς κανόνες ελέγχου.

Αυτό το άρθρο εξηγεί πώς να ορίσετε μια γλώσσα σε συγκεκριμένο κείμενο, να θέσετε την προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), να δημιουργήσετε πολυγλωσσικές παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled`, και να διατηρήσετε τις προτιμώμενες ρυθμίσεις όταν χρησιμοποιείτε [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν κείμενο, δεν εκτελούν ορθογραφικό έλεγχο βάσει λεξικού, ούτε επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός της γλώσσας ελέγχου για κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/), αποκτήστε το απαιτούμενο τμήμα κειμένου μέσω του [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getPortionFormat--), και ορίστε το αναγνωριστικό γλώσσας του. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τη βρετανική αγγλική ως γλώσσα ελέγχου, και αποθηκεύει το αποτέλεσμα με το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να καθορίσετε τη γλώσσα ελέγχου που το Aspose.Slides θα εκχωρεί στο νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν η πλειονότητα ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας κειμένου που ήδη έχει ρητή γλώσσα.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες ελέγχου:

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

## **Χρήση πολλαπλών γλωσσών σε μία παράγραφο**

Ένα [IParagraph](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iparagraph/) περιλαμβάνει μια συλλογή τμημάτων κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/portion/) για κάθε γλώσσα και ορίστε το `LanguageId` ανεξάρτητα.

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

## **Ενεργοποίηση ή κατάσβεση ορθογραφικού ελέγχου για μεμονωμένα τμήματα**

[IPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από το [IBasePortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/). Προσπελάστε τη μορφοποίηση ενός τμήματος μέσω του [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getPortionFormat--) και χρησιμοποιήστε το [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) για να ελέγξετε αν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για εκείνο το τμήμα. Η προεπιλεγμένη τιμή είναι `false`: `true` επιτρέπει τον έλεγχο, ενώ `false` τον καταστέλλει.

Η ρύθμιση ισχύει για μεμονωμένα τμήματα κειμένου. Διαφορετικά τμήματα στην ίδια παράγραφο μπορούν επομένως να χρησιμοποιούν διαφορετικές τιμές. Τα [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) και `setSpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `setLanguageId` προσδιορίζει τη γλώσσα ελέγχου, ενώ το `setSpellCheck` καθορίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για το τμήμα.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ελέγχει επίσης τον έλεγχο, αλλά αντιπροσωπεύει τη γενικότερη κατάσταση «μη επιβεβαίωσης» ως [NullableBool](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/nullablebool/). Χρησιμοποιήστε το `setSpellCheck` όταν χρειάζεστε άμεσο διακόπτη Boolean ειδικά για ορθογραφικό έλεγχο. Χρησιμοποιήστε το `setProofDisabled` όταν πρέπει να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη επιβεβαίωσης» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NotDefined`. Αν ορίσετε και τις δύο ιδιότητες, διατηρήστε τις τιμές τους συνεπείς· μην συνδυάσετε `setSpellCheck(true)` με `setProofDisabled(NullableBool.True)`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα ελέγχου που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για να εκτελέσει λεξικό‑βασισμένο ορθογραφικό έλεγχο ή για να επιστρέψει λίστα λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια είσοδο παρουσίασης, τη φορτώνει, ορίζει διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες ελέγχου για δύο τμήματα στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ανοίγει ξανά και επαληθεύει τις αποθηκευμένες τιμές:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) ενώνει διαδοχικά τμήματα που έχουν την ίδια μορφοποίηση. Μια διαφορά μόνο στο `SpellCheck` δεν διατηρεί αυτά τα τμήματα χωριστά· αφού ενωθούν, το προκύπτον τμήμα διατηρεί την τιμή `SpellCheck` του πρώτου τμήματος. Εάν τα τμήματα χρειάζονται διαφορετικές ρυθμίσεις ελέγχου, καλέστε το `joinPortionsWithSameFormatting` πριν ορίσετε αυτές τις ρυθμίσεις, ή ελέγξτε τα όρια του προκύπτοντος τμήματος και επαναεφαρμόστε τις ρυθμίσεις μετά. Τα τμήματα με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστά επειδή η μορφοποίηση γλώσσας ελέγχου διαφέρει.

## **Συχνές ερωτήσεις**

**Μεταφράζει ένα ID γλώσσας το κείμενο;**

Όχι. Το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) αποθηκεύει μεταδεδομένα ελέγχου για ορθογραφία και γραμματική· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένο τμήμα.

**Ο έλεγχος γλώσσας ελέγχει γραμματοσειρές, συλλαβισμό ή αναδίπλωση γραμμής;**

Όχι. Το αναγνωριστικό γλώσσας αφορά τον έλεγχο. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/androidjava/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, παρέχετε τις απαιτούμενες γραμματοσειρές, διαμορφώστε την [font substitution](/slides/el/androidjava/font-substitution/), ή [embed fonts](/slides/el/androidjava/embedded-font/) στην παρουσίαση.

**Μπορεί μια παράγραφος να χρησιμοποιεί πολλές γλώσσες ελέγχου;**

Ναι. Ορίστε κάθε γλώσσα σε ξεχωριστό τμήμα, όπως φαίνεται στο παράδειγμα πολύγλωσσης παραγράφου.

**Πρέπει να χρησιμοποιήσω το `setDefaultTextLanguage` ή το `setLanguageId`;**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) όταν θέλετε μια προεπιλογή για το νεοδημιουργηθέν κείμενο. Χρησιμοποιήστε το [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) όταν ένα συγκεκριμένο τμήμα χρειάζεται ρητή γλώσσα ελέγχου ή όταν μια παράγραφος περιέχει πολλές γλώσσες.