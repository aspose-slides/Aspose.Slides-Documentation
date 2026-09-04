---
title: "Προστασία Παρουσιάσεων με Κωδικό στο .NET"
linktitle: "Προστασία με Κωδικό"
type: docs
weight: 20
url: /el/net/password-protected-presentation/
keywords:
- παρουσίαση προστατευμένη με κωδικό
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
description: "Κρυπτογραφήστε, ανιχνεύστε, επικυρώστε, ανοίξτε και αποκρυπτογραφήστε παρουσιάσεις PowerPoint PPT και PPTX προστατευμένες με κωδικό σε C# με το Aspose.Slides για .NET."
---
## **Overview**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί μια παρουσίαση. Ο σωστός κωδικός απαιτείται για να φορτωθεί και να προβληθεί το περιεχόμενο της παρουσίασης, επομένως αυτή η προστασία παρέχει εχεμύθεια.

Ένας κωδικός πρόσβασης ανοίγματος διαφέρει από έναν κωδικό προστασίας εγγραφής. Η προστασία εγγραφής περιορίζει την τροποποίηση αλλά δεν κρυπτογραφεί το περιεχόμενο ή εμποδίζει τη φόρτωση της παρουσίασης. Για τη διαχείριση κωδικών πρόσβασης για τροποποίηση παρουσιάσεων, δείτε [Write-Protect Presentations](/slides/el/net/write-protected-presentation/).

Οι ροές εργασίας παρακάτω ισχύουν και για παρουσιάσεις PPT και PPTX. Τα παραδείγματα χρησιμοποιούν και τις δύο μορφές όπου η συμπεριφορά βάσει αρχείου και ροής είναι σημαντική.

## **Encrypt a Presentation with an Opening Password**

Χρησιμοποιήστε [IProtectionManager.Encrypt](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/encrypt/) για να ορίσετε έναν κωδικό πρόσβασης ανοίγματος. Στη συνέχεια χρησιμοποιήστε [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) για να αποθηκεύσετε την κρυπτογραφημένη παρουσίαση.

Το ακόλουθο παράδειγμα κρυπτογραφεί μια παρουσίαση PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Keep Document Properties Public**

