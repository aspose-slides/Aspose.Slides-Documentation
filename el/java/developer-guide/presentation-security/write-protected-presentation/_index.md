---
title: Προστασία Εγγραφής Παρουσιάσεων σε Java
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/java/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Ορίστε, ανιχνεύστε, επικυρώστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για Java."
---
## **Εισαγωγή**

Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, ενδέχεται επίσης να μπορούν να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με άλλο όνομα, έτσι η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ένας κωδικός έναρξης εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για κρυπτογράφηση μιας παρουσίασης ή επαλήθευση κωδικού έναρξης, δείτε[Προστασία Παρουσιάσεων με Κωδικό](/slides/el/java/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και την αντίστοιχη μορφή αποθήκευσης PPT.

## **Ορισμός Προστασίας Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε[IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) για να ορίσετε έναν κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

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

Επειδή η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της παρουσίασης. Ο κωδικός σχετίζεται μόνο κατά την επαλήθευση εξουσιοδότησης για τροποποίηση της προστατευμένης παρουσίασης.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Μην περάσετε κωδικό προστασίας εγγραφής στη μέθοδο[ILoadOptions.setPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Αυτή η μέθοδος δέχεται έναν κωδικό έναρξης για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση διαθέτει και τους δύο τύπους προστασίας, παρέχετε τον κωδικό έναρξης για να τη φορτώσετε και διαχειριστείτε χωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) για να αφαιρέσετε τον περιορισμό τροποποίησης, στη συνέχεια αποθηκεύστε την παρουσίαση.

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

## **Έλεγχος Εάν μια Παρουσίαση είναι Προστατευμένη Εγγραφή**

Για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο[Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/)instance, καλέστε[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) και εξετάστε[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Η μέθοδος χρησιμοποιεί το[NullableBool](https://reference.aspose.com/slides/el/java/com.aspose.slides/nullablebool/) και επιστρέφει`NullableBool.True` όταν εντοπίζεται προστασία εγγραφής.

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

Η εκδοχή με ροή της μεθόδου[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ροή.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε ολόκληρη την παρουσίαση. Ελέγξτε πρώτα το[IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει κωδικό έναρξης ή καθορίζει εάν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντίστροφα,[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/el/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) επικυρώνει μόνο κωδικό έναρξης. Εάν έχει ήδη φορτωθεί πλήρης παρουσίαση,[IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/el/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) παρέχει τον ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας του.

Σε παραγωγικές εφαρμογές, μην καταγράφετε κωδικούς ή τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρείτε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο.

{{% alert color="info" title="See also" %}}
- [Προστασία Παρουσιάσεων με Κωδικό](/slides/el/java/password-protected-presentation/)
- [Παρουσιάσεις Μόνο για Ανάγνωση](/slides/el/java/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει την τροποποίηση, αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός έναρξης απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει τόσο κωδικό έναρξης όσο και κωδικό προστασίας εγγραφής;**

Ναι. Παρέχετε τον κωδικό έναρξης μέσω των επιλογών φόρτωσης για το άνοιγμα της κρυπτογραφημένης παρουσίασης και επικυρώστε ξεχωριστά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.