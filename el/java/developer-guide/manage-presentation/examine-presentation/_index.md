---
title: "Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε Java"
linktitle: "Πληροφορίες Παρουσίασης"
type: docs
weight: 30
url: /el/java/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Java για ταχύτερη κατανόηση και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναγνωρίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα αποθετήριο ή να εξετάσετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο δείχνει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/) και του [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) . Η μέθοδος [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Δημιουργία Ελαφρού Αποθετηρίου Παρουσιάσεων**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε ένα σύντομο αποθετήριο για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτήν την περίπτωση, χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για να αποκτήσετε ένα αντικείμενο [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/) και, στη συνέχεια, καλέστε το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και δεν απαιτεί να διασχίσετε ολόκληρο το μοντέλο αντικειμένων παρουσίασης.

Οι εκτεταμένες ιδιότητες που εκτίθενται από το [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/) παρέχουν τις ακόλουθες τιμές αποθετηρίου:

| Μέθοδος | Τιμή αποθετηρίου |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getSlides--) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getNotes--) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Συνολικός αριθμός παραγράφων, εφόσον είναι διαθέσιμος. |
| [getWords](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getWords--) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και εκτυπώνει ένα σύντομο αποθετήριο. Συνδυάζει επίσης το [getHeadingPairs](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) με το [getTitlesOfParts](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) για την εμφάνιση ομάδων περιεχομένου όπως γραμματοσειρές, θέματα και τίτλοι διαφανειών.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Κάθε [IHeadingPair](https://reference.aspose.com/slides/el/java/com.aspose.slides/iheadingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Το [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) επιστρέφει έναν ενωμένο, ταξινομημένο πίνακα, οπότε καταναλώστε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες αποθετηρίου που επιστρέφονται από το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) αντανακλούν τα μεταδεδομένα που διατίθενται στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αντιπροσωπεύονται από προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι παλαιές εάν η εφαρμογή που αποθήκευσε τελευταία φορά το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει εκτεταμένες ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικές στατιστικές εγγράφου, όπως αριθμούς σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε ειδική για το PowerPoint εκτεταμένη ιδιότητα. Μεταδεδομένα για κρυφές διαφάνειες, σημειώσεις, πολυμέσα, ζεύγη επικεφαλίδων και τίτλους τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες αποθετηρίου ενδέχεται να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μια μηδενική τιμή ή έναν κενό πίνακα ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθετήρια και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και επιθεωρήστε το ενεργό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφονται από το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) μπορούν επίσης να αλλάξουν χωρίς δημιουργία μιας παρουσίασης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), και στη συνέχεια γράψτε την συνδεδεμένη παρουσίαση με το [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου της παρουσίασης PowerPoint.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ημερομηνία τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Η παρακάτω εικόνα δείχνει τις αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Παρουσιάσεις με Κωδικό Πρόσβασης](/slides/el/java/password-protected-presentation/)
- [Παρουσιάσεις Προστατευμένες από Εγγραφή](/slides/el/java/write-protected-presentation/)

## **FAQ**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getFontsManager--) . Καλέστε το [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και το [IFontsManager.getFonts](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifontsmanager/#getFonts--) για να αποκτήσετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώσω αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και του [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) . Αυτό είναι κατάλληλο για ελαφρύ αποθετήριο. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλαιά, ή εάν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, διατρέξτε το [Presentation.getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) και ελέγξτε τη μέθοδο [ISlide.getHidden](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getHidden--) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlideSize--) . Χρησιμοποιήστε το [ISlideSize.getType](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/#getType--), το [ISlideSize.getSize](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/#getSize--) και το [ISlideSize.getOrientation](https://reference.aspose.com/slides/el/java/com.aspose.slides/islidesize/#getOrientation--) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με την αναμενόμενη προεπιλογή και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να δω αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/java/com.aspose.slides/chart/) και καλέστε το [IChartData.getDataSourceType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdata/#getDataSourceType--) . Για εξωτερικό βιβλίο εργασίας, καλέστε το [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) . Ο τύπος πηγής δεδομένων και η διαδρομή υποδεικνύουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Δεν υπάρχει μία μοναδική ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation.getSlides](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getSlides--) και τη συλλογή [IBaseSlide.getShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseslide/#getShapes--) κάθε διαφάνειας. Χρησιμοποιήστε τους αριθμούς σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων ή πολυμέσων ως ενδείξεις, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο εμπόδιο απόδοσης.