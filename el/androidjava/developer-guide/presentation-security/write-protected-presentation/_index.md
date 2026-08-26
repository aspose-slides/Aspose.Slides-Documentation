---
title: Προστασία Εγγραφής Παρουσιάσεων σε Android
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/androidjava/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ορισμός, ανίχνευση, επικύρωση και αφαίρεση κωδικών προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για Android μέσω Java."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να είναι δυνατόν να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με διαφορετικό όνομα, επομένως η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ένας κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για κρυπτογράφηση παρουσίασης ή επαλήθευση κωδικού ανοίγματος, δείτε [Προστασία Παρουσίασης με Κωδικό](/slides/el/androidjava/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο ισχύουν για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός Προστασίας Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε το [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) για να ορίσετε κωδικό πρόσβασης για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Φόρτωση Παρουσίασης με Προστασία Εγγραφής**

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός είναι σχετικός μόνο όταν επαληθεύεται η εξουσιοδότηση για τροποποίηση της προστατευμένης παρουσίασης.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Μην περάσετε κωδικό προστασίας εγγραφής στο [ILoadOptions.setPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Αυτή η μέθοδος δέχεται κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση έχει και τους δύο τύπους προστασίας, παρέχετε τον κωδικό ανοίγματος για τη φόρτωση και χειριστείτε ξεχωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε το [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) για να αφαιρέσετε τον περιορισμό τροποποίησης, στη συνέχεια αποθηκεύστε την παρουσίαση.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Έλεγχος Αν μια Παρουσίαση Είναι Προστατευμένη Εγγραφής**

Για να εξετάσετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/), καλέστε το [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) και ελέγξτε το [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Η μέθοδος χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/nullablebool/) και επιστρέφει `NullableBool.True` όταν εντοπιστεί προστασία εγγραφής.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

Η υπερφόρτωση ροής του [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ροή.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε το [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς τη φόρτωση ολόκληρης της παρουσίασης. Ελέγξτε πρώτα το [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει κωδικό ανοίγματος ή καθορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντίστροφα, το [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν μια πλήρης παρουσίαση έχει ήδη φορτωθεί, το [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) παρέχει το ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας.

Σε παραγωγικές εφαρμογές, μην καταγράφετε κωδικούς ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρήστε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/androidjava/password-protected-presentation/)
- [Παρουσιάσεις μόνο για ανάγνωση](/slides/el/androidjava/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει την τροποποίηση αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει και κωδικό ανοίγματος και κωδικό προστασίας εγγραφής;**

Ναι. Παρέχετε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.