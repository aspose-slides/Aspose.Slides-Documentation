---
title: Καθορισμός της Αρχικής Μορφής Παρουσίασης στο Android
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/androidjava/detect-presentation-source-format/
keywords:
- μορφή πηγής
- αναγνώριση μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης στο Android με το Aspose.Slides για Android μέσω Java, συγκρίνετε τα API ανίχνευσης και διαχειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSourceFormat--) για να προσδιορίσετε την αρχική της μορφή. Η μέθοδος είναι επίσης διαθέσιμη μέσω του [IPresentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Χρησιμοποιήστε τη όταν η επακόλουθη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε η τρέχουσα παρουσίαση.

Η πηγαία μορφή διαφέρει από το [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει την πηγαία μορφή της υπάρχουσας παρουσίασης.

Τα παραδείγματα χρησιμοποιούν Java και διαδρομές αρχείων. Στο Android, αντικαταστήστε τις δείγματες διαδρομές με διαδρομές σε αποθηκευτικό χώρο προσβάσιμο από την εφαρμογή, όπως ο εσωτερικός φάκελος αρχείων της εφαρμογής σας.

## **Ανάγνωση της Πηγαίας Μορφής ενός Αρχείου**

Το παράδειγμα αυτό απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας της εφαρμογής χρησιμοποιώντας το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSourceFormat--), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

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

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Η κλάση [SourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sourceformat/) ορίζει ακέραιους σταθερούς που διακρίνουν τις παρακάτω μορφές παρουσίασης. Οι επεκτάσεις παρακάτω είναι συμβατικές, όχι μια ανακατασκευή του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολές |
| `Pps` | `.pps` | Παρουσίαση διαφανειών PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Παρουσίαση διαφανειών Office Open XML |
| `Ppsm` | `.ppsm` | Παρουσίαση διαφανειών Office Open XML με μακροεντολές |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολές |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της Πηγαίας Μορφής από Ροή**

Το παράδειγμα αυτό απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των byte του σε μνήμη‑ροή προσομοιώνει είσοδο που λαμβάνεται χωρίς όνομα αρχείου, όπως μια τιμή βάσης δεδομένων ή ένα ανεβασμένο πίνακα byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) δέχεται μόνο τη ροή.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Κατά τη φόρτωση με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει στην διαφοροποίηση μιας παρουσίασης διαφανειών ή πρότυπου. Χωρίς όνομα αρχείου, το παλαιότερο περιεχόμενο PPS και POT ενδέχεται να αναφέρεται ως `SourceFormat.Ppt`; το παραπάνω παράδειγμα PPS εκτυπώνει την ακέραια τιμή του `SourceFormat.Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Μια επέκταση είναι χρήσιμη υπόδειξη για αυτά τα παλαιότερα υποτύπα, αλλά δεν πρέπει να είναι η μοναδική βάση για τον εντοπισμό αυθαίρετου περιεχομένου παρουσίασης.

## **Σύγκριση Ανίχνευσης Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και το [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) όταν χρειάζεται να εξετάσετε ένα αρχείο πριν φορτώσετε το πλήρες αντικείμενο παρουσίασης. Χρησιμοποιήστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSourceFormat--) όταν η παρουσίαση υπάρχει ήδη.

Το παράδειγμα αυτό απαιτεί `sample.pptx` και εκτυπώνει τις ακέραιες τιμές του `LoadFormat.Pptx` και του `SourceFormat.Pptx`, αντίστοιχα. Σε παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν χρειάζεται δεύτερη εξέταση μόνο για την απόκτηση της πηγαίας μορφής.

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

Τα αποτελέσματα χρησιμοποιούν σταθερές από διαφορετικές κλάσεις: [LoadFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sourceformat/). Μην συγκρίνετε τις αριθμητικές τους τιμές ή υποθέτετε ότι κάθε μορφή έχει τα ίδια αποτελέσματα ανίχνευσης. Το PowerPoint XML μπορεί να αναφέρεται ως `LoadFormat.Unknown` πριν τη φόρτωση και ως `SourceFormat.Xml` μετά τη φόρτωση.

## **Διατήρηση της Πηγαίας και της Εξόδου Μορφής Ξεχωριστά**

Το παράδειγμα αυτό απαιτεί `sample.pptx` και γράφει `converted.odp`. Εκτυπώνει την ακέραια τιμή του `SourceFormat.Pptx` τόσο πριν όσο και μετά την αποθήκευση της αρχικής παρουσίασης. Μόνο η νέα παρουσίαση που φορτώνεται από το αρχείο ODP αναφέρει `Odp`.

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

Μια παρουσίαση που δημιουργείται από το μηδέν με `new Presentation()` αναφέρει `SourceFormat.Pptx`. Δεν υπάρχει αρχείο εισόδου: αυτή είναι η προεπιλεγμένη τιμή για μια νεοδημιουργημένη παρουσίαση, όχι ένδειξη ότι φορτώθηκε αρχείο PPTX. Παρακολουθείτε εάν η εφαρμογή σας δημιούργησε ή διέσωσε την παρουσίαση ξεχωριστά, αν αυτή η διάκριση είναι σημαντική.

## **Χαρτογράφηση Πηγαίας Μορφής σε Επέκταση**

Το παρακάτω παράδειγμα απαιτεί `sample.pptx`. Αντιστοιχίζει κάθε τρέχουσα υποστηριζόμενη τιμή του [SourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/sourceformat/) σε συμβατική επέκταση, χωρίς να αναλύει το όνομα του εισερχόμενου αρχείου. Η εναλλακτική λύση αποτρέπει την σιωπηρή ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

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

Αυτή η αντιστοίχηση δεν μετατρέπει αρχείο ή δεν ανακτά υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση από ροή. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/), ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών με Αποθήκευση και Επανάληψη Φόρτωσης**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Επαναφορτώνει κάθε έξοδο τόσο μέσω διαδρομής όσο και μέσω μνήμης‑ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν την αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων byte χωρίς όνομα αρχείου αναφέρει `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Το περιεχόμενο PPS/POT αναγνωρίζεται ως `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την αναγνώριση μορφής, όχι τη διατήρηση κάθε δυνατότητας της παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP την πηγαία μορφή μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα παρουσίαση εξακολουθεί να αναφέρει `Pptx`. Μια παρουσίαση που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλαιά παρουσίαση, προβολή διαφανειών και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την ίδια δυαδική μορφή. Κρατήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω αν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για έλεγχο πριν τη φόρτωση.