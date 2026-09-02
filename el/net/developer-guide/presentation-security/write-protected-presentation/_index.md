---
title: Προστασία Εγγραφής Παρουσιάσεων σε .NET
linktitle: Προστασία Εγγραφής
type: docs
weight: 25
url: /el/net/write-protected-presentation/
keywords:
- προστασία εγγραφής
- προστασία εγγραφής PowerPoint
- κωδικός για τροποποίηση
- περιορισμός επεξεργασίας παρουσίασης
- αφαίρεση προστασίας εγγραφής
- επικύρωση κωδικού τροποποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ορίστε, ανιχνεύστε, επικυρώστε και αφαιρέστε κωδικούς προστασίας εγγραφής σε παρουσιάσεις PowerPoint PPT και PPTX χρησιμοποιώντας το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Ο κωδικός προστασίας εγγραφής περιορίζει την τροποποίηση μιας παρουσίασης, αλλά δεν κρυπτογραφεί το περιεχόμενό της. Οι χρήστες μπορούν να φορτώσουν και να προβάλουν μια παρουσίαση με προστασία εγγραφής χωρίς τον κωδικό. Ανάλογα με την εφαρμογή, μπορεί επίσης να μπορούν να επεξεργαστούν το περιεχόμενο και να το αποθηκεύσουν με διαφορετικό όνομα, επομένως η προστασία εγγραφής δεν πρέπει να θεωρείται μηχανισμός εμπιστευτικότητας.

Ο κωδικός ανοίγματος εξυπηρετεί διαφορετικό σκοπό: κρυπτογραφεί την παρουσίαση και απαιτείται για τη φόρτωση του περιεχομένου της. Για να κρυπτογραφήσετε μια παρουσίαση ή να επικυρώσετε έναν κωδικό ανοίγματος, δείτε [Password-Protect Presentations](/slides/el/net/password-protected-presentation/).

Οι ροές εργασίας σε αυτό το άρθρο εφαρμόζονται τόσο σε παρουσιάσεις PPT όσο και PPTX. Τα παραδείγματα χρησιμοποιούν αρχεία PPTX· όταν αποθηκεύετε σε PPT, χρησιμοποιήστε την επέκταση `.ppt` και τη σχετική μορφή αποθήκευσης PPT.

## **Ορισμός Προστασίας Εγγραφής σε Παρουσίαση**

Χρησιμοποιήστε το [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/setwriteprotection/) για να ορίσετε έναν κωδικό για την τροποποίηση μιας παρουσίασης. Η αποθήκευση της παρουσίασης διατηρεί τη ρύθμιση προστασίας.

Το παρακάτω παράδειγμα ορίζει προστασία εγγραφής σε μια παρουσίαση PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Φόρτωση Παρουσίασης με Προστασία Εγγραφής**

Καθώς η προστασία εγγραφής δεν κρυπτογραφεί το περιεχόμενο της παρουσίασης, δεν απαιτείται κωδικός για τη φόρτωση της. Ο κωδικός είναι σχετικός μόνο κατά την επικύρωση εξουσιοδότησης για τροποποίηση της προστατευμένης παρουσίασης.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Μην περάσετε κωδικό προστασίας εγγραφής στο [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/). Αυτή η ιδιότητα δέχεται έναν κωδικό ανοίγματος για κρυπτογραφημένο περιεχόμενο. Εάν μια παρουσίαση έχει και τους δύο τύπους προστασίας, δώστε τον κωδικό ανοίγματος για να τη φορτώσετε και διαχειριστείτε ξεχωριστά τον κωδικό προστασίας εγγραφής.

## **Αφαίρεση Προστασίας Εγγραφής από Παρουσίαση**

Χρησιμοποιήστε το [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/removewriteprotection/) για να αφαιρέσετε τον περιορισμό τροποποίησης, στη συνέχεια αποθηκεύστε την παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Έλεγχος Εάν μια Παρουσίαση Είναι Προστατευμένη Εγγραφή**

Για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε ένα πλήρες αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), καλέστε το [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) και εξετάστε το [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/iswriteprotected/). Η ιδιότητα χρησιμοποιεί το [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/) και επιστρέφει `NullableBool.True` όταν ανιχνεύεται προστασία εγγραφής.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Η έκδοση με ροή του [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationfactory/getpresentationinfo/) παρέχει τις ίδιες πληροφορίες για μια παρουσίαση που παρέχεται ως ροή.

## **Επικύρωση Κωδικού Προστασίας Εγγραφής**

Χρησιμοποιήστε το [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkwriteprotection/) για να επικυρώσετε έναν κωδικό τροποποίησης χωρίς να φορτώσετε ολόκληρη την παρουσίαση. Ελέγξτε πρώτα το [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/iswriteprotected/) ώστε η εφαρμογή να ζητά ή να επικυρώνει κωδικό μόνο όταν υπάρχει προστασία εγγραφής.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

Το [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkwriteprotection/) επικυρώνει μόνο τον κωδικό προστασίας εγγραφής. Δεν επικυρώνει έναν κωδικό ανοίγματος ούτε καθορίζει αν μπορεί να φορτωθεί κρυπτογραφημένο περιεχόμενο. Αντίστροφα, το [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/checkpassword/) επικυρώνει μόνο έναν κωδικό ανοίγματος. Εάν έχει ήδη φορτωθεί μια πλήρης παρουσίαση, το [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/checkwriteprotection/) παρέχει το ισοδύναμο έλεγχο προστασίας εγγραφής μέσω του διαχειριστή προστασίας.

Σε παραγωγικές εφαρμογές, μην καταγράφετε κωδικούς ή τους ενσωματώνετε σε διαγνωστικά μηνύματα. Αποφύγετε περιττές επαναλαμβανόμενες προσπάθειες επικύρωσης και διατηρείτε τους κωδικούς στη μνήμη μόνο όσο είναι απαραίτητο.

{{% alert color="info" title="See also" %}}
- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/net/password-protected-presentation/)
- [Παρουσιάσεις Μόνο για Ανάγνωση](/slides/el/net/read-only-presentation/)
- [Ψηφιακή Υπογραφή στο PowerPoint](/slides/el/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Κρυπτογραφεί η προστασία εγγραφής μια παρουσίαση;**

Όχι. Περιορίζει τη τροποποίηση, αλλά αφήνει το περιεχόμενο της παρουσίασης διαθέσιμο για φόρτωση και προβολή.

**Απαιτείται ο κωδικός προστασίας εγγραφής για το άνοιγμα μιας παρουσίασης;**

Όχι. Μόνο ένας κωδικός ανοίγματος απαιτείται για τη φόρτωση κρυπτογραφημένου περιεχομένου παρουσίασης.

**Μπορεί μια παρουσίαση να έχει τόσο κωδικό ανοίγματος όσο και κωδικό προστασίας εγγραφής;**

Ναι. Παρέχετε τον κωδικό ανοίγματος μέσω των επιλογών φόρτωσης για να ανοίξετε την κρυπτογραφημένη παρουσίαση και επικυρώστε διαχωριστικά τον κωδικό προστασίας εγγραφής όταν απαιτείται εξουσιοδότηση τροποποίησης.