---
title: Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις στο Android
linktitle: Ενσωματωμένες Γραμματοσειρές
type: docs
weight: 40
url: /el/androidjava/embedded-font/
keywords:
- προσθήκη γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- ενσωμάτωση γραμματοσειράς
- λήψη ενσωματωμένης γραμματοσειράς
- προσθήκη ενσωματωμένης γραμματοσειράς
- αφαίρεση ενσωματωμένης γραμματοσειράς
- συμπίεση ενσωματωμένης γραμματοσειράς
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ενσωματωμένες γραμματοσειρές στο PowerPoint με το Aspose.Slides για Android μέσω Java. Προσθέστε, ανακτήστε, αφαιρέστε και συμπιέστε γραμματοσειρές για να διατηρήσετε την εμφάνιση του κειμένου και να μειώσετε το μέγεθος του αρχείου."
---
## **Εισαγωγή**

Η ενσωμάτωση γραμματοσειρών αποθηκεύει τα δεδομένα γραμματοσειράς μέσα σε μια παρουσίαση PowerPoint. Όταν ένας προβολέας υποστηρίζει ενσωματωμένες γραμματοσειρές, μπορεί να εμφανίζει κείμενο χρησιμοποιώντας αυτές τις γραμματοσειρές ακόμη και αν δεν είναι εγκατεστημένες στο σύστημα‑στόχο. Αυτό βοηθά στη διατήρηση των αλλαγών γραμμής, του διαστήματος του κειμένου και της διάταξης των διαφανειών.

Το Aspose.Slides for Android μέσω Java σας επιτρέπει να ανακτάτε, να προσθέτετε και να αφαιρείτε ενσωματωμένες γραμματοσειρές μέσω της διεπαφής [IFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/) που επιστρέφεται από το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getFontsManager--). Μπορείτε επίσης να μειώσετε το μέγεθος των δεδομένων ενσωματωμένων γραμματοσειρών αφαιρώντας χαρακτήρες που δεν χρησιμοποιεί η παρουσίαση.

Τα παραδείγματα παρακάτω λειτουργούν με αρχεία PPTX. Πριν ενσωματώσετε μια γραμματοσειρά, βεβαιωθείτε ότι τα δεδομένα της γραμματοσειράς είναι διαθέσιμα στο Aspose.Slides και ότι η άδειά της επιτρέπει την ενσωμάτωση.

## **Ανάκτηση και Αφαίρεση Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε το [getEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) για να απαριθμήσετε τις γραμματοσειρές που αποθηκεύονται σε μια παρουσίαση. Για να αφαιρέσετε μία, περάστε μια γραμματοσειρά από αυτή τη λίστα στη μέθοδο [removeEmbeddedFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), και έπειτα αποθηκεύστε την παρουσίαση.

Το παρακάτω παράδειγμα απαριθμεί τις ενσωματωμένες γραμματοσειρές στο αρχείο `EmbeddedFonts.pptx` και αφαιρεί το Calibri αν υπάρχει:
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

Η αφαίρεση μιας ενσωματωμένης γραμματοσειράς αφαιρεί τα αποθηκευμένα δεδομένα της γραμματοσειράς· δεν αλλάζει τη γραμματοσειρά που έχει αντιστοιχιστεί στο κείμενο. Εάν η γραμματοσειρά είναι εγκατεστημένη στο σύστημα‑στόχο, το κείμενο μπορεί να τη χρησιμοποιεί ακόμη. Διαφορετικά, η απόδοση ενδέχεται να απαιτήσει [font substitution](/slides/el/androidjava/font-substitution/), κάτι που μπορεί να επηρεάσει τη διάταξη.

## **Επιθεώρηση Δεδομένων Γραμματοσειράς και Δικαιωμάτων Ενσωμάτωσης**

Χρησιμοποιήστε τη διεπαφή [IFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/) για να επιθεωρήσετε τις γραμματοσειρές πριν τις ενσωματώσετε. Καλέστε τη μέθοδο [IFontsManager.getFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) για να ανακτήσετε τις γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση. Για κάθε γραμματοσειρά, περάστε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontdata/) και την απαιτούμενη τιμή [FontStyleType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fontstyletype/) στη μέθοδο [IFontsManager.getFontBytes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Η μέθοδος επιστρέφει τα δυαδικά δεδομένα για αυτό το στυλ γραμματοσειράς, ή `null` όταν η ζητούμενη γραμματοσειρά ή στυλ δεν είναι διαθέσιμα. Μην περάσετε ένα αποτέλεσμα `null` στη μέθοδο [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), επειδή αυτή η μέθοδος απαιτεί σειρά byte.

[EmbeddingLevel](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/embeddinglevel/) είναι μια απαριθμητική σημαία (flags enumeration) που αναφέρει τους περιορισμούς ενσωμάτωσης που αποθηκεύονται στη γραμματοσειρά:

- `Installable` επιτρέπει την ενσωμάτωση και την μόνιμη εγκατάσταση σε άλλο σύστημα, υπό την άδεια της γραμματοσειράς.
- `Restricted` απαγορεύει την ενσωμάτωση εκτός εάν ληφθεί άδεια από τον νόμιμο κάτοχο της γραμματοσειράς όταν είναι η μόνη σημαία άδειας χρήσης.
- `PreviewPrint` επιτρέπει προσωρινή χρήση για προβολή και εκτύπωση· ένα έγγραφο που περιέχει τη γραμματοσειρά πρέπει να είναι μόνο για ανάγνωση.
- `Editable` επιτρέπει προσωρινή χρήση και επιτρέπει το έγγραφο να επεξεργασθεί και να αποθηκευτεί.
- `NoSubsetting` είναι ένας επιπλέον περιορισμός που απαγορεύει την ενσωμάτωση μόνο ενός υποσυνόλου των γλύφων. Ενσωματώνει όλους τους χαρακτήρες όταν αυτή η σημαία είναι παρούσα.
- `BitmapOnly` είναι ένας επιπλέον περιορισμός που επιτρέπει μόνο bitmap strikes να ενσωματωθούν, όχι δεδομένα περίγραμμα. Εάν η γραμματοσειρά δεν έχει bitmap strikes, δεν μπορεί να ενσωματωθεί.

Οι πρώτες τέσσερις τιμές περιγράφουν την άδεια χρήσης, ενώ τα `NoSubsetting` και `BitmapOnly` μπορούν να συνδυαστούν με αυτές. Ελέγξτε τις τροποποιητικές σημαίες με λογικές πράξεις bitwise. Επειδή το `Installable` είναι μηδέν, εφαρμόστε μάσκα στα bits άδειας χρήσης και συγκρίνετε το αποτέλεσμα με `Installable` αντί να το ελέγξετε ως σημαία. Οι τρέχουσες γραμματοσειρές πρέπει να θέτουν το πολύ ένα bit άδειας χρήσης. Για συμβατότητα με παλαιότερες γραμματοσειρές που θέτουν περισσότερα από ένα, ο βοηθός παρακάτω επιλέγει την λιγότερο περιοριστική άδεια: `Editable`, έπειτα `PreviewPrint`, έπειτα `Restricted`.

Το παρακάτω παράδειγμα ελέγχει τα δεδομένα κανονικού, έντονου, πλαγίου και έντονο‑πλάγιου που είναι διαθέσιμα για κάθε γραμματοσειρά που επιστρέφεται από τη μέθοδο `getFonts`. Παραλείπει στυλ που δεν είναι διαθέσιμα, περιορισμένες γραμματοσειρές, γραμματοσειρές μόνο bitmap, γραμματοσειρές που περιορίζονται σε προεπισκόπηση και εκτύπωση επειδή η έξοδος παραμένει επεξεργάσιμη, και γραμματοσειρές που είναι ήδη ενσωματωμένες. Εάν κάποιο διαθέσιμο στυλ έχει `NoSubsetting`, ενσωματώνει όλους τους χαρακτήρες για αυτή την οικογένεια γραμματοσειρών.
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

Αυτή η επιθεώρηση αναφέρει τους περιορισμούς που κωδικοποιούνται σε κάθε αρχείο γραμματοσειράς. Δεν παρέχει άδεια, δεν αποδεικνύει ότι αποκτήσατε τη γραμματοσειρά νόμιμα, ούτε αντικαθιστά τον έλεγχο της άδειας χρήσης της γραμματοσειράς πριν τη διανομή μιας ενσωματωμένης αντιγραφής.

## **Προσθήκη Ενσωματωμένων Γραμματοσειρών**

Χρησιμοποιήστε τη μέθοδο [addEmbeddedFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) για να ενσωματώσετε μια γραμματοσειρά. Οι υπερφορτώσεις της δέχονται είτε ένα αντικείμενο [IFontData](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontdata/) είτε μια σειρά byte που περιέχει τα δεδομένα της γραμματοσειράς. Η απαριθμητική τιμή [EmbedFontCharacters](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/embedfontcharacters/) ελέγχει ποιοι χαρακτήρες περιλαμβάνονται:

- [All](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/embedfontcharacters/) ενσωματώνει όλους τους χαρακτήρες στη γραμματοσειρά. Χρησιμοποιήστε αυτή την επιλογή όταν οι αποδέκτες χρειάζεται να επεξεργαστούν την παρουσίαση και να εισάγουν νέο κείμενο.
- [OnlyUsed](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/embedfontcharacters/) ενσωματώνει μόνο τους χαρακτήρες που χρησιμοποιούνται στην παρουσίαση για μείωση του μεγέθους του αρχείου. Επιλέξτε αυτή την επιλογή για μια ολοκληρωμένη παρουσίαση που προορίζεται κυρίως για προβολή.

Το παρακάτω παράδειγμα χρησιμοποιεί τη μέθοδο [getFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) για να ανακτήσει τις γραμματοσειρές που χρησιμοποιούνται στο αρχείο `Fonts.pptx` και ενσωματώνει εκείνες που δεν είναι ήδη ενσωματωμένες. Οι γραμματοσειρές που θα προστεθούν πρέπει να είναι διαθέσιμες στη συσκευή Android ή να έχουν καταχωρηθεί στο Aspose.Slides. Οι υπάρχουσες ενσωματωμένες γραμματοσειρές διατηρούν τα τρέχοντα σύνολα χαρακτήρων τους.
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

## **Συμπίεση Ενσωματωμένων Γραμματοσειρών**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) μειώνει τα δεδομένα ενσωματωμένων γραμματοσειρών αφαιρώντας αχρησιμοποίητους χαρακτήρες. Λειτουργεί σε γραμματοσειρές που είναι ήδη ενσωματωμένες, επομένως η μείωση του μεγέθους εξαρτάται από το πόσα αχρησιμοποίητα δεδομένα γραμματοσειρών περιέχει η παρουσίαση.

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

Διατηρήστε το αρχικό αρχείο εάν οι αποδέκτες ενδέχεται να χρειαστεί να προσθέσουν κείμενο αργότερα. Οι χαρακτήρες που αφαιρέθηκαν κατά τη συμπίεση δεν είναι πλέον διαθέσιμοι από την ενσωματωμένη γραμματοσειρά, ακόμη και αν αρχικά ενσωματώσατε όλους τους χαρακτήρες.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν μια ενσωματωμένη γραμματοσειρά θα αντικατασταθεί ακόμα κατά την απόδοση;**

Καλέστε τη μέθοδο [getSubstitutions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) στο περιβάλλον όπου αποδίδετε την παρουσίαση για να δείτε ποιες γραμματοσειρές θα αντικαταστήσει η Aspose.Slides. Επίσης ελέγξτε τις ρυθμίσεις [font substitution](/slides/el/androidjava/font-substitution/) και τους κανόνες [font fallback](/slides/el/androidjava/fallback-font/). Το fallback διαχειρίζεται ελλιπείς χαρακτήρες, επομένως η ενσωμάτωση μιας γραμματοσειράς δεν λύνει χαρακτήρες που δεν περιέχονται στη γραμματοσειρά.

**Πρέπει να ενσωματώνω κοινές γραμματοσειρές όπως Arial και Calibri;**

Βάσει της απόφασης στο περιβάλλον‑στόχο. Εάν οι απαιτούμενες γραμματοσειρές είναι διαθέσιμες σε κάθε συσκευή που ανοίγει ή αποδίδει την παρουσίαση, η ενσωμάτωσή τους μπορεί να προσθέσει περιττό μέγεθος αρχείου. Εάν οι αποδέκτες ή οι διακομιστές μπορεί να μην έχουν αυτές τις γραμματοσειρές, η ενσωμάτωση μπορεί να βοηθήσει στη διατήρηση της προγραμματισμένης εμφάνισης, υπό την προϋπόθεση ότι οι άδειές τους το επιτρέπουν.