Από προεπιλογή, το Aspose.Slides περιλαμβάνει τις ιδιότητες του εγγράφου στην κρυπτογράφηση της παρουσίασης. Η ιδιότητα [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ελέγχει αυτή τη συμπεριφορά ανεξάρτητα από την κρυπτογράφηση του περιεχομένου των διαφάνειων. Ορίστε την σε `false` πριν καλέσετε [IProtectionManager.Encrypt](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/encrypt/) όταν ένα σύστημα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων πρέπει να διαβάσει τα μεταδεδομένα χωρίς τον κωδικό ανοίγματος.

Το ακόλουθο παράδειγμα δημιουργεί μια κρυπτογραφημένη παρουσίαση PPTX ενώ αφήνει τις ενσωματωμένες ιδιότητες του εγγράφου δημόσιες:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Ο ορισμός του `EncryptDocumentProperties` σε `false` δεν καθιστά τις διαφάνειες, τα master, τα layout, τα σχήματα, τα πολυμέσα ή άλλο περιεχόμενο της παρουσίασης δημόσια. Επηρεάζει μόνο τις ιδιότητες του εγγράφου. Για να διαβάσετε αυτές τις ιδιότητες χωρίς να φορτώσετε το κρυπτογραφημένο περιεχόμενο, δείτε [Manage Presentation Properties](/slides/el/net/presentation-properties/).

## **Load an Encrypted Presentation**

Ορίστε το [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/) στον κωδικό ανοίγματος και περάστε τις επιλογές στο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) κατά τη φόρτωση του αρχείου. Η φόρτωση αποτυγχάνει όταν απαιτείται κωδικός ανοίγματος αλλά ο παρεχόμενος κωδικός λείπει ή είναι λανθασμένος.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Εργαστείτε με την αποκρυπτογραφημένη παρουσίαση.
```

## **Remove Encryption from a Presentation**

Φορτώστε την παρουσίαση με τον κωδικό ανοίγματος, καλέστε [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/removeencryption/), και αποθηκεύστε το αποτέλεσμα. Η αποθηκευμένη παρουσίαση μπορεί στη συνέχεια να φορτωθεί χωρίς κωδικό.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validate an Opening Password Before Loading**

Χρησιμοποιήστε [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) για να αποκτήσετε το [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/) χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης. Ελέγξτε το [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/ispasswordprotected/) πριν ζητήσετε ή επικυρώσετε έναν κωδικό. Όταν υπάρχει προστασία, επικυρώστε την παρεχόμενη τιμή με το [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkpassword/).

### **File-Path Workflow**

Το ακόλουθο παράδειγμα επικυρώνει έναν κωδικό ανοίγματος για αρχείο PPTX, περνά την επικυρωμένη τιμή στο [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/), και έπειτα φορτώνει την πλήρη παρουσίαση:

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

### **Stream Workflow**

Η υπερφόρτωση ροής του [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει την ίδια ροή εργασίας. Επαναρυθμίστε τη θέση μιας αναζητήσιμης ροής πριν φορτώσετε την πλήρη παρουσίαση από αυτή τη ροή.

Το ακόλουθο παράδειγμα χρησιμοποιεί ένα αρχείο PPT:

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

### **CheckPassword Return Values**

Το [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkpassword/) επιστρέφει `true` μόνο όταν η παρουσίαση διαθέτει κωδικό ανοίγματος και ο παρεχόμενος κωδικός είναι σωστός. Επιστρέφει `false` σε καθένα από τα παρακάτω:

- Ο κωδικός είναι λανθασμένος.
- Η παρουσίαση δεν έχει κωδικό πρόσβασης ανοίγματος.
- Ο παρεχόμενος κωδικός είναι `null` ή κενός.

Η συμπεριφορά είναι η ίδια για παρουσιάσεις PPT και PPTX.

## **Check Whether a Loaded Presentation Is Encrypted**

Μετά τη φόρτωση μιας παρουσίασης με τον σωστό κωδικό, ελέγξτε το [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/isencrypted/) για να επιβεβαιώσετε ότι η πηγή παρουσίασης ήταν κρυπτογραφημένη. Για ανίχνευση προστασίας κωδικού ανοίγματος πριν από τη φόρτωση, χρησιμοποιήστε το `IPresentationInfo.IsPasswordProtected` όπως φαίνεται παραπάνω.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Security Recommendations**

{{% alert color="warning" title="Ασφάλεια" %}}
Μην καταγράφετε τους κωδικούς ανοίγματος ή τους συμπεριλαμβάνετε σε μηνύματα διάγνωσης. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης, κρατήστε τους κωδικούς στη μνήμη μόνο όσο χρειάζεται, και επαναχρησιμοποιήστε ένα επιτυχές αποτέλεσμα επικύρωσης όταν φορτώνετε αμέσως την παρουσίαση.

Οι δημόσιες ιδιότητες εγγράφου μπορούν να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές παρόλο που το περιεχόμενο της παρουσίασης είναι κρυπτογραφημένο. Κρυπτογραφήστε ευαίσθητα μεταδεδομένα μαζί με την παρουσίαση. Η διατήρηση των ιδιοτήτων ως δημόσιες πρέπει να είναι σαφής απόφαση, που λαμβάνεται μόνο όταν τα συστήματα πρέπει να ευρετηριάσουν, ταξινομήσουν, αναζητήσουν ή διαχειριστούν το αρχείο χωρίς κωδικό ανοίγματος.
{{% /alert %}}

## **Password-Protect a Presentation Online**

1. Ανοίξτε την εφαρμογή [Aspose.Slides Lock](https://products.aspose.app/slides/el/lock).
1. Επιλέξτε ή ανεβάστε την παρουσίαση.
1. Εισαγάγετε έναν κωδικό για προστασία προβολής.
1. Προαιρετικά εισαγάγετε έναν ξεχωριστό κωδικό για προστασία επεξεργασίας.
1. Εφαρμόστε την προστασία και κατεβάστε το παραγόμενο αρχείο.

{{% alert color="info" title="Δείτε επίσης" %}}
- [Write-Protect Presentations](/slides/el/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/el/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**What is the difference between an opening password and a write-protection password?**

Ένας κωδικός πρόσβασης ανοίγματος κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Ένας κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση χωρίς να κρυπτογραφεί το περιεχόμενο.

**Can I validate an opening password without loading all slides?**

Ναι. Αποκτήστε πληροφορίες παρουσίασης, ελέγξτε αν υπάρχει προστασία κωδικού ανοίγματος και επικυρώστε τον κωδικό πριν δημιουργήσετε ένα πλήρες αντικείμενο παρουσίασης.

**Can an application read metadata without the opening password?**

Ναι, αλλά μόνο όταν η παρουσίαση κρυπτογραφήθηκε με το `EncryptDocumentProperties` ορισμένο σε `false`. Η εφαρμογή πρέπει τότε να χρησιμοποιήσει τη λειτουργία φόρτωσης μόνο ιδιοτήτων εγγράφου όπως περιγράφεται στην [Manage Presentation Properties](/slides/el/net/presentation-properties/).

**Do the password-checking workflows support both PPT and PPTX?**

Ναι. Οι διαδικασίες ανίχνευσης και επικύρωσης κωδικού βάσει διαδρομής αρχείου ή ροής συμπεριφέρονται με τον ίδιο τρόπο για παρουσιάσεις PPT και PPTX.