---
title: Προστασία Παρουσιάσεων με Κωδικό στην .NET
linktitle: Προστασία Κωδικού
type: docs
weight: 20
url: /el/net/password-protected-presentation/
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
  - .NET
  - C#
  - Aspose.Slides
description: "Κρυπτογραφήστε, εντοπίστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX με προστασία κωδικού στην C# με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός πρόσβασης απαιτείται για τη φόρτωση και προβολή του περιεχομένου της παρουσίασης, έτσι αυτή η προστασία παρέχει εμπιστευτικότητα.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό πρόσβασης προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση, αλλά δεν κρυπτογραφεί το περιεχόμενο ή εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για την τροποποίηση παρουσιάσεων, δείτε [Προστασία Παρουσιάσεων κατά την εγγραφή](/slides/el/net/write-protected-presentation/).

Οι παρακάτω ροές εργασίας εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όταν η συμπεριφορά τους βάσει αρχείου και ροής είναι σημαντική.

## **Κρυπτογράφηση Παρουσίας με Κωδικό Πρόσβασης Ανοίγματος**

Χρησιμοποιήστε το [IProtectionManager.Encrypt](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/encrypt/) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια, χρησιμοποιήστε το [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το παρακάτω παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Φόρτωση Κρυπτογραφημένης Παρουσίας**

Ορίστε το [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/) στον κωδικό πρόσβασης ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός πρόσβασης ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
```

## **Αφαίρεση Κρυπτογράφησης από Παρουσίαση**

Φορτώστε την παρουσίαση με τον κωδικό πρόσβασης ανοίγματος, καλέστε το [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/removeencryption/), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό πρόσβασης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Επικύρωση Κωδικού Πρόσβασης Ανοίγματος Πριν τη Φόρτωση**

Χρησιμοποιήστε το [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/) χωρίς τη δημιουργία πλήρους παρουσιαστικού αντικειμένου. Ελέγξτε το [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/ispasswordprotected/) πριν ζητήσετε ή επαληθεύσετε έναν κωδικό πρόσβασης. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Ροή Εργασίας με Διαδρομή Αρχείου**

Το παρακάτω παράδειγμα επικυρώνει έναν κωδικό πρόσβασης ανοίγματος για ένα αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/), και στη συνέχεια φορτώνει την πλήρη παρουσίαση:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Ροή Εργασίας με Ροή**

Η υπερφόρτωση ροής του [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει την ίδια ροή εργασίας. Επαναρυθμίστε τη θέση μιας ροής με δυνατότητα αναζήτησης πριν τη φόρτωση της πλήρης παρουσίασης από αυτήν τη ροή.

Το παρακάτω παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Τιμές Επιστροφής CheckPassword**

Το [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkpassword/) επιστρέφει `true` μόνο όταν η παρουσίαση έχει κωδικό πρόσβασης ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε κάθε μία από τις ακόλουθες περιπτώσεις:

- Ο κωδικός πρόσβασης είναι λανθασμένος.
- Η παρουσίαση δεν διαθέτει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός πρόσβασης είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Έλεγχος Εάν μια Φορτωμένη Παρουσίαση είναι Κρυπτογραφημένη**

Αφού φορτώσετε μια παρουσίαση με τον σωστό κωδικό πρόσβασης, ελέγξτε το [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/isencrypted/) για να επιβεβαιώσετε ότι η πηγή της παρουσίασης ήταν κρυπτογραφημένη. Για να εντοπίσετε την προστασία με κωδικό πρόσβασης ανοίγματος πριν τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo.IsPasswordProtected` όπως φαίνεται παραπάνω.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Συστάσεις Ασφάλειας**

{{% alert color="warning" title="Security" %}}
Μην καταγράφετε τους κωδικούς πρόσβασης ανοίγματος ούτε τους συμπεριλαμβάνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατώντας τους κωδικούς πρόσβασης στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχημένο αποτέλεσμα επικύρωσης κατά τη άμεση φόρτωση της παρουσίασης.
{{% /alert %}}

## **Προστασία Παρουσίας με Κωδικό Πρόσβασης Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισαγάγετε έναν κωδικό πρόσβασης για προστασία προβολής.
1. Προαιρετικά, εισαγάγετε έναν ξεχωριστό κωδικό πρόσβασης για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το προκύπτον αρχείο.

{{% alert color="info" title="See also" %}}
- [Προστασία Παρουσιάσεων κατά την εγγραφή](/slides/el/net/write-protected-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ κωδικού πρόσβασης ανοίγματος και κωδικού πρόσβασης προστασίας εγγραφής;**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός πρόσβασης προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Μπορώ να επικυρώσω έναν κωδικό πρόσβασης ανοίγματος χωρίς τη φόρτωση όλων των διαφανειών;**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε εάν υπάρχει προστασία με κωδικό πρόσβασης ανοίγματος, και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Υποστηρίζουν οι ροές ελέγχου κωδικού πρόσβασης τόσο PPT όσο και PPTX;**

Ναι. Η ανίχνευση και επικύρωση κωδικού πρόσβασης βάσει διαδρομής αρχείου και ροής συμπεριφέρονται με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.