---
title: Περιορισμοί API
type: docs
weight: 320
url: /el/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Γνωρίστε τους περιορισμούς του Aspose.Slides for C++: οι εξαγωγές ορίζουν σταθερά μεταδεδομένα Application/Producer σε PPT, PPTX, ODP και PDF—βοηθώντας σας να προγραμματίσετε ενσωματώσεις χωρίς εκπλήξεις."
---
## **Επισκόπηση**

Όταν δημιουργούνται ή εξάγονται παρουσιάσεις με Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που σχετίζονται με τα πεδία μεταδεδομένων `Application`, `Creator` και `Producer` σε αρχεία PPTX και PDF.

## **Εφαρμογή και Παραγωγός**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με Aspose.Slides for C++, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία συνήθως προκαλούν ερωτήσεις:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for C++, αυτή η τιμή είναι σταθερή και εμφανίζει τον προμηθευτή της βιβλιοθήκης αντί για το όνομα της εφαρμογής σας, ακόμη και αν χρησιμοποιήσετε [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/el/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** προσδιορίζει τη μηχανή απόδοσης που δημιούργησε το τελικό αρχείο κατά την εξαγωγή. Στις εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for C++, και τα δύο είναι σταθερά και αντανακλούν τη βιβλιοθήκη και την έκδοσή της.

**Τι είναι περιορισμένο**

Δεν μπορείτε να παρακάμψετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως "Aspose.Slides for C++". Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως "Aspose.Slides for C++ x.x.x". Αυτή η συμπεριφορά είναι σχεδιασμένη και εφαρμόζεται ανεξαρτήτως του τρόπου φόρτωσης ή αποθήκευσης του αρχείου, καθώς και ανεξαρτήτως των τιμών που έχουν οριστεί μέσω του [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/el/cpp/aspose.slides/documentproperties/set_nameofapplication/).