---
title: Διαχείριση Ιδιοτήτων Παρουσίασης στο Android
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
- Γλώσσα ορθογραφικού ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για Android μέσω Java και βελτιστοποιήστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο αυτοί τύποι ιδιοτήτων μπορούν να προσεγγιστούν και να διαχειριστούν εύκολα χρησιμοποιώντας το API του Aspose.Slides.

Το Aspose.Slides σάς επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties/) . Μια παρουσία της διεπαφής επιστρέφεται από το [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **AppVersion** δεν μπορούν να τροποποιηθούν. Το Aspose.Slides τα ξαναγράφει σε κάθε αποθήκευση, έτσι ώστε μια αποθηκευμένη παρουσίαση να αναφέρει πάντα το όνομα προϊόντος Aspose.Slides και την έκδοση της βιβλιοθήκης που την δημιούργησε. Κάθε τιμή που περάστηκε στο `setNameOfApplication` απορρίπτεται όταν η παρουσίαση γράφεται.
{{% /alert %}}

## **Ιδιότητες Εγγράφου στο PowerPoint**

Το Microsoft PowerPoint 2007 επιτρέπει τη διαχείριση των ιδιοτήτων εγγράφου των αρχείων παρουσίασης. Το μόνο που χρειάζεται να κάνετε είναι να κάνετε κλικ στο εικονίδιο Office και, στη συνέχεια, στο στοιχείο μενού **Prepare | Properties | Advanced Properties** του Microsoft PowerPoint 2007 όπως φαίνεται παρακάτω:

|**Επιλογή Καταχώρησης Σύνθετων Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Αφού επιλέξετε το στοιχείο μενού **Advanced Properties**, εμφανίζεται ένας διάλογος που σας επιτρέπει να διαχειριστείτε τις ιδιότητες εγγράφου του αρχείου PowerPoint όπως φαίνεται παρακάτω:

|**Διάλογος Ιδιοτήτων**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Στον παραπάνω **Διάλογος Ιδιοτήτων**, μπορείτε να δείτε ότι υπάρχουν πολλές καρτέλες όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Όλες αυτές οι καρτέλες επιτρέπουν τη διαμόρφωση διαφορετικών τύπων πληροφοριών σχετικών με τα αρχεία PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση των προσαρμοσμένων ιδιοτήτων των αρχείων PowerPoint.

## **Εργασία με Ιδιότητες Εγγράφου Χρησιμοποιώντας το Aspose.Slides για Android μέσω Java**

Όπως περιγράψαμε νωρίτερα, το Aspose.Slides για Android μέσω Java υποστηρίζει δύο είδη ιδιοτήτων εγγράφου, οι **Built-in** και **Custom**. Έτσι, οι προγραμματιστές μπορούν να έχουν πρόσβαση και στα δύο είδη ιδιοτήτων μέσω του API του Aspose.Slides για Android μέσω Java. Το Aspose.Slides για Android μέσω Java παρέχει μια κλάση [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties) που αντιπροσωπεύει τις ιδιότητες εγγράφου που σχετίζονται με ένα αρχείο παρουσίασης μέσω της ιδιότητας **Presentation.DocumentProperties**.

Οι προγραμματιστές μπορούν να χρησιμοποιήσουν την ιδιότητα **IDocumentProperties** που εκτίθεται από το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) για να έχουν πρόσβαση στις ιδιότητες εγγράφου των αρχείων παρουσίασης όπως περιγράφεται παρακάτω:

## **Ανάγνωση Δημοσίων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται περνώντας `false` στο [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), οι ιδιότητες εγγράφου της παραμένουν δημόσιες. Μία εφαρμογή μπορεί στη συνέχεια να περάσει `true` στο [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό ανοίγματος.

Η επιλογή «μόνο ιδιότητες εγγράφου» ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Αν οι ιδιότητες είχαν συμπεριληφθεί στην κρυπτογράφηση, η φόρτωσή τους χωρίς κωδικό αποτυγχάνει. Αν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παρακάτω παράδειγμα επαληθεύει τη λειτουργία φόρτωσης μέσω του [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω του [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Οι διαφάνειες, τα master, τα layout, τα σχήματα, τα πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) πριν εκτελέσουν λειτουργία που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Προειδοποίηση" %}}
Τα δημόσια μεταδεδομένα μπορούν να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Αφήστε τις δημόσιες μόνο όταν απαιτείται από συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων που πρέπει να έχουν πρόσβαση χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται σε λειτουργία «μόνο ιδιότητες εγγράφου» προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγές ιδιοτήτων από αυτό το αντικείμενο μόνο‑μεταδεδομένων, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί συνεπώς τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με το [LoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), ενημερώνει δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξαναφορτώνει τα δημόσια μεταδεδομένα χωρίς κωδικό ώστε να ελέγξει τις νέες τιμές:

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

Αν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Built-in Ιδιότητες**

Αυτές οι ιδιότητες, όπως εκτίθενται από το αντικείμενο [IDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties), περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** και **Title**.

```java
import com.aspose.slides.*;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει την παρουσίαση
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την παρουσίαση
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

## **Τροποποίηση Built-in Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο απλή όσο η πρόσβασή τους. Μπορείτε απλώς να αναθέσετε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα τροποποιηθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς μπορούμε να τροποποιήσουμε τις ενσωματωμένες ιδιότητες του εγγράφου παρουσίασης χρησιμοποιώντας το Aspose.Slides για Android μέσω Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο IDocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ορισμός των ενσωματωμένων ιδιοτήτων
    dp.setAuthor("Aspose.Slides for Android via Java");
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

|**Built-in ιδιότητες εγγράφου μετά την τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Εγγράφου**

Το Aspose.Slides για Android μέσω Java επιτρέπει επίσης στους προγραμματιστές να προσθέσουν προσαρμοσμένες τιμές για τις ιδιότητες εγγράφου παρουσίασης. Το παρακάτω παράδειγμα προσθέτει τρεις προσαρμοσμένες ιδιότητες, στη συνέχεια αναζητεί το όνομα αποθηκευμένο στη θέση 2 και το αφαιρεί, ώστε η αποθηκευμένη παρουσίαση να διατηρεί δύο από αυτές. Οι προσαρμοσμένες ιδιότητες ταξινομούνται αλφαβητικά, όχι με τη σειρά προσθήκης.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Ανάκτηση Ιδιοτήτων Εγγράφου
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Προσθήκη Προσαρμοσμένων ιδιοτήτων
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Ανάκτηση ονόματος ιδιότητας σε συγκεκριμένο δείκτη
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Αφαίρεση επιλεγμένης ιδιότητας
    dProps.removeCustomProperty(getPropertyName);
    
    // Αποθήκευση παρουσίασης
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Προσαρμοσμένες Ιδιότητες Εγγράφου Προστέθηκαν**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides για Android μέσω Java επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση στις τιμές των προσαρμοσμένων ιδιοτήτων. Ένα παράδειγμα παρατίθεται παρακάτω που δείχνει πώς μπορείτε να προσπελάσετε και να τροποποιήσετε όλες αυτές τις προσαρμοσμένες ιδιότητες για μια παρουσίαση.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Δημιουργία αναφοράς στο αντικείμενο DocumentProperties που σχετίζεται με την Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Εμφάνιση ονομάτων και τιμών προσαρμοσμένων ιδιοτήτων
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Τροποποίηση τιμών προσαρμοσμένων ιδιοτήτων
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Αποθήκευση της παρουσίασής σας σε αρχείο
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Αυτό το παράδειγμα τροποποιεί τις προσαρμοσμένες ιδιότητες του [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation. Οι παρακάτω εικόνες δείχνουν τις προσαρμοσμένες ιδιότητες της παρουσίασης πριν και μετά τη τροποποίηση:

|**Προσαρμοσμένες Ιδιότητες πριν την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Προσαρμοσμένες Ιδιότητες μετά την Τροποποίηση**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Προχωρημένες Ιδιότητες Εγγράφου**

{{% alert color="info" title="Σημείωση" %}}
Νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), και [WriteBindedPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) προστέθηκαν στο [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo), η λογική του setter της ιδιότητας [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) άλλαξε.
{{% /alert %}}

Οι δύο νέες μέθοδοι [ReadDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) και [UpdateDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) προστέθηκαν στη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/IPresentationInfo). Παρέχουν γρήγορη πρόσβαση στις ιδιότητες εγγράφου και επιτρέπουν την αλλαγή και ενημέρωση των ιδιοτήτων χωρίς τη φόρτωση ολόκληρης της παρουσίασης.

Το τυπικό σενάριο φόρτωσης των ιδιοτήτων, αλλαγής κάποιας τιμής και ενημέρωσης του εγγράφου μπορεί να υλοποιηθεί ως εξής:

```java
import com.aspose.slides.*;

// Ανάγνωση των πληροφοριών της παρουσίασης
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Υπάρχει και άλλος τρόπος χρήσης των ιδιοτήτων μιας συγκεκριμένης παρουσίασης ως προτύπου για την ενημέρωση ιδιοτήτων σε άλλες παρουσιάσεις:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

Μπορεί να δημιουργηθεί νέο πρότυπο από το μηδέν και έπειτα να χρησιμοποιηθεί για την ενημέρωση πολλαπλών παρουσιάσεων:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

Το Aspose.Slides παρέχει την ιδιότητα LanguageId (που εκτίθεται από την κλάση PortionFormat) ώστε να μπορείτε να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα έγγραφο PowerPoint. Η γλώσσα ελέγχου ορθογραφίας είναι η γλώσσα κατά την οποία ελέγχονται η ορθογραφία και η γραμματική στο PowerPoint.

Αυτός ο κώδικας Java δείχνει πώς να ορίσετε τη γλώσσα ελέγχου ορθογραφίας για ένα PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // ορίστε το Id μιας γλώσσας ελέγχου ορθογραφίας

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
    // Προσθέτει ένα νέο σχήμα ορθογώνιου με κείμενο
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ελέγχει τη γλώσσα του πρώτου τμήματος
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**Aspose.Slides Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου μέσω του API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε ως κενές εφόσον αυτό επιτρέπεται από την συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων· το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες της παρουσίασης χωρίς να φορτώσω ολόκληρη την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) και στη συνέχεια το [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) . Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/androidjava/examine-presentation/) για ένα ολοκληρωμένο παράδειγμα αναφοράς και περιορισμούς ανά τύπο μορφής.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η κρυπτογράφηση ιδιοτήτων εγγράφου πρέπει να ήταν απενεργοποιημένη πριν κρυπτογραφηθεί η παρουσίαση, και η παρουσίαση πρέπει να φορτωθεί σε λειτουργία «μόνο ιδιότητες εγγράφου».

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία «μόνο ιδιότητες εγγράφου»;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμείνουν συνεπή, έτσι ώστε η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX να απαιτεί τη φόρτωση ολόκληρης της παρουσίασης με τον σωστό κωδικό ανοίγματος.