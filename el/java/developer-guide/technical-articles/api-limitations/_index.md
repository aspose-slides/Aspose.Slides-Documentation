---
title: Περιορισμοί Μεταδεδομένων Εξόδου
type: docs
weight: 320
url: /el/java/api-limitations/
keywords:
- Περιορισμοί API
- μορφή εξαγωγής
- εφαρμογή
- παραγωγός
- Ιδιότητες εγγράφου
- μεταδεδομένα
- γεννήτρια
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Το Aspose.Slides for Java γράφει σταθερά μεταδεδομένα εφαρμογής, δημιουργού και παραγωγού στα αποθηκευμένα αρχεία PPTX, PDF και ODP, ανεξάρτητα από το όνομα εφαρμογής που έχετε ορίσει."
---
## **Επισκόπηση**

Όταν δημιουργούνται ή εξάγονται παρουσιάσεις με Aspose.Slides, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο εξόδου. Αυτό το άρθρο εξηγεί τους περιορισμούς που σχετίζονται με τα πεδία μεταδεδομένων `Application`, `Creator`, `Producer` και generator στα αρχεία PPTX, PDF και ODP.

## **Application και Producer**

Όταν δημιουργείτε ή εξάγετε παρουσιάσεις με Aspose.Slides for Java, ορισμένα τεχνικά μεταδεδομένα γράφονται στο αρχείο. Δύο πεδία συχνά εγείρουν ερωτήσεις:

**Application** προσδιορίζει το πρόγραμμα που δημιούργησε ή αποθήκευσε τελευταία μια παρουσίαση **PPTX**. Στο Aspose.Slides for Java, αυτή η τιμή είναι σταθερή και εμφανίζει το όνομα της βιβλιοθήκης αντί του ονόματος της εφαρμογής σας, ακόμη και αν χρησιμοποιήσετε [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** προσδιορίζει τη μηχανή απόδοσης που παρήγαγε το τελικό αρχείο κατά την εξαγωγή. Σε εξαγωγές **PDF**, τα μεταδεδομένα χρησιμοποιούν τα πεδία **Creator** και **Producer**. Με το Aspose.Slides for Java, και τα δύο αυτά πεδία είναι σταθερά και αντανακλούν τη βιβλιοθήκη και την έκδοσή της.

**Τι είναι περιορισμένο**

Δεν μπορείτε να παρακάμψετε αυτά τα πεδία μέσω του API για τις παραπάνω μορφές. Για **PPTX**, η ιδιότητα Application γράφεται ως "Aspose.Slides for Java". Για **PDF**, οι ιδιότητες Creator και Producer γράφονται ως "Aspose.Slides for Java" ακολουθούμενο από την έκδοση της βιβλιοθήκης. Για **ODP**, το πεδίο generator γράφεται ως "Aspose.Slides for Java" ακολουθούμενο από την έκδοση της βιβλιοθήκης. Αυτή η συμπεριφορά είναι σχεδιασμένη και ισχύει ανεξάρτητα από το πώς φορτώνετε ή αποθηκεύετε το αρχείο, καθώς και ανεξάρτητα από τις τιμές που έχουν οριστεί χρησιμοποιώντας [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Αυτός ο περιορισμός δεν ισχύει για αρχεία **PPT**: σε ένα αρχείο PPT, το όνομα της εφαρμογής που ορίζετε με [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/el/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) αποθηκεύεται.