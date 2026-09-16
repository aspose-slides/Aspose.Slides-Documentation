---
title: Εξαγωγή Παρουσιάσεων σε XAML με Java
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint και OpenDocument σε XAML με Java χρησιμοποιώντας το Aspose.Slides—γρήγορη, λύση χωρίς Office που διατηρεί αμετάβλητη τη διάταξη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και επιδεικνύει πώς να προσαρμόσετε την εξαγωγή μέσω του [XamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυμμένων διαφανειών. Το άρθρο επίσης απαντά σε κάποιες συνηθισμένες ερωτήσεις σχετικά με τις εναλλακτικές γραμματοσειρές, τη συμβατότητα των στοίβων XAML και τη συμπεριφορά εξαγωγής κρυμμένων διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βάσει XML που χρησιμοποιείται για την περιγραφή διεπαφών χρηστών σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να εργάζεστε με αρχεία XAML σε οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα άμεσα.

## **Εξαγωγή παρουσιάσεων σε XAML με προεπιλεγμένες επιλογές**

Το παρακάτω παράδειγμα Java δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

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

Από προεπιλογή, οι εξαγώμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `pres` του τρέχοντος καταλόγου εργασίας της διεργασίας, που προκύπτει από μια κενή διαδρομή με το [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-). Ο φάκελος δημιουργείται αυτόματα και οι απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχικού αρχείου χωρίς την επέκταση του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.λπ. Ακόμη και αν περάσετε μια απόλυτη διαδρομή στο αρχείο εισόδου, ο φάκελος εξόδου δημιουργείται σχετικά με τον τρέχοντα κατάλογο εργασίας, όχι παράλληλα με το αρχείο εισόδου.

## **Εξαγωγή παρουσιάσεων σε XAML με προσαρμοσμένες επιλογές**

Χρησιμοποιήστε το interface [IXamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη θέση, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) και περάστε ένα παράδειγμα της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) του [XamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυμμένες διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) με `true`, όπως φαίνεται στο παρακάτω παράδειγμα Java:

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

## **Καταγραφή όλων των παραγόμενων αντικειμένων XAML**

Μια εξαγωγή XAML μπορεί να παράγει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια συν ξεχωριστές εικόνες και βοηθητικούς πόρους. Ορίστε έναν προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) στο [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) για να λαμβάνετε αυτά τα αντικείμενα αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με το XAML‑συγκεκριμένο [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) overload που δέχεται επιλογές XAML.

### **Κατανόηση του κύκλου ζωής της ανάκλησης**

Ο εξαγωγέας καλεί το [IXamlOutputSaver.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` προσδιορίζει το αντικείμενο και μπορεί να περιέχει σχετικούς καταλόγους. Διατηρήστε αυτή την πληροφορία επειδή το XAML μπορεί να αναφερθεί σε πόρους με σχετικές διαδρομές.
- `data` περιέχει τα bytes του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε πίνακα byte σε μνήμη που ανήκει στην εφαρμογή.
- Θεωρήστε την εξαγωγή επιτυχημένη μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης ολοκληρωθεί και όλες οι ανακλήσεις έχουν ολοκληρωθεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή μην ξεκινάτε μη παρακολουθούμενες γραφές στο παρασκήνιο. Αν η μόνιμη αποθήκευση συμβεί μετά, αναφέρετε τη συνολική επιτυχία μόνο αφού και αυτό το βήμα ολοκληρωθεί επιτυχώς.

Το [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ισχύει επίσης για προσαρμοσμένο αποθηκευτή. Η προεπιλογή, `false`, εξαιρεί τα έγγραφα XAML κρυμμένων διαφανειών. Η μεταβίβαση `true` τα περιλαμβάνει μαζί με όποιους πόρους απαιτούνται για την εξαγωγή τους. Οι αριθμοί πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή σταθερή σειρά κλήσεων.

### **Εξαγωγή στη μνήμη και έλεγχος των αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε αντικείμενο σε ένα [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) και τυπώνει το όνομα, τον τύπο και το μέγεθος σε bytes. Διατηρεί τα παρεχόμενα ονόματα ακριβώς. Τα διπλότυπα ονόματα σηματοδοτούν τη συλλογή ως μη έγκυρη αντί να αντικαθιστούν σιωπηρά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό το ζήτημα πριν χρησιμοποιήσει τα αποτελέσματα.

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

    // Αποκωδικοποίηση μόνο XAML και μόνο όταν απαιτείται κειμενική επιθεώρηση.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων άγνωστων τύπων πόρων. Μην τροποποιήσετε τα bytes κατά την αποθήκευση ή τη μετάδοση. Χρησιμοποιήστε τον κατασκευαστή [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) με UTF‑8 μόνο για XAML που χρειάζεται κείμενο επεξεργασία.

### **Συσκευασία των συλλεγμένων αντικειμένων σε αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά bytes σε μια αρχειοθήκη ZIP. Ένα μοναδικό όνομα αρχείου διαχωρίζει ταυτόχρονες εργασίες εξαγωγής. Οι καταχωρήσεις ZIP χρησιμοποιούν καμπύλες γραμμές και διατηρούν σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτονται πριν γράψετε το πακέτο.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

        // Ο κατάλογος ZIP ολοκληρώθηκε με το κλείσιμο πριν την αναφορά επιτυχίας.
        System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

Το παράδειγμα χρησιμοποιεί το [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) για να γράψει ένα τοπικό αρχείο ZIP· ο εξαγωγέας δεν γράφει ξεχωριστά αρχεία XAML ή εικόνων. Για απομακρυσμένη αποθήκευση, αντικαταστήστε το βήμα γραφής του αρχείου με ανεβάσματα των συλλεγμένων πινάκων bytes. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής μαζί με το πλήρες σχετικό όνομα αντικειμένου ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε μια σειρά βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλα τα ανεβάσματα ή η συναλλαγή της βάσης δεδομένων δεσμευτεί. Καθαρίστε τυχόν μερική έξοδο αν η μόνιμη αποθήκευση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει κάθε αντικείμενο απευθείας στην αποθήκευση της εφαρμογής για να αποφεύγει τη διατήρηση αντιγράφου όλης της εξαγωγής στη μνήμη. Κρατήστε κάθε callback συγχρονισμένο από την προοπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός αποδεχτεί τα bytes και επιτρέψτε στα σφάλματα να φτάσουν στον κάλεση.

### **Διατήρηση ονομάτων πόρων και επαλήθευση αναφορών**

- Κανονικοποιήστε τα διαχωριστικά διαδρομών όταν το προορισμό το απαιτεί, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) εκτός εάν κάθε παραγόμενο όνομα είναι σίγουρα μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων ειδική για τον προορισμό. Κατά τη γραφή ξεχωριστών αρχείων, απορρίψτε μονοπάτια που αρχίζουν από ρίζα και τμήματα διαδρομής που προχωρούν προς τα πάνω, λύστε τον προορισμό με το [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), και βεβαιωθείτε ότι παραμένει κάτω από τον προορισμένο φάκελο εξαγωγής, συμπεριλαμβανομένου του διαχωριστικού φακέλου στον έλεγχο περιεχομένου. Χρησιμοποιήστε έναν κατάλογο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να επαναπροσανατολίσουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Ανιχνεύστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας πεζών/κεφαλαίων του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και ελέγξτε τις αναφορές πόρων βάσει αρχείων, όπως τις ιδιότητες `Source` ή `ImageSource`. Επιλύστε κάθε σχετικό URI έναντι του καταλόγου του αντίστοιχου αντικειμένου XAML, κανονικοποιήστε το προκύπτον όνομα αποθήκευσης και επιβεβαιώστε ότι υπάρχει το αντίστοιχο κλειδί στο χάρτη, η καταχώρηση ZIP ή το αποθηκευμένο αντικείμενο. Αντιμετωπίστε ξεχωριστά τα εξωτερικά URI και τις εκφράσεις σήμανσης XAML από τα ονόματα αρχείων.

Για παράδειγμα, αν το `pres/Slide_1.xaml` αναφέρει `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα έσπαγε αυτή τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε αυτά τα URL πόρων προσβάσιμα στον καταναλωτή XAML. Ξαναανοίξτε το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα καταχωρήσεων και τα bytes των πόρων, και φορτώστε ενδεικτικές διαφάνειες στο περιβάλλον XAML προορισμού για να επιβεβαιώσετε ότι οι εικόνες αναλύονται σωστά.

## **Συχνές ερωτήσεις**

**Πως μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές αν η αρχική γραμματοσειρά δεν υπάρχει στο μηχάνημα;**

Καλέστε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) στο [XamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/) — χρησιμοποιείται ως εναλλακτική γραμματοσειρά κατά την εξαγωγή όταν λείπει η αρχική. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει τη γραμματοσειρά εναλλακτικής ή ότι η γραμματοσειρά θα είναι διαθέσιμη στο μηχάνημα προορισμού. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Είναι το εξαγόμενο XAML προορισμένο μόνο για WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο περιβάλλον προορισμού σας.

**Υποστηρίζονται οι κρυμμένες διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυμμένες διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) στο [XamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/xamloptions/) — κρατήστε το απενεργοποιημένο αν δεν χρειάζεστε την εξαγωγή τους.