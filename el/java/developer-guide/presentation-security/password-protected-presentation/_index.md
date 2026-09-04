---
title: "Προστασία Παρουσιάσεων με κωδικό πρόσβασης σε Java"
linktitle: "Προστασία Κωδικού Πρόσβασης"
type: docs
weight: 20
url: /el/java/password-protected-presentation/
keywords:
- "παρουσίαση με προστασία κωδικού"
- "κωδικός ανοίγματος"
- "κρυπτογράφηση PowerPoint"
- "αποκρυπτογράφηση PowerPoint"
- "επικύρωση κωδικού παρουσίασης"
- "έλεγχος κωδικού παρουσίασης"
- "άνοιγμα κρυπτογραφημένης παρουσίασης"
- "αφαίρεση κρυπτογράφησης"
- "PowerPoint"
- "PPT"
- "PPTX"
- "παρουσίαση"
- "Java"
- "Aspose.Slides"
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού πρόσβασης σε Java με το Aspose.Slides."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, έτσι αυτή η προστασία παρέχει απόρρητο.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για την τροποποίηση παρουσιάσεων, δείτε [Write-Protect Presentations](/slides/el/java/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά βάσει αρχείου και ροής είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το [IProtectionManager.encrypt](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε το [IPresentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Διατήρηση Δημοσίων Ιδιοτήτων Εγγράφου**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες εγγράφου στην κρυπτογράφηση της παρουσίασης. Η μέθοδος [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περάστε `false` πριν καλέσετε το [IProtectionManager.encrypt](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει τα μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ διατηρεί τις ενσωματωμένες ιδιότητες εγγράφου δημόσιες:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η μεταβίβαση του `false` στη μέθοδο [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) δεν κάνει τις διαφάνειες, τις κυρίες, τις διατάξεις, τα σχήματα, τα μέσα ή άλλο περιεχόμενο της παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς τη φόρτωση του κρυπτογραφημένου περιεχομένου, δείτε το [Manage Presentation Properties](/slides/el/java/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Δουλέψτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί πλέον να φορτωθεί χωρίς κωδικό.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν από τη Φόρτωση**

Χρησιμοποιήστε το [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/) χωρίς τη δημιουργία πλήρους παρουσίασης. Ελέγξτε το [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) πριν ζητήσετε ή επικυρώσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Ροή Εργασίας με Ροή**

Η υπερφόρτωση ροής του [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) προσφέρει την ίδια ροή εργασίας. Επαναφέρετε τη θέση μιας ροής με δυνατότητα αναζήτησης πριν φορτώσετε την πλήρη παρουσίαση από αυτή τη ροή.

Το παρακάτω παράδειγμα χρησιμοποιεί αρχείο PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Τιμές Ε επιστροφής του checkPassword**

Το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) επιστρέφει `true` μόνο όταν η παρουσίαση διαθέτει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις παρακάτω περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Αφού φορτωθεί μια παρουσίαση με το σωστό κωδικό, ελέγξτε το [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) για να επιβεβαιώσετε ότι η αρχική παρουσίαση ήταν κρυπτογραφημένη. Για να ανιχνεύσετε προστασία κωδικού πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo.isPasswordProtected` όπως φαίνεται παραπάνω.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Συστάσεις Ασφάλειας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς πρόσβασης στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου ενδέχεται να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη και αν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε τα ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων δημόσιων θα πρέπει να είναι σαφής απόφαση, λήφθηκε μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό πρόσβασης ανοίγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισάγετε έναν κωδικό πρόσβασης για προστασία προβολής.
1. Προαιρετικά, εισάγετε έναν διαφορετικό κωδικό πρόσβασης για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το προκύπτον αρχείο.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/el/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/el/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς τη φόρτωση όλων των διαφανειών;**

Ναι. Αποκτήστε τις πληροφορίες της παρουσίασης, ελέγξτε αν υπάρχει προστασία κωδικού πρόσβασης ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε πλήρη παρουσίαση.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό πρόσβασης ανοίγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με την κρυπτογράφηση των ιδιοτήτων εγγράφου απενεργοποιημένη. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο-ιδιοτήτων-εγγράφου που περιγράφεται στο [Manage Presentation Properties](/slides/el/java/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικού πρόσβασης τόσο PPT όσο και PPTX;**

Ναί. Ο εντοπισμός και η επικύρωση κωδικού πρόσβασης βάσει διαδρομής αρχείου και ροής λειτουργούν με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.