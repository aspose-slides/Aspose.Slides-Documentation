---
title: Προσδιορισμός της Αρχικής Μορφής Παρουσίασης σε Java
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/java/detect-presentation-source-format/
keywords:
- μορφή πηγής
- ανίχνευση μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης σε Java με το Aspose.Slides για Java, συγκρίνετε τα API ανίχνευσης και χειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--) για να προσδιορίσετε την αρχική της μορφή. Η μέθοδος είναι επίσης διαθέσιμη μέσω [IPresentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getSourceFormat--). Χρησιμοποιήστε τη όταν η επόμενη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε το τρέχον αντικείμενο.

Η πηγή μορφή είναι διαφορετική από το [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει τη μορφή πηγής του υπάρχοντος αντικειμένου.

## **Ανάγνωση της μορφής πηγής ενός αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας εφαρμογής χρησιμοποιώντας [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--), αντί για το όνομα αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Αναγνώριση των υποστηριζόμενων τιμών**

Η κλάση [SourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/sourceformat/) ορίζει ακέραιες σταθερές που διακρίνουν τις παρακάτω μορφές παρουσίασης. Οι επεκτάσεις παρακάτω είναι συμβατικές επεκτάσεις, όχι μια ανακατασκευή του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολή |
| `Pps` | `.pps` | Παρουσίαση διαφάνειας PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Παρουσίαση διαφάνειας Office Open XML |
| `Ppsm` | `.ppsm` | Παρουσίαση διαφάνειας Office Open XML με μακροεντολή |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολή |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της μορφής πηγής από ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των ψηφιολέξεων του σε μια μνήμη ροής προσομοιώνει είσοδο που λαμβάνεται χωρίς όνομα αρχείου, όπως μια τιμή βάσης δεδομένων ή ένας μεταφορτωμένος πίνακας bytes. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) λαμβάνει μόνο τη ροή.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Κατά τη φόρτωση με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει να διακρίνει μια παρουσίαση διαφάνειας ή πρότυπο. Χωρίς όνομα αρχείου, το παλαιό περιεχόμενο PPS και POT μπορεί να αναφερθεί ως `SourceFormat.Ppt`; το παραπάνω παράδειγμα PPS εκτυπώνει την ακέραια τιμή του `SourceFormat.Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Μία επέκταση είναι χρήσιμος δείκτης για αυτά τα παλαιά υποτυπώματα, αλλά δεν πρέπει να αποτελεί τη μοναδική βάση για την αναγνώριση αυθαίρετου περιεχομένου παρουσίασης.

## **Σύγκριση ανίχνευσης πριν και μετά τη φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και το [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) όταν χρειάζεται να εξετάσετε ένα αρχείο πριν τη φόρτωση του πλήρους μοντέλου αντικειμένων παρουσίασης. Χρησιμοποιήστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--) όταν το αντικείμενο υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και εκτυπώνει τις ακέραιες τιμές των `LoadFormat.Pptx` και `SourceFormat.Pptx`, αντίστοιχα. Σε παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν χρειάζεται δεύτερη εξέταση μόνο για την απόκτηση της μορφής πηγής της.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Τα αποτελέσματα χρησιμοποιούν σταθερές από διαφορετικές κλάσεις: [LoadFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/sourceformat/). Μην συγκρίνετε τις αριθμητικές τους τιμές ή υποθέτετε ότι κάθε μορφή έχει ταυτόσια αποτελέσματα ανίχνευσης. Το PowerPoint XML μπορεί να αναφερθεί ως `LoadFormat.Unknown` πριν από τη φόρτωση και ως `SourceFormat.Xml` μετά τη φόρτωση.

## **Διατήρηση ξεχωριστών μορφών πηγής και εξόδου**

Αυτό το παράδειγμα απαιτεί το `sample.pptx` και γράφει το `converted.odp`. Εκτυπώνει την ακέραια τιμή του `SourceFormat.Pptx` τόσο πριν όσο και μετά την αποθήκευση του αρχικού αντικειμένου. Μόνο το νέο αντικείμενο που φορτώθηκε από το αρχείο εξόδου ODP αναφέρει `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μια παρουσίαση που δημιουργείται από την αρχή με `new Presentation()` αναφέρει `SourceFormat.Pptx`. Δεν έχει αρχείο εισόδου: αυτή είναι η προεπιλογή για ένα νεοδημιουργημένο αντικείμενο, όχι απόδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθήστε εάν η εφαρμογή σας δημιούργησε ή φόρτωσε το αντικείμενο ξεχωριστά εάν αυτή η διάκριση έχει σημασία.

## **Αντιστοίχιση μορφής πηγής σε επέκταση**

Το παρακάτω παράδειγμα απαιτεί το `sample.pptx`. Αντιστοιχίζει κάθε τρέχουσα υποστηριζόμενη τιμή του [SourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/sourceformat/) σε μια συμβατική επέκταση, χωρίς να αναλύει το όνομα αρχείου εισόδου. Η εναλλακτική αποφεύγει την σιωπηρή εκχώρηση μιας επέκτασης σε μη αναγνωρισμένη τιμή.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Αυτή η αντιστοίχιση δεν μετατρέπει αρχείο ή ανακτά ένα παλαιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση από ροή. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/), ή χρησιμοποιήστε τη μετατροπή που εμφανίζεται στο [Save Presentations in Their Original Format](/slides/el/java/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση μορφών με αποθήκευση και επαναφόρτωση**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Επαναφέρει κάθε έξοδο τόσο με διαδρομή όσο και μέσω μνήμης ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων bytes χωρίς όνομα αρχείου αναφέρει `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ιδία με τη διαδρομή αρχείου |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ιδία με τη διαδρομή αρχείου |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ιδία με τη διαδρομή αρχείου |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ιδία με τη διαδρομή αρχείου |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Το περιεχόμενο PPS/POT αναγνωρίζεται ως `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την αναγνώριση μορφής, όχι τη διατήρηση κάθε χαρακτηριστικού παρουσίασης κατά τη μετατροπή.

## **FAQ**

**Αλλάζει η αποθήκευση σε ODP τη μορφή πηγής μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Το υπάρχον αντικείμενο εξακολουθεί να αναφέρει `Pptx`. Ένα αντικείμενο που φορτώθηκε από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διαχωρίσει μια παλιά παρουσίαση, μια παρουσίαση διαφάνειας και ένα πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται τη δυαδική μορφή. Κρατήστε το όνομα αρχείου ή μεταδεδομένα υποτύπου ξεχωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω αν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSourceFormat--). Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για εξέταση πριν τη φόρτωση.