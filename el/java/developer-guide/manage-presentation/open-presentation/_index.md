---
title: Άνοιγμα παρουσιάσεων σε Java
linktitle: Άνοιγμα παρουσίασης
type: docs
weight: 20
url: /el/java/open-presentation/
keywords:
- άνοιγμα PowerPoint
- άνοιγμα OpenDocument
- άνοιγμα παρουσίασης
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- φόρτωση PPTX
- φόρτωση PPT
- φόρτωση ODP
- προστατευμένη παρουσίαση
- μεγάλη παρουσίαση
- εξωτερικός πόρος
- δυαδικό αντικείμενο
- Java
- Aspose.Slides
description: "Άνοιγμα παρουσιάσεων PowerPoint (.pptx, .ppt) και OpenDocument (.odp) χωρίς δυσκολίες με το Aspose.Slides για Java—γρήγορο, αξιόπιστο, πλήρως εξοπλισμένο."
---
## **Εισαγωγή**

Πέρα από τη δημιουργία παρουσιάσεων PowerPoint από το μηδέν, το Aspose.Slides σας επιτρέπει επίσης να ανοίξετε υπάρχουσες παρουσιάσεις. Αφού φορτώσετε μια παρουσίαση, μπορείτε να ανακτήσετε πληροφορίες γι' αυτήν, να επεξεργαστείτε το περιεχόμενο των διαφανειών, να προσθέσετε νέες διαφάνειες, να αφαιρέσετε υπάρχουσες και πολλά άλλα.

## **Άνοιγμα Παρουσιάσεων**

Για να ανοίξετε μια υπάρχουσα παρουσίαση, δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και περάστε τη διαδρομή του αρχείου στον κατασκευαστή της.

Το παρακάτω παράδειγμα Java δείχνει πώς να ανοίξετε μια παρουσίαση και να λάβετε τον αριθμό των διαφανειών της:

```java
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation και περάστε μια διαδρομή αρχείου στον κατασκευαστή της.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Εκτυπώστε το συνολικό αριθμό διαφανειών στην παρουσίαση.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Παρουσιάσεων με Προστασία Κωδικού**

Όταν χρειάζεται να ανοίξετε μια παρουσίαση προστατευμένη με κωδικό, περάστε τον κωδικό μέσω της μεθόδου [setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) της κλάσης [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) για να την αποκρυπτογραφήσετε και να τη φορτώσετε. Το παρακάτω κώδικα Java δείχνει αυτήν τη λειτουργία:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Εκτελέστε ενέργειες στην αποκρυπτογραφημένη παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Άνοιγμα Μεγάλων Παρουσιάσεων**

Το Aspose.Slides παρέχει επιλογές — ειδικότερα τη μέθοδο [getBlobManagementOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) στην κλάση [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) — για να σας βοηθήσει να φορτώσετε μεγάλες παρουσιάσεις.

Το παρακάτω κώδικα Java δείχνει πώς να φορτώσετε μια μεγάλη παρουσίαση (για παράδειγμα, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Επιλέξτε τη συμπεριφορά KeepLocked — το αρχείο παρουσίασης θα παραμείνει κλειδωμένο για τη διάρκεια της
// του αντικειμένου Presentation, αλλά δεν χρειάζεται να φορτωθεί στη μνήμη ή να αντιγραφεί σε προσωρινό αρχείο.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Η μεγάλη παρουσίαση έχει φορτωθεί και μπορεί να χρησιμοποιηθεί, ενώ η κατανάλωση μνήμης παραμένει χαμηλή.

    // Κάντε αλλαγές στην παρουσίαση.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Αποθηκεύστε την παρουσίαση σε άλλο αρχείο. Η κατανάλωση μνήμης παραμένει χαμηλή κατά τη διάρκεια αυτής της λειτουργίας.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Μην το κάνετε! Θα προκληθεί εξαίρεση I/O επειδή το αρχείο είναι κλειδωμένο μέχρι να διαγραφεί το αντικείμενο παρουσίασης.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Μπορεί να γίνει εδώ. Το αρχείο προέλευσης δεν είναι πλέον κλειδωμένο από το αντικείμενο παρουσίασης.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Για να προσαρμοστείτε σε ορισμένους περιορισμούς κατά τη χρήση ροών, το Aspose.Slides ενδέχεται να αντιγράψει τα περιεχόμενα μιας ροής. Η φόρτωση μιας μεγάλης παρουσίασης από ροή προκαλεί το αντίγραφο της παρουσίασης και μπορεί να επιβραδύνει τη φόρτωση. Συνεπώς, όταν χρειάζεται να φορτώσετε μια μεγάλη παρουσίαση, συνιστούμε ανεπιφύλακτα τη χρήση της διαδρομής του αρχείου παρουσίασης αντί για ροή.

Κατά τη δημιουργία παρουσίασης που περιέχει μεγάλα αντικείμενα (βίντεο, ήχο, εικόνες υψηλής ανάλυσης κ.λπ.), μπορείτε να χρησιμοποιήσετε τη [BLOB management](/slides/el/java/manage-blob/) για να μειώσετε την κατανάλωση μνήμης.
{{%/alert %}}

## **Έλεγχος Εξωτερικών Πόρων**

Το Aspose.Slides παρέχει το interface [IResourceLoadingCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iresourceloadingcallback/) που σας επιτρέπει να διαχειρίζεστε εξωτερικούς πόρους. Το παρακάτω κώδικα Java δείχνει πώς να χρησιμοποιήσετε το interface `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Φορτώστε μια εναλλακτική εικόνα.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ορίστε μια εναλλακτική URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Παράβλεψη όλων των άλλων εικόνων.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Φόρτωση Παρουσιάσεων χωρίς Ενσωματωμένα Δυαδικά Αντικείμενα**

Μια παρουσίαση PowerPoint μπορεί να περιέχει τους παρακάτω τύπους ενσωματωμένων δυαδικών αντικειμένων:

- VBA project (πρόσβαση μέσω [IPresentation.getVbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE object embedded data (πρόσβαση μέσω [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX control binary data (πρόσβαση μέσω [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/el/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Χρησιμοποιώντας τη μέθοδο [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) μπορείτε να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό αντικείμενο.

Αυτή η μέθοδος είναι χρήσιμη για την αφαίρεση ενδεχομένως κακόβουλου δυαδικού περιεχομένου. Το παρακάτω κώδικα Java δείχνει πώς να φορτώσετε μια παρουσίαση χωρίς κανένα ενσωματωμένο δυαδικό περιεχόμενο:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Εκτελέστε ενέργειες στην παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **ΣΥΧΝΑ ΕΡΩΤΗΜΑΤΑ**

**Πώς μπορώ να καταλάβω ότι ένα αρχείο είναι κατεστραμμένο και δεν μπορεί να ανοιχθεί;**

Θα λάβετε εξαίρεση επαλήθευσης ανάλυσης/μορφής κατά τη φόρτωση. Τέτοια σφάλματα συχνά αναφέρουν μη έγκυρη δομή ZIP ή κατεστραμμένα αρχεία PowerPoint.

**Τι συμβαίνει αν λείπουν τα απαιτούμενα γραμματοσειρές κατά το άνοιγμα;**

Το αρχείο θα ανοίξει, αλλά αργότερα το [rendering/export](/slides/el/java/convert-presentation/) μπορεί να αντικαταστήσει τις γραμματοσειρές. [Configure font substitutions](/slides/el/java/font-substitution/) ή [add the required fonts](/slides/el/java/custom-font/) στο περιβάλλον εκτέλεσης.

**Τι γίνεται με τα ενσωματωμένα μέσα (βίντεο/ήχος) κατά το άνοιγμα;**

Γίνονται διαθέσιμα ως πόροι της παρουσίασης. Εάν τα μέσα αναφέρονται μέσω εξωτερικών διαδρομών, βεβαιωθείτε ότι αυτές οι διαδρομές είναι προσβάσιμες στο περιβάλλον σας· διαφορετικά το [rendering/export](/slides/el/java/convert-presentation/) μπορεί να παραλείψει τα μέσα.