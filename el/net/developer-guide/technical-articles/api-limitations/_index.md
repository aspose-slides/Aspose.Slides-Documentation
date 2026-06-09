---
title: Περιορισμοί API
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
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Γνωρίστε τους περιορισμούς του Aspose.Slides for .NET: οι εξαγωγές ορίζουν σταθερά μεταδεδομένα Application/Producer σε PPT, PPTX, ODP και PDF—σας βοηθάει να σχεδιάσετε ενσωματώσεις χωρίς εκπλήξεις."
---
## **Επισκόπηση**

Όταν δημιουργούνται ή εξάγονται παρουσιάσεις με Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που σχετίζονται με τα πεδία μεταδεδομένων `Application`, `Creator` και `Producer` σε αρχεία PPTX και PDF.

## **Application και Producer**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με Aspose.Slides for .NET, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία προκαλούν συχνά ερωτήματα:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for .NET, αυτή η τιμή είναι σταθερή και εμφανίζει τον προμηθευτή της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμη και αν ορίσετε [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/el/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for .NET, και τα δύο είναι σταθερά και αντικατοπτρίζουν τη βιβλιοθήκη και την έκδοσή της.

**Τι περιορίζεται**

Δεν μπορείτε να παρακάμψετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως "Aspose.Slides for .NET". Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως "Aspose.Slides for .NET x.x.x". Αυτή η συμπεριφορά είναι προκαθορισμένη και ισχύει ανεξάρτητα από το πώς φορτώνετε ή αποθηκεύετε το αρχείο, καθώς και ανεξάρτητα από τις τιμές που έχουν οριστεί στο [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/el/net/aspose.slides/documentproperties/nameofapplication/).