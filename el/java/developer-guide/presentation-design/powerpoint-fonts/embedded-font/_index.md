---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις σε Java
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/java/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειρών
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides για Java. Προσθέστε, ανακτήστε, αφαιρέστε και συμπιέστε γραμματοσειρές για να διατηρήσετε την εμφάνιση του κειμένου και να μειώσετε το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα της γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίζει το κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμα και αν δεν είναι εγκατεστημένες στο σύστημα προορισμού. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος κειμένου και της διάταξης των διαφάνειων.

Το Aspose.Slides for Java σας επιτρέπει να ανακτάτε, να προσθέτετε και να αφαιρείτε ενσωματωμένες γραμματοσειρές μέσω της διεπαφής IFontsManager που επιστρέφεται από τη μέθοδο Presentation.getFontsManager. Μπορείτε επίσης να μειώσετε το μέγεθος των δεδομένων ενσωματωμένης γραμματοσειράς αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παρακάτω παραδείγματα λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Ανάκτηση και κατάργηση ενσωματωμένων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο getEmbeddedFonts για να απαριθμήσετε τις γραμματοσειρές που αποθηκεύονται σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από τη λίστα στη μέθοδο removeEmbeddedFont και, στη συνέχεια, αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα απαριθμεί τις ενσωματωμένες γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αφαιρεί τη Calibri αν υπάρχει:
```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Η κατάργηση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει ανατεθεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα προορισμού, το κείμενο μπορεί ακόμη να τη χρησιμοποιήσει. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει [αντικατάσταση γραμματοσειράς](/slides/el/java/font-substitution/), κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Έλεγχος δεδομένων γραμματοσειράς και δικαιωμάτων ενσωμάτωσης**

Χρησιμοποιήστε τη διεπαφή IFontsManager για να ελέγξετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε τη μέθοδο IFontsManager.getFonts για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο IFontData και την απαιτούμενη τιμή FontStyleType στη μέθοδο IFontsManager.getFontBytes. Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για το συγκεκριμένο στυλ γραμματοσειράς, ή null όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε ένα αποτέλεσμα null στη μέθοδο IFontsManager.getFontEmbeddingLevel, επειδή αυτή η μέθοδος απαιτεί έναν πίνακα byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/java/com.aspose.slides/embeddinglevel/) είναι μια απαρίθμηση σημαδιών που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και την μόνιμη εγκατάσταση σε άλλο σύστημα, υπό τους όρους της άδειας της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μοναδική σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει την επεξεργασία και αποθήκευση του εγγράφου.
- `NoSubsetting` είναι πρόσθετος περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλυφών. Ενσωματώστε όλους τους χαρακτήρες όταν αυτή η σημαία υπάρχει.
- `BitmapOnly` είναι πρόσθετος περιορισμός που επιτρέπει την ενσωμάτωση μόνο bitmap εκδοχών, όχι των διαγραμμάτων. Εάν η γραμματοσειρά δεν διαθέτει bitmap εκδόσεις, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ τα `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν μαζί τους. Ελέγξτε τα μετατροπείς με λειτουργίες bitwise. Επειδή το `Installable` έχει τιμή μηδέν, αμαυρώστε τα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με το `Installable` αντί να το ελέγξετε ως σημαία. Οι τρέχουσες γραμματοσειρές θα πρέπει να ορίζουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που ορίζουν περισσότερα από ένα, ο παρακάτω βοηθός επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, μετά `PreviewPrint`, μετά `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα δεδομένα κανονικού, έντονου, πλάγιου και έντονο-πλάγιου τύπου που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφει η μέθοδος `getFonts`. Παραλείπει τα μη διαθέσιμα στυλ, τις περιορισμένες γραμματοσειρές, τις γραμματοσειρές μόνο bitmap, τις γραμματοσειρές περιορισμένες σε προεπισκόπηση και εκτύπωση επειδή το αποτέλεσμα παραμένει επεξεργάσιμο, και τις γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για αυτήν την οικογένεια γραμματοσειρών.
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που είναι κωδικοποιημένοι σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδείχνει ότι αποκτήσατε τη γραμματοσειρά νόμιμα και δεν αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν διανείμετε ένα ενσωματωμένο αντίγραφο.

## **Προσθήκη ενσωματωμένων γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο addEmbeddedFont για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις της δέχονται είτε ένα αντικείμενο IFontData είτε έναν πίνακα byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαρίθμηση EmbedFontCharacters ελέγχει ποιοι χαρακτήρες θα συμπεριληφθούν:

- [All](https://reference.aspose.com/slides/el/java/com.aspose.slides/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες της γραμματοσειράς. Χρησιμοποιήστε αυτήν την επιλογή όταν οι αποδέκτες χρειάζονται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/java/com.aspose.slides/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για να μειώσει το μέγεθος του αρχείου. Επιλέξτε αυτήν την επιλογή για μια τελική παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο getFonts για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο αρχείο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στο μηχάνημα που εκτελεί τον κώδικα. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.
```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συμπίεση ενσωματωμένων γραμματοσειρών**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) μειώνει τα δεδομένα ενσωματωμένης γραμματοσειράς αφαιρώντας αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, επομένως η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειράς περιέχει η παρουσίαση.

Το παρακάτω παράδειγμα συμπιέζει τις γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αποθηκεύει το αποτέλεσμα ως ξεχωριστό αρχείο:
```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Διατηρήστε το αρχικό αρχείο εάν οι αποδέκτες ενδέχεται να χρειαστούν να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη κι αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ελέγξω αν μια ενσωματωμένη γραμματοσειρά θα αντικατασταθεί ακόμα κατά την απόδοση;**

Καλέστε τη μέθοδο getSubstitutions στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει το Aspose.Slides. Ελέγξτε επίσης τις ρυθμίσεις [αντικατάστασης γραμματοσειράς](/slides/el/java/font-substitution/) και τους κανόνες [εναλλακτικής γραμματοσειράς](/slides/el/java/fallback-font/). Η εναλλακτική διαχειρίζεται τους ελλιπείς χαρακτήρες, επομένως η ενσωμάτωση μιας γραμματοσειράς δεν επιλύει χαρακτήρες που η ίδια η γραμματοσειρά δεν περιέχει.

**Πρέπει να ενσωματώνω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βάλετε την απόφαση στο περιβάλλον προορισμού. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε μηχάνημα που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωση τους μπορεί να προσθέσει περιττό μέγεθος αρχείου. Εάν οι αποδέκτες ή οι διακομιστές ενδέχεται να μην διαθέτουν αυτές τις γραμματοσειρές, η ενσωμάτωση τους μπορεί να βοηθήσει στη διατήρηση της προβλεπόμενης εμφάνισης, εφόσον οι άδειές τους το επιτρέπουν.