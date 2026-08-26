---
title: Προστασία Παρουσιάσεων με Κωδικό στην Android
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
- κατάργηση κρυπτογράφησης
- PowerPoint
- PPT
- PPTX
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού, χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Ένας κωδικός ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για τη φόρτωση και την προβολή του περιεχομένου της παρουσίασης, επομένως αυτή η προστασία παρέχει εμπιστευτικότητα.

Ο κωδικός ανοίγματος διαφέρει από τον κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ούτε εμποδίζει τη φόρτωση της παρουσίασης. Για διαχείριση κωδικών που επιτρέπουν την τροποποίηση παρουσιάσεων, δείτε [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/androidjava/write-protected-presentation/).

Οι παρακάτω ροές εργασίας ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά με βάση το αρχείο και το ρεύμα είναι σημαντική.

## **Κρυπτογράφηση Παρουσίασης με Κωδικό Ανοίγματος**

Χρησιμοποιήστε [IProtectionManager.encrypt](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) για να ορίσετε έναν κωδικό ανοίγματος. Στη συνέχεια, χρησιμοποιήστε [IPresentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

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

## **Φόρτωση Κρυπτογραφημένης Παρουσίασης**

Ορίστε [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) στον κωδικό ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι εσφαλμένος.

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

## **Κατάργηση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό ανοίγματος, καλέστε [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

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

## **Επικύρωση Κωδικού Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/) χωρίς να δημιουργήσετε ολοκληρωμένο αντικείμενο παρουσίασης. Ελέγξτε το [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) πριν ζητήσετε ή επικυρώσετε κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

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

### **Ροή Εργασίας με Ρεύμα**

Η υπερφόρτωση ρεύματος του [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) παρέχει την ίδια ροή εργασίας. Επαναφέρετε τη θέση ενός ρεύματος με δυνατότητα αναζήτησης πριν φορτώσετε την πλήρη παρουσίαση από εκείνο το ρεύμα.

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

### **Τιμές Επιστροφής του checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις ακόλουθες περιπτώσεις:

- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν Μια Φορτωμένη Παρουσίαση Είναι Κρυπτογραφημένη**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, εξετάστε το [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) για να επιβεβαιώσετε ότι η πηγή παρουσίασης ήταν κρυπτογραφημένη. Για να εντοπίσετε την προστασία με κωδικό ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo.isPasswordProtected` όπως φαίνεται παραπάνω.

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

{{% alert color="warning" title="Ασφάλεια" %}}
Μην καταγράφετε τους κωδικούς ανοίγματος ή τους ενσωματώνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.
{{% /alert %}}

## **Προστασία Παρουσίασης με Κωδικό Διαδικτυακά**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
2. Επιλέξτε ή ανεβάστε την παρουσίαση.
3. Εισάγετε έναν κωδικό για προστασία εμφάνισης.
4. Προαιρετικά, εισάγετε ξεχωριστό κωδικό για προστασία επεξεργασίας.
5. Εφαρμόστε την προστασία και κατεβάστε το παραγόμενο αρχείο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Προστασία Εγγραφής Παρουσιάσεων](/slides/el/androidjava/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού ανοίγματος και κωδικού προστασίας εγγραφής;**

Ο κωδικός ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ο κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό ανοίγματος χωρίς να φορτώσω όλες τις διαφάνειες;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε αν υπάρχει προστασία με κωδικό ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε ολοκληρωμένο αντικείμενο παρουσίασης.

**Υποστηρίζουν οι ροές εργασίας ελέγχου κωδικού και τα PPT και PPTX;**

Ναι. Η ανίχνευση και η επικύρωση κωδικού με βάση τη διαδρομή αρχείου ή το ρεύμα λειτουργούν κατά τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.