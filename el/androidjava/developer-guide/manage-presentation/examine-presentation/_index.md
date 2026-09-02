---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε Android
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/androidjava/examine-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας Java για πιο γρήγορη ανάλυση και ευφυέστερους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν πρέπει να ταξινομήσετε αρχεία, να δημιουργήσετε μια απογραφή ή να επιθεωρήσετε ιδιότητες πριν αποφασίσετε εάν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο επιδεικνύει ελαφριά επιθεώρηση μέσω [PresentationFactory](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/) και [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Χρησιμοποιήστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) . Η μέθοδος [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) αναφέвает τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

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

## **Δημιουργία Ελαφριάς Απογραφής Παρουσίασης**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειαστείτε μια συμπαγή απογραφή για επαλήθευση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) για να λάβετε ένα αντικείμενο [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/), και στη συνέχεια καλέστε [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) ούτε απαιτεί την πλήρη διάσχιση του μοντέλου αντικειμένων παρουσίασης.

Οι επεκταμένες ιδιότητες που εκτίθενται από το [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/) παρέχουν τις ακόλουθες τιμές απογραφής:

| Μέθοδος | Τιμή απογραφής |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμο. |
| [getWords](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το ακόλουθο παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συνδυάζει επίσης το [getHeadingPairs](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) με το [getTitlesOfParts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) για εμφάνιση ομάδων περιεχομένου όπως γραμματοσειρές, θέματα και τίτλοι διαφανειών.

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

Κάθε [IHeadingPair](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iheadingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των αντικειμένων σε αυτήν την ομάδα. Η μέθοδος [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) επιστρέφει έναν επίπεδο, διατεταγμένο πίνακα, επομένως καταναλώστε τον αριθμό διαδοχικών τίτλων που ορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες απογραφής που επιστρέφει το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επαναϋπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αναπαρίστανται από προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι ξεπερασμένες αν η εφαρμογή που αποθήκευσε το αρχείο τελευταία δεν ενημέρωσε τις ιδιότητες εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκταμένες ιδιότητες εγγράφου για τον αριθμό διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδας και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από το ποιες ιδιότητες γράφτηκαν από τον δημιουργό του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμό σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε εκτεταμένη ιδιότητα του PowerPoint. Μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμέσων, ζευγών επικεφαλίδας και τίτλων τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μηδενική τιμή ή κενό πίνακα ως αποδείξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προαπαιτούμενους ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ζωντανό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντικατοπτρίζει αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με το [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) και στη συνέχεια γράψτε την δεσμευμένη παρουσίαση με το [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το ακόλουθο παράδειγμα αλλάζει τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

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

- [Password-Protect Presentations](/slides/el/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/el/androidjava/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω εάν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getFontsManager--). Καλέστε το [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [IFontsManager.getFonts](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και του [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Αυτή η μέθοδος είναι κατάλληλη για ελαφριά απογραφή. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι ξεπερασμένα· ή αν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, διασχίστε τις [Presentation.getSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlides--) και ελέγξτε τη μέθοδο [ISlide.getHidden](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islide/#getHidden--) για κάθε διαφάνεια.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlideSize--). Χρησιμοποιήστε τις μεθόδους [ISlideSize.getType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidesize/#getSize--) και [ISlideSize.getOrientation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/islidesize/#getOrientation--) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προεπιλεγμένες διαστάσεις και προσανατολισμό.

**Υπάρχει γρήγορος τρόπος να δω αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/chart/) και καλέστε το [IChartData.getDataSourceType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Για εξωτερικό βιβλίο εργασίας, καλέστε το [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Ο τύπος πηγής δεδομένων και η διαδρομή υποδεικνύουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις «βαριές» διαφάνειες που ίσως επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μία μοναδική ιδιότητα πολυπλοκότητας. Διασχίστε τις [Presentation.getSlides](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getSlides--) και τη συλλογή [IBaseSlide.getShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseslide/#getShapes--) κάθε διαφάνειας. Χρησιμοποιήστε μετρήσεις αριθμού σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων αντικειμένων ή πολυμέσων ως σήματα φιλτραρίσματος, και πραγματοποιήστε αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε τη διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης.