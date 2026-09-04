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
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα διόρθωσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Διαχειριστείτε αποτελεσματικά τις ιδιότητες παρουσίασης στο Aspose.Slides for Java και βελτιώστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν μέσω του API του Aspose.Slides.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties/) . Μια παρουσία της διεπαφής αυτής επιστρέφεται από την μέθοδο [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDocumentProperties--) . Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, ώστε μια αποθηκευμένη παρουσίαση να αναφέρει πάντα «Aspose.Slides for Java» και την έκδοση της βιβλιοθήκης που την παρήγαγε. Οποιαδήποτε τιμή περάσει στη μέθοδο `setNameOfApplication` παραλείπεται όταν η παρουσίαση γράφεται.
{{% /alert %}} 

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Απλώς κάντε κλικ στο εικονίδιο Office και στη συνέχεια στην επιλογή **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή στοιχείου μενού Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, θα εμφανιστεί ένα παράθυρο διαλόγου που επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου του αρχείου PowerPoint, όπως φαίνεται στην παρακάτω εικόνα:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Στον παραπάνω **Διάλογο Ιδιοτήτων**, μπορείτε να δείτε πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

### Εργασία με Ιδιότητες Εγγράφου χρησιμοποιώντας Aspose.Slides for Java

Όπως περιγράφηκε νωρίτερα, το Aspose.Slides for Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων μέσω του API του Aspose.Slides for Java. Το Aspose.Slides for Java παρέχει την κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που συνδέονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) για πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης, όπως περιγράφεται παρακάτω:

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ο κωδικός ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται με το `false` στην μέθοδο [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), οι ιδιότητες εγγράφου παραμένουν δημόσιες. Στη συνέχεια, μια εφαρμογή μπορεί να περάσει `true` στη μέθοδο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

Η επιλογή φόρτωσης μόνο ιδιοτήτων εγγράφου ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες είχαν συμπεριληφθεί στην κρυπτογράφηση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και η πλήρης παρουσίαση φορτώνεται.

Το παρακάτω παράδειγμα ελέγχει τη λειτουργία φόρτωσης μέσω της μεθόδου [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω της [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφάνειων δεν φορτώνεται. Διαφάνειες, master, layouts, σχήματα, media και άλλες αντικειμενικές μονάδες παρουσίασης δεν είναι διαθέσιμες. Οι εφαρμογές πρέπει πάντα να ελέγχουν την [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Προειδοποίηση" %}}
Τα δημόσια μεταδεδομένα μπορούν να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη ανάγκη πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται σε λειτουργία μόνο ιδιοτήτων εγγράφου προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγές ιδιοτήτων από αυτό το αντικείμενο μόνο‑μεταδεδομένων επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωση απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με τη μέθοδο [LoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί τη μέθοδο [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξανά ανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Οι ιδιότητες που εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties) περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία δημιουργίας), **Modified** (Ημερομηνία τροποποίησης), **Printed** (Τελευταία ημερομηνία εκτύπωσης), **LastModifiedBy**, **Keywords**, **SharedDoc** (Κοινόχρηστο μεταξύ διαφορετικών παραγωγών?), **PresentationFormat**, **Subject** και **Title**

```java
import com.aspose.slides.*;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Εμφάνιση των ενσωματωμένων ιδιοτήτων
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβαση σε αυτές. Απλώς αντιστοιχίστε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες εγγράφου της παρουσίασης χρησιμοποιώντας το Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις ενσωματωμένες ιδιότητες της παρουσίασης όπως φαίνεται παρακάτω:

|**Ενσωματωμένες ιδιότητες εγγράφου μετά την τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides for Java επιτρέπει επίσης στους προγραμματιστές να προσθέτουν προσαρμοσμένες τιμές στις ιδιότητες εγγράφου παρουσίασης. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητά το όνομα στην θέση 2 και την αφαιρεί, έτσι ώστε η αποθηκευμένη παρουσίαση να διατηρεί δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά προσθήκης.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Λήψη Ιδιοτήτων Εγγράφου
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Προσθήκη Προσαρμοσμένων ιδιοτήτων
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Λήψη ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Αφαίρεση επιλεγμένης ιδιότητας
    dProps.removeCustomProperty(getPropertyName);
    
    // Αποθήκευση παρουσίασης
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου που Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides for Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Το παρακάτω παράδειγμα δείχνει πώς μπορείτε να διαβάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Εμφάνιση ονομάτων και τιμών των προσαρμοσμένων ιδιοτήτων
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Τροποποίηση τιμών των προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες της [PPTX](https://docs.fileformat.com/presentation/pptx/) παρουσίασης. Τα παρακάτω σχήματα δείχνουν τις προσαρμοσμένες ιδιότητες πριν και μετά την τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προηγμένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Σημείωση" %}}
Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), και [WriteBindedPresentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στο [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo), ο setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) έχει τροποποιηθεί.
{{% /alert %}} 

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) προστέθηκαν στο interface [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/IPresentationInfo). Παρέχουν γρήγορη πρόσβαση σε ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση ιδιοτήτων χωρίς τη φόρτωση ολόκληρης παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγή κάποιας τιμής και ενημέρωση του εγγράφου μπορεί να υλοποιηθεί ως εξής:

```java
import com.aspose.slides.*;

// ανάγνωση των πληροφοριών της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// λήψη των τρεχουσών ιδιοτήτων
IDocumentProperties props = info.readDocumentProperties();

// ορισμός των νέων τιμών στα πεδία Συγγραφέας και Τίτλος
props.setAuthor("New Author");
props.setTitle("New Title");

// ενημέρωση της παρουσίασης με τις νέες τιμές
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει εναλλακτικός τρόπος χρήσης των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως πρότυπο για ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Μπορεί να δημιουργηθεί νέο πρότυπο από το μηδέν και στη συνέχεια να χρησιμοποιηθεί για ενημέρωση πολλαπλών παρουσιάσεων:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Διόρθωσης**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (εμφανιζόμενη από την κλάση PortionFormat) για να θέσετε τη γλώσσα διόρθωσης σε ένα έγγραφο PowerPoint. Η γλώσσα διόρθωσης είναι η γλώσσα για την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη γλώσσα διόρθωσης για ένα PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ορίστε το Id μιας γλώσσας διόρθωσης

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη προεπιλεγμένη γλώσσα για ολόκληρη την παρουσίαση PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Προσθέτει νέο σχήμα ορθογωνίου με κείμενο
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργαστείτε με ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα της τιμή θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της.

**Μπορώ να έχω πρόσβαση στις ιδιότητες παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε τη μέθοδο [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και μετά τη [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) . Δείτε το παράδειγμα [Build a Lightweight Presentation Inventory](/slides/el/java/examine-presentation/) για πλήρη αναφορά και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η κρυπτογράφηση ιδιοτήτων εγγράφου πρέπει να είχε απενεργοποιηθεί πριν κρυπτογραφηθεί η παρουσίαση και η παρουσίαση πρέπει να φορτωθεί σε λειτουργία μόνο ιδιοτήτων εγγράφου.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο ιδιοτήτων εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί πλήρη φόρτωση της παρουσίασης με τον σωστό κωδικό ανοίγματος.