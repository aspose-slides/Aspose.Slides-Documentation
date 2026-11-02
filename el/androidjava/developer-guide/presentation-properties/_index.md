---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε Android
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/androidjava/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα αποδεικτικού
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides for Android μέσω Java και βελτιστοποιήστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides for Android μέσω Java υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάσετε και να ενημερώσετε τα μεταδεδομένα της παρουσίασης, όπως ο συγγραφέας, ο τίτλος και οι τιμές που ορίζονται από τον χρήστη.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) . Μία παρουσία της διεπαφής αυτής επιστρέφεται από το [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του δημιουργού κατά την αποθήκευση παρουσιάσεων· αυτά τα πεδία προσδιορίζουν το λογισμικό που δημιούργησε το αρχείο εξόδου.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες παράλληλα με το περιεχόμενο της παρουσίασης. Διαχωρίζονται σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγραφέας και τα στατιστικά του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονομα/τιμή που ορίζονται από τον χρήστη.

Το Aspose.Slides for Android μέσω Java παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **File → Info → Properties → Advanced Properties** για να εξετάσετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Summary**, **Statistics**, **Contents** και **Custom**. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε τις ιδιότητες που ορίζει ο χρήστης.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός πρόσβασης ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται μετά την κλήση του [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) με `false`, οι ιδιότητες εγγράφου της παραμένουν δημόσιες. Μια εφαρμογή μπορεί τότε να καλέσει το [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) με `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό πρόσβασης ανοίγματος.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν αφεθεί δημόσιες. Επαληθεύει τη λειτουργία φόρτωσης μέσω του [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω του [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) :

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

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Οι διαφάνειες, τα master, οι διατάξεις, τα σχήματα, τα μέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) πριν εκτελέσουν μια ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Warning" %}}
Τα δημόσια μεταδεδομένα μπορούν να εκθέσουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη ανάγκη πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται μετά την κλήση του [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) με `true` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει τις αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως το σωστό κωδικό πρόσβασης ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και γνωστό κωδικό ανοίγματος. Ανοίγει την πλήρη παρουσίαση με το [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

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

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Η διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) εκθέτει ενσωματωμένα μεταδεδομένα μέσω μεθόδων getter, συμπεριλαμβανομένων των [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) και [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) . Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα της στην κονσόλα. Οι τιμές εξαρτώνται από την εισερχόμενη παρουσίαση· κάποια πεδία μπορεί να είναι κενά.

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

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε ενσωματωμένα μεταδεδομένα, χρησιμοποιήστε τις μεθόδους setter στο αντικείμενο που επιστρέφεται από το [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, καλεί τα [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), και [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) . Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
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

Το [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) επιστρέφει τη βάση επιπέδου εγγράφου για σχετικούς υπερσυνδέσμους. Χρησιμοποιήστε το [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) για να την αλλάξετε ή να την διαγράψετε. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα της αρχεία σε άλλη θέση. Είναι ξεχωριστό από το [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) ενός μεμονωμένου υπερσυνδέσμου· η αλλαγή της βάσης δεν επανεγγράφει τις αποθηκευμένες διευθύνσεις συνδέσμων ούτε αλλάζει τις απόλυτες προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει τη υπάρχουσα βάση, ορίζει νέα διεύθυνση βάσης και αποθηκεύει και ξανά ανοίγει την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια διαγράφει τη βάση με κενή συμβολοσειρά και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη διεύθυνση βάσης του παραδείγματος με τη θέση των συνδεδεμένων σας αρχείων.

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

Τα δύο μηνύματα επαλήθευσης πρέπει να εμφανίσουν `true`. Η διαγραφή της βάσης αφήνει τις μεμονωμένες διευθύνσεις υπερσυνδέσμων ανέπαφες.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε `old/target.pptx` όταν η βάση επιστρεφόταν στο φάκελο `old`. Αφού η βάση αλλάξει στο φάκελο `new`, αποθηκευμένο και ξαναφορτωμένο το ίδιο αρχείο ανοιγόταν ως `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Η μέθοδος [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) σας επιτρέπει να ορίσετε μια τιμή με το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο κειμενικές τιμές και μια ακέραια τιμή έκδοσης, και αποθηκεύει την παρουσίαση με το [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) . Η ανάθεση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή εκείνης της ιδιότητας.

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

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) για να τις επαναλάβει. Η μέθοδος [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) δέχεται μηδενικό δείκτη και επιστρέφει το όνομα που χρησιμοποιείται από το [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) . Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με αριθμημένη συμβολοσειρά ανεξάρτητα από τον αρχικό τύπο, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, ο βρόχος δεν κάνει καμία αλλαγή.

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

Δοκιμάστε την [**Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint**](https://products.aspose.app/slides/metadata) online εφαρμογή για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε ως κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Yes. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) and then [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/el/androidjava/examine-presentation/) for a complete reporting example and format-specific limitations.

**Μπορώ να διαβάσω τις δημόσιες ιδιότητες μιας κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Yes. The presentation must have been encrypted after calling [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) with `false`, and it must be loaded after calling [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) with `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο-ιδιοτήτων-εγγράφου;**

No. Public and encrypted property data must remain consistent, so updating an encrypted PPTX file requires loading the complete presentation with the correct opening password.