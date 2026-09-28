---
title: Περιορισμοί Μεταδεδομένων Εξόδου
type: docs
weight: 320
url: /el/net/api-limitations/
keywords:
- Περιορισμοί API
- μορφή εξαγωγής
- εφαρμογή
- παραγωγός
- ιδιότητες εγγράφου
- μεταδεδομένα
- δημιουργός
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Το Aspose.Slides for .NET γράφει σταθερά μεταδεδομένα εφαρμογής, δημιουργού και παραγωγού σε αποθηκευμένα αρχεία PPTX, PDF και ODP, ό,τι όνομα εφαρμογής και αν ορίσετε."
---
## **Επισκόπηση**

Όταν παρουσιάσεις δημιουργούνται ή εξάγονται με το Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που αφορούν τα πεδία μεταδεδομένων `Application`, `Creator`, `Producer` και generator στα αρχεία PPTX, PDF και ODP.

## **Εφαρμογή και Παραγωγός**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με το Aspose.Slides for .NET, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία συχνά εγείρουν ερωτήσεις:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for .NET, αυτή η τιμή είναι σταθερή και εμφανίζει το όνομα της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμα και αν ορίσετε [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for .NET, και τα δύο είναι σταθερά και αντικατοπτρίζουν τη βιβλιοθήκη και την έκδοση της.

## **Τι περιορίζεται**

Δεν μπορείτε να αντικαταστήσετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως "Aspose.Slides for .NET". Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως "Aspose.Slides for .NET" ακολουθούμενο από την έκδοση της βιβλιοθήκης. Για **ODP**, το πεδίο generator γράφεται ως "Aspose.Slides for .NET" ακολουθούμενο από την έκδοση της βιβλιοθήκης. Αυτή η συμπεριφορά είναι σκόπιμη και ισχύει ανεξαρτήτως του τρόπου φόρτωσης ή αποθήκευσης του αρχείου, καθώς και ανεξαρτήτως των τιμών που έχουν οριστεί στο [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

Αυτή η περιοριστική ενέργεια δεν ισχύει για αρχεία **PPT**: σε ένα αρχείο PPT, το όνομα εφαρμογής που έχετε ορίσει στο [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) αποθηκεύεται.