---
title: Αυτοματοποιήστε την τοπικοποίηση παρουσίασης σε JavaScript
linktitle: Τοπικοποίηση παρουσίασης
type: docs
weight: 100
url: /el/nodejs-java/presentation-localization/
keywords:
- αλλαγή γλώσσας
- ορθογραφικός έλεγχος
- κατάσβεση ορθογραφικού ελέγχου
- γλώσσα απόδειξης
- αναγνωριστικό γλώσσας
- πολυγλωσσικό κείμενο
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ορίστε γλώσσες απόδειξης για κείμενο παρουσίασης PowerPoint και OpenDocument σε JavaScript με Aspose.Slides, συμπεριλαμβανομένων προεπιλογών και πολυγλωσσικών παραγράφων."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java σάς επιτρέπει να διαμορφώσετε μεταδεδομένα ελέγχου απόδειξης για μεμονωμένες περιοχές κειμένου. Χρησιμοποιήστε [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) για να προσδιορίσετε τη γλώσσα απόδειξης, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) για να επιτρέψετε ή να καταστείλετε τον ορθογραφικό έλεγχο, και [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) για να ελέγξετε την ευρύτερη κατάσταση «μη απόδειξης». Επειδή αυτές οι ρυθμίσεις εφαρμόζονται σε επίπεδο περιοχής, μια παράγραφος μπορεί να περιέχει πολλαπλές γλώσσες και διαφορετικούς κανόνες απόδειξης.

Αυτό το άρθρο εξηγεί πώς να εκχωρήσετε μια γλώσσα σε συγκεκριμένο κείμενο, να ορίσετε τη προεπιλεγμένη γλώσσα για νέο κείμενο με [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), να δημιουργήσετε πολύγλωσσες παραγράφους, να επιλέξετε μεταξύ `SpellCheck` και `ProofDisabled`, και να διατηρήσετε τις προτεινόμενες ρυθμίσεις όταν χρησιμοποιείτε [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Αυτές οι ιδιότητες αποθηκεύουν μεταδεδομένα για εφαρμογές παρουσίασης· δεν μεταφράζουν το κείμενο, δεν εκτελούν ορθογραφικό έλεγχο βάσει λεξικού και δεν επιστρέφουν λανθασμένες λέξεις.

## **Ορισμός της γλώσσας απόδειξης για κείμενο**

Δημιουργήστε ή φορτώστε ένα [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), αποκτήστε πρόσβαση στην απαιτούμενη περιοχή κειμένου μέσω [Portion.getPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getPortionFormat--), και εκχωρήστε το αναγνωριστικό της γλώσσας. Το παρακάτω παράδειγμα δημιουργεί ένα σχήμα, ορίζει τη βρετανική αγγλική ως γλώσσα απόδειξης και αποθηκεύει το αποτέλεσμα με [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός της προεπιλεγμένης γλώσσας για νέο κείμενο**

Χρησιμοποιήστε [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) για να καθορίσετε τη γλώσσα απόδειξης που το Aspose.Slides εκχωρεί σε νέο κείμενο. Αυτή η ρύθμιση είναι χρήσιμη όταν το περισσότερο ή όλο το νέο κείμενο σε μια παρουσίαση χρησιμοποιεί την ίδια γλώσσα. Δεν αλλάζει τα μεταδεδομένα γλώσσας κειμένου που ήδη έχει  explicit language.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση της οποίας το νέο κείμενο χρησιμοποιεί γερμανικούς κανόνες απόδειξης:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Χρήση πολλαπλών γλωσσών σε μία παράγραφο**

Ένα [Paragraph](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/paragraph/) περιέχει μια συλλογή περιοχών κειμένου. Δημιουργήστε ξεχωριστό [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) για κάθε γλώσσα και ορίστε το `LanguageId` του ανεξάρτητα.

Αυτό το παράδειγμα δημιουργεί μια παράγραφο με αγγλικές και γαλλικές περιοχές:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ενεργοποίηση ή κατάστολη του ορθογραφικού ελέγχου για μεμονωμένες περιοχές**

[PortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portionformat/) κληρονομεί τις κοινές ιδιότητες κειμένου που ορίζονται από [BasePortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/). Πρόσβαση στη μορφοποίηση μιας περιοχής μέσω [Portion.getPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getPortionFormat--) και χρήση του [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) για να ελέγξετε αν μια εφαρμογή παρουσίασης μπορεί να ελέγξει την ορθογραφία για αυτήν την περιοχή. Η προεπιλεγμένη τιμή είναι `false`: το `true` επιτρέπει τον έλεγχο, ενώ το `false` τον καταστέλλει.

Η ρύθμιση εφαρμόζεται σε μεμονωμένες περιοχές κειμένου. Διαφορετικές περιοχές στην ίδια παράγραφο μπορούν επομένως να χρησιμοποιούν διαφορετικές τιμές. Το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) και το `setSpellCheck` εξυπηρετούν συμπληρωματικούς σκοπούς: το `setLanguageId` προσδιορίζει τη γλώσσα απόδειξης, ενώ το `setSpellCheck` καθορίζει αν επιτρέπεται ο ορθογραφικός έλεγχος για την περιοχή.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) ελέγχει επίσης την απόδειξη, αλλά αντιπροσωπεύει την ευρύτερη κατάσταση «μη απόδειξης» ως [NullableBool](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/nullablebool/). Χρησιμοποιήστε το `setSpellCheck` όταν χρειάζεστε άμεσο διακόπτη Boolean ειδικά για ορθογραφικούς ελέγχους. Χρησιμοποιήστε το `setProofDisabled` όταν θέλετε να διατηρήσετε ή να ελέγξετε ρητά τα μεταδεδομένα «μη απόδειξης» της παρουσίασης, συμπεριλαμβανομένης της κατάστασης `NotDefined`. Εάν ορίσετε και τις δύο ιδιότητες, κρατήστε τις τιμές τους συνεπείς· μην συνδυάζετε `setSpellCheck(true)` με `setProofDisabled(NullableBool.True)`.

Αυτές οι ιδιότητες διαμορφώνουν μεταδεδομένα απόδειξης που χρησιμοποιούν το PowerPoint και άλλες εφαρμογές παρουσίασης. Το Aspose.Slides δεν τις χρησιμοποιεί για εκτέλεση λεξικού ορθογραφικού ελέγχου ή επιστροφή λίστας λανθασμένων λέξεων.

Το παρακάτω πλήρες παράδειγμα δημιουργεί μια παρουσίαση εισόδου, τη φορτώνει, εκχωρεί διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου και γλώσσες απόδειξης σε δύο περιοχές στην ίδια παράγραφο, αποθηκεύει το αποτέλεσμα, το ξανανοίγει και επαληθεύει τις αποθηκευμένες τιμές:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) συνδυάζει γειτονικές περιοχές που έχουν την ίδια μορφοποίηση. Μια διαφορά στο `SpellCheck` μόνο δεν διατηρεί τις περιοχές ξεχωριστές· αφού ενωθούν, η προκύπτουσα περιοχή διατηρεί την τιμή `SpellCheck` της πρώτης περιοχής. Εάν οι περιοχές χρειάζονται διαφορετικές ρυθμίσεις ορθογραφικού ελέγχου, καλέστε το `joinPortionsWithSameFormatting` πριν ορίσετε αυτές τις ρυθμίσεις, ή εξετάστε τα όρια της προκύπτουσας περιοχής και εφαρμόστε ξανά τις ρυθμίσεις μετά. Οι περιοχές με διαφορετικές τιμές `LanguageId` παραμένουν ξεχωριστές επειδή η μορφοποίηση της γλώσσας απόδειξης διαφέρει.

## **Συχνές Ερωτήσεις**

**Μεταφράζει ένας κωδικός γλώσσας το κείμενο;**

Οχι. Το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) αποθηκεύει μεταδεδομένα απόδειξης για ορθογραφικό και γραμματικό έλεγχο· δεν αλλάζει το περιεχόμενο του κειμένου. Μεταφράστε το κείμενο ξεχωριστά και, στη συνέχεια, ορίστε το κατάλληλο αναγνωριστικό γλώσσας για κάθε μεταφρασμένη περιοχή.

**Ο έλεγχος απόδειξης ελέγχει γραμματοσειρές, συλλαβισμό ή αναδίπλωση γραμμής;**

Οχι. Το αναγνωριστικό γλώσσας προορίζεται για απόδειξη. Η απόδοση κειμένου και η διάταξη εξαρτώνται κυρίως από τις διαθέσιμες [fonts](/slides/el/nodejs-java/powerpoint-fonts/), το σύστημα γραφής και τις ρυθμίσεις του πλαισίου κειμένου. Για αξιόπιστη απόδοση, προσφέρετε τις απαιτούμενες γραμματοσειρές, ρυθμίστε την [font substitution](/slides/el/nodejs-java/font-substitution/), ή [embed fonts](/slides/el/nodejs-java/embedded-font/) στην παρουσίαση.

**Μπορεί μια παράγραφος να χρησιμοποιήσει πολλές γλώσσες απόδειξης;**

Ναι. Εκχωρήστε κάθε γλώσσα σε ξεχωριστή περιοχή, όπως δείχνει το παράδειγμα πολυγλωσσικής παραγράφου.

**Πρέπει να χρησιμοποιήσω `setDefaultTextLanguage` ή `setLanguageId`;**

Χρησιμοποιήστε το [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) όταν θέλετε μια προεπιλογή για νέο κείμενο. Χρησιμοποιήστε το [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) όταν μια συγκεκριμένη περιοχή χρειάζεται ρητή γλώσσα απόδειξης ή όταν μια παράγραφος περιέχει πολλαπλές γλώσσες.