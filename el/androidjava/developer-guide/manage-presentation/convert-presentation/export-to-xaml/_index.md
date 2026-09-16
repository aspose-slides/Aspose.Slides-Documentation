---
title: Εξαγωγή Παρουσιάσεων σε XAML στο Android
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/androidjava/export-to-xaml/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- PowerPoint σε XAML
- OpenDocument σε XAML
- παρουσίαση σε XAML
- PPT σε XAML
- PPTX σε XAML
- ODP σε XAML
- αποθήκευση PPT ως XAML
- αποθήκευση PPTX ως XAML
- αποθήκευση ODP ως XAML
- εξαγωγή PPT σε XAML
- εξαγωγή PPTX σε XAML
- εξαγωγή ODP σε XAML
- Android
- Java
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint και OpenDocument σε XAML με Java χρησιμοποιώντας το Aspose.Slides για Android—γρήγορη λύση χωρίς Office που διατηρεί το σχεδιασμό σας αμετάβλητο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides για Android μέσω Java. Περιλαμβάνει σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο απαντά επίσης σε μερικές κοινές ερωτήσεις σχετικά με τις εφεδρικές γραμματοσειρές, τη συμβατότητα στοίβας XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε τη σήμανση απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Επιλογές**

Το παρακάτω παράδειγμα Java δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με προεπιλεγμένες ρυθμίσεις:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, οι εξαγόμενες διαφάνειες αποθηκεύονται σε υποφακότομο `pres` του τρέχοντος καταλόγου εργασίας της διεργασίας. Ο φάκελος δημιουργείται αυτόματα και αποθηκεύονται επίσης τυχόν απαιτούμενες εικόνες.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχικού αρχείου χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.ο.κ. Ακόμη και αν περάσετε απόλυτη διαδρομή στο αρχείο εισόδου, ο φάκελος εξόδου δημιουργείται σχετικά με τον τρέχοντα κατάλογο εργασίας, όχι δίπλα στο αρχείο εισόδου.

Στο Android, χρησιμοποιήστε ένα αρχείο εισόδου προσβάσιμο από την εφαρμογή σας. Ο τρέχων κατάλογος εργασίας μπορεί να μην είναι εγγράψιμος· χρησιμοποιήστε έναν προσαρμοσμένο αποθηκευτή εξόδου για να διατηρήσετε την εξαγωγή στη μνήμη ή να την γράψετε στην αποθήκευση της εφαρμογής, όπως φαίνεται παρακάτω. Το παραγόμενο WPF XAML προορίζεται για έναν συμβατό καταναλωτή και δεν αποτελεί πόρο διάταξης Android.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Επιλογές**

Χρησιμοποιήστε τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη τοποθεσία, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ixamloutputsaver/) και περάστε μια παρουσία της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) του [XamlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) με `true`, όπως φαίνεται στο παρακάτω παράδειγμα Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Σύλληψη Όλων των Παραγόμενων Αντικειμένων XAML**

Μια εξαγωγή XAML μπορεί να παραγάγει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια μαζί με ξεχωριστές εικόνες και πρόσθετους πόρους. Εκχωρήστε έναν προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ixamloutputsaver/) στο [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) για να λαμβάνετε αυτά τα αντικείμενα αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με τη συγκεκριμένη για XAML μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) που δέχεται επιλογές XAML.

### **Κατανόηση του Κύκλου Ζωής της Επιστροφής**

Ο εξαγωγέας καλεί το [IXamlOutputSaver.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` προσδιορίζει το αντικείμενο και μπορεί να περιλαμβάνει σχετικούς καταλόγους. Διατηρήστε αυτήν την πληροφορία επειδή το XAML μπορεί να κάνει αναφορά σε πόρους με σχετικές διαδρομές.
- `data` περιέχει τα byte του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την επίμονη αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε πίνακα byte σε μνήμη που ανήκει στην εφαρμογή.
- Θεωρήστε την εξαγωγή επιτυχής μόνο όταν ολοκληρωθεί η αποθήκευση της παρουσίασης και όλες οι κλήσεις επιστροφής έχουν ολοκληρωθεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή ξεκινάτε αόρατες γραφές στο παρασκήνιο. Εάν η επίμονη αποθήκευση συμβεί μετά, αναφέρετε τη συνολική επιτυχία μόνο αφού ολοκληρωθεί και αυτό το βήμα.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ισχύει επίσης για έναν προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη τιμή, `false`, εξαιρεί τα έγγραφα XAML κρυφών διαφανειών. Η μετάδοση `true` τα συμπεριλαμβάνει μαζί με τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Οι αριθμοί πόρων εξαρτώνται από την παρουσίαση· μην υποθέετε μία κλήση ανά διαφάνεια ή μια σταθερή σειρά κλήσεων.

### **Εξαγωγή στη Μνήμη και Επιθεώρηση των Αντικειμένων**

Αυτό το ολοκληρωμένο παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε αντικείμενο σε ένα [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε byte. Διατηρεί τα παρεχόμενα ονόματα ακριβώς. Τα διπλότυπα ονόματα σηματοδοτούν τη συλλογή ως άκυρη αντί να επικαλύπτουν σιωπηλά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό πριν χρησιμοποιήσει τα αποτελέσματα.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Αποκωδικοποίηση μόνο XAML, και μόνο όταν απαιτείται κειμενική επιθεώρηση.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων των άγνωστων τύπων πόρων. Αφήστε τα byte αμετάβλητα κατά την αποθήκευση ή τη μετάδοση. Χρησιμοποιήστε τον κατασκευαστή [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) με UTF-8 μόνο για XAML που απαιτεί κειμενική επεξεργασία.

### **Συσκευασία Συλλεγμένων Αντικειμένων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματά της και γράφει τα αρχικά byte σε αρχείο ZIP. Αντικαταστήστε το `/path/to/app/files` με τη διαδρομή που επιστρέφει η μέθοδος [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) του Android context σας. Ένα μοναδικό όνομα αρχείου διαχωρίζει ταυτόχρονες εργασίες εξαγωγής. Οι καταχωρίσεις ZIP χρησιμοποιούν καθετούς (`/`) και διατηρούν τους σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτουν ολόκληρο το πακέτο πριν γραφτεί.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // Ο κατάλογος ZIP έχει ολοκληρωθεί κλείσιμο πριν την αναφορά της επιτυχίας.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Το παράδειγμα χρησιμοποιεί το [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) για να γράψει ένα τοπικό αρχείο ZIP· ο εξαγωγέας δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για απομακρυσμένη αποθήκευση, αντικαταστήστε το στάδιο εγγραφής του αρχείου με ανεβάσματα των συλλεγμένων byte arrays. Χρησιμοποιήστε αναγνωριστικό εργασίας εξαγωγής μαζί με το πλήρες σχετικό όνομα του αντικειμένου ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε μία σειρά βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλα τα ανεβάσματα ή η συναλλαγή της βάσης δεδομένων επιβεβαιωθεί. Καθαρίστε την μερική έξοδο εάν η μόνιμη αποθήκευση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει άμεσα κάθε αντικείμενο στην αποθήκευση της εφαρμογής ώστε να αποφεύγεται η διατήρηση ενός επιπλέον αντιγράφου όλης της εξαγωγής στη μνήμη της εφαρμογής. Κρατήστε κάθε κλήση συγχρονισμένη από την οπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός αποδεχτεί τα byte, και επιτρέψτε τις αποτυχίες να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομών όταν απαιτείται από τον προορισμό, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το [File.getName](https://developer.android.com/reference/java/io/File#getName()) εκτός εάν κάθε παραγόμενο όνομα είναι γνωστό ότι είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων συγκεκριμένης προορισμού. Κατά την εγγραφή ανεξάρτητων αρχείων, απορρίψτε διαδρομές που ξεκινούν από ρίζα και τμήματα διαπέρασης, επιλύστε τον προορισμό με το [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), και βεβαιωθείτε ότι παραμένει κάτω από τον προβλεπόμενο φάκελο εξαγωγής, συμπεριλαμβανομένου του διαχωριστικού καταλόγου στον έλεγχο περιέκτη. Χρησιμοποιήστε φάκελο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να ανακατευθύνουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας σε πεζά/κεφαλαία του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και ελέγξτε τις αναφορές πόρων βάσει αρχείου, όπως τα χαρακτηριστικά `Source` ή `ImageSource` των εικόνων. Επιλύστε κάθε σχετικό URI έναντι του καταλόγου του περιέχοντος αντικειμένου XAML, κανονικοποιήστε το προκύπτον όνομα αποθήκευσης και επιβεβαιώστε ότι υπάρχει το αντίστοιχο κλειδί χάρτη, η καταχώριση ZIP ή το αποθηκευμένο αντικείμενο. Αντιμετωπίστε τα εξωτερικά URI και τις εκφράσεις σήμανσης XAML ξεχωριστά από τα σχετικά ονόματα αρχείων.

Για παράδειγμα, εάν το `pres/Slide_1.xaml` αναφέρει το `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα σπάσει τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε εκείνα τα URL πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα των καταχωρίσεων και τα byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο στόχο XAML για να επιβεβαιώσετε ότι οι εικόνες επιλύονται σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Καλέστε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) στο [XamlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/) — χρησιμοποιείται ως εφεδρική γραμματοσειρά κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα κάνει αναφορά στην εφεδρική γραμματοσειρά ή ότι η γραμματοσειρά θα είναι διαθέσιμη στο τελικό μηχάνημα. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Προορίζεται το εξαγόμενο XAML μόνο για WPF, ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει WPF XAML μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε τη δημιουργημένη σήμανση στο περιβάλλον στόχο σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη τους εξαγωγή;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν συμπεριλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) στο [XamlOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/xamloptions/) — διατήρησέ το απενεργοποιημένο αν δεν χρειάζεστε την εξαγωγή τους.