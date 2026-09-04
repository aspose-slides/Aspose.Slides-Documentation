---
title: Προστασία Παρουσιάσεων με Κωδικό στο Android
linktitle: Προστασία Κωδικού
type: docs
weight: 20
url: /el/androidjava/password-protected-presentation/
keywords:
- παρουσίαση με προστασία κωδικού
- κωδικός ανοίγματος
- κρυπτογράφηση PowerPoint
- αποκρυπτογράφηση PowerPoint
- επικύρωση κωδικού παρουσίασης
- έλεγχος κωδικού παρουσίασης
- άνοιγμα κρυπτογραφημένης παρουσίασης
- αφαίρεση κρυπτογράφησης
- PowerPoint
- PPT
- PPTX
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένας κωδικός άνοιγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εχεμύθεια.

Ένας κωδικός άνοιγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών για τροποποίηση παρουσιάσεων, δείτε [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/androidjava/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά τους με βάση το αρχείο και τη ροή είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Άνοιγματος**

Χρησιμοποιήστε το [IProtectionManager.encrypt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) για να ορίσετε έναν κωδικό άνοιγματος. Στη συνέχεια χρησιμοποιήστε το [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

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

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες του εγγράφου στην κρυπτογράφηση της παρουσίασης. Η μέθοδος [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφανειών. Περνάτε την τιμή `false` πριν καλέσετε το [IProtectionManager.encrypt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει μεταδεδομένα χωρίς τον κωδικό άνοιγματος.

Το παρακάτω παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ αφήνει τις ενσωματωμένες ιδιότητες του εγγράφου δημόσιες:

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

Η μετάδοση του `false` στο [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) δεν καθιστά δημόσιες τις διαφάνειες, τους κύριους, τις διατάξεις, τα σχήματα, τα πολυμέσα ή άλλο περιεχόμενο της παρουσίασης. Επηρεάζει μόνο τις ιδιότητες του εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς να φορτώσετε το κρυπτογραφημένο περιεχόμενο, δείτε το [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/androidjava/presentation-properties/).

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε το [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) στον κωδικό άνοιγματος και περάστε τις επιλογές στην [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός άνοιγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
} finally {
    presentation.dispose();
}
```

## **Αφαιρέστε την Κρυπτογράφηση από μια Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό άνοιγματος, καλέστε το [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

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

## **Επικύρωση Κωδικού Άνοιγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/) χωρίς να δημιουργήσετε ένα πλήρες στιγμιότυπο παρουσίασης. Ελέγξτε το [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) πριν ζητήσετε ή επικυρώσετε έναν κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό άνοιγματος για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

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

### **Ροή Εργασίας με Ροή Δεδομένων**

Η υπερφόρτωση με ροή του [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση μιας αναζητήσιμης ροής πριν φορτώσετε την πλήρη παρουσίαση από αυτή τη ροή.

Το παρακάτω παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

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

### **Τιμές Επιστροφής του checkPassword**

Το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό άνοιγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις ακόλουθες περιπτώσεις:

- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό άνοιγματος.
- Ο παρεχόμενος κωδικός είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν η Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, ελέγξτε το [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) για να επιβεβαιώσετε ότι η πηγή παρουσίασης κρυπτογραφήθηκε. Για να εντοπίσετε προστασία κωδικού άνοιγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo.isPasswordProtected` όπως φαίνεται παραπάνω.

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

## **Συστάσεις Ασφαλείας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς άνοιγματος ούτε τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, διατηρήστε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες του εγγράφου μπορεί να αποκαλύψουν ονόματα συγγραφέων, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές, ακόμη κι όταν το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων ως δημόσιες πρέπει να είναι μια σαφής απόφαση που λαμβάνεται μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό άνοιγματος.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό μέσω Διαδικτύου**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισάγετε έναν κωδικό για προστασία προβολής.
1. Προαιρετικά, εισάγετε έναν ξεχωριστό κωδικό για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το προκύπτον αρχείο.

{{% alert color="info" title="See also" %}}
- [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/androidjava/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού άνοιγματος και κωδικού προστασίας εγγραφής;**

Ένας κωδικός άνοιγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει τη τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό άνοιγματος χωρίς τη φόρτωση όλων των διαφανειών;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε εάν υπάρχει προστασία κωδικού άνοιγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες στιγμιότυπο παρουσίασης.

**Μπορεί μια εφαρμογή να διαβάσει μεταδεδομένα χωρίς τον κωδικό άνοιγματος;**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με την κρυπτογράφηση ιδιοτήτων εγγράφου απενεργοποιημένη. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο με ιδιότητες εγγράφου που περιγράφεται στο [Διαχείριση Ιδιοτήτων Παρουσίασης](/slides/el/androidjava/presentation-properties/).

**Υποστηρίζουν οι ροές ελέγχου κωδικού και τα δύο, PPT και PPTX;**

Ναι. Η ανίχνευση και επικύρωση κωδικού βάσει διαδρομής αρχείου ή ροής δεδομένων συμπεριφέρονται με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.