---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε Java
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/java/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προχωρημένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα διορθώσεων
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις κύριες ιδιότητες παρουσίασης στο Aspose.Slides για Java και βελτιώστε την αναζήτηση, τη διαμόρφωση εμπορικού σήματος και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides for Java υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάσετε και να ενημερώσετε τα μεταδεδομένα της παρουσίασης, όπως ο δημιουργός, ο τίτλος και οι τιμές που ορίζει ο χρήστης.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) . Μια παρουσία της διεπαφής επιστρέφεται από τη μέθοδο [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) . Τα ακόλουθα παραδείγματα δείχνουν πώς να διαβάζετε, να τροποποιείτε και να διαχειρίζεστε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του παραγωγού κατά την αποθήκευση των παρουσιάσεων· αυτά τα πεδία αναγνωρίζουν το λογισμικό που δημιούργησε το αποτέλεσμα.
{{% /alert %}}

## **Διαχείριση Ιδιότητων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες παράλληλα με το περιεχόμενο της παρουσίασης. Ανήκουν σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο δημιουργός και τα στατιστικά του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονομα/τιμή που ορίζονται από τον χρήστη.

Το Aspose.Slides for Java παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **Αρχείο → Πληροφορίες → Ιδιότητες → Προχωρημένες Ιδιότητες** για να εξετάσετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Περίληψη**, **Στατιστικά**, **Περιεχόμενα** και **Προσαρμοσμένες**. Χρησιμοποιήστε την καρτέλα **Προσαρμοσμένες** για να διαχειριστείτε τις ιδιότητες που ορίζει ο χρήστης.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός άνοιγμα συνήθως προστατεύει τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες του εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται μετά την κλήση της μεθόδου [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) με `false`, οι ιδιότητές της παραμένουν δημόσιες. Μια εφαρμογή μπορεί τότε να καλέσει τη μέθοδο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) με `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό άνοιγμα.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες συμπεριλήφθηκαν στην κρυπτογράφηση, η φόρτωσή τους χωρίς τον κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν παραμείνει δημόσιες. Ελέγχει τη λειτουργία φόρτωσης μέσω του [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διαφάνειες, κύριοι, διατάξεις, σχήματα, πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) πριν εκτελέσουν κάποια ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορεί να εκθέτουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν οι μηχανές ευρετηρίασης, ταξινόμησης, αναζήτησης ή τα συστήματα διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίας**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά την κλήση του [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) με `true` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει τις αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο με μεταδεδομένα, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν σύμφωνες με τα αντίστοιχα δεδομένα εντός της κρυπτογραφημένης παρουσίασης. Η ενημέρωσή τους απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και έναν γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με τη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) , ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) για να ελέγξει ότι η κρυπτογράφηση διατηρείται και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να επαληθεύσει τις νέες τιμές:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο για ανάγνωση.

## **Πρόσβαση στις Ενσωματωμένες Ιδιότητες**

Η διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) εκθέτει τις ενσωματωμένες μεταδεδομένα μέσω μεθόδων getter, όπως [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--) , [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) και [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) . Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα στην κονσόλα. Οι τιμές εξαρτώνται από την παρουσίαση εισόδου· ορισμένα πεδία μπορεί να είναι κενά.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Αναφορά Αριθμού Αναθεώρησης και Χρόνου Επεξεργασίας**

Για να αναφέρετε μια γραμμή για κάθε αρχείο PPTX στον φάκελο `presentations`, καλέστε το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε το [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) του χωρίς να φορτώσετε τις διαφάνειες για επεξεργασία. Το Java API επιστρέφει τη διάρκεια επεξεργασίας σε χιλιοστά του δευτερολέπτου. Το παράδειγμα τη μορφοποιεί ως ώρες, λεπτά και δευτερόλεπτα, με μέτρηση ημερών για διάρκειες 24 ωρών ή περισσότερο.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

Για μια παρουσίαση με καταγεγραμμένο χρόνο επεξεργασίας 1 ημέρα, 2 ώρες και 5 λεπτά, η αναφορά εμφανίζει το ακόλουθο αποτέλεσμα.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) διαβάζει μια τιμή που οι εφαρμογές μπορούν να αλλάξουν με το [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) . Ο μόνος αριθμός αναθεώρησης δεν μπορεί να προσδιορίσει πόσες φορές έχει αποθηκευτεί η παρουσίαση ή να ανασυγκροτήσει το ιστορικό εκδόσεων.

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) διαβάζει τη διάρκεια επεξεργασίας που καταγράφηκε στο αρχείο. Μια τιμή `00:00:00` σημαίνει ότι η αποθηκευμένη διάρκεια είναι μηδέν, ακόμη κι αν κάποιος επεξεργάστηκε την παρουσίαση.

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε τα ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις μεθόδους setter στο αντικείμενο που επιστρέφεται από το [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) . Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τις μεθόδους [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-) , [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-) , [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-) , [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) και [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) , στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) . Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διαχείριση Βάσης Υπερσυνδέσμου**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) επιστρέφει τη βάση σε επίπεδο εγγράφου για σχετικούς υπερσυνδέσμους. Χρησιμοποιήστε το [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) για να την αλλάξετε ή να την διαγράψετε. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα αρχεία της σε άλλη τοποθεσία. Είναι ξεχωριστό από το ατομικό υπερσύνδεσμο [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) : η αλλαγή της βάσης δεν επαναγράφει τις αποθηκευμένες διευθύνσεις συνδέσμων ή δεν αλλάζει απόλυτους προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει τη υπάρχουσα βάση, αντιστοιχίζει μια νέα διεύθυνση βάσης, και αποθηκεύει και ανοίγει ξανά την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια διαγράφει τη βάση με μια κενή συμβολοσειρά και επαληθεύει την κενή τιμή σε ένα ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη διεύθυνση βάσης του παραδείγματος με τη θέση των συνδεδεμένων αρχείων σας.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Τα δύο μηνύματα επαλήθευσης θα πρέπει να εκτυπώσουν `true`. Η διαγραφή της βάσης αφήνει τις διευθύνσεις των ατομικών υπερσυνδέσμων ανέπαφες.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση έδειχνε στο φάκελο `old`. Αφού η βάση αλλάξει στο φάκελο `new`, αποθηκευτεί και ανοίξει ξανά η παρουσίαση, ο ίδιος σύνδεσμος άνοιγε `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Η μέθοδος [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) σάς επιτρέπει να εκχωρήσετε μια τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο τιμές κειμένου και μια ακέραια τιμή έκδοσης, και αποθηκεύει την παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) . Η εκχώρηση μιας τιμής σε υπάρχον όνομα αντικαθιστά την τιμή της ιδιότητας.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) για να τις επαναλάβει. Το [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) δέχεται έναν δείκτη που αρχίζει από το μηδέν και επιστρέφει το όνομα που χρησιμοποιείται από το [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) . Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με μια αριθμημένη συμβολοσειρά ανεξαρτήτως του αρχικού τύπου, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, η επανάληψη δεν κάνει αλλαγές.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την διαδικτυακή εφαρμογή [**Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint**](https://products.aspose.app/slides/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε ως κενές, εάν αυτό επιτρέπεται από τη συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναί. Χρησιμοποιήστε τη μέθοδο [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και στη συνέχεια το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) . Δείτε το άρθρο [Δημιουργία Ελαφρού Αποθέματος Παρουσίασης](/slides/el/java/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά τύπο αρχείου.

**Μπορώ να διαβάσω τις δημόσιες ιδιότητες μιας κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό άνοιγμα;**

Ναί. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί μετά την κλήση του [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) με `false`, και πρέπει να φορτωθεί μετά την κλήση του [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) με `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο-ιδιοτήτων-εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση ολόκληρης της παρουσίασης με τον σωστό κωδικό άνοιγμα